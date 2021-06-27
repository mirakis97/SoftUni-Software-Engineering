class Restaurant {
    constructor(budgetMoney) {
        this.budgetMoney = +budgetMoney;
        this.menu = {};
        this.stockProducts = {}
        this.history = []
    }
    loadProducts(products) {  //["product quantity price", ...
        let messageLog = []
        for (let entry of products) {
            entry = entry.split(' ')
            //let [product, quantity, price] = entry.split(' ')
            let price = +entry.pop()
            let quantity = +entry.pop()
            let product = entry.join(' ')
            if (this.budgetMoney - price >= 0) {
                if (this.stockProducts[product]) this.stockProducts[product] += Number(quantity)
                else this.stockProducts[product] = Number(quantity)
                this.budgetMoney -= Number(price)
                messageLog.push( `Successfully loaded ${quantity} ${product}`) //test 3
            } else {
                messageLog.push(`There was not enough money to load ${quantity} ${product}`)//test 4
            }
        }
        //this.history.push(messageLog.join('\n'))
        this.history = [...this.history, ...messageLog]
        return this.history.join('\n')  //test 5 pass
        
    }
    addToMenu(meal, neededIngs, price) {  //neededIngs = ['product quantity', ...
        if (!this.menu[meal]) {
            this.menu[meal] = {products: neededIngs, price: +price}
            if (Object.keys(this.menu).length === 1)
            {
            return `Great idea! Now with the ${meal} we have 1 meal in the menu, other ideas?`

            }
            return `Great idea! Now with the ${meal} we have 2 meals in the menu, other ideas?` //? no effect //TEST 6 ERROR
        } else 
        {return `The ${meal} is already in the our menu, try something different.`} //test 7 - pass
 
    }
    showTheMenu() {
        let toPrint = []
        for (let key of Object.keys(this.menu)) {
            toPrint.push(`${key} - $ ${this.menu[key][1]}`) 
        }
        if (!toPrint.length) return ('Our menu is not ready yet, please come later...') //test 8 pass
        else {return toPrint.join('\n').trimEnd()} // // TEST 9 ERROR 
 
    }
    makeTheOrder(meal) {
        if (!this.menu[meal]) return (`There is not ${meal} yet in our menu, do you want to order something else?`)
        //check for products          
        let ingredientsNeeded = this.menu[meal][0]  
        for (let item of ingredientsNeeded) {  //item = 'product quantity'
            item = item.split(' ')
            let quantity = +item.pop()
            let product = item.join(' ')
            //let [product, quantity] = item.split(' ')
            if (this.stockProducts[product] < quantity || !this.stockProducts[product]) {
                return (`For the time being, we cannot complete your order (${meal}), we are very sorry...`) // test 15
            }
        }
 
        for (let item of ingredientsNeeded) {
            item = item.split(' ')
            let quantity = +item.pop()
            let product = item.join(' ')
            this.stockProducts[product] -= quantity
        } this.budgetMoney += this.menu[meal][1]
        return (`Your order (${meal}) will be completed in the next 30 minutes and will cost you ${this.menu[meal][1]}.`) //test 13 pass
    }
}
let kitchen = new Restaurant(1000);
console.log(kitchen.loadProducts(['Banana 10 5', 'Banana 20 10', 'Strawberries 50 30', 'Yogurt 10 10', 'Yogurt 500 1500', 'Honey 5 50']));
