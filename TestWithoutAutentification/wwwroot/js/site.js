// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.



$(function () {
    var PlaceHolderElement = $('#PlaceHolder');
    $('button[data-toggle="ajax-modal"]').click(function (event) {
        var url = $(this).data('url');
        var m = $(this).data('bind');
        $.get(url, m).done(function (data) {
            PlaceHolderElement.html(data);
            PlaceHolderElement.find('.modal').modal('show');
        })
    })

    PlaceHolderElement.on('click', '[data-save="modal"]', function (event) {
        var form = $(this).parents('.modal').find('form');
        if (form.valid() == true) {
            var actionUrl = form.attr('action');
            var sendData = form.serialize();
            $.post(actionUrl, sendData).done(function (data){

                PlaceHolderElement.find('.modal').modal('hide');
                //и вызвать частичное представление
            })
            
        }       
    })
})

$(function () {
    $.ajaxSetup({ cache: false });
    $(".compItem").click(function (e) {
        e.preventDefault();
        var url = $(this).data('url');
        $.get(url, function (data) {
            $('#dialogContent').html(data);
            $('#modDialog').modal('show');
        });
    });
})

$(".navbar-nav a").on("click", function () {
    $(".navbar-nav").find(".active").removeClass("active");
    $(this).parent().addClass("active");
});

