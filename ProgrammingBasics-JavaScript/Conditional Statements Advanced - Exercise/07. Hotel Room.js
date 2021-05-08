function hotelRoom (input) {
    
    var studioPriceMayOctober = 50;
    var apartmentPriceMayOctober = 65;
    var studioPriceJuneSeptember = 75.20;
    var apartmentPriceJuneSeptember = 68.70;
    var studioPriceJulyAugust = 76;
    var apartmentPriceJulyAugust = 77;

    var month = String(input[0]);
    var numbersOfNights = Number(input[1]);

    var totalPriceForStudio = 0;
    var totalPriceForApartment = 0;

    switch (month)
    {
        case "May":
            totalPriceForApartment = numbersOfNights * apartmentPriceMayOctober;
            totalPriceForStudio = numbersOfNights * studioPriceMayOctober;
            if (numbersOfNights > 7 && numbersOfNights <= 14)
            {

                totalPriceForStudio -= totalPriceForStudio * 0.05;
            }
            else if (numbersOfNights > 14)
            {

                totalPriceForStudio -= totalPriceForStudio * 0.30;
            }
            break;
        case "October":
            totalPriceForApartment = numbersOfNights * apartmentPriceMayOctober;
            totalPriceForStudio = numbersOfNights * studioPriceMayOctober;
            if (numbersOfNights > 7 && numbersOfNights <= 14)
            {

                totalPriceForStudio -= totalPriceForStudio * 0.05;
            }
            else if (numbersOfNights > 14)
            {

                totalPriceForStudio -= totalPriceForStudio * 0.30;
            }
            break;
        case "June":
            totalPriceForApartment = numbersOfNights * apartmentPriceJuneSeptember;
            totalPriceForStudio = numbersOfNights * studioPriceJuneSeptember;
            if (numbersOfNights > 14)
            {
                totalPriceForStudio -= totalPriceForStudio * 0.20;
            }
            break;
        case "September":
            totalPriceForApartment = numbersOfNights * apartmentPriceJuneSeptember;
            totalPriceForStudio = numbersOfNights * studioPriceJuneSeptember;
            if (numbersOfNights > 14)
            {
                totalPriceForStudio -= totalPriceForStudio * 0.20;
            }
            break;
        case "July":
            totalPriceForApartment = numbersOfNights * apartmentPriceJulyAugust;
            totalPriceForStudio = numbersOfNights * studioPriceJulyAugust;
            break;
        case "August":
            totalPriceForApartment = numbersOfNights * apartmentPriceJulyAugust;
            totalPriceForStudio = numbersOfNights * studioPriceJulyAugust;
            break;

    }
    if (numbersOfNights > 14)
    {
        totalPriceForApartment -= totalPriceForApartment * 0.10;
    }

    console.log(`Apartment: ${totalPriceForApartment.toFixed(2)} lv.`);
    console.log(`Studio: ${totalPriceForStudio.toFixed(2)} lv.`);
}   
