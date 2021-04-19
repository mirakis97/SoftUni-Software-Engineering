function metricConverter(input)
{
    
            //Input
            var number = Number(input[0]);
            var inputUnit = String(input[1]);
            var outputUnit = String(input[2]);
            //Calculations
            if (inputUnit == "mm" && outputUnit == "m")
            {
                number /= 1000;
            }
            else if (inputUnit == "m" && outputUnit == "cm")
            {
                number *= 100;
            }
            else if (inputUnit == "mm" && outputUnit == "cm")
            {
                number /= 10;
            }
            else if (inputUnit == "cm" && outputUnit == "mm")
            {
                number *= 10;
            }
            else if (inputUnit == "cm"&& outputUnit == "m")
            {
                number /= 100;
            }
            else if (inputUnit == "m" && outputUnit == "mm")
            {
                number *= 1000;
            }
            //Output
            console.log(number.toFixed(3))
}
metricConverter (["12","mm","m"]);