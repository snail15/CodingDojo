function numbersOnly(arr) {

    var newArray = [];
    for (var i = 0; i < arr.length; i++) {

        if (typeof arr[i] == "number") {
            newArray.push(arr[i]);
        }

    }

    return newArray;
}

function numbersOnlyRemove(array) {
    for (var i = 0; i < array.length; i++) {
        
         if (typeof arr[i] == "number") {
            array.splice(i, 1);
        }
        
    }
    return array;
}

var newArray = numbersOnly([-1, 1, 0, "Jim", true, undefined]);
console.log(newArray);

var newArray2 = numbersOnly([-1, 1, 10, "Jim", true, undefined, false]);
console.log(newArray2);