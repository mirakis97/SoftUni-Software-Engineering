class List {

    constructor() {
        this.numbers = [];
        this.size = this.numbers.length;
    }
    add(element) {
        if (isNaN(element)) {
            throw new Error('Element to add must be a number');
        }

        this.numbers.push(Number(element));
        this.numbers.sort((a,b) => a - b);
        this.size++;

        return this;
    }

    remove(index) {
        if (index >= 0 && index < this.numbers.length) {
            this.numbers.splice(index,1);
            this.size--;
            this.numbers.sort((a,b) => a - b);
        }
        else {
            throw new Error('Invalid index');
        }
        return this;
    }

    get(index) {
        if (index >= 0 && index < this.numbers.length) {
            return this.numbers[index];
        }
        else {
            throw new Error('Invalid index');
        }
    }
}