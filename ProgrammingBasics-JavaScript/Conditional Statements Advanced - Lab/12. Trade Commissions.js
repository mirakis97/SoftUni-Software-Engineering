function tradeCommission (input) {
    var city = String(input[0]);
    var money = Number(input[1]);

    var comission = -1.0;

    if (city == "Sofia")
    {
        if (money >= 0 && money <= 500)
        {
          comission = money * 0.05;
        }
        else if (money > 500 && money <= 1000)
        {
            comission = money * 0.07;
        }
        else if (money > 1000 && money <= 10000)
        {
            comission = money * 0.08;
        }
        else if (money > 10000)
        {
            comission = money * 0.12;
        }
        console.log(`${comission.toFixed(2)}`);
    }
    if (city == "Varna")
    {
        if (money >= 0 && money <= 500)
        {
            comission = money * 0.045;
        }
        else if (money > 500 && money <= 1000)
        {
            comission = money * 0.075;
        }
        else if (money > 1000 && money <= 10000)
        {
            comission = money * 0.10;
        }
        else if (money > 10000)
        {
            comission = money * 0.13;
        }
        console.log(`${comission.toFixed(2)}`);
    }
    if (city == "Plovdiv")
    {
        
        if (money >= 0 && money <= 500)
        {
            comission = money * 0.055;
            console.log(`${comission.toFixed(2)}`);
        }
        else if (money > 500 && money <= 1000)
        {
            comission = money * 0.08;
            console.log(`${comission.toFixed(2)}`);
        }
        else if (money > 1000 && money <= 10000)
        {
            comission = money * 0.12;
            console.log(`${comission.toFixed(2)}`);
        }
        else if (money > 10000)
        {
            comission = money * 0.145;
            console.log(`${comission.toFixed(2)}`);
        }
        else if (money < 0)
        {
            console.log("error");
        }
    }

    if (city != "Sofia" && city != "Varna" && city != "Plovdiv")
    {
        console.log("error");
    }
}