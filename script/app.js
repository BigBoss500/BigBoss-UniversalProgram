
const remote = require('electron').remote;

function minim(){
    var audio = new Audio();
    audio.src = './sound/click.mp3';
    audio.autoplay = true;
    var window = remote.getCurrentWindow();
    window.minimize();
}

function cl() {
    var audio = new Audio();
    audio.src = './sound/click.mp3';
    audio.autoplay = true;
    var window = remote.getCurrentWindow();
    window.close();
}

function AuCLick() {
    var audio = new Audio();
    audio.src = './sound/click.mp3';
    audio.autoplay = true;
}

var back = document.getElementById('back')

back.onclick = function () {
    var audio = new Audio();
    audio.src = './sound/click.mp3';
    audio.autoplay = true;
    history.back()
}



require("electron").openExternal("http://www.google.com")