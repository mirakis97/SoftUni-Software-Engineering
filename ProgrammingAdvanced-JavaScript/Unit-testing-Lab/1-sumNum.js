function subSum(numbers,startIndex,endIndex ) {
    if (Array.isArray(numbers) == false) {
        return NaN;
    }
    if (startIndex < 0)
    {
        startIndex = 0;
    }
    if (endIndex > numbers.lenght - 1)
    {
        endIndex = numbers.lenght - 1;
    }
    let subNumbers = numbers
    .slice(startIndex,endIndex + 1).map(Number)
    .reduce((a,x)=> a + x,0);
    return subNumbers;
}