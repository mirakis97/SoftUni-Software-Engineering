function gardening(input) {
    let kvMeters = Number(input.shift())
    let priceForMeters = 7.61
    
    let price = kvMeters * priceForMeters
    let discount = price * 0.18
    let totalPrice = price - discount;
    console.log(`The final price is: ${totalPrice.toFixed(2)} lv.`)
    console.log(`The discount is: ${discount.toFixed(2)} lv.`)
}

gardening([540])