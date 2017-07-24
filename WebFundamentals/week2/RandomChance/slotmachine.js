function playSlot(coin, target) {

    var winningNum = Math.floor(Math.random()* 100);
    
    // if (target === undefined) {
    //     target = 0;
    // }

    while (coin > 0) {
        var winningAmount = Math.floor(Math.random() * 50) + 50;
        var userNum = Math.floor(Math.random() * 100);
        if (userNum === winningNum) {
            coin += winningAmount;
            console.log("You won " + winningAmount + " coins!!!! You have " + coin + " coins.");
            if (target != undefined && coin >= target) {
                break;
            }
        } else {
            coin--;
        }

    }

    console.log(coin + " coins remained.");
}
