function toyStore (input){
    var priceOfTrip = Number(input[0]);
    var numberOfCrosswords = Number(input[1]);
    var numberOfTalkingDolls = Number(input[2]);
    var numberOfTeddyBears = Number(input[3]);
    var numberOfMinions = Number(input[4]);
    var numberOfTrucks = Number(input[5]);

    var finalPrice = (numberOfCrosswords * 2.6) + (numberOfTalkingDolls * 3) + (numberOfTeddyBears * 4.10) + (numberOfMinions * 8.20) + (numberOfTrucks * 2);
    var finalNumberOfToys = numberOfCrosswords + numberOfTalkingDolls + numberOfTeddyBears + numberOfMinions + numberOfTrucks;

            if (finalNumberOfToys >= 50)
            {
                finalPrice *= 0.75;
            }
            finalPrice *= 0.90;

            if (finalPrice >= priceOfTrip)
            {
                var moneyLeft = finalPrice - priceOfTrip;
                console.log(`Yes! ${moneyLeft.toFixed(2)} lv left.`);
            }
            else if (finalPrice < priceOfTrip)
            {
                var moneyWeNeed = priceOfTrip - finalPrice;
                    console.log(`Not enough money! ${moneyWeNeed.toFixed(2)} lv needed.`);
            }
}
toyStore(["40.8", "20", "25", "30", "50", "10"]);