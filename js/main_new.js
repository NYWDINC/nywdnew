/**
* demo.js
* http://www.codrops.com
*
* Licensed under the MIT license.
* http://www.opensource.org/licenses/mit-license.php
* 
* Copyright 2019, Codrops
* http://www.codrops.com
*/


var cartCount = 0,
	 buy = $('.add-cart'),
	 span = $('.number'),
	 cart = $('.cart'),
	 quickview = $('.quickviewContainer'),
	 quickViewBtn = $('.quickview'),
	 close = $('.quickviewContainer .close'),
	 minicart = [],
	 totalPrice = [],
	 miniCartPrice;

buy.on('click', addToCart);
quickViewBtn.on('click', quickView);
cart.on('click', showMiniCart);
close.on('click', function(){
    quickview.removeClass('active');
});

function quickView() {
    var description = $(this).parent().find('.description').text(),
		 header = $(this).parent().find('.header').text(),
		 price = $(this).find('.price'),
		 quickViewHeader = $('.quickviewContainer .headline'),
		 quickViewDescription = $('.quickviewContainer .description');
    clearTimeout(timeQuick);
    if(quickview.hasClass('active')){
        quickview.removeClass('active');
        var timeQuick = setTimeout(function(){
            quickview.addClass('active');
        }, 300);
    } else{
        quickview.addClass('active');
    }
	
    quickViewHeader.text(header);
    quickViewDescription.text(description);
}

function showMiniCart() {
    $('.mini').toggleClass('visible');
    if ($('.sub-menu').hasClass('open-submenu')) {
        $('.sub-menu').removeClass('open-submenu');
    };
}

$('a.close-cart').on('click',function(){
    $('.mini').removeClass('visible');
});

function addToCart() {
    var self = $(this),
		 productName = $(this).parent().find('.header').text(),
		 miniCartNames = $('.products'),
		 names = $('.names'),
		 price = $(this).parent().find('.price').text(),
		 priceInt = parseInt(price);
	
	
    $(this).addClass('ok');
    var timeOk = setTimeout(function(){
        self.removeClass('ok');
    }, 1000);
}

var swiper = new Swiper('.swiper-container', {
    spaceBetween: 0,
    centeredSlides: true,
    autoplay: {
        delay: 3800,
        disableOnInteraction: false,
    },
    pagination: {
        el: '.swiper-pagination',
        clickable: true,
    },
    navigation: {
        nextEl: '.swiper-button-next',
        prevEl: '.swiper-button-prev',
    },
});


$('.search-button').click(function(){
    $(this).parent().toggleClass('open');
});

$(document).ready(function() {
	
    $('.minus').click(function () {
        var $input = $(this).parent().find('input');
        var count = parseInt($input.val()) - 1;
        count = count < 1 ? 1 : count;
        $input.val(count);
        $input.change();
        return false;
    });
    $('.plus').click(function () {
        var $input = $(this).parent().find('input');
        $input.val(parseInt($input.val()) + 1);
        $input.change();
        return false;
    });
    $('.hamburger').click(function(){
        $('.nav-shop').toggleClass('open-menu');
        $('body').toggleClass('block');
    });
			
    $('.sub-menu a').click(function(e){
        e.preventDefault();
        $('.sub-menu').toggleClass('open-submenu');
        $('.overflow-menu').addClass('openover');
        if ($('.search-main').hasClass('open-search')) {
            $('.search-main').removeClass('open-search');
        };
        if ($('.search-system').hasClass('close-state')) {
            $('.search-system').removeClass('close-state');
        };
        if ($('.list-account').hasClass('open-list')) {
            $('.list-account').removeClass('open-list');
        };
    });
    $('.close-sub-menu').click(function(){
        $('.sub-menu').removeClass('open-submenu');
        $('.overflow-menu').removeClass('openover');
    });

    $('.overflow-menu').click(function(){
        if ($('.sub-menu').hasClass('open-submenu')) {
            $('.sub-menu').removeClass('open-submenu');
        };
        $(this).removeClass('openover');
    });
			
			
			
			
    //Check to see if the window is top if not then display button
    $(window).scroll(function(){
        if ($(this).scrollTop() > 100) {
            $('.scrollToTop').fadeIn();
        } else {
            $('.scrollToTop').fadeOut();
        }
    });
    //Click event to scroll to top
    $('.scrollToTop').click(function(){
        $('html, body').animate({scrollTop : 0},800);
        return false;
    });
    $('.advanced-trigger a').click(function(e){
        e.preventDefault();
        $(this).toggleClass('open-trigger');
        $('.list-shop-filter').toggleClass('open-filter');
        $('body').toggleClass('block-fil');
    });
		    	    
		    
});

