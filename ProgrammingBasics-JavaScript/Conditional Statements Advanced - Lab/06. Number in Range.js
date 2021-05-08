function numbersInRange (input) {
    var num1 = Number(input[0]);

            if (num1 >= -100 && num1 <= 100 && num1 != 0)
            {
                console.log("Yes");
            }
            else
            {
                console.log("No");
            }
}
numbersInRange(["120"]);