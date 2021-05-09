function vowelsSum (input) {
    var cha = String(input[0]);

    var number = 0;
    for (var i = 0; i < cha.length; i++)
    {
        var  currentLetter = cha[i];

        switch (currentLetter)
        {
            case 'a':
                number += 1;
                break;
            case 'e':
                number += 2;
                break;
            case 'i':
                number += 3;
                break;
            case 'o':
                number += 4;
                break;
            case 'u':
                number += 5;
                break;
        }
    }
    console.log(number);
}
