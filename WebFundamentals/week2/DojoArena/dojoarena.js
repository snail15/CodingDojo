//to fix the background img when user selects an arena
var backgroundFixed = false;

function displayCharcter(img, player) {
    var colName = ".p1-col";
    if(player === 2){
        colName = ".p2-col";
    }
    console.log("<img src="+ img + " alt='character'>");
    $(colName).html("<img src="+ "'"+ img + "'"+ "alt='character'>");
    $(".foot").html("<br><br><br><br><br><br><br>")

}
function attachHandlerForSelection() {
    var imgName;
    var imgName2;
    $("#p1-ninja").change(function (){
        imgName = $(this).val();
        console.log(imgName);
        if (imgName !== "Select Your Ninja") {
            displayCharcter(imgName, 1);
        }
    })
    $("#p2-ninja").change(function (){
        imgName2 = $(this).val();
        console.log(imgName2);
         if (imgName2 !== "Select Your Ninja") {
            displayCharcter(imgName2, 2);
        }
    })

    

}

$(document).ready(function () {


    $(".btn").hover(function(){
        var imgId = $(this).attr("id");
        $(".container").css("background", "url("+ imgId +".jpg)");
        backgroundFixed = false;
    }, function(){
        if (backgroundFixed === false) {
            $(".container").css("background", "");  
        }
    })

    $(".btn").click(function(){
        backgroundFixed = true;
        $(".buttons").slideUp(1000, function(){
            $("h3").text("Select Your Ninja!!").addClass("sub-heading");
            $(".option-row").hide().css("display","").slideDown(1000);       
        });

        attachHandlerForSelection();
    })
});

