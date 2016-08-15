package silah{
	import fl.controls.BaseButton;
	import flash.display.MovieClip;
	
	public class namlu extends MovieClip {
	
		var tip:String;
		var sayac = 0;
		
		public function namlu() {

		}
		
		function kur(tipp:String){
			if (tipp == "basit"){
				
				var nsne:basit_namlu = new basit_namlu();
				nsne.x = 0;
				nsne.y = 0;
				
				this.addChild(nsne);
				tip = tipp;
			}
			
		}
	
		public function ates_et(){
			sayac += 1;
			var vx:Number;
			var vy:Number;
			
			var angle = this.rotation * Math.PI / 180 ;
			
			vx = Math.cos(this.rotation);
			vy = Math.sin(this.rotation);
			
			//trace(vx + " " + vy);
			
			if (sayac > 10){
				if (tip == "basit"){
					var mermi:mermi1 = new mermi1();
					
					mermi.x = 20;
					
					this.addChild(mermi);
					mermi.basla(vx,vy);
				}
				
				sayac = 0;
			}
		}
	}
}
