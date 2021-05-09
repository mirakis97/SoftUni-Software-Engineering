function sumOfNumbers (input) {
    var n = Number(input[0]);

    var sum = 0;

    for (var i = 0; i < n.toString.length; i++)
    {
        var num = n.toString[i];
        sum += num;
    }
    console.log(`The sum of the digits is:${sum}`);
}
sumOfNumbers(["1234"]);