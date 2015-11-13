/// <reference path="C:\Users\Zac\Documents\Visual Studio 2013\Projects\JAPhotography\JAPhotography\Views/Home/_Error.cshtml" />
$(document).ready(function () {

    var bodyPadding = 55;
    var navbarHeight = 70;
    var footerHeight = 60;
    var screenHeight = $(document).height();

    $(".main-content").height(screenHeight - (bodyPadding + navbarHeight + footerHeight));    

    $("#MainContainer").load('/Home/_Gallery', function () {
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
        LoadGalleryPartial();        
    });

    $(".investment-link").on('click', function (e) {
        e.preventDefault();
        LoadInvestmentPartial();
    });

    $(".contact-link").on('click', function (e) {
        e.preventDefault();
        LoadContactPartial();
    });

    // Email View

    $(".submit-email").on('click', function (e) {
        //e.preventDefault();
        SendEmail();
    });

    $("#thumbnail_gallery a").attr("href");
});

function ShowLoadingImage()
{

}

function HideLoadingImage()
{

}

function AjaxError()
{
    // Improve this call's error.

    $.ajax({
        url: '/Home/_Error',
        type: 'POST',
        dataType: "html",
        data: {},
        error: function () {
            alert('error');
        },
        success: function (data) {
            $('#MainContainer').html(data);
        }
    });
}

function LoadGalleryPartial()
{
    //ShowLoadingImage();
    $.ajax({
        url: '/Home/_Gallery',
        type: 'POST',
        dataType: "html",
        data: {},
        error: function () {
            AjaxError();
        },
        success: function (data) {
            //HideLoadingImage();
            $('#MainContainer').html(data);
            $("#thumbnail_gallery").justifiedGallery({
                rowHeight: 250,
                lastRow: 'nojustify',
                captions: false,
                margins: 7,
                waitThumbnailsLoad: true
            });
        }
    });
}

function LoadInvestmentPartial()
{
    //ShowLoadingImage();
    $.ajax({
        url: '/Home/_Investment',
        type: 'POST',
        dataType: "html",
        data: {},
        error: function () {
            AjaxError();
        },
        success: function (data) {
            //HideLoadingImage();
            $('#MainContainer').html(data);
        }
    });
}

function LoadContactPartial()
{
    //ShowLoadingImage();
    $.ajax({
        url: '/Home/_Contact',
        type: 'POST',
        dataType: "html",
        data: {},
        error: function () {
            AjaxError();
        },
        success: function (data) {
            //HideLoadingImage();
            $('#MainContainer').html(data);
        }
    });
}

function SendEmail() {
    //alert('sending!');
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
            //alert('success!');
            $('.ajax-loader').hide();
            $(".email-submission").html(data);
        },
        error: function (data) {
            alert('error!');
            $('.ajax-loader').hide();
            $(".email-submission").html('@Html.Partial("_Error")');
        }
    });
};