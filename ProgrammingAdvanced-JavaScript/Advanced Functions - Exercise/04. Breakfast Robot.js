function solution() {
    const recipes = {
        apple: { carbohydrate: 1, flavour: 2 },
        lemonade: { carbohydrate: 10, flavour: 20 },
        burger: { carbohydrate: 5, fat: 7, flavour: 3 },
        eggs: { protein: 5, fat: 1, flavour: 1 },
        turkey: { protein: 10, carbohydrate: 10, fat: 10, flavour: 10 },
    }
    const storage = {
        protein: 0,
        carbohydrate: 0,
        fat: 0,
        flavour: 0,
    }

    const actions = {
        restock(ingredient, qnty) {
            storage[ingredient] += qnty;
            return 'Success';
        },
        prepare(recipe, qnty) {
            let deductedSupplies = {};
            for (const ingredient in recipes[recipe]) {
                if (storage[ingredient] < recipes[recipe][ingredient] * qnty) {
                    return `Error: not enough ${ingredient} in stock`;

                } else {
                    deductedSupplies[ingredient] = storage[ingredient] - recipes[recipe][ingredient] * qnty;
                }
            }
            Object.assign(storage, deductedSupplies);
            return 'Success';
        },
        report() {
            return Object.entries(storage)
                .map(entry => `${entry[0]}=${entry[1]}`)
                .join(' ')
        }
    }
    return function manager(input) {
        let [action, ingredient, qnty] = input.split(' ');
        qnty = Number(qnty);
        return actions[action](ingredient, qnty)
    }
}