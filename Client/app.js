$(document).ready(function () {

    getAllMovies();

});
  
// const searchBar = document.getElementById('searchBar');
// const movieList = document.getElementById(movieList)


console.log(searchBar);
let storedData = [];
searchBar.addEventListener('keyup', (e) => {
    console.log(e);
    searchString = e.target.value;
    filteredMovies = storedData.filter(movie => {
    let test = movie.title.toLowerCase().includes(searchString) || movie.director.toLowerCase().includes(searchString);
    return test;
    
});

    console.log(filteredMovies);
    displaySearchCards(filteredMovies);

});

function displaySearchCards(filteredMovies) {
    $('#movieCardContainer').html('');
    $.each(filteredMovies, function (index, value) {
        let posterUrl = "poster_dumby.jpg"
        if (value.posterImage) {
            posterUrl = value.posterImage.posterLink;
        }
        $("#movieCardContainer").append(
            `
        <div id="${value.movieId}" class="col-md-6">
            <div class="row no-gutters border rounded overflow-hidden flex-md-row mb-4 shadow-sm h-md-250 position-relative">
            <div class="col-8 p-4 d-flex flex-column position-static">
                <strong class="d-inline-block mb-2 text-primary">${value.genre}</strong>
                <h3 class="mb-0">${value.title}</h3>
                <div class="mb-1 text-muted">${value.director}</div>
                <p class="card-text mb-auto">This is a wider card with supporting text below as a natural lead-in to additional content.</p>
                <button id="btn${value.movieId}" onclick="viewMovie(${value.movieId})" class="btn-primary">View details</a>
                </div>
                <div class="col-4 d-none d-lg-block ">
                <img src="${posterUrl}" class="img-fluid float-right" alt="movie poster for ${value.title}">
                </div>
            </div>
        </div>
        `
        )
    }
    )
}


(function ($) {
    async function processForm(e) {
        var dict = {
            Title: this["title"].value,
            Director: this["director"].value,
            Genre: this["genre"].value
        };

        e.preventDefault();
        let scrollRef;

        await $.ajax({
            url: 'http://71.11.153.207:9000/api/movie/',
            dataType: 'json',
            type: 'post',
            contentType: 'application/json',
            data: JSON.stringify(dict),
            success: function (data, textStatus, jQxhr) {
                $('#response pre').html(data);
            },
            error: function (jqXhr, textStatus, errorThrown) {
                console.log(errorThrown);
            }
        }).then(function (data) {
            storedData.push(data);
            scrollRef = data.movieId;
            displayCards();
        })

        window.scrollTo(0, document.body.scrollHeight);
    }

    $('#my-form').submit(processForm);
})(jQuery);


function displayCards() {
    $('#movieCardContainer').html('');
    $.each(storedData, function (index, value) {
        let posterUrl = "poster_dumby.jpg";
        let plot = "This has no Plot.";
        if (value.posterImage) {
            posterUrl = value.posterImage.posterLink;
        }
        if(value.plotSynop){
            plot = value.plotSynop
        }

        $("#movieCardContainer").append(
            `
        <div id="${value.movieId}" class="col-md-6">
            <div class="row no-gutters border rounded overflow-hidden flex-md-row mb-4 shadow-sm h-md-250 position-relative">
                
            <div class="col-8 p-4 d-flex flex-column position-static">
                <strong class="d-inline-block mb-2 text-primary">${value.genre}</strong>
                <h3 class="mb-0">${value.title}</h3>
                    
                <div class="mb-1 text-muted">${value.director}</div>

                <p class="card-text mb-auto">${plot}</p>
                <button id="btn${value.movieId}" onclick="viewMovie(${value.movieId})" class="btn-primary">View details</a>
                </div>
                
                <div class="col-4 d-none d-lg-block ">
                <img src="${posterUrl}" class="img-fluid float-right" alt="movie poster for ${value.title}">
                </div>
            </div>
        </div>
        `
        )
    }
    )
}

