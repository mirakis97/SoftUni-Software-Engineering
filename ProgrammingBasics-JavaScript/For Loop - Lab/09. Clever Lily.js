function cleverLily(input) {
    var age = Number(input[0]);
    var priceForMashine = Number(input[1]);
    var priceOfToys = Number(input[2]);

    var toyCount = 0;
    var savedMoney = 0;
    var temp = 10;
    for (var i = 1; i <= age; i++)
    {
        if (i % 2 != 0)
        {
            toyCount++;
        }
        else
        {
            savedMoney += temp;
            temp += 10;
        }
    }
    savedMoney -= age / 2;

    savedMoney += toyCount * priceOfToys;

    var leftMoney = Math.abs(savedMoney - priceForMashine);

    if (savedMoney >= priceForMashine)
    {
        console.log(`Yes! ${leftMoney.toFixed(2)}`);
    }
    else
    {
        console.log(`No! ${leftMoney.toFixed(2)}`);
    }
}