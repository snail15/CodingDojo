$(document).ready(function () {
    for (var i = 1; i <= 151 ; i++) {
        console.log("<img src='http://pokeapi.co/media/img/"+i+".png'"+" alt='pokemon'>")
        $(".pic-row").append("<img src='http://pokeapi.co/media/img/"+i+".png'"+" alt='pokemon'>")
    } 
});
