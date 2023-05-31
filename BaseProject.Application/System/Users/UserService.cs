using BaseProject.Application.Catalog.Images;
using BaseProject.Application.Common;
using BaseProject.Data.EF;
using BaseProject.Data.Entities;
using BaseProject.ViewModels.Common;
using BaseProject.ViewModels.System.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject.Application.System.Users
{
    public class UserService : IUserService
    {
        private const string USER_CONTENT_FOLDER_NAME = "Images";
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IStorageService _storageService;
        private readonly IImageService _imageService;
        private readonly DataContext _dataContext;
        private readonly IConfiguration _config;
        private readonly IMemoryCache _cache;

        public UserService(UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            RoleManager<AppRole> roleManager,
            IStorageService storageService,
            IImageService imageService,
            DataContext dataContext,
            IConfiguration config,
            IMemoryCache cache)
        {
            _storageService = storageService;
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
            _dataContext = dataContext;
            _imageService = imageService;
            _config = config;
            _cache = cache;
        }

        public async Task<ApiResult<string>> Authenticate(LoginRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user == null) return new ApiErrorResult<string>("Tài khoản không tồn tại");

            var result = await _signInManager.PasswordSignInAsync(user, request.Password, request.RememberMe, true);
            if (!result.Succeeded)
            {
                return new ApiErrorResult<string>("Sai mật khẩu");
            }
            var roles = await _userManager.GetRolesAsync(user);
            var claims = new[]
            {
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.Role, string.Join(";",roles)),
                new Claim(ClaimTypes.Name, request.UserName)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Tokens:Issuer"],
                _config["Tokens:Issuer"],
                claims,
                expires: DateTime.Now.AddHours(3),
                signingCredentials: creds);


            //var cacheKey = $"user_{user.Id}";
            //_cache.Set(cacheKey, user, TimeSpan.FromMinutes(30));


            return new ApiSuccessResult<string>(new JwtSecurityTokenHandler().WriteToken(token));
        }

        public async Task<ApiResult<bool>> Delete(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null)
            {
                return new ApiErrorResult<bool>("User không tồn tại");
            }
            var reult = await _userManager.DeleteAsync(user);
            if (reult.Succeeded)
                return new ApiSuccessResult<bool>();

            return new ApiErrorResult<bool>("Xóa không thành công");
        }

        // Lấy thông tin user name - Admin
        public async Task<ApiResult<UserVm>> GetById(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null)
            {
                return new ApiErrorResult<UserVm>("User không tồn tại");
            }
            var roles = await _userManager.GetRolesAsync(user);
            var userVm = new UserVm()
            {
                Id = user.Id,
                Image = user.Image,
                Email = user.Email,
                Name = user.Name,
                DateOfBir = user.DateOfBir,
                Gender = user.Gender,
                UserName = user.UserName,
                Roles = roles,
                Description = user.Description,
                UserAddress = user.Address,
            };
            return new ApiSuccessResult<UserVm>(userVm);
        }

        // Xem thông tin user name -PUBLIC
        public async Task<ApiResult<UserVm>> GetByUserName(string username)
        {
            var user = await _userManager.FindByNameAsync(username);
            if (user == null)
            {
                return new ApiErrorResult<UserVm>("User không tồn tại");
            }
            var roles = await _userManager.GetRolesAsync(user);
            var userVm = new UserVm()
            {
                Id = user.Id,
                Image = user.Image,
                Email = user.Email,
                Name = user.Name,
                DateOfBir = user.DateOfBir,
                Gender = user.Gender,
                UserName = user.UserName,
                Roles = roles,
                Description = user.Description,
                UserAddress = user.Address
            };
            return new ApiSuccessResult<UserVm>(userVm);
        }

        public async Task<ApiResult<string>> GetToken(string request)
        {
            var user = await _userManager.FindByNameAsync(request);
            if (user == null) return new ApiErrorResult<string>("Tài khoản không tồn tại");

            var roles = await _userManager.GetRolesAsync(user);
            var claims = new[]
            {
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.Role, string.Join(";",roles)),
                new Claim(ClaimTypes.Name, request)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Tokens:Issuer"],
                _config["Tokens:Issuer"],
                claims,
                expires: DateTime.Now.AddHours(3),
                signingCredentials: creds);

            return new ApiSuccessResult<string>(new JwtSecurityTokenHandler().WriteToken(token));
        }

        public async Task<ApiResult<PagedResult<UserVm>>> GetUsersPaging(GetUserPagingRequest request)
        {
            var query = _userManager.Users;
            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(x => x.UserName.Contains(request.Keyword)
                 || x.PhoneNumber.Contains(request.Keyword));
            }

            //3. Paging
            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new UserVm()
                {
                    Id = x.Id,
                    Image = x.Image,
                    Email = x.Email,
                    Name = x.Name,
                    DateOfBir = x.DateOfBir,
                    Gender = x.Gender,
                    UserName = x.UserName,
                }).ToListAsync();

            //4. Select and projection
            var pagedResult = new PagedResult<UserVm>()
            {
                TotalRecords = totalRow,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                Items = data
            };
            return new ApiSuccessResult<PagedResult<UserVm>>(pagedResult);
        }

        public async Task<ApiResult<bool>> Register(RegisterRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user != null)
            {
                return new ApiErrorResult<bool>("Tài khoản đã tồn tại");
            }
            if (await _userManager.FindByEmailAsync(request.Email) != null)
            {
                return new ApiErrorResult<bool>("Emai đã tồn tại");
            }

            user = new AppUser()
            {
                DateOfBir = request.DateOfBir,
                Email = request.Email,
                Name = request.Name,
                Image = request.Image ,
                UserName = request.UserName,
                Gender = request.Gender
            };

            // Lưu mật khẩu
            var result = await _userManager.CreateAsync(user, request.Password);
            if (result.Succeeded)
            {
                // Auto RoleAssign
                var role = await _dataContext.Roles.FirstOrDefaultAsync(x => x.Name == "User");
                var getUser = await _dataContext.Users.FirstOrDefaultAsync(x => x.UserName == request.UserName);
                await _userManager.AddToRoleAsync(getUser, role.Name);
                return new ApiSuccessResult<bool>();
            }

            

            return new ApiErrorResult<bool>("Đăng ký không thành công : Mật khẩu không hợp lệ, yêu cầu gồm có ít 6 ký tự bao gồm ký tự: Hoa, thường, số, ký tự đặc biệt ");
        }

        public async Task<ApiResult<bool>> NewRegister(RegisterRequestOfUser request)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user != null)
            {
                return new ApiErrorResult<bool>("Tài khoản đã tồn tại");
            }
            if (await _userManager.FindByEmailAsync(request.Email) != null)
            {
                return new ApiErrorResult<bool>("Emai đã tồn tại");
            }

            user = new AppUser()
            {
                Email = request.Email,
                UserName = request.UserName,
            };
            // Lưu mật khẩu
            var result = await _userManager.CreateAsync(user, request.Password);
            if (result.Succeeded)
            {
                // Auto RoleAssign
                var role = await _dataContext.Roles.FirstOrDefaultAsync(x => x.Name == "User");
                var getUser = await _dataContext.Users.FirstOrDefaultAsync(x => x.UserName == request.UserName);
                await _userManager.AddToRoleAsync(getUser, role.Name);
                return new ApiSuccessResult<bool>();
            }

            

            return new ApiErrorResult<bool>("Đăng ký không thành công : Mật khẩu không hợp lệ, yêu cầu gồm có ít 6 ký tự bao gồm ký tự: Hoa, thường, số, ký tự đặc biệt ");
        }

        public async Task<ApiResult<bool>> RoleAssign(Guid id, RoleAssignRequest request)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null)
            {
                return new ApiErrorResult<bool>("Tài khoản không tồn tại");
            }
            var removedRoles = request.Roles.Where(x => x.Selected == false).Select(x => x.Name).ToList();
            foreach (var roleName in removedRoles)
            {
                if (await _userManager.IsInRoleAsync(user, roleName) == true)
                {
                    await _userManager.RemoveFromRoleAsync(user, roleName);
                }
            }
            await _userManager.RemoveFromRolesAsync(user, removedRoles);

            var addedRoles = request.Roles.Where(x => x.Selected).Select(x => x.Name).ToList();
            foreach (var roleName in addedRoles)
            {
                if (await _userManager.IsInRoleAsync(user, roleName) == false)
                {
                    await _userManager.AddToRoleAsync(user, roleName);
                }
            }

            return new ApiSuccessResult<bool>();
        }

        public async Task<ApiResult<bool>> Update(Guid id, UserUpdateRequest request)
        {
            if (await _userManager.Users.AnyAsync(x => x.Email == request.Email && x.Id != id))
            {
                return new ApiErrorResult<bool>("Emai đã tồn tại");
            }
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (request.DateOfBir != null)
            {
                user.DateOfBir = request.DateOfBir;
            }
            user.Email = request.Email;
            user.Name = request.Name;
            user.Gender = request.Gender;
            user.Description = request.Description;
            user.Address = request.UserAddress;

            if (request.GetImage != null)
            {
                if (user.Image != null)
                {
                    RemoveImage(user.Image);
                }
                user.Image = await SaveFile(request.GetImage);
            }

            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return new ApiSuccessResult<bool>();
            }
            return new ApiErrorResult<bool>("Cập nhật không thành công");
        }


        public async Task<bool> RemoveImage(string request)
        {
            await _storageService.DeleteFileAsync(request);
            return true;
        }
        private async Task<string> SaveFile(IFormFile file)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            await _storageService.SaveFileAsync(file.OpenReadStream(), fileName);
            return "https://localhost:7204/" + USER_CONTENT_FOLDER_NAME + "/" + fileName;
        }

        public async Task<List<UserVm>> TakeByQuantity(int quantity)
        {
            var listUser = await _dataContext.Users.ToListAsync();

            // Lấy ra top 3 người dùng có số bài viết nhiều nhất
            var topUsers = _dataContext.Posts.GroupBy(p => p.UserId)
                .Select(g => new { UserId = g.Key, PostCount = g.Count() })
                .OrderByDescending(u => u.PostCount)
                .Take(quantity);

            List<UserVm> users = new List<UserVm>();
            if (topUsers.Any())
            {

                foreach (var user in topUsers)
                {
                    var getUser = await _dataContext.Users.Where(x => x.Id == user.UserId).FirstOrDefaultAsync();
                    UserVm userVm = new UserVm();
                    userVm.Id = user.UserId;
                    userVm.PostNumber = user.PostCount;
                    userVm.UserName = getUser.UserName;
                    userVm.Email = "not displayed!";
                    userVm.Description = getUser.Description;
                    userVm.Image = getUser.Image;
                    users.Add(userVm);
                }

                return users;
            }

            return users;

        }
    }
}