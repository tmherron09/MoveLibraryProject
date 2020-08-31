(function($){
    function processForm( e ){
        var dict = {
        	Title : this["title"].value,
        	Director: this["director"].value
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


$(document).ready(getAllMovies);

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

