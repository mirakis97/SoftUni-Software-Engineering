function SkiTrip (input) {
     var roomForOnePerson = 18.00;
     var apartment = 25.00;
     var presidentRoom = 35.00;

    var daysForStay = Number(input[0]);
    var typeOfRoom = String(input[1]);
    var quality = String(input[2]);

    var totalMoney = 0;
    if (daysForStay < 10)
    {
        if (typeOfRoom == "room for one person")
        {
            totalMoney = roomForOnePerson * (daysForStay - 1);
        }
        else if (typeOfRoom == "apartment")
        {
            totalMoney = (apartment * (daysForStay - 1)) - (apartment * (daysForStay - 1)) * 0.30;
        }
        else if (typeOfRoom == "president apartment")
        {
            totalMoney = (presidentRoom * (daysForStay - 1)) - (presidentRoom * (daysForStay - 1)) * 0.10;
        }
    }
    else if (daysForStay >= 10 && daysForStay < 15)
    {
        if (typeOfRoom == "room for one person")
        {
            totalMoney = roomForOnePerson * (daysForStay - 1) ;
        }
        else if (typeOfRoom == "apartment")
        {
            totalMoney = (apartment * (daysForStay - 1)) - (apartment * (daysForStay - 1)) * 0.35;
        }
        else if (typeOfRoom == "president apartment")
        {
            totalMoney = (presidentRoom * (daysForStay - 1)) - (presidentRoom * (daysForStay - 1)) * 0.15;
        }
    }
    else if (daysForStay >= 15)
    {
        if (typeOfRoom == "room for one person")
        {
            totalMoney = roomForOnePerson * (daysForStay - 1);
        }
        else if (typeOfRoom == "apartment")
        {
            totalMoney = (apartment * (daysForStay - 1)) - (apartment * (daysForStay - 1)) * 0.50;
        }
        else if (typeOfRoom == "president apartment")
        {
            totalMoney = (presidentRoom * (daysForStay - 1)) - (presidentRoom * (daysForStay - 1)) * 0.20;
        }
    }
    if (quality == "positive")
    {
        var newPrice = totalMoney + (totalMoney * 0.25);
        console.log(`${newPrice.toFixed(2)}`);
    }
    else if (quality == "negative")
    {
        var newPrice = totalMoney - (totalMoney * 0.10);
        console.log(`${newPrice.toFixed(2)}`);
    }
}