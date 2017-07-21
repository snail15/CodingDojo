function askTime(hour, min, ap) {
    var message = "";
    var ampm = "";
    if (ap === "AM") {
        ampm = " in the morning";
    } else {
        ampm = " in the evening";
    }
    if (min <= 30) {
        message = "It is just after " + hour + ampm;
    } else {
        message = "It is almost " + (hour+1) + ampm;
    }

    console.log(message);
}

askTime(8, 45, "PM");
askTime(8, 29, "AM");
askTime(8, 29, "PM");
askTime(8, 45, "AM");

