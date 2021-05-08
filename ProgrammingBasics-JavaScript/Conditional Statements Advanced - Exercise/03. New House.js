function newHouse (input) {
             var roses = 5;
             var dahlias = 3.80;
             var tulips = 2.80;
             var narcissus = 3;
             var gladiolus = 2.50;

            var typeOfFlower = String(input[0]);
            var numberOfFlowers = Number(input[1]);
            var budget = Number(input[2]);
            var totalMoney = 0;
            
            if (typeOfFlower == "Roses")
            {
                if (numberOfFlowers > 80)
                {
                    var money = (numberOfFlowers * roses) * 0.10;
                    totalMoney = (numberOfFlowers * roses) - money;
                }
                else
                {
                    totalMoney = numberOfFlowers * roses;
                }
            }                
            if (typeOfFlower == "Dahlias")
            { 
                if (numberOfFlowers > 90)
                {
                    var money = (numberOfFlowers * dahlias) * 0.15;
                    totalMoney = (numberOfFlowers * dahlias) - money;
                }
                else
                {
                    totalMoney = numberOfFlowers * dahlias;
                }
            }
            if (typeOfFlower == "Tulips")
            {
                if (numberOfFlowers > 80)
                {
                    var money = (numberOfFlowers * tulips) * 0.15;
                    totalMoney = (numberOfFlowers * tulips) - money;
                }
                else
                {
                    totalMoney = numberOfFlowers * tulips;
                }
            }
            if (typeOfFlower == "Narcissus")
            {
                if (numberOfFlowers < 120)
                {
                    var money = (numberOfFlowers * narcissus) * 0.15;
                    totalMoney = money + (numberOfFlowers * narcissus);
                }
                else
                {
                    totalMoney = numberOfFlowers * narcissus;
                }
            }
            if (typeOfFlower == "Gladiolus")
            {
                if (numberOfFlowers < 80)
                {
                    var money = (numberOfFlowers * gladiolus) * 0.20;
                    totalMoney = money + (numberOfFlowers * gladiolus);
                }
                else
                {
                    totalMoney = numberOfFlowers * gladiolus;
                }
            }
            if (budget >= totalMoney)
            {
                var moneyLeft = budget - totalMoney;
                console.log(`Hey, you have a great garden with ${numberOfFlowers} ${typeOfFlower} and ${moneyLeft.toFixed(2)} leva left.`);
            }
            if (budget < totalMoney)
            {
                var moneyNeeded = totalMoney - budget;
                console.log(`Not enough money, you need ${moneyNeeded.toFixed(2)} leva more.`);
            }
}