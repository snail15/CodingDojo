$(document).ready(function () {
    $('.note-form').submit(function(e) {
        e.preventDefault();
        $.ajax({
            url: 'create',
            method: 'post',
            data: $(this).serialize(),
            success: function(serverResponse) {
                $('.post-row').append(serverResponse)
            }
        })
    })
});