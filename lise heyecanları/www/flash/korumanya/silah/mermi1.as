package silah {	
	import flash.display.MovieClip;
	import flash.utils.Timer;
	import flash.events.TimerEvent;
	import dusman.dusman;
	
	public class mermi1 extends MovieClip {
		var zamanla:Timer;
		var vx:Number;
		var vy:Number;

		
		public function mermi1(){
		}
		
		public function basla(hiz_x:Number,hiz_y:Number){
			zamanla = new Timer(2);
			
			zamanla.addEventListener(TimerEvent.TIMER, ilerle);
			zamanla.start();
			
			vx = hiz_x * 2;
			vy = hiz_y * 2;
			
			this.play();
		}
		
		function ilerle(e:TimerEvent){
			this.x += 5;
			//this.y += vy;
			
			//MovieClip(root).dusmanlar
			var dsman:dusman.dusman;
			
			for (var i = 0; i < MovieClip(root).dusmanlar.length; i++){
				dsman = MovieClip(root).dusmanlar[i];
				
				if (this.hitTestObject(dsman.fzksel.hit)){ 
					// Can azaltma ve patlama işlemleri //
					dsman.can_al(1)
					
					this.gotoAndPlay(11); ///
					
					zamanla.stop();
					//this = null;
				}
			}
		}
	}
}
