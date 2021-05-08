function fruitShop (input) {
    var fruit = String(input[0]);
    var dayOfWeek = String(input[1]);
    var number = Number(input[2]);

    var price = 0;
    
    switch (dayOfWeek)
    {
        case "Monday":
        case "Tuesday":
        case "Wednesday":
        case "Thursday":
        case "Friday":
            switch (fruit)
            {
                case "banana":
                    price = 2.50;
                    break;
                case "apple":
                    price = 1.20;
                    break;
                case "orange":
                    price = 0.85;
                    break;
                case "grapefruit":
                    price = 1.45;
                    break;
                case "kiwi": 
                    price = 2.70;
                    break;
                case "pineapple": 
                    price = 5.50;
                    break;
                case "grapes": 
                    price = 3.85;
                    break;
            }
            break;
        case "Saturday":
        case "Sunday":
            switch (fruit)
            {
                case "banana":
                    price = 2.70;
                    break;
                case "apple":
                    price = 1.25;
                    break;
                case "orange":
                    price = 0.90;
                    break;
                case "grapefruit":
                    price = 1.60;
                    break;
                case "kiwi":
                    price = 3.00;
                    break;
                case "pineapple":
                    price = 5.60;
                    break;
                case "grapes":
                    price = 4.20;
                    break;
            }
            break;
    }
     ;
    if (fruit != "banana" && fruit != "apple" && fruit != "orange" && fruit != "grapefruit" && fruit != "kiwi" && fruit != "pineapple" && fruit != "grapes")
    {
            console.log("error");
    }
    else if (dayOfWeek != "Monday" && dayOfWeek != "Tuesday" && dayOfWeek != "Wednesday" && dayOfWeek != "Thursday" && dayOfWeek != "Friday" && dayOfWeek != "Saturday" && dayOfWeek != "Sunday")
        {
            console.log("error");
        }
        else
    {
        var num = number * price;
        console.log(`${num.toFixed(2)}`);
    }
}