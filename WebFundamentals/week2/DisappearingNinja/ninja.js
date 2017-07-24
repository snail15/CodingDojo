$(document).ready(function () {
    $("img").click(function () {
        $(this).hide(1000);
    });

    $(".restore-btn").click(function() {
        $("img").show(900);
    })

});