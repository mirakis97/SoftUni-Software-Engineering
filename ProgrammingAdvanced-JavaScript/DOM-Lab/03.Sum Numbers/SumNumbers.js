function calc() {
    // TODO: sum = num1 + num2
    let num1 = document.getElementById('num1').value;
    
    let num2 = document.getElementById('num2').value;

    let sum1 = Number(num1) + Number(num2);
    document.getElementById('sum').value = sum1;
}
