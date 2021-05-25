function solve(pies,firstPie,lastPie) {
    let firstPieIndex = pies.indexOf(firstPie);
    let lastPieIndex = pies.indexOf(lastPie);

    let resultPies = pies.slice(firstPieIndex,lastPieIndex + 1);

    return resultPies;
}