function displaySearchCards(filteredMovies) {
    $('#movieCardContainer').html('');
    $.each(filteredMovies, function (index, value) {
        let posterUrl = "poster_dumby.jpg"
        let plot = "This has no Plot.";
        if (value.posterImage) {
            posterUrl = value.posterImage.posterLink;
        }
        if(value.plotSynop){
            plot = value.plotSynop
        }

        $("#movieCardContainer").append(
            `
        <div id="${value.movieId}" class="col-md-6 ">
            <div class="row no-gutters border rounded overflow-hidden flex-md-row mb-4 shadow-sm h-md-250 position-relative">
                
            <div class="col-8 p-4 d-flex flex-column position-static">
                <strong class="d-inline-block mb-2 text-primary">${value.genre}</strong>
                <h3 class="mb-0">${value.title}</h3>
                    
                <div class="mb-1 text-muted">${value.director}</div>

                <p class="card-text mb-auto">${plot}</p>
                <button id="btn${value.movieId}" onclick="viewMovie(${value.movieId})" class="btn-primary">View details</a>
                </div>
                
                <div class="col-4 d-none d-lg-block ">
                <img src="${posterUrl}" class="img-fluid float-right" alt="movie poster for ${value.title}">
                </div>
            </div>
        </div>
        `
        )
    }
    )
}



function sortCards(sortMethod) {
    storedData = sortMethod();
    displayCards();
}


// Sort Movies by Title Alphabetically/Reverse
function sortTitleAlphabetically() {

    let data = storedData.sort(function (a, b) {
        if (a.title < b.title) { return -1; }
        if (a.title > b.title) { return 1; }
        return 0;
    });
    return data;
}

function sortTitleReverseAlphabetically() {

    let data = storedData.sort(function (a, b) {
        if (a.title > b.title) { return -1; }
        if (a.title < b.title) { return 1; }
        return 0;
    });
    return data;

}



function sortTitleAlpha() {
    if ($('#alpha-title').css("display") == "inline") {
        sortCards(sortTitleAlphabetically);
        $('#alpha-title').css('display', 'none');
        $('#reverse-alpha-title').css('display', 'inline');
    }
    else {
        sortCards(sortTitleReverseAlphabetically);
        $('#reverse-alpha-title').css('display', 'none');
        $('#alpha-title').css('display', 'inline');
    }
}

$('#alpha-title').click(function () {
    sortCards(sortTitleAlphabetically);
});
$('#reverse-alpha-title').click(function () {
    sortCards(sortTitleReverseAlphabetically);
});

// Sort Movies by Genre Alphabetically/Reverse
function sortGenreAlphabetically() {

    let data = storedData.sort(function (a, b) {
        if (a.genre < b.genre) { return -1; }
        if (a.genre > b.genre) { return 1; }
        return 0;
    });
    return data;
}

function sortGenreReverseAlphabetically() {

    let data = storedData.sort(function (a, b) {
        if (a.genre > b.genre) { return -1; }
        if (a.genre < b.genre) { return 1; }
        return 0;
    });
    return data;

}

function sortGenreAlpha() {
    if ($('#alpha-title').css("display") == "inline") {
        sortCards(sortTitleAlphabetically);
        $('#alpha-title').css('display', 'none');
        $('#reverse-alpha-title').css('display', 'inline');
    }
    else {
        sortCards(sortTitleReverseAlphabetically);
        $('#reverse-alpha-title').css('display', 'none');
        $('#alpha-title').css('display', 'inline');
    }
}

$('#alpha-genre').click(function () {
    sortCards(sortGenreAlphabetically);
});
$('#reverse-alpha-genre').click(function () {
    sortCards(sortGenreReverseAlphabetically);
});

// Sort Movies by Director Alphabetically/Reverse
function sortDirectorAlphabetically() {

    let data = storedData.sort(function (a, b) {
        if (a.director < b.director) { return -1; }
        if (a.director > b.director) { return 1; }
        return 0;
    });
    return data;
}

function sortDirectorReverseAlphabetically() {

    let data = storedData.sort(function (a, b) {
        if (a.director > b.director) { return -1; }
        if (a.director < b.director) { return 1; }
        return 0;
    });
    return data;

}


$('#alpha-director').click(function () {
    sortCards(sortDirectorAlphabetically);
});
$('#reverse-alpha-director').click(function () {
    sortCards(sortDirectorReverseAlphabetically);
});





function getAllMovies() {

    $.ajax({
        type: 'GET',
        dataType: 'json',
        url: 'http://71.11.153.207:9000/api/movie/',
        success: function () {
            $('#MovieTable').html('');
        },
    })
        .then(function (data) {
            storedData = data;

            sortCards(sortTitleAlphabetically);

        })
}



function getMovieById(id) {
    return $.ajax({
        type: 'GET',
        dataType: 'json',
        url: 'http://71.11.153.207:9000/api/movie/' + id,
        success: function () {
            console.log("GET id Success.");
        },
        error: function () {
            console.log("GET id failed.");
        }
    }).then(function (data) {
        return data[0];
    })
}

