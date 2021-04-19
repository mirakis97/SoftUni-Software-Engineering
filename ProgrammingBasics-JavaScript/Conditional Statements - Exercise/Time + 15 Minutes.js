function timePlus15 (Input){
    var hours = Number(Input[0])
    var minutes = Number(Input[1])

    minutes += 15;
            if (minutes >= 60)
            {
                minutes -= 60;
                hours += 1;
            }
            if (hours >= 24)
            {
                hours = 0;
            }
            if (minutes < 10) 
            {
             console.log(`${hours}:0${minutes}`);
            }
            else
            {
              console.log(`${hours}:${minutes}`);
            }
}
timePlus15 (["1", "46"]);