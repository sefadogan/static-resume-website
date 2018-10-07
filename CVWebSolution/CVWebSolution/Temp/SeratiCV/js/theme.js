// change header opacity scrolling
    $(window).scroll(function () {
    var scrollTop = $(window).scrollTop();
    var height = $(window).height();

    $('.profile').css({
        'opacity': ((height - scrollTop) / height)
    }); 
	});




// Toggle Main Menu
	$(document).ready(function(){ 
		$( ".site-menu .fa-bars" ).click(function() {
  		$( ".site-menu ul" ).fadeToggle( "fast", function() {  });
  		this.toggle = !this.toggle;
        $(this).stop().fadeTo(400, this.toggle ? 0.4 : 1);
});
	});
	
	
	
	
	
// Scroll to a Section	
$(document).ready(function(){
	$('a[href^="#"]').on('click',function (e) {
	    e.preventDefault();

	    var target = this.hash,
	    $target = $(target);

	    $('html, body').stop().animate({
	        'scrollTop': $target.offset().top
	    }, 900, 'swing', function () {
	        window.location.hash = target;
	    });
		
		$('.site-menu ul').hide();
	});
});

