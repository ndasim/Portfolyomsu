package  {
	
	import flash.display.MovieClip;
	import flash.events.MouseEvent;
	import flash.display.Graphics;
	import flash.display.Sprite;
		
	public class nokta extends MovieClip {
		public var ad:String;
		public var deger:int = 0;
		
		public var X:int;
		public var Y:int;
		
		public function nokta() {
			// constructor code
			
			this.addEventListener(MouseEvent.MOUSE_OVER,kıpırda);
			this.addEventListener(MouseEvent.CLICK,isaretle);
		}
		
		public function kıpırda(e:MouseEvent){
			MovieClip(root).ad.text = ad;
		}
		
		public function isaretle(e:MouseEvent){
			if (deger == 0){
				deger = 1;
				this.gotoAndStop(2);
			}
			else{
				deger = 0; 
				this.gotoAndStop(1);
			}
		}
		
		public function sınır_yenile(){
			var dnek:nokta;
			
		}
	}
	
}
