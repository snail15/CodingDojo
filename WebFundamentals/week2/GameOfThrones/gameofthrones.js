function displayHouseDetail(name, founded, titles, words) {

    htmlString = "";
    htmlString += "<p><span>Name:</span> " + name + "</p>";
    htmlString += "<p><span>Founded:</span> " + founded + "</p>";
    htmlString += "<p><span>Words:</span> " + words + "</p>";
    htmlString += "<p><span>Titles:</span> "
    for(var i = 0; i < titles.length; i++) {
        if (i == titles.length - 1){
            htmlString += titles[i] + "</p>";
        }
        htmlString += titles[i] + ", ";
    }
    $(".descrip").hide().html(htmlString).slideDown(1000);

}
$(document).ready(function () {
    $("img").click(function (){

        var house = $(this).attr("id");
        var queryName;

        if (house === "baratheon") {
            queryName = "House Baratheon of King's Landing";
        } else if (house === "lannister") {
            queryName = "House Lannister of Casterly Rock";
        } else if (house === "stark") {
            queryName = "House Stark of Winterfell";
        } else if (house === "dragon"){
            queryName = "House Targaryen of King's Landing";
        }

        $.get("https://www.anapioficeandfire.com/api/houses?name="+ queryName, function(data){
            var name = data[0].name;
            var title = [];
            for(var i = 0; i < data[0].titles.length; i++) {
                title.push(data[0].titles[i]);
            }
            var founded = data[0].founded;
            var words = data[0].words;

            displayHouseDetail(name, founded, title, words);
        }, "json");
    })
});