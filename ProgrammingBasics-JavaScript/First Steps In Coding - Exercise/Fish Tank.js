function aquarium(input) {
    var length = Number(input[0]);
    var width = Number(input[1]);
    var hight = Number(input[2]);
    var percent = Number(input[3]);
     

    var aquariumTotal = length * width * hight;
    var litersInAquarium = aquariumTotal * 0.001 ;
    var percents = percent * 0.01 ;
    var totalLiters = litersInAquarium *( 1 -percents) ;
    console.log(totalLiters)
}

aquarium(["85",
"75",
"47",
"17"])
