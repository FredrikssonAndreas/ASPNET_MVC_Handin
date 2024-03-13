var isDarkMode = false;


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
}


function activateDarkMode() {
    document.body.classList.add("dark-mode");
}

function deactivateDarkMode() {
    document.body.classList.remove("dark-mode");
}


