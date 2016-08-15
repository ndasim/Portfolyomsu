package dusman{
	import flash.display.MovieClip;
	import flash.geom.Point;
	import dusman.dusman;
	import flash.utils.Timer;
	import flash.events.TimerEvent;
	
	public class dusman extends MovieClip{
		public var fzksel:MovieClip;
		//public var x:Number = 0;
		//public var y:Number = 0;
		
		var koordinat:Point = new Point(0,0);
		
		var zamanla:Timer;
		
		public var can = 100;
		
		
		public function dusman(ad:String,X:Number,Y:Number,ebeveyn:MovieClip) {
			if (ad == "basitcan"){
				// düsmanın olusturulması //
				fzksel = new dusman_1;
				
				this.x = X;
				this.y = Y;
				
				koordinat.x = X;
				koordinat.y = Y;
				
				x = X;
				y = Y;
				
				this.addChild(fzksel);
				ebeveyn.addChild(this);
			}
			
			zamanla = new Timer(2);
			
			zamanla.addEventListener(TimerEvent.TIMER, ilerle);
			zamanla.start();
		}
		
		function ilerle(e:TimerEvent){
			this.x = MovieClip(root).farex;
			//fzksel.x = mouseX;
			
			this.y = MovieClip(root).farey;
			//fzksel.y = mouseY;
			
			MovieClip(root).ad.text = mouseX;
		}
		
		public function uzaklık_al(x:Number,y:Number){
			var donut:Number;
			
			donut = (((x - koordinat.x) ^ 2) + ((y - koordinat.y) ^ 2)) ^ 0.5;
			
			return donut;
		}
		
		public function can_al(deger:Number){
			
		}
	}
}
