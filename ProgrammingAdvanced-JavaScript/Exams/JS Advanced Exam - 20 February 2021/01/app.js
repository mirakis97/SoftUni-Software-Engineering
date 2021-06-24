function solve(){
   let createButton = document.querySelector('.site-content aside button.btn.create');

   createButton.addEventListener('click', createArticleHeandler);

   function createArticleHeandler(e) {
      e.preventDefault();

      let authorInput = document.querySelector('#creator');
      let titleInput = document.querySelector('#title');
      let categoryInput = document.querySelector('#category');
      let contentTextarea = document.querySelector('#content');

      let aritcleElement = document.createElement('article');
      let titleHeading = document.createElement('h1');

      titleHeading.textContent = titleInput.value;

      let categoryParagraph = document.createElement('p');
      categoryParagraph.textContent = 'Category:';
      let categoryStrong = document.createElement('strong');
      categoryStrong.textContent = categoryInput.value;
      categoryParagraph.appendChild(categoryStrong);

      let creatorParagraph = document.createElement('p');
      creatorParagraph.textContent = 'Creator';
      let creatorStrong = document.createElement('strong');
      creatorStrong.textContent = authorInput.value;
      creatorParagraph.appendChild(creatorStrong);

      let contentParagraph = document.createElement('p');
      contentParagraph.textContent = contentTextarea.value;

      let buttonDiv =document.createElement('button');
      buttonDiv.classList.add('buttons');

      let deleteButton = document.createElement('button');
      deleteButton.textContent = 'Delete';
      deleteButton.classList.add('btn','delete');
      deleteButton.addEventListener('click',deleteArticleHandler)

      let archiveButton = document.createElement('button');
      archiveButton.textContent = 'Archive';
      archiveButton.classList.add('btn' ,'archive')
      archiveButton.addEventListener('click',archiveArticleHandler)


      buttonDiv.appendChild(deleteButton);
      buttonDiv.appendChild(archiveButton);

      aritcleElement.appendChild(titleHeading);
      aritcleElement.appendChild(categoryParagraph);
      aritcleElement.appendChild(creatorParagraph);
      aritcleElement.appendChild(contentParagraph);
      aritcleElement.appendChild(buttonDiv);

      let postSection = document.querySelector('.site-content main section');
      postSection.appendChild(aritcleElement);
   }

   function deleteArticleHandler(e) {
      let deleteButton = e.target;
      let articleToDelete = deleteButton.parentElement.parentElement;
      articleToDelete.remove();
   }

   function archiveArticleHandler(e) {
      let articleToArchive = e.target.parentElement.parentElement;
      let archiveOl = document.querySelector('.archive-section ol');

      let archiveLis = Array.from(archiveOl.querySelectorAll('li'));

      let aricleTitle = articleToArchive.querySelector('h1');
      let articleTitleHeading = aricleTitle.textContent;

      let newTitleLi = document.createElement('li');
      newTitleLi.textContent = articleTitleHeading;
      articleToArchive.remove();

      archiveLis.push(newTitleLi);
      archiveLis.sort((a,b) => a.textContent.localeCompare(b.textContent))
      .forEach(li => archiveOl.appendChild(li));
   }
  }
