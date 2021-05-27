function solve(matrix = [[]]) {
    let arRowsEqual = matrix.map(row => row.reduce((a, b) => a + b))
    .every((element, index,arr) => element === arr[0]);
    let areColsEqual = matrix.reduce((a, b) => a.map((element, index) => element + b[index]))
    .every((element, index,arr) => element === arr[0]);

    return arRowsEqual && areColsEqual;
}

console.log(solve([
    [4, 5, 6],
    [6, 5, 4],
    [5, 5, 5]]));