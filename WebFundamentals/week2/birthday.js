var daysUntilMyBirthday = 60;

function countDown (daysRemaining) {
    while (daysRemaining > 0) {
        if (daysRemaining >= 30) {
            console.log(daysRemaining + " days left. Such a long time...")
        } else if (daysRemaining < 30 && daysRemaining > 5) {
            console.log(daysRemaining + "days left. It's getting close!")
        } else if (daysRemaining >= 1 && daysRemaining <= 5) {
            console.log("Only " + daysRemaining + " days left!!!!!!!!!!!!!!!!!!!")
        }
        daysRemaining--;
    }
    console.log("HAPPY BIRTHDAY!!!!!!!!!!!!!!!")
}

countDown(daysUntilMyBirthday);