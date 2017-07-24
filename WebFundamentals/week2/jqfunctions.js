    $(document).ready(function () {
                $(".click-btn").click(function () {
                    $(".click-row").css("background-color", "orange");
                });

                $(".hide-btn").click(function () { 
                    $(".hide-h2").hide(700);
                    
                });
                $(".show-btn").click(function () { 
                    $(".show-h3").show(1100, function () {
                        $(".show-h3").hide(500);

                    }); 
                    
                });

                $(".toggle-btn").click(function () {
                    $(".hidden-toggle-list").toggle(2000, function() {
                        $(".hidden-toggle-list").hide(800);
                    })
                })

                $(".slide-down-btn").click(function () {
                    $("#slide-down-img").slideDown(1200, function() {
                        $("#slide-down-img").hide(800);
                    });
                })

                $(".slide-up-btn").click(function () {
                    $("#slide-up-img").slideUp(1500, function() {
                        $("#slide-up-img").slideDown(800);
                    });
                })

                $(".slide-toggle-btn").click(function () {
                    $("#slide-toggle-img").slideToggle(1500);
                })


            });