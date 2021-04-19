function sumSeconds (input){
    var timeFirst = Number(input[0]);
    var timeSecond = Number(input[1]);
    var timeThird = Number(input[2]);
  

    var totalTime = timeFirst + timeSecond + timeThird;
    var minutes = Math.floor(totalTime / 60);
    var seconds = totalTime % 60;

       
            if (seconds < 10)
            {
                console.log(`${minutes}:0${seconds}`);
            }
            else 
            {
                console.log(`${minutes}:${seconds}`);
            }
}

sumSeconds (["35",
"45",
"44"])
;