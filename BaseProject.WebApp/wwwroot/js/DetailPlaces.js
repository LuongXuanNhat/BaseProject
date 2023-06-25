var username = '@Html.Raw(ViewBag.UserName)';
$(document).ready(function () {
    // BÌNH LUẬN
    // Thêm comment
    $(document).ready(function () {
        $("#sendButton").click(function () {
            var questionInput = $("#questionInput").val();
            var placeId = $("#sendButton").attr("id-place");

            var data = {
                Content: questionInput,
                LocationId: placeId,
                UserName: username
            };

            // Gửi yêu cầu AJAX POST đến API controller
            $.ajax({
                url: "/api/Comment/AddChatQA",
                type: "POST",
                contentType: "application/json",
                data: JSON.stringify(data),
                success: function (response) {
                    loadComments();
                    var successMsg = "Đã bình luận";
                    $('#msgAlert2').removeClass('hidden-class').addClass('alert alert-success');
                    $('#msgAlert2').text(successMsg).show().delay(2000).fadeOut('slow', function () {
                        $(this).addClass('hidden-class');
                    });
                },
                error: function (xhr, textStatus, errorThrown) {
                    alert("Hỏi thất bại");
                    console.log(errorThrown);
                }
            });
        });
    });

    // Xóa comment
    $(document).on('click', '.delete-comment', function (event) {
        event.preventDefault();
        var commentId = $(this).data('comment-id');
        var commentElement = $(this).closest('.comment');
        $.ajax({
            url: '@Url.Action("Delete", "Comment")',
            type: 'POST',
            data: { commentId: commentId },
            success: function (result) {
                if (result.success) {
                    commentElement.remove();
                } else {
                    alert('Failed to delete comment.');
                }
            }
        });
    });

    // Sửa comment
    $(document).on('click', '.edit-comment', function (event) {
        event.preventDefault();
        var commentId = $(this).data('comment-id');
        var commentElement = $(this).closest('.comment');
        // TODO: Hiển thị form sửa comment và gửi request Ajax để cập nhật comment
    });

    function loadComments() {
        var Id = '@Html.Raw(@ViewBag.PlaceId)';
        $.ajax({
            url: '@Url.Action("GetComments", "Comment")',
            type: 'POST',
            data: { locationId: Id },
            success: function (result) {
                $('#comments-list').html(result);
            }
        });
    }

    // Gọi hàm loadComments để tải danh sách comment khi trang tải
    loadComments();
});
