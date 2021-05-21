function solve(x1, y1, x2, y2) {

    function getDistance(x1, y1, x2, y2) {
        let distX = x1 - x2;
        let distY = y1 - y2;

        return Math.sqrt(distX ** 2 + distY ** 2);
    }

    let status1 = 'valid';
    if (!Number.isInteger(getDistance(x1, y1, 0, 0))) {
        status1 = 'invalid';
    }

    console.log(`{${x1}, ${y1}} to {0, 0} is ${status1}`);



    let status2 = 'valid';
    if (!Number.isInteger(getDistance(x2, y2, 0, 0))) {
        status2 = 'invalid';
    }
    console.log(`{${x2}, ${y2}} to {0, 0} is ${status2}`);


    let status3 = 'valid';
    if (!Number.isInteger(getDistance(x1, y1, x2, y2))) {
        status3 = 'invalid';
    } 
        console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is ${status3}`);
    

}