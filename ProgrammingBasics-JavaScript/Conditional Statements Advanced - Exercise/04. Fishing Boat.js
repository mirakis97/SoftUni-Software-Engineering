function fishingBoat (input) {
             var springPrice = 3000;
             var summerAndAutumnPrice = 4200;
             var winterPrice = 2600;

            var  budget = Number(input[0]);
            var season = String(input[1]);
            var numberOfFisherman = Number(input[2]);
            var totalMoney = 0;

            switch (season)
            {
                case "Spring":
                    totalMoney = springPrice;
                    break;
                case "Summer":
                    totalMoney = summerAndAutumnPrice;
                    break;
                case "Autumn":
                    totalMoney = summerAndAutumnPrice;
                    break;
                case "Winter":
                    totalMoney = winterPrice;
                    break;
            }
            if (numberOfFisherman <=6)
            {
                totalMoney -= totalMoney * 0.10;
            }
            else if (numberOfFisherman > 6 && numberOfFisherman <= 11)
            {
                totalMoney -= totalMoney * 0.15;
            }
            else
            {
                totalMoney -= totalMoney * 0.25;
            }
            if (numberOfFisherman % 2 == 0 && season != "Autumn")
            {
                totalMoney -= totalMoney * 0.05;
            }
            if (budget >= totalMoney)
            {
                var moneyLeft = budget - totalMoney;
                console.log(`Yes! You have ${moneyLeft.toFixed(2)} leva left.`);
            }
            else
            {
                var moneyNeeded = totalMoney - budget;
                console.log(`Not enough money! You need ${moneyNeeded.toFixed(2)} leva.`);
            }
}