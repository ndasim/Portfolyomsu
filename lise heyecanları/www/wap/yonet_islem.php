<?php ob_start(); ?>
<?php  
	include "ortak.php";
	//ob_start();
	header("Content-Type: text/xml; charset=utf-8");
	
	// Tüm veriler Burada Ateşleniyor;
	gelen_veriler();
	
	
	function gelen_veriler(){
		
		$_SESSION["yönetime ulaşan post verileri"] = $_POST;
		$_SESSION["yönetime ulaşan FILE verileri"] = $_FILES;
		
		if (isset($_GET["komut"])){
			$komut = $_GET["komut"];
			
			//echo "asasas";
			
			if ($komut == "giris"){
				//echo "asasasg  ".$_POST["kullanıcı"];
				if (!oturum_kontrol()){
					if (isset($_POST["kullanıcı"])){
						
						$sonuc = oturum_baslat('yönetici');
						
						if ($sonuc){
							echo "tmm";
						}
						else{
							echo "Lütfen Tekrar deneyiniz sonuç alamıyorsanız yöneticiye başvurun";
						}
					}
					//new dbug($_POST);
				}
				
			}
			else if ($komut == "sis_yonetim"){
				//echo "asasasg  ".$_POST["kullanıcı"];
				if (isset($_POST["kullanıcı"])){
					if ($sonuc){
						include "sistem.php";
					}
					else{
						echo "Lütfen Tekrar deneyiniz sonuç alamıyorsanız yöneticiye başvurun";
					}
				}
				//new dbug($_POST);
			}
			else if ($komut == "uye_yonetim"){ // TEWWAAAMMM
				
				if (isset($_POST["bull"])){ // Postdan gelen veriyi uye listesi içinden belirli alanlarda aratıp bulur
					
				}
				else{
					
				}
				
			}
			else if ($komut == "grafik"){
				if (isset($_POST["islem"])){
					
					if ($_POST["islem"] == 1){ // Değişiklikleri Kaydetme
						$hata = false;
						
						// Seçili Temanın Adı
						$tema = $_POST["tema"];
						
						/* 
							Gelen Post verilerininin adı css ile başlayan nesnelerin 
							başındaki css atlanır ve geri kalan ad css komut adı olarak kullanılır
						*/ 
						
						// Nesne adlarından komut isimlerinin ayrıştırılması..
						$dizi = array_keys($_POST);
						
						$i = 0;
						$CssKomut = array();
						
						$_SESSION["testt10"] = $tema;
						$_SESSION["testt1"] = $dizi;	
						
						// :adn: karekteri bulunduğu yerede bir birimlik boşluğa dönüştürülüyor
						
						foreach ($dizi as $ad){
							
							$cssad = str_replace(":adn:"," ",$ad); // Ayıklama
							
							// ilk 3 harfin öğrenilmesi
							$ilk = substr($ad,0,3);
							
							if ($ilk == "css"){
							
								if ($_POST[$ad] == ""){
									$hata = true;
								}
								
								$CssKomut[$i] = array();  
								
								$CssKomut[$i]["kural"] = substr($cssad,3);
								$CssKomut[$i]["komut"] = $_POST[$ad];
								
								$i++;
								
								//echo 'ewtt<br />';
							}
							//echo $ilk.' <br />';
						}
						
						$_SESSION["testt"] = $CssKomut;	
						
						
						
						// Arayüz Resimlerinin Kaydı...
						
						// veritabanından verilerin Çekilmesi
						$sorgu = mysql_query('SELECT * FROM tema_kaynak WHERE tema_ad="'.$tema.'"');
						
						while ($dizi = mysql_fetch_array($sorgu)){
							
							/*echo '
									<tr>
										<td><img src="'.$dizi["adres"].'" class="baslik" height="20" width="20"></td>
										<td width="100">'.$dizi["nesne"].'</td>
										<td><input type="file" name="dosya'.$dizi["nesne"].'"></td>
									</tr>
								';
							*/
							
							// Veri tabanından çıkan obje adı <arayüz elemanının grafik adı> dosya_kaydet fonksiyonu ile önce sayfadan gelip gelmediği öğrenilir sonra kayt işlemi yapılır 
							$sonuc = dosya_yukle("dosya".$dizi["nesne"],"tema/tema1/menu/",$dizi["nesne"]);
							
							// ** ... ** //
							
							if ($sonuc == false){
								$hata = true;
								echo "Upload etmeye çalıştığınız dosya formatı desteklenmemektedir";
							}
						}
						
						if (!$hata){
							// Ayrıştırılan Komutlar Tema_Verinin İçinde Seçili Temaya Ait Saturlar Güncelleniyor
							
							foreach ($CssKomut as $komut){
								@mysql_query('UPDATE tema_veri SET komut="'.$komut['komut'].'" WHERE kural="'.$komut['kural'].'" and tema_ad="'.$tema.'"')or die(mysql_error());
							}
							
							echo 'Değişiklikler Başarıyla Kaydedilmiştir';
						}
						
					}
					else if ($_POST["islem"] == 2){ // Önizleme
						/* Bu aşamada formdaki bütün veriler sessiona kaydedilir... */
						//session_start();
						$_SESSION["önizleme"] = $_POST;
						
						$dizi = array_keys($_POST);
						// Tema arayüz resimleri adresleri ayrıştırıldıktan sonra geçici adlarla
						// sunucuya saklanıp session'a geçici adresleri kaydedilir...
						
						// Her resim için ayrılmış olan hidden nesnelerinden resimlerin yolları öğreniliyor...
						
						$img_yol = array();
										
						foreach ($dizi as $ad){
							
							
							// ilk 3 harfin öğrenilmesi
							$ilk = substr($ad,0,5);
							
							if ($ilk == "dosya"){
								
								if ($_POST[$ad] == ""){
									$hata = true;
								}
								
								$img_yol[substr($ad,5)] = $_POST[$ad];
								
							}
							// echo $ad.'-'.$ilk.'   ';
						}
						
						// Ayrıştırılan resimlerin Session(Oturum)'a kaydedilmesi
						$_SESSION['arayüz_önizleme'] = $img_yol;
						
						echo "Tek Oturumluk Web Deneyimi Etkinleştirilmiştir :-adn-: Bu Durum Sdece Bu oturum İçindir Oturum Kaptıldığında Veriler Kaybolur";
					}
					else if ($_POST["islem"] == 3){ // Yeni bir tema oluşturma
						
						$hata = false;
						
						// Yeni Temanın Adı
						if (isset($_POST["yeniad"])){
						$yeniad = $_POST["yeniad"];
						
							if ($yeniad != ""){
								
								// Eski adlar sorgulanıp iki adet aynı addan tema oluşturulması engelleniyor
								$sorgu = mysql_query('SELECT * FROM temalar');
								
								while ($tema = mysql_fetch_array($sorgu)){
									if ($yeniad == $tema){
										$hata = true;
									}
								}
								
								if (!$hata){
								
									/* 
										Gelen Post verilerininin adı css ile başlayan nesnelerin 
										başındaki css atlanır ve geri kalan ad css komut adı olarak kullanılır
									*/ 
									
									// Nesne adlarından komut isimlerinin ayrıştırılması..
									$dizi = array_keys($_POST);
									
									$i = 0;
									$CssKomut = array();
									
									
									foreach ($dizi as $ad){
										
										$cssad = str_replace(":adn:"," ",$ad); // Ayıklama
										
										// ilk 3 harfin öğrenilmesi
										$ilk = substr($ad,0,3);
										
										if ($ilk == "css"){
											
											if ($_POST[$ad] == ""){
												$hata = true;
											}
											
											$CssKomut[$i] = array();  
											
											$CssKomut[$i]["kural"] = substr($cssad,3);
											$CssKomut[$i]["komut"] = $_POST[$ad];
											$CssKomut[$i]["tür"] = $_POST['tur'.substr($ad,3)];
											
											$i++;
										}
										// echo $ad.'-'.$ilk.'   ';
									}
									
									// Ayrıştırılan Komutlar Yeni Tema Adıyla Tema Verinin İçine Kaydediliyor
									
									// Performans için:
									//
									// Teker Teker mysql_query açmak yerine 
									// 
									// Döngüyle ortak bir query cümlesi oluşturulur döngü sonunda mysql_query çağrılır
									
									// Query cümlesi:
									
									$query = 'INSERT INTO tema_veri(tema_ad,kural,komut,tur) VALUES ';
									
									$i = 0;
									
									foreach ($CssKomut as $komut){
										if ($i == 0){
											$query .= '("'.$yeniad.'","'.$komut["kural"].'","'.$komut["komut"].'","'.$komut["tür"].'")';
										}
										else{
											$query .= ',("'.$yeniad.'","'.$komut["kural"].'","'.$komut["komut"].'","'.$komut["tür"].'")';
										}
										
										
										$i++;
									}
									
									@mysql_query($query)or die(mysql_error());
									
									// Tema temalar tablosuna kayıt ediliyor
									@mysql_query('INSERT INTO temalar(tema_ad,tarih) VALUES ("'.$yeniad.'","'.date("m.d.y").'")')or die(mysql_error());
									
									// Tema Seç Bölümü Yazdırılıyor...
									// Temalar tablosundan tema adları alınıyor...
									$sorgu = mysql_query('SELECT * FROM temalar');
									$i;
									$ek = "";
									
									$secili = "";
									
									// Varsayılan tema öğreniliyor
									$innerhtml = "";
									
									// Teker teker tema adları <option> etiketine sarılarak yazdırılıyor
									while($ad = mysql_fetch_array($sorgu)){
										
										if ($ad["tema_ad"] == $tema){
											echo $tema;
											$ek = 'selected="selected"'; // otomatik olarak seçili görünmesi için
											$secili = $ad["tema_ad"]; // bir alt betikte kullanmak için
										}
										else{
											$ek = "";
										}
										
										$innerhtml .= '
											<option '.$ek.' value="'.$ad["tema_ad"].'">'.$ad["tema_ad"].'</option>
										';
									}
									echo $innerhtml;
									
									if (!$hata){
										echo ':_adn_: Dikkat Sunucuya Gelen Verilerin İçinde Boş Alanlar Olduğu Gözlendi :-adn-: Bu Durum Sistemde Bir Çok Öğenin İstenlimeyen Biçimde Görüntülenmesini Sağlayabilir';
									}	
								}
							}
						}
						else{
							echo ' :_adn_: :_adn_:Temanın Yeni Bir Adı Olmak Zorunda';
						}
					}
					else if ($_POST["islem"] == 4){ // Seçili temayı siler // Dönüt Olarak menü seçme ekranı döndürür
						
						// Seçili Tema:
						$tema = $_POST["tema"];
						
						// Varsayılan Temanın Öğrenilmesi
						$sorgu = mysql_query('SELECT * FROM sistem WHERE ad="tema"');
						$varsylan = mysql_result($sorgu,0,"deger");
							
						if ($tema != "varsayılan"){
							// Seçili Tema temalr tablosundan ve tema_veri tablosundan satırlar halinde siliniyor
								mysql_query('DELETE FROM temalar WHERE tema_ad="'.$tema.'"');
								mysql_query('DELETE FROM tema_veri WHERE tema_ad="'.$tema.'"');
							
							// Tema seçme bölümü 
							
							// Temalar tablosundan tema adları alınıyor...
							$sorgu = mysql_query('SELECT * FROM temalar');
							$i;
							$ek = "";
							
							$secili = "";
							
							// Varsayılan tema öğreniliyor
							$innerhtml = "";
							
							// Teker teker tema adları <option> etiketine sarılarak yazdırılıyor
							while($ad = mysql_fetch_array($sorgu)){
								
								if ($ad["tema_ad"] == $tema){
									echo $tema;
									$ek = 'selected="selected"'; // otomatik olarak seçili görünmesi için
									$secili = $ad["tema_ad"]; // bir alt betikte kullanmak için
								}
								else{
									$ek = "";
								}
								
								$innerhtml .= '
									<option '.$ek.' value="'.$ad["tema_ad"].'">'.$ad["tema_ad"].'</option>
								';
							}
							
							$msj = "";
							
							if ($tema == $varsylan){
								$donut = 'Sildiğiniz Tema Sistemin Varsayılan Temasıydı Varsayılan Tema: varsayılan Olarak Değiştirilmiştir :_adn_: '.$innerhtml;
							}
							else{
								$donut = $innerhtml;
							}
							
							echo $donut;
						}
						else{
							hata_yaz('Bu Tema Sistemin Temel Temasıdır Silinemez');
						}
						
						// Ayrıştırma: responseText.split(':_adn_:')
					}
					else if ($_POST["islem"] == 5){ // Seçili temayı görüntüler
						
						// Seçili Tema:
						$tema = $_POST["tema"];
						
						// Tema verilerinin yazdırılması
						
						echo '<b class="baslik">Tema CSS Kuralları</b>';
						
						$tema_ad = $tema; 
						
						// veritabanından verilerin Çekilmesi
						$sorgu = mysql_query('SELECT * FROM tema_veri WHERE tema_ad="'.$tema_ad.'"');
						
						// Tablonun Doldurulması
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
					}	
					else if ($_POST["islem"] == 6){ // Seçili temayı varsayılan yapar
						
						// Seçili Tema:
						$tema = $_POST["tema"];
						
						// Sorgu ile değişim gerçekleştiriliyor
						mysql_query('UPDATE sistem SET deger="'.$tema.'" WHERE ad="tema"');
						$hata = mysql_error();
						if ($hata){
							echo "Veritabanına Kayıt Hatası: :-adn-: ".$hata;
						};
					}
					else if ($_POST["islem"] == 7){ // Verilen resim dosyasını sunucuda geçici konuma yükler
					
					}
					else if ($_POST["islem"] == 8){ // Seçili Temaya Kural Ekler
						
						// Seçili Tema:
						$tema = $_POST["tema"];
						
						if (isset($_POST["yeni_komut_adi"])){
							// Ekleme...
							@mysql_query('INSERT INTO tema_veri(tema_ad,kural,tur) VALUES ("'.$tema.'","'.$_POST["yeni_komut_adi"].'","'.$_POST["yeni_komut_tur"].'")')or die(mysql_error());
							echo "Css Kuralı Eklenmiştir :-adn-: Lütfen Yenileyiniz ve Kural İçeriğini Değiştiriniz";
						}
						else{
							echo "Lütfen Sayfayı Yeniden Yükleyerek Deneyiniz yada :-adn-: Farklı Bir Tarayıcıyı Tercih Edin";
						}
						
					}
				}
			}
			else if ($komut == "sohbet_oda"){
				
				// Öncelikli olarak postdan gelen odaid ve yapılacak işlem öğrenilir
				$odaid = $_POST["odaid"];
				$islem = $_POST["islem"];
				
				if ($islem == 1){ // Oda içinde kayıtlı olan bütün verileri siler // Oda için olan özel mesaj hariç
					// Özel mesajın sql kopyası alınıyor...
					$sorgu = mysql_query('SELECT * FROM '.$odaid.' WHERE yazanid=-1 and sil=1');
					$kopya = mysql_result($sorgu,0,"mesaj");
					
					$sorgu = mysql_query('TRUNCATE TABLE '.$odaid);
					
					//echo $kopya."_hasnictr";
					
					@mysql_query("INSERT INTO ".$odaid."(id,yazanid,mesaj,sil) VALUES(0,-1,'".$kopya."',1)")or die(mysql_error());
				}
				elseif($islem == 2){ // Sadece seçilmiş olan mesajları siler
					$tara = true;
					$i = 1;
					
					//echo $odaid;
					
					// Odadaki toplam mesaj sayısı...
					@$sorgu = mysql_query('SELECT * FROM '.$odaid)or die(mysql_error());
					$max = mysql_num_rows($sorgu);
					
					// Seçilmiş id'leri Öğrenme....
					
					for ($i=0;$i<=$max;$i++){	/// !!!!!!!!!!!------------ BİLGİLENDİRME ÇIKTISI ALINACAKKKK --------!!!!!!!!!!
						if(isset($_POST["c".$i])){
							// Silme prosedürü .. buarada ifade etmeliyimki prosedür kelimesini ilk burada kullandım :) ..
							
							@mysql_query('UPDATE '.$odaid.' SET sil=1 WHERE id="'.$i.'"')or die(mysql_error());
							
							//echo 'UPDATE '.$odaid.' SET sil=1 WHERE id="'.$i.'"';
							//echo 'naber ln';
						}
						echo "c".$i." denendi...<br />";
					}
				}
				elseif($islem == 3){ // Odayı Tamamen Kullanımdan Kaldırır(Siler)
					// Odayı Kayıtdan Silme
					mysql_query('DELETE FROM odalar WHERE oda_id="'.$odaid.'"');
					
					// Oda tablosunu sistemden kaldırma
					mysql_query('DROP TABLE '.$odaid);
					
				}
			}
			else if ($komut == "oda_yaz"){
				
				// Öncelikli olarak postdan gelen odaid öğrenilir
				$odaid = $_POST["odaid_yaz"];
				
				echo "Odaya yazılıyor";
				
				//new dbug($_POST);
				mesaj_yaz("odaya",$odaid);
				
				//odalar_sayfası();
			}
			else if ($komut == "oda_veri"){
				
				// Öncelikli olarak get'den gelen odaid öğrenilir
				$odaid = $_GET["odaid"];
				
				// Odaya Yazılmış olan mesajlar alınıyor...
				$sorgu = mysql_query('SELECT * FROM '.$odaid)or die(mysql_error()) ;

				// odamızın içinde yazılı mesaj olup olmadığını kontrol ediyoruz
				$satır = mysql_num_rows($sorgu);
				
				echo '<div id="'.$odaid.'div" style="width:298px; height:480px; overflow:auto;">
							<form id="'.$odaid.'form" action="yonet_islem.php?komut=sohbet_oda" method="post">
							<input type="hidden" name="odaid" value="'.$odaid.'">
							<input type="hidden" id="'.$odaid.'islem" name="islem" value="'.$odaid.'">
							<table width="%100">';
				
				// her mesajı veri tabanınan çıkartıp yazanıyla beraber sayfaya işliyoruz
				if ($satır > 0){

					$geri = $satır;
					
					for ($i=0;$i<=$satır;$i++){
						if ($i < $satır){
							$geri--;
							
							$id = mysql_result($sorgu,$geri,'id');
							$uyeid = mysql_result($sorgu,$geri,'yazanid');
							$icerik = mysql_result($sorgu,$geri,'mesaj');
							$tarih = mysql_result($sorgu,$geri,'tarih');
							$sil = mysql_result($sorgu,$geri,'sil');
							
							if ($sil == 0){
								// bize verilen üye id'sinin kime ait olduğunu bulduruyoruz ve yazdırıyoruz
								$uyead = uye_adı($uyeid);

								/*echo '<p style="border-bottom:#CC6600 solid 1px; " ><a style="padding:0px;" href="index.php?komut=arkadas&git=menu&id='.id_maskele($uyeid,"sohbet").'" title="a">'.$uyead.':</a>
										<strong style="color:#000000; padding:3px" >'.$icerik.'</strong>
									</p>';*/
								
								echo '
									<tr>
										<td width="100">'.$uyead.':</td>
										<td style="text-align:left;">'.$icerik.'</td>
										<td style="text-align:left;"><input name="c'.$id.'" type="checkbox"></td>
									</tr>
									<tr>
										<td colspan="3" style="border-bottom:#CC6600 solid 1px;"></td>
									</tr>';
							}
						}
					}
				}
				echo '</table></form>';
			}
			else if ($komut == "yenioda"){
				
				// Oda adı ile odaid aynı olacak // Aslında id'kısmı forklıda olabilirdi ... :S
				
				// Gerekli kayıtlar yapılıyor...
				@mysql_query('INSERT INTO odalar(odaad,oda_id) VALUES("'.$_POST["odaad"].'","'.$_POST["odaad"].'")')or die(mysql_error());;
				
				// Oda tablosu oluşturuluyor...
				@mysql_query("CREATE TABLE IF NOT EXISTS ".$_POST["odaad"]." (
					  id int(11) NOT NULL,
					  yazanid int(11) NOT NULL,
					  mesaj text COLLATE utf8_turkish_ci NOT NULL,
					  tarih text COLLATE utf8_turkish_ci NOT NULL,
					  sil varchar(1) COLLATE utf8_turkish_ci NOT NULL DEFAULT '0'
					) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;")or die(mysql_error());
				
				// scrpt methoduyla özel mesaj içine ön tanımlı kişisayısı aktarılıyor...
				// özemesaj kuralı: yazanid = -1 // olasılık dışı bir değerdir bu // gizlenmiş msjdır sil=0;
				@mysql_query('INSERT INTO '.$_POST["odaad"].'(id,yazanid,mesaj,sil) VALUES(0,-1,\'|u ad="kisisayisi"|0;\',1)')or die(mysql_error());
			}
			else if ($komut == "sayfalar"){
				
				//echo "a";
				
				if (isset($_POST["ifade"])){
					
					// Veritabanından görünenler listesinden değiştirlmek istenen bulunur normal değeri alınır tekrar normal değeri üzerinden değişim gerçekleştirilir
					
					$sorgu = mysql_query('SELECT * FROM dil_yapılandırması WHERE gorunen="'.$_POST["ifade"].'"');
					
					if ($sorgu){
						if (mysql_num_rows($sorgu) > 0){
							
							mysql_query('UPDATE dil_yapılandırması SET gorunen="'.$_POST["yeni_ifade"].'" WHERE gorunen="'.$_POST["ifade"].'"');
							
							echo "Değiştirme İşlemi Başarılı";
						}
						else{
							echo "Başarısız İşlem :-adn-: Vermiş Olduğunuz İfade Sistemde Kullanılmıyor :-adn-: 
								Yada Daha Önceden Belirtilmiş Olan Kriterlere :-adn-: 
								Bağlı Kalınmadan Değer Girişi Yapılmış";
						}
					}
					else{
						echo mysql_error();
					}
				}
				
				
				if (isset($_POST["ana_giris_toplam"])){ // ana giris menüsü için gelmiş olan veriler veritabanına kaydediliyor
					/* 
						öncelikli olarak ana giris menusu icin kaydedilmis veriler veri tabanından siliniyor cünkü alt satırlarda
						yeni kayıt da varsa tekrar sql kontrolleriyle fazla uğrasmadan gelen verileri eklemek icin postdan gelen veriler hayatidir!!!...
					*/
					
					mysql_query('DELETE FROM menuler WHERE menu_gurup = "ana giriş"');
					
					$toplam = $_POST["ana_giris_toplam"];
					
					for ($i = 1; $i <= $toplam; $i++){
						
						mysql_query('INSERT INTO menuler(menu_gurup, sıra_no, menu_text, adres, img_ad) VALUES ("ana giriş",'.$i.',"'.$_POST["ana_giris_".$i].'","","")');
						
						
					}
					if (!mysql_error()){
						echo "Menü itemi değiştirme işlemi başarılı";
					}
					else{
						echo "Üzgünüz büyük ihtimalle tarayıcıdan kaynaklanan bir sorun nedeniyle veriler kaybolmuş eski sistem öğeleriniz silinmiş olabilir";
					}
				}
			
			}
			else if ($komut == "ifadeler"){
				echo 't';
				// new dbug($_FILES);
				echo 't';
				new dbug($_POST);
				
				if (isset($_POST["yeni_ifade"])){ // Elde edilen ifadenin sunucuya kaydedilmesi
					
					echo 't';
					
					$deger = "ifade";
					
					if ($_POST['genislik'] == ''){$genislik = -1;}else{$genislik = $_POST["genislik"];}
					if ($_POST['yukseklik'] == ''){$yukseklik = -1;}else{$yukseklik = $_POST["yukseklik"];}
					
					
					if ($_FILES[$deger]["error"] == 0){
						
						echo 't';
						
						$tmp_name = $_FILES[$deger]["tmp_name"];
						
						if ($_FILES[$deger]["type"] = "image/gif"){
							$dsyaadı = $_POST["yeni_ifade"].'_adnmanya.gif';
								
							move_uploaded_file($tmp_name, "site/ifadeler/".$dsyaadı);
							
							echo $tmp_name;
							
							@$sorgu = mysql_query('SELECT * FROM ifadeler WHERE kısayol = "'.$_POST["yeni_ifade"].'"') or die(mysql_error());
							
							echo 'as';
							if (mysql_num_rows($sorgu) > 0){
								// @mysql_query('UPDATE ifadeler SET ad="'.$deger.'",adres="tema/tema1/'.$dsyaadı.'",tema="1" WHERE ad="'.$deger.'" ') or die(mysql_error());
							}
							else {
								echo 'INSERT INTO ifadeler(adres,kısayol,yukseklik,genislik) VALUES ("site/ifadeler/'.$dsyaadı.'",".'.$_POST["yeni_ifade"].'.","'.$yukseklik.'","'.$genislik.'")';
								@mysql_query('INSERT INTO ifadeler(adres,kısayol,yukseklik,genislik) VALUES ("site/ifadeler/'.$dsyaadı.'",".'.$_POST["yeni_ifade"].'.","'.$yukseklik.'","'.$genislik.'")') or die(mysql_error());
							}
						}
						else {
							echo 'Lütfen Gif Formatında Bir Dosya Seçin';
						}
					}
					elseif ($_FILES[$deger]["error"] == 2){
						echo 'Seçmiş olduğun dosya boyutu 900000 baytı geçti';
					}
					else {
						echo 'Sunucu üzerinde dosya aktarımında bir sıkıntı oldu lütfen tekrar deneyiniz';
					}
				}
				
				if (isset($_POST["ex_kisayol"])){ // ana giris menüsü için gelmiş olan veriler veritabanına kaydediliyor
					echo "abbb";
					$exkısayol = $_POST["ex_kisayol"];
					
					$sorgu = mysql_query('SELECT * FROM ifadeler WHERE kısayol="'.$exkısayol.'"');
					
					$kısayol = mysql_result($sorgu,0,"kısayol");
					$genislik = mysql_result($sorgu,0,"genislik");
					$yukseklik = mysql_result($sorgu,0,"yukseklik");
					
					// $exkısayol = ""; 
					
					if ($_POST["kisayol"] != ""){$kısayol = $_POST["kisayol"];}
					if ($_POST["genislik"] != ""){$genislik = $_POST["genislik"];}
					if ($_POST["yukseklik"] != ""){$yukseklik = $_POST["yukseklik"];}
					
					mysql_query('UPDATE ifadeler SET kısayol="'.$kısayol.'", genislik="'.$genislik.'", yukseklik = "'.$yukseklik.'" WHERE kısayol="'.$exkısayol.'"');
					
					echo 'Güncelleme Sonu Mesajı:'.'UPDATE ifadeler SET kısayol="'.$kısayol.'", genislik="'.$genislik.'", yukseklik = "'.$yukseklik.'" WHERE kısayol="'.$exkısayol.'"';
				}
				
				// echo "abbb";
			}
			else if ($komut == "hata_mesaji"){
				hata_goruntule();
			}
		
		}
	
	}
	//new dbug($_SESSION);
	
	function odalar_sayfası(){
		// Ön Yükleme...
		
		// Oluşturulmuş Ortak Sohbet Odaları Alınıyor
		$sorgu = mysql_query('SELECT * FROM odalar');
		
		$i = 0;
		$x = 0;
		$y = 0;
		$dewam = true;
		
		$odalar = array();
		while ($oda = mysql_fetch_array($sorgu)){
			if ($oda["odaad"] != ""){
				$i++;
				$odalar[$i] = $oda;
				// Çıkan oda sayfaya x ve y'ye bağlı bir poziyonla yerleştiriliyor
				
				echo $oda["odaad"];
				
				if ($x < 4){
					$x++;
				}
				else{
					$x = 0;
					$y++;
				}
				// html etiketleri oluşturuluyor...
				echo '<div style="left:'.(320 * $x).'px; top:'.(610*$y).'px; height:600px; width:300px; overflow:hidden;">
						<div class="baslik">'.$oda["odaad"].'</p>';
				
				// Yazı paneli oluşturuluyor...
				echo '<form action="#" id="form'.$oda["oda_id"].'" method="post">
						<input type="text" name="mesaj">
						<a href="#" onclick="yaz(\''.$oda["oda_id"].'\')">Yaz</a> 
						<input type="hidden" name="odaid" value="'.$oda["oda_id"].'">
					</form></div>';
				
				// Odaya Yazılmış olan mesajlar alınıyor...
				$sorgu = mysql_query('SELECT * FROM '.$oda["oda_id"])or die(mysql_error()) ;

				// odamızın içinde yazılı mesaj olup olmadığını kontrol ediyoruz
				$satır = mysql_num_rows($sorgu);
				
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
							
							$id = mysql_result($sorgu,$geri,'id');
							$uyeid = mysql_result($sorgu,$geri,'yazanid');
							$icerik = mysql_result($sorgu,$geri,'mesaj');
							$tarih = mysql_result($sorgu,$geri,'tarih');
							
							// bize verilen üye id'sinin kime ait olduğunu bulduruyoruz ve yazdırıyoruz
							$uyead = uye_adı($uyeid);
							
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
							
							/*echo '<p style="border-bottom:#CC6600 solid 1px; " ><a style="padding:0px;" href="index.php?komut=arkadas&git=menu&id='.id_maskele($uyeid,"sohbet").'" title="a">'.$uyead.':</a>
									<strong style="color:#000000; padding:3px" >'.$icerik.'</strong>
								</p>';*/
							
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
				echo '</table></form></div>';
				
				echo '<div class="baslik" style="height:100px; width:%100;">
					<table style="width:100%;">
						<tr>
							<td>
								<a href="">Odayı Tazele(Hepsini Sil)</a>
								<a href="">Seçilileri Sil</a><br>
							</td>
							<td>
								<a href="">Odayı Kapat</a>
								<a href="">İçeridekileri Gör</a><br />
							</td>
						</tr>
					</table>
					';
				
				
				echo '</div></div>';
			}
		}
	}
	
	function hata_yaz($mesaj){
		//session_start();
		
		$_SESSION["yonetim_hata_mesajı"] .= "-".$mesaj;
	}
	
	function hata_goruntule(){
	
		if (!isset($_SESSION)){
			session_start();
		}
			
		
		if(isset($_SESSION["yonetim_hata_mesajı"])){
			
			if ($_SESSION["yonetim_hata_mesajı"] != ""){
			
				echo $_SESSION["yonetim_hata_mesajı"];
				$_SESSION["yonetim_hata_mesajı"] = "";
				
			}
			else{
				echo "Üzgünüz Nedeni Şuanlık Açıklanamayan Bir Hata Oluştu";
			}
		}
		else{
			echo "Üzgünüz Nedeni Şuanlık Açıklanamayan Bir Hata Oluştu";
		}
		

	}
	
?>
<?php ob_end_flush(); ?>












































