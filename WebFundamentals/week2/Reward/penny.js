function pennyAward(days) {
    var award = 0.01;
    for (var i = 1; i <= days; i++) {
        award *= 2;
    }
    return award;
}

function howManyDays(amount){
    var award = 0.01;
    var days = 0;
    while (award <= amount) {
        award *= 2;
        days++;
    }
    return days;
}