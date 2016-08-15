package  {
	
	import flash.display.MovieClip;
	import flash.events.MouseEvent;
	import flash.display.Graphics;
	import flash.display.Sprite;
		
	public class nokta extends MovieClip {
		public var ad:int;
		public var gurup:int;
		
		public var X:int;
		public var Y:int;
		
		public function nokta() {
			// constructor code
			this.addEventListener(MouseEvent.CLICK,tıklatt);
		}
		
		public function tıklatt(e:MouseEvent):void{
			MovieClip(root).merkez(gurup);
		}

		public function kıpırda(){
			this.gotoAndPlay(1);
		}
		
		public function sınır_yenile(){
			var dnek:nokta;
			
			/* 
				root içindeki noktalar dizisi içinden nokta sağ,sol,üst ve aşağısında kalan noktaların gurup 
				adları kontrol edilir farklı bir grup adıyla karşılaşıldığında veya nokta bulunamadığında kontroledilen nokta ile 
				araya bir sınır çizdigisi konulur 
			*/
			
			var sprite:Sprite = new Sprite(); 
			
			sprite.graphics.clear();
            sprite.graphics.lineStyle(2,0);
			
			// Sağ yanın kontrol edilmesi;
			if (X + 1 < MovieClip(root).genislik){
				
				dnek = MovieClip(root).noktalar[X][Y];
				if (dnek.gurup != this.gurup){
					trace (ad + "için sağ tarafta grupdaş bulunmamaktadır");
					sprite.graphics.moveTo(MovieClip(root).kre_gnslk, 0);
					sprite.graphics.lineTo(0, MovieClip(root).kre_yuks);
				}
			}
			
			
			//Sol yanın kontrol edilmesi;
			if (X - 1 > 0){
				
				dnek = MovieClip(root).noktalar[X - 1][Y];
				if (dnek.gurup != this.gurup){
					trace (ad + "için sol tarafta grupdaş bulunmamaktadır");
					sprite.graphics.moveTo(0, 0);
					sprite.graphics.lineTo(0, MovieClip(root).kre_yuks);
				}
			}
			
			//Üst tarafın kontroledilmesi
			if (Y - 1 > 0){
				
				dnek = MovieClip(root).noktalar[X][Y - 1];
				if (dnek.gurup != this.gurup){
					trace (ad + "için üst tarafta grupdaş bulunmamaktadır");
					sprite.graphics.moveTo(0, 0);
					sprite.graphics.lineTo(MovieClip(root).kre_gnslk, 0);
				}
			}
			
			// Alt tarafın kontroledilmesi
			if (Y + 1 < MovieClip(root).yukseklik){
				
				dnek = MovieClip(root).noktalar[X][Y + 1];
				if (dnek.gurup != this.gurup){
					trace (ad + "için alt tarafta grupdaş bulunmamaktadır");
					sprite.graphics.moveTo(0, MovieClip(root).kre_yuks);
					sprite.graphics.lineTo(0, MovieClip(root).kre_yuks);
				}
			}
			
			this.addChild(sprite);
			trace (ad + "için sınır kontrolü sağlandı");
		}
	}
	
}
