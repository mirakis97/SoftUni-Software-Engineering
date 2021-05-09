function rangeby9([n,n1]) {
    let num = Number(n);
    let num1 = Number(n1);
    let res = 0;
    let output = "";
    for (let i=num; i<=num1;i++) {
        if(i % 9 == 0) {
            res += i;
            output += i +  "\n" ;        
        }
    }
    console.log(`The sum: ${res}`);
    console.log(output);
}