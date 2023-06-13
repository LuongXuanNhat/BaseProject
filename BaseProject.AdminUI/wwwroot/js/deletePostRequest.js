// Gọi hàm Ajax để xóa User
$(function () {
    $('#delete-post').on('click', function () {
        var postId = $(this).data('post-id');
        $.ajax({
            url: '/post/delete/' + postId,
            method: 'DELETE',
            success: function () {
                location.reload();
            }
        });
    });
});
