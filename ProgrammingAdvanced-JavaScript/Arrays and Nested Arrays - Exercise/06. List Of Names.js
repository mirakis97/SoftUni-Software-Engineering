function solve(arr) {
    let sorted = arr.sort((a,b) => a.localeCompare(b)).map((name,index) => {return `${index + 1}.${name}`;})
    
    return sorted.join('\n')
}

console.log(solve(["John", "Bob", "Christina", "Ema"]));