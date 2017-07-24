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

                 $(".fade-in-btn").click(function () {
                    $("#fade-in-img").fadeIn(1500);
                })

                 $(".fade-out-btn").click(function () {
                    $("#fade-out-img").fadeOut(1500);
                })

                //  $(".add-class-btn").click(function () {
                //     $(".add-class-list li").addClass(function (index , currentClass){
                //         currentClass = "blue";
                //         return currentClass;

                //     });
                // })

                $(".add-class-btn").click(function () {
                    $(".add-class-list li:nth-child(2)").addClass("blue");
                })

                $(".before-btn").click(function () { 
                    $(".before-h2").before("<h2>Hey I am the before h2!</h2>");
                
                });

                 $(".after-btn").click(function () { 
                    $(".after-h2").after("<h2>Hey I am the after h2!</h2>");
                
                });

                 $(".append-btn").click(function () { 
                    $(".append-list").append("<li>No 4</li>");
                
                });

                 $(".html-btn").click(function () {
                    var htmlStr = $(".html-h2").html();
                    $(".html-h2").text(htmlStr);
                
                });

                var checked = $("#attr-check").attr("checked");
                $(".check-h2").html(checked);

                $(".val-btn").click(function () {
                    var Str = $(this).text();
                    $("#val-input").val(Str);
                });

                $(".text-btn").click(function () {
                    var Str = $(".text-h2-first").text();
                    $(".text-h2").text(Str);
                });

                $(".data-btn").click(function () {
                    $("div").data("food", {menu: "Pizza", drink: "Coke"});
                    $(".data-list li:nth-child(1)").text($("div").data("food").menu);
                    $(".data-list li:nth-child(2)").text($("div").data("food").drink);
                });


            });