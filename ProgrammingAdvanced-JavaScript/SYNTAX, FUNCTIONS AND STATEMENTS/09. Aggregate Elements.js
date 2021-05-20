function solve(input) {

    function aggregate(arr, initVal, func) {

        let result = initVal;

        for (let i = 0; i < arr.length; i++) {
            result = func(result, arr[i]);
        }

        return result;
    }

    let sum = aggregate(input, 0, (a, b) => a + b);
    let inverseSum = aggregate(input, 0, (a, b) => a + 1/b);
    let concat = aggregate(input, '', (a, b) => a + b);

    console.log(sum);
    console.log(inverseSum);
    console.log(concat);

}
solve([1, 2, 3]);