$('select.dropdown').each(function() {

    var dropdown = $('<div />').addClass('dropdown selectDropdown');
		
    $(this).wrap(dropdown);
		
    var label = $('<span />').text($(this).attr('placeholder')).insertAfter($(this));
    var list = $('<ul />');
		
    $(this).find('option').each(function() {
        list.append($('<li />').append($('<a />').text($(this).text())));
    });
		
    list.insertAfter($(this));
		
    if($(this).find('option:selected').length) {
        label.text($(this).find('option:selected').text());
        list.find('li:contains(' + $(this).find('option:selected').text() + ')').addClass('active');
        $(this).parent().addClass('filled');
    }
		
});
		
$(document).on('click touch', '.selectDropdown ul li a', function(e) {
    e.preventDefault();
    var dropdown = $(this).parent().parent().parent();
    var active = $(this).parent().hasClass('active');
    var label = active ? dropdown.find('select').attr('placeholder') : $(this).text();
		
    dropdown.find('option').prop('selected', false);
    dropdown.find('ul li').removeClass('active');
		
    dropdown.toggleClass('filled', !active);
    dropdown.children('span').text(label);
		
    if(!active) {
        dropdown.find('option:contains(' + $(this).text() + ')').prop('selected', true);
        $(this).parent().addClass('active');
    }
		
    dropdown.removeClass('open');
});
		
$('.dropdown > span').on('click touch', function(e) {
    var self = $(this).parent();
    self.toggleClass('open');
});
		
$(document).on('click touch', function(e) {
    var dropdown = $('.dropdown');
    if(dropdown !== e.target && !dropdown.has(e.target).length) {
        dropdown.removeClass('open');
    }
});
		
 	
$('.button').click(function(){
    var buttonId = $(this).attr('id');
    $('#modal-container').removeAttr('class').addClass(buttonId);
    $('body').addClass('modal-active');
});

$('.add-to-cart').click(function(e){
    e.preventDefault();
    $(this).addClass('added');
});

$('.update-cart').click(function(e){
    e.preventDefault();
    $(this).addClass('updated');
});

$('.edit-card ').click(function(){
    $('#modal-container').removeAttr('class').addClass('open-modal');
    $('body').addClass('modal-active');
});

$('.add-primary').click(function(){
    $('#modal-container').removeAttr('class').addClass('open-modal');
    $('body').addClass('modal-active');
});

/*$('.log-shop').click(function(){
  var buttonId = $(this).attr('id');
  $('#modal-container').removeAttr('class').addClass(buttonId);
  $('body').addClass('modal-active');
});*/

$('.responsability-open').click(function(e){
    e.preventDefault();
    var buttonId = $(this).attr('id');
    $('#modal-container2').removeAttr('class').addClass(buttonId);
    $('body').addClass('modal-active');
});

$('.change-ship').click(function(e){
    e.preventDefault();
    var buttonId = $(this).attr('id');
    $('#modal-container2').removeAttr('class').addClass(buttonId);
    $('body').addClass('modal-active');
});

$('.delete-card').click(function(e){
    e.preventDefault();
    $('#modal-container3').removeAttr('class').addClass('open-modal');
    $('body').addClass('modal-active');
});

$('.delete-item-cart').click(function(e){
    e.preventDefault();
    $('#modal-container4').removeAttr('class').addClass('open-modal');
    $('body').addClass('modal-active');
});

$('.order-prev').click(function(e){
    e.preventDefault();
    $('#modal-container4').removeAttr('class').addClass('open-modal');
    $('body').addClass('modal-active');
});



$('.account-l').click(function(e){
    e.preventDefault();
    $('.list-account').toggleClass('open-list');
    if ($('.sub-menu').hasClass('open-submenu')) {
        $('.sub-menu').removeClass('open-submenu');
    };
  
});

$('.search-system a').click(function(e){
    e.preventDefault();
    $('.search-system').toggleClass('close-state');
    $('.search-main').toggleClass('open-search');
    if ($('.sub-menu').hasClass('open-submenu')) {
        $('.sub-menu').removeClass('open-submenu');
    };
  
});

$('.close-search').click(function(e){
    e.preventDefault();
    $('.search-main').removeClass('open-search');
  
});



$('.change-bill').click(function(e){
    e.preventDefault();
    $('#modal-container3').removeAttr('class').addClass('open-modal');
    $('body').addClass('modal-active');
});

