function solve(arr) {
    let operands = [];

    for (let i = 0; i < arr.length; i++) {
        if (typeof arr[i] === 'number') {
            operands.push(arr[i])
        } else {
            let operator = arr[i];
            if (operands.length < 2) {
                console.log('Error: not enough operands!');
                break;
            }
            let operant2 = operands.pop();
            let operant1 = operands.pop();
            let result = applyOperators(operant1,operant2, operator);

            operands.push(result);
        }
        if(operands.length > 1) {
            console.log('Error: too many operands!');
            break;
        }

    }
    return operands.join();


    function applyOperators(op1, op2, operator) {
        const opertors = {
            '+': () => op1 + op2,
            '-': () => op1 - op2,
            '*': () => op1 * op2,
            '/': () => op1 / op2,
        }
        return opertors[operator]();
    }
}
solve([3,
    4,
    '+']
   );