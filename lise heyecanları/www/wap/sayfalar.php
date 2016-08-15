<?php 
	ob_start(); 
	include "ortak.php";
	// include "site/sayfala.php";
?>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
	<head>
		<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
		<title>Untitled Document</title>
		<link href="tema/yonetim/uye.css" rel="stylesheet" type="text/css" />
		<script type="text/javascript" language="javascript">

			var baglanti = false;
			var formdata = false;
			var islm_bklme = false;
			
			function baglan() {
				
				if (window.XMLHttpRequest) { // Mozilla, Safari,...
					baglanti = new XMLHttpRequest();
					baglanti = new XMLHttpRequest();
					if (baglanti.overrideMimeType) {
						baglanti.overrideMimeType('text/xml');
						// See note below about this line
					}
				} else if (window.ActiveXObject) { // IE
					try {
						baglanti = new ActiveXObject("Msxml2.XMLHTTP");
					} catch (e) {
						try {
							baglanti = new ActiveXObject("Microsoft.XMLHTTP");
						} catch (e) {}
					}
				}

				if (!baglanti) {
					alert('Lütfen AJAX Desteği Olan Bir Tarayıcıyla Bağlanın');
					return false;
				}
				baglanti.onreadystatechange = function(){donut();};
				
				
			}
			
			function nl2(text){
				// Gereksiz php artık /n/p karekterlerinden temizleme yapımı
				text = escape(text);
				if(text.indexOf('%0D%0A') > -1){
					re_nlchar = /%0D%0A/g ;
				}else if(text.indexOf('%0A') > -1){
					re_nlchar = /%0A/g ;
				}else if(text.indexOf('%0D') > -1){
					re_nlchar = /%0D/g ;
				}
				text = unescape( text.replace(re_nlchar,'') );
				
				// :-adn-: bulunan yerleri /n/p olarak değiştirme;
				text = escape(text);
				if(text.indexOf('%3A-adn-%3A') > -1){
					re_nlchar = /%3A-adn-%3A/g ;
				}
				
				return unescape( text.replace(re_nlchar,'%0D%0A') );
			}
			
			function gonder(){
				
				var formdata = document.forms[0];
				var data = createQuery(document.forms[0]);
				
				//data.append("CustomField", "Ekstra Veri");
				
				baglanti.open('POST','yonet_islem.php?komut=sayfalar', false);
				// header("Content-Type", "charset=utf-8");
				baglanti.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
				baglanti.setRequestHeader("Content-length", data.length);
				baglanti.setRequestHeader("Connection", "close");
				
				baglanti.send(data);
			}
			
			function createQuery(form){ // Alıntıdır www.webmastersitesi.com/javascript/19275-ajax-uygulamalarinda-turkce-karakter-sorunu.htm
				var elements = form.elements;
				var pairs = new Array();

				for (var i = 0; i < elements.length; i++) {

				if ((name = elements[i].name) && (value = elements[i].value))
				pairs.push(escape(name) + "=" + encodeURIComponent(value));
				}
				//pairs.push("param1=1");
				return pairs.join("&");
			}		
			
			function donut() {

				if (baglanti.readyState == 4) {
					if (baglanti.status == 200) {
						
						$donut = nl2(baglanti.responseText);
						alert($donut);
						
						var iframe = document.getElementById("onizleme");
						iframe.src = iframe.src;
					} 
					else {
						alert('Sunucu üzerinde bir hata oluştu. Durum Kodu:' + baglanti.status);
					}
				}

			}
			
			function basla(){
				baglan();
				
				// nesneleme methodu ile sistem menülerininsayfaya yerleştirilmesi
				
				elemanları_diz();
				
			}
			
			function elemanları_diz(){
				// ana giris menüsünün eleman sayısı öğreniliyor
				
				var nsne = document.getElementById('ana_giris_toplam');
				
				var eleman_sayısı = nsne.value;

				for (var i = 1; i <= eleman_sayısı; i++){
					
					// gerekli görüntüleme elemanlarının oluşturulması
					
					var nsne = document.getElementById('ana_giris_table');
					var eleman = document.getElementById('ana_giris_' + i);
					
					nsne.innerHTML += '<tr><td>' + i + '</td><td>' + eleman.value + '</td><td><a href="#" onclick="eleman_duzenle(\'ana_giris\',' + i + ')">Düzenle</a></td></tr>';
					
					// nsne.innerHTML += '<div id="ana_giris_eleman_' + i + '">' + i + '.' +  + '</div>';
				}
			}
			
			function eleman_duzenle(nsne_ad,no){
				
				
				var nsne = document.getElementById(nsne_ad + "_" + no );
				var deger = false;
				
				deger = prompt('Lütfen altdaki kutucuğa yeni ifadeyi yazın',nsne.value);
				
				if (deger != null){
					nsne.value = deger;
				
					var nsne = document.getElementById('ana_giris_table');
					nsne.innerHTML = "";
					
					elemanları_diz();
					
					gonder();
				} 
				else {
					
				}
			}
			
			function nesne(id,no){
				this.ad = id;
				this.nesne = document.getElementById(id);
				this.no = no;
			}
			
		</script>
	</head>
	<body onload="basla()">
		<p class="baslik">Görünen Yazıyı Değiştir</p>
		<form name="form1" action="#" method="post">
			<table>
				<tr>
					<td>Değiştirilecek İfade: </td>
					<td><input name="ifade" type="text"></td>
				</tr>
				<tr>
					<td>Yeni İfade:</td>
					<td><input type="text" name="yeni_ifade"></td>
					<td><a href="#" onclick="gonder()">Gönder</a></td>
				</tr>
				<tr>
					<td rowspan="5">Kurallar:</td>
					<td></td>
				</tr>
				<tr>
					<td colspan="2" style="color:#FF0000;">** Değiştirilmek istenen ifadenin ne başında ne de sonunda boşluk bulunmamalıdır</td>
				</tr>
				<tr>
					<td colspan="2" style="color:#FF0000;">** Değiştirilmek istenen ifade eksiksiz tam cümle oluşturacak biçimde olmalıdır </td>
				</tr>
				<tr>
					<td colspan="2" style="color:#FF0000;">** Değiştirilmek istenen ifade veya sistem içinden alınmış her hangi bir cümle eğer arada sisteme dair(üye ismi,üye id'si,tarih,yorum vs) herhangi bir kelime veya cümle içeriyorsa bu değiştirelcek olan kelime ikiye bölünüp aradaki sistem öğesi atılıp öyle değiştirilmelidir </td>
				</tr>
				<tr>
					<td colspan="2" style="color:#FF0000;">** Değiştirilmek istenen ifade noktalama işaretlerinide içermelidir örneğin en sonda ":" işareti bulunuyorsa bu işaretde seçime alınmalıdır </td>
				</tr>
			</table>
		
		
			<div id="ana_giris_div">
				<p class="baslik">Ana Giriş Öğeleri</p>
				<?php 
				
					// Veri Tabanından İlk giriş sayfasının Text Öğeleri Gösteriliyor
				
					@$sorgu = mysql_query('SELECT * FROM menuler WHERE menu_gurup="ana giriş" and sıra_no ORDER BY "DESC"') or die(mysql_error());

					$str_says = mysql_num_rows($sorgu);
					$i = 0;

					// Menü listesi alınıyor
					while ($dizi = mysql_fetch_array($sorgu)){

						$text = $dizi["menu_text"];
						$id = $dizi["sıra_no"];

						echo '<input name="ana_giris_'.$id.'" id="ana_giris_'.$id.'" type="hidden" value="'.$text.'" >';
						echo '<input name="ana_giris_'.$id.'_i" id="ana_giris_'.$id.'_i" type="hidden" value="'.$id.'" >';
					
						$i++;
					}
					
					echo '<input name="ana_giris_toplam" id="ana_giris_toplam" type="hidden" value="'.$i.'" >';

				?>
				
				<table id="ana_giris_table">
					
				</table>
				
			</div>
			<div id="anasayfa">
				
			</div>
			<div id="altmenu">
				
			</div>
		</form>
		<iframe id="onizleme" src="index.php" height="500"></iframe>
	</body>
</html>
<?php ob_end_flush(); ?>