function depositingCalculator(input) {
    let deposite = Number(input[0])
    let depositeMonths = Number(input[1])
    let yearlyTax = Number(input[2])
    
    let tax = deposite * (yearlyTax / 100)
    let taxForTwelweMonths = tax / 12
    let taxForOneMonth = deposite + (depositeMonths *taxForTwelweMonths)
    console.log(taxForOneMonth.toFixed(2))
}

depositingCalculator(["200",
"3",
"5.7"])
