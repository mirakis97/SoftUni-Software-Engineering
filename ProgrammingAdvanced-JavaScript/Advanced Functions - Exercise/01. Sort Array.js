function solve(number = [],sortType) {
    const actions = {
        'asc' : () => number.slice().sort((a,b) => a - b),
        'desc' : () => number.slice().sort((a,b) => b -a),
    };
    return actions[sortType]();
}