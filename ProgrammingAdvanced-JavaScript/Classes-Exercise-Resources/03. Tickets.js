function SortTickets(data,criteria) {
    class Ticket {
        constructor(destination,price,status) {
            this.destination = destination;
            this.price = Number(price);
            this.status = status;
        }
    }

    let tickets = [];
    data.map(x => {
        let[destination,price,status] = x.split('|');
        let currTicket = new Ticket(destination,price,status);
        tickets.push(currTicket);
    });

    console.log(tickets.sort((a,b) => {
        if (typeof a[criteria] === 'number') {
            return a[criteria] - b[criteria];
        }
        else {
            return ((a[criteria] < b[criteria]) ? -1 : ((a[criteria] > b[criteria]) ? 1 : 0));
        }
    }));	

    return tickets;
}