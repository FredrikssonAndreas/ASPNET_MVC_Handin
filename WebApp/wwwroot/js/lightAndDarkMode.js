var isDarkMode = false;
var logoElement = document.getElementById("logo");
var logoImage = "/images/silicon-logo.svg";
logoElement.innerHTML = "<img src='" + logoImage + "' alt='Silicon Logo'>";
var notFoundElement = document.getElementById("notFoundId");
var notFoundImage = "/images/404.svg";
notFoundElement.innerHTML = "<img src='" + notFoundImage + "' alt='404 Not Found'>";

function toggleBothSwitches() {
   
    isDarkMode = !isDarkMode;
  
    var desktopSwitch = document.getElementById("switch");
    desktopSwitch.checked = isDarkMode;

    
    var mobileSwitch = document.getElementById("switch-mobile");
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



