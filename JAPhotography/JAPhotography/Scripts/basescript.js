
// Disable right click
//document.oncontextmenu = document.body.oncontextmenu = function () { return false; }

$(document).ready(function () {

    var bodyPadding = 55;
    var navbarHeight = 70;
    var footerHeight = 60;
    var screenHeight = $(document).height();

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
        //e.preventDefault();
        SendEmail();
    });

    $("#thumbnail_gallery a").attr("href");
});

function AjaxError(submissionForm)
{
    // Improve this call's error.

    $.ajax({
        url: '/Home/_Error',
        type: 'POST',
        dataType: "html",
        data: {},
        error: function () {
            //alert('error');
            $("html").load("error.cshtml");
        },
        success: function (data) {
            $('.ajax-loader').hide();
            if (submissionForm)
            {
                $('.email-submission').html(data);
                //$('.email-submission img').width($(".email-submission").width());
            }
            else
            {
                $('#MainContainer').html(data);
            }            
        }
    });
}

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
            $('.ajax-loader').hide();
            AjaxError(true);
        }
    });
};

function ResetContactForm()
{
    $(".form-control").val("");
}