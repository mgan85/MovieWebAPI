function showMovies() {
    var title = document.getElementById("title").value;
    var releaseYear = document.getElementById("releaseYear").value;
    var genre = document.getElementById("genre").value;
    var uri = "api/Movies/GetMovies?title=" + title + "&releaseYear=" + releaseYear + "&genre=" + genre;
    var domElement = document.getElementById("movies");
    $.getJSON(uri)
        .done(function (data) {
            domElement.innerHTML = JSON.stringify(data);
        })
        .fail(function (jqXHR, textStatus, err) {
            domElement.innerHTML = 'Error: ' + err;
        });
}

function showTop5Movie() {
    var uri = "api/Movies/Top5Movies";
    var domElement = document.getElementById("top5movies");
    $.getJSON(uri)
        .done(function (data) {
            domElement.innerHTML = JSON.stringify(data);
        })
        .fail(function (jqXHR, textStatus, err) {
            domElement.innerHTML = 'Error: ' + err;
        });
}

function showTop5UseMovies() {
    var genre = document.getElementById("genre").value;
    var uri = "api/Movies/GetMovies?title=" + title + "&releaseYear=" + releaseYear + "&genre=" + genre;
    var domElement = document.getElementById("top5usermovies");
    $.getJSON(uri)
        .done(function (data) {
            domElement.innerHTML = JSON.stringify(data);
        })
        .fail(function (jqXHR, textStatus, err) {
            domElement.innerHTML = 'Error: ' + err;
        });
}

function addRate() {
    var movieId = document.getElementById("userid2").value;
    var uri = "api/Movies/Top5UserMovies/" + id;
    var domElement = document.getElementById("top5usermovies");
    $.getJSON(uri)
        .done(function (data) {
            domElement.innerHTML = JSON.stringify(data);
        })
        .fail(function (jqXHR, textStatus, err) {
            domElement.innerHTML = 'Error: ' + err;
        });
}