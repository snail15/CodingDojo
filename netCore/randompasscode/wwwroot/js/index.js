$(document).ready(function () {
    $('.btn').click(function(){
        $.get("generate", function(response){
            var newPassword = response.password;
            var attempt = response.attempt;
            $(".password").text(newPassword);
            $(".attempt").text(attempt);
        })
    })
});