function getMovieByIdLocal(id) {
    let movie = storedData.filter(function (value) {

        if (value.movieId == id) {
            return true;
        }
        return false;
    })

    return movie[0];
}



function viewMovie(id) {

    $('.col-md-12').toggleClass("col-md-6 col-md-12");

    var movie = getMovieByIdLocal(id);
    console.log(movie.title);
    $(`#${id}`).toggleClass("col-md-6 col-md-12");
    if ($(`#btnEdit${movie.movieId}`).length) {
        $('.editBtn').remove();
        $('.formRemove').remove();
        $('.col-md-12').toggleClass("col-md-6 col-md-12");
    }
    else {
        $('.editBtn').remove();
        $('.formRemove').remove();
        $(`#btn${id}`).before(
            `
        <button id="btnEdit${movie.movieId}" onclick="editMovie(${movie.movieId})" class="btn-primary editBtn my-3">Edit details</a>
        `
        )
    }
}

function editMovie(id) {

    let movie = getMovieByIdLocal(id);
    if(movie.plotSynop == null) {
        movie.plotSynop = "No plot description available.";
    }
    
    $(`#btnEdit${id}`).before(
        `
        <form id="editForm" class="form-group formRemove">
            <input type="hidden" name="movieId" value="${movie.movieId}" />
            <label>Title</label>
            <input type="text" name="title" placeholder="${movie.title}" value="${movie.title}" class="form-control py-2"></input>
            <label>Director</label>
            <input type="text" name="director" placeholder="${movie.director}" value="${movie.director}" class="form-control py-2"/>
            <label>Genre</label>
            <input type="text" name="genre" placeholder="${movie.genre}" value="${movie.genre}" class="form-control py-2"/>
            <label>Plot Synopsis</label>
            <input type="text" name="plotSynop" placeholder="${movie.plotSynop}" value="${movie.plotSynop}" class="form-control py-2"/>
            <label>Poster Link</label>
            <input type="text" name="posterLink" placeholder="${movie.posterImage.posterLink}" value="${movie.posterImage.posterLink}" class="form-control py-2"/>
            <button type="submit">Update Movie</button>
        </form>
        `
    )
    $("#editForm").submit(processEditMovieForm);
    $('.editBtn').remove();
}




async function processEditMovieForm(e) {

    let indexRef = parseInt(this["movieId"].value);
    var dataObj = {
        movieId: parseInt(this["movieId"].value),
        title: this["title"].value,
        genre: this["genre"].value,
        director: this["director"].value,
        plotSynop: this["plotSynop"].value,
        posterImage: {
            posterLink: this["posterLink"].value
        },
        posterImageId: null
    }
    var outgoing = JSON.stringify(dataObj);

    e.preventDefault();
    let updatedMovie = await jQuery.ajax({
        url: 'http://71.11.153.207:9000/api/movie/',
        type: 'PUT',
        contentType: 'application/json',
        data: outgoing,
        success: function (data, textStatus, jQxhr) {
            $('#response pre').html("Movie Successfully Edited!");
        },
        error: function (jqXhr, textStatus, errorThrown) {

            console.log(errorThrown);
        }
    })

    storedData[indexRef] = updatedMovie;

    let posterUrl = "poster_dumby.jpg"
    if (updatedMovie.posterImage) {
        posterUrl = updatedMovie.posterImage.posterLink;
    }

    $(`#${indexRef}`).html('');

    $(`#${indexRef}`).append(
        `
        <div class="row no-gutters border rounded overflow-hidden flex-md-row mb-4 shadow-sm h-md-250 position-relative">
            
        <div class="col-8 p-4 d-flex flex-column position-static">
            <strong class="d-inline-block mb-2 text-primary">${updatedMovie.genre}</strong>
            <h3 class="mb-0">${updatedMovie.title}</h3>
                
            <div class="mb-1 text-muted">${updatedMovie.director}</div>

            <p class="card-text mb-auto">This is a wider card with supporting text below as a natural lead-in to additional content.</p>
            <button id="btn${updatedMovie.movieId}" onclick="viewMovie(${updatedMovie.movieId})" class="btn-primary">View details</a>
            </div>
            
            <div class="col-4 d-none d-lg-block ">
            <img src="${posterUrl}" class="img-fluid float-right" alt="movie poster for ${updatedMovie.title}">
            </div>
        </div>
    `);

}