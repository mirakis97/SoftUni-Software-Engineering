function validate() {
    const email = document.querySelector('#email');
    email.addEventListener('change', (event) => {

        let input = event.target.value;
        let regex = /^[a-z]+@[a-z]+.[a-z]+$/;
        let isValid = regex.test(input);

        if (!isValid) {
            event.target.classList.add('error');
        }
        else {
            event.target.classList.remove('error');
        }
    })
}