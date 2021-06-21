(function() {
    String.prototype.ensureStart = function(str) {
        if (!this.startsWith(str)) {
            return str.concat(this);
        } else {
            return this.toString();
        }
    }
    String.prototype.ensureEnd = function(str) {
        if (!this.endsWith(str)) {
            return this.concat(str)
        } else {
            return this.toString();
        }
    }
    String.prototype.isEmpty = function() {
        return this.length == 0 ? true : false;
    }
    String.prototype.truncate = function (n) {
        if (n < 3) {
            return '.'.repeat(n);
        }
        if (this.toString().length <= n) {
            return this.toString();
        } else {
            let lastIndex = this.toString().substr(0, n - 2).lastIndexOf(" ");
            if(lastIndex != -1){
                return this.toString().substr(0, lastIndex) + "...";
            } else {
                return this.toString().substr(0, n-3) + "...";
            }
        }
    }
    String.format = function(str, ...params) {
        params.forEach((key, index) => {
            str = str.replace(`{${index}}`, key);
        });
        return str;
    };
}())