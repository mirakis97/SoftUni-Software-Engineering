function godzilaVsKong (input)
{
      //Input
      var budgetForMovie = Number(input[0]);
      var numbersOfExtras = Number(input[1]);
      var priceForClothesForOneStatist = Number(input[2]);
      //Calculations
      var priceForDecor = budgetForMovie * 0.10;
      
      //Output
      
      if (numbersOfExtras > 150)
      {
          priceForClothesForOneStatist *= 0.90;
      }
      var priceForClothes = numbersOfExtras * priceForClothesForOneStatist;
      var priceOfTheMovie = priceForDecor + priceForClothes;

      if (priceOfTheMovie > budgetForMovie)
      {
        var neededMoney = priceOfTheMovie - budgetForMovie;
        console.log("Not enough money!");
        console.log(`Wingard needs ${neededMoney.toFixed(2)} leva more.`);
      }
      else if (priceOfTheMovie <= budgetForMovie)
      {
        var priceLeft = budgetForMovie - priceOfTheMovie;
          console.log("Action!");
          console.log(`Wingard starts filming with ${priceLeft.toFixed(2)} leva left.`);
      }
}
godzilaVsKong(["20000",
"120",
"55.5"])
;