var isDarkMode = localStorage.getItem("darkMode") === "true" ? true : false;
var logoElement = document.getElementById("logo");
var logoImage = isDarkMode ? "/images/silicon-logo-dark.svg" : "/images/silicon-logo.svg";
var notFoundElement = document.getElementById("notFoundId");
var notFoundImage = isDarkMode ? "/images/404-dark.svg" : "/images/404.svg";
var desktopSwitch = document.getElementById("switch");
var mobileSwitch = document.getElementById("switch-mobile");
logoElement.innerHTML = "<img src='" + logoImage + "' alt='Silicon Logo'>";
desktopSwitch.checked = isDarkMode;
mobileSwitch.checked = isDarkMode;


function toggleBothSwitches() {
    isDarkMode = !isDarkMode;
    localStorage.setItem("darkMode", isDarkMode); 

    desktopSwitch.checked = isDarkMode;
    mobileSwitch.checked = isDarkMode;

    if (isDarkMode) {
        activateDarkMode();
    } else {
        deactivateDarkMode();
    }

    updateLogo();
    update404();
}


function activateDarkMode() {
    document.body.classList.add("dark-mode");
}

function deactivateDarkMode() {
    document.body.classList.remove("dark-mode");
}

function updateLogo() {
    logoImage = isDarkMode ? "/images/silicon-logo-dark.svg" : "/images/silicon-logo.svg";
    logoElement.innerHTML = "<img src='" + logoImage + "' alt='Silicon Logo'>";
}

function update404() {

    notFoundImage = isDarkMode ? "/images/404-dark.svg" : "/images/404.svg";
    notFoundElement.innerHTML = "<img src='" + notFoundImage + "' alt='404 Not Found'>";
}

window.onload = function () {   
    if (isDarkMode) {
        activateDarkMode();
    } else {
        deactivateDarkMode();
    }    
    updateLogo();
    update404();    
};



