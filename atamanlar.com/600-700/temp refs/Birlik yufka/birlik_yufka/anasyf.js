// Yazan: Asım Doğan NAMLI

/*  
	Yazara saygı amacıyla lütfen bu dosyayı izinsiz çoğaltmayınız
	Eğer dosya çok lazımsa yazarı asim.dogan.namli@gmail.com adresinden bilgilendirmeniz yeterli olacaktır
*/

var esknok = 0;

var nesneler = new Array;

var yon = "yukarı";
var syc = 0;
var dur = false;

var y = 0;
var ana_y = 0;

// animasyon değiskenleri

var ana_gecikme = 2000;
var gecikme = 10;

var y_azlma = 4;
var y_artma = 4;

// html'den okuncak bilgiler

var kresys = 0; 
var kreyuks = 0;
var kreara = 0;


function basla(){
	var dnek;
	var göster;
	var a,b,c;
	var dönüt;
	var i = 0;
	
	// kare yüksekliği ve ara;
	
	dnek = document.getElementById("m1")
	kreyuks = dnek.offsetHeight;
	
	// Toplam kare sayısı öğrenme şekillendirme
	
	while (!dönüt){
		i += 1;	
		
		dnek = document.getElementById("m" + i)
		
		if (dnek){
			kresys += 1;
			
			a = (i-1) * kreyuks
			b = (i-1) * kreara
			c = a + b 
			
			dnek.style.top = c + "px";
			
		}
		else{
			dönüt = true;
		}
	}
	

	
	
	
    // Nesnelerin tanımlanması
    for (var i = 1; i < kresys + 1; i++)
    {
        nesneler[i] = new nesne(i);
    }
	
	
	setTimeout("beyin('adım')",ana_gecikme);
	
}

function nesne(no){
	
	this.ad = "m" + no;
	
	var nsne = document.getElementById("m" + no);
	
	var y = nsne.offsetTop;
	
	this.ilerle = function(yon) // Hata bekleniyor...
				{
					if (yon == "aşağı"){
						y += y_artma;
					}
					else if (yon == "yukarı"){
						y -= y_azlma;
					}
					nsne.style.top = y + "px";
				}
}

function beyin(durum){ 
	
	var kmt = "";

	if (durum == "ilerleme bitti"){
	
		setTimeout("beyin('adım')",ana_gecikme);
	
	}
	else if (durum == "adım"){
	
		if (y == -((kresys - 2) * kreyuks)){	// Görüntülenen öğe sayısı 3; her bir birimin yüksekliği kreyuks; yandaki formulle max yukarı çıkma koşulu belirleniyor
		
			setTimeout("yuru('aşağı')",gecikme);
			yon = "aşağı";
			
		}
		else if (y == 0)
		{
		
			setTimeout("yuru('yukarı')",gecikme);
			yon = "yukarı";
			
		}
		else
		{
			setTimeout("yuru('" + yon + "')",gecikme);
			
		}
	}
}

function yuru(yon){
	
	var dnek;
	
	if (syc !== parseFloat(kreyuks)){		// kreyuks her nesnenin yüksekliği 
	
		if (yon == "aşağı"){
		
			y += y_artma;
			syc += y_artma;
			
		}
		else if (yon == "yukarı"){
		
			y -= y_azlma;
			syc += y_azlma;
			
		}
		
		for (var i = 1; i < kresys + 1; i++)
		{
		
			dnek = nesneler[i]
			if (dnek){
			
				dnek.ilerle(yon);
				
			}
			
		}
		
		beyin("adım");
	}
	else{
	
		beyin("ilerleme bitti");
		syc = 0;
	}

}

function yonlendir(nereye,no){
	cerceve.location = nereye;
	git(no);
}

 