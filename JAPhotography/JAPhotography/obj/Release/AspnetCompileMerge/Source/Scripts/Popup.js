var html = jQuery('html');

function OpenDimmer(color, opacity, FadeDuration, Image)
{
    if (!($(".dim").length))
    {
        var dimmer = "<div class='dim' style='position: fixed; max-width: 100%; opacity: " + opacity + "; background-color: " + color + ";' onclick='CloseDimmer(" + FadeDuration + "); return false;'></div>";
        var wrapper = "<div class='wrapper'></div>";
        //var getImage = "<img class='popupImage' src='data:image/jpeg;base64," + Image + "' alt='' style='width: " + Width + "; height: " + Height + ";' />";
        //var getImage = "<img class='popupImage' src='data:image;base64, " + Image + "' alt='' style='width: 50%; height: auto;' />";
        var getImage = "<img class='popupImage' src='" + Image + "' alt='' />";        
        //var getImage = "<div class='popupImage' style='background-image: url(" + Image + ");'></div>";

        $(dimmer).hide().appendTo("body");
        $(wrapper).hide().appendTo("body");
        $(getImage).appendTo(".wrapper");
        //var closeIcon = "<img class='closeIcon' src='/Content/Images/icons/close.png' onclick='CloseDimmer(" + FadeDuration + ");' />";
        //$(closeIcon).appendTo(".wrapper");
        $(".dim").fadeIn(FadeDuration);
        $(".wrapper").fadeIn(FadeDuration);
        //$(".popupImage").fadeIn(FadeDuration);
        //$(".closeIcon").fadeIn(FadeDuration);

        var scrollPosition = [
        self.pageXOffset || document.documentElement.scrollLeft || document.body.scrollLeft,
        self.pageYOffset || document.documentElement.scrollTop || document.body.scrollTop
        ];

        html.data('scroll-position', scrollPosition);
        html.data('previous-overflow', html.css('overflow'));
        html.css('overflow', 'hidden');
        window.scrollTo(scrollPosition[0], scrollPosition[1]);
    }    
}

function CloseDimmer(FadeDuration)
{
    $(".wrapper, .dim").fadeOut(FadeDuration, function () {
        //$(".dim").fadeOut();
        //$(".popupImage").remove();
        $(".dim").remove();
        //$(".closeIcon").remove();
        $(".wrapper").remove();
    });

    var scrollPosition = html.data('scroll-position');
    html.css('overflow', html.data('previous-overflow'));
    window.scrollTo(scrollPosition[0], scrollPosition[1])
}

(function ($) {
    $("body").scroll(function () {
        $(".dim, .popupImage, .closeIcon").css('top', $(this).scrollTop());
    });  


    // un-lock scroll position
    
})(jQuery)