function solve(arr1,arr2){
    let one = Number(arr1);
    let two = Number(arr2);
    let result = Number();
    for (let index = one; index <= two; index++) {
        
        result += index;
        
    }
    console.log(result)
}

solve('1', '5');