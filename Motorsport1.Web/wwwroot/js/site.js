﻿function ordinal_suffix_of(i) {
    let j = i % 10,
        k = i % 100;
    if (j == 1 && k != 11) {
        return i + "st";
    }
    if (j == 2 && k != 12) {
        return i + "nd";
    }
    if (j == 3 && k != 13) {
        return i + "rd";
    }
    return i + "th";
}

window.onload = function () {
    for (let i = 0; i < document.getElementsByClassName("li").length; i++) {
        document.getElementsByClassName("li")[i].innerHTML = ordinal_suffix_of(i+1);
    }
}
