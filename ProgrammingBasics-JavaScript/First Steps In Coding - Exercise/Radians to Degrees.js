function radiansToDegrees(input) {
    let radians = Number(input.shift())
    let degrees = (radians*180)/Math.PI
    
    console.log(Math.round(degrees))
 
}

radiansToDegrees([3.1416])