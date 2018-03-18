function showMovies() {
    var title = document.getElementById("title").value;
    var releaseYear = document.getElementById("releaseYear").value;
    var genre = document.getElementById("genre").value;
    var uri = "api/Movies/Movies?title=" + title + "&releaseYear=" + releaseYear + "&genre=" + genre;
    var domElement = document.getElementById("movies");
    ajaxHelper(uri, 'GET')
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
    ajaxHelper(uri, 'GET')
        .done(function (data) {
            domElement.innerHTML = JSON.stringify(data);
        })
        .fail(function (jqXHR, textStatus, err) {
            domElement.innerHTML = 'Error: ' + err;
        });
}

function showTop5UseMovies() {
    var userid = document.getElementById("userid2").value;
    var uri = "api/Movies/Top5UserMovies/" + userid;
    var domElement = document.getElementById("top5usermovies");
    ajaxHelper(uri, 'GET')
        .done(function (data) {
            domElement.innerHTML = JSON.stringify(data);
        })
        .fail(function (jqXHR, textStatus, err) {
            domElement.innerHTML = 'Error: ' + err;
        });
}

function addRate() {
    var rate = {
        MovieId: parseInt(document.getElementById("movieid").value),
        UserId: parseInt(document.getElementById("userid").value),
        Rating: parseInt(document.getElementById("rate").value)
    };

    var uri = "api/Rates/AddRate";
    var domElement = document.getElementById("infoRate");
    ajaxHelper(uri, 'POST', rate)
        .done(function (data) {
            domElement.innerHTML = "Added";
        })
        .fail(function (jqXHR, textStatus, err) {
            domElement.innerHTML = 'Error: ' + err;
        });
}

function ajaxHelper(uri, method, data) {
    return $.ajax({
        type: method,
        url: uri,
        contentType: 'application/json; charset=utf-8',
        data: data ? JSON.stringify(data) : null
    });
}