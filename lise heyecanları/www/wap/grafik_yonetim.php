<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
	<head>
		<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
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
			
			function gonder(form,url){
				
				var formdata = document.forms[0];
				// var data = createQuery(form);
				var data = new FormData(document.forms[0]);
				
				//data.append("CustomField", "Ekstra Veri");
				
				baglanti.open('POST', url, false);
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
				pairs.push(bosluk(name) + "=" + encodeURIComponent(value));
				}
				//pairs.push("param1=1");
				return pairs.join("&");
			}
			
			function bosluk(giris){
				var re_nlchar;
				
				// %20 bulunan yerleri :adn: olarak değiştirme;
				text = escape(giris);
				if(text.indexOf('%20') > -1){
					re_nlchar = /%20/g ;
				}
				
				return unescape( text.replace(re_nlchar,'%3Aadn%3A') );
			}

			function PostData(formlar){
				var getstr = "";
				for (i=0; i<formlar.elements.length; i++) {
					if (formlar.elements[i].tagName == "INPUT") {
						if (formlar.elements[i].type == "text" || formlar.elements[i].type == "password") {
							getstr += formlar.elements[i].name + "=" + escape(formlar.elements[i].value) + "&";
						}
						if (formlar.elements[i].type == "checkbox") {
							if (formlar.elements[i].checked) {
								getstr += formlar.elements[i].name + "=" + escape(formlar.elements[i].value) + "&";
							} 
						}
						if (formlar.elements[i].type == "radio") {
							if (formlar.elements[i].checked) {
								getstr += formlar.elements[i].name + "=" + escape(formlar.elements[i].value) + "&";
							}
						}
						if (formlar.elements[i].type == "hidden") {
							getstr += formlar.elements[i].name + "=" + escape(formlar.elements[i].value) + "&";
						}
					}   
					if (formlar.elements[i].tagName == "SELECT") {
						var sel = formlar.elements[i];
						getstr += sel.name + "=" + escape(sel.options[sel.selectedIndex].value) + "&";
					}
					if (formlar.elements[i].tagName == "TEXTAREA") {
						var sel = formlar.elements[i];
						getstr += sel.name + "=" + escape(formlar.elements[i].value) + "&";
					}
				}
				
				return getstr;
			}			
			
			function donut() {

				if (baglanti.readyState == 4) {
					if (baglanti.status == 200) {
						$donut = nl2(baglanti.responseText);
						
						// Sunucudan gelen yanıt kontrol ediliyor eğer olumsuz sonuç çıkarsa kullanıcıya açıklama mesajı iletiliyor
						if (islm_bklme){
						
							if (islm_bklme == 1){
								//alert("Kaydetme Başarılı");
								alert($donut);
							}
							else if (islm_bklme == 2){
								alert($donut);
							}
							else if (islm_bklme == 6){
								//alert("Varsayılan Temanız Başarıyla Değiştirilmiştir");
								alert($donut);
							}
							else if (islm_bklme == 8){
								islem(5); // Tema verisi yenileniyor...
							}
							else if (islm_bklme == 9){
								var nsne = document.getElementById("tema");
								nsne.innerHTML = $donut; //
							}
							else if (islm_bklme == 3){
									// alert("Yeni Tema Kaydı Başarılı");
									//alert($donut);
									var nsne = document.getElementById("tema");
									
									$dizi = $donut.split(":_adn_:");
									
									if ($dizi.length == 1){
										nsne.innerHTML = $dizi[0];
									}
									else if ($dizi.length == 2){
										alert($dizi[1]);
										nsne.innerHTML = $dizi[0];
									}
									else if ($dizi.length == 3){
										alert($dizi[2]);
									}
									
									//nsne.innerHTML = $donut;  
							}
							else if (islm_bklme == 4){
									var nsne = document.getElementById("tema");
									
									//alert("Seçili Tema Başarıyla Silinmiştir");
									
									$dizi = $donut.split(":_adn_:");
									
									if ($dizi.length == 1){
										nsne.innerHTML = $dizi[0];
									}
									else if ($dizi.length == 2){
										alert($dizi[0]);
										nsne.innerHTML = $dizi[1];
									}
									nsne.value = "varsayılan"; //
									
									islem(5); // Tema verileri yenileniyor
							}
							else if(islm_bklme == 5){
								var nsne = document.getElementById("tema_degisken");
								nsne.innerHTML = $donut;
							}
							/*
							else{
								// Geri Dönüt Yapılıp Hata mesajı Sunucudan İsteniyor
								islm_bklme = false;
								
								baglanti.open("GET","yonet_islem.php?komut=hata_mesaji",false);
								baglanti.send(null);
							}
							*/
						}
						else{
							alert($donut);
						}
						
						
					} else {
						alert('Sunucu üzerinde bir hata oluştu. Durum Kodu:' + baglanti.status);
					}
				}

			}
			
			function islem(deger){
				islm_bklme = deger;
				
				var nsne = document.getElementById("islem");
				nsne.value = deger;
				
				var form = document.getElementById("form1");
				gonder(form,"yonet_islem.php?komut=grafik");
				
				
			}
			
			function degis(){
				var nsne = document.getElementById("tema");
				var hidden = document.getElementById("asil_tema");
				var varsylan = document.getElementById("grafik_varsylan");
				
				if (nsne.value == hidden.value){
					varsylan.checked = true;
				}
				else{
					varsylan.checked = false;
				}
				
				// Sunucuya Bildirme
				islem(5);
			}
			
			function b(){
				var nsne = document.getElementById("grafik_varsylan");
				
				if (nsne.checked){
					nsne.checked = true; // Durum Değişimi Engelleniyor
				}
				else{
					islem(6);
				}
			}
			
			
		</script>
	
	</head>
	<body onload="baglan()" >
		
		<div style="">
			<form enctype="multipart/form-data" method="POST">
				<div id="tema_degisken">
					<?php
						// Ön Yükleme...
						include "ortak.php";
						include "site/guvenlik.php";
						
						echo '<b class="baslik">Tema CSS Kuralları</b>';
						
						if (isset($_GET["tema"])){
							$tema_ad = $_GET["tema"];
						}
						else{
							// Varsayılan Temanın Öğrenilmesi 
							
							$sorgu = mysql_query('SELECT * FROM sistem WHERE ad="tema"');
							$sonuc = mysql_result($sorgu,0,"deger");
							
							$tema_ad = $sonuc;
						}
						
						// veritabanından verilerin Çekilmesi
						$sorgu = mysql_query('SELECT * FROM tema_veri WHERE tema_ad="'.$tema_ad.'"');
						
						// Tablonun Doldurulması;
						
						echo "<table>";
						
						
						while ($dizi = mysql_fetch_array($sorgu)){
							
							echo '
									<tr>
										<td>'.$dizi["kural"].'</td>
										<td>
											<textarea name="css'.$dizi["kural"].'" rows="5" cols="61">'.$dizi["komut"].'</textarea>
											<input type="hidden" name="tur'.$dizi["kural"].'" value="'.$dizi["tur"].'">
										</td>
									</tr>
								';
						
						}
						echo "</table>";
					
						echo '<b class="baslik">Tema Arayüz Resimleri</b>';
								
						// veritabanından verilerin Çekilmesi
						$sorgu = mysql_query('SELECT * FROM tema_kaynak WHERE tema_ad="'.$tema_ad.'"');
						
						// Tablonun Doldurulması;
						
						echo "<table>";
						
						while ($dizi = mysql_fetch_array($sorgu)){
							
							echo '
									<tr>
										<td><img src="'.$dizi["adres"].'" class="baslik" height="20" width="20"></td>
										<td width="100">'.$dizi["nesne"].'</td>
										<td><input type="file" name="dosya'.$dizi["nesne"].'"></td>
									</tr>
								';
						
						}
						echo "</table>";
					?>
				</div>
				<div style="position:absolute; left: 640px; top: 55px; width: 300px; height: 500px;">
					<input type="hidden" id="islem" name="islem" value="">
					<table>
						<tr>
							<td>Tema Seç:</td>
							<td><select id="tema" name="tema" onchange="degis()">
								<?php 
									// temalar tablosundan tema adları alınıyor...
									$sorgu = mysql_query('SELECT * FROM temalar');
									$i;
									$ek = "";
									
									$secili = "";
									
									// Varsayılan tema öğreniliyor
									$altsorgu = mysql_query('SELECT * FROM sistem WHERE ad="tema"');
									$tema = mysql_result($altsorgu,0,"deger");
									
									// Teker teker tema adları <option> etiketine sarılarak yazdırılıyor
									while($ad = mysql_fetch_array($sorgu)){
										
										if ($ad["tema_ad"] == $tema){
											echo $tema;
											$ek = 'selected="selected"'; // otomatik olarak seçili ggörünmesi için
											$secili = $ad["tema_ad"]; // bir alt betikte kullanmak için
										}
										else{
											$ek = "";
										}
										
										echo '
											<option '.$ek.' value="'.$ad["tema_ad"].'">'.$ad["tema_ad"].'</option>
										';
									}
								?>
								<!-- <option selected="selected" value="1">Varsayılan</option> -->
							</select></td>
							<input type="hidden" id="asil_tema" value="<?php echo $secili; ?>">
						</tr>
						<tr>
							<td><div align="right" style="border:none;"><input id="grafik_varsylan" type="checkbox" name="varsayilan" style="text-align:right;" onclick="b()" checked></div></td>
							<td><div align="left" style="border:none;">Varsayılan Olsun</div></td>
						</tr>
						<tr height="5">
							<td colspan="2"></td>
						</tr>
						<tr>
							<td colspan="2" style="border-bottom:1px solid #F1C100"></td>
						</tr>
						<tr height="5">
							<td colspan="2"></td>
						</tr>
						<tr>
							<td colspan="2"><a href="#" onclick="islem(1)">Değişiklikleri Kaydet</a></td>
						</tr>
						<tr height="5">
							<td colspan="2"></td>
						</tr>
						<tr>
							<td colspan="2" style="border-bottom:1px solid #F1C100"></td>
						</tr>
						<tr height="5">
							<td colspan="2"></td>
						</tr>
						<tr>
							<td colspan="2">Farklı Kaydet:</td>
						</tr>
						<tr>
							<td colspan="2"><input type="text" name="yeniad"><a href="#" onclick="islem(3)">Kaydet</a></td>
						</tr>
						<tr height="5">
							<td colspan="2"></td>
						</tr>
						<tr>
							<td colspan="2" style="border-bottom:1px solid #F1C100"></td>
						</tr>
						<tr height="5">
							<td colspan="2"></td>
						</tr>
						<tr>
							<td colspan="2"><a href="#" onclick="islem(2)">Tek Oturumluk Test Et</a></td>
						</tr>
						<tr height="5">
							<td colspan="2"></td>
						</tr>
						<tr>
							<td colspan="2" style="border-bottom:1px solid #F1C100"></td>
						</tr>
						<tr height="5">
							<td colspan="2"></td>
						</tr>
						<tr>
							<td colspan="2"><a href="#" onclick="islem(4)">Bu Temayı Sil</a></td>
						</tr>
						<tr height="5">
							<td colspan="2"></td>
						</tr>
						<tr>
							<td colspan="2" style="border-bottom:1px solid #F1C100"></td>
						</tr>
						<tr height="5">
							<td colspan="2"></td>
						</tr>
						<tr>
							<td colspan="2">Kural Ekle:</td>
						</tr>
						<tr>
							<td colspan="2">Seçici<input type="text" name="yeni_komut_adi"><br />
							Seçici türü:<input type="text" name="yeni_komut_tur"><br /><a href="#" onclick="islem(8)">Ekle</a></td>
						</tr>
						<tr height="5">
							<td colspan="2"></td>
						</tr>
					</table>
					<!--<a href="#" onclick="islem(1)">Önizleme</a>
					<a href="#" onclick="islem(2)">Kaydet</a> -->
				</div>
				
			</form>
		</div>
	</body>
</html>










































