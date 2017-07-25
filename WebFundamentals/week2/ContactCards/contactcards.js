function attachDescriptionHandler(description, firstName, lastName) {
    
    var generalCard = true;

    $(".card").click(function (){
        if (generalCard == true) {
            $(this).html("<p>"+description+"</p>");
            $(this).children("p").addClass("description-p")
            generalCard = false;
        } else {
            $(this).html("<h3>"+firstName+" "+lastName
                        +"</h3>"
                        +"<p>Click here for the description!</p>");
            generalCard = true;
        }
    })
}

$(document).ready(function () {
    
     $(".submit").click(function(){
        var firstName = $("input[name=first_name]").val();
        var lastName = $("input[name=last_name]").val();
        var description = $("#description").val();
        
        $(".card-col").append("<div class='card'>"
                                +"<h3>"+firstName+" "+lastName
                                +"</h3>"
                                +"<p>Click here for the description!</p>");

        
        attachDescriptionHandler(description, firstName, lastName);
    
    })

});