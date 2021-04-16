function petShop(input) {
    let dogs = Number(input.shift())
    let otherAnimal = Number(input.shift())
    let dogFoodPrice = dogs * 2.5
    let foodForOtherAnimal = otherAnimal * 4

    let totalPrice = dogFoodPrice + foodForOtherAnimal

    console.log(`${totalPrice.toFixed(2)} lv.`)
}

petShop([5,4])

