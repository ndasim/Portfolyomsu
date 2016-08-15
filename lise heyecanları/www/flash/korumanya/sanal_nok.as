package  {
	
	import flash.display.MovieClip;
	import flash.geom.Point; 
	
	
	public class sanal_nok extends MovieClip {
		
		public var yol:Array;
		public var nok:Point;
		public var m_uzaklk:Number;
		
		public function sanal_nok(pos:Point,hedef:Point) {
			nok = pos;
			m_uzaklık = ((hedef.x - nok.x) ^ 2 + (hedef.y - nok.y)^2) ^ 0.5
		}
	
		public function hesapla(isteyen:Point,sonnok:Point){
		
			var sn_array:Array;
			
			var list:Array = new Array;
			
			list.push(new sanal_nok(new Point(nok.x + 1,nok.y))); // sağ nokta için
			list.push(new sanal_nok(new Point(nok.x - 1,nok.y))); // sol nokta için
			list.push(new sanal_nok(new Point(nok.x,nok.y + 1))); // üst nokta için
			list.push(new sanal_nok(new Point(nok.x,nok.y - 1))); // alt nokta için
			
			var nok_list:Array;
			
			var dur:Boolean;
			
			var byk_deger:int;
			var i:int;
			
			var nsne:sanal_nok;
			var byk_nsne:sanal_nok;
			
			var tara:Boolean = true;
			/* 
				Öncelikli olarak fonksiyona verilen noktanın isteyen hariç tüm yönlerindeki noktaları bir hesaplama sırasına sokmaktır
				hesaplama sırasına sokulan noktalar sırası ile ile taratılır tek kural bir üst sıradaki nokta hedefe ulaşmış ise diğer noktaslar hesaplanmaz
			*/
			
			// 3 farklı nokta bir birilerine göre uzunlukça kıyaslanacaklar ve nok_list'e eklenecekler
			
			byk_deger = 0;
			
			var nkta:nokta = MovieClip(root).noktalar[nok.x][nok.y];
			
			if (nkta.deger == 0){
				
				sn_array = new Array(this)
				
				if (nok.x != sonnok.x && nok.y != sonnok.y){
				
					for (var ii = 0; ii < 4; ii++){
						
						for (var i = 0; i < 4; i++){
							nsne = list[i];
							
							if (nsne.m_uzaklk > byk_deger){
								byk_nsne = nsne;
								byk_deger = nsne.m_uzaklk;
								list.splice(i - 1,1); // sonucu yanıltabilir...
							}
						}
						if (byk_nsne.pos.x != isteyen.x && byk_nsne.y != isteyen.y){
							nok_list.push(byk_nsne);
						}
					}
					
					// elde edilen nok_list'in başındaki elemandan başlatılarak hata durumuna göre hesaplatılıyor
					
					nsne = nok_list[0]
					list = nsne.hesapla(nok,sonnok);
					
					if (nsne.hesapla != undefined){
						sn_array.concat(list)
					}
				}
			}
		}
	}
	
}
