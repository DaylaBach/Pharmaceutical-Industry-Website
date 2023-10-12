(function($) {
    'use strict';
    // Preloader
    $(window).on('load', function() {
        $('.preloader').addClass('hidden');
        $('[data-popup="tooltip"]').tooltip();
    });
    $(".hamburger>.hamburger_btn").on('click', function() {
        $(".header .navigation").toggleClass('open');
        $(this).toggleClass('active');
    });
    // Mobile Menu
    $(".header .menu-item-has-children > a").on('click', function(e) {
        var submenu = $(this).next(".sub-menu");
        e.preventDefault();
        submenu.slideToggle(200);
    });
    // Main Banner
    $('.banner_slider').slick({
        infinite: true,
        slidesToShow: 1,
        slidesToScroll: 1,
        autoplay: true,
        autoplaySpeed: 1000,
        speed: 1000,
        dots: false,
        arrows: true,
        dotsClass: "slick-dots d-flex",
        responsive: [{
            breakpoint: 992,
            settings: {
                arrows: false,
                dots: true,
            }
        }]
    });
    // New Arrivals
    $('.new_arrivals').slick({
        infinite: true,
        slidesToShow: 4,
        slidesToScroll: 1,
        autoplay: true,
        autoplaySpeed: 1000,
        speed: 1000,
        dots: false,
        arrows: true,
        dotsClass: "slick-dots d-flex mt-5",
        responsive: [{
                breakpoint: 992,
                settings: {
                    slidesToShow: 3
                }
            },
            {
                breakpoint: 768,
                settings: {
                    slidesToShow: 2
                }
            },
            {
                breakpoint: 576,
                settings: {
                    arrows: false,
                    dots: true,
                    slidesToShow: 1
                }
            }
        ]
    });
    // Trending Products
    $('.trending_products').slick({
        infinite: true,
        slidesToShow: 4,
        slidesToScroll: 1,
        autoplay: true,
        autoplaySpeed: 1000,
        speed: 1000,
        dots: false,
        arrows: true,
        dotsClass: "slick-dots d-flex mt-5",
        responsive: [{
                breakpoint: 992,
                settings: {
                    slidesToShow: 3
                }
            },
            {
                breakpoint: 768,
                settings: {
                    slidesToShow: 2
                }
            },
            {
                breakpoint: 576,
                settings: {
                    arrows: false,
                    dots: true,
                    slidesToShow: 1
                }
            }
        ]
    });
    // Testimonial Slider
    $('.testimonial_slider').slick({
        infinite: true,
        slidesToShow: 3,
        slidesToScroll: 1,
        autoplay: true,
        autoplaySpeed: 1000,
        speed: 1000,
        dots: false,
        arrows: true,
        dotsClass: "slick-dots d-flex mt-5",
        responsive: [{
                breakpoint: 992,
                settings: {
                    slidesToShow: 2
                }
            },
            {
                breakpoint: 768,
                settings: {
                    slidesToShow: 1
                }
            },
            {
                breakpoint: 576,
                settings: {
                    arrows: false,
                    dots: true,
                    slidesToShow: 1
                }
            }
        ]
    });
    // Blog Slider
    $('.blog_slider').slick({
        infinite: true,
        slidesToShow: 3,
        slidesToScroll: 1,
        autoplay: true,
        autoplaySpeed: 1000,
        speed: 1000,
        dots: false,
        arrows: true,
        dotsClass: "slick-dots d-flex mt-5",
        responsive: [{
                breakpoint: 992,
                settings: {
                    slidesToShow: 2
                }
            },
            {
                breakpoint: 768,
                settings: {
                    slidesToShow: 1
                }
            },
            {
                breakpoint: 576,
                settings: {
                    arrows: false,
                    dots: true,
                    slidesToShow: 1
                }
            }
        ]
    });
    // Team Slider
    $('.related_slider').slick({
        infinite: true,
        slidesToShow: 3,
        slidesToScroll: 1,
        autoplay: true,
        autoplaySpeed: 1000,
        speed: 1000,
        dots: false,
        arrows: true,
        dotsClass: "slick-dots d-flex mt-5",
        responsive: [{
                breakpoint: 992,
                settings: {
                    slidesToShow: 2
                }
            },
            {
                breakpoint: 768,
                settings: {
                    slidesToShow: 1
                }
            },
            {
                breakpoint: 576,
                settings: {
                    arrows: false,
                    dots: true,
                    slidesToShow: 1
                }
            }
        ]
    });
    // Product Details Slider
    $('.product_slider').slick({
        slidesToShow: 1,
        slidesToScroll: 1,
        arrows: false,
        asNavFor: '.product_slider_nav'
    });
    $('.product_slider_nav').slick({
        slidesToShow: 3,
        slidesToScroll: 1,
        asNavFor: '.product_slider',
        dots: false,
                arrows:false,
        centerMode: true,
        centerPadding: '0px',
        focusOnSelect: true,
        responsive: [{
            breakpoint: 567,
            settings: {
                slidesToShow: 2,
            }
        }]
    });
    // Countdown
    $(".countdown").each(function() {
        var $this = $(this);
        $this.countdown($this.data('countdown'), function(event) {
            $(this).html("<ul> <li> <h4>" + event.strftime('%D') + "</h4> <p>Days</p></li><li> <h4>" + event.strftime('%H') + "</h4> <p>Hours</p></li><li> <h4>" + event.strftime('%M') + "</h4> <p>Minutes</p></li><li> <h4>" + event.strftime('%S') + "</h4> <p>Seconds</p></li></ul>")
        });
    });
    // Countdown
    $(".countdown_basic").each(function() {
        var $this = $(this);
        $this.countdown($this.data('countdown'), function(event) {
            $(this).text(
                event.strftime('%D days %Hh : %Mm : %Ss')
            );
        });
    });
    // Countdown
    $(".countdown_basic_two").each(function() {
        var $this = $(this);
        $this.countdown($this.data('countdown'), function(event) {
            $(this).text(
                event.strftime('%H:%M:%S')
            );
        });
    });
    // Progress bar
    $(".featured_product").each(function() {
        var progressBar = $(this).find(".claimed_bar>div");
        $(progressBar).one('inview', function(event, isInView) {
            if (isInView) {
                $(progressBar).animate({
                    width: $(progressBar).attr("data-valuenow") + "%"
                });
            }
        });
    });
    // Progress bar
    $(".rating_bar li").each(function() {
        var progressBar = $(this).find(".rate_bar>div");
        $(progressBar).one('inview', function(event, isInView) {
            if (isInView) {
                $(progressBar).animate({
                    width: $(progressBar).attr("data-valuenow") + "%"
                });
            }
        });
    });
    // Product Social
    $(".social_trigger").on('click', function() {
        $(this).next().slideToggle(200);
    });
    // Sticky Header
    var header = $(".can-sticky");
    var footer = $(".ft-sticky");
    var headerHeight = header.innerHeight();
    var FooterHeight = footer.innerHeight();

    function doSticky() {
        if (window.pageYOffset > headerHeight) {
            header.addClass("sticky");
        } else {
            header.removeClass("sticky");
        }
        if (window.pageYOffset > FooterHeight) {
            footer.addClass("d-flex");
        } else {
            footer.removeClass("d-flex");
        }
    }
    doSticky();
    //On scroll events
    $(window).on('scroll', function() {
        doSticky();
    });
    if ($(".back-to-top").length) {
        $(".back-to-top").on("click", function() {
            var target = $(this).attr("data-target");
            // animate
            $("html, body").animate({
                    scrollTop: $(target).offset().top,
                },
                1000
            );

            return false;
        });
    };
    // Current year
    var d = new Date();
    document.getElementById("year").innerHTML = d.getFullYear();
    // Add / Subtract Quantity
    $(".quantity button").on('click', function() {
        var qty = $(this).closest('.quantity').find('input');
        var qtyVal = parseInt(qty.val());
        if ($(this).hasClass('qty-add')) {
            qty.val(qtyVal + 1);
        } else {
            return qtyVal > 1 ?
                qty.val(qtyVal - 1) :
                0;
        }
    });
     // Toggle eye
    function VisiblePassword() {
        var togglePassword = document.querySelector('#password_eye');
        var password = document.querySelector('#password_value');
        if (togglePassword) {
            togglePassword.addEventListener('click', function(e) {
                // toggle the type attribute
                const type = password.getAttribute('type') === 'password' ? 'text' : 'password';
                password.setAttribute('type', type);
                // toggle the eye / eye slash icon
                this.classList.toggle('fa-eye-slash');
            });
        }
    }
    VisiblePassword();
})(jQuery);