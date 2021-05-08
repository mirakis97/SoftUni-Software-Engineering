function cinema (input) {
    var typeOfProjection = String(input[0]);
    var numOfRow = Number(input[1]);
    var numOfColums = Number(input[2]);

    var price = 0;
    switch (typeOfProjection)
    {
        case "Premiere":
            price = 12.00;
            var income = price * numOfColums * numOfRow;
            console.log(`${income.toFixed(2)} leva`);
            break;
        case "Normal":
            price = 7.50;
            var normalIncome = price * numOfColums * numOfRow;
            console.log(`${normalIncome.toFixed(2)} leva`);
            break;
        case "Discount":
            price = 5.00;
            var discountIncome = price * numOfColums * numOfRow;
            console.log(`${discountIncome.toFixed(2)} leva`);
            break;
    }
}