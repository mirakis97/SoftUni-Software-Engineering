function solve(input) {
    const obj = {};
    for (let i = 0; i < input.length; i++) {
        obj[input[i]] = +input[++i];
    }

    return obj;
}

console.log(solve(['Yoghurt', '48', 'Rise', '138', 'Apple', '52']));