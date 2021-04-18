function guessThePassword(input){

    var num = String(input[0]);

    if (num == "s3cr3t!P@ssw0rd" ) {
        console.log("Welcome")
    }
    else {
        console.log("Wrong password!")
    }   
}

guessThePassword (["s3cr3t!P@ssw0rd"]);