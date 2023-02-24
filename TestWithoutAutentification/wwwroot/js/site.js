
//$(function () {
//    $.ajaxSetup({ cache: false });
//    $(".down").click(function (e) {
//        e.preventDefault();
//        var url = $(this).data('url');
//        $.get(url, function (data) {
//        });
//    });
//})

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
    $("#filter").click(function (e) {
        var obj = document.getElementById("filterDiv");
        obj.style.display = "flex";
        var filterHref = document.getElementById("filter");
        if (filterHref.innerHTML == "Скрыть фильтры") {
            obj.style.display = "none";
            filterHref.innerHTML = "Показать фильтры";
        } else {
            filterHref.innerHTML = "Скрыть фильтры";
        }
    });
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

$(".navbar-brand").on("click", function () {
    $(".navbar-nav .company").removeClass("active");
    $(".navbar-nav .user").addClass("active");
    localStorage.removeItem("companyIsActive");
    localStorage.setItem("userIsActive", "true");
});

$(".navbar-nav .user").on("click", function () {
    $(".navbar-nav .company").removeClass("active");
    $(".navbar-nav .user").addClass("active");
    localStorage.removeItem("companyIsActive");
    localStorage.setItem("userIsActive", "true");
});

$(".navbar-nav .company").on("click", function () {
    $(".navbar-nav .user").removeClass("active");
    $(".navbar-nav .company").addClass("active");
    localStorage.removeItem("userIsActive");
    localStorage.setItem("companyIsActive", "true");
});

$(function () {
    var userIsActive = localStorage.getItem("userIsActive");
    if (userIsActive == "true") {
        $(".navbar-nav .company").removeClass("active");
        $(".navbar-nav .user").addClass("active");
    }
    var companyIsActive = localStorage.getItem("companyIsActive");
    if (companyIsActive == "true") {
        $(".navbar-nav .user").removeClass("active");
        $(".navbar-nav .company").addClass("active");
    }
})

$(function () {
    document.getElementById("specialization").onchange = function () {
        sessionStorage.setItem('specialization', document.getElementById("specialization").value);
    }

    if (sessionStorage.getItem('specialization')) {
        document.getElementById("specialization").options[sessionStorage.getItem('specialization')].selected = true;
    }

    document.getElementById("city").onchange = function () {
        sessionStorage.setItem('city', document.getElementById("city").value);
    }

    if (sessionStorage.getItem('city')) {
        document.getElementById("city").options[sessionStorage.getItem('city')].selected = true;
    }

    document.getElementById("experience").onchange = function () {
        sessionStorage.setItem('experience', document.getElementById("experience").value);
    }

    if (sessionStorage.getItem('experience')) {
        document.getElementById("experience").options[sessionStorage.getItem('experience')].selected = true;
    }    
})

$(function () {
    var tx = document.getElementsByTagName('textarea');

    for (var i = 0; i < tx.length; i++) {
        tx[i].setAttribute('style', 'height:' + (tx[i].scrollHeight) + 'px;overflow-y:hidden;');
        tx[i].addEventListener("input", OnInput, false);
    }

    function OnInput() {
        this.style.height = 'auto';
        this.style.height = (this.scrollHeight) + 'px';
    }
})

window.addEventListener("DOMContentLoaded", function () {
    [].forEach.call(document.querySelectorAll('.phone'), function (input) {
        var keyCode;
        function mask(event) {
            event.keyCode && (keyCode = event.keyCode);
            var pos = this.selectionStart;
            if (pos < 3) event.preventDefault();
            var matrix = "+7 (___) ___ ____",
                i = 0,
                def = matrix.replace(/\D/g, ""),
                val = this.value.replace(/\D/g, ""),
                new_value = matrix.replace(/[_\d]/g, function (a) {
                    return i < val.length ? val.charAt(i++) || def.charAt(i) : a
                });
            i = new_value.indexOf("_");
            if (i != -1) {
                i < 5 && (i = 3);
                new_value = new_value.slice(0, i)
            }
            var reg = matrix.substr(0, this.value.length).replace(/_+/g,
                function (a) {
                    return "\\d{1," + a.length + "}"
                }).replace(/[+()]/g, "\\$&");
            reg = new RegExp("^" + reg + "$");
            if (!reg.test(this.value) || this.value.length < 5 || keyCode > 47 && keyCode < 58) this.value = new_value;
            if (event.type == "blur" && this.value.length < 5) this.value = ""
        }

        input.addEventListener("input", mask, false);
        input.addEventListener("focus", mask, false);
        input.addEventListener("blur", mask, false);
        input.addEventListener("keydown", mask, false)
    });
});