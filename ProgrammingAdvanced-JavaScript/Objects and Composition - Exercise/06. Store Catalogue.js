function solve(arr) {
    let productCatalogue = {};
    for (let i = 0; i < arr.length; i++) {
      let [productName, productPrice] = arr[i].split(' : ');

      productPrice = Number(productPrice);

      let initial = productName[0].toUpperCase();

      if(productCatalogue[initial] === undefined){
          productCatalogue[initial] = {};
      }

      productCatalogue[initial][productName] = productPrice;
    }

    let initialSorted = Object.keys(productCatalogue).sort
    ((a,b) => a.localeCompare(b));
    let result = [];

    for (const key of initialSorted) {
        let product = Object.entries(productCatalogue[key]).sort
        ((a,b) => a[0].localeCompare(b[0]));
        result.push(key);

        let productAsString = product.map(x => `${x[0]}: ${x[1]}`).join
        ('\n');
        result.push(productAsString);
    }
    return result.join('\n');
}

solve(['Appricot : 20.4',
'Fridge : 1500',
'TV : 1499',
'Deodorant : 10',
'Boiler : 300',
'Apple : 1.25',
'Anti-Bug Spray : 15',
'T-Shirt : 10']
);