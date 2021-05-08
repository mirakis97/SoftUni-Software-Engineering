function onTimeForTheExam (input) {
            var hourExamStart = Number(input[0]);
            var minutesOfExamStart = Number(input[1]);
            var hourOfComing = Number(input[2]);
            var minutesOfComing = Number(input[3]);
            var difference = 0;
            var hour = 0;
            var minutes = 0;

            minutesOfExamStart += hourExamStart * 60;
            minutesOfComing += hourOfComing * 60;

            if (minutesOfComing > minutesOfExamStart)
            {
                console.log("Late");
                difference = minutesOfComing - minutesOfExamStart;
                if (difference < 60)
                {
                    console.log(`${difference} minutes after the start`);
                }
                else
                {
                    hour = difference / 60;
                    minutes = difference % 60;
                    console.log(`${hour}:${minutes} hours after the start`);
                }
            }
            else if (minutesOfComing < minutesOfExamStart - 30)
            {
                console.log("Early");
                difference = minutesOfExamStart - minutesOfComing;
                if (difference < 60)
                {
                    console.log(`${difference} minutes before the start`);
                }
                else
                {
                    hour = difference / 60;
                    minutes = difference % 60;
                    console.log(`${hour}:${minutes} hours before the start`);
                }
            }
            else
            {
                console.log("On Time");
                difference = minutesOfExamStart - minutesOfComing;
                console.log(`${difference} minutes before the start`);
            }
}
