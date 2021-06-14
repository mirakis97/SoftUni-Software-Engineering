function notify(message) {
  const div = document.querySelector('#notification');
  const node = document.createTextNode(message);

  div.appendChild(node);
  div.style.display = 'block';

  div.addEventListener('click', () => {
    div.style.display = 'none';
    div.textContent = '';
  });
}