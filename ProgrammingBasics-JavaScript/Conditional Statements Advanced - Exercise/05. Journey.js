function journey (input) {
    var budget = Number(input[0]);
    var season = String(input[1]);

    if (budget <= 100)
    {
        if (season == "summer")
        {
            var moneyLeft = budget * 0.30;
            console.log(`Somewhere in Bulgaria`);
            console.log(`Camp - ${moneyLeft.toFixed(2)}`);
        }
        else
        {
            var moneyNeed = budget * 0.70;
            console.log(`Somewhere in Bulgaria`);
            console.log(`Hotel - ${moneyNeed.toFixed(2)}`);

        }                    
    }
    else if (budget <= 1000)
    {
        if (season == "summer")
        {
            var moneyLeft = budget * 0.40;
            console.log(`Somewhere in Balkans`);
            console.log(`Camp - ${moneyLeft.toFixed(2)}`);
        }
        else
        {
            var moneyNeeded = budget * 0.80;
            console.log(`Somewhere in Balkans`);
            console.log(`Hotel - ${moneyNeeded.toFixed(2)}`);
        }                    
    }
    else if (budget > 1000)
    {
        var moneyLeft = budget * 0.90;
        console.log(`Somewhere in Europe`);
        console.log(`Hotel - ${moneyLeft.toFixed(2)}`);
    }
}