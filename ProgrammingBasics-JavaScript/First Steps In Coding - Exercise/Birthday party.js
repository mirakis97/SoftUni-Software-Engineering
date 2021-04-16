function birthdayParty(input) {
    var priceForThePlace = Number(input[0]);
    
    var priceForCake = priceForThePlace * 0.20;
    var priceForDrinks = priceForCake - (priceForCake * 0.45);
    var priceForAnimator = priceForThePlace / 3;
    var totalPrice = priceForThePlace + priceForCake + priceForDrinks + priceForAnimator;
    console.log(totalPrice);
}
birthdayParty(["3720"])