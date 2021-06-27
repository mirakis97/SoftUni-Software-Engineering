window.addEventListener('load', solution);

function solution() {
  //1.Getting the user’s personal information
  let fullNameInputElement = document.getElementById('fname');
  let emailInputElement = document.getElementById('email');
  let phoneNumberInputElement = document.getElementById('phone');
  let addressInputElement = document.getElementById('address');
  let postalCodeInputElement = document.getElementById('code');
 
  let submitButtonElement = document.getElementById('submitBTN');
 
  submitButtonElement.addEventListener('click', (e) => {
    e.preventDefault();
 
    if (!fullNameInputElement.value || !emailInputElement.value) {
      return;
    }
    //2.Previewing the user’s personal information 
    submitButtonElement.disabled = true;
 
    let editButtonElement = document.getElementById('editBTN');
    editButtonElement.disabled = false;
    let continueButtonElement = document.getElementById('continueBTN');
    continueButtonElement.disabled = false;
 
    let ulElelement = document.getElementById('infoPreview');
 
    let nameLi = document.createElement('li');
    nameLi.textContent = `Full Name: ${fullNameInputElement.value}`;
 
    let emailLi = document.createElement('li');
    emailLi.textContent = `Email: ${emailInputElement.value}`;
 
    let phoneLi = document.createElement('li');
    phoneLi.textContent = `Phone Number: ${phoneNumberInputElement.value}`;
 
    let addressLi = document.createElement('li');
    addressLi.textContent = `Address: ${addressInputElement.value}`;
 
    let postalLi = document.createElement('li');
    postalLi.textContent = `Postal Code: ${postalCodeInputElement.value}`;
 
    ulElelement.appendChild(nameLi);
    ulElelement.appendChild(emailLi);
    ulElelement.appendChild(phoneLi);
    ulElelement.appendChild(addressLi);
    ulElelement.appendChild(postalLi);
    //clear input fields
    fullNameInputElement.value = '';
    emailInputElement.value = '';
    phoneNumberInputElement.value = '';
    addressInputElement.value = '';
    postalCodeInputElement.value = '';
 
 
    editButtonElement.addEventListener('click', (e) => {
      e.preventDefault();
 
      while (ulElelement.firstChild) {
        ulElelement.removeChild(ulElelement.firstChild);
      }
 
      fullNameInputElement.value = nameLi.textContent;
      emailInputElement.value = emailLi.textContent;
      phoneNumberInputElement.value = Number(phoneLi.textContent);
      addressInputElement.value = addressLi.textContent;
      postalCodeInputElement.value = Number(postalLi.textContent);
 
      submitButtonElement.disabled = false;
      editButtonElement.disabled = true;
      continueButtonElement.disabled = true;
    });
 
    continueButtonElement.addEventListener('click', (e) => {
      e.preventDefault();
 
      let mailDivElement = document.getElementById('block');
 
      while (mailDivElement.firstChild) {
        mailDivElement.removeChild(mailDivElement.firstChild);
      }
 
      let finalHeader = document.createElement('h3');
      finalHeader.textContent = 'Thank you for your reservation!';
      mailDivElement.appendChild(finalHeader);
    })
  });
}
