function evenPowers (input) {
    var num = Number(input[0]);
    for (var i = 0; i <= num; i += 2)
    {

        console.log(Math.pow(2, i));
    }
}