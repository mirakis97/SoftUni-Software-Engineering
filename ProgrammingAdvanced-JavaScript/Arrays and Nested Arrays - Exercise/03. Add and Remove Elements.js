function solve(arr = []) {
    let result = [];
    let num = 1;

    for (let comand of arr) {
        if (comand === 'add') {
            result.push(num);
        }
        else{
            result.pop();
        }
        num++;
    }
    
    if (result.length === 0) {
        return 'Empty';
    }
    else{
        return result.join('\n')
    }
}
console.log(solve(['add',
    'add',
    'add',
    'add']));