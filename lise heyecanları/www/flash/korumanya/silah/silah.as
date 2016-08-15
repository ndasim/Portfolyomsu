package silah{
	
	import flash.display.MovieClip;
	import flash.utils.Timer;
	import flash.events.TimerEvent;
	import flash.geom.Point;
	import dusman.dusman;
	import silah.silah;
	import silah.namlu;
	
	
	public class silah extends MovieClip{

		var zamanlayici:Timer;
		var oldurucu:Timer;
		var namlu:silah.namlu;
		var hedef:dusman.dusman;
		
		var kapsama:int = 300; // silahın piksel cinsinden kapsama yarıçapı
		

		public function silah() {
			
		}
		
		public function kur(tip:String,X:Number,Y:Number){
			zamanlayici = new Timer(2);
			
			zamanlayici.addEventListener(TimerEvent.TIMER, kolacan_et);
			zamanlayici.start();
			
			oldurucu = new Timer(2);
			
			oldurucu.addEventListener(TimerEvent.TIMER, oldur);
			
			namlu = new silah.namlu();
			namlu.kur(tip);
			
			namlu.x = 20;
			namlu.y = 20;
			
			this.addChild(namlu);
			this.x = X;
			this.y = Y;
			
			//dondur(10);
		}
		
		function kolacan_et(e:TimerEvent):void{
			// root da bulunan düsmanlar dizisinden silahın belli bölgesine girmiş olan düşmanlar bulunuyor ve sadece ona kilitleniliyor
			// düşman belirli alandan çıkmadığı veya ölmediği sürece kolacan_et() fonksiyonu tekrar çalıştırılmıyor
			
			var dsman:dusman.dusman;
			
			for (var i = 0; i < MovieClip(root).dusmanlar.length; i++){
				dsman = MovieClip(root).dusmanlar[i];
				
				var uzaklık:Number;
				uzaklık = Math.abs(Math.pow(Math.pow(dsman.x - (this.x + 20),2) + Math.pow(dsman.y - (this.y + 20),2),0.5)); // Hipotenüs formülünden düşmanın silaha olan uzaklığı alınıyor 
				
				if (uzaklık < kapsama){ 
					// Düşman silahın kapsama alnındadır //
					// Kitlenme işlemleri yapılıyor //
				
					zamanlayici.stop();
					
					hedef = dsman;
					
					oldurucu.start();
					//trace(dsman.x + " " + dsman.y);
				}
			}
		}
		
		function dondur(hedef:dusman):Boolean {
			
			namlu.rotation = (180 * Math.atan2(hedef.y - this.y - 20,hedef.x - this.x - 20)) / Math.PI ;
			//namlu.rotation = (180 * Math.atan2(hedef.y - namlu.y,hedef.x - namlu.x)) / Math.PI ;
			//trace(hedef.y);
			return true;
		}
		
		function oldur(e:TimerEvent){
			var uzaklık:Number;
			uzaklık = Math.abs(Math.pow(Math.pow(hedef.x - (this.x + 20),2) + Math.pow(hedef.y - (this.y + 20),2),0.5)); // Hipotenüs formülünden düşmanın silaha olan uzaklığı alınıyor 
			
			//trace (Math.pow(hedef.x - (this.x + 20),2));
			//trace ((hedef.y - (this.y + 20)) ^ 2);   
			trace ("( (" + hedef.x + " - " + (this.x + 20) + ") ^ 2 + (" + hedef.y + " - " + (this.y + 20) + ")^2 ) ^ 0.5 =" + uzaklık);
			
			if (uzaklık < kapsama){ 
				// Düşman silahın kapsama alnındadır //
				if (hedef.can > 0){
					// Düşman henüz ölmemiştir //
					// Ateşleme işlemleri yapılıyor //
					dondur(hedef);
					namlu.ates_et();
				}
			}
			else{
				oldurucu.stop();
				zamanlayici.start();
			}
		}

	}
	
}
