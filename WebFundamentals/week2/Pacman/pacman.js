var map = [
        [0,0,0,0,0,0,0,0,0,0],
        [0,1,1,1,1,1,1,1,1,0],
        [0,1,1,1,1,1,1,1,1,0],
        [0,1,1,1,1,1,1,1,1,0],
        [0,1,1,1,1,1,1,1,1,0],
        [0,1,1,1,1,1,1,1,1,0],
        [0,1,1,1,1,1,1,1,1,0],
        [0,1,1,1,1,1,1,1,1,0],
        [0,1,1,1,1,1,1,1,1,0],
        [0,0,0,0,0,0,0,0,0,0],
    ];

function displayMap() {
    var htmlString ="";
    for(var row in map) {
        htmlString += "\n<div class='row'>";
        for (var brick in map[row]){
            if (map[row][brick] == 0) {
                htmlString += "\n\t<div class='brick'></div>";
            } else if (map[row][brick] == 1) {
                htmlString += "\n\t<div class='coin'></div>";
            }
        }
        htmlString += "\n</div>";
    }
    $("body").html("<h1>Pacman</h1>"+ htmlString);
}


$(document).ready(function () {
    
    displayMap();


});