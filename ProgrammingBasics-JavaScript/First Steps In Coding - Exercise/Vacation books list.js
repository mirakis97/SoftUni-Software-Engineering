function pagesToRead(input) {
    let bookPages = Number(input[0])
    let pagesThatWeCanReadForOneHour = Number(input[1])
    let daysForWeNeedToReadTheBook = Number(input[2])
    
    let timeForReadTheWholeBook = bookPages / pagesThatWeCanReadForOneHour
    let timeForTheDay = timeForReadTheWholeBook / daysForWeNeedToReadTheBook
    console.log(timeForTheDay)
}

pagesToRead(["212",
"20",
"2"]
)