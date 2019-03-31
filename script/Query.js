jQuery(document).ready(function () {
    jQuery('#run').click(function () {
        require('child_process').exec('start ./program/VK_UserInfo.exe');
    });
});