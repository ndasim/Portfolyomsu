
var sill = true;

var dizn = Array(); 

function basla(){
	
	document.body.innerHTML += '<div id="gosterr"></div>';
	
	// p nesneleri
	
	dizn["form"] = document.getElementsByTagName("form"); 
	dizn["p"] = document.getElementsByTagName("p"); 
	dizn["a"] = document.getElementsByTagName("a");
	dizn["b"] = document.getElementsByTagName("b");
	dizn["div"] = document.getElementsByTagName("div");
	dizn["img"] = document.getElementsByTagName("img");
	dizn["table"] = document.getElementsByTagName("table");
	dizn["td"] = document.getElementsByTagName("td");
	dizn["tr"] = document.getElementsByTagName("tr");
	
	// hepsine onload ekleme
	
	var i = 0;
	var islencek;
	
	for (i=0;i <= dizn["form"].length - 1;i++){
		var nsne = dizn["form"][i];
		
		nsne.onclick = bende;
	}
	for (i=0;i < dizn["p"].length - 1;i++){
		var nsne = dizn["p"][i];
		
		nsne.onclick = bende;
	}
	for (i=0;i <= dizn["a"].length - 1;i++){
		var nsne = dizn["a"][i];

		nsne.onmousemove = bende;
	}
	for (i=0;i <= dizn["div"].length - 1;i++){
		var nsne = dizn["div"][i];

		nsne.onclick = bende;
	}
	for (i=0;i <= dizn["b"].length - 1;i++){
		var nsne = dizn["b"][i];

		nsne.onclick = bende;
	}
	for (i=0;i <= dizn["img"].length - 1;i++){
		var nsne = dizn["img"][i];

		nsne.onclick = bende;
	}
	for (i=0;i <= dizn["table"].length - 1;i++){
		var nsne = dizn["table"][i];

		nsne.onclick = bende;
	}
	for (i=0;i <= dizn["td"].length - 1;i++){
		var nsne = dizn["td"][i];

		nsne.onclick = bende;
	}
	for (i=0;i <= dizn["tr"].length - 1;i++){
		var nsne = dizn["tr"][i];

		nsne.onclick = bende;
	}
}


function sil(){
	if (sill){
		document.forms[0].ara.value = "";
		sill = false;
	}
}	
function bende(e){
	var nsne = document.getElementById('gosterr');
	
	var dallanma = aile(e.target);
	
	nsne.innerHTML = 'nesnenin sınıfı: ' + e.target.className + ' | nesnenin adı: ' + e.target.id + ' | nesnenin tag adı: ' + e.target.tagName + ' | Daha ayrıntılı dallanma: ' + aile(e.target); 
}

function aile(nsne){
	var tara = true;
	var donut = "";
	
	var nesne;
	
	nesne = nsne;
	
	
	while (tara){
		if (nesne.parentElement != document.body){
			
			if (nesne.parentElement.className != ""){
				donut += " " + nesne.parentElement.className;
			}
			else if (nesne.parentElement.id != ""){
				donut += " " + nesne.parentElement.id;
			}
			else{
				donut += " " + nesne.parentElement.tagName;
			}
			
			nesne = nesne.parentElement;
		}
		else{
			tara = false;
		}
	}
	
	donut += " " + nsne.tagName;
	
	return donut;
}










