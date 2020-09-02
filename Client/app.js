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
            $('#MovieTable').append(
                `
                <tr>
                    <td>${value.title}</td>
                    <td>${value.genre}</td>
                    <td>${value.director}</td>
                </tr>
                `
            )
        })
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
        url: 'http://71.11.153.207:9000/api/movie',
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
