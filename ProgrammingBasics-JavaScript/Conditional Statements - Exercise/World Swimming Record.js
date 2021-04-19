function swimmingRecord(Input)
{
    //Input
    var recordInSeconds = Number(Input[0]);
    var distanceInMeters = Number(Input[1]);
    var timeInSeconds = Number(Input[2]);
    //Caluculations
    var timeForSwim = distanceInMeters * timeInSeconds;
    var resistance = Math.floor(distanceInMeters / 15) * 12.5;
    var finalTime = timeForSwim + resistance;
    
    if (finalTime < recordInSeconds)
    {
        console.log(`Yes, he succeeded! The new world record is ${finalTime.toFixed(2)} seconds.`);
    }
    else
    {
        var timeHeNeed = finalTime - recordInSeconds;
        console.log(`No, he failed! He was ${timeHeNeed.toFixed(2)} seconds slower.`);
    }
}

swimmingRecord (["10464",
"1500",
"20"])
;