function solve(arr1,arr2,arr3){
    let one = Number(arr1);
    let two = Number(arr2);
    let three = Number(arr3);
    let result ;
    if (one > two && one  > three) {
        result = one;
    }
    else if (two > one && two  > three) {
        result = two;
    }
    else if (three > one && three  > two) {
        result = three;
    }
    console.log(`The largest number is ${result}.`);
}
solve(5, -3, 16);