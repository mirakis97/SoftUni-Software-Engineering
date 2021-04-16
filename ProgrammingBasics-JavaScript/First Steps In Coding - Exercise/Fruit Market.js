function charity(input) {
    var priceForStrawberrys = Number(input[0]);
    var bannanas = Number(input[1]);
    var oranges = Number(input[2]);
    var raspberrys = Number(input[3]);
    var strawberrys = Number(input[4]);
    
    var priceForRaspberry = priceForStrawberrys / 2;
    var priceForOranges = priceForRaspberry - (priceForRaspberry * 0.40);
    var priceForBannanas = priceForRaspberry - (priceForRaspberry *0.80);
    var priceForTotalRaspberry = raspberrys * priceForRaspberry ;
    var priceForTotalOranges = oranges * priceForOranges;
    var priceForTotalBannanas = bannanas * priceForBannanas;
    var priceForTotalStrawberrys = strawberrys * priceForStrawberrys;
    var total = priceForTotalRaspberry + priceForTotalOranges + priceForTotalBannanas + priceForTotalStrawberrys;
    console.log(total)
}

charity(["48",
"10",
"3.3",
"6.5",
"1.7"])
