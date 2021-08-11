function solve() {
   let create = document.querySelector('.site-content aside button.btn.create');
   const creator = document.getElementById('creator')
   const title = document.getElementById('title')
   const category = document.getElementById('category')
   const content = document.getElementById('content');

   create.addEventListener('click',createArticleHeandler)
   function createArticleHeandler(e) {
      e.preventDefault()
      console.log('Hello');

      let creatorInput = creator.value;
      let titleInput = title.value;
      let categoryInput = category.value;
      let contentInput = content.value;

      creator.value = '';
      title.value = '';
      category.value = '';
      content.value = '';

      let articleElement = document.createElement('article');
      let titleHeading = document.createElement('h1');
      titleHeading.textContent = titleInput;

      let catagoryParagraph = document.createElement('p');
      catagoryParagraph.textContent = 'Category:';
      let catagoryStrong = document.createElement('strong');
      catagoryStrong.textContent = categoryInput;
      catagoryParagraph.appendChild(catagoryStrong);

      let creatorParagraph = document.createElement('p');
      creatorParagraph.textContent = 'Creator:';
      let creatorStrong = document.createElement('strong');
      creatorStrong.textContent = creatorInput;
      creatorParagraph.appendChild(creatorStrong);

      let contentParagraph = document.createElement('p');
      contentParagraph.textContent = contentInput;

      let divBtns = document.createElement('div');
      divBtns.classList.add('buttons');

      let archiveBtn = el('button', 'Archive', 'btn archive');
      archiveBtn.addEventListener('click', archive);
      let deleteBtn = el('button', 'Delete', 'btn delete');
      deleteBtn.addEventListener('click', deleteArticleHandler);

      divBtns.appendChild(deleteBtn);
      divBtns.appendChild(archiveBtn);

      articleElement.appendChild(titleHeading);
      articleElement.appendChild(catagoryParagraph);
      articleElement.appendChild(creatorParagraph);
      articleElement.appendChild(contentParagraph);
      articleElement.appendChild(divBtns);

      let postSection = document.querySelector('.site-content main section');
      postSection.appendChild(articleElement);
   }
   function deleteArticleHandler(e) {
      let deleteButton = e.target;
      let articleToDelete = deleteButton.parentElement.parentElement;
      articleToDelete.remove();
   }
   function archive(e) {
      let articleToArchive = e.target.parentElement.parentElement;
      let archiveOl = document.querySelector('.archive-section ol');

      let archiveLis = Array.from(archiveOl.querySelectorAll('li'));

      let articleTitle = articleToArchive.querySelector('h1');
      let articleTitleHeading = articleTitle.textContent;

      let newTitleLi = document.createElement('li');
      newTitleLi.textContent = articleTitleHeading;
      articleToArchive.remove();
      
      archiveLis.push(newTitleLi);
      archiveLis.sort((a,b) => a.textContent.localeCompare(b.textContent)).forEach(li => archiveOl.appendChild(li));
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
