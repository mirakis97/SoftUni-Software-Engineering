function solve(arr1,arr2,arr3){
    let one = String(arr1);
    let two = String(arr2);
    let three = String(arr3);

    let sum = one.length + two.length + three.length;
    let average = Math.floor(sum / 3);

    console.log(sum);
    console.log(average);
}

solve('chocolate', 'ice cream', 'cake');
