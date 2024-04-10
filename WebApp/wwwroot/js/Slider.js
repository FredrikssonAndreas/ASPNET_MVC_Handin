document.addEventListener("DOMContentLoaded", function () {
    var slider = document.getElementById("myRange");
    var blackBox = document.querySelector(".box-black");
    var whiteBox = document.querySelector(".box-white");
    var blackImage = document.getElementById("imageBlack");
    var whiteImage = document.getElementById("imageWhite");

    slider.oninput = function () {
        var value = this.value;
        var blackWidth = 50 - value / 2;
        var whiteWidth = 50 + value / 2;

        blackBox.style.width = blackWidth + "%";
        whiteBox.style.width = whiteWidth + "%";

        blackImage.style.width = blackWidth + "%";
        whiteImage.style.width = whiteWidth + "%";
    };
});