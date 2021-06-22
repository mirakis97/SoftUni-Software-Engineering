function solve() {
    let addButton = document.getElementById('add');
    const task = document.getElementById('task');
    const description = document.getElementById('description');
    const dueDate = document.getElementById('date');
    const section = document.querySelectorAll('section div');

    const openDiv = section[3];
    const inProgress = section[5];
    const finished = section[7];

    addButton.addEventListener('click',(e) => {
        e.preventDefault();
        console.log(section,openDiv,inProgress,finished);
        if (task.value == '' || description.value == '' || dueDate.value == ''){
            return;
        }
        let taskInput = task.value;
        let descriptionInput = description.value;
        let dueDateInput = dueDate.value;

        task.value = '';
        description.value = '';
        dueDate.value = '';

        let strtBtn = el('button','Start','green');
        strtBtn.addEventListener('click', () => start(taskInput,descriptionInput,dueDateInput,article));
        let deleteBtn = el('button','Delete','red');
        deleteBtn.addEventListener('click',() => del(article));
        let div = el('div','','flex');
        div.appendChild(strtBtn);
        div.appendChild(deleteBtn);

        let h3 = el('h3',taskInput);
        let p = el('p',`Description: ${descriptionInput}`);
        let p2 = el('p', `Due Date: ${dueDateInput}`);
        let article = el('article', '');

        article.appendChild(h3);
        article.appendChild(p);
        article.appendChild(p2);
        article.appendChild(div);

        openDiv.appendChild(article);
    });

    function start(taskInput,descriptionInput,dueDateInput,article) {
        article.remove();

        let newDeleteBtn = el('button','Delete','red');;
        newDeleteBtn.addEventListener('click',() => del(newArticle));
        let finishButton = el('button','Finish','orange');
        finishButton.addEventListener('click', () => complete(taskInput , descriptionInput,dueDateInput,newArticle));
        let div = el('div','','flex');

        div.appendChild(newDeleteBtn);
        div.appendChild(finishButton);

        let h3 = el('h3',taskInput);
        let p = el('p',`Description: ${descriptionInput}`);
        let p2 = el('p', `Due Date: ${dueDateInput}`);
        let newArticle = el('article', '');

        newArticle.appendChild(h3);
        newArticle.appendChild(p);
        newArticle.appendChild(p2);
        newArticle.appendChild(div);

        inProgress.appendChild(newArticle);
    }

    function complete(taskInput,descriptionInput,dueDateInput,newArticle) {
        newArticle.remove();

        let h3 = el('h3',taskInput);
        let p = el('p',`Description: ${descriptionInput}`);
        let p2 = el('p', `Due Date: ${dueDateInput}`);
        let finishedArticle = el('article', '');

        finishedArticle.appendChild(h3);
        finishedArticle.appendChild(p);
        finishedArticle.appendChild(p2);

        finished.appendChild(finishedArticle);
    }

    function del(article) {
        article.remove();
    }

    function el(type,content,addClass) {
        const result = document.createElement(type);
        result.textContent = content;;

        if (addClass) {
            result.className = addClass;
        }

        return result;
    }
}