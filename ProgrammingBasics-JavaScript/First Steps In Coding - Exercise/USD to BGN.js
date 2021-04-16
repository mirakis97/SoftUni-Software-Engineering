function usdToBgn(input) {
    let usd = Number(input.shift())
    let bgn = 1.79549
    
    let usdToBgnFinal = usd * bgn
    console.log(`${usdToBgnFinal.toFixed(2)} BGN`)
 
}

usdToBgn([20])