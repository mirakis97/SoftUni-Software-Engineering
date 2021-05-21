function solve(num, op1, op2, op3, op4, op5) {
    num = operation(num,op1);
    console.log(num);
    num = operation(num,op2);
    console.log(num);
    num = operation(num,op3);
    console.log(num);
    num = operation(num,op4);
    console.log(num);
    num = operation(num,op5);
    console.log(num);
    
    function operation(num,op) {
        switch (op) {
            case "chop":
                num /= 2;
                break;
            case "dice":
                num = Math.sqrt(num);
                break;
            case "spice":
                num++;
                break;         
            case "bake":
                num *= 3;
                break; 
            case "fillet":
                num = num * 0.8;
                break; 
            default:
                break;
        }
        return num;
    }
   
}
solve('32', 'chop', 'chop', 'chop', 'chop', 'chop');