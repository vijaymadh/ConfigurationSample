var isDestroyed = false;
var couroselinit = function () {

    if ($(window).width() >= 1087 || ($('#container').hasClass("hide"))) {
       
            $(".owl-carousel").trigger('destroy.owl.carousel')//.removeClass('owl-carousel owl-loaded');
            $(".owl-carousel").find('.owl-stage-outer').children().unwrap();;
          
        return;
    }
    else {
        isDestroyed = false;
        $(".owl-carousel").owlCarousel({
            loop: false,
            dotsSpeed: 150,

            responsive: {
                0: {
                    items: 4,
                    nav: false,
                    autoWidth: false,
                    autoHeight: false,
                    dotsEach: 4
                },
                480: {
                    items: 4,
                    nav: false,
                    autoWidth: false,
                    autoHeight: false,
                    dotsEach: 4

                },
                600: {
                    items: 6,
                    nav: false,
                    autoWidth: false,
                    autoHeight: false,
                    dotsEach: 6

                },
                768: {
                    items: 7,
                    autoWidth: false,
                    autoHeight: false,
                    dotsEach: 7
                },
                1000: {
                    items: 9,
                    autoWidth: false,
                    autoHeight: false,
                    dotsEach: 9


                },
                1280: {
                    items: 13,
                    autoWidth: false,
                    autoHeight: false,
                    dotsEach: false,
                    dots: false

                }


            }
        });
    }

    
    }

$(document).ready(function () {
    couroselinit();
    // Apply dynamic font-size based on tile text length.
    var tile = $("#_menu").children().filter(function () { return $(this).css("display") !== "none"; });
    var flag = 0;
    $(tile).each(function () {
        var text = $(this).find('.top_menu_text').text();     
        if (text.length > 22) {
            flag = 1;
        }
    });

    $(tile).each(function () {
        if (flag == 1) {
            $(this).find('.top_menu_text').addClass("customFont");
            $(".SearchTile").find("span.search").addClass("customFont");

            $(this).find('.top_menu_text').each(function () {
                var $menuItem = $(this);
                var menuText = $menuItem.text();
                var menuWords = menuText.split(' ');

                var maxLinesAllowed = 2;
                var currentLineNumber = 1;
                var currentLineText = "";
                var finalText = "";
                var CHARPERLINE = 16;
                $(menuWords).each(function (idx, val) {

                    if (currentLineNumber <= maxLinesAllowed) {
                        if (currentLineText !== "") {
                            currentLineText += " ";
                        }

                        var tempText = currentLineText + val;

                        if (tempText.length > CHARPERLINE) {
                            if (tempText.indexOf(" ") < 0 || currentLineNumber === maxLinesAllowed) {
                                $menuItem.attr('title', menuText);
                                finalText += tempText.substring(0, 11) + '...';
                                currentLineText = "";
                            }
                            else if (tempText.indexOf(" ") >= 0) {
                                finalText += currentLineText;
                                currentLineText = val;
                            }

                            currentLineNumber++;
                        }
                        else {
                            currentLineText = tempText;
                        }
                    }
                });

                if (currentLineText !== "") {
                    if (currentLineText.length > CHARPERLINE) {
                        $menuItem.attr('title', menuText);
                        finalText += currentLineText.substring(0, 11) + '...';
                    }
                    else {
                        finalText += currentLineText;
                    }
                }

                $menuItem.text(finalText);
            });
        }
    });

    setTimeout(function(){ 
        if($('.owl-dot').find('span').length == 1 )
        {
            $('.owl-dot').find('span').remove();
        }
    }, 100);
    });

var id;
$(window).resize(function () {
    clearTimeout(id);
    id = setTimeout(couroselinit, 200);
    //console.log("on resize calling couroselinit");
    //couroselinit();

 if($('.owl-dot').find('span').length == 1 )
    {
        $('.owl-dot').find('span').remove();
 }
     
 
 //if (!isDestroyed) {
 //    $(".owl-carousel").trigger('destroy.owl.carousel')//.removeClass('owl-carousel owl-loaded');
 //    $(".owl-carousel").find('.owl-stage-outer').children().unwrap();;
 //    isDestroyed = true;
    //}

 //if ($(window).width() >= 1000) {
 //   var target =  $('div .owl-item .active');
 //   target.attr("style", "");
 //   target.removeClass("owl-item").removeClass("active");
 //}
});