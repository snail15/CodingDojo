function getCookie(c_name)
{
    if (document.cookie.length > 0)
    {
        c_start = document.cookie.indexOf(c_name + "=");
        if (c_start != -1)
        {
            c_start = c_start + c_name.length + 1;
            c_end = document.cookie.indexOf(";", c_start);
            if (c_end == -1) c_end = document.cookie.length;
            return unescape(document.cookie.substring(c_start,c_end));
        }
    }
    return "";
 }

$(document).ready(function () {

    $.ajaxSetup({
        headers: { "X-CSRFToken": getCookie("csrftoken") }
    });
 
   $('.name').keyup(function () {
       console.log("Here, serialized:", $('.name_search').serialize());
       $.ajax({
           url: 'search_name',
           method: 'post',
           data: $('.name_search').serialize(),
           success: function(serverResponse) {
               $('.table-body').html(serverResponse)
           }
       })
   });
 
   $('.from_date').change(function (){
        $.ajax({
           url: 'search_name',
           method: 'post',
           data: $('.from_search').serialize(),
           success: function(serverResponse) {
               $('.table-body').html(serverResponse)
           }
       })
   })
   $('.to_date').change(function (){
        $.ajax({
           url: 'search_name',
           method: 'post',
           data: $('.from_search').serialize(),
           success: function(serverResponse) {
               $('.table-body').html(serverResponse)
           }
       })
   })

  $('.page-link').click(function (){
      $.ajax({
          url: 'paginate',
          method: 'post',
          data: {'url': $(this).attr('goto')},
          success: function(serverResponse) {
              $(document).html(serverResponse)
          }
        
      })
  })
});