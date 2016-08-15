<?php 
	//// SAYFALA FONKSİYONU //// !!!!! TESSTTT !!!!! //// !!!!! YARIM KALDII !!!!! ////
	
	/*
	*
	* Üyeler İçin Tablo Kuralı:
	* 
	* u_* üyenin bütün izin ve ek bilgilerinin tutulacağı tablo
	* p_* üyenin paylaştığı/sildiği bütün 
	session_start();
	
	$baglanti = baglan();

	
	paylaşımları tutacaktır
	* 
	*/
	
	
	include "site/dBug.php";
	include "veritabani.php";
	include "site/scrpt_dili.php";
	include "site/tarih_farki.php";
	
	if (isset($guvenlik)){
		include "site/guvenlik.php";
	}
	
	baslat();
	
	function baslat(){
		@session_start();
		ob_start();
	}

	function bitir(){
		ob_end_flush();
	}

	function stil_al(){
		return 'color:color:#CC6600;';
	}
	
	function oturum_baslat($yonet_kntrl = false){
		
		// Veriler alınıyor
		$kullanıcı = $_POST['kullanıcı'];
		$sifre = $_POST['sifre'];
		
		// Alınan verilere göre kayıt kontrol yapılıyor
		$sorgu = mysql_query('SELECT * FROM uye WHERE sifre = "'.$sifre.'" and kullanıcı_adı= "'.$kullanıcı.'"') or die(mysql_error());
		$satır = mysql_num_rows($sorgu);
		
		$deger = false;
		
		if ($yonet_kntrl){
			if ($satır > 0){
				if (mysql_result($sorgu,0,"rutbe") == "yönetici"){
					$deger = true;

					$_SESSION["id"] = mysql_result($sorgu,0,"uyeid");
					$_SESSION["ad"] = mysql_result($sorgu,0,"ad");
					$_SESSION["soyad"] = mysql_result($sorgu,0,"soyad");
					$_SESSION["kullanıcı_adı"] = mysql_result($sorgu,0,"kullanıcı_adı");
					$_SESSION["cinsiyet"] = mysql_result($sorgu,0,"cinsiyet");
					$_SESSION["eposta"] = mysql_result($sorgu,0,"eposta");
					$_SESSION["sifre"] = mysql_result($sorgu,0,"sifre");
					
				}
			}
		}
		else{
			if ($satır > 0){
				$deger = true;
				$_SESSION["id"] = mysql_result($sorgu,0,"uyeid");
				$_SESSION["ad"] = mysql_result($sorgu,0,"ad");
				$_SESSION["soyad"] = mysql_result($sorgu,0,"soyad");
				$_SESSION["kullanıcı_adı"] = mysql_result($sorgu,0,"kullanıcı_adı");
				$_SESSION["cinsiyet"] = mysql_result($sorgu,0,"cinsiyet");
				$_SESSION["eposta"] = mysql_result($sorgu,0,"eposta");
				$_SESSION["sifre"] = mysql_result($sorgu,0,"sifre");
				
				$_SESSION['odaid'] = "";
				
				// gecmis öğesi
				//$_SESSION["gecmis"] = array();
				//$_SESSION["gecmis"][] "";
				
				if ($kntrl != "yönetici"){
					header("Location:index.php");
				}
				
				//echo mysql_result($sorgu,0,"ad");
				
				// Çevrim içi olarak ayarlama...
				
				mysql_query('UPDATE uye SET cevrimici=1 WHERE uyeid='.$_SESSION["id"]);
				
			}
			else{
				$deger = false;
			}
		}
		
		// Varsayılan temanın öğrenilmesi...
		$sorgu = mysql_query('SELECT * FROM sistem WHERE ad="tema"');
		$tema = mysql_result($sorgu,0,'deger');
		
		$_SESSION["tema"] = $tema;
		
		$_SESSION["gecmis"] = array();
		$_SESSION["gecmis_ad"] = array();
		$_SESSION["güvenlik"] = array();
		
		return $deger;
	}
	
	function oturum_kontrol($uyeid = 0){
		$donut = false;
		//new dbug($_SESSION);
		
		if ($uyeid == 0){
			if (isset($_SESSION['ad'])){
				$donut = true;
				//echo "ww";
			}
		}
		else{
			/* Verilen id'nin açık olup olmama durumuna bakılıyor 
				aynı zamanda son giriş tarihine bakılarak 
				otomatik oturum kapatma uygulanıyor
			*/
			@$sorgu = mysql_query('SELECT cevrimici,sonislem_tarih FROM uye WHERE uyeid='.$uyeid)or die(mysql_error());
			//echo "ww";
			if ($sorgu){
				if (mysql_num_rows($sorgu) > 0){
					if (mysql_result($sorgu,0,"cevrimici") == 1){
						//echo $uyeid;
						
						/*
						// Tarih farkı alınıyor
						$sontarih = mysql_result($sorgu,0,"sonislem_tarih");
						$saat_fark = tarihFarki(date("d.m.y G:i:s"),$sontarih, "dakika"); ////// DAAANNDİİKK ÇALIŞMIYORR
						
						echo $saat_fark." _ ".date("d.m.y G:i:s")." _ ".$sontarih;
						
						if ($saat_fark > 1){
							// Kapatma islemi
							@mysql_query('UPDATE uye SET cevrimici=0 WHERE uyeid='.$uyeid)or die(mysql_error());
						}
						else {
							
						}
						*/
						
						$donut = true;
					}
				}
			}
		}
		
		return $donut;
	}
	
	function oturum_kapat(){
		
		mysql_query('UPDATE uye SET cevrimici=0 WHERE uyeid='.$_SESSION["id"]);
		
		session_destroy();
		// **** diğer olaylar 
	}
	
	function izin($deger){
	
	}
	
	function bildirim_ekle($uyeid,$bild,$deger){
		return "asim";
	}
	
	function bild_sayfala($uyeid,$deger){
		$dizi = array();
		
		$sorgu = mysql_query("SELECT id FROM bildirim WHERE gorenler like '%".$uyeid."%' and ORDER BY tarih DESC");
		$satır = mysql_num_rows($sorgu);
		
		while ($satır == $deger){
			$dizi[] = mysql_result($sorgu,0,"id");
			$deger++;
		}
		
		return $dizi;
		
	}
	
	function bild_goruntule($uyeid,$sayfa){
		$dizi = bild_sayfala($uyeid,$sayfa*10);
		$cıktı = "";
		
		if (count($dizi) != 0){
			for ($i=0;$i <= count($dizi);$i++){
				$sorgu = mysql_query("SELECT * FROM bildirim WHERE id = '".$dizi[$i]."'");
			
				$cıktı = '<b class="yazi">'.mysql_result($sorgu,0,"yazan").'<b><br />
						<p>'.mysql_result($sorgu,0,"bildirim").'</p>
						<p class="yazi">'.mysql_result($sorgu,0,"tarih").'</p>
						<a href="uye.php?komut=begen&id='.$dizi[$i].'" class="yazi">beğen</a>
						<a href="uye.php?komut=yorum&id='.$dizi[$i].'" class="yazi">yorum yap</a>';
			}
			echo $cıktı;
		}
		else{
			echo '<p class="yazi" >Malesef henüz görüntülenecek bildirminiz yok</p>';
		}
		
	}
	
	function yorum_yaz($uyeid,$bildirimid,$yorum){
		return "tmm";
	}
	
	function sohbete_gir($uyeid,$tabload){
		
	}
	
	function sohbet_yaz($uyeid,$tabload,$icerik){
	
	}
	
	function mesaj_yolla($nereye = ""){
		
		// Değerler toplanıyor
		$kime = uye_id($_POST["kime"]);
		$baslik = $_POST["baslik"];
		$tarih = date("y.m.d");
		$icerik = $_POST["icerik"]; ///// !!!!!!!!!!!!!! STRİNG PARÇALAMA KULLANILACAK EKRAN İÇİN !!!!!!!!!!!!!! ////
		
		$uyeid = $_SESSION["id"]; // Açık olan kullanıcının id'si -yazan kisi-
		
		$donut = "başarılı";
		
		/* nereye değişkenimiz üstüne yazma olyını -cevapla- olup olmayacağnı belirtir
			Cevaplama işleminde önceki yazılan veride göz önüne alınır ve icerik 
			bölümüne tarih ve gönderen etiketleriyle  eklenir
		*/
		
		if ($nereye == ""){
			// Yeni mesaj yazılır
			if ($kime != 'bulunamadı'){
				
				// mesajid tabloda eklenen son kişi numarasının bir üstündeki sayıdır
				@$sorgu = mysql_query('SELECT * FROM mesaj') or die ("Ölümcül bu site kullılamaz hale gelmiştir"); 
				$mesajid = mysql_num_rows($sorgu);
				
				mysql_query('INSERT INTO mesaj(mesaj_id,atan_id, alan_id, baslik, icerik, onay, tarih, gorunur_alan, gorunur_atan) VALUES ("'.$mesajid.'","'.$uyeid.'","'.$kime.'","'.$baslik.'","'.$icerik.'","0","'.$tarih.'","1","1")'); 
				if (mysql_error() != ""){ 
					$donut = "sorgu";
					echo mysql_error();
				}
			
			}
			else {
				echo $kime;
				$donut = "kullnıcıyok";
			}
		}
		else {
			// vâr olan mesaja ek yapılır 
			
			// mesajın açılması ve içeriğinin alınması
			
			// !!!!!!!!!!! nereye değiskeni icin guvenlik saptaması sayı olup olmama durumu !!!!!!!!!!!!!!!!
			
			@$sorgu = mysql_query('SELECT * FROM mesaj WHERE mesaj_id='.$nereye)or die (mysql_error());
			
			$exicerik = mysql_result($sorgu,0,'icerik');
			$alanid = mysql_result($sorgu,0,'atan_id'); // Çaprazlama metodu: atan_id bir anda alan_id olacaktır
			$baslık = mysql_result($sorgu,0,'baslik');
			$extarih = mysql_result($sorgu,0,'tarih');
			
			$atan_ad = uye_adı($alanid);
			
			$ynicerik = $_POST["icerik"];
			
			$icerik = $ynicerik."<br /><br />[".$atan_ad." Tarafından] <br />[".$extarih."'de/da yazıldı]<br />-- ".$exicerik;
			
			// Sorgulama
			@mysql_query('UPDATE mesaj SET icerik="'.$icerik.'",tarih="'.date("y.m.d, G:i").'",atan_id="'.$_SESSION["id"].'",alan_id="'.$alanid.'",gorunur_atan=1,onay=0 WHERE mesaj_id='.$nereye)or die(mysql_error());
			
		}
		
		
		return $donut;
		
	}
	
	function uye_ekle($ad,$soyad,$sifre,$kullanıcı_adı,$cins,$e_mesaj){ ///////// TARİH ÖĞESİİİİİİİİ //////// !!!!!!!!!!!
		
		$uyeid = "";
		$mesajid = "";
		$sohbet = "";
		
		$kayıt_tar = date("d.m.y G.i.s");
		$arkadas = '|p ad="gurup" tur="s"|:|s ad="konum"|Genel:;'; // Varsayılan arkadas gurubu oluşturulması...
		
		// Üye id tabloda eklenen son kişi numarasının bir üstündeki sayıdır
		@$sorgu = mysql_query('SELECT uyeid FROM uye') or die ("Ölümcül bu site kullılamaz hale gelmiştir"); 
		$uyeid = mysql_num_rows($sorgu) + 1;
		// Üyenin mesaj kodu kendi id'sinin sonuna "p" eklenmişidr
		
		// Tabloya yeni kayıt ekleniyor
		mysql_query('INSERT INTO uye(uyeid, rutbe, ad, soyad, sifre, kullanıcı_adı, cinsiyet, eposta, kayıt_tar) 
					 VALUES ("'.$uyeid.'","standart","'.$ad.'","'.$soyad.'","'.$sifre.'","'.$kullanıcı_adı.'","'.$cins.'","'.$e_mesaj.'","'.$kayıt_tar.'");') or die(mysql_error());
		
		mysql_query('INSERT INTO uye_2(uyeid) VALUES ("'.$uyeid.'")');
		
		mysql_query("UPDATE uye SET arkadas='".$arkadas."' WHERE uyeid=".$uyeid); // Tekrardan update komutunun alınmasının nedeni arkadas alanına yerleştirilecek olan scrp'in sadece " işaretini kabul edişidir eski ' işaretini değiştimek zor olacağından bu yola baş vurulmuştur...
		
		// Üyenin kendisine has olacak olan tabloları kuruluyor
		kullanici_tabkur($uyeid);
		//mesaj_kur($uyeid)
		
		//echo 'INSERT INTO üye(uyeid, ad, soyad, yasi, cinsiyet, emesaj, mesajid, anasohbet) VALUES("1","'.$ad.'","'.$soyad.'","'.$sifre.'","'.$kullanıcı_adı.'","'.$cins.'","'.$e_mesaj.'","s","c")';
		//$sayi = mysql_result($sorgu,0,"sayi");
		
		//$sayi++;
	
		//$sorgu = mysql_query("UPDATE sayac SET sayi=$sayi WHERE 1");
		
	}
	
	function kullanici_tabkur($uyeid){
		//@mysql_query("CREATE TABLE ".$uyeid."_sohbet(yazanid NUM,icerik TEXT(15),tarih TEXT(3));")or die(mysql_error());
	}
	
	function odadan_cık(){
		// Belli bir odada olup olmadığı kontrol ediliyor
		if (@$_SESSION['odaid'] != ""){
			
			// Oda acık değerinin 1 yapılması hatta 0 yapılıp komple silinmesi
			
			// Oda acık değeri öğreniliyor
			$sorgu = mysql_query('SELECT * FROM ana_sohbet WHERE oda_ad="'.$_SESSION['odaid'].'"')or die(mysql_error());
			
			if (mysql_num_rows($sorgu) > 0){ // Aksi drumu beklenmemektedir aksi takdirde Bu durumda hata var demektir
				if (mysql_result($sorgu,0,"acık") == 1){
					// Oda Kapatma işlemleri
				
					// eski yazışmalar tablosuna kapatılacak olan tablonun bütün verileri eklenir
					
					// ** Özel olarak ilk mesaj ve son mesaj sistem tarafından oluşturulur
					// ** ilk mesaj'ın içeriği odanın açılış tarihini ve kuran kişinin id'sini içerir
					// ** son mesaj'ın içeriği ise odanın kapanış ve kapatan id bilgilerini içerir
					
					// Kuran kişinin öğrenilmesi...
				





					echo "leeüyyn";
					
					// Oda acık değeri 0 yapılyor
					@mysql_query('UPDATE ana_sohbet SET acık=0 WHERE oda_ad="'.$_SESSION['odaid'].'"')or die(mysql_error());
				
				}
				else{
				
					// Oda acık değeri 1 yapılyor
					mysql_query('UPDATE ana_sohbet SET acık=1 WHERE oda_ad="'.$_SESSION['odaid'].'"');
				
				}
			}
			else{
				// Burada Ya Hata Vardır Yada Herkese Açık Bir Odadan Çıkılmıştır...
				
				// Eğer Odanın içinde Özel mesaj yoksa Hata durumu var demektir... // Durum kontrol ediliyor
				
				$sorgu = mysql_query('SELECT * FROM '.$_SESSION['odaid'].' WHERE yazanid=-1 and sil=1');
				if (mysql_num_rows($sorgu) > 0){
					// Herkese açık odadan çıkma işlemi için:
					// Kişi sayısı +1 azaltılıyor ve kişi listesinden kullanıcının adı siliniyor...
					// scrpt methoduyla...
					
					$scrpt = mysql_result($sorgu,0,"mesaj");
					$scrpt_dizi = scrpt_parcala($scrpt);
					
					$scrpt_dizi["u"]["kisisayisi"]--;
					
					// scrpt listesinden kayıt silme işlemi
					$tara= true;
					$i = 0;
					
					while ($tara){
						if (isset($scrpt_dizi[$i])){
							if ($scrpt_dizi[$i]["kullanici"]["u"]["id"] == $_SESSION["id"]){
								
								$scrpt_dizi[$i]["sil"] = true; // Kaydın dikkate alınmaması sağlanıyor...
							}
							
						}
						else{
							$tara = false;
						}
						$i++;
					}
					
					// scrpt birlestirme... // Asıl silme işlemi burada yapılmaktadır
					$scrpt_son = scrpt_birlestir($scrpt_dizi);
					
					// Kaydetme...
					
					@mysql_query("UPDATE ".$_SESSION['odaid']." SET mesaj='".$scrpt_son."' WHERE yazanid=-1 and sil=1")or die(mysql_error());
				
					
				}
				else{
					// HATA BİLDİRİM SİSTEMİ İÇİN...
					
				}
				
				
				
			}
			
			// Son olarak oturum değişkenin sıfırlanması
			$_SESSION['odaid'] = "";
		}
	}
		
	function mesaj_kontrol($neicin){
		if ($neicin == "menu"){
			/*komutlar ve konroller*/
			return "mesajlar.gif";
		}
	}
	
	function bildrim_kontrol(){
		
	}
	
	function arkadas_kontrol($neicin){
		if ($neicin == "menu"){
			/*komutlar ve konroller*/
			return "mesajlar.gif";
		}
	}
	
	function arkadas_istek(){
	
	}
	
	function olay_kontrol($neicin){
		if ($neicin == "menu"){
			/*komutlar ve konroller*/
			return "mesajlar.gif";
		}
	}
	
	function mesaj_yaz($nereye,$odaid = false){
		//echo "aa";
		$mesaj = arındır($_POST['mesaj']);
		$tarih = date("y.m.d G:i:s");
						
		if(!$odaid){
			$oda_id = maske_coz($_GET['odaid']);
		}
		else{
			//include "site/guvenlik.php";
			$oda_id = $odaid;
		}
			
		if ($nereye == "odaya"){

			// id öğrenimi
			$sorgu = mysql_query('SELECT * FROM '.$oda_id);
			
			$id = mysql_num_rows($sorgu); // OLDUKÇA YANLIŞ BİR UYGULAMA SİLME ÖZELLİĞİNİ KISITLIYOR
			
			//echo $oda_id."ss";
			
			@$sorgu = mysql_query('INSERT INTO '.$oda_id.'(id,yazanid,mesaj,tarih) VALUES ('.$id.',"'.$_SESSION['id'].'","'.$mesaj.'","'.$tarih.'")') or die(mysql_error());
			
		}
		else if ($nereye == "bireysel odaya"){
			
			// id öğrenimi
			$sorgu = mysql_query('SELECT * FROM yazısmalar WHERE odaid="'.$odaid.'"');
			
			$id = mysql_num_rows($sorgu); // OLDUKÇA YANLIŞ BİR UYGULAMA SİLME ÖZELLİĞİNİ KISITLIYOR
			
			//echo $oda_id."ss";
			
			@$sorgu = mysql_query('INSERT INTO yazısmalar(id,tarih,odaid,yazanid,mesaj) VALUES ('.$id.',"'.$tarih.'","'.$oda_id.'","'.$_SESSION['id'].'","'.$mesaj.'")') or die(mysql_error());

		}
	
	}
	
	function kaynak_al($neicin,$sadeceurl = false,$yukseklik = 20,$genislik = 20){ // Site icin veri tabanından tasarım resimlerini çeker 
		$stil = "";
		$sorgu = mysql_query('SELECT * FROM tema_kaynak WHERE nesne="'.$neicin.'" and tema_ad="varsayılan"');
		
		$donut ="tema/tema1/bos.gif";
		
		if ($sorgu){
			if (mysql_num_rows($sorgu) > 0){
				$donut = mysql_result($sorgu,0,"adres");
			}
		}
		else{
			echo mysql_error();
		}
		
		if ($sadeceurl){
			return $donut;
		}
		else{
			return '<img style="'.$stil.'" src="'.$donut.'" height='.$yukseklik.' width='.$genislik.'>';
		}

	}
	
	function dil($normal){ // Yönetimde TaM Destek Esneklik Sağlayan Bütün Sitemin Görünür Yazılarını Değiştirmek Amaçlı Fonksiyon
		
		// normal: Sistem ilk tasarlandığı zamanlardaki değiştirilmemiş salt_okunur olan deyimdir 
		// Veri Tabanından Normal İfade Taratılıp Yeni İfade Döndürülüyor...
		
		$sorgu = mysql_query('SELECT * FROM dil_yapılandırması WHERE normal="'.$normal.'" ');
		
		$donut = false;
		
		if ($sorgu){
			if (mysql_num_rows($sorgu) > 0){
				$donut = mysql_result($sorgu,0,'gorunen');
			}
			else{
				
				// Normal ifade veri tabanına ekleniyor
				mysql_query('INSERT INTO dil_yapılandırması(dil,normal,gorunen) VALUES ("tr","'.$normal.'","'.$normal.'")');
				$donut = $normal;
			}
		}
		else {
			$donut = mysql_error();
		}
		
		
		return $donut;
	}
	
	function uye_foto($sdceurl = false,$id = 0,$yukseklik = 30,$genislik = 30,$stil = ""){
		
		if ($id == 0){
			$id = $_SESSION["id"];
		}
		
		// Sorgu ile kullanıcıya ait fotoğraf belirli boyutlarda sayfaya yerlestiriliyor
		
		@$sorgu = mysql_query('SELECT uye_foto FROM uye WHERE uyeid="'.$id.'"')or die(mysql_error()); 
		
		$url = mysql_result($sorgu,0,"uye_foto");
		
		if ($sdceurl){
			return $url;
		}
		else{
			return '<img src="'.$url.'" bgcolor="#CC3300" height='.$genislik.' width='.$yukseklik.' style="'.$stil.'">';
		}
		
	}
	
	function uye_adı($uyeid){
		// Sorgu ile üye adı çıkarılıyor
		// HATA BEKLENİYOR: Üye silme işleminden sonra benzersiz id değişimi olayı olumsuz etkileyebilir...
		$uyead = $uyeid;
		
		$sorgu = mysql_query('SELECT * FROM uye WHERE uyeid='.$uyeid.'');			
		
		if ($sorgu){
			if (mysql_num_rows($sorgu) > 0){
				$uyead = mysql_result($sorgu,0,'kullanıcı_adı');
			}
			else{
				$uyead = "Silinmiş kullanıcı";
			}
		}
		return $uyead;
	}
	
	function uye_id($kullanıcı_adı){
		
		$sorgu = mysql_query('SELECT uyeid FROM uye WHERE kullanıcı_adı="'.$kullanıcı_adı.'"');	
		
		if ($sorgu){
			if (mysql_num_rows($sorgu) > 0){
				$uyeid = mysql_result($sorgu,0,'uyeid');
				
				sistem_cıktısı(false,$uyeid);
			}
			else{
				// echo "howww";
				$uyeid = -1;
			}
		}
		
		return $uyeid;
	}
	
	function uye_durum($uyeid,$sdceimg = false){
		// Uye sorgulanması
		$sorgu = mysql_query('SELECT cevrimici FROM uye WHERE uyeid='.$uyeid);
		
		$donut = "";
		
		if ($sorgu){ // mysql_num_rows'un boolean hatası vermemesi icin
		
			if (mysql_num_rows($sorgu) > 0){
				$durum = mysql_result($sorgu,0,"cevrimici");
				
				if ($durum == 0){
					if ($sdceimg){
						$donut = '<img src="'.kaynak_al("çevrimdışı",true).'" height=10 width=10>';
					}
					else{
						$donut = "Kapalı";
					}
				}
				else{
					if ($sdceimg){
						$donut = '<img src="'.kaynak_al("çevrimici",true).'" height=10 width=10>';
					}
					else{
						$donut = "Açık";
					}
				}
			}
			else{
				if ($sdceimg){
					$donut = '<img src='.kaynak_al("çevrimdışı",true).' height=10 width=10>';
				}
				else{
					$donut = "Kapalı";
				}
			}
		}
		
		return $donut;
	}
	
	function uye_verileri($uyeid){ // Uye'nin Sistem verilerini döker
		$donut = array();
		
		// uyenin deşifre edilmesi
		@$sorgu = mysql_query('SELECT * FROM uye_2 WHERE uyeid="'.$uyeid.'"')or die(mysql_error());
		
		// Alan adlarının alınması...
		$i=1;
		$tara = true;
		
		while ($tara){
			$alan_ad = false;
			
			@$alan_ad = mysql_field_name($sorgu, $i);
			
			$donut[$alan_ad] = mysql_result($sorgu,0,$alan_ad);
			$i++;
			
			if(!$alan_ad){
				$tara = false;
			}
		}

		return $donut;
	}
	
	function uye_bilgileri($uyeid,$izinkntrl = true){ // Bu Fonksiyon Üyenin Paylastığı Bilgilerini Bir Diziye Aktarır 
		$donut = array();
		
		// uyenin deşifre edilmesi
		@$sorgu = mysql_query('SELECT * FROM uye WHERE uyeid="'.$uyeid.'"')or die(mysql_error());
		@$sorgu_izin = mysql_query('SELECT * FROM uye_2 WHERE uyeid="'.$uyeid.'"')or die(mysql_error());
		
		$sql_dizin = mysql_fetch_assoc($sorgu_izin);
		
		//new dbug($sql_dizin);
		
		// Verilerin diziziye aktarımı // İzin kontroll // Arkadaş olma durumları
		$donut["kullanıcı_adı"] = mysql_result($sorgu,0,"kullanıcı_adı");
		
		if (arkadasmı($uyeid)){
			if ($sql_dizin["grnr_adsyad"] == 1 or $sql_dizin["grnr_adsyad"] == 2){$donut["ad"] = mysql_result($sorgu,0,"ad");}else{$donut["ad"] = "Gizlenmiş";} 
			if ($sql_dizin["grnr_adsyad"] == 1 or $sql_dizin["grnr_adsyad"] == 2){$donut["soyad"] = mysql_result($sorgu,0,"soyad");}else{$donut["soyad"] = "Gizlenmiş";}
			if ($sql_dizin["grnr_cinsiyet"] == 1 or $sql_dizin["grnr_cinsiyet"] == 2){$donut["cinsiyet"] = mysql_result($sorgu,0,"cinsiyet");}else{$donut["cinsiyet"] = "Gizlenmiş";}
			if ($sql_dizin["grnr_eposta"] == 1 or $sql_dizin["grnr_eposta"] == 2){$donut["eposta"] = mysql_result($sorgu,0,"eposta");}else{$donut["eposta"] = "Kişi tarafından engellenmiştir";}
			if ($sql_dizin["grnr_medeni"] == 1 or $sql_dizin["grnr_medeni"] == 2){$donut["medeni"] = mysql_result($sorgu,0,"medeni");}else{$donut["medeni"] = "Kişi tarafından engellenmiştir";}
			if ($sql_dizin["grnr_meslek"] == 1 or $sql_dizin["grnr_meslek"] == 2){$donut["meslek"] = mysql_result($sorgu,0,"meslek");}else{$donut["meslek"] = "Kişi tarafından engellenmiştir";}
			if ($sql_dizin["grnr_ktlmsehir"] == 1 or $sql_dizin["grnr_ktlmsehir"] == 2){$donut["nereden"] = mysql_result($sorgu,0,"nereden");}else{$donut["nereden"] = "Kişi tarafından engellenmiştir";}
			if ($sql_dizin["grnr_dogumtar"] == 1 or $sql_dizin["grnr_dogumtar"] == 2){$donut["dogumtar"] = mysql_result($sorgu,0,"dogumtar");}else{$donut["dogumtar"] = "Kişi tarafından engellenmiştir";}
			if ($sql_dizin["grnr_hakkımda"] == 1 or $sql_dizin["grnr_hakkında"] == 2){$donut["hakkında"] = mysql_result($sorgu,0,"hakkımda");}else{$donut["hakkında"] = "Kişi tarafından engellenmiştir";}
			if ($sql_dizin["grnr_sevdiklerim"] == 1 or $sql_dizin["grnr_sevdikleri"] == 2){$donut["sevdikleri"] = mysql_result($sorgu,0,"sevdiklerim");}else{$donut["sevdikleri"] = "Kişi tarafından engellenmiştir";}
			if ($sql_dizin["grnr_asıl"] == 1 or $sql_dizin["grnr_aradığı"] == 2){$donut["aradığı"] = mysql_result($sorgu,0,"aradıgım");}else{$donut["aradığı"] = "Kişi tarafından engellenmiştir";}
		}
		else{
			if ($sql_dizin["grnr_adsyad"] == 1){$donut["ad"] = mysql_result($sorgu,0,"ad");}else{$donut["ad"] = "Gizlenmiş";} 
			if ($sql_dizin["grnr_adsyad"] == 1){$donut["soyad"] = mysql_result($sorgu,0,"soyad");}else{$donut["soyad"] = "Gizlenmiş";}
			if ($sql_dizin["grnr_cinsiyet"] == 1){$donut["cinsiyet"] = mysql_result($sorgu,0,"cinsiyet");}else{$donut["cinsiyet"] = "Gizlenmiş";}
			if ($sql_dizin["grnr_eposta"] == 1){$donut["eposta"] = mysql_result($sorgu,0,"eposta");}else{$donut["eposta"] = "Kişi tarafından engellenmiştir";}
			if ($sql_dizin["grnr_medeni"] == 1){$donut["medeni"] = mysql_result($sorgu,0,"medeni");}else{$donut["medeni"] = "Kişi tarafından engellenmiştir";}
			if ($sql_dizin["grnr_meslek"] == 1){$donut["meslek"] = mysql_result($sorgu,0,"meslek");}else{$donut["meslek"] = "Kişi tarafından engellenmiştir";}
			if ($sql_dizin["grnr_ktlmsehir"] == 1){$donut["nereden"] = mysql_result($sorgu,0,"nereden");}else{$donut["nereden"] = "Kişi tarafından engellenmiştir";}
			if ($sql_dizin["grnr_dogumtar"] == 1){$donut["dogumtar"] = mysql_result($sorgu,0,"dogumtar");}else{$donut["dogumtar"] = "Kişi tarafından engellenmiştir";}
			if ($sql_dizin["grnr_hakkımda"] == 1){$donut["hakkında"] = mysql_result($sorgu,0,"hakkımda");}else{$donut["hakkında"] = "Kişi tarafından engellenmiştir";}
			if ($sql_dizin["grnr_sevdiklerim"] == 1){$donut["sevdikleri"] = mysql_result($sorgu,0,"sevdiklerim");}else{$donut["sevdikleri"] = "Kişi tarafından engellenmiştir";}
			if ($sql_dizin["grnr_asıl"] == 1){$donut["aradığı"] = mysql_result($sorgu,0,"aradıgım");}else{$donut["aradığı"] = "Kişi tarafından engellenmiştir";}
		}

		// *
		// *
		
		return $donut;
	}
	
	function el_salla($kime){ //
	
		if ($kime == 0){ // Eğer yollanacak kisinin id'si 0 ise bu acık kisi icin elsallayanlar varmı yokmu kontrol etme anlamındadır
			// echo "n'oluyo ln";
			// El Sallayanları Görüntüleme
			// Dönüt Sadece kullanıcı adı şeklindedir
			// Kontrol edilen Veriler her defasında temizlenir
			// Her uyeid'si tek seferde yalnızca 1 defa görüntülenir
			
			$sorgu = mysql_query('SELECT el_salla FROM uye WHERE uyeid='.$_SESSION["id"]);
		
			// Veri tabanından çekilen veriler önce değişkene atanıyor
			$veri = mysql_result($sorgu,0,"el_salla");
			
			if ($veri != ""){
				
				$dizin = explode(";",$veri);
				
				// Şuan dizin içinde aratma komutunu bilmediğim için basit bir aratma algoritması yazıyorum
				// Algoritma sadece gelen veriyi önce komple silip tekrar üstne bir defa yazma mantığına göre çalışır
				
				foreach ($dizin as $id){
					$veri = str_replace($id,"",$veri);
					$veri += $id.";";
				}
				
				// Temizlenen veri tekrar parçalanarak sunulur

				$dizin = explode(";",$veri); /// TEST YAPILMADIIIIIIIIIIIII
				
				foreach ($dizin as $id){
					echo '<p>'.uye_adı($id).' Size El Salladı</p>'; 
				}
				
				// İşlem bittikten sonra veri tabanındaki elsallayanlar alanı silinir
				if (isset($_GET["komut"])){
					if ($_GET["komut"] != "elsalla"){
						mysql_query('UPDATE uye SET el_salla="" WHERE uyeid='.$_SESSION["id"]);
						// echo "silindi";
					}
				}
				//return $dizin;
			}
		}
		else{ // El sallama 
			//echo "leeyynn ---- ";
			@$sorgu = mysql_query('SELECT el_salla FROM uye WHERE uyeid='.$kime) or die(mysql_error());
		
			// Veri tabanından çekilen veriler önce değişkene atanıyor
			$veri = mysql_result($sorgu,0,"el_salla");
			
			// Çekilen verilerin üstüne kendi kullanıcımızın verisi ekleniyor
			$veri .= $_SESSION['id'].";";
			
			//echo $veri;
			
			//  Üye Tablo güncelleniyor
			mysql_query('UPDATE uye SET el_salla="'.$veri.'" WHERE uyeid='.$kime);
			
			// Kullanıcaya 'x kişisine el salladınız' Yazısı gönderiliyor
			$mesaj = uye_adı($kime).' ye/ya El Salladınız';
			sistem_cıktısı(false,$mesaj);
			
			//echo $mesaj;
		}
		
	}
	
	function sistem_cıktısı($gorntule = true,$mesaj = "",$derece = 1){ //** Önemli Olaylar da bu vesile ile yazdırılacak
	
		// Görüntüleme islemi her olay icin yalnız 1 defa sağlanacaktır;
		// Tarih Öğesii
		
		if ($gorntule){
			
			@$sorgu = mysql_query('SELECT * FROM sistem_mesaj WHERE uyeid='.$_SESSION['id'].' and uye_icin=1 and goruntule=1')or die(mysql_error());
			$satır = 0;
			
			if ($sorgu){
				$satır = mysql_num_rows($sorgu);
				if ($satır > 0){
					for ($i=0;$i<$satır;$i++){
						// Elde edilen çıktıların yazdırılması
						$veri = mysql_result($sorgu,$i,"mesaj");
						echo '<p style="color:#CC3300">'.$veri.'</p>';
						
						mysql_query("UPDATE sistem_mesaj SET goruntule=0 WHERE uyeid=".$_SESSION["id"]);
					}
					
					// Gönderileri Silme
					
					if (isset($_GET["komut"])){
						if ($_GET["komut"] != "elsalla"){
							mysql_query('UPDATE uye SET el_salla="" WHERE uyeid='.$_SESSION["id"]);
							// echo "silindi";
						}
					}	
				}
			}
		}
		else{
			$tarih = date("y.m.d, G:i");
			$uyeicin = 1; // Görüntüleme derecesidir
			
			if ($derece == 1){
				// 1. dereceden mesajlar kullanıcı tarafından görüntülenebilir mesajlardır
				$uyeicin = 1; 
			}
			else if($derece == 2){
				// 2.derceden mesajlar sadece web yöneticileri tarafından görüntülenebilirler
				$uyeicin = 0; 
			}
			
			@mysql_query('INSERT INTO sistem_mesaj(uyeid,mesaj,goruntule,uye_icin,tarih) VALUES ("'.$_SESSION["id"].'","'.$mesaj.'",1,"'.$uyeicin.'","'.$tarih.'")')or die(mysql_error());
		}
	
	}

	function gecmis_ekle(){
		// gecmis Öğeleri Session üzerinde saklanacak // Bütün gecmis öğelerin neden saklanması gerektiğini unuttum
		// yeni gelen veri veritabanına tarih öğesiyle eklenecek ayrıca sessıonada kaydedilecek
		
		if (oturum_kontrol()){
			//echo $_SESSION["gecmis"][count($_SESSION["gecmis"]) - 1];
			
			// $_SESSION["gecmis"][] = arındır($_SERVER["QUERY_STRING"]);
			
			// Veri tabanında update yöntemiyle yeni adres kaydadilir
		
			mysql_query('UPDATE uye SET sonkonum="'.arındır($_SERVER["QUERY_STRING"]).';'.date("y.m.d, G:i").'" WHERE uyeid='.$_SESSION["id"]);
			mysql_query('UPDATE uye SET sonislem_tarih="'.date("d.m.y G:i:s").'" WHERE uyeid='.$_SESSION["id"]);
			
		}
	}
	
	function tarihFarki($d1, $d2=null, $format="*"){ // Farklı Bir Kaynaktan Alınmıstır
		if($d2==null){
			$d2=$d1;
			$d1=time();
		}

		if(!is_int($d1)) $d1=strtotime($d1);
		if(!is_int($d2)) $d2=strtotime($d2);
		$d=abs($d1-$d2);

		$format=strtolower($format);
		if(empty($format)) $format="*";

		$result = array();

		if($format=="*" || $format=="gun")    $result["gun"]   = floor($d/(60*60*24));
		if($format=="*" || $format=="ay")     $result["ay"] = floor($d/(60*60*24*30));
		if($format=="*" || $format=="yil")    $result["yil"]  = floor($d/(60*60*24*365));
		if($format=="*" || $format=="hafta")  $result["hafta"]  = floor($d/(60*60*24*7));
		if($format=="*" || $format=="saat")   $result["saat"]  = floor($d/(60*60));
		if($format=="*" || $format=="dakika") $result["dakika"]= floor($d/60);

		if($format!="*") return $result[$format];
		else return $result;
	}
	
	function teklif_yolla(){
		// Prensib: id'si belirli olan uyenin tablosuna istek atılır
		// İstek onaylanırsa onaylayan tarafından arkadas ekleme islemi gerçeklestirilir
	
		if ($_GET['id']){
			
			$sorgu = mysql_query('SELECT arkadas_istek FROM uye WHERE uyeid='.$_GET['id'])or die(mysql_error());;
			
			$istek_cache = mysql_result($sorgu,0,"arkadas_istek");
			
			// Ayrıştırılabilir İstek komutu yazılıyor
			$istek_cache .= '|p ad="istek" |:|u ad="kim"|'.$_SESSION["id"].':|s ad="tarih"|'.date("y.m.d G:i").';';
			
			// Son haliyle veri tabanına yazılıyor
			mysql_query("UPDATE uye SET arkadas_istek='".$istek_cache."' WHERE uyeid=".$_GET['id'])or die(mysql_error());
			
			sistem_cıktısı(false,"Arakadaşlık Teklifiniz Gönderildi");
		}
	}
	
	function arkadas_listesi($guruplu = true,$uyeid = 0){
		
		/* Dönüt arraydır:
			
			guruplu ve gurupsuz olarak ikiye ayrılır ;
			
			guruplularda arkadaş listesi işlenmden sadece birey birey dönüte yerleştirlirken,
			gurupsuzlarda bireyi işleyerek sadece id'sini dönüte yerleştirir
		
		*/
		
		$kisiler = array();
		
		$i = 0;
		
		$donut = array();
		$liste = array();
		
		$tara = true;
		
		if ($uyeid == 0){
			$uyeid = $_SESSION["id"];
		}
		
		@$sorgu = mysql_query('SELECT arkadas FROM uye WHERE uyeid="'.$uyeid.'"')or die(mysql_error());
		
		$islenmemis = mysql_result($sorgu,0,"arkadas");
		
		/* eski sistem
		
		/ Parçalama islemi: 
			Veri ";" isaretleri arasındaki parçalara bölünür
			
			NOT:Listeleme yapılırken bulunan her string parçasının ilk terimi incelenir 
			eğer ilk karekter '%' harfi değilse normal kullanıcı id'si gibi davranılır
			değilse yeni grup adıymış gibi davranılır
			
			DİKKAT:birleştirme işlemi hayati önem taşımaktadır ***********
		/
		
		$liste = explode(";",$islenmemis);
		
		if ($guruplu){
			$donut = $liste;
		}
		else{
			// Filtreleme ile listenin içindeki %'li ifadeler ayırılıyor
			foreach($liste as $icerik){
				
				$ilkkrkter = substr($icerik,0,1);
				
				if ($ilkkrkter != "%"){
					$donut[] = $icerik;
				}
			}
		}
		*/
		if ($guruplu){
			$donut = scrpt_parcala($islenmemis);
		}
		else{
			$liste = scrpt_parcala($islenmemis);
			while ($tara){
				if (isset($liste[$i])){
					// Uye id alma;
					$donut[] = $liste[$i]["arkadas"]["u"]["id"];
					$i++;
				}
				else{
					$tara = false;
				}
			}
		}
		
		return $donut;
	}
	
	function arkadas_ekle(){
		// Prensip: istek listesinden eklenecek kişiyi siler ve arkadaş listesine ekler
		//          yollayan kişinin arkadaş listesine kullanıcıyı ekler...
		
		$sorgu = mysql_query('SELECT arkadas_istek FROM uye WHERE uyeid='.$_SESSION["id"]);
		
		$scrpt_giris = mysql_result($sorgu,0,"arkadas_istek");
		$scrpt_sonuc = scrpt_sil($scrpt_giris,$_GET["id"]);
		
		//new dbug(scrpt_parcala($scrpt_sonuc));
		
		// Değiştirilmiş scrpt verimiz veri tabanına işleniyor
		@mysql_query("UPDATE uye SET arkadas_istek='".$scrpt_sonuc."' WHERE uyeid=".$_SESSION["id"])or die(mysql_error());
		
		// Ön arkadaş listeleri alınıyor
		$kisibilg = scrpt_sub($scrpt_giris,$_GET["id"]);
		$kim = $kisibilg["istek"]["u"]["kim"];
		
		$sorgu = mysql_query("SELECT arkadas FROM uye WHERE uyeid=".$_SESSION["id"]);
		$bnm_ark_cache = mysql_result($sorgu,0,"arkadas");
		
		$sorgu = mysql_query("SELECT arkadas FROM uye WHERE uyeid=".$kim);
		$yni_ark_cache = mysql_result($sorgu,0,"arkadas");
		
		// Son olarak yeni arkadaş kendi listemize ve kullanıcının listesine ekleniyor		
		$scrpt_ekleme = '|p ad="arkadas" |:|s ad="konum"|Genel:|u ad="id"|'.$kim.';';
		$scrpt_atan_icin = '|p ad="arkadas" |:|s ad="konum"|Genel:|u ad="id"|'.$_SESSION["id"].';';
		
		@mysql_query("UPDATE uye SET arkadas='".$bnm_ark_cache.$scrpt_ekleme."' WHERE uyeid=".$_SESSION["id"])or die(mysql_error()); // Kendi arakadaş listemizi güncelledik 
		@mysql_query("UPDATE uye SET arkadas='".$yni_ark_cache.$scrpt_atan_icin."' WHERE uyeid=".$kim)or die(mysql_error()); // İstek yollayan kullanıcının arkadaş listesini güncelledik
	
		sistem_cıktısı(false,uye_adı($kim)." Artık sizin arkadaşınız");
	}

	function arkadasmı($id){ // Belirtilen id'nin kullanıcının arkadaşı olup olmadığını kontrol eder
		
		$sorgu = mysql_query('SELECT arkadas FROM uye WHERE uyeid='.$_SESSION["id"]);
		$arkds_scrpt = mysql_result($sorgu,0,"arkadas");
		
		// stripos yardımı ile scriptimiz içindeki bir dyimi -bu deyim arkadaşlık kontrolünün delilidir- aratıyoruz
		// eğer dönen değer true ise sorgulana birader arkadaş değilse arkadaşlık tablosunda kayıtlı değildir;
		$pos = stripos($arkds_scrpt,'|u ad="id"|'.$_GET["id"]);
		
		//echo 'SELECT arkadas FROM uye WHERE'.$_SESSION["id"].'------'.$pos.'---|u ad="id"|'.$_GET["id"].$arkds_scrpt;
		
		if ($pos != ""){$donut = true;}else{$donut = false;}
		
		return $donut;
	}

	function arkadasın_arkadasımı($id,$tür = "boolean"){
		// Bütün arkadaşların taratılması söz konusudur
		// tür değişkeni boolean ise true false sayı ise kaç arkadasın ortak olduğu...
		
		$kimlerle = array();
		$toplam = 0;
		
		$ark_list = arkadas_listesi(false);
		
		foreach ($ark_list as $ark_id){
			// Çıkarılan idlerin arkadaş listelerine teker teker gidilerek arkadası olup olmadığı öğreniliyor
			// Ayrıca kimlerle arkadaş olduğunu $_SESSION içine kaydediliyor // performans için
			
			$sorgu = mysql_query('SELECT arkadas FROM uye WHERE uyeid='.$ark_id);
			$arkds_scrpt = mysql_result($sorgu,0,"arkadas");
			
			// stripos yardımı ile scriptimiz içindeki bir dyimi -bu deyim arkadaşlık kontrolünün delilidir- aratıyoruz
			// eğer dönen değer true ise sorgulanan birader arkadaş, değilse arkadaşlık tablosunda kayıtlı değildir;
			$pos = stripos($arkds_scrpt,'|u ad="id"|'.$id);
			
			//echo 'SELECT arkadas FROM uye WHERE'.$_SESSION["id"].'------'.$pos.'---|u ad="id"|'.$_GET["id"].$arkds_scrpt;
			
			if ($pos != ""){
				$donut = true;
				$kimlerle[] = $ark_id;
				$toplam++;
			}
			else{
				$donut = false;
			}
		}
		
		if (count($kimlerle) > 0){
			$_SESSION["ortak_ark_says_".$id] = $kimlerle;
		}
		
		if ($tür == "boolean"){
			return $donut;
		}
		else if ($tür == "sayı"){
			return $toplam;
		}
	}
	
	function arkadas_ara($aranan,$ada_göre_ara = true){
		
	
		// Kademeli olarak aratma işlemi yapılacaktır 
		// Önce yakınlık sıralamasına sonrada alfabetik sıraya göre sıralanıp çıktı alınacaktı
		$sonuc_listesi = array();
		
		$isim = explode($aranan," ");
		$ad = $isim[0];
		@$ad1 = $isim[1];
		@$soyad =$isim[2];
		
		if ($ada_göre_ara){
			$sıralama = "order by ad asc";
		}
		else if ($ada_göre_ara){
			$sıralama = "order by kullanıcı_ad asc";
		}
		
		// Sorgu cümlemiz aynı anda sıralamayıda yapacak ve aratılmak isteneni yaklaşık olarak bulacaktır
		
		@$sorgu = mysql_query('SELECT uyeid FROM uye WHERE ad="'.$ad.'" and soyad="'.$ad1." ".$soyad.'" 
							or ad="'.$ad." ".$ad1.'" and soyad="'.$soyad.'"
							or ad="'.$ad.'"
							or ad="'.$ad." ".$ad1.'"
							or ad="'.$ad." ".$ad1." ".$soyad.'"
							or kullanıcı_ad="'.$ad.'" 
							or kullanıcı_ad="'.$ad." ".$ad1.'"
							or kullanıcı_ad="'.$ad." ".$ad1." ".$soyad.'" order by ad asc')or die(mysql_error());
		
		foreach (mysql_fetch_array($sorgu) as $id){
			
			// Bulunan id'lerin belli filtrelerden geçirilmesi //
			
			$yakınmı = arkadasın_arkadasımı($id,"boolean");
			
			if ($yakınmı){
				$sonuc_listesi[] = $id;
			}
		}
		// İkinci döngüyle arkadaş olmayanlarda listeye ekleniyor
		foreach (mysql_fetch_array($sorgu) as $id){
		
			$sonuc_listesi[] = $id;
			
		}
		
		return $sonuc_listesi;
	}
	
	function cevrimicimi($uyeid){
		/// tewamm ///
	}
	
	function sifre_degis_kontrol(){
		$donut = false;
		
		// Şifre değişimi için ön koşullar kontrol ediliyor
		if (isset($_POST["yn_sifre"])){ // Her hangi post verisinin olup olmadığını kontrol için
			if ($_POST["yn_sifre"] != ""){
				if ($_POST["ex_sifre"] != ""){
					if ($_POST["ex_sifre"] == $_SESSION["sifre"]){
						if ($_POST["yn_sifre"] == $_POST["yn_sifre_ony"]){
							$donut = true;
						}
						else {
							// Hata mesajı yazdırılıyor
							sistem_cıktısı(false,"Onay şifresini yanlış girdiniz");
						}
					}
					else{
						// Hata mesajı yazdırılıyor
						sistem_cıktısı(false,"Eski şifreniz uyumsuz");
					}
				}
				else{
					// Hata mesajı yazdırılıyor
					sistem_cıktısı(false,"Eski Şifre Girişi yapmadınız");
				}
			}
		}
		
		return $donut;
	}

	function izin_kontrol($kntrl_edilen,$id){
		// Uye_2 tablosundaki izin verilerine göre çıktı sağlanıyor
		
		$sorgu = mysql_query('SELECT * FROM uye WHERE uyeid="'.$uyeid.'"')or die(mysql_error());
		
		if($sql_dizin["kntrl_edilen"] == 1 or 2){$donut = true;}else{$donut = false;} 
		
		return $donut;
	}
	
	function mail_at(){
		require_once('site/mail/class.phpmailer.php');
		$mail = new PHPMailer(true);

		$mail->IsSMTP(); // sınıfı smtp ile kullanacağımızı tanımlıyoruz

		try {
			$mail->Host= "mail.sitenizinadı.com"; // SMTP sunucu
			$mail->SMTPDebug = 2; // SMTP için sunucuyu test ediyoruz
			$mail->SMTPAuth= true;
			$mail->Host= "mail.sitenizinadı.com";
			$mail->Port       = 26; // Mail için port numarasını girmeliyiz.
			$mail->Username   = "isminiz@sitenizinadı.com"; // SMTP kullanıcı adınız
			$mail->Password   = "şifreniz"; // SMTP kullanıcı şifreniz
			$mail->AddReplyTo('isminiz@sitenizinadı.com', 'Cihan ARAT'); //mail adresiniz ve isminiz
			$mail->AddAddress('isim@siteadı.com', 'John Doe'); // Mail yollanacak adres ve ismi
			$mail->SetFrom('isminiz@sitenizinadı.com', 'Cihan ARAT');
			$mail->AddReplyTo('isminiz@sitenizinadı.com', 'Cihan ARAT');
			$mail->Subject = 'Aratmedya.com phpmailer kullanımı'; //Mailimizin konusu
			$mail->AltBody = 'İstersek bir alt açıklama girebiliriz.';
			$mail->MsgHTML(file_get_contents('icerik.html')); //HTML olarak mail yollamak istersek
			//$mail->AddAttachment('images/phpmailer.gif');      // Dosya eklemek
			//$mail->AddAttachment('images/phpmailer_mini.gif'); // dosya eklemek
			$mail->Send();
			
			echo "Mesaj gönderildi\n";
			
		} catch (phpmailerException $e) {
			echo $e->errorMessage();
		} catch (Exception $e) {
			echo $e->getMessage();
		}
	}
	
	function dosya_yukle($getiren,$hedef,$ad = false){
		// Hata durumu ortadan kaldırılıyor ve dosya belirtilen hedefe upload ediliyor
		$donut = ":*adn*:";
		$hata = false;
		$tmp_name = "";
		// getiren string'in içindeki boşluklar "_" işaretine dönüştürülüyor...
		
		$getiren = str_replace(" ", "_", $getiren);
		
		//echo "asd";
		
		if ($_FILES[$getiren]["error"] == 0){
			
			// echo "ho";
			
			$tmp_name = $_FILES[$getiren]["tmp_name"];
			
			if ($ad){
				$dsyaadı = $ad;
				
				// echo $_FILES[$getiren]["type"];
				
				if ($_FILES[$getiren]["type"] = "image/png"){
					$dsyaadı .= ".png";
				}
				else if ($_FILES[$getiren]["type"] = "image/gif"){
					$dsyaadı .= ".gif";
				}
				else if ($_FILES[$getiren]["type"] = "image/jpeg"){
					$dsyaadı .= ".jpg";
				}
				else if ($_FILES[$getiren]["type"] = "image/bitmap"){
					$dsyaadı .= ".bmp";
				}
				else {
					$donut = false;
					$hata = true;
					//echo "hata2";
				}

			}
			else{
				$dsyaadı = $_FILES[$getiren]["name"];
			}
			
			
			//echo $dsyaadı;
			if ($hata == false){
				
				move_uploaded_file($tmp_name, $hedef.$dsyaadı); // !!!!! ANAHTARLANMIŞ OLARAK KAYDEDİLECEKKKK !!!!! //
				$donut = $hedef.$dsyaadı;
				
			}
		}
		else if ($_FILES[$getiren]["error"] == 1){
			$donut = false;
			$hata = true;
			
			// echo "hata2";
		}
		
		//new dbug($_FILES);
		
		return $donut;
	}
	
	///// HATA: $k+(($i-1)*10) FORMÜLÜNDE KARARSIZLIK VAR.... //////
	
	function sayfala($dizin,$sayfaad,$maxdeger = 10){ // 10 sistem varsayılanıdır...
		// Amaç Gelen Dizindeki Verileri Sunucu Çerezi yardımıyla rastgele üretilmiş id'lerle sayfalamaktır...
		
		// unset($dizi[5]); // Elemanı diziden siler
		
		$sayfa = "";
		$donut = array();
		
		$i = 1;
		
		$_SESSION["sayfalar"][$sayfaad] = array();
		
		while(count($dizin) > 0){
		
			//new dbug($dizin);
			
			$sayfa = id_maskele($i,$sayfaad);
			
			$_SESSION["sayfalar"][$sayfaad][$i] = array();
			
			for ($k=0;$k <= $maxdeger ;$k++){
				
				////// $k+(($i-1)*maxdeger ) matamatiksel fonksiyonu bir sonraki indexi maxdeger değerinden sonra dahi söylemeye devam eder....
				////// ancak bu matamatiksel formülde çözümlenemeyen bir kararsızlık var :(
				
				if (isset($dizin[$k+(($i-1)*$maxdeger )])){ 
					$_SESSION["sayfalar"][$sayfaad][$i][$k] = $dizin[$k+(($i-1)*$maxdeger)];
					unset($dizin[$k+(($i-1)*$maxdeger)]);
					//echo ($k+(($i-1)*$maxdeger))."silindi<br />";
				}
				else{
					//echo $k+(($i-1)*$maxdeger)."denemesi başarısız<br />";
				}
			}
			
			$i++;
		}
		
		$_SESSION["sayfalar"][$sayfaad]["max_sayfa"] = $i-1;
	
	}
	
	function sayfa_dizisi($sayfa_id = "",$sayfaad){
		
		// 	Amaç sunucu çerezi(session) içinden verilen sayfano ve ada ilişkilendirilmiş olan dizini çağırmaktır...
		
		$donut = false; // HAYATİ: //** Mesaj Sistemi için **//
		$sayfa_no = 1;
		
		// Sayfa_id'in değerinin öğrenilmesi
		if ($sayfa_id != ""){
			$sayfa_no = maske_coz($sayfa_id);
		}
		
		//echo "Verilen sayfa adı:".$sayfa_id."<br>";
		//echo "Çıkan sayfa no:".$sayfa_no."<br>";
		
		@$donut = $_SESSION["sayfalar"][$sayfaad][$sayfa_no];
		
		return $donut; 
	}
	
	function begeni_sayısı($neicin,$id){
		// Gönderilmiş olan herhangi bir bildirm veya olay için ki beğenileri toplam beğeniyi gösterir
		$donut = 0;
		
		if ($neicin == "paylaşım"){
			@$sorgu = mysql_query('SELECT begeni_say FROM paylasımlar WHERE id='.$id)or die(mysql_error());
			$donut = mysql_result($sorgu,0,"begeni_say");
		}
		
		return $donut;
	}
	
	function mesaj_filtreleme($icerik){
		
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
		
		return $yaz;
	}
?>














