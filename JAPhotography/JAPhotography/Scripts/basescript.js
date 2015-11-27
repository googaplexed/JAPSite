
var bodyPadding = 55;
var navbarHeight = $(".navbar").height() + 20;
var footerHeight = 60;
var screenHeight = $(window).height();

// Disable right click
//document.oncontextmenu = document.body.oncontextmenu = function () { return false; }

$(window).resize(function () {
    navbarHeight = $(".navbar").height() + 20;
    screenHeight = $(window).height();
    $(".main-content").height(screenHeight - (bodyPadding + navbarHeight + footerHeight));    
});

$(document).ready(function () {   

    $(".main-content").height(screenHeight - (bodyPadding + navbarHeight + footerHeight));    

    $("#MainContainer").load('/Home/_Gallery', function () {
        //$('.ajax-loader').show();
        $(".main-content").addClass("insert-scroll");
        $("#thumbnail_gallery").justifiedGallery({
            rowHeight: 250,
            lastRow: 'nojustify',
            captions: false,
            margins: 7,
            waitThumbnailsLoad: true
        });
    });

    $(".gallery-link").on('click', function (e) {
        e.preventDefault();
        $(".main-content").addClass("insert-scroll");
        LoadGalleryPartial();        
    });

    $(".investment-link").on('click', function (e) {
        e.preventDefault();
        $(".main-content").removeClass("insert-scroll");
        LoadInvestmentPartial();
    });

    $(".contact-link").on('click', function (e) {
        e.preventDefault();
        $(".main-content").removeClass("insert-scroll");
        LoadContactPartial();
    });

    // Email View

    $(".submit-email").on('click', function (e) {
        e.preventDefault();
        SendEmail();
    });

    $("#thumbnail_gallery a").attr("href");    
});

function LoadGalleryPartial()
{
    $('.ajax-loader').show();
    $.ajax({
        url: '/Home/_Gallery',
        type: 'POST',
        dataType: "html",
        data: {},
        error: function () {
            $('.ajax-loader').hide();
            AjaxError();
        },
        success: function (data) {
            $('#MainContainer').html(data);
            $("#thumbnail_gallery").justifiedGallery({
                rowHeight: 250,
                lastRow: 'nojustify',
                captions: false,
                margins: 7,
                waitThumbnailsLoad: true
            });
            $('.ajax-loader').hide();
        }
    });
}

function LoadInvestmentPartial()
{
    $('.ajax-loader').show();
    $.ajax({
        url: '/Home/_Investment',
        type: 'POST',
        dataType: "html",
        data: {},
        error: function () {
            $('.ajax-loader').hide();
            AjaxError();
        },
        success: function (data) {
            $('.ajax-loader').hide();
            $('#MainContainer').html(data);
        }
    });
}

function LoadContactPartial()
{
    $('.ajax-loader').show();
    $.ajax({
        url: '/Home/_Contact',
        type: 'POST',
        dataType: "html",
        data: {},
        error: function () {
            $('.ajax-loader').hide();
            AjaxError();
        },
        success: function (data) {
            $('.ajax-loader').hide();
            $('#MainContainer').html(data);
        }
    });
}

function SendEmail() {
    $('.ajax-loader').show();
    $.ajax({
        url: 'Home/_ContactSend',
        type: "POST",
        dataType: "html",
        cache: false,
        data: {
            'email': $("#email").val(),
            'name': $("#name").val(),
            'subject': $("#subject").val(),
            'message': $("#message").val()
        },
        success: function (data) {
            $('.ajax-loader').hide();
            $(".email-submission").html(data);
        },
        error: function (data) {            
            $('.ajax-loader').hide();
            $(".email-submission").html(data);
        }
    });
};

function ResetContactForm()
{
    $(".form-control").val("");
}