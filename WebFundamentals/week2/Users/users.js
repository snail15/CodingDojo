$(document).ready(function () {

    $(".submit").click(function(){
        var firstName = $("input[name=first_name]").val();
        var lasttName = $("input[name=last_name]").val();
        var email = $("input[name=email]").val();
        var contactNo = $("input[name=contact]").val();
        
        $("#usertable > tbody:last-child").append("<tr><td>"+firstName
        +"</td><td>"+lastName+"</td><td>"
        +email+"</td><td>"
        +contactNo+"</td></tr>");
    })
});