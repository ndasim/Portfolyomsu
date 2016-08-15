// asim.dogan.namli@gmail.com //

function kur(){
	var sayfa = $('#sayfaid').html();
	 
	switch (sayfa){
		case 'giris':
			$(".body").css("height", '400px');
			break;
		case 'hakkimizda':
			$(".body").css("height", '600px');
			break;
		case 'iletisim':
			$(".body").css("height", '600px');
			break;
        case 'emlakAna':
			$(".body").css("height", '1000px');
			break;
	}
	
	$('.petek').hover(
	  function() {
		$(this).find('.in').css('display', 'block');
	    $(this).find('.in').fadeTo('fast', 1);
		$(this).find('.out').fadeTo('fast', 0);
	  },
	  function() {
		$(this).find('.in').fadeTo('fast', 0);
		$(this).find('.out').fadeTo('fast', 1);
	  }
	);
}

