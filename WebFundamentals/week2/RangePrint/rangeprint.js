function rangePrint(start, end, step) {

    if (step === undefined) {
        step = 1;
    }

    if (end === undefined) {
        end = start;
        start = 0;
    }

    if (step > 0) {
        for (var i = start; i < end; i += step) {
            console.log(i);
        }
    } else {
        step = step * -1;
        for (var i = start; i > end; i -= step) {
            console.log(i);
        }
    }
}