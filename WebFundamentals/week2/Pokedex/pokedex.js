    function displayPokedex(img, types, height, weight, name) {

        $(".pokedex-col").html("<div class='pokedex'></div>")

        var htmlString = "";
        htmlString += "<h2>"+ name +"</h2>";

        htmlString += "<img src=";
        htmlString += img;
        htmlString += " alt='pokemon pic'>";

        console.log(types);

        htmlString += "<h5>Types</h5>";
        htmlString += "<ul>";
        for (var i = 0; i < types.length; i++) {
            htmlString += "<li>" + types[i] + "</li>";
        }
        htmlString += "</ul>";

        htmlString += "<h5>Height</h5>";
        htmlString += "<h6>"+ height + "</h6>";

        htmlString += "<h5>Weight</h5>";
        htmlString += "<h6>"+ weight + "</h6>";

        $(".pokedex").hide().html(htmlString).slideDown(1000);
    }

$(document).ready(function () {
    for (var i = 1; i <= 151 ; i++) {
        console.log("<img id='"+i+"' src='http://pokeapi.co/media/img/"+i+".png'"+" alt='pokemon'>")
        $("#pokemon-pic").append("<img id='"+i+"' src='http://pokeapi.co/media/img/"+i+".png'"+" alt='pokemon'>");
    }

    
    $("img").click(function(){
        var pokeId = $(this).attr("id");
        $.get("http://pokeapi.co/api/v1/pokemon/"+ pokeId +"/", function(data){
            
            var imageAddress = "http://pokeapi.co/media/img/" + pokeId +".png";
            
            var pokeType = [];
            for (var i = 0; i < data.types.length; i++) {
                pokeType.push(data.types[i].name);
            }

            var pokeHeight = data.height;
            var pokeWeight = data.weight;
            
            var pokeName = data.name;

            displayPokedex(imageAddress, pokeType, pokeHeight, pokeWeight, pokeName);

        }, "json");
    })
});
