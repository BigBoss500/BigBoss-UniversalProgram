jQuery(document).ready(function () {
    jQuery('#run').click(function () {
        require('child_process').exec('start ./VK_UserInfo.exe');
    });
});