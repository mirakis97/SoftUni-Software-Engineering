function solve(arr =[],n) {
    return arr.filter((_,index) => index % n == 0);
}

console.log(solve(['5',
    '20',
    '31',
    '4',
    '20'],
    2))