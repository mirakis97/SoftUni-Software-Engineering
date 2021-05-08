function volleyball (input) {
    var year = String(input[0]);
    var holidays = Number(input[1]);
    var weekends = Number(input[2]);

    var weekendsInSofia = 48 - weekends;
    var weekendsSofiaPlay = weekendsInSofia * 3.0 / 4.0;
    var holidaysInSofia = holidays * 2.0 / 3.0;

    var plays = holidaysInSofia + weekendsSofiaPlay + weekends;
    if (year == "leap")
    {
        plays *= 1.15;
        console.log(`${Math.floor(plays)}`);
    }
    else
    {
        console.log(`${Math.floor(plays)}`);
    }
}