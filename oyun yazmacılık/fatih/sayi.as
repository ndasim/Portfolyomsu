package  {
	
	import flash.display.MovieClip;
	import flash.utils.Timer;
	import flash.events.MouseEvent;
	import flash.events.TimerEvent;
	import flashx.textLayout.formats.Float;
	
	public class sayi extends MovieClip {
		
		var number = 2;
		var end = 0;
		
		var hiz:Number = 0;
		var timer:Timer = new Timer(10,0);
		
		var toFixed:Function = function(number:Number, factor:int) {
			return Math.round(number * factor)/factor;
		}
		
		public function sayi() {
			timer.addEventListener(TimerEvent.TIMER, olay, false, 0, true);
			
			sayi1.x = 0;
			sayi1.y = 0;
			
			sayi2.x = 0;
			sayi2.y = -81;
		}
		
		public function oynat(v){
			trace('ooww yee beybi başlıyoruz hileye');
			timer.start();
			hiz = v;
		}
		
		function olay(e){
			if (hiz > 0){
				sayi1.y = toFixed(sayi1.y + hiz, 100);
				sayi2.y = toFixed(sayi2.y + hiz, 100);
				
				if (sayi1.y > 72){
					sayi1.y = -80 + (sayi1.y - 72);
					
					if (number == 9){
						number = -10;
					}
					number += 1;
					
					sayi1.text = number;
				}
				
				if (sayi2.y > 72){
					sayi2.y = -80 + (sayi2.y - 72);
					
					if (number == 9){
						number = -10;
					}
					number += 1;
					
					sayi2.text = number;
				}
				hiz -= 0.01;
				
				//[[[[[[[[[[[Hangi sayı nerede]]]]]]]]]]]]//
				if (sayi1.y > -20 && sayi1.y < 50){
					sayi1.textColor = 0xFF0000;
					end = sayi1.text;
				}
				else{
					sayi1.textColor = 0x000000;
				}
				
				if(sayi2.y > -20 && sayi2.y < 50){
					sayi2.textColor = 0xFF0000;
					end = sayi2.text;
				}
				else{
					sayi2.textColor = 0x000000;
				}
			}
			else{
				timer.stop();
				MovieClip(root).girdi(end);
			}
		}
	}
}
