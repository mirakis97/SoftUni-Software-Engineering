let { assert , expect} = require('chai');
const cinema = {
    showMovies: function (movieArr) {

        if (movieArr.length == 0) {
            return 'There are currently no movies to show.';
        } else {
            let result = movieArr.join(', ');
            return result;
        }

    },
    ticketPrice: function (projectionType) {

        const schedule = {
            "Premiere": 12.00,
            "Normal": 7.50,
            "Discount": 5.50
        }
        if (schedule.hasOwnProperty(projectionType)) {
            let price = schedule[projectionType];
            return price;
        } else {
            throw new Error('Invalid projection type.')
        }

    },
    swapSeatsInHall: function (firstPlace, secondPlace) {
        if (!Number.isInteger(firstPlace) || firstPlace <= 0 || firstPlace > 20 ||
            !Number.isInteger(secondPlace) || secondPlace <= 0 || secondPlace > 20 ||
            firstPlace === secondPlace) {
            return "Unsuccessful change of seats in the hall.";
        } else {
            return "Successful change of seats in the hall.";
        }

    }
};

describe("Tests …", function() {
    it("showMovies work corect …", function () {
        let movies = ['Kiko','Kiro']
        expect(function() {cinema.showMovies()}).to.throw();
        expect(cinema.showMovies(movies)).to.equal('Kiko, Kiro');

    });
    it("showMovies should throw corect …", function () {
        let movies = []

        expect(function() {cinema.showMovies()}).to.throw();
        expect(cinema.showMovies(movies)).to.equal('There are currently no movies to show.');

    });
    it("ticketPrice work corect …", function () {
        expect(cinema.ticketPrice('Premiere')).to.equal(12.00);
        expect(cinema.ticketPrice('Normal')).to.equal(7.50);
        expect(cinema.ticketPrice('Discount')).to.equal(5.50);

    });
    it("ticketPrice should throw corect …", function () {
        expect(function() {cinema.ticketPrice('Luxury')}).to.throw();
    });
    
    it("swapSeatsInHall work corect …", function () {
        expect(cinema.swapSeatsInHall(2,5)).to.equal('Successful change of seats in the hall.');
        expect(cinema.swapSeatsInHall(19,20)).to.equal('Successful change of seats in the hall.');
    });
    it("swapSeatsInHall should throw corect …", function () {
        expect(cinema.swapSeatsInHall(0,20)).to.equal('Unsuccessful change of seats in the hall.');
        expect(cinema.swapSeatsInHall(10,0)).to.equal('Unsuccessful change of seats in the hall.');
        expect(cinema.swapSeatsInHall(-2,20)).to.equal('Unsuccessful change of seats in the hall.');
        expect(cinema.swapSeatsInHall(2,-5)).to.equal('Unsuccessful change of seats in the hall.');
        expect(cinema.swapSeatsInHall(25,20)).to.equal('Unsuccessful change of seats in the hall.');
        expect(cinema.swapSeatsInHall(2,21)).to.equal('Unsuccessful change of seats in the hall.');
        expect(cinema.swapSeatsInHall('a',19)).to.equal('Unsuccessful change of seats in the hall.');
        expect(cinema.swapSeatsInHall(5,'v')).to.equal('Unsuccessful change of seats in the hall.');
    });
});

