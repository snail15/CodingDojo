<script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
$(document).ready(function () {
    $("img").click(function (){
            var temp = $(this).attr("src");
            $(this).attr("src",  $(this).attr("alt-src"));
            $(this).attr("alt-src", temp);
            $(this).show(800);

    })
});