package  {
	
	import flash.display.MovieClip;
	import flash.events.MouseEvent;
	
	public class kare_1 extends MovieClip {
		
		public var ad:int;
		
		public function kare_1() {
			// constructor code
			this.addEventListener(MouseEvent.CLICK,tıklatt);
		}
		
		function tıklatt(e:MouseEvent):void{
			MovieClip(root).merkez(ad);
		}
	}
	
}
