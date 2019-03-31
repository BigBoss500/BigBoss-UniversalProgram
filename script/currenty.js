$.getJSON("https://www.cbr-xml-daily.ru/daily_json.js", function (data) {
    $('#usd').html(
        "<h2>Главный курс рубля:</h2>" +
        data.Valute.USD.Nominal + " Доллар США -> " + data.Valute.USD.Value + " Рублей" + "<br>" +
        data.Valute.EUR.Nominal + " Евро -> " + data.Valute.EUR.Value + " Рублей" + "<br>" +
        data.Valute.BYN.Nominal + " Белорусских рублей -> " + data.Valute.BYN.Value + " Рублей" + "<br>" +
        data.Valute.UAH.Nominal + " Украинских гривней -> " + data.Valute.UAH.Value + " Рублей" + "<br>" +
        data.Valute.AMD.Nominal + " Армянских драм -> " + data.Valute.AMD.Value + " Рублей" + "<br>" + "Больше находите в конверторе внизу"
    );
    var RUR = data.Valute.USD.Value
    var BRL = data.Valute.BRL.Value
    var EUR = data.Valute.EUR.Value
    var INR = data.Valute.INR.Value
    var AUD = data.Valute.AUD.Value
    var AZN = data.Valute.AZN.Value
    var GBP = data.Valute.GBP.Value
    var AMD = data.Valute.AMD.Value
    var BYN = data.Valute.BYN.Value
    var UAH = data.Valute.UAH.Value
    var JPY = data.Valute.JPY.Value
    var HUF = data.Valute.HUF.Value
    var HKD = data.Valute.HKD.Value
    var DKK = data.Valute.DKK.Value
    var KZT = data.Valute.KZT.Value
    var CAD = data.Valute.CAD.Value
    var KGS = data.Valute.KGS.Value
    var CNY = data.Valute.CNY.Value
    var MDL = data.Valute.MDL.Value
    var NOK = data.Valute.NOK.Value
    var PLN = data.Valute.PLN.Value
    var BGN = data.Valute.BGN.Value
    var RON = data.Valute.RON.Value
    var XDR = data.Valute.XDR.Value
    var SGD = data.Valute.SGD.Value
    var TJS = data.Valute.TJS.Value
    var TRY = data.Valute.TRY.Value
    var TMT = data.Valute.TMT.Value
    var UZS = data.Valute.UZS.Value
    var CZK = data.Valute.CZK.Value
    var SEK = data.Valute.SEK.Value
    var CHF = data.Valute.CHF.Value
    var ZAR = data.Valute.ZAR.Value
    var KRW = data.Valute.KRW.Value

    var Money = function (symbol, value) {
        this.symbol = symbol;
        this.value = value;
    }

    var arr = [
        new Money("Рубль", 1),
        new Money("Доллар США", RUR / data.Valute.USD.Nominal),
        new Money("Евро", EUR / data.Valute.EUR.Nominal),
        new Money("Украинская гривна", UAH / data.Valute.UAH.Nominal),
        new Money("Белорусский рубль", BYN / data.Valute.BYN.Nominal),
        new Money("Армянский драм", AMD / data.Valute.AMD.Nominal),
        new Money("Бразильские реал", BRL / data.Valute.BRL.Nominal),
        new Money("Индийская рупия", INR / data.Valute.INR.Nominal),
        new Money("Австралийский доллар", AUD / data.Valute.AUD.Nominal),
        new Money("Азербайджанский манат", AZN / data.Valute.AZN.Nominal),
        new Money("Фунт стерлингов", GBP / data.Valute.GBP.Nominal),
        new Money("Японскиая иена", JPY / data.Valute.JPY.Nominal),
        new Money("Венгерский форинт", HUF / data.Valute.HUF.Nominal),
        new Money("Гонконгский доллар", HKD / data.Valute.HKD.Nominal),
        new Money("Датская крона", DKK / data.Valute.DKK.Nominal),
        new Money("Казахстанский тенге", KZT / data.Valute.KZT.Nominal),
        new Money("Канадский доллар", CAD / data.Valute.CAD.Nominal),
        new Money("Киргизский сом", KGS / data.Valute.KGS.Nominal),
        new Money("Жэньминьби", CNY / data.Valute.CNY.Nominal),
        new Money("Молдавский лей", MDL / data.Valute.MDL.Nominal),
        new Money("Норвежская крона", NOK / data.Valute.NOK.Nominal),
        new Money("Польский злотый", PLN / data.Valute.PLN.Nominal),
        new Money("Болгарский лев", BGN / data.Valute.BGN.Nominal),
        new Money("Румынский лей", RON / data.Valute.RON.Nominal),
        new Money("Специальные Права Заимствования", XDR / data.Valute.XDR.Nominal),
        new Money("Сингапурский доллар", SGD / data.Valute.SGD.Nominal),
        new Money("Таджикский сомони", TJS / data.Valute.TJS.Nominal),
        new Money("Турецкая лира", TRY / data.Valute.TRY.Nominal),
        new Money("Туркменский манат", TMT / data.Valute.TMT.Nominal),
        new Money("Узбекский сум", UZS / data.Valute.UZS.Nominal),
        new Money("Чешская крона", CZK / data.Valute.CZK.Nominal),
        new Money("Шведская крона", SEK / data.Valute.SEK.Nominal),
        new Money("Швейцарский франк", CHF / data.Valute.CHF.Nominal),
        new Money("Южноафриканский рэнд", ZAR / data.Valute.ZAR.Nominal),
        new Money("Южнокорейская вона", KRW / data.Valute.KRW.Nominal)
    ];


    var numInput = document.getElementById("num");
    var fromSelect = document.getElementById("from");
    var toSelect = document.getElementById("to");
    var resultSpan = document.getElementById("result");

    arr.forEach(function (money) {
        var option = document.createElement("option");
        option.text = money.symbol;
        fromSelect.add(option);

        option = option.cloneNode();
        option.text = money.symbol;
        toSelect.add(option);
    });

    numInput.oninput = fromSelect.oninput = toSelect.oninput = function (event) {
        var money1 = arr[fromSelect.options.selectedIndex];
        var money2 = arr[toSelect.options.selectedIndex];
        var num = +numInput.value;
        if (!numInput.value.length || isNaN(num)) {
            return;
        }
        console.log(numInput.value.length)

        var result = money1.value / money2.value * num;
        resultSpan.innerHTML = Math.round(result * 1000) / 1000 + " " + money2.symbol;
    }


});
