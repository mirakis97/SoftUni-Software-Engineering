function solve() {
    let addBtn = document.getElementById('add');
    const task = document.getElementById('task')
    const description = document.getElementById('description')
    const date = document.getElementById('date')
    const section = document.querySelectorAll('section div');

    let openDiv = section[3];
    let inProgress = section[5];
    let finished = section[7];

    addBtn.addEventListener('click', (e) => {
        e.preventDefault();
        console.log(section, openDiv, inProgress, finished)
        if (!task.value || !description.value || !date.value) {
            return;
        }

        let taskInput = task.value;
        let descriptionInput = description.value;
        let dateInput = date.value;

        task.value = '';
        description.value = '';
        date.value = '';

        let startBtn = el('button', 'Start', 'green');
        startBtn.addEventListener('click', () => start(taskInput,descriptionInput,dateInput,article));
        let deleteBtn = el('button', 'Delete', 'red');
        deleteBtn.addEventListener('click', () => del(article));

        let div = el('div', '', 'flex');
        div.appendChild(startBtn);
        div.appendChild(deleteBtn);

        let h3 = el('h3', taskInput);
        let p1 = el('p', `Description: ${descriptionInput}`);
        let p2 = el('p', `Due Date: ${dateInput}`);
        let article = el('article', '');

        article.appendChild(h3);
        article.appendChild(p1);
        article.appendChild(p2);
        article.appendChild(div);

        openDiv.appendChild(article);

    })
    function start(taskInput, descriptionInput, dateInput, article) {
        article.remove();
    
        let newDeleteBtn = el('button', 'Delete', 'red');
        newDeleteBtn.addEventListener('click',() => del(newArticle));
        let finishBtn = el('button', 'Finish', 'orange');
        finishBtn.addEventListener('click', () => complete(taskInput, descriptionInput, dateInput, newArticle));
    
        let div = el('div', '', 'flex');
        div.appendChild(newDeleteBtn);
        div.appendChild(finishBtn);
    
        let h3 = el('h3', taskInput);
        let p1 = el('p', `Description: ${descriptionInput}`);
        let p2 = el('p', `Due Date: ${dateInput}`);
        let newArticle = el('article', '');
    
        newArticle.appendChild(h3);
        newArticle.appendChild(p1);
        newArticle.appendChild(p2);
        newArticle.appendChild(div);
    
        inProgress.appendChild(newArticle);
    }
    function complete(taskInput, descriptionInput, dateInput, newArticle) {
        newArticle.remove();
    
        let h3 = el('h3', taskInput);
        let p1 = el('p', `Description: ${descriptionInput}`);
        let p2 = el('p', `Due Date: ${dateInput}`);
        let finshedArticle = el('article', '');
    
        finshedArticle.appendChild(h3);
        finshedArticle.appendChild(p1);
        finshedArticle.appendChild(p2);
    
        finished.appendChild(finshedArticle);
    }
    function del(article) {
        article.remove();
    }
    
    function el(type, content, addClass) {
        const result = document.createElement(type);
        result.textContent = content;;
    
        if (addClass) {
            result.className = addClass;
        }
    
        return result;
    }
}
