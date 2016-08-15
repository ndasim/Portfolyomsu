// Yazan: Asım Doğan NAMLI

/*  
	Yazara saygı amacıyla lütfen bu dosyayı izinsiz çoğaltmayınız
	Eğer dosya çok lazımsa yazarı asim.dogan.namli@gmail.com adresinden bilgilendirmeniz yeterli olacaktır
*/

var esknok = 0;

var nsne;
var nsne1;
var cerceve;
var altoklava;

var pncyuks = 0;
var oklava_y = 0;

var kapalı = false;
var durum = "yüklü";
var gidilckurl = "";

var yol = 0;

var x = 0;
var x1= 0;

var calısyor = false; 

function basla(){
	
	nsne = document.getElementById("menuodak");
	nsne1 = document.getElementById("isaret");
	cerceve = document.getElementById("pncere");
	altoklava = document.getElementById("altoklava")
	
	oklava_y = altoklava.offsetTop;
	pncyuks = cerceve.offsetHeight;
	x = nsne.offsetLeft; 
	x1 = nsne1.offsetLeft;
}

function git(nereye){
	if (calısyor == false){ 
		yol =  (nereye * 160) - (esknok * 160) ; 
		esknok = nereye;
		calısyor = true;	
		isle();
	}
	else{
		setTimeout("git(" + nereye  + ")",100); // Hata Bekleniyor...
	}
}

function git_a(nereye){
	nsne1.style.left = (x1 + (nereye*160)) + "px";
}

function isle(){
	if (yol > 0){
		x += 5;
		yol -= 5;
		setTimeout("isle()",1);
	}
	else if (yol < 0){
		x -= 5;
		yol +=5;
		setTimeout("isle()",1);
	}
	else{
		calısyor = false;
	}
	nsne.style.left = x + "px";
}

function yonlendir(nereye,no){

	gidilckurl = nereye;
	kapat();
	
	git(no);
}

// iFrame şekillendirme...

function kapat(){
	if (kapalı == false){
		if (pncyuks > 0){
			pncyuks -= 10;
			oklava_y -= 10;
			
			altoklava.style.top = oklava_y + "px";
			cerceve.style.height = pncyuks + "px";
			setTimeout("kapat()",10);
		}
		else{
			kapalı = true;
			yonlen();
			
		}
	}
}

function yonlen(){
	cerceve.src = gidilckurl;
	kontrol();
}

function ac(){
	if (kapalı == true){
		if (pncyuks < 500){
			pncyuks += 10;
			oklava_y += 10;
			
			altoklava.style.top = oklava_y + "px";
			cerceve.style.height = pncyuks + "px";
			setTimeout("ac()",10);
		}
		else{
			kapalı = false;
		}
	}
}

function kontrol(){
	if (cerceve.ownerDocument.readyState == "complete"){
		ac();
	}
	else {
		setTimeout("kontrol()",100)
	}
	
}









 