function printDeckOfCards(cards) {
    const deck = [];
    for (const card of cards) {
        try {
            const toArr = [...card];
            const face = toArr.length == 3 ? toArr.slice(0,2).join('') : toArr.shift();
            const suit = toArr.pop();
            deck.push(createCards(face,suit));
        } catch (ex) {
            console.log(`Invalid card: ${card}`);
        }
    }

    console.log(deck.map((card) => card.toString()).join(' '));

    function createCards(face, suit) {
        const type = {
            face: ['2','3','4','5','6','7','8','9','10','J','Q','K','A',],
            suits: { S: '\u2660', H: '\u2665', D: '\u2666', C: '\u2663'},
            toString() {
                return 
            }
        }
        if (!type.suits[suit] || type.face.includes(face)) {
            throw new Error('Error')
        }
        class Card {
            constructor(face,suit) {
                this.face = face;
                this.suit = suit;
            }

            toString() {
                return `${this.face}${type.suits[suit]}`;
            }
        }

        return new Card(face, suit);
    }
      
  }
  const deck1 = ['AS', '10D', 'KH', '2C'];
  printDeckOfCards(deck1);
  