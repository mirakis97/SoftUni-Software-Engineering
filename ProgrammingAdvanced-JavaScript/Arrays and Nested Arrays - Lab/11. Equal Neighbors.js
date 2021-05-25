function solve(nums) {
    let pairs = 0;

    for (let i = 0; i < nums.length; i++) {
        for (let j = 0; j < nums[i].length; j++) {
            
            if (i === nums.length - 1) {
                if (nums[i][j] === nums[i][j + 1]) {
                    pairs++;
                }
            }
            else {
                if (nums[i][j] === nums[i + 1][j]) {
                    pairs++;
                }

                if (nums[i][j] === nums[i][j + 1]) {
                    pairs++;
                }
            }
        }
    }
    return pairs;
}


console.log(solve(
    [['2', '3', '4', '7', '0'],
    ['4', '0', '5', '3', '4'],
    ['2', '3', '5', '4', '2'],
    ['9', '8', '7', '5', '4']]))

console.log(solve(
    [['test', 'yes', 'yo', 'ho'],
    ['well', 'done', 'yo', '6'],
    ['not', 'done', 'yet', '5']]
))

console.log(solve(
    [[2, 2, 5, 7, 4],
    [4, 0, 5, 3, 4],
    [2, 5, 5, 4, 2]]
))