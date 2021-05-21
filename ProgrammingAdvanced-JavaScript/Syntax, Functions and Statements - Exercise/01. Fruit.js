function solve(fruit,grams,price) {
    let weightInKg = grams / 1000;
    let money = weightInKg * price;

    return `I need $${money.toFixed(2)} to buy ${weightInKg.toFixed(2)} kilograms ${fruit}.`;
    
}