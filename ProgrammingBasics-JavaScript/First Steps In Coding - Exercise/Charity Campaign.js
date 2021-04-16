function charity(input) {
    var days = Number(input[0]);
    var chefs = Number(input[1]);
    var cakes = Number(input[2]);
    var waffels = Number(input[3]);
    var pancakes = Number(input[4]);
    
    var cakesFromOneChef = cakes * 45;
    var waffelsFromOneChef = waffels * 5.80;
    var pancakesFromOneChef = pancakes * 3.20;
    var priceForOneDay = (cakesFromOneChef + waffelsFromOneChef +  pancakesFromOneChef) * chefs;
    var totalPrice = priceForOneDay * days;
    var totalPriceWithCoverdProducts = totalPrice - (totalPrice / 8);
    console.log(totalPriceWithCoverdProducts)
}

charity(["23",
"8",
"14",
"30",
"16"])
