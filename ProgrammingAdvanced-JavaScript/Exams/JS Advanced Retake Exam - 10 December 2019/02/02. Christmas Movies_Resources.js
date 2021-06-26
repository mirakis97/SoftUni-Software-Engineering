let { assert , expect} = require('chai');

class ChristmasMovies {
    constructor() {
        this.movieCollection = [];
        this.watched = {};
        this.actors = [];
    }

    buyMovie(movieName, actors) {
        let movie = this.movieCollection.find(m => movieName === m.name);
        let uniqueActors = new Set(actors);

        if (movie === undefined) {
            this.movieCollection.push({ name: movieName, actors: [...uniqueActors] });
            let output = [];
            [...uniqueActors].map(actor => output.push(actor));
            return `You just got ${movieName} to your collection in which ${output.join(', ')} are taking part!`;
        } else {
            throw new Error(`You already own ${movieName} in your collection!`);
        }
    }

    discardMovie(movieName) {
        let filtered = this.movieCollection.filter(x => x.name === movieName)

        if (filtered.length === 0) {
            throw new Error(`${movieName} is not at your collection!`);
        }
        let index = this.movieCollection.findIndex(m => m.name === movieName);
        this.movieCollection.splice(index, 1);
        let { name, _ } = filtered[0];
        if (this.watched.hasOwnProperty(name)) {
            delete this.watched[name];
            return `You just threw away ${name}!`;
        } else {
            throw new Error(`${movieName} is not watched!`);
        }

    }

    watchMovie(movieName) {
        let movie = this.movieCollection.find(m => movieName === m.name);
        if (movie) {
            if (!this.watched.hasOwnProperty(movie.name)) {
                this.watched[movie.name] = 1;
            } else {
                this.watched[movie.name]++;
            }
        } else {
            throw new Error('No such movie in your collection!');
        }
    }

    favouriteMovie() {
        let favourite = Object.entries(this.watched).sort((a, b) => b[1] - a[1]);
        if (favourite.length > 0) {
            return `Your favourite movie is ${favourite[0][0]} and you have watched it ${favourite[0][1]} times!`;
        } else {
            throw new Error('You have not watched a movie yet this year!');
        }
    }

    mostStarredActor() {
        let mostStarred = {};
        if (this.movieCollection.length > 0) {
            this.movieCollection.forEach(el => {
                let { _, actors } = el;
                actors.forEach(actor => {
                    if (mostStarred.hasOwnProperty(actor)) {
                        mostStarred[actor]++;
                    } else {
                        mostStarred[actor] = 1;
                    }
                })
            });
            let theActor = Object.entries(mostStarred).sort((a, b) => b[1] - a[1]);
            return `The most starred actor is ${theActor[0][0]} and starred in ${theActor[0][1]} movies!`;
        } else {
            throw new Error('You have not watched a movie yet this year!')
        }
    }
}

let christmas = new ChristmasMovies();
christmas.buyMovie('Home Alone', ['Macaulay Culkin', 'Joe Pesci', 'Daniel Stern']);
christmas.buyMovie('Home Alone 2', ['Macaulay Culkin']);
christmas.buyMovie('Last Christmas', ['Emilia Clarke', 'Henry Golding']);
christmas.buyMovie('The Grinch', ['Benedict Cumberbatch', 'Pharrell Williams']);
christmas.watchMovie('Home Alone');
christmas.watchMovie('Home Alone');
christmas.watchMovie('Home Alone');
christmas.watchMovie('Home Alone 2');
christmas.watchMovie('The Grinch');
christmas.watchMovie('Last Christmas');
christmas.watchMovie('Home Alone 2');
christmas.watchMovie('Last Christmas');
christmas.discardMovie('The Grinch');
christmas.favouriteMovie();
christmas.mostStarredActor();

describe("Tests …", () => {
    let christmas = []

    beforeEach(function() {
        christmas = new ChristmasMovies();
    });


    it('tests add corectly ', () => {
        assert.equal(christmas.buyMovie("2Fast 2Furious", ["Vin Diesel","Paul Walker"]),"You just got 2Fast 2Furious to your collection in which Vin Diesel, Paul Walker are taking part!");

    });

    it('tests add corectly with one actor ', () => {
        assert.equal(christmas.buyMovie("2Fast 2Furious", ["Paul Walker","Paul Walker"]),"You just got 2Fast 2Furious to your collection in which Paul Walker are taking part!");

    });
    
    it('tests add throw error ', () => {
        christmas.buyMovie("2Fast 2Furious", ["Vin Diesel","Paul Walker"]);
        assert.throw( () => christmas.buyMovie("2Fast 2Furious", ["Vin Diesel","Paul Walker"]),"You already own 2Fast 2Furious in your collection!");

    });
    it('tests discardMovie throw error ', () => {
        assert.throw( () => christmas.discardMovie("Paul Walker"),"Paul Walker is not at your collection!");

    });

    it('tests discardMovie should delete move ', () => {
        christmas.buyMovie("2Fast 2Furious", ["Vin Diesel","Paul Walker"]);
        christmas.watchMovie("2Fast 2Furious");
        assert.equal(christmas.discardMovie("2Fast 2Furious"),"You just threw away 2Fast 2Furious!");

    });

    it('tests discardMovie throw error ', () => {
        christmas.buyMovie("2Fast 2Furious", ["Vin Diesel","Paul Walker"])
        assert.throw( () => christmas.discardMovie("2Fast 2Furious"),"2Fast 2Furious is not watched!");

    });

    it('favouriteMovie should throw Error', () => {
        assert.throws(() => christmas.favouriteMovie(), 'You have not watched a movie yet this year!');
    })
    
    it('tests watchMovie should throw error ', () => {
        assert.throw( () => christmas.watchMovie("2Fast 2Furious"),"No such movie in your collection!");
    });

    it('tests watchMovie should incrase value ', () => {
        christmas.buyMovie("2Fast 2Furious", ["Vin Diesel","Paul Walker"])
        christmas.watchMovie("2Fast 2Furious");
        christmas.watchMovie("2Fast 2Furious");
        christmas.watchMovie("2Fast 2Furious");
        assert.equal(christmas.watched["2Fast 2Furious"],3);
    });


    it('tests favouriteMovie should throw error ', () => {
        assert.throw( () => christmas.favouriteMovie(),"You have not watched a movie yet this year!");
    });

    it('tests favouriteMovie should work ', () => {
        christmas.buyMovie("2Fast 2Furious", ["Vin Diesel","Paul Walker"])
        christmas.watchMovie("2Fast 2Furious");

        assert.equal(christmas.favouriteMovie(),"Your favourite movie is 2Fast 2Furious and you have watched it 1 times!");
    });
    it('tests mostStarredActor throw error ', () => {
        assert.throw( () => christmas.mostStarredActor(),"You have not watched a movie yet this year!");
    });

    it('tests favouriteMovie should work ', () => {
        christmas.buyMovie("2Fast 2Furious", ["Paul Walker"])
        christmas.watchMovie("2Fast 2Furious");

        assert.equal(christmas.mostStarredActor(),"The most starred actor is Paul Walker and starred in 1 movies!");
    });

    it('mostStarredActor should return actor', () => {
        christmas.buyMovie('Home Alone', ['Macaulay Culkin', 'Joe Pesci', 'Daniel Stern']);
        christmas.buyMovie('Harry Potter', ['Rupert Grint', 'Macaulay Culkin']);
        christmas.watchMovie('Home Alone');
        assert.equal(christmas.mostStarredActor(), 'The most starred actor is Macaulay Culkin and starred in 2 movies!')
    });
    
});
