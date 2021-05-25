function solve(n,k) {
    const length = Number(n);
    let steps = Number(k);
    let arr = [1];
    
    for (let i = 1; i < length; i++){
        let nextNum = sum(arr,steps)
        arr.push(nextNum)
       
    }
    
    function sum(arr,steps) {
        steps = arr.length < steps ? arr.length : steps;

        let result = 0;

        for (let i = 1; i <= steps; i++) {
            result += arr[arr.length - i];
            
        }
        return result;
    }
    return arr;
}

console.log(solve(6,3));
console.log(solve(8,2));