function random_text() {
    var audio = new Audio();
    audio.src = './sound/click.mp3';
    audio.autoplay = true;
    document.getElementById('txtbox').textContent = 'Пожалуйста, подождите...';
    var timerID = setTimeout(random,  2000);
    var timerID2 = setTimeout(random_descr, 2000)
}

function random() {
    var b = new Array;
    b[0] = 'Бан'
    b[1] = 'Анимированная краска (в игре)'
    b[2] = 'Повестка в армию'
    b[3] = 'Пинок'
    b[4] = 'Котэ'
    b[5] = 'Кристаллы на аккаунт (в игре)'
    b[6] = 'Лицензия на Minecraft (игра)'
    b[7] = 'Премиум аккаунт (в игре)'
    b[8] = 'Александр Ворон'
    b[9] = 'Даниил Зиннатов'
    b[10] = 'DDoS телефона'
    b[11] = 'Удача в жизни'
    b[12] = 'Счастье в жизни'
    b[13] = 'Много денег'
    b[14] = 'Быть умным в жизни'
    b[15] = 'Орёл'
    b[16] = 'Владимир Романов'
    b[17] = 'Найти в жизни девушку/парня'
    b[18] = 'Подарок ВК'
    b[19] = 'Не учиться'
    b[20] = 'Посмотреть сериал'
    b[21] = 'Защита от DDoS-атаки на телефон'
    b[22] = 'Шанс на повтор рулетки'
    b[23] = 'Критическая ошибка (в игре)'
    b[24] = 'Алаеро'
    b[25] = '50 рублей'
    b[26] = 'Баги в программах и играх'
    b[27] = '10 000 подписчиков на YouTube'
    b[28] = '100 000 подписчиков на YouTube'
    b[29] = '1 000 000 подписчиков на YouTube'
    b[30] = 'Face'
    b[31] = 'Инструкция "Как поднять бабла"'
    b[32] = 'Самый крутой смартфон'
    b[33] = 'Мощный компьютер'
    b[34] = 'По ОГЭ и ЕГЭ на отлично'
    b[35] = 'Windows 10'
    b[36] = 'Решётка'
    b[37] = 'JavaScript'
    b[38] = 'PHP'
    b[39] = 'Canyon'
    b[40] = 'Ничего'
    rdmRuletka = Math.floor(Math.random() * b.length);
    document.getElementById('txtbox').textContent = 'Выпадает: ' + b[rdmRuletka];
    var audio = new Audio();
    audio.src = '/Sound/tadam.mp3';
    audio.autoplay = true;
}

function random_res() {
    var audio = new Audio();
    audio.src = './sound/click.mp3';
    audio.autoplay = true;
    document.getElementById('txtbox').textContent = 'Нажмите "Крутить", чтобы узнать, что выпадет';
}
function changeText() {
    var audio = new Audio();
    audio.src = './sound/click.mp3';
    audio.autoplay = true;
    var userInput = document.getElementById('userInput').value;
    document.getElementById('FDR').textContent = userInput;
}