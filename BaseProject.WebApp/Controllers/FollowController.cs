using BaseProject.ApiIntegration;
using BaseProject.ApiIntegration.Post;
using BaseProject.ApiIntegration.User;
using BaseProject.Data.Entities;
using BaseProject.ViewModels.System.Users;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BaseProject.WebApp.Controllers
{
    [Authorize]
    public class FollowController : Controller
    {
        private readonly IUserApiClient _userApiClient;
        private readonly IPostApiClient _postApiClient;
        private readonly BaseApiClient _baseApiClient;

        public FollowController(IUserApiClient userApiClient, IPostApiClient postApiClient, BaseApiClient baseApiClient)
        {
            _userApiClient = userApiClient;
            _postApiClient = postApiClient;
            _baseApiClient = baseApiClient;
        }


        [HttpGet]
        public async Task<IActionResult> Index(string keyword, int pageIndex = 1, int pageSize = 10)
        {
            var user = User.Identity.Name;

            var request = new GetUserPagingRequest()
            {
                Keyword = keyword,
                PageIndex = pageIndex,
                PageSize = pageSize,
                UserName = user
            };
            var data = await _userApiClient.GetFollowersPagings(request);
            ViewBag.Keyword = keyword;
            ViewBag.Name = user;
            ViewBag.Token = _baseApiClient.GetToken();
            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];
            }
            return View(data.ResultObj);
        }


        // Lấy tất cả bài viết của những người theo dõi
        // Nếu tìm kiếm tất cả _ Lưu lịch sử tìm kiếm
        [HttpGet]
        public async Task<IActionResult> IndexAll(string keyword, int pageIndex = 1, int pageSize = 10)
        {

            // 3: Tìm kiếm bài viết tất cả
            var request = new GetUserPagingRequest()
            {
                UserName = User.Identity.Name,
                Keyword = keyword,
                Keyword2 = "",
                PageIndex = pageIndex,
                PageSize = pageSize,
                number = 3
            };
            var data = await _postApiClient.GetAllFollowPostPagings(request);
            ViewBag.Keyword = keyword;
            ViewBag.Token = _baseApiClient.GetToken();
            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];
            }
            foreach (var item in data.ResultObj.Items)
            {
                string editorContent = item.Content;
                HtmlDocument document = new HtmlDocument();
                document.LoadHtml(editorContent);

                // Loại bỏ các thẻ không mong muốn
                RemoveUnwantedTags(document.DocumentNode);

                // Lấy nội dung đã xử lý
                string sanitizedContent = document.DocumentNode.OuterHtml;

                if (sanitizedContent.Length > 200)
                {
                    item.Content = sanitizedContent.Substring(0, 200);
                }
                else
                {
                    item.Content = sanitizedContent;
                }

            }

            return View(data.ResultObj);
        }

       

        [HttpPost]
        public async Task<IActionResult> AddFollow(FollowViewModel following)
        {
            if (following == null)
            {
                return BadRequest();
            }
            var result = await _userApiClient.AddFollow(following);

            if (result.IsSuccessed)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> UnFollow(FollowViewModel following)
        {
            if (following == null)
            {
                return BadRequest();
            }
            var result = await _userApiClient.UnFollow(following);

            if (result.IsSuccessed)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> CheckFollow(FollowViewModel follow)
        {
            if (follow == null)
            {
                return NotFound();
            }
            var result = await _userApiClient.CheckFollow(follow);

            if (result.IsSuccessed)
            {
                ViewBag.Follow = 1;
                return Ok(1);
            }
            ViewBag.Follow = 0;
            return Ok(0);
        }

        private void RemoveUnwantedTags(HtmlNode node)
        {
            if (node.NodeType == HtmlNodeType.Element)
            {
                // Danh sách các thẻ không mong muốn cần loại bỏ
                string[] unwantedTags = { "p", "a", "strong", "oembed", "span", "img" };

                if (node.Name == "figure")
                {
                    node.ParentNode.RemoveChild(node, true);
                    return;
                }
                else if (unwantedTags.Contains(node.Name))
                {
                    if (node.Name == "p" && node.ParentNode.Name == "figure")
                    {
                        node.Remove();
                    }
                    else if (node.Name == "strong" && node.ParentNode.Name == "p")
                    {
                        var strongContent = node.InnerHtml; // Lưu lại nội dung của thẻ strong
                        node.ParentNode.InsertBefore(HtmlNode.CreateNode(strongContent), node); // Thêm nội dung trước thẻ strong
                        node.Remove(); // Xóa thẻ strong
                    }
                    else if (node.Name == "img")
                    {
                        // Kiểm tra nội dung của thẻ img
                        if (string.IsNullOrWhiteSpace(node.InnerHtml))
                        {
                            node.ParentNode.RemoveChild(node);
                        }
                    }
                    else
                    {
                        foreach (var childNode in node.ChildNodes.ToList())
                        {
                            RemoveUnwantedTags(childNode);
                        }
                    }
                    return;
                }
            }

            foreach (var childNode in node.ChildNodes.ToList())
            {
                RemoveUnwantedTags(childNode);
            }
        }
    }
}
