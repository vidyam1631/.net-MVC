
let movie = document.querySelector('.Movie');
let request = new XMLHttpRequest();
request.open("GET", 'https://localhost:44370/api/Movies/1');
request.send();
request.addEventListener('load', function () {
    let data = JSON.parse(request.responseText);
    console.log(data);
    const html = `<article>
<div> ${data.id}</div>
<div>${data.title}</div>
<div>${data.genre}</div>
<div>${data.releaseDate}</div>
</article>`;
    movie.insertAdjacentHTML('beforeend', html);

});

