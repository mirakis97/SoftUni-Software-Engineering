function solve(input = []) {
    let nums = input.sort((a,b) => (a - b));
    let result = [];

    while (nums.length !== 0) {
        result.push(nums.shift());
        result.push(nums.pop());
    }
    return result;
}

console.log(solve([1, 65, 3, 52, 48, 63, 31, -3, 18, 56]));