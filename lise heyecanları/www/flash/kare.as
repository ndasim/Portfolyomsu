package  {
	
	import flash.display.MovieClip;
	import flash.display.Sprite; 
	
	
	public class kare extends MovieClip {
		public var radius = 10;
        public var fillColor = 0xFF0000;
		
		public function kare() {
			// constructor code
		}
		
		public function daire(){
			
			var sprite:Sprite = new Sprite(); 
			
			sprite.graphics.clear();
            sprite.graphics.beginFill(0xFF0000);
            sprite.graphics.drawRect(0, 0, 100, 80);
			sprite.graphics.endFill();
			
			this.addChildAt(sprite, 2);
			
			var sprite1:Sprite = new Sprite(); 
			
			sprite1.graphics.clear();
            sprite1.graphics.beginFill(0x0000ff);
            sprite1.graphics.drawRect(0, 0, 100, 80);
			sprite1.graphics.endFill();
			this.addChildAt(sprite1, 2);
		}
	}
	
}
