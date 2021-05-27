function solve(arr =[],n) {
    let result = arr;
    for (let i = 0; i < n; i++) {
        let el = result.pop();
        result.unshift(el);
    }
    return result.join(' ');
}
console.log(solve(['1', 
'2', 
'3', 
'4'], 
2
));