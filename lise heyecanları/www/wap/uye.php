<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
	<head>
		<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
		<link href="tema/yonetim/uye.css" rel="stylesheet" type="text/css" />
	</head>
	<body>
		
		<?php 
			// Ön Yükleme...
			include "ortak.php";
			include "site/guvenlik.php";
			//!!!!! HATA !!!!! SESSION İÇİNE KAYDEDİLEN ANLIK SAYFALAR TEKRAR SİLİNMİYOR...
			
			// Üye Bilgilerinin Alınması
			
			$uyeid = maske_coz($_GET["id"]);
			
			$sorgu = mysql_query("SELECT ad,soyad,kullanıcı_adı,sifre,eposta FROM uye WHERE uyeid=".$uyeid);
			
			$ad = mysql_result($sorgu,0,"ad");
			$soyad = mysql_result($sorgu,0,"soyad");
			$kullanıcı_ad = mysql_result($sorgu,0,"kullanıcı_adı");
			$sifre = mysql_result($sorgu,0,"sifre");			
			$eposta = mysql_result($sorgu,0,"eposta");
			
			// Diğer Sayfaların Oluşturulması
			echo '<a href="uye.php?'.$_SERVER["QUERY_STRING"].'">Yenile</a>';
		?>
		
		<div id="menu1">
			<ul>
				<li>Kullanıcı Günlüğünü Görüntüle</li>
				<li>Hesabı Kısa Süreliğine Dondur</li>
				<li>Hesabı Kapat</li>
				<li>Hesap Bilgilerini Değiştir</li>
				<li>Tüm Verilerini Sıfırla</li>
				<li>İzinlerini Kısıtla</li>
				<li><a href="hesap_ayar.php">Hesap Ayarlarını Değiştir</a><?php //mysql_field_name($res, 0) Bu Method Kullanılacak ?></li>
				<li>Mesaj Yolla</li>
				<li>El Salla</li>
			</ul>
		</div>
		
		<div id="bilg_panel">
			  <p><img src="tema/tema1/kisi.gif" alt="Üye Profil Resmi" width="146" height="132" /></p>
			  
			  <div id="altt">
				<b>Üye numarası:</b> <?php echo $uyeid ?><br />
				<b>Adı:</b> <?php echo $ad ?><br />
				<b>Soyadı:</b> <?php echo $soyad ?><br />
				<b>Kullanıcı Adı:</b> <?php echo $kullanıcı_ad ?><br />
				<b>E-postası:</b> <?php echo $eposta ?><br />
				Profili Düzenle<br />
			  </div>
		</div>
		
		<div id="sohbet_rapor">
			<b class="baslik">Sohbet Raporları:</b>
			<table width="100%">
				<thead>
					<tr>
						<td>Tarih</td>
						<td>Kime</td>
						<td>Nereden</td>
						<td>İçerik</td>
					</tr>
				</thead>
				<tbody>
					<tr> <!--- Silinecek -->
						<td>Tarih</td>
						<td>Kime</td>
						<td>Nereden</td>
						<td>İçerik</td>
					</tr>
				</tbody>
			</table>
		</div>
		
		<div id="gelen_msjlr">
			<b class="baslik">Gelen Mesajlar:</b>
			<table width="100%">
				<thead>
					<tr>
						<td>İd</td>
						<td>Tarih</td>
						<td>Kimden</td>
						<td>İçerik</td>
						<td>Silinme Durumu</td>
					</tr>
				</thead>
				<tbody>
					<?php 
						// Sorgudan çıkan değerlerin belli miktarı <tarih sıralamasına göre> tabloya enjekte etme işlemi gerçekleştiriliyor 
						
						@$sorgu = mysql_query('SELECT * FROM mesaj WHERE alan_id="'.$uyeid.'" ORDER BY tarih DESC')or die(mysql_error());
						
						// Belli miktarda yazdırma alma işlemi...
						
						for ($i=0;$i <= 10;$i++){
							if($dizi = mysql_fetch_array($sorgu)){
								// içerik alanı maskeleniyor [*****...]
								$icerik = substr($dizi["icerik"],0,10);
								$icerik .= "...";
								
								// Silinme durumu okunur hale getiriliyor...
								if ($dizi["gorunur_alan"] == 0){
									$gorunrlk = "Silinmemiş";
								}
								else{
									$gorunrlk = "Silinmiş";
								}
								
								echo '
									<tr> <!--- Silinecek -->
										<td>'.$dizi["mesaj_id"].'</td>
										<td>'.$dizi["tarih"].'</td>
										<td>'.uye_adı($dizi["atan_id"]).'</td>
										<td>'.$icerik.'</td>
										<td>'.$gorunrlk .'</td>
									</tr>
								';
							}
						}
						
					?>
				</tbody>
			</table>
			<p class="baslik" style="text-align:right;"><a href="#">Detaylı İşlem --></a></p>
		</div>
		
		<div id="giden_msjlr">
			<b class="baslik">Giden Mesajlar:</b>
			<table width="100%">
				<thead>
					<tr>
						<td>İd</td>
						<td>Tarih</td>
						<td>Kime</td>
						<td>İçerik</td>
						<td>Silinme Durumu</td>
					</tr>
				</thead>
				<tbody>
					<?php 
						// Sorgudan çıkan değerlerin belli miktarı <tarih sıralamasına göre> tabloya enjekte etme işlemi gerçekleştiriliyor 
						
						@$sorgu = mysql_query('SELECT * FROM mesaj WHERE atan_id="'.$uyeid.'" ORDER BY tarih DESC')or die(mysql_error());
						
						// Belli miktarda yazdırma alma işlemi...
						
						for ($i=0;$i <= 10;$i++){
							if($dizi = mysql_fetch_array($sorgu)){
								// içerik alanı maskeleniyor [*****...]
								$icerik = substr($dizi["icerik"],0,10);
								$icerik .= "...";
								
								// Silinme durumu okunur hale getiriliyor...
								if ($dizi["gorunur_atan"] == 0){
									$gorunrlk = "Silinmemiş";
								}
								else{
									$gorunrlk = "Silinmiş";
								}
								
								echo '
									<tr> <!--- Silinecek -->
										<td>'.$dizi["mesaj_id"].'</td>
										<td>'.$dizi["tarih"].'</td>
										<td>'.uye_adı($dizi["alan_id"]).'</td>
										<td>'.$icerik.'</td>
										<td>'.$gorunrlk .'</td>
									</tr>
								';
							}
						}
						
					?>
				</tbody>
			</table>
			<p class="baslik" style="text-align:right;"><a href="#">Detaylı İşlem --></a></p>
		</div>
		
		<div id="son_paylsmlr">
			<b class="baslik">Kullanıcının Son Paylaşımları:</b>
			<table>
				<thead>
					<tr>
						<td width="10">İd</td>
						<td width="125">Tarih</td>
						<td width="20">Türü</td>
						<td width="355">İçerik</td>
						<td width="10">Yorum Sayısı</td>
						<td width="20">Beğeni Sayısı</td>
					</tr>
				</thead>
				<tbody>
					<?php 
						// Sorgudan çıkan değerlerin belli miktarı <tarih sıralamasına göre> tabloya enjekte etme işlemi gerçekleştiriliyor 
						
						// echo 'SELECT * FROM paylasımlar WHERE gondrn_id="'.$uyeid.'" ORDER BY tar DESC';
						$sorgu = mysql_query('SELECT * FROM paylasımlar WHERE gondrn_id="'.$uyeid.'" ORDER BY tarih DESC')or die(mysql_error());
						
						// Belli miktarda yazdırma alma işlemi...
						
						for ($i=0;$i <= 16;$i++){
							if($dizi = mysql_fetch_array($sorgu)){
								$veriler = scrpt_parcala($dizi['yorum']);
								//new dbug($veriler);
								//toplam yorum sayısı öğreniliyor
								$toplm = $veriler["s"]["s_yorum"];
								
								// Toplam beğeni sayısı öğreniliyor
								$toplm_begeni = begeni_sayısı("paylaşım",$dizi["id"]);
								
								if ($dizi["tur"] == "yazı"){
									$icerik = $dizi['icerik'];
									//echo "---leeyynn---";
								}
								else if($dizi["tur"] == "foto"){
									// İçerik alanı düzeltiliyor...
									$icerik = $veriler["s"]["adres"]; // array içindeki veriler veri parcala tarafından tablodan alına veriye göre oluşturulmuştur
								}
								
								// Tarihe maske getiriliyor [00.00.00 ...]
								//$tarih = substr($dizi["tarih"],0,8);
								
								echo '
									<tr>
										<td>'.$dizi["id"].'</td>
										<td>'.$dizi["tarih"].'</td>
										<td>'.$dizi["tur"].'</td>
										<td>'.$icerik.'</td>
										<td>'.$toplm.'</td>
										<td>'.$toplm_begeni.'</td>
									</tr>
								';
							}
						}
						
					?>
				</tbody>
			</table>
			<p class="baslik" style="text-align:right;"><a href="#">Detaylı İşlem --></a></p>
		</div>
		
		<div id="son_grsme">
			<b class="baslik">Kullanıcının Son Görüştüğü Kişiler:</b>
		</div>
		
		<div id="arkads_panel">
			<b class="baslik">Kullanıcının Arkadaş Listesi:</b>
			<table width="100%">
				<thead>
					<tr>
						<td>İd</td>
						<td>Kullanıcı Adı</td>
						<td>Ad Soyad</td>
						<td>Son İşlem Tarihi</td>
					</tr>
				</thead>
				<tbody>
					<?php 
						// Arkadaş Bilgilerinin Çekimi
						
						$liste = arkadas_listesi(false,$uyeid);
						
						// Çıkan sonucun sadece belli bir miktarı listeleniyor...
						for ($i=0;$i<=50;$i++){
							
							if (isset($liste[$i])){
								$sorgu = mysql_query('SELECT kullanıcı_adı,ad,soyad,sonislem_tarih FROM uye WHERE uyeid='.$liste[$i]);
								echo '
									<tr>
										<td>'.$liste[$i].'</td>
										<td>'.mysql_result($sorgu,0,"kullanıcı_adı").'</td>
										<td>'.mysql_result($sorgu,0,"ad").' '.mysql_result($sorgu,0,"soyad").'</td>
										<td>'.mysql_result($sorgu,0,"sonislem_tarih").'</td>
									</tr>
								';
							}
						}
					?>
				</tbody>
			</table>
			<p class="baslik" style="text-align:right;"><a href="#">Detaylı İşlem --></a></p>
		</div>
	</body>
</html>
