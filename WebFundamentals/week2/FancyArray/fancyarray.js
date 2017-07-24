function fancyArray(array, symbol, reverse) {
    if (reverse === true) {
        for (var i = array.length - 1; i >= 0; i--){
            console.log(i + " " + symbol + " " + array[i]);
           
        }
    } else {
        for (var i = 0; i < array.length ; i++){
            console.log(i + " " + symbol + " " + array[i]);
        }
    }
}