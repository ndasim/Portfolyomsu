package {
	
	import flash.display.MovieClip;
	import flash.geom.Point;

	
	public class yol_bul extends MovieClip {
					
		var baslama_nok:Array;
		var bitis_nok:Array;
		
		public function yol_bul() {
			// constructor code
		}
		
		function fiziksel_uzklk(nokta:Point){
			var donut:Number;
			
			return donut;
		}
		
		function sırala(nok:Array){
			/*var COUNTRIES : Array = 
				[ { short:"AD",long:"Andorra"}, 
				  {short:"AE", long:"United Arab Emirates"}, 
				  {short:"AF", long:"Afghanistan"}// and so forth
				];
			
			COUNTRIES.sortOn ("long"); // sorts by long name
			COUNTRIES.sortOn ("short"); // sorts by short name*/
		}
		
		function yolu_bul(baslama:Point,bitis:Array){
			var donut:Array;
			var noktalar:Array;
			
			var yeni_nok:Point;
			
			var uzaklık:int;
			
			// verilen baslangıc noktasını yan noktaları taranır ve en en yakın nokta tekrar aynı islemlerden gecerilir taaki bitis nok bulunana kadar;
			
			// üst_noktanın fzksel noktası alınıyor ve listeye ekleniyor
			yeni_nok = new Point(baslama.x,baslama.y - 1);
			uzaklık = fiziksel_uzklk(yeni_nok);
			
			if (yeni_nok.y < 0 && uzaklık == -1){
				
				if(noktalar[int(yeni_nok.x)] === undefined){
					noktalar[int(yeni_nok..x)] = [];
					noktalar[int(yeni_nok.x)][int(yeni_nok.y)] = uzaklık;
				}
				
			}
			
		}
		
		
	}
}