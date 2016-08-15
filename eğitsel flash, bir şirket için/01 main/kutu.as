package  {
	
	import flash.display.*;
	import flash.events.*;
	
	public class kutu extends SimpleButton {
		
		var id;
		
		public function kutu(ID) {
			addEventListener(MouseEvent.CLICK, gonder);
			id = ID
		}
		
		function gonder(e:MouseEvent){ // Ana programa tıklama olduğunu söyler...
			MovieClip(root).tik(id);
		}
		
		/*
		function ustunde(e:MouseEvent){
			gotoAndStop(2);
		}
		
		function disinda(e:MouseEvent){
			gotoAndStop(1);
			trace("blaaa")
		}
		
		function basma(e:MouseEvent){
			gotoAndPlay(3);
		}
		
		function kaldirma(e:MouseEvent){ // fare üzerine artık basmıyor, nam-ı diğer UP :D
			
		}*/
	}
	
}
