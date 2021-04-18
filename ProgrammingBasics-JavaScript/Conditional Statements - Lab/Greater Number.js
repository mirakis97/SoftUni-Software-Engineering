function greaterNumber(input){

    var num1 = Number(input[0]);
    var num2 = Number(input[1]);

    if (num1 > num2) {
        console.log(num1);
    }
    else{
        console.log(num2);
    }        
}

greaterNumber(["5", "3"]);