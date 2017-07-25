$(document).ready(function () {

    $(".submit").click(function(){
        var firstName = $("input[name=first_name]").val();
        var lastName = $("input[name=last_name]").val();
        var email = $("input[name=email]").val();
        var contactNo = $("input[name=contact]").val();
        
        $("#tbody").append("<tr>"
            +"<td>"+firstName
            +"</td><td>"+lastName
            +"</td><td>"+email
            +"</td><td>"+contactNo
            +"</td></tr>");
        
        // $("tbody").append("<tr><td>Bill</td><td>Gates</td><td>ads@asdas.com</td><td>123-456-7890</td></tr>");
    })
});