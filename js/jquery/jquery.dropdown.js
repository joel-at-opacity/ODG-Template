$(document).ready(function(){

	$("ul.dropdown li").dropdown();

});

$.fn.dropdown = function() {

	$(this).hover(function(){
		$(this).removeClass("no-hover").addClass("hover");
		$('> .dir',this).addClass("open");
		$('ul:first',this).css('visibility', 'visible');
	},function(){
		$(this).removeClass("hover").addClass("no-hover");
		$('.open',this).removeClass("open");
		$('ul:first',this).css('visibility', 'hidden');
	});

}