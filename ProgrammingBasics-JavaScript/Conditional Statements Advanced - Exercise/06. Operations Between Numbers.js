function operation (input) {
    var n1 = Number(input[0]);
    var n2 = Number(input[1]);
    var math = String(input[2]);

    var result = 0;
    var type = "";

    if (math == "+")
    {
        result = n1 + n2;
        if (result % 2 == 0)
        {
            type = "even";
            console.log(`${n1} ${math} ${n2} = ${result} - ${type}`);
        }
        else
        {
            type = "odd";
            console.log(`${n1} ${math} ${n2} = ${result} - ${type}`);
        }
    }
    else if (math == "-")
    {
        result = n1 - n2;
        if (result % 2 == 0)
        {
            type = "even";
            console.log(`${n1} ${math} ${n2} = ${result} - ${type}`);
        }
        else
        {
            type = "odd";
            console.log(`${n1} ${math} ${n2} = ${result} - ${type}`);
        }
    }
    else if (math == "*")
    {
        result = n1 * n2;
        if (result % 2 == 0)
        {
            type = "even";
            console.log(`${n1} ${math} ${n2} = ${result} - ${type}`);
        }
        else
        {
            type = "odd";
            console.log(`${n1} ${math} ${n2} = ${result} - ${type}`);
        }
    }
    else if (math == "/" && n2 == 0)
    {
        console.log(`Cannot divide ${n1} by zero`);
    }
    else if (math == "%" && n2 == 0)
    {
        console.log(`Cannot divide ${n1} by zero`);
    }
    else if (math == "/")
    {
        result = n1  /  n2;
        console.log(`${n1} / ${n2} = ${result.toFixed(2)}`);
    }
    else if (math == "%")
    {
        result = n1 % n2;
        console.log(`${n1} % ${n2} = ${result}`);
    }
}