function solve(num,name) {
    const cityLimit = 50;
    const interstateLimit = 90;
    const motorway = 130;
    const residential = 20;
    let status = "";
    if (name == "city") {
        if (num > cityLimit) {
            let difference = num - cityLimit;
            if (difference <= 20) {
                status = "speeding";
            console.log(`The speed is ${difference} km/h faster than the allowed speed of ${cityLimit} - ${status}`);
            }
            else if (difference <= 40) {
                status = "excessive speeding";
            console.log(`The speed is ${difference} km/h faster than the allowed speed of ${cityLimit} - ${status}`);
                
            }
            else{
                status = "reckless driving";
            console.log(`The speed is ${difference} km/h faster than the allowed speed of ${cityLimit} - ${status}`);

            }
        }
        else {
        console.log(`Driving ${num} km/h in a ${cityLimit} zone`);

        }
    }
    else if (name == "residential") {
        if (num > residential) {
            let difference = num - residential;
            if (difference <= 20) {
                status = "speeding";
            console.log(`The speed is ${difference} km/h faster than the allowed speed of ${residential} - ${status}`);
            }
            else if (difference <= 40) {
                status = "excessive speeding";
            console.log(`The speed is ${difference} km/h faster than the allowed speed of ${residential} - ${status}`);
                
            }
            else{
                status = "reckless driving";
            console.log(`The speed is ${difference} km/h faster than the allowed speed of ${residential} - ${status}`);

            }
        }
        else {
        console.log(`Driving ${num} km/h in a ${residential} zone`);

        }
    }
    else if (name == "interstate") {
        if (num > interstateLimit) {
            let difference = num - interstateLimit;
            if (difference <= 20) {
                status = "speeding";
            console.log(`The speed is ${difference} km/h faster than the allowed speed of ${interstateLimit} - ${status}`);
            }
            else if (difference <= 40) {
                status = "excessive speeding";
            console.log(`The speed is ${difference} km/h faster than the allowed speed of ${interstateLimit} - ${status}`);
                
            }
            else{
                status = "reckless driving";
            console.log(`The speed is ${difference} km/h faster than the allowed speed of ${interstateLimit} - ${status}`);

            }
        }
        else{
        console.log(`Driving ${num} km/h in a ${interstateLimit} zone`);

        }
    }
    else if (name == "motorway") {
        if (num > motorway) {
            let difference = num - motorway;
            if (difference <= 20) {
                status = "speeding";
            console.log(`The speed is ${difference} km/h faster than the allowed speed of ${motorway} - ${status}`);
            }
            else if (difference <= 40) {
                status = "excessive speeding";
            console.log(`The speed is ${difference} km/h faster than the allowed speed of ${motorway} - ${status}`);
                
            }
            else{
                status = "reckless driving";
            console.log(`The speed is ${difference} km/h faster than the allowed speed of ${motorway} - ${status}`);

            }
        }
        else{
        console.log(`Driving ${num} km/h in a ${motorway} zone`);

        }
    }
}

solve(200, 'motorway');