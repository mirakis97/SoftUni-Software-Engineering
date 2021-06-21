function solve() {
    const prototype = {};
    const instance = Object.create(prototype);

    instance.extend = function (obj) {
        Object.entries(obj).forEach(([key,value]) => {
            if (typeof value === 'function') {
                prototype[key] = value;
            }
            else {
                instance[key] = value;
            }
        });
    }

    return instance;
}