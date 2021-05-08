function workingHours (input) {
    var hour = Number(input[0]);
    var dayOfWeek = String(input[1]);

    if (hour >=10 && hour <=18 )
    {
        if (dayOfWeek == "Monday" || dayOfWeek == "Tuesday" || 
            dayOfWeek == "Wednesday" || dayOfWeek == "Thursday" ||
            dayOfWeek == "Friday" || dayOfWeek == "Saturday")
        {
            console.log("open");
        }

        else
        {
            console.log("closed");
        }
    }
    else
    {
        console.log("closed");
    }
}