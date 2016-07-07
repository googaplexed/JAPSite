var html = jQuery('html');
var fadeDuration = 500;

$(window).resize(function () {
    $("#image-container").width($(".popupImage").width());
});

function OpenDimmer()
{
    if ($(".dim").length)
    {
        $(".dim, .wrapper").hide().fadeIn(fadeDuration);

        var scrollPosition = [
        self.pageXOffset || document.documentElement.scrollLeft || document.body.scrollLeft,
        self.pageYOffset || document.documentElement.scrollTop || document.body.scrollTop
        ];

        html.data('scroll-position', scrollPosition);
        html.data('previous-overflow', html.css('overflow'));
        html.css('overflow', 'hidden');
        window.scrollTo(scrollPosition[0], scrollPosition[1]);
    }    
};

function CloseDimmer()
{
    if ($(".dim").length) {
        $(".wrapper, .dim").fadeOut(fadeDuration, function () {
            $(".dim, .wrapper").remove();
        });

        var scrollPosition = html.data('scroll-position');
        html.css('overflow', html.data('previous-overflow'));
        window.scrollTo(scrollPosition[0], scrollPosition[1]);
    }
}

(function ($) {
    $("body").scroll(function () {
        $(".dim, .popupImage, .closeIcon").css('top', $(this).scrollTop());
    });  


    // un-lock scroll position
    
})(jQuery)

function showImage(imageUrl)
{
    $.ajax({
        url: '/home/_popup',
        method: 'GET',
        data: {},
        dateType: 'html',
        cache: false,
        success: function (html) {
            $("body").append(html);
            $(".popupImage").attr('src', imageUrl);
            OpenDimmer();
        },
        error: function () {
            //alert('failed!');
        }
    });
}