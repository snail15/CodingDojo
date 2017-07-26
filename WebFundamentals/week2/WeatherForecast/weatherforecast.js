function displayWeather(cityName, weather, description) {
    var htmlString = "";
    console.log(cityName);
    htmlString += "<h2>"+ cityName +"</h2>";
    htmlString += "<h3>"+ weather +"</h3>";
    htmlString += "<h3>"+ description +"</h3>";
    console.log(htmlString);
    $(".weather-col").html(htmlString);
}

$(document).ready(function () {
    $(".submit").click(function (){
        var cityDisplayName;
        var weather;
        var description;
        var city = $("input[name=city]").val();
        console.log(city);

        $.get("http://api.openweathermap.org/data/2.5/weather?q="+ city
                + "&appid=cadf3a27f2ea3fdc12fc9d8634dea854", function(data){
                    cityDisplayName = data.name;
                    weather = data.weather[0].main;
                    weatherDescription = data.weather[0].description;
                    
                    displayWeather(cityDisplayName, weather, weatherDescription);
                }, "json");
        

    })
}); 