function toggle() {
    let button = document.getElementsByClassName('button')[0].textContent;

    if (button === "More") {
        document.getElementsByClassName('button')[0].textContent = 'Less';
        document.getElementById('extra').style.display = 'block';
    }
    else if (button === "Less") {
        document.getElementsByClassName('button')[0].textContent = 'More';
        document.getElementById('extra').style.display = 'none';
    }
}