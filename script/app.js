
const remote = require('electron').remote;

function minim(){
    var window = remote.getCurrentWindow();
    window.minimize();
}

function cl() {
    var window = remote.getCurrentWindow();
    window.close();
}

require("electron").openExternal("http://www.google.com")