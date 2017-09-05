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
                    if(response.win === true){
                        $('.feed').css("visibility", "hidden");
                        $('.play').css("visibility", "hidden");
                        $('.work').css("visibility", "hidden");
                        $('.sleep').css("visibility", "hidden");
                        $('.restart').css("visibility", "visible");
                        $(".card-text").text("You Won!! Restart?");
                    } else {    
                        if(response.gain === 0){
                            $(".card-text").text("Unhappy! Gained No Fullness");
                        } else if (response.gain === -1) {
                            $(".card-text").text("You don't even have a meal to feed");
                        } else {
                            $(".card-text").text("Good! Gained " + response.gain + " Fullness, -1 Meal");
                        }
                    }
                }
            }
        })
    })
    $(".play").click(function(){
        $.ajax({
            url: "play",
            method: "GET",
            success: function(response){
                $('.energy').text(response.energy);
                $('.happiness').text(response.happiness);
                if(response.win === true){
                    $('.feed').css("visibility", "hidden");
                    $('.play').css("visibility", "hidden");
                    $('.work').css("visibility", "hidden");
                    $('.sleep').css("visibility", "hidden");
                    $('.restart').css("visibility", "visible");
                    $(".card-text").text("You Won!! Restart?");
                } else {
                    if(response.gain === 0){
                        $(".card-text").text("Unhappy! Gained No Happiness");
                    } else if (response.gain === -1) {
                        $(".card-text").text("You don't even have energy to play");
                    } else {
                        $(".card-text").text("Good! Gained " + response.gain + " Happiness, -5 Energy");
                    }
                }
            }
        })
    })
    $(".work").click(function(){
        $.ajax({
            url: "work",
            method: "GET",
            success: function(response){
                $('.energy').text(response.energy);
                $('.meal').text(response.meal);
                if(response.gain === -1){
                    $(".card-text").text("You don't have energy to work. Sleep?");
                } else {
                    $(".card-text").text("Good! Gained " + response.gain + " Meal, -5 Energy");
                }

            }
        })
    })
    $(".sleep").click(function(){
        $.ajax({
            url: "sleep",
            method: "GET",
            success: function(response){
                $('.energy').text(response.energy);
                $('.happiness').text(response.happiness);
                $('.fullness').text(response.fullness);
                if(response.lose === true){
                    $('.feed').css("visibility", "hidden");
                    $('.play').css("visibility", "hidden");
                    $('.work').css("visibility", "hidden");
                    $('.sleep').css("visibility", "hidden");
                    $('.restart').css("visibility", "visible");
                    $(".card-text").text("You Lost.....!! Restart?");
                } else if (response.won === true){
                    $('.feed').css("visibility", "hidden");
                    $('.play').css("visibility", "hidden");
                    $('.work').css("visibility", "hidden");
                    $('.sleep').css("visibility", "hidden");
                    $('.restart').css("visibility", "visible");
                    $(".card-text").text("You Won!! Restart?");
                } else {    
                    $(".card-text").text("Good! Gained " + response.gain + " Energy, -5 Happiness & Fullness");
                }
                

            }
        })
    })
});