$('.download-feed').click(function(e){
    e.preventDefault();
    $('#modal-container3').removeAttr('class').addClass('open-modal');
    $('body').addClass('modal-active');
});
$('.order-current').click(function(e){
    e.preventDefault();
    $('#modal-container3').removeAttr('class').addClass('open-modal');
    $('body').addClass('modal-active');
});


$('.close-modal2').click(function(e){
    e.preventDefault();
    $('#modal-container2').addClass('out');
    $('body').removeClass('modal-active');
});

$('.close-modal3').click(function(e){
    e.preventDefault();
    $('#modal-container3').addClass('out');
    $('body').removeClass('modal-active');
});

$('.close-modal4').click(function(e){
    e.preventDefault();
    $('#modal-container4').addClass('out');
    $('body').removeClass('modal-active');
});

$('.close-modal').click(function(e){
    e.preventDefault();
    $('#modal-container').addClass('out');
    $('body').removeClass('modal-active');
});

$('.username-login').click(function(e){
    e.preventDefault();
    $('.login-account').removeClass('slide-up');
  
});

$('.delete-login-account').click(function(e){
    e.preventDefault();
    $('.login-account').addClass('slide-up');
  
});


$('.agree').click(function(e){
    e.preventDefault();
    $('.web-term').addClass('hid');
});



$('.referral-btn').click(function(e){
    e.preventDefault();
    $('body').addClass('open-modal');
    $('.form-wrapper-ref').addClass('open-form-ref');
  
});

$('.close-wrapper-ref').click(function(e){
    e.preventDefault();
    $('.form-wrapper-ref').removeClass('open-form-ref');
    $('body').removeClass('open-modal');
  
});

$('.send-app').click(function(e){
    e.preventDefault();
    $('.panel-form').addClass('open-panel');
  
});

$('.order-current').click(function(e){
    e.preventDefault();
    $('.panel-form.Current').addClass('open-panel');
  
});

$('.order-prev').click(function(e){
    e.preventDefault();
    $('.panel-form.Previous').addClass('open-panel');
  
});

$('.close-panel').click(function(e){
    e.preventDefault();
    $('.panel-form').removeClass('open-panel');
  
});

$('.username-login').click(function(e){
    e.preventDefault();
    $('.panel-form.username-panel').addClass('open-panel');
  
});

$('.password-login').click(function(e){
    e.preventDefault();
    $('.panel-form.password-panel').addClass('open-panel');
  
});

console.clear();

const loginBtn = document.getElementById('login');
const signupBtn = document.getElementById('signup');


loginBtn.addEventListener('click', (e) => {
    let parent = e.target.parentNode.parentNode;
Array.from(e.target.parentNode.parentNode.classList).find((element) => {
    if(element !== "slide-up") {
        parent.classList.add('slide-up')
}else{
    signupBtn.parentNode.classList.add('slide-up')
    parent.classList.remove('slide-up')
}
});
});



signupBtn.addEventListener('click', (e) => {
    let parent = e.target.parentNode;
Array.from(e.target.parentNode.classList).find((element) => {
    if(element !== "slide-up") {
        parent.classList.add('slide-up')
}else{
    loginBtn.parentNode.parentNode.classList.add('slide-up')
    parent.classList.remove('slide-up')
}
});
});



// jQuery is required to run this code
$( document ).ready(function() {
    scaleVideoContainer();

    initBannerVideoSize('.video-container .poster img');
    initBannerVideoSize('.video-container .filter');
    initBannerVideoSize('.video-container video');

    $(window).on('resize', function() {
        scaleVideoContainer();
        scaleBannerVideoSize('.video-container .poster img');
        scaleBannerVideoSize('.video-container .filter');
        scaleBannerVideoSize('.video-container video');
    });
});

function scaleVideoContainer() {
    var height = $(window).height() + 5;
    var unitHeight = parseInt(height) + 'px';
    $('.homepage-hero-module').css('height',unitHeight);
}

function initBannerVideoSize(element){
    $(element).each(function(){
        $(this).data('height', $(this).height());
        $(this).data('width', $(this).width());
    });

    scaleBannerVideoSize(element);
}

function scaleBannerVideoSize(element) {

    var windowWidth = $(window).width(),
    windowHeight = $(window).height() + 5,
    videoWidth,
    videoHeight;

    // console.log(windowHeight);

    $(element).each(function(){
        var videoAspectRatio = $(this).data('height')/$(this).data('width');

        $(this).width(windowWidth);

      

        $('.homepage-hero-module .video-container video').addClass('fadeIn animated');

    });
}