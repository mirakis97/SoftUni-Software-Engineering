function sumTable() {
    let cost = Array.from(document.querySelectorAll('td:nth-child(2)'));
    let costTdElements = cost.pop();
    let sum = cost.reduce((a ,x) => a + Number(x.textContent), 0)

    costTdElements.textContent = sum;
}