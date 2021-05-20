function solve(arr1,arr2,operator){
    let one = Number(arr1);
    let two = Number(arr2);
    let three = String(operator);
    let result ;
    switch (three) {
            case "+": result = one + two; 
            
            break;
            case "-": result = one - two; 
            
            break;
            case "/": result = one / two; 
            
            break;
            case "*": result = one * two; 
            
            break;
            case "%": result = one % two; 
            
            break;
            case "**": result = one ** two; 
            
            break;
    }
    
    console.log(result);
}

solve(5, 6, '+');