$(document).ready(function () {
    $(".feed").click(function(){
        $.ajax({
            url: "feed",
            method: "GET",
            success: function(response){
                console.log(response.meal);
                console.log(response.fullness);
                if(response.meal !== undefined){
                    $('.meal').text(response.meal);
                    $('.fullness').text(response.fullness);
                }
            }
        })
    })
});