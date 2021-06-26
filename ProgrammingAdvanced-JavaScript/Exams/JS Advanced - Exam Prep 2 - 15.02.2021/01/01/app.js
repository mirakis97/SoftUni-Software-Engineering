function solution() {
    const addBtn = document.getElementsByTagName('button')[0];
    const input = document.getElementsByTagName('input')[0];
    const giftList = document.querySelector('div > section:nth-child(2) > ul');
    const sendGifts = document.querySelector('div > section:nth-child(3) > ul');
    const discardedGifts = document.querySelector('div > section:nth-child(4) > ul');

    addBtn.addEventListener('click', onClickAdd);

    function onClickAdd(event) {
        let newGift = document.createElement('li');
        newGift.classList.add('gift');
        newGift.textContent = input.value;

        let sendBtn = document.createElement('button');
        sendBtn.id = 'sendButton';
        sendBtn.textContent = 'Send';

        let discardBtn = document.createElement('button');
        discardBtn.id = 'discardButton';
        discardBtn.textContent = 'Discard';

        sendBtn.addEventListener('click', () => {

            let newSent = document.createElement('li');
            newSent.classList.add('gift');
            newSent.textContent = (newGift.textContent).replace('SendDiscard','');

            sendGifts.appendChild(newSent);

            newGift.remove();
        })

        discardBtn.addEventListener('click', () => {

            let newDiscarded = document.createElement('li');
            newDiscarded.classList.add('gift');
            newDiscarded.textContent = (newGift.textContent).replace('SendDiscard','');

            discardedGifts.appendChild(newDiscarded);
            newGift.remove();
        })

        newGift.appendChild(sendBtn);
        newGift.appendChild(discardBtn);

        giftList.appendChild(newGift);

        Array.from(giftList.getElementsByTagName('li'))
        .sort((a, b) => a.textContent.localeCompare(b.textContent))
        .forEach(li => giftList.appendChild(li));

        input.value = '';
    }


}