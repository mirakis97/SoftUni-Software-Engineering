class Request {
    constructor(method, uri, version, message){
        this.method = String(method);
        this.uri = String(uri);
        this.version = String(version);
        this.message = String(message);
        this.response = undefined;
        this.fulfilled = false;
    }

}
let myData = new Request('GET', 'http://google.com', 'HTTP/1.1', '')
console.log(myData);
