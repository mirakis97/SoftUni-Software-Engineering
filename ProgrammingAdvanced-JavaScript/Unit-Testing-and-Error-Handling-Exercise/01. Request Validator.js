function requestValdiation(httpObj) {
    validUrl(httpObj);
    validateVersion(httpObj);
    validateMethod(httpObj);
    validateMessage(httpObj);
    return httpObj;

    function validUrl(httpObj) {
        let propName = 'uri';
        let urlRegex =  /^[\w.]+$/;

        if (httpObj[propName] === undefined || !urlRegex.test(httpObj[propName])){
            throw new Error('Invalid request header: Invalid URI');
        } 
    }
    function validateVersion(httpObj) {
        let propName = 'version';
        let validVersion = ['HTTP/0.9', 'HTTP/1.0', 'HTTP/1.1','HTTP/2.0' ];
        if(httpObj[propName] === undefined || !validVersion.includes(httpObj[propName])){
            throw new Error('Invalid request header: Invalid Version');

        }
    }
    function validateMethod(httpObj) {
        let validMethods = ['GET','POST','DELETE','CONNECT'];
        let propName = 'method';

        if(httpObj[propName] === undefined || !validMethods.includes(httpObj[propName])){
            throw new Error('Invalid request header: Invalid Method');
        }
    }
    function validateMessage(httpObj) {
        let propName = 'message';
        let messageRegex = /^[^<>\\&'"]*$/;

        if (httpObj[propName] === undefined || !messageRegex.test(httpObj[propName])){
            throw new Error('Invalid request header: Invalid Message');
        } 
    }
}