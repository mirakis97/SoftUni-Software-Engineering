function juiceStore(array) {
    const bottles = new Map();

    array.reduce((acc, value) => {
        let [fruit, quantity] = value.split(' => ');
        quantity = Number(quantity);

        if (!acc.hasOwnProperty(fruit)) {
            acc[fruit] = 0;
        }
        acc[fruit] += quantity;

        if (acc[fruit] >= 1000) {
            if (!bottles.has(fruit)) {
                bottles.set(fruit, 0);
            }

            bottles.set(fruit, bottles.get(fruit) + parseInt(acc[fruit] / 1000));
            acc[fruit] %= 1000;
        }

        return acc
    }, {});

    for (const [fruit, quantity] of bottles) {
        console.log(`${fruit} => ${quantity}`); 
    }
}

juiceStore(['Kiwi => 234',
'Pear => 2345',
'Watermelon => 3456',
'Kiwi => 4567',
'Pear => 5678',
'Watermelon => 6789']
);