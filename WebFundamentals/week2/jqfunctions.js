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
            });