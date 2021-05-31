function solve(array) {
    let obj = {};
    for (const line of array) {
        let [town, product, price] = line.split(' | ');
        price = Number(price);
        obj[product] ? obj[product][town] = price : obj[product] = { [town]: price };
    }
    for (const key in obj) {
        let sorted = Object.entries(obj[key]).sort((a,b) => a[1] - b[1]);
        console.log(`${key} -> ${sorted[0][1]} (${sorted[0][0]})`); 
    }
}
solve(['Sample Town | Sample Product | 1000',
'Sample Town | Orange | 2',
'Sample Town | Peach | 1',
'Sofia | Orange | 3',
'Sofia | Peach | 2',
'New York | Sample Product | 1000.1',
'New York | Burger | 10']
)