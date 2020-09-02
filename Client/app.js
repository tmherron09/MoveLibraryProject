$(document).ready(function () {



    getAllMovies();


});

    
(function ($) {
    function processForm( e ){
        var dict = {
        	Title : this["title"].value,
            Director: this["director"].value,
            Genre: this["genre"].value
        };

        $.ajax({
            url: 'https://localhost:44325/api/movie',
            dataType: 'json',
            type: 'post',
            contentType: 'application/json',
            data: JSON.stringify(dict),
            success: function( data, textStatus, jQxhr ){
                $('#response pre').html( data );
            },
            error: function( jqXhr, textStatus, errorThrown ){
                console.log( errorThrown );
            }
        });

        e.preventDefault();
    }

    $('#my-form').submit( processForm );
})(jQuery);




function getAllMovies(){

    $.ajax({
        type: 'GET',
        dataType: 'json',
        url: 'https://localhost:44325/api/movie',
        success: function() {
            $('#MovieTable').html('');
        },
    })
    .then(function(data){
        $.each(data, function(index, value){                
            $("#movieCardContainer").append(
                `
                <div id="${value.movieId}" class="col-md-6">
                    <div class="row no-gutters border rounded overflow-hidden flex-md-row mb-4 shadow-sm h-md-250 position-relative">
                        
                    <div class="col-8 p-4 d-flex flex-column position-static">
                        <strong class="d-inline-block mb-2 text-primary">${value.genre}</strong>
                        <h3 class="mb-0">${value.title}</h3>
                            
                        <div class="mb-1 text-muted">${value.director}</div>

                        <p class="card-text mb-auto">This is a wider card with supporting text below as a natural lead-in to additional content.</p>
                        <button onclick="editmovie(${value.movieId})" class="btn-primary">View details</a>
                        </div>
                        
                        <div class="col-4 d-none d-lg-block">
                        <img src="" class="img-fluid" alt="movie poster for ${value.title}">
                        </div>
                    </div>
                </div>
                `
            )
        }
        )})
    }
                
    

function getMovieById(id) {
    return $.ajax({
        type: 'GET',
        dataType: 'json',
        url: 'https://localhost:44325/api/movie/' + id,
        success: function () {
            console.log("GET id Success.");
        },
        error: function() {
            console.log("GET id failed.");
        }
    }).then(function(data) {
        return data[0];
    })
}

async function processEditMovieForm(e) {
    var dataObj = {
        movieId : parseInt(this["movieId"].value),
        title: this["title"].value,
        genre: this["genre"].value,
        director: this["director"].value
    }
    var outgoing = JSON.stringify(dataObj);

    e.preventDefault();
    await jQuery.ajax({
        url: 'https://localhost:44325/api/movie',
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
    getAllMovies();
}

