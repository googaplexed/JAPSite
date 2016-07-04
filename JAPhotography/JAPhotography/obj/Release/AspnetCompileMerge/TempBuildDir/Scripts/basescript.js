
var bodyPadding = 30;
var navbarHeight = $(".navbar").height() + 20;
var footerHeight = 60;
var screenHeight = $(window).height();

var pageSize = 10;
var pageIndex = 0;

$(window).resize(function () {
    navbarHeight = $(".navbar").height() + 20;
    screenHeight = $(window).height();
    $(".main-content").height(screenHeight - (bodyPadding + navbarHeight + footerHeight));    
});

$(document).ready(function () {

    //GetData();

    //$(window).scroll(function () {
    //    if ($(window).scrollTop() == $(document).height() - $(window).height())
    //    {
    //        GetData();
    //    }
    //});

    //$(document).on("click", ".loadMoreBtn", function () {
    //    window.location.href = window.location.href + "photos";
    //});

    $('body').on('contextmenu', 'img', function (e) { return false; });


    function GetData() 
    {
        $.ajax({
            type: 'GET',
            url: '/home/GetData',
            data: { "pageIndex": pageIndex, "pageSize": pageSize },
            dataType: 'json',
            success: function (data) {
                if (data != null) {
                    for (var i = 0; i < data.length; i++)
                    {
                        $("#thumbnail_gallery").append("<h2>Woo! " + pageIndex + "</h2>");
                    }
                    pageIndex++;
                }
            },
            beforeSend: function () {
                $("#progress").show();
            },
            complete: function () {
                $("#progress").hide();
            },
            error: function () {
                //alert("Error while retrieving data!");
            }
        })
    }


    //$(".main-content").height(screenHeight - (bodyPadding + navbarHeight + footerHeight));    

    $(".gallery").load('/Home/_Gallery', function () {
        //$('.ajax-loader').show();
        //$(".main-content").addClass("insert-scroll");
        $("#thumbnail_gallery").justifiedGallery({
            rowHeight: 215,
            lastRow: 'nojustify',
            captions: false,
            margins: 7,
            waitThumbnailsLoad: true,
            fixedHeight: true
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
            $('.gallery').html(data);
            $("#thumbnail_gallery").justifiedGallery({
                rowHeight: 250,
                lastRow: 'nojustify',
                captions: false,
                margins: 7,
                waitThumbnailsLoad: false
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
    //$('.ajax-loader').show();
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
            //$('.ajax-loader').hide();
            $(".email-submission").html(data);
        },
        error: function (data) {            
            //$('.ajax-loader').hide();
            $(".email-submission").html(data);
        }
    });
};

function ResetContactForm()
{
    $(".form-control").val("");
}