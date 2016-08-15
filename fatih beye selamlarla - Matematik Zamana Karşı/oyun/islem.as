package  {
	
	import flash.display.MovieClip;
	import flash.text.TextField;
	import flash.text.TextFieldType;
	
	
	public class islem extends MovieClip {
		var sayi1:Number; // islemin ilk sayısı
		var sayi2:Number; // ikinci sayısı
		var sonuc:Number; // sonucu 
		var operator:int; // işlemin operatörü
		var tampon:String = ""; // kontrol esnasındaki tampon, çok şekerdir, hayat kurtarır
		var kilit:Boolean = false; // yanıt verildikden sonra olası gelecek karekterleri engeller
		
		public function islem() {
			txtYanit.text = "";
			//txtIslem.x = 100;
			//txtIslem.appendText(sayi1 + " + " + sayi2 + " = " + sonuc);
			//txtYanit.appendText(sonuc);
		}
		
		public function yeniIslem(op:int,seviye:int){
			switch(seviye){
				case 1:
					sayi1 = RastgeleSayi(0,9);
					sayi2 = RastgeleSayi(0,9);
					break;
				case 2:
					sayi1 = RastgeleSayi(10,20);
					sayi2 = RastgeleSayi(10,20);
					break;
				case 3:
					sayi1 = RastgeleSayi(10,100);
					sayi2 = RastgeleSayi(10,100);
					break;
				case 4:
					sayi1 = RastgeleSayi(100,500);
					sayi2 = RastgeleSayi(100,500);
					break;
			}
			
			trace(op);
			switch (op){ // @var op: operator'ün kısaltması, integer olarak 4 adet + - * /
				case 1: // toplama yapmaca
					trace("toplama yapmayı severigh");
					sonuc = sayi1 + sayi2;
					trace("aranan islem: " + sayi1 + " + " + sayi2 + " = " + sonuc);
					txtIslem.text = sayi1 + " + " + sayi2 + " = ";
					txtYanit.x = txtIslem.x + txtIslem.width + 10;
					durum.x = txtYanit.x + txtYanit.width + 10;
					break;
				case 2:
					trace("subtraction bizim işimiz pampa");
					sonuc = sayi1 - sayi2;
					trace("aranan islem: " + sayi1 + " - " + sayi2 + " = " + sonuc);
					txtIslem.text = sayi1 + " - " + sayi2 + " = ";
					txtYanit.x = txtIslem.x + txtIslem.width + 10;
					durum.x = txtYanit.x + txtYanit.width + 10;
					break;
				case 3:
					trace("biz çarpmayı dersten değil hayatdan öğrendigh");
					sonuc = sayi1 * sayi2;
					trace("aranan islem: " + sayi1 + " x " + sayi2 + " = " + sonuc);
					txtIslem.text = sayi1 + " x " + sayi2 + " = ";
					txtYanit.x = txtIslem.x + txtIslem.width + 10;
					durum.x = txtYanit.x + txtYanit.width + 10;
					break;
				case 4:
					trace(":D ırkçılık yapma oç");
					var sayilar = [2, 3, 4, 5, 7, 10];
					var i = RastgeleSayi(0,5);
					
					sonuc = sayilar[i];
					sayi1 = sayi2 * sonuc;
					trace("aranan islem: " + sayi1 + " / " + sayi2 + " = " + sonuc);
					txtIslem.text = sayi1 + " / " + sayi2 + " = ";
					txtYanit.x = txtIslem.x + txtIslem.width + 10;
					durum.x = txtYanit.x + txtYanit.width + 10;
					break;
				default:
					trace("toplama is a basis step");
					sonuc = sayi1 + sayi2;
					trace("aranan islem: " + sayi1 + " + " + sayi2 + " = " + sonuc);
					txtIslem.text = sayi1 + " + " + sayi2 + " = ";
					txtYanit.x = txtIslem.x + txtIslem.width + 10;
					durum.x = txtYanit.x + txtYanit.width + 10;
					
			}
			txtYanit.text = "";
			//txtIslem.text = sayi1 + " + " + sayi2 + " = " + sonuc;
		}
		
		function RastgeleSayi(minNum:Number, maxNum:Number):Number{
			return (Math.floor(Math.random() * (maxNum - minNum + 1)) + minNum);
		}
		
		public function EkleTestEt(sayi:String){ // Dananın kuyruğu burada kopar, bize bir rakam gelir, bizde bir ona bakar bir de sonuca sonrada karar veririz geleceğe
			if (!kilit){
				tampon += sayi;
				txtYanit.text = tampon;
				if(String(sonuc).length == tampon.length){
					if (sonuc == Number(tampon)){
						// You are the winner
						trace("Nice!");
						Object(root).skorla();
						durum.gotoAndStop(2);
					}
					else{
						durum.gotoAndStop(3);
					}
					
					Object(root).devam();
					kilit = true;
				}
			}
		}
	}
}
