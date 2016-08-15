<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
	<head>
		<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
		<link href="tema/yonetim/uye.css" rel="stylesheet" type="text/css" />
		
		<script type="text/javascript" language="javascript">

			var baglanti = false;
			var formdata = false;
			
			var odaidd = false;
			
			var say = true;
			
			var i = 0;
			var yenileme_index = 0;
			
			var kilitid = false;
			
			function baglan() {
				
				odaidd = document.getElementsByName("odaid");
				
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
				
			function gonder(form,url){
				
				var formdata = document.forms[0];
				var data = PostData(form);
				
				//data.append("CustomField", "Ekstra Veri");
				
				baglanti.open('POST', url, false);
				
				baglanti.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
				baglanti.setRequestHeader("Content-length", data.length);
				baglanti.setRequestHeader("Connection", "close");
				
				baglanti.send(data);
				
				yenile();
			}
				
			function donut() {

				if (baglanti.readyState == 4) {
					if (baglanti.status == 200) {
						// document.body.innerHTML += baglanti.responseText;
						// verilen kilitid'e ait div etiketi bulunup içeriği response verisiyle dolduruluyor...
						// alert(baglanti.responseText);
						if (kilitid){
							var nsne = document.getElementById(kilitid + "div");
							nsne.innerHTML = nl2(baglanti.responseText);
							
							// alert(baglanti.responseText);
							// Kilitid sıfırlanıyor yazma sırasında görüntüye post 'dan dönen veriler yazdırmaması için...,
							
							kilitid = false;
							
							yenile(); // Bir sonraki odanın yenilenmesi sağlanıyor...
						}
						
						
					} else {
						alert('Sunucu üzerinde bir hata oluştu. Durum Kodu:' + baglanti.status);
					}
				}

			}
			
			function nl2(text){ // Alıntıdır orjinali nl2br
				text = escape(text);
				if(text.indexOf('%0D%0A') > -1){
					re_nlchar = /%0D%0A/g ;
				}else if(text.indexOf('%0A') > -1){
					re_nlchar = /%0A/g ;
				}else if(text.indexOf('%0D') > -1){
					re_nlchar = /%0D/g ;
				}
				return unescape( text.replace(re_nlchar,'') );
			}
			
			function deger(odaid,deger){
				
				var nsne = document.getElementById(odaid + "islem");
				nsne.value = islem;
				
				var form = document.getElementById(odaid + "form");
				
				gonder(form,"yonet_islem.php?komut=sohbet_oda");
				
				yenile();
			}
			
			function yaz(odaid){
				form = document.getElementById("form" + odaid);
				gonder(form,"yonet_islem.php?komut=oda_yaz");
				yenile();
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
			
			function yenile(){
				var odaid = "";
				
				// Adım Adım Sırasıyla bütün odalar yenilendikten sonra 20 sn içinde tekrar yenilenme yapılıyor...  

				say = false; // Sayaç durduruluyor ve bütün odaların yenilenmesine odaklanılıyor...
				i = 0; // Sayaç sıfırlanıyor...
				
				// Get metoduyla odanın mesaj geçmişi ajax ile çağrılıyor yenileme index 1 artırılıyor
				
				
				if (yenileme_index < (odaidd.length)){
					odaid = odaidd[yenileme_index];
					odaid = odaid.value; // odanın hidden nesnesinden alınan id'si
					
					// dönüt odaid'si belirtilen form'a yönlendiriliyor
					kilitid = odaid
						
					yenileme_index += 1;
					baglanti.open("GET", "yonet_islem.php?komut=oda_veri&odaid=" + odaid, true)
					baglanti.send(null);
				}
				else{
					yenileme_index = 0;
				}
				
				i = 0;
			}
			
			function sayac(){
				i += 1;
				if (say){
					setInterval('sayac()',10);
				}				
			}
			
			function islem(formid,islem){
				var nsne = document.getElementById(formid + "islem");
				nsne.value = islem;
				
				var form = document.getElementById(formid + "form");
				gonder(form,"yonet_islem.php?komut=sohbet_oda");
				
			}
			
		</script>
	</head>
	<body onload="baglan()">
		<form action="yonet_islem.php?komut=yenioda" method="post">
			<p class="baslik">Yeni Oda Oluştur<br />
			Oda Adı:
			<input type="text" name="odaad">
			<input type="submit" value="Oluştur">
			</p>
		</form>
		<b class="baslik">Açık Sohbet Odaları</b>
		
		<?php
			// Ön Yükleme...
			include "ortak.php";
			include "site/guvenlik.php";
			
			// Oluşturulmuş Ortak Sohbet Odaları Alınıyor
			$sorgu = mysql_query('SELECT * FROM odalar');
			
			$i = 0;
			$x = 0;
			$y = 0;
			$dewam = true;
			
			$odalar = array();
			while ($oda = mysql_fetch_array($sorgu)){
				$odalar[$i] = $oda;
				if ($oda["odaad"] != ""){
					$i++;
					// Çıkan oda sayfaya x ve y'ye bağlı bir poziyonla yerleştiriliyor
						
					//echo $oda["odaad"];		 
					
					// html etiketleri oluşturuluyor...
					echo '<div style="position:absolute; left:'.((320 * $x)+10).'px; top:'.((610*$y) + 100 ).'px; height:600px; width:300px; overflow:hidden;">
							<div class="baslik">'.$oda["odaad"].'</p>';
					
					// Yazı paneli oluşturuluyor...
					echo '<form action="#" id="form'.$oda["oda_id"].'" method="post">
							<input type="text" name="mesaj">
							<a href="#" onclick="yaz(\''.$oda["oda_id"].'\')">Yaz</a> 
							<input type="hidden" name="odaid_yaz" value="'.$oda["oda_id"].'">
						</form></div>';
					
					// Odaya Yazılmış olan mesajlar alınıyor...
					$altsorgu = mysql_query('SELECT * FROM '.$oda["oda_id"])or die(mysql_error()) ;

					// odamızın içinde yazılı mesaj olup olmadığını kontrol ediyoruz
					$satır = mysql_num_rows($altsorgu);
					
					echo '<div id="'.$oda["oda_id"].'div" style="width:298px; height:480px; overflow:auto;">
						<form id="'.$oda["oda_id"].'form" action="yonet_islem.php?komut=sohbet_oda" method="post">
						<input type="hidden" name="odaid" value="'.$oda["oda_id"].'">
						<input type="hidden" id="'.$oda["oda_id"].'islem" name="islem" value="'.$oda["oda_id"].'">
						<table width="%100">';
					
					// her mesajı veri tabanınan çıkartıp yazanıyla beraber sayfaya işliyoruz
					if ($satır > 0){

						$geri = $satır;
						
						for ($i=0;$i<=$satır;$i++){
							if ($i < $satır){
								$geri--;
								
								$id = mysql_result($altsorgu,$geri,'id');
								$uyeid = mysql_result($altsorgu,$geri,'yazanid');
								$icerik = mysql_result($altsorgu,$geri,'mesaj');
								$tarih = mysql_result($altsorgu,$geri,'tarih');
								$sil = mysql_result($altsorgu,$geri,'sil');
						
								if ($sil == 0){
									// bize verilen üye id'sinin kime ait olduğunu bulduruyoruz ve yazdırıyoruz
									$uyead = uye_adı($uyeid);

									/*echo '<p style="border-bottom:#CC6600 solid 1px; " ><a style="padding:0px;" href="index.php?komut=arkadas&git=menu&id='.id_maskele($uyeid,"sohbet").'" title="a">'.$uyead.':</a>
											<strong style="color:#000000; padding:3px" >'.$icerik.'</strong>
										</p>';*/
									
									// Belirli filtrelerle beraber iceriğin içindeki ifadeler aranıyor
		
									// "." ile baslayıp . ile biten ifadeleri taratıoz ilk noktanın bulunduğu yere iki nokta arasında verilmisolan ifade id'si bağlı ifade konduruluyor 
									$sec = false;
									$ifade_id = '';
									$ilk_nok = 0;
									
									$yaz = "";
									
									for ($i = 0;$i < strlen($icerik);$i++){
										if ($sec){
											if (substr($icerik,$i,1) == "."){
												$sec = false;
												
												$ifade_id = substr($icerik,$ilk_nok,$i - $ilk_nok);
												$ifade_id = substr($icerik,$ilk_nok,$i - $ilk_nok + 1);
												
												// echo '<br>Seçilen:'.$ifade_id.'<br>';
												
												// Veri tabanından ifade_id'e bağlı olan resmin yolu'nun alınması
												$sorgu = mysql_query('SELECT * FROM ifadeler WHERE kısayol="'.$ifade_id.'"');
												
												// echo '<br>Seçme islemi durduruldu<br>';
												
												if ($sorgu){
													if (mysql_num_rows($sorgu) > 0){
														$ifade_adres = mysql_result($sorgu,0,'adres');
														$yukseklik = mysql_result($sorgu,0,'yukseklik');
														$genislik = mysql_result($sorgu,0,'genislik');
														
														// ifadenin yazdırılması
														$yaz .= '<img src="'.$ifade_adres.'" height="'.$yukseklik.'" width="'.$genislik.'" >'; 
														// echo '<br>Aranan İfade Bulundu('.$ifade_id.')<br>';
													}
													else {
														// secmeye alınmıs olan karekterler tekrardan yazılacak listesine aktarılıyor...
														// echo '<br>Aranan İfade Bulunamadı('.$ifade_id.')<br>';
														$yaz .= $ifade_id; 
													}
												}
												else {
													$yaz .= 'sql_hatası:'.mysql_error();
												}
											}
											else if (substr($icerik,$i,1) == " "){
												$sec = false;
												
												// secmeye alınmıs olan karekterler tekrardan yazılacak listesine aktarılıyor...
												$yaz .= $ifade_id; 
												// echo '<br>İfade içinde Boşluk war<br>';
											}
											else{
												$ifade_id = substr($icerik,$ilk_nok,$i - $ilk_nok);
												// echo '<br>Seçilen:'.$ifade_id.'<br>';
											}
										}
										else{
											if (substr($icerik,$i,1) == "."){
												// echo '<br>Secme islemi basladı<br>';
												
												$sec = true;
												$ilk_nok = $i;
											}
											else {
												$yaz .= substr($icerik,$i,1);
											} 
										}
									}
									
									if ($sec){
										// secmeye alınmıs olan karekterler tekrardan yazılacak listesine aktarılıyor...
										$yaz .= $ifade_id; 
									}
									
									echo '
										<tr>
											<td width="100">'.$uyead.':</td>
											<td style="text-align:left;">'.$yaz.'</td>
											<td style="text-align:left;"><input name="c'.$id.'" type="checkbox"></td>
										</tr>
										<tr>
											<td colspan="3" style="border-bottom:#CC6600 solid 1px;"></td>
										</tr>';
								}
							}
						}
					}
					echo '</table></form></div>';
					
					echo '<div class="baslik" style="height:100px; width:%100;">
						<table style="width:100%;">
							<tr>
								<td>
									<a href="#" onclick="islem(\''.$oda["oda_id"].'\',1)">Odayı Tazele(Hepsini Sil)</a>
									<a href="#" onclick="islem(\''.$oda["oda_id"].'\',2)">Seçilileri Sil</a><br>
								</td>
								<td>
									<a href="#" onclick="islem(\''.$oda["oda_id"].'\',3)">Odayı Kapat</a>
									<a href="#" onclick="islem(\''.$oda["oda_id"].'\',1)">İçeridekileri Gör</a><br />
								</td>
							</tr>
						</table>
						';
					
					
					echo '</div></div>';
					
					if ($x < 3){
						$x++;
					}
					else{
						$x = 0;
						$y++;
					}
					//echo "x:".$x." y:".$y."<br />";	
				}
			}
			//new dbug($odalar);
		?>
	</body>
</html>



























































