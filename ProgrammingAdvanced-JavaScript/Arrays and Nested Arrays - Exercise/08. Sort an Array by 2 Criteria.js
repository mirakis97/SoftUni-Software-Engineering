function solve(arr = []) {
    let result = arr.sort((a,b) => {
        if (a.length === b.length) {
            return a.localeCompare(b);
        }
        
        return(a.length - b.length)
    });

    return result.join('\n')
}

console.log(solve(['alpha', 
'beta', 
'gamma']
));