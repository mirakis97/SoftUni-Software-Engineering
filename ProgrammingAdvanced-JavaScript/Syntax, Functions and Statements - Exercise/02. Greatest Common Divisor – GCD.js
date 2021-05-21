function solve(a,b) {
    while (b > 0) {
        let temp = b;
        b = a % b;
        a = temp;
    }

    return a;
}

solve(15,5);