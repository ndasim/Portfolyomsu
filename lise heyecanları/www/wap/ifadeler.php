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
				// var data = createQuery(document.forms[0]);
				var data = new FormData(document.forms[0]);
				
				//data.append("CustomField", "Ekstra Veri");
				
				baglanti.open('POST','yonet_islem.php?komut=ifadeler', false);
				// header("Content-Type", "charset=utf-8");
				// baglanti.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
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
						//alert($donut);
						
						nsne = document.getElementById("sonuc");
						nsne.innerHTML = baglanti.responseText;
						
						// var iframe = document.getElementById("onizleme");
						// iframe.src = iframe.src;
					} 
					else {
						alert('Sunucu üzerinde bir hata oluştu. Durum Kodu:' + baglanti.status);
					}
				}

			}
			
			function basla(){
				baglan();
				
				// nesneleme methodu ile sistem menülerininsayfaya yerleştirilmesi
				
				elemanlari_diz();
				
			}
			
			function elemanlari_diz(){
				// ana giris menüsünün eleman sayısı öğreniliyor
				
				var nsne = document.getElementById('gostergec_toplam');
				
				var eleman_sayısı = nsne.value;

				var yukseklik = 30;
				var genislik = 30;
				
				for (var i = 1; i <= eleman_sayısı; i++){
					
					// gerekli görüntüleme elemanlarının oluşturulması
					
					var nsne = document.getElementById('gostergec_table');
					var eleman = document.getElementById('gostergec_' + i);
					var adres = document.getElementById('gostergec_' + i + '_img');
					var genislikk = document.getElementById('gostergec_' + i + '_width');
					var yukseklikk = document.getElementById('gostergec_' + i + '_height');
					
					if (genislikk.value != -1){genislik = genislikk.value;}
					
					if (yukseklikk.value != -1){yukseklik = yukseklikk.value;}
					
					nsne.innerHTML += '<tr><td><img src="' + adres.value + '" height="' + yukseklik + '" width="' + genislik + '"></td><td>' + eleman.value + '</td><td>Boyut : ' + genislik + ' x ' + yukseklik + '</td><td><a href="#" onclick="eleman_duzenle(\'gostergec\',' + i + ')">Düzenle</a></td></tr>';
					
					// nsne.innerHTML += '<div id="gostergec_eleman_' + i + '">' + i + '.' +  + '</div>';
				}
			}
			
			function eleman_duzenle(nsne_ad,i){
				
				var kısayol = document.getElementById('gostergec_' + i);
				var adres = document.getElementById('gostergec_' + i + '_img');
				var genislik = document.getElementById('gostergec_' + i + '_width');
				var yukseklik = document.getElementById('gostergec_' + i + '_height');
				
				window.open("ifade_duzenle.php?kısayol=" + kısayol.value + "&genislik=" + genislik.value + "&yukseklik=" + yukseklik.value);
				
			}
			
			function nesne(id,no){
				this.ad = id;
				this.nesne = document.getElementById(id);
				this.no = no;
			}
			
		</script>
	</head>
	<body onload="basla()">
		<p class="baslik">Yeni İfade Ekle</p>
		<form enctype="multipart/form-data" method="POST">
			<table>
				<tr>
					<td>Resimin dosyası: </td>
					<td><input name="ifade" type="file"></td>
				</tr>
				<tr>
					<td>İfadenin kısayolu:</td>
					<td><input type="text" name="yeni_ifade"></td>
				</tr>
				<tr>
					<td>Genişlik: <input name="genislik" type="text" value="30"></td>
					<td>Yükseklik:<input name="yukseklik" type="text" value="30"></td>
				</tr>
				<tr>
					<td><a href="#" onclick="gonder()">Gönder</a></td>
				</tr>
				<tr>
					<td rowspan="5">Kurallar:</td>
					<td></td>
				</tr>
				<tr>
					<td colspan="2" style="color:#FF0000;">** Dosya kesinlikle resim dosyası olmalıdır</td>
				</tr>
				<tr>
					<td colspan="2" style="color:#FF0000;">** Kısayol yazarken "." ve " " işareti kullanılmamalıdır </td>
				</tr>
				<tr>
					<td colspan="2" style="color:#FF0000;">** Boyut Kısmı Boş Kalabilir </td>
				</tr>
			</table>
		
		
			<div id="gostergec_div">
				
				<?php 
				
					// Veri Tabanından İlk giriş sayfasının Text Öğeleri Gösteriliyor
				
					@$sorgu = mysql_query('SELECT * FROM ifadeler') or die(mysql_error());

					$str_says = mysql_num_rows($sorgu);
					$i = 0;

					echo "a";
					
					// Menü listesi alınıyor
					while ($dizi = mysql_fetch_array($sorgu)){

						$kısayol = $dizi["kısayol"];
						$adres = $dizi["adres"];
						
						$genislik = $dizi["genislik"];
						$yukseklik = $dizi["yukseklik"];
						
						echo '<input name="gostergec_'.$i.'" id="gostergec_'.$i.'" type="hidden" value="'.$kısayol.'" >';
						echo '<input name="gostergec_'.$i.'_i" id="gostergec_'.$i.'_img" type="hidden" value="'.$adres.'" >';
						echo '<input name="gostergec_'.$i.'_i" id="gostergec_'.$i.'_height" type="hidden" value="'.$yukseklik.'" >';
						echo '<input name="gostergec_'.$i.'_i" id="gostergec_'.$i.'_width" type="hidden" value="'.$genislik.'" >';
						
						$i++;
					}
					
					echo '<input name="gostergec_toplam" id="gostergec_toplam" type="hidden" value="'.$i.'" >';

				?>
				
				<table id="gostergec_table">
					<thead>
						<tr>
							<td>İfade Resmi</td>
							<td>İfade Kısayolu</td>
							<td>İfade Boyuları</td>
							<td>İşlem</td>
						</tr>
					</thead>
					<tbody>
						
					</tbody>
				</table>
				<div id="sonuc">
				</div>
				
			</div>
		</form>
	</body>
</html>
<?php ob_end_flush(); ?>