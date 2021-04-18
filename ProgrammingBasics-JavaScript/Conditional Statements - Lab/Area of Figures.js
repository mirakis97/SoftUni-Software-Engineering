function areaOFFigures(input){

    var figuers = String(input[0]);

    if (figuers == "square") {

     var num = Number(input[1]);
     var squareArea = num * num;

     console.log(squareArea.toFixed(3));
    }
    else if ( figuers == "rectangle"){
     var num2 = Number(input[1]);
     var num3 = Number(input[2]);
     var rectangleArea = num2 * num3;

     console.log(rectangleArea.toFixed(3));
    }
     else if (figuers == "circle"){
     var num4 = Number(input[1]);
     var circleArea = Math.PI * (num4 * num4)
     console.log(circleArea.toFixed(3));
    }   
    else if (figuers == "triangle"){
        var num5 = Number(input[1]);
        var num6 = Number(input[2]);
        var triangleArea = (num5 * num6)  / 2;
        console.log(triangleArea.toFixed(3));
    }
}

areaOFFigures (["triangle",
"4.5",
"20"]);
