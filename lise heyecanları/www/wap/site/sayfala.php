﻿<?php

	//require "site/tarih_farki.php";
	
	/*
		* Sürüm 0.001 Tarih: ~~~~~ ~~.11.2011
		*
		** Getiriler
		**
		*** Sistemin İlk Adımları Atıldı
		*** Tek Sayfa Profili Geliştirildi
		*
		*
		* Sürüm 0.002 Tarih: 22:08 07.02.2012
		*
		** Getiriler
		**
		*** Block Sistemi Uygulama için ilk adım atıldı
		*** İlk kez sürüm ifadesi kullanıldı
		*** Dil Yapılandırılması Eklendi
	*/

	
	// call_user_func('fonksyn ismi', 'fonksiyon argümanları');
	
	
	//!!!! HATAAA :!!!! http://localhost:8080/wap/index.php?komut=mesaj&git=gelen&sayfa=1&sayfa=2&sayfa=1&sayfa=0 //////
	
	//!!!! SORUN YARATABİLİR : sayfa yönlendirme göstergecinde bir kararsıszlık var.... kimi zaman 5 kimi zaman 4 son değerde 3 değerlik çıktı üretiyor...
	
	//!!!! SORUN YARATABİLİR : sayfa_dizisi($_GET["sayfa"],... Şekilndeki kullanım $_GET["sayfa"] değeri tanımlanmamış olduğunda hata verebilir
	
	// !!!! EK: Arkadas menuye birde paylaşımlarını gör linki eklenmeli !!!! //

	// Otomatik HATA BİLDİRİM: odadan ayrılma ve oda silme gibi işlemlerin gerçekleştirildiği bölümde detaylar vardır
	
	function sayfa_kur(){
		/*  	Amaç sunucu üzerinde sadece tek bir sayfa barındırarak sayfa içeriklerini kodlara yaptırmaktır
			sadece tek sayfa içeriğine bu fonksiyon yerleştirildiğinde get ve post methotlarına göre sayfayı
			ayırıp gerekli fonksiyonları çalıştıracaktır...

				Yani sitenini bel kemiği bu ana fonksiyon olacaktır.
		*/

		/* Başlangıç: temel öğeler; banner,menü vs. */


		// echo '<a href="index.php"><img src="baslik.gif" /></a><br />';
		if (isset($_GET['komut'])){
			if($_GET['komut'] == 'sohbet'){
				menu_kur('sohbet');
			}
			else if($_GET['komut'] == 'kayıt'){
				menu_kur('kayıt');
			}
			else{
				menu_kur("giris");
			}
		}
		else{
			menu_kur("giris");
		}
		
		
		if (oturum_kontrol()){
		
			// Sistem Çıktılarının Yazdırılması
			el_salla(0); // El sallayanlar;
			sistem_cıktısı();
		}

			
		/* 	Adım 1: Sayfanın adının öğrenilmesi:

			Eğer sayfamıza herhangi bir get veya post bilgileri yollanmamışsa sayfamız ana giriş,
			Eğer sayfamıza sayfa="kayıt" verisi gelmişse sayfamız kayıt sayfası,
			Eğer sayfamıza post[kayıt_kullanıcı=***] verisi gelmişse sayfamız kayıt kontrol sayfası,
			Eğer sayfamıza get[sayfa="giris"] şeklinde veri gelmişse sayfamız giriş sayfası,
			Eğer sayfamıza post[kullanıcı=***] şeklinde veri gelmişse sayfamız giriş kontrol sayfası,
			*
			*
			*

			Adım 2: Görüntüle Belirlenen kriterlerdeki sayfalar veri tabanlarından çekilen özel bilgilerle
					oluşturulur.
		*/

		if(isset($_POST['kayıt_kullanıcı'])){
			/*
				Burada belli başlı kriterler kontrol edilir açık üye olması gibi durumlar
				veya postdan şifre vb. bilgilerde gelmişse kullanıcı bilgileri kontrol edilir duruma göre dönüt yollanır
			*/

			// Hata araması yapılıyor



			if (girdileri_sorgula('kayıt')){
				echo "tmmm";
				uye_ekle($_POST['sifre'],$_POST['kayıt_kullanıcı'],$_POST['cins'],$_POST['emesaj']);
				header('location:index.php');
			}
		}
		else if(isset($_POST['kullanıcı'])){
			/*
				Burada belli başlı kriterler kontrol edilir açık üye olması gibi durumlar
				veya postdan şifre vb. bilgilerde gelmişse kullanıcı bilgileri kontrol edilir duruma göre dönüt yollanır
			*/
			if (isset($_GET["komut"])){ // Post verisini nereden geldiği sorgulanıyor
				echo "aass";
				if ($_GET["komut"] == "ayarlar"){ // Ayarlar sayfasından gelen bilgiler şifre değiştirme vs bilgilerindir onlar işleniyor

					// Temel kontrollerle eski şifre değişimi ve kullanıcı adı değişimi yapılıyor;

					if ($_POST["kullanıcı"] != ""){ // Kullanıcı adı değişimi
						$deger = arındır($_POST["kullanıcı"]);

						if (uye_id($deger) == -1){
							$_SESSION["kullanıcı_ad"] = $deger;
							// Veritabanına yerlestirme

							@mysql_query('UPDATE uye SET kullanıcı_adı="'.$deger.'" WHERE uyeid='.$_SESSION["id"])or die(mysql_error());
							//echo 'UPDATE uye SET ad="'.$deger.'" WHERE uyeid='.$_SESSION["id"];

							// Sonuç Bildiriliyor
							sistem_cıktısı(false,"Kullanıcı Adınız Değiştirildi");
						}
						else{
							// Hata mesajı yazdırılıyor
							sistem_cıktısı(false,"Bu kullanıcı adı kullanılıyor");
							sistem_cıktısı(false,"Kullanıcı adınız değiştirilmedi");
						}
					}

					if (sifre_degis_kontrol()){ // Ön koşulların doğruluğu kontrol ediliyor
						$deger = arındır($_POST["yn_sifre"]);

						$_SESSION["sifre"] = $deger;
						// Veritabanına yerlestirme

						@mysql_query('UPDATE uye SET sifre="'.$deger.'" WHERE uyeid='.$_SESSION["id"])or die(mysql_error());
						//echo 'UPDATE uye SET ad="'.$deger.'" WHERE uyeid='.$_SESSION["id"];

						// Sonuç Bildiriliyor
						sistem_cıktısı(false,"Hesabınızın Şifresi Değiştirildi");
					}


					// Hesap bilgileri sayfasına dönüş yapılıyor
					header("location:index.php?komut=ayarlar&islem=hesap");
				}
				if ($_GET["komut"] == "giris"){
					if (girdileri_sorgula('giris')){
	
						if (oturum_baslat()){
							echo dil("giris başarılı");
						}
						else{
							echo dil("Lütfen kullanıcı adınızı kontrol ediniz");
						}
					}
				}
				
			}
			else{
				
				if (girdileri_sorgula('giris')){

					if (oturum_baslat()){
						echo dil("giris başarılı");
					}
					else{
						echo dil("Lütfen kullanıcı adınızı kontrol ediniz");
					}
				}
			}
			

		}
		else if (isset($_GET['komut'])){
			
			if($_GET['komut'] == 'kayıt'){
				kayıt_pan(); //
			}
			else if($_GET['komut'] == 'giris'){
				giris_pan(); //
			}
			
			if (oturum_kontrol()){ // Güvenlik için...
				
				$komut = $_GET['komut'];

				// Bazı ek olayalar:
				// Odadan çıkış kontrol

				// Eğer komut tekrar sohbet olarak dönmezse durumdan da anlaşşılabileceği üzere odadan çıkılmış demektir

				if ($komut != "sohbet"){
					odadan_cık(); // Burada ek kontrollerde sağlandıktan sonra çıkma işlmei gerçekleştirilecek
				}
				else{
					if (!isset($_GET['odaid'])){
						odadan_cık();
					}
				}
				
				// Sürüm 0.002 'den  sonra eklenmiştir //
				
				if ($komut == "sayfa"){
					
					// Sayfanın Adı Bulunuyor
					$sayfa_id = maske_coz($_GET["sayfaid"]);
					
					// Bulunan Sayfa Veri Tabanından Çekilerek İçeriğindeki Bloklar Sayfaya Yazdırılıyor //
					
					
				}
				// ** // ** // ** // ** // ** // ** // ** //
				
				else if ($komut == 'cıkıs'){
					oturum_kapat(); //
					header('location:index.php');
				}
				else if ($komut == 'profil'){ //
					//echo "tmm1 ";
					if (isset($_GET["git"])){
						//echo "tmm2 ";
						if ($_GET["git"] == "bilg_duzenle"){
							profil_guncelle();
							header("location:index.php?komut=profil");
						}
						elseif ($_GET["git"] == "id"){
							profil_pan(true);
							$_SESSION["gecmis"][] =  arındır($_SERVER["QUERY_STRING"]);
							$_SESSION["gecmis_ad"][] = "Profil";
						}
						elseif ($_GET["git"] == "ayarlar"){
							ayar_pan();
							$_SESSION["gecmis"][] =  arındır($_SERVER["QUERY_STRING"]);
							$_SESSION["gecmis_ad"][] = "Ayarlar";
						}
						elseif ($_GET["git"] == "paylasim"){
							
						}
						elseif ($_GET["git"] == "profil_foto"){ // Profil resmi değiştirme
							if (isset($_GET["isle"])){ // paylaşılmış fotolardan resim değiştirme
								
								// paylaşılmış foto'lar arasından foto seçip değiştirme
								
								$sorgu = mysql_query('SELECT icerik FROM paylasımlar WHERE id="'.maske_coz($_GET["isle"]).'"');
								
								$icerik = scrpt_parcala(mysql_result($sorgu,0,"icerik"));
								
								$yol = $icerik["s"]["adres"]; // .............
								
								
							}
							else{
								profil_foto();
							}
						}
						elseif ($_GET["git"] == "profil_foto_yukle"){
							
							$dosya_ad = dosya_yukle("dosya","site/kullanicilar/",kriptol1n($_SESSION["id"].'sosyal'.$_SESSION["id"].'manya'.$_SESSION["id"]));
							
							// Veritabanı kayıttt
							@mysql_query('UPDATE uye SET uye_foto="'.$dosya_ad.'" WHERE uyeid='.$_SESSION["id"])or die(mysql_error());
							
							sistem_cıktısı(false,"Profil resminiz değiştirilmiştir");
							
						}
					}
					else{
						profil_pan();
						$_SESSION["gecmis"][] =  arındır($_SERVER["QUERY_STRING"]);
						$_SESSION["gecmis_ad"][] = "Profil";
					}

				}
				else if ($komut == 'arkadas'){ //

					if (isset($_GET["git"])){
						if ($_GET["git"] == "menu"){
							arkadas_menu();
							$_SESSION["gecmis"][] =  arındır($_SERVER["QUERY_STRING"]);
							$_SESSION["gecmis_ad"][] = "Arkadaş";
						}
						if ($_GET["git"] == "bul"){
							arkadas_ara_pan();
							$_SESSION["gecmis"][] =  arındır($_SERVER["QUERY_STRING"]);
							$_SESSION["gecmis_ad"][] = "Arkadaş Aratma";
						}
						if ($_GET["git"] == "yeni_uyeler"){
							yeni_kaydolanlar();
							$_SESSION["gecmis"][] =  arındır($_SERVER["QUERY_STRING"]);
							$_SESSION["gecmis_ad"][] = "Arkadaş Aratma";
						}
						if ($_GET["git"] == "cevrimici"){
							acık_kullanıcılar();
							$_SESSION["gecmis"][] =  arındır($_SERVER["QUERY_STRING"]);
							$_SESSION["gecmis_ad"][] = "Arkadaş Aratma";
						}
						if ($_GET["git"] == "tum_uyeler"){
							butun_kullanıcılar();
							$_SESSION["gecmis"][] =  arındır($_SERVER["QUERY_STRING"]);
							$_SESSION["gecmis_ad"][] = "Arkadaş Aratma";
						}
					}
					else{
						arkadas_pan();
						$_SESSION["gecmis"][] =  arındır($_SERVER["QUERY_STRING"]);
						$_SESSION["gecmis_ad"][] = "Arkadaşlarım";
					}

				}
				else if ($komut == 'bildirim'){
					
					bildirim_pan();
					
				}
				else if ($komut == 'paylasimlar'){
					if (isset($_GET["sayfa"])){
						if ($_GET["sayfa"] == "gizlilik"){
							paylasım_gizlilik_pan(); ///// !!!!!!!!!!! YAZILMADII !!!!!!!!!!! //
						}
					}
					else{
						if (isset($_POST["yazi"])){ // Herhangi bir paylaşımda bulunulup bulunulmadığı kontrol ediliyor
							if ($_POST["yazi"] != ""){
							
								// Paylaşılan yazı veritabanına kaydediliyor
								if (isset($_POST["gizlilik"])){
									// Gizlilik Ayarlarını yapmak için farklı bir pencereye yönlendirme

									// Bir sonraki adımda kullanılmak üzere resimin yolu bir değişkene atılıyor
									$_SESSION["paylasılan_veri"] = $_POST["yazi"];

									// Farklı sayfaya yönlendirilme

									header("location:index.php?komut=paylasimlar&sayfa=gizlilik");
								}
								else{
									// Yazının veritabanına kaydedilmesi
									$sorgu = mysql_query("SELECT * FROM paylasımlar");

									$no = mysql_num_rows($sorgu); // Son kaydın index'i alınıyor
									$tarih = date("d.m.y, G:i:s");
									$icerik = $_POST["yazi"];
									
									$yorum = '|s ad="s_yorum"|0;'; // Varsayılan toplam yorum sayısı
									
									mysql_query("INSERT INTO paylasımlar(id,gondrn_id,tarih,tur,icerik,yorum,izinler,goruntule,begeni)
												 VALUES (".$no.",".$_SESSION["id"].",'".$tarih."','yazı','".$icerik."','".$yorum."','',1,0)");
									
									sistem_cıktısı(false,"Yazınız Paylaşıldı".mysql_error());
									sistem_cıktısı();
								}
							}
							
							if (isset($_FILES["res"])){
								if ($_FILES["res"]["name"] != ""){

									$kayt_adres = dosya_yukle("res","site/kullanicilar/foto/");

									if (isset($_POST["gizlilik"])){
										// Gizlilik Ayarlarını yapmak için farklı bir pencereye yönlendirme

										// Bir sonraki adımda kullanılmak üzere resimin yolu bir değişkene atılıyor
										$_SESSION["dosya_yol"] = $kayt_adres;

										// Farklı sayfaya yönlendirilme

										header("location:index.php?komut=paylasimlar&sayfa=gizlilik");
									}
									else{
										// Resimin veritabanına kaydedilmesi
										$sorgu = mysql_query("SELECT * FROM paylasımlar");

										$tanim = $_POST["aciklama"];

										if ($_POST["aciklama"] == ""){
											$tanim = "Yorumsuz";
										}

										$no = mysql_num_rows($sorgu); // Son kaydın index'i alınıyor
										$tarih = date("d.m.y, G:i:s");
										$icerik = '|s ad="adres"|'.$kayt_adres.';|s ad="tanim"|'.$tanim.';';
										$yorum = '|s ad="s_yorum"|0;';
										
										//Yorum Yazma Kuralı '|p ad="yorum" |:|u ad="kim"|'..':|s ad="yorum"|'..'|s ad="sil"|0:;';

										@mysql_query("INSERT INTO paylasımlar(id,gondrn_id,tarih,tur,icerik,yorum,izinler,goruntule,begeni)
													 VALUES (".$no.",".$_SESSION["id"].",'".$tarih."','foto','".$icerik."','".$yorum."','',1,0)")or die(mysql_error());

										sistem_cıktısı(false,"Fotoğrafınız Paylaşıldı");
										sistem_cıktısı();
									}
								}
							}
						}
					}
					//new dbug($_POST);
					$git = "tekil";
					if (isset($_GET["git"])){
						if ($_GET["git"] == "tekil"){
							paylasım_pan("paylasımlarım");
						}
						else{
							paylasım_pan();
						}
					}	
					
					$_SESSION["gecmis"][] =  arındır($_SERVER["QUERY_STRING"]);
					$_SESSION["gecmis_ad"][] = "Paylaşımlarım";
					
				}
				else if ($komut == 'mesaj'){
					if (oturum_kontrol()){
						if (isset($_GET["git"])){
							// Sayfanın gelen veya giden olmasına göre sql komutları yapılandırılıyor

							if ($_GET["git"] == "islem"){ // Mesaj işlemleri yaptırma
								if (isset($_POST["islem"])){
									mesaj_islemleri();
									header("location:index.php?komut=mesaj");
								}
							}
							else if ($_GET["git"] == "yenimesaj"){
								if (isset($_POST["nereye"])){
									// !!!!!!!!! GÜVENLİK FİLTRESİİ !!!!!!!!! //

									$hata = mesaj_yolla($_POST["nereye"]);

									if ($hata == "kullnıcıyok"){
										echo dil("mesaj yazmaya çalıştığınız Kişi sitemizde kayıtlı değildir");
									}
									else if ($hata == "sorgu"){
										echo dil("mesaj gönderiminde bir hata oluştu");
									}
									else{
										echo "sorguaa";
										header("location:index.php?komut=mesaj");
									}
								}
								else{
									mesaj_yazpan();
								}
							}
							else if ($_GET["git"] == "oku"){  // Okuma methodudur: Gelen mesajlar için...
								if (isset($_GET["id"])){
									// !!!!!!!!! GÜVENLİK FİLTRESİİ !!!!!!!!! //
									mesaj_oku();
									
									$_SESSION["gecmis"][] =  arındır($_SERVER["QUERY_STRING"]);
									$_SESSION["gecmis_ad"][] = "Mesaj Oku";
								}
								else{
									mesaj_pan();
									
									$_SESSION["gecmis"][] =  arındır($_SERVER["QUERY_STRING"]);
									$_SESSION["gecmis_ad"][] = "Gelen Kutusu";
								}
							}
							else if ($_GET["git"] == "oku1"){ // // Okuma methodudur: Yollanan mesajlar için...
								if (isset($_GET["id"])){
									// !!!!!!!!! GÜVENLİK FİLTRESİİ !!!!!!!!! //
									mesaj_oku();
									$_SESSION["gecmis"][] =  arındır($_SERVER["QUERY_STRING"]);
									$_SESSION["gecmis_ad"][] = "Mesaj Oku";
								}
								else{
									mesaj_pan();
									$_SESSION["gecmis"][] =  arındır($_SERVER["QUERY_STRING"]);
									$_SESSION["gecmis_ad"][] = "Gelen Kutusu";
								}
							}
							else if ($_GET["git"] == "gondrlen"){
								mesaj_pan("giden");
								$_SESSION["gecmis"][] =  arındır($_SERVER["QUERY_STRING"]);
								$_SESSION["gecmis_ad"][] = "Giden Kutusu";
							}
							else if ($_GET["git"] == "gelen"){
								mesaj_pan();
								$_SESSION["gecmis"][] =  arındır($_SERVER["QUERY_STRING"]);
								$_SESSION["gecmis_ad"][] = "Gelen Kutusu";
							}
						}
						else {
							mesaj_pan();
							$_SESSION["gecmis"][] =  arındır($_SERVER["QUERY_STRING"]);
							$_SESSION["gecmis_ad"][] = "Gelen Kutusu";
						}
					}
					else{
						echo "Lütfen kullanıcı girişi yapın";
					}

				}
				else if ($komut == 'sohbet'){ //
					
					if (isset($_GET['odaid'])){

						// yeni odaya girme durumu işleniyor
						if (@$_SESSION['odaid'] == ""){
							$_SESSION['odaid'] = maske_coz($_GET['odaid']); // bu hane ile bu kosul taaaki odadan çıkana kadar isletilmeyecek

							// oda acık sayısının 2 yapılması
							@mysql_query('UPDATE ana_sohbet SET acık=2 WHERE oda_ad="'.maske_coz($_GET['odaid']).'"') or die(mysql_error());
							
							// Ana Sohbet Tablosunda Verilen Oda Adının Olup Olmadığına Bakılarak Herkese Açık Oda Olup Olmadığına Bakılıyor
							$sorgu = mysql_query('SELECT * FROM ana_sohbet WHERE oda_ad="'.maske_coz($_GET['odaid']).'"');
							
							if ($sorgu){
								if (mysql_num_rows($sorgu) == 0){
									
									// Herkese Açık Oda oldğu doğrulandı // İçeri giriş için kayıtlar yapılıyor //
									// Ek özel durumların olup olmadığı kontrol ediliyor
									
									// Özel mesajın içindeki scrpt'in açılması ve işlenmesi...
									
									$altsorgu = mysql_query('SELECT * FROM '.maske_coz($_GET['odaid']).' WHERE yazanid=-1 and sil=1');
									$scrpt = mysql_result($altsorgu,0,'mesaj');
									
									$scrpt_dizi = scrpt_parcala($scrpt);
									
									// Kişi sayısı // +1 artırılıyor
									$scrpt_dizi['u']['kisisayisi']++;
									
									
									// İçeriğe kullanıcı ekleniyor
									$ekdizi = array();
									$ekdizi["kullanici"] = array();
									$ekdizi["kullanici"]["u"]["id"] = $_SESSION["id"];
									
									$scrpt_dizi[] = $ekdizi;
									
									//new dbug($scrpt_dizi);
									
									// scrpt kapatılıp kaydediliyor...
									$scrpt_son = scrpt_birlestir($scrpt_dizi);
									
									@mysql_query("UPDATE ".maske_coz($_GET['odaid'])." SET mesaj='".$scrpt_son."' WHERE yazanid=-1 and sil=1")or die(mysql_error());
									
								}
							}
							
						}
							
						sohbet(); // Sohbet panelini yazdırır
						$_SESSION["gecmis"][] =  arındır($_SERVER["QUERY_STRING"]);
						$_SESSION["gecmis_ad"][] = "Sohbet";
						
						if (isset($_POST['mesaj'])){
							
							if (isset($_GET["git"])){
								if ($_GET["git"] == "uye"){
									header ("Location:index.php?komut=sohbet&git=uye&odaid=".$_GET['odaid']."");
									mesaj_yaz('bireysel odaya');
								}
							}
							else{
								header ("Location:index.php?komut=sohbet&odaid=".$_GET['odaid']."");
								mesaj_yaz('odaya');
							}

						}
					}
					else{
						odalar_goruntule(); //
						
						$_SESSION["gecmis"][] =  arındır($_SERVER["QUERY_STRING"]);
						$_SESSION["gecmis_ad"][] = "Sohbet Odaları";
					}
					
				}
				else if ($komut == 'sohbetkur'){ // İki kullanıcının bir biri arasında yazışması için
					// Prensip olarak önce yeni bir sohbet odası olusturulacak eğer daha öndeden iki kullanıcı arasında kurulmamışsa veya oda silinmişse
					// ve bütün yazışmalar bu oda üzerinden devam edecek iki tarafta çıktığı zaman oda otomatik olarak kapatılacak

					if ($_SESSION["id"] != maske_coz($_GET["id"])){ // Bu kontrolün nedeni istisnai durumlarda aynı tek kisilik tablo acılsını önlemek çünkü bu tür tablolar otomatik olarak silinemiyor
						
						// Yeni odanın benzersiz adı: // Küçük olan başa geçer kuralı ile oluşturulacak // Böylelikle bu iki kullanıcı her oda kuruduklarında sadece bu ada sahip olabilecekler
						if ($_SESSION["id"] < maske_coz($_GET["id"])){
							$ad = "sohbet_".$_SESSION["id"]."_".maske_coz($_GET["id"]); // Kriptooo
						}
						else{
							$ad = "sohbet_".maske_coz($_GET["id"]."_".$_SESSION["id"]); // Kriptooo
						}
						
						$sorgu = mysql_query('SELECT id FROM yazısmalar');
						$id = mysql_result($sorgu,0,"id");
						
						$id++;
						
						echo 'INSERT INTO yazısmalar(id, tarih, odaid, yazanid, mesaj, durum, sil) VALUES ('.$id.',"'.date('d.m.y - G:i:s').'","'.$ad.'",-1,"kuruluş","-",1)';
						
						// Odanın Diriltiliş Tarihi İşleniyor // bu bilgi odaya özel mesaj olarak işleniyor bu mesaj kullanıcılar tarafından görüntülenemeyecek
						@mysql_query('INSERT INTO yazısmalar(id, tarih, odaid, yazanid, mesaj, durum, sil) VALUES ('.$id.',"'.date('d.m.y - G:i:s').'","'.$ad.'",-1,"kuruluş","-",1)')or die(mysql_error());
						
						echo "b";
						
						// Eğer daha önceden bu ad ana_sohbet tablosuna kayıtlı ise güncelleştirme yapılacak...
						@$sorgu = mysql_query('SELECT * FROM ana_sohbet WHERE oda_ad="'.$ad.'"')or die(mysql_error());
						
						echo "b";
						if (mysql_num_rows($sorgu) > 0){ // Güncelleme...
							echo "b";
							
							// tarih ve acık güncelleştirmesi yapılacak								
							mysql_query('UPDATE ana_sohbet SET tarih="'.date('d.m.y, G:i:s').'", acık=1 WHERE oda_ad="'.$ad.'"');
							
							// Odanın Diriltiliş Tarihi İşleniyor // bu bilgi odaya özel mesaj olarak işleniyor bu mesaj kullanıcılar tarafından görüntülenemeyecek
							@mysql_query('INSERT INTO yazısmalar(id, tarih, odaid, yazanid, mesaj, durum, sil) VALUES ('.$id.',"'.date('d.m.y - G:i:s').'","'.$ad.'",-1,"diriliş","-",1)')or die(mysql_error());
						
						}
						else{ // Ekleme
							@mysql_query('INSERT INTO yazısmalar(id, tarih, odaid, yazanid, mesaj, durum, sil) VALUES ('.$id.',"'.date('d.m.y - G:i:s').'","'.$ad.'",-1,"kuruluş","-",1)')or die(mysql_error());
						}
						
						$_SESSION['odaid'] = $ad;
						
						// İşleri fonksiyonlara devretme
						header ("Location:index.php?komut=sohbet&git=uye&odaid=".id_maskele($ad,"odalar"));
					}
					else {
						header ("Location:index.php?komut=sohbet");
					}

				}
				else if ($komut == 'elsalla'){ //
					//echo "noluo ln";
					el_salla(maske_coz($_GET["id"]));//

					// Bir Önceki Sayfaya Geri Dönme;
					header("location:index.php?".$_SESSION["gecmis"]);
							
				}
				else if ($komut == 'duvar'){ //
					$kimicin = 0;

					if (isset($_GET["git"])){
						if (isset($_GET["id"])){
							$kimicin = maske_coz($_GET["id"]);
						}

						if ($_GET["git"] == "foto"){
							// Uye foto panel hazırlanması
							foto_menu($kimicin); // DEWAAMM
							$_SESSION["gecmis"][] =  arındır($_SERVER["QUERY_STRING"]);
							$_SESSION["gecmis_ad"][] = "Ark. Fotoğrafları";
						}
					}
					
					// Bir Önceki Sayfaya Geri Dönme;
					// header("location:index.php?".$_SESSION["gecmis"]);

				}
				else if ($komut == 'teklif'){ //
					$kimicin = 0;

					if (isset($_GET["id"])){
						teklif_yolla(); // Arkadaşlık teklifi yollama
					}

					// Bir Önceki Sayfaya Geri Dönme;
					header("location:index.php?".$_SESSION["gecmis"][count($_SESSION["gecmis"])]);

				}
				else if ($komut == 'kisi_onayla'){ //

					if (isset($_GET["id"])){
						arkadas_ekle(); // Arkadaşlık teklifi yollama
					}

					//echo "sss";

					// Bir Önceki Sayfaya Geri Dönme;
					header("location:index.php?".$_SESSION["gecmis"][count($_SESSION["gecmis"]) - 1]);

				}
				else if ($komut == 'gurup_degis'){ //

					if (isset($_GET["git"])){
						if ($_GET["git"] == "sec"){
							//echo "oo";
							gurup_secpan();
						}
						if ($_GET["git"] == "yeni"){

							// Oldukça küçük bir parça olduğundan pan işlemi parçalanmadan yazılmıştır

							if (isset($_POST["yeni"])){
								// Sorgu ile açılan script dizine dönüstülür ve yeni s>grup>konum eklenir... ///

								$sorgu = mysql_query('SELECT arkadas FROM uye WHERE uyeid='.$_SESSION["id"]);

								$script = mysql_result($sorgu,0,"arkadas");

								// Scripti dizine ayırma
								$dizin = scrpt_parcala($script);

								/// Yeni Gurub adını ekleme işlemi

								$eklncek = array();
								$eklncek["gurup"] = array();
								$eklncek["gurup"]["s"] = array();
								$eklncek["gurup"]["s"]["konum"] = $_POST["yeni"];

								$dizin["s"][] = $eklncek;

								//new dbug($dizin);
								
								// script son haliyle paketleniyor...
								$scrpt_son = scrpt_birlestir($dizin);
								
								echo $scrpt_son;
								
								// Kaydetme ve mesaj+gurup seçme paneline dönme işlemi
								
								@mysql_query("UPDATE uye SET arkadas='".$scrpt_son."' WHERE uyeid=".$_SESSION["id"])or die(mysql_error());

								sistem_cıktısı(false,"Yeni Gurup Oluşturuldu");

								// geri dönme...
								header("location:index.php?".$_SESSION["geri_dönme2"]);
							}
							else{
								echo '<form id="form1" method="post">
									<p class="baslik">Yeni Gurup Oluşturma</p>
									<p class="yazi">Yeni Gurubun Adını Giriniz</p>
									<input type="text" name="yeni" /><br />
									<input type="submit" name="submit" value="'.dil("Oluştur").'" />
								</form>';
							}

						}
						if ($_GET["git"] == "isle"){
							if (isset($_POST["deger"])){
								// Postdan gelen veri koşulsuz olarak grupmuş gibi davranılarak //// GÜVENLİKKK HATASII
								// ilgili kullanıcının hanesine yazılır


								$sorgu = mysql_query("SELECT arkadas FROM uye WHERE uyeid=".$_SESSION["id"]);
								$scrpt_text = mysql_result($sorgu,0,"arkadas");

								// İfadenin dizin yollarıyla değiştirilmesi

								$dizin = scrpt_parcala($scrpt_text);

								// !! önemli burada ilgili kullanıcı taratılarak bulunuyor
								$i = 0;
								$tara = true;

								while ($tara){
									// Kontrol
									if (isset($dizin[$i])){
										echo "kntrl";
										if ($dizin[$i]["arkadas"]["u"]["id"] == maske_coz($_GET["id"])){
											echo "kntrl41";
											// Sorgusuz sualsiz(*) gurup adı değiştirliyor
											$dizin[$i]["arkadas"]["s"]["konum"] = $_POST["deger"];
										}
										$i++;
									}
									else{
										$tara = false;
									}
								}

								// Dizine dönüştürülen değer birleştirilerek veritabanına kaydediliyor

								//new dbug($dizin);

								$scrpt_cıktı = scrpt_birlestir($dizin);

								@mysql_query("UPDATE uye SET arkadas='".$scrpt_cıktı."' WHERE uyeid=".$_SESSION["id"])or die(mysql_error());

								$degiscek = ""; // Bu ifade gurubu değişcek olan kullanıcın sahip olduğu scrpt_text içindeki yegane değeridir

								// (*)Bu işlem güvenlik hatalarına yol açabilir
							}
						}
					}

					//echo "sss";

					// Bir Önceki Sayfaya Geri Dönme;
					// header("location:index.php?".$_SESSION["gecmis"]);

				}
				else if ($komut == 'araclar'){ //

						echo '<p class="yazi">'.dil("Sitemizi daha etkin kullanın:").'</p>';

						araclar_menü();
						$_SESSION["gecmis"][] =  arındır($_SERVER["QUERY_STRING"]);
						$_SESSION["gecmis_ad"][] = "Araçlar";
						
						//echo "sss";

						// Bir Önceki Sayfaya Geri Dönme;
						// header("location:index.php?".$_SESSION["gecmis"]);

				}
				else if ($komut == 'ayarlar'){
					ayar_pan();
					$_SESSION["gecmis"][] =  arındır($_SERVER["QUERY_STRING"]);
					$_SESSION["gecmis_ad"][] = "Ayarlar";
				}
				else if ($komut == 'yorum'){
					// Girdilerin kontrolü + yorum pan //
						
					/* Girdi Kontrolü 
						Girlen girdiler iki kategoridedir get ve post
						
						get: bu girdilerden yorum yazılcak nesnenin türü ve nesne id'si çekilir
						post yoluyla gelen bilgilerde yeni yorum yazılacağı anlamına gelir
					*/
					
					// Get:
					if (isset($_GET["nsne_tur"])){
						
						$tur = $_GET["nsne_tur"]; // nesnenin türü
						$id = maske_coz($_GET["id"]); // nesnenin id'si
						
						//echo "aa";
						
						//new dbug($_SESSION);
						
						// Posst;
					
						if(isset($_POST["mesaj"])){
							if($_POST["mesaj"] != ""){
								// Veri tabanın açılması ve kayıt işleminin gerçekleştirilmesi
								if($tur == "gonderi_yorum"){
									
									$sorgu = mysql_query('SELECT yorum FROM paylasımlar WHERE id='.$id);
									
									// scrpt'in çıkarılması ve dizine dökülmesi...
									
									$scrpt = mysql_result($sorgu,0,"yorum");
									
									$dizin = scrpt_parcala($scrpt);
									
									// Yorum sayısının öğrenilmesi ve +1 artırılması...
									$toplm = $dizin['s']['s_yorum'];
									$toplm++;
									$dizin['s']['s_yorum'] = $toplm;
									
									// Dizine numerik indeks'li sahte tablo ekleme islemi
									$eklncek = array();
									$eklncek["yorum"] = array();
									$eklncek["yorum"]["u"] = array();
									$eklncek["yorum"]["u"]["id"] = $_SESSION["id"];
									$eklncek["yorum"]["s"] = array();
									$eklncek["yorum"]["s"]["icerik"] = $_POST["mesaj"];
									
									$dizin[] = $eklncek;
									
									// scrpt'e dökme ve kaydetme işlemi...
									$scrpt = scrpt_birlestir($dizin);
									
									@mysql_query("UPDATE paylasımlar SET yorum='".$scrpt."' WHERE id=".$id)or die(mysql_error());
								}
							}
						}
						
						// Tür'e göre icerik görüntüleme + yorumları görüntüleme...
						
						if ($tur == "gonderi_yorum"){
							// paylasımlar tablosundan verilen id'nin tür'ünün bulunması ve yazdırılması
							
							$sorgu = mysql_query('SELECT tur,icerik,tarih,gondrn_id FROM paylasımlar WHERE id='.$id);
							
							$kim =  mysql_result($sorgu,0,"gondrn_id");
							$veri_tur = mysql_result($sorgu,0,"tur");
							$icerik = mysql_result($sorgu,0,"icerik");
							$tarih = mysql_result($sorgu,0,"tarih");
							
							
							$tarih = yaklasik_tarih($tarih);
							
							if ($veri_tur == "yazı"){
								echo '<table border="0" width="180">
										<!-- <tr>
											<td colspan="4" class="paylasim_ust">'.$tarih.'</td>
										</tr> -->
										<tr>
											<td rowspan="2" width=40>'.uye_foto(false,0,40,40).'</td>
											<td colspan="3"><a href="">'.uye_adı($kim).'\'nin/nın Yazısı</a></td>
										</tr>
										<tr class="paylasim_alt">
											<td><a href="index.php?komut=begen&id='.id_maskele($id,"paylasımpan").'">'.dil("Beğeni").'('.begeni_sayısı("paylasim",$id).') '.$tarih.'</td>
										</tr>
										<tr>
											'.$icerik.'
										</tr>
									</table>';	
							}
							if ($veri_tur == "foto"){
								// icerik içindeki bilgiler parçalanıp sınıflandırlıyor

								$veriler = scrpt_parcala($icerik);

								$yol = $veriler["s"]["adres"]; // array içindeki veriler veri pacala tarafından tablodan alına veriye göre oluşturulmuştur
								$etiket = $veriler["s"]["tanim"];
								
								//new dbug($veriler);

								echo '<table border="0" width="200">
										<tr>
											<td width=40><img src="'.$yol.'" height=140 width=160 /></td>
										</tr>
										<tr class="paylasim_alt1">
											<td>
												<b><a href="foto.php">'.$etiket.'</a></b>
												'.$tarih.' '.dil("Tarihinde Paylaşıldı").' | <a href="index.php?komut=begen&id='.id_maskele($id,"paylasımpan").'">'.dil("Beğeni").'('.begeni_sayısı("paylasim",$id).')</a>
											</td>
										</tr>
									</table>';
							}
						}
						///  Yorum Yazma Paneli
						yorum_tab("gonderi",$id);
						
						$_SESSION["gecmis"][] =  arındır($_SERVER["QUERY_STRING"]);
						$_SESSION["gecmis_ad"][] = "Gönderi";
					}
				}
				else if ($komut == 'gonderiyi_paylas'){ //
					// Daha Önceden Paylaşılmış Gonderileri Paylaşmak için kullanılır
					$id = maske_coz($_GET["id"]); // nesnenin id'si
					
					if ($id){
						@$sorgu = mysql_query('SELECT tur,icerik,tarih FROM paylasımlar WHERE id='.$id)or die(mysql_error());
							
						$veri_tur = mysql_result($sorgu,0,"tur");
						$icerik = mysql_result($sorgu,0,"icerik");
						
						$sorgu = mysql_query("SELECT * FROM paylasımlar");
						$no = mysql_num_rows($sorgu); // Son kaydın index'i alınıyor
						
						echo $veri_tur;
						
						if ($veri_tur == "yazı"){
							// Yazının veritabanına kaydedilmesi
							$tarih = date("d.m.y, G:i:s");


							@mysql_query("INSERT INTO paylasımlar(id,gondrn_id,tarih,tur,icerik,yorum,izinler,goruntule,begeni)
										 VALUES (".$no.",".$_SESSION["id"].",'".$tarih."','yazı','".$icerik."','','',1,0)")or die(mysql_error());
							
							sistem_cıktısı(false,"Yazınız Paylaşıldı");
						}
						
						
						
						if ($veri_tur == "foto"){

							// Resimin veritabanına kaydedilmesi
							$tarih = date("d.m.y, G:i:s"); 

							//Yorum Yazma Kuralı '|p ad="yorum" |:|u ad="kim"|'..':|s ad="yorum"|'..'|s ad="sil"|0:;';

							@mysql_query("INSERT INTO paylasımlar(id,gondrn_id,tarih,tur,icerik,yorum,izinler,goruntule,begeni)
										 VALUES (".$no.",".$_SESSION["id"].",'".$tarih."','foto','".$icerik."','','',1,0)")or die(mysql_error());

							sistem_cıktısı(false,"Fotoğrafınız Paylaşıldı");
						}
					}
					
					// Bir Önceki Sayfaya Geri Dönme
					header("location:index.php?".$_SESSION["gecmis"][count($_SESSION["gecmis"]) - 1]);

				}
				else if ($komut == 'begen'){ //
					
					// Daha Önceden Paylaşılmış Gonderileri Beğenmek için Kullanılır
					$id = maske_coz($_GET["id"]); // nesnenin id'si
					$hata = false;
					
					if ($id){
						@$sorgu = mysql_query('SELECT * FROM paylasımlar WHERE id='.$id)or die(mysql_error());
						
						echo "Cümle:".'SELECT * FROM paylasımlar WHERE id='.$id."<br />";
						
						$begenis = mysql_result($sorgu,0,"begeni");
						$begenisay = mysql_result($sorgu,0,"begeni_say");
						
						$begenenler = scrptcan_parcala($begenis);
						
						foreach ($begenenler as $idd){
							if ($idd == $_SESSION["id"]){
								sistem_cıktısı(false,"Bu Gönderiyi Zaten Daha Önceden Beğenmişsiniz");
								$hata = true;
							}
						}
						
						if (!$hata){
							$begenenler[] = $_SESSION["id"];
		
							$scrptcan = scrptcan_birlestir($begenenler);
							$begenisay++;
			
							@mysql_query('UPDATE paylasımlar SET begeni="'.$scrptcan.'", begeni_say='.$begenisay.' WHERE id='.$id)or die(mysql_error());
							sistem_cıktısı(false,"Gönderi Beğenildi");
						}
						// Bir Önceki Sayfaya Geri Dönme
						header("location:index.php?".$_SESSION["gecmis"][count($_SESSION["gecmis"]) - 1]);
					}

				}
				else if ($komut == 'arkadas_bul'){ //

					if (isset($_GET["git"])){
						if ($_GET["git"] = 1){ // Arayarak arkadas buldurma...
							arkadas_ara_pan();
						}
						else if ($_GET["git"] = 2){ // Açık olanlara bakarak arkadas buldurma...
							
						}
						else if ($_GET["git"] = 3){ //  Yeni kayıt olanlara bakarak buldurma...
							yeni_kaydolanlar();
						}
						else if ($_GET["git"] = 4){ // Arayarak arkadas buldurma...
							butun_kullanıcılar();
						}
					}
				}
				else if ($komut == 'arkadasliktan_cikar'){ //

					if (isset($_GET["id"])){
						// !!!! KULLANICI İÇİN !!!! //
						// Sorgu ile arkadas listesi deşifre edilir istene parça değiştirldikten sonra tekrar kayddedilir...

						$sorgu = mysql_query("SELECT arkadas FROM uye WHERE uyeid=".$_SESSION["id"]);
						$scrpt = mysql_result($sorgu,0,"arkadas");
						
						$dizi = scrpt_parcala($scrpt);
						
						// Arkadasın scrpt verisinden cıkarılmasi
						
						
						for ($i=0;$i<count($dizin);$i++){
							if ($dizin[$i]["arkadas"]["u"]["id"] == maske_coz($_GET["id"])){
								//echo "leeyyn nerden pulduin beni";
								$dizin[$i]["sil"] = array();
								$dizin[$i]["sil"] = "true";
							}
						}
						
						$dizi[$i]["sil"] = array();
						
						//new dbug($dizi);
						
						$scrpt_cıkıs = scrpt_birlestir($dizi);
						
						// Son verinin varitabanına kaydedilmesi...
						@mysql_query("UPDATE uye SET arkadas='".$scrpt_cıkıs."' WHERE uyeid=".$_SESSION["id"])or die(mysql_error());
					
						// !!!! SİLİNEN KUALLANICI İÇİN !!!! //
						// Sorgu ile arkadas listesi deşifre edilir istene parça değiştirldikten sonra tekrar kayddedilir...

						$sorgu = mysql_query('SELECT arkadas FROM uye WHERE uyeid='.maske_coz($_GET["id"]));
						$scrpt = mysql_result($sorgu,0,"arkadas");
						
						$dizi = scrpt_parcala($scrpt);
						
						// Arkadasın scrpt verisinden cıkarılmasi
						
						$i = 0;
						
						for ($i=0;$i<count($dizin);$i++){
							if ($dizin[$i]["arkadas"]["u"]["id"] == $_SESSION["id"]){
								//echo "leeyyn nerden pulduin beni";
								$dizin[$i]["sil"] = array();
								$dizin[$i]["sil"] = "true";
							}
						}
						
						$dizi[$i]["sil"] = array();
						$scrpt_cıkıs = scrpt_birlestir($dizi);
						
						//new dbug($dizi);
						
						// Son verinin varitabanına kaydedilmesi...
						@mysql_query("UPDATE uye SET arkadas='".$scrpt_cıkıs."' WHERE uyeid=".maske_coz($_GET["id"]))or die(mysql_error());;
						
						sistem_cıktısı(false,uye_adı(maske_coz($_GET["id"]))." Arkadaş listenizden kaldırıldı");
					}
					
					// Bir önceki sayfaya geri dönme //
					header("location:index.php?".$_SESSION["gecmis"][count($_SESSION["gecmis"]) - 1]);
					
				}
				else if ($komut == 'ifadeler'){
					ifadeler_pan();
				}
			}
		}
		else{
			/* Ana giriş sayfası: eğer kullanıcı girişi varsa uye sayfası gibi davranılır */
			if (oturum_kontrol()){
				uye_anasayfa();
			}
			else{
				uye_anasayfa();
				// echo "psss";
			}
		}

		/* Bitiriş: standart sayfa sonu öğeleri */
		if (!isset($_GET["komut"])){ // Ana giriş Sayfasından sayfa sonu menüsünün kaldırılması
			if (oturum_kontrol()){
				sayfa_sonu();
			}
		}
		else{
			if ($_GET["komut"] != 'kayıt'){
				if (oturum_kontrol()){
					sayfa_sonu();
				}
			}
		}
	}

	function sayfa_css(){
		echo '
				#adn{
					color:#CC3300;
				}

			';
	}

	function menu_kur($kurulum){
		
		if (oturum_kontrol()){
			
			$geri = "";
			
			// Son girilen konumun öğrenilmesi...
			
			@$sonknm = $_SESSION["gecmis"][count($_SESSION["gecmis"]) - 1]; // -2'nin nedeni -1 o anki dizinin son değeri + -1 Sondan bir önceki değer...  			
			@$sonkonum = $_SESSION["gecmis_ad"][count($_SESSION["gecmis"]) - 1]; // **
			
			if (isset($_GET["geri"])){
				$sonknm = str_replace("geri=1","",$sonknm);
			}
			
			$mesaj = mesaj_kontrol("menu");
			$olaylar = olay_kontrol("menu");
			$arkadas = arkadas_kontrol("menu");
			echo "<p class='gircubuk'>
					<a href='index.php'>".kaynak_al("anasayfa")."</a>
					<a href='index.php?komut=profil'>".kaynak_al("profil")."</a>
					<a href='index.php?komut=mesaj'>".kaynak_al("mesaj")."</a>
					<a href='index.php?komut=arkadas'>".kaynak_al("arkadas")."</a>
					<a href='index.php?komut=sohbet'>".kaynak_al("sohbet")."</a>
					<a href='index.php?komut=cıkıs'>".kaynak_al("cıkıs")."</a><br>
					<a href='index.php?".$sonknm."&geri=1'> <-- Geri Git(".$sonkonum.")</a>
					</p>";
			
		}
		else{
			if ($kurulum == "giris"){
				echo "<p class='gircubuk'><a href='index.php?komut=giris'>".dil("GiriŞ yaP")."</a> | <a href='index.php?komut=kayıt'>".dil("Kayıt Ol")."</a></p>";
			}
			else if ($kurulum == "sohbet"){
				echo "<p class='gircubuk'>".dil("Etkili kullanım için lütfen")." <br />
						<a href='index.php'>".dil("Giriş")."</a> ".dil("yapın")."</p>";
			}
			else if ($kurulum == "kayıt"){
				echo "<p class='gircubuk'>Üyemizseniz 
						<a href='index.php'>".dil("Giriş")."</a> ".dil("yapın")."</p>";
			}
		}
	}

	function sohbet(){


		// tarih yazdırma konusunda devrim yapılacakkkkkk!!!
		// üye yorum yazma eklenecek
		
		$uyeveri = uye_verileri($_SESSION["id"]);
		
		$maxsatır = $uyeveri["sohbet_max"]; // Kullanıcı tarafından ayarlanabilir olacak

		$odaid = maske_coz($_GET['odaid']);
		
		if (isset($_GET["git"])){ 
			if ($_GET["git"] == 'uye'){ // oda türü //
			
				$sorgu = mysql_query('SELECT * FROM yazısmalar WHERE odaid="'.$odaid.'"')or die(mysql_error());
				if (oturum_kontrol()){
					mesaj_yaz_pan();
				}
			}
			else{
				$sorgu = mysql_query('SELECT * FROM '.$odaid)or die(mysql_error());
				if (oturum_kontrol()){
					mesaj_yaz_pan();
				}
			}
		}
		else{
			$sorgu = mysql_query('SELECT * FROM '.$odaid)or die(mysql_error());
			if (oturum_kontrol()){
				mesaj_yaz_pan();
			}
		}
		
		

		// odamızın içinde yazılı mesaj olup olmadığını kontrol ediyoruz
		$satır = mysql_num_rows($sorgu);

		// her mesajı veri tabanınan çıkartıp yazanıyla beraber sayfaya işliyoruz
		if ($satır > 0){

			$geri = $satır;

			if (isset($_GET['sayfa'])){
				// $i <= 10 ifadesi sayfaya göre değişecek ve altda buton ayarlaması yapılacak
			}
			else{
				for ($i=0;$i<=$maxsatır;$i++){
					if ($i < $satır){
						$geri--;
						sohbet_cıktı($sorgu,$geri);
					}
				}
			}
		}

		// Çıktı işleminden sonra odada açık olanları göster
		if (isset($_GET["git"])){
			if ($_GET["git"] == 'uye'){
				// Eğer oda kişisel sohbet içinse

				echo '<p class="baslik">
							'.dil("Durum:").'
					</p>';
				// Oda acık değeri alınıyor
				@$sorgu = mysql_query('SELECT * FROM ana_sohbet WHERE oda_ad="'.maske_coz($_GET['odaid']).'"')or die(mysql_error());

				if ($sorgu){
					if(mysql_num_rows($sorgu) > 0){

						// Karşıdaki kişinin öğrenilmesi
						if (mysql_result($sorgu,0,'diger_id') == $_SESSION["id"]){
							$karsıdaki = mysql_result($sorgu,0,'kuran_id');
						}
						else {
							$karsıdaki = mysql_result($sorgu,0,'diger_id');
						}

						// Karşıdaki elemanın açık olup olmadığı kontrol ediliyor
						if (oturum_kontrol($karsıdaki)){
							$durum = dil("Oturumu Açık");
						}
						else{
							$durum = dil("Henüz Oturum Açmamış");
						}

						// Eğer oda acık değeri 1 ise sadece asıl kullanıcı açık gösterilir
						// Eğer oda acık değeri 2 ise hem kullanıcı hemde sohbet edilenş kişi açık gösterilir

						$acık = mysql_result($sorgu,0,"acık");

						if ($acık == 1){

							if ($durum == dil("Oturumu Açık")){
								$durum .= dil(" Henüz Sohbete Katılmadı");
							}

							echo '  <table class="listetab"  width=100% border="0">
									  <tr>
										<td id="ilk"  width=15 >
											'.uye_foto(false,$karsıdaki).'
										</td>
										<td>
											<a style="padding:0px;" href="index.php?komut=arkadas&git=menu&id='.id_maskele($karsıdaki,"sohbet").'">'.uye_adı($karsıdaki).'-'.$durum.'</a></b><br />
										</td>
									  </tr>
									</table>';
						}
						else{
							echo '  <table class="listetab"  width=100% border="0">
									  <tr>
										<td id="ilk"  width=15 >
											'.uye_foto(false,$karsıdaki).'
										</td>
										<td>
											<a style="padding:0px;" href="index.php?komut=arkadas&git=menu&id='.id_maskele($karsıdaki,"sohbet").'">'.uye_adı($karsıdaki).'-'.dil("Şuan Seninle Sohbetde").'</a></b><br />
										</td>
									  </tr>
									</table>';
						}

					}
				}
			}
		}
		
	}

	function sohbet_cıktı($sorgu,$i){
		$uyeid = mysql_result($sorgu,$i,'yazanid');
		$icerik = mysql_result($sorgu,$i,'mesaj');
		$tarih = mysql_result($sorgu,$i,'tarih');
		@$sil = mysql_result($sorgu,$i,'sil');
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
		
		if ($sil == 0){
			echo '<p style="border-bottom:#CC6600 solid 1px; " ><a style="padding:0px;" href="index.php?komut=arkadas&git=menu&id='.id_maskele($uyeid,"sohbet").'" title="a">'.$uyead.':</a>
				<strong style="color:#000000; padding:3px" >'.$yaz.'</strong>
			</p>';
		}	
	}

	function acık_odalar(){ // Blok
	
		
		@$sorgu = mysql_query('SELECT * FROM ana_sohbet WHERE kuran_id='.$_SESSION["id"].' or diger_id='.$_SESSION["id"])or die(mysql_error());
		
		if ($sorgu){

			$satır = mysql_num_rows($sorgu);
			$yazılcak = "";
			
			$acıkoda = 0;
			
			if ($satır > 0){

				for ($i=0;$i < $satır;$i++){
				
					if (@mysql_result($sorgu,0,'acık') > 0){
						
						$acıkoda++;
						
						// Karşıdaki kişinin öğrenilmesi
						if (mysql_result($sorgu,0,'diger_id') == $_SESSION["id"]){
							$karsıdaki = mysql_result($sorgu,0,'kuran_id');
						}
						else {
							$karsıdaki = mysql_result($sorgu,0,'diger_id');
						}

						// Oda adını alma ve tablosuna bağlanıp son mesajı alma
						$oda_ad = mysql_result($sorgu,$i,"oda_ad");
						
						$sorgu = mysql_query('SELECT * FROM yazısmalar WHERE odaid="'.$oda_ad.'"');

						$sonindx = mysql_num_rows($sorgu) - 1;

						if ($sonindx >= 0){
							$sonmsj = mysql_result($sorgu,$sonindx,"mesaj");
						}
						else{
							$sonmsj = "";
						}


						// Yazdırma

						$yazılcak .= '<table class="listetab"  width=100% border="0">
							  <tr>
								<td id="ilk"  width=15 >
									'.uye_foto(false,$karsıdaki).'
								</td>
								<td>
									<b id="mesaj_tab" >
									<a style="padding:0px;" href="index.php?komut=sohbet&git=uye&odaid='.id_maskele($oda_ad,"odalar").'">'.uye_adı($karsıdaki).'</a></b><br />
									<b>'.$sonmsj.'</b></td>
							  </tr>
							</table>';
					}
					
				}
				
				if ($acıkoda > 0){
					echo '<p class="baslik">
						'.dil("Yanıt Bekleyenler:").'
					</p>'.$yazılcak;
				}
			}
		}
	}
	
	function herkese_acık_odalar(){ // Blok
		echo '<p class="baslik">
				Herkese Açık Sohbet Odaları
			</p>';

		// Genel seçme komutumuz
		$sorgu = mysql_query('SELECT * FROM odalar');

		// Toplam oda sayısının öğrenilmesi
		$satır = mysql_num_rows($sorgu);

		// Odaların teker teker taratılıp yerleştirilmesi
		echo '<table border="0">';
		
		for ($i = 0;$i <= $satır-1;$i++){


			$odaad = mysql_result($sorgu,$i,'odaad');
			$odaid = mysql_result($sorgu,$i,'oda_id');
			
			// scrpt methoduyla özel mesaj içinde saklanan scrpt çıkarılıyor...
			// özemesaj kuralı: yazanid = -1 // olasılık dışı bir değerdir bu // gizlenmiş msjdır sil=0;

			$altsorgu = mysql_query('SELECT * FROM '.$odaid.' WHERE yazanid=-1 and sil=1');
			$scrpt = mysql_result($altsorgu,0,'mesaj');
			
			$scrpt_dizi = scrpt_parcala($scrpt);
			
			// Kişi sayısı //
			
			$kisisayisi = $scrpt_dizi['u']['kisisayisi'];

			$stil = stil_al();
			
			//echo '<a href ="index.php?komut=sohbet&odaid='.id_maskele($odaid,"odalar").'">'.$odaad.'('.$kisisayisi.')</a><br />';
			echo '
					<tr>
						<td></td>
						<td><a href ="index.php?komut=sohbet&odaid='.id_maskele($odaid,"odalar").'">'.$odaad.'('.$kisisayisi.')</a></td>
					</tr>
					';
		}
		
		echo '</table>';
	}
	
	function sohbete_acık_olanlar(){ // Blok
		echo '
			<p class="baslik">
				'.dil("Sohbet Edebilecek Olduklarım:").'
			</p>';

		// Tüm arkadaş listesi taratılıyor ve açık olanlar listeleniyor
		$liste = arkadas_listesi();
		$kimse_yok = true;
		
		echo '<table class="listetab"  width=100% border="0">';
		
		if (isset($liste["u"])){
			$uyeids = $liste["u"];
			foreach ($uyeids as $id){
				if ($id != ""){
					if (oturum_kontrol($id)){ // Çıkarılan id'nin Online olup Olmadığı Kontrol Ediliyor...
						echo '	<tr>
									<td id="ilk"  width=15 >
										'.uye_foto(false,$id).'
									</td>
									<td>
										<b id="mesaj_tab" >
										<a style="padding:0px;" href="index.php?komut=sohbetkur&id='.id_maskele($id,"odalar").'">'.uye_adı($id).'</a></b><br />
									</td>
								  </tr>
								';
								
					}
				}
			}
		}
		
		echo '</table>';
		
		if ($kimse_yok){
			echo '<p class="yazi">'.dil("Malesef Sohbet Edebilceğiniz Açık Arkadaşınız Yok").'</p>';
		}
	}
	
	function odalar_goruntule($amac = "herkesicin"){ // Çift Fonksiyonlu Bir yapı : 1.amaç=herkese açık odaları gorüntüleme 2.amaç=kullanıcının sohbet odalarını görüntüleme

		// Kullanıcı için açılmış odalar burada listelenecektir
		// Kullanıcı adına açılmış odalar aranıyor

		acık_odalar();
		
		herkese_acık_odalar(); 

		sohbete_acık_olanlar();
	}

	function sayfa_sonu(){ // Blok
		@$sorgu = mysql_query('SELECT * FROM menuler WHERE menu_gurup="sayfa sonu" and sıra_no ORDER BY "DESC"') or die(mysql_error());

		$str_says = mysql_num_rows($sorgu);
		$i = 0;

		echo '<p class="altmenu">'; // Başlangıç

		// Menü listesi alınıyor
		while ($i < $str_says){

			$adres = mysql_result($sorgu,$i,"adres");
			$img_ad = mysql_result($sorgu,$i,"img_ad");
			$text = mysql_result($sorgu,$i,"menu_text");

			echo '<a href="'.$adres.'">'.kaynak_al($img_ad).' '.dil($text).'</a><br />';

			$i++;
		}

		echo '</p>';

		/*
		echo '<p class="altmenu">
					<a href="index.php?komut=profil">'.kaynak_al("profil").' Profilim</a><br />
					<a href="index.php?komut=arkadas">'.kaynak_al("arkadas").' Arkadaşlarım</a><br />
					<a href="index.php?komut=sohbet">'.kaynak_al("sohbet").' Çevrim içi sohbet</a><br />
					<a href="index.php?komut=araclar">'.kaynak_al("araclar").' Site Araçları*</a><br />
					<a href="index.php?komut=mesaj">'.kaynak_al("mesaj").' Mesajlarım</a><br />
					<a href="index.php?komut=mp3">'.kaynak_al("mp3").' Mp3 Merkezim</a><br />
					<a href="index.php?komut=uygulama">'.kaynak_al("uygulama").' Uygulamalarım</a><br />
					<a href="index.php?komut=ayarlar">'.kaynak_al("ayarlar").' Ayarlarım</a><br />
				</p>';
		*/
	}

	function giris_pan(){
		echo '<form class="baslik" id="form1" action="" method="post">
						'.dil("Kullanıcı Adınız:").'<br /><input name="kullanıcı" type="text" width="100" /><br />
						'.dil("Şifreniz:").'<br /><input name="sifre" type="password" width="100" /><br />
						<input type="image" src="tema/gir.gif" style="padding:5px; padding-left:45px;" >
				</form>';
	}

	function kayıt_pan(){
		echo '<form class="baslik" id="form1" action="" method="post">
						'.dil("Kullanıcı Adınız:").'<br /><input name="kayıt_kullanıcı" type="text" width="100" /><br />
						'.dil("Şifreniz:").'<br /><input name="sifre" type="password" width="100" /><br />
						'.dil("Cinsiyetiniz:").'<br />
						<select name="cins">
							<option>Erkek</option>
							<option>Bayan</option>
						</select><br />
						'.dil("E-posta:").'<br /><input name="eposta" type="text" width="100" /><br />
						'.dil("Kuralları kabul ediyorum").' <input name="kabul" type="checkbox" value="" /><br>
						<input name="submit" type="submit" value="'.dil("Kaydımı Tamamla").'" /><br>
					</form>';
	}

	function ana_giris(){
		echo '	<p class="govde">
							<img src ="tema/nokta.gif">Çevrim içi Arkadaşlık<br />
							<img src ="tema/nokta.gif">Çevrim içi sohbetler<br />
							<img src ="tema/nokta.gif">Oyunlar,Etkinlikler,Astroloji<br />
							<img src ="tema/nokta.gif">Resim,Video paylaşımı<br />
							<img src ="tema/nokta.gif">Hızlı ve kaliteli gezinti<br />
							<img src ="tema/nokta.gif">Son dakika haberleri<br />
							<img src ="tema/nokta.gif">Gündemden haberler<br />
							<img src ="tema/nokta.gif">Ve Renkli Sosyal Yaşam<br />
						</p>';
	}

	function mesaj_yaz_pan($baslik = "",$araclar = true){
		echo '<form id="form1" action="" method="post" >
				<p class="baslik" >
					'.$baslik.'
					<span style="padding:0px; color:#FFFFFF">
						<input name="mesaj" type="text"  />
						<input type="submit" value="'.dil("yaz").'"><br />
						<a href="index.php?'.arındır($_SERVER["QUERY_STRING"]).'">'.dil("Yenile").'</a>';
		if ($araclar){
			echo '. <a href="index.php?komut=sohbet&git=ayar">'.dil("Ayarlar").'</a>.<a href="index.php?komut=ifadeler">'.dil("ifadeler").'</a>';
		}
		
		echo '</span>
				</p>
			  </form>';
	}

	function uye_anasayfa(){ // Veri Tabanı Bağlantısı Sağlanacak // Blok

		/* Başlangıç : KARARSIZIM :P */

		$arkadas = arkadas_kontrol("sayı");
		$mesaj = mesaj_kontrol("sayı");
		$istek = arkadas_istek("sayı");
		
		
		if (oturum_kontrol()){
			// arkadas_bulma_yontemleri();
			sohbete_acık_olanlar();
			paylasım_pan();
		}
		else{
		
			echo '<p class="baslik" style="text-size:14px;">'.dil("MoßiL EqLencE vE İçeriK ServisLeri").'</p>';
			
			@$sorgu = mysql_query('SELECT * FROM menuler WHERE menu_gurup="ana giriş" and sıra_no ORDER BY "DESC"') or die(mysql_error());

			$str_says = mysql_num_rows($sorgu);
			$i = 0;

			echo '<p style="color:#FFFFFF; border-bottom:#000000 5px solid" class="altmenu">'; // Başlangıç

			// Menü listesi alınıyor
			while ($i < $str_says){

				$adres = mysql_result($sorgu,$i,"adres");
				$img_ad = mysql_result($sorgu,$i,"img_ad");
				$text = mysql_result($sorgu,$i,"menu_text");

				echo kaynak_al($img_ad).' '.dil($text).'<br />';

				$i++;
			}

			echo '</p>';
			
			
			/*
				<p style="color:#FFFFFF; border-bottom:#000000 5px solid" class="altmenu"> <img src ="tema/accept.gif">'.dil("OnLine oyuN HizmetLeri").'<br />
				 <img src ="tema/accept.gif">'.dil("VideO Ve resiM PayLaşımI").'<br />
				 <img src ="tema/accept.gif">'.dil("ChaT SohßeT ArkadaşLıK").'<br />
				 <img src ="tema/accept.gif">'.dil("yorumLar ßeqeniLer Astroloji").'<br />
				 <img src ="tema/accept.gif">'.dil("vE daha fazLasI icin").'<a href="index.php?komut=kayıt">'.dil(" ÜcreTsiz üye oL'un").'</a><p />
				<p style="background-color:#555555; color:#FFFFFF"><img src ="tema/accept.gif">adnmAnia.coM © 2012</p>';
			*/
		}
	}

	function profil_pan($goruntule = false){
		/* Tasarım belli */

		if (!$goruntule){
			$sorgu = mysql_query('SELECT * FROM uye WHERE uyeid='.$_SESSION['id']);
		}
		else{
			$sorgu = mysql_query('SELECT * FROM uye WHERE uyeid='.maske_coz($_GET['id']));
		}

		$dgun = "00";
		$day = "00";
		$dyıl = "0000";


		$dtarih = mysql_result($sorgu,0,"dogumtar");
		$ddizi = explode(".",$dtarih);

		@$dgun = $ddizi[0];
		@$day = $ddizi[1];
		@$dyıl = $ddizi[2];

		if (mysql_result($sorgu,0,"cinsiyet") == ""){
			$cinsiyet = "Belirtilmemiş";
		}
		else if (mysql_result($sorgu,0,"cinsiyet") == 1){
			$cinsiyet = "Erkek";
		}
		else if (mysql_result($sorgu,0,"cinsiyet") == 2){
			$cinsiyet = "Kadın";
		}
		else if (mysql_result($sorgu,0,"cinsiyet") == 3){
			$cinsiyet = "Homoseksüel";
		}

		$medeni = "Belirtilmemiş";

		if (mysql_result($sorgu,0,"medeni") == 1){
			$medeni = "İlişkisi Var";
		}
		else if (mysql_result($sorgu,0,"medeni") == 2){
			$medeni = "İlişkisi Yok";
		}
		else if (mysql_result($sorgu,0,"medeni") == 3){
			$medeni = "Evli";
		}
		else if (mysql_result($sorgu,0,"medeni") == 4){
			$medeni = "Nişanlı";
		}
		else if (mysql_result($sorgu,0,"medeni") == 5){
			$medeni = "Karmaşık";
		}
		else if (mysql_result($sorgu,0,"medeni") == 6){
			$medeni = "Dul";
		}

		// Tablo içinde gösterim sağlanacak
		if (!$goruntule){
			echo '
			<p class="baslik">
				'.dil('PROFİL').'
			</p>
			<b><table width="200" border="0">
				<tr>
					<td rowspan="4"><a href="index.php?komut=profil&git=profil_foto" >'.uye_foto(false,0,70,70).'</a></td> <!-- Üye fotosunun konulması; -->
					<td>'.dil("Üye numaram: ").$_SESSION["id"].'</td>
				</tr>
				<tr>
					<td><a href="index.php?komut=profil&git=ayarlar">'.dil("Ayarlar").'</a></td>
				</tr>
				<tr>
					<td><a href="index.php?komut=paylasimlar&git=tekil">'.dil("Paylaşımlarım").'()</a></td>
				</tr>
			</table></b><br />

			<p class="baslik">
				'.dil("GENEL").'
			</p>
			<p>
			<b>'.dil("Adım:").'</b> '.$_SESSION["ad"].'<br />
			<b>'.dil("Soyadım:").'</b> '.$_SESSION["soyad"].'<br />
			<b>'.dil("Cinsiyetim:").'</b> '.$cinsiyet.'<br />
			<b>'.dil("Görünen Adım:").'</b> '.$_SESSION["kullanıcı_adı"].'<br />
			<b>'.dil("E-mail'im:").'</b> '.$_SESSION["eposta"].'<br />

			<p class="baslik">
				'.dil("GÜNCELLE").'
			</p>

			<p>

			<form action="index.php?komut=profil&git=bilg_duzenle" method="post">

				<p><b>'.dil("Adım:").'</b><br />
						<input type="text" name="ad" value="'.$_SESSION["ad"].'"><br />
						<b>'.dil("Soyadım:").'</b><br />
						<input type="text" name="soyad" value="'.$_SESSION["soyad"].'"><br />
				<b>'.dil("E-mail'im:").'<br><input name="eposta" value="'.$_SESSION["eposta"].'" type="text"><br>
				'.dil("Cinsiyetim:").' <br><select name="cinsiyet">
					<option selected="selected" value="1">'.$cinsiyet.'</option>
					<option value="1">Erkek</option>
					<option value="2">Bayan</option>
					<option value="3">Homoseksüel</option>
				</select><br>
				'.dil("Nereden katılıyorum:").'<br>
				<input name="nereden" type="text" value="'.mysql_result($sorgu,0,"nereden").'"><br>
				'.dil("İlişkim:").' <br>
				<select name="medeni_durum">
					<option selected="selected" value="'.mysql_result($sorgu,0,"medeni").'">'.$medeni.'</option>
					<option value="1">İlişkisi var</option>
					<option value="2">İlişkisi yok</option>
					<option value="3">Evli</option>
					<option value="4">Nişanlı</option>
					<option value="5">Karmaşık ilişki</option>
					<option value="6">Dul</option>
				</select><br>
				'.dil("Mesleğim:").'<br>
				<input name="meslek" type="text" value="'.mysql_result($sorgu,0,"meslek").'"><br>
				'.dil("Hakkımda:").'<br><textarea name="hakkimda" rows="3" cols="20">'.mysql_result($sorgu,0,"hakkımda").'</textarea>
				<br>'.dil("Sevdiklerim:").' <br><textarea name="sevdiklerim" rows="3" cols="20">'.mysql_result($sorgu,0,"sevdiklerim").'</textarea><br>
				'.dil("Asıl Aradığım:").' <br><textarea name="aradigim" rows="3" cols="20">'.mysql_result($sorgu,0,"aradıgım").'</textarea><br>
				'.dil("Doğum Tarihim:").'<br> <select name="gun"><option selected="selected" value="'.$dgun.'">'.$dgun.'</option><option value="01">01</option><option value="02">02</option><option value="03">03</option><option value="04">04</option><option value="05">05</option><option value="06">06</option><option value="07">07</option><option value="08">08</option><option value="09">09</option><option value="10">10</option><option value="11">11</option><option value="12">12</option><option value="13">13</option><option value="14">14</option><option value="15">15</option><option value="16">16</option><option value="17">17</option><option value="18">18</option><option value="19">19</option><option value="20">20</option><option value="21">21</option><option value="22">22</option><option value="23">23</option><option value="24">24</option><option value="25">25</option><option value="26">26</option><option value="27">27</option><option value="28">28</option><option value="29">29</option><option value="30">30</option><option value="31">31</option></select><select name="ay"><option selected="selected" value="'.$day.'">'.$day.'</option><option value="01">01</option><option value="02">02</option><option value="03">03</option><option value="04">04</option><option value="05">05</option><option value="06">06</option><option value="07">07</option><option value="08">08</option><option value="09">09</option><option value="10">10</option><option value="11">11</option><option value="12">12</option></select><select name="yil"><option selected="selected" value="'.$dyıl.'">'.$dyıl.'</option><option value="1999">1999</option><option value="1998">1998</option><option value="1997">1997</option><option value="1996">1996</option><option value="1995">1995</option><option value="1994">1994</option><option value="1993">1993</option><option value="1992">1992</option><option value="1991">1991</option><option value="1990">1990</option><option value="1989">1989</option><option value="1988">1988</option><option value="1987">1987</option><option value="1986">1986</option><option value="1985">1985</option><option value="1984">1984</option><option value="1983">1983</option><option value="1982">1982</option><option value="1981">1981</option><option value="1980">1980</option><option value="1979">1979</option><option value="1978">1978</option><option value="1977">1977</option><option value="1976">1976</option><option value="1975">1975</option><option value="1974">1974</option><option value="1973">1973</option><option value="1972">1972</option><option value="1971">1971</option><option value="1970">1970</option><option value="1969">1969</option><option value="1968">1968</option><option value="1967">1967</option><option value="1966">1966</option><option value="1965">1965</option><option value="1964">1964</option><option value="1963">1963</option><option value="1962">1962</option><option value="1961">1961</option><option value="1960">1960</option><option value="1959">1959</option><option value="1958">1958</option><option value="1957">1957</option><option value="1956">1956</option><option value="1955">1955</option><option value="1954">1954</option><option value="1953">1953</option><option value="1952">1952</option><option value="1951">1951</option><option value="1950">1950</option><option value="1949">1949</option><option value="1948">1948</option><option value="1947">1947</option><option value="1946">1946</option><option value="1945">1945</option><option value="1944">1944</option><option value="1943">1943</option><option value="1942">1942</option><option value="1941">1941</option></select>
				<br /><br /><input value="'.dil("Güncelle").'" type="submit"></b></p></form>';
		}
		else{

			$bilgi = uye_bilgileri(maske_coz($_GET["id"])); // Filtrelemeee /////

			echo '
			<p class="baslik">
				'.uye_adı(maske_coz($_GET['id'])).'
			</p>
			<table width="200" border="0"><b>
				<tr>
					<td width="70" rowspan="4">'.uye_foto(false,maske_coz($_GET["id"]),70,70).'</td> <!-- Üye fotosunun konulması; -->
					<td>'.dil("Adı:").' '.$bilgi["ad"].'</td>
				</tr>
				<tr>
					<td>'.dil("Soyadı:").' '.$bilgi["soyad"].'</td>
				</tr>
				<tr>
					<td>'.dil("Cinsiyeti:").' '.$bilgi["cinsiyet"].'</td>
				</tr></b>
			</table>

			<p class="baslik">
				GENEL
			</p>
			<p class="listeyazi"><b class="yazi1">'.dil("Görünen Adı:").'</b> '.$bilgi["kullanıcı_adı"].'<br /></p>
			<p class="listeyazi"><b class="yazi1">'.dil("E-mail'i:").'</b> '.$bilgi["eposta"].'<br /></p>
			<p class="listeyazi"><b class="yazi1">'.dil("Nereli:").'</b> '.$bilgi["nereden"].'<br /></p>
			<p class="listeyazi"><b class="yazi1">'.dil("Doğum Tarihi:").'</b> '.$bilgi["dogumtar"].'<br /></p>
			<p class="listeyazi"><b class="yazi1">'.dil("Medeni Durumu:").'</b> '.$bilgi["medeni"].'<br /></p>
			<p class="listeyazi"><b class="yazi1">'.dil("Mesleği:").'</b> '.$bilgi["meslek"].'<br /></p>
			<p class="listeyazi"><b class="yazi1">'.dil("Hakkında:").'</b> '.$bilgi["hakkında"].'<br /></p>
			<p class="listeyazi"><b class="yazi1">'.dil("Sevdikleri:").'</b> '.$bilgi["sevdikleri"].'<br /></p>
			<p class="listeyazi"><b class="yazi1">'.dil("Aradığı:").'</b> '.$bilgi["aradığı"].'<br /></p>';
		}
	}

	function profil_goruntule(){

	}

	function profil_guncelle(){
		if (isset($_POST["ad"])){ // Doğrulama için her hangi form nesnesini olusturulup olusturulmadıgı inceleniyor
			if ($_POST["ad"] != ""){
				$deger = arındır($_POST["ad"]);

				$_SESSION["ad"] = $deger;
				// Veritabanına yerlestirme

				@mysql_query('UPDATE uye SET ad="'.$deger.'" WHERE uyeid='.$_SESSION["id"])or die(mysql_error());
				//echo 'UPDATE uye SET ad="'.$deger.'" WHERE uyeid='.$_SESSION["id"];
			}
			if ($_POST["soyad"] != ""){
				$deger = arındır($_POST["soyad"]);

				$_SESSION["soyad"] = $deger;
				// Veritabanına yerlestirme

				@mysql_query('UPDATE uye SET soyad="'.$deger.'" WHERE uyeid='.$_SESSION["id"])or die(mysql_error());
				//echo 'UPDATE uye SET soyad="'.$deger.'" WHERE uyeid='.$_SESSION["id"];
			}
			if ($_POST["eposta"] != ""){
				$deger = arındır($_POST["eposta"]);

				$_SESSION["eposta"] = $deger;
				// Veritabanına yerlestirme

				@mysql_query('UPDATE uye SET eposta="'.$deger.'" WHERE uyeid='.$_SESSION["id"])or die(mysql_error());
				//echo 'UPDATE uye SET eposta="'.$deger.'" WHERE uyeid='.$_SESSION["id"];
			}
			if ($_POST["cinsiyet"] != ""){
				$deger = arındır($_POST["cinsiyet"]);

				// Veritabanına yerlestirme
				mysql_query('UPDATE uye SET cinsiyet="'.$deger.'" WHERE uyeid='.$_SESSION["id"]);
			}
			if ($_POST["nereden"] != ""){
				$deger = arındır($_POST["nereden"]);

				// Veritabanına yerlestirme
				mysql_query('UPDATE uye SET nereden="'.$deger.'" WHERE uyeid='.$_SESSION["id"]);
			}
			if ($_POST["medeni"] != ""){
				$deger = arındır($_POST["medeni"]);

				// Veritabanına yerlestirme
				mysql_query('UPDATE uye SET medeni="'.$deger.'" WHERE uyeid='.$_SESSION["id"]);
			}
			if ($_POST["meslek"] != ""){
				$deger = arındır($_POST["meslek"]);

				// Veritabanına yerlestirme
				mysql_query('UPDATE uye SET meslek="'.$deger.'" WHERE uyeid='.$_SESSION["id"]);
			}
			if ($_POST["hakkimda"] != ""){
				$deger = arındır($_POST["hakkimda"]);

				// Veritabanına yerlestirme
				mysql_query('UPDATE uye SET hakkımda="'.$deger.'" WHERE uyeid='.$_SESSION["id"]);
			}
			if ($_POST["sevdiklerim"] != ""){
				$deger = arındır($_POST["sevdiklerim"]);

				// Veritabanına yerlestirme
				mysql_query('UPDATE uye SET sevdiklerim="'.$deger.'" WHERE uyeid='.$_SESSION["id"]);
			}
			if ($_POST["aradigim"] != ""){
				$deger = arındır($_POST["aradigim"]);

				// Veritabanına yerlestirme
				mysql_query('UPDATE uye SET aradıgım="'.$deger.'" WHERE uyeid='.$_SESSION["id"]);
			}
			if ($_POST["gun"] != ""){ // Buradan Aşağısı Fuzuli bir deyim karmaşasıdır...
				$gun = arındır($_POST["gun"]);
				$ay = arındır($_POST["ay"]);
				$yıl = arındır($_POST["yil"]);

				// Veritabanına yerlestirme
				mysql_query('UPDATE uye SET dogumtar="'.$gun.'.'.$ay.'.'.$yıl.'" WHERE uyeid='.$_SESSION["id"]);
			}
		}
	}

	function mesaj_pan($komut = "gelen"){ // DEWAAAMMMM // ///SAYFALAMADAN DEWAM EDİLECEK
		/* Tablo yapısı benimsenecek */

		// Başlangıç: tablo başlığı

		$menu1 = "yenimesaj";
		$menu2 = "gondrlen";
		$menu1ad = "Yeni Yaz";
		$menu2ad = "Gönderilenler";

		$baslik = dil("--- Gelen Kutusu ---");

		if ($komut == "giden"){
			$menu1 = 'gelen';
			$menu2 = 'yenimesaj';
			$menu1ad = dil("Gelenler");
			$menu2ad = dil("Yeni Yaz");
			$baslik = dil("--- Giden Kutusu ---");
		}

		echo '<div class="baslik">
				<p>
					<a href="index.php?komut=mesaj&git='.$menu1.'">'.$menu1ad.'</a> . 
					<a href="index.php?komut=mesaj&git='.$menu2.'">'.$menu2ad.'</a>
				</p>
				<p>'.$baslik.'</p>
			</div>

			<p class="altbaslik" color:#FFFFFF; border-bottom:#FFFFFF dotted 1px; ">
				<b class="yancizgi">Seç</b>
				<b>'.dil("Başlık/Kimden").'</b>
			</p>';


		// Script hazırlanması
		echo '<script language="javascript">

				var nesne;

				function yolla(deger){
					nesne = document.getElementById("islem");
					nesne.value = deger;
					document.forms[0].submit();
				}
			</script>';

		// Form'un tanımlanması
		echo '<form action="index.php?komut=mesaj&git=islem" method="post">
				<input type="hidden" name="komut" id="komut" value="'.$komut.'"> <!-- Sunucuya işlem sırasında uygulaması gereken kuralı söyler -->
				<input type="hidden" name="islem" id="islem" value="0">';

		// Öğe alınımı ve yazımı
		$sayfaad = mesaj_cıktı($komut); // Kaçınıcı sayfada olunduğu bu fonksiyonun içinde tanımlanmıştır

		// İşlem menüsü

		echo '<div class="baslik">
				<p><a href="javascript:void(0)" onclick="yolla(1)">'.dil("Hepsini sil").'</a></p>
				<p><a href="javascript:void(0)" onclick="yolla(2)">'.dil("Hepsini onayla").'</a></p>
				<p><a href="javascript:void(0)" onclick="yolla(3)">'.dil("Seçilileri sil").'</a></p>
				<p><a href="javascript:void(0)" onclick="yolla(4)">'.dil("Seçilileri onayla").'</a></p>
				<p><a href="javascript:void(0)" >'.dil("Ayarlar").'</a></p>
			</div>
			</form>' ;
		
		// Bitiriş: Sayfa bilgilerinin yazdırılması

		echo '<p class="sayfa_gostergec">'.sayfa_no_gorntle(@$_GET["sayfa"],"index.php?".$_SERVER['QUERY_STRING']."&sayfa=","mesajlar".$sayfaad).'</p>';
	
		
	}

	function sayfa_no_gorntle($maske,$kalıp_link,$sayfaadı){  // TESTTTTTT YAPILMADI
		/*  
			Amaç: Verilen maskeyi hem link'e koyup hemde çözümleyip diğer aritmetik sayıları yan yana dizmektir
			Ve sayfaya sağ sol yön tuşları koydurtmaktır.
			
			Örnek Kullanım:
				sayfa_no_gorntle(@$_GET["sayfa"],"index.php?".$_SERVER['QUERY_STRING']."&sayfa=","mesajlar".$sayfaad)
		*/
		// NOT: sayfaadı hangi sayfa için maskeleme işelemlerinin gerçekleştirildiğini belirtir... 
		
		$link_list = array();
		$donut = "";
		
		// Maximum sayfa sayısı
		$max_deger = $_SESSION["sayfalar"][$sayfaadı]["max_sayfa"];
		
		if ($maske != ""){
			$sayı = maske_coz($maske); // Bu denklik kesinlikle sağlanmalıdır
		}
		else{
			$sayı = 1;
		}
		
		
		//echo "Verilen ".$maske."'nin karşılığı".$sayı."<br>";
		
		// Geri butonu;
		if (($sayı - 1) > 0){
			// Bir sonraki sayının maskesi:
			$mske = id_maskele(($sayı-1),$sayfaadı);
			
			$donut .= '<a href="'.$kalıp_link.$mske.'">◄</a>';
		}
		else{
			$donut .= "◄";
		}
		
		// -2 den başlayarak +2 ye kadar sayılarak önceki sayfaların linkleri ve sonraki sayfaların linkleri oluşturuluyor
		for ($i=-2;$i <= 2;$i++){
			if (($sayı + $i) > 0 and ($sayı + $i) <= $max_deger){
				// Bir sonraki sayının maskesi:
				$mske = id_maskele(($sayı + $i),$sayfaadı);
				
				if ($i == 0){ // Bu Durumda yazılma sırası gelen sayıya yeni o anki seçili sayfanın no'suna gelmiştir
					$donut .= ' <a style="text-decoration:underline;" href="'.$kalıp_link.$mske.'">.'.($sayı + $i).'.</a> ';
				}
				else{
					$donut .= ' <a href="'.$kalıp_link.$mske.'">.'.($sayı + $i).'.</a> '; // Maskelenmiş link oluşturma...
				}
				
			}
		}
		
		// İleri butonu;
		if (($sayı + 1) <= $max_deger){
			// Bir sonraki sayının maskesi:
			$mske = id_maskele(($sayı+1),$sayfaadı);
			
			$donut .= '<a href="'.$kalıp_link.$mske.'">►</a>';
		}
		else{
			$donut .= "►";
		}
		
		return $donut;
	}
	
	function mesaj_cıktı($komut = "gelen"){

		// Tabloya uygun dizyn edilecek post method'lu form	kullanılacak

		// Kullanıcı Ayar verileri çekiliyor
		$max_satır = 10;

		// Get[] den sayfa öğreniliyor
		$sayfa = 0;

		// Get[] den gelen veya giden kutusu olup olmadığı anlasılıyor
		$kmt = "oku";

		if (isset($_GET["git"])){
			if ($_GET["git"] == "gondrlen"){
				$kmt = "oku1";
			}
		}

		if (isset($_GET['sayfa'])){
			$sayfa = $_GET['sayfa'];
		}

		// mesaj_no ların kaydedileceği dizin

		$msjnolar = array();

		// Veri tabanından veri çekilmesi Tablo biçimi: No-Gönderen-Alan-Baslık-İcerik-Tarih
		// Tarihde devrim yapılacak

		// Herhangi sızıntıya karşı güvenlik filtreleri kullanılabilir...
		$uyeid = $_SESSION["id"];

		if ($komut == "gelen"){
			$sorgu = mysql_query('SELECT mesaj_id,atan_id,alan_id,baslik,tarih,onay FROM mesaj WHERE alan_id='.$uyeid.' and gorunur_alan=1');
		}
		else if ($komut == "giden"){
			$sorgu = mysql_query('SELECT mesaj_id,atan_id,alan_id,baslik,tarih,onay FROM mesaj WHERE atan_id='.$uyeid.' and gorunur_atan=1');
		}
		
		$sayfaad = $komut;

		// Tablodaki toplam satır sayısına göre işlemler dizisi
		$index = $sayfa * $max_satır;

		$satır = mysql_num_rows($sorgu);

		// Basit döngüyle bütün mesajların bir array'a yüklenmesi
		$msjlar = array();
		
		while($mesaj = mysql_fetch_array($sorgu)){
			
			$msjlar[] = $mesaj;
			
		}
		
		
		//** Mesajların Sayfalanması **//
		sayfala($msjlar,"mesajlar".$sayfaad,10);
		
		//** Sayfalanan Mesajların Görüntülenmesi **//
		$msjlar = sayfa_dizisi($sayfa,"mesajlar".$sayfaad);
		
		
		//Teker teker tablo yapısına uygun verileri yazdırma
		
		//echo '<table width="145" border="0">';
		
		if ($msjlar){
			foreach ($msjlar as $mesaj){

				// Veri tabanından çekilen veriler
				$mesajid = $mesaj["mesaj_id"];
				$baslik = $mesaj["baslik"];
				$kim = uye_adı($mesaj["atan_id"]); // Uye adını buldurma // Varsayılan ayarıdır kim değişkeni iki farklı görev için kullanılacaktır birinci konumu ön tanımlıdır
				$kime = uye_adı($mesaj["alan_id"]);
				$onay = $mesaj["onay"];

				// Yazımla ilgili veriler
				$isaret = "(!)";
				$sıfat = "Kimden"; // N'apim koymaya başka ad bulamadım

				// Kontroller
				if ($onay == 1){
					$isaret = "";
				}

				if ($komut == "giden"){ // İkinci komut için ön tanımlı değerler değiştiriliyor
					$sıfat = "Kime ";
					$kim = $kime; /// Bu kodda bir matıksal hata var 11.12.2011 17:13 ////
				}
				else{
					// Ad'a link verme

					$kim = '<a href="index.php?komut=arkadas&git=menu&id='.id_maskele($uyeid,"mesaj").'">'.$kim.'</a>';
				}

				// Yazdırma ve kayda alma
				$msjnolar[$i-$index] = $mesajid;

				echo '	<table class="listetab"  width=100% border="0">
						  <tr>
							<td id="ilk"  width=15 >
								<input name="k'.($i-$index).'" type="checkbox">
							</td>
							<td>
								<b id="mesaj_tab" ><a style="padding:0px;" href="index.php?komut=mesaj&git='.$kmt.'&id='.id_maskele($mesajid,"mesaj").'">'.$baslik.$isaret.'</a></b><br />
								'.$sıfat.':<br /><b>'.$kim.'</b></td>
						  </tr>
						</table>';
			}
		}
		else {
			echo '<b style="yazi"><br />'.dil("Malesef görüntülenecek mesajnız bulunmamaktadır").' </b><br />';
		}

		$_SESSION['mesajid'] = $msjnolar;

		return $sayfaad;

	}

	function mesaj_yazpan(){
		// Ön tanımlı değerlerin alınması

		$nereye = "";
		$baslik = "";
		$kime = "";

		if (isset($_GET["nereye"])){ // Buradan alınan değişken bir mesajın üstüne cevap yazılacağı anlamındadır;
			$nereye = maske_coz($_GET["nereye"]); // Guvenlikkkkkkk
			// Baslik ve kime değişkenleri doldurulacakkk !!!!!! //
		}

		if (isset($_GET["kime"])){ // Buradan alınan değişken bir mesajın üstüne cevap yazılacağı anlamındadır;
			$kime = uye_adı(maske_coz($_GET["kime"])); // Guvenlikkkkkkk
		}

		if (isset($_GET["baslik"])){ // Buradan alınan değişken bir mesajın üstüne cevap yazılacağı anlamındadır;
			$baslik = maske_coz($_GET["baslik"]); // Guvenlikkkkkkk
		}

		// Post scriptinin oluşturulması
		echo '<script language="javascript">

				var nesne;

				function yolla(deger){
					nesne = document.getElementById("islem");
					nesne.value = deger;
					document.forms[0].submit();
				}

			</script>';


		// Üst menü ve formun tanımlanması
		echo '<p class="baslik">
				<b style="border-right:#FFFFFF dotted 1px; padding-right:5px;"><a href="index.php?komut=mesaj">'.dil("Gelen Kutusu").'</a></b>
				<b><a href="index.php?komut=mesaj&git=gondrlen">'.dil("Gönderilenler").'</a></b></br>
			</p>

			<form action="index.php?komut=mesaj&git=yenimesaj" method="post">
				<input type="hidden" name="nereye" value="'.$nereye.'">';

			if ($nereye == ""){
				echo '<p style="background-color:#CC6600; color:#FFFFFF;">
						<input type="hidden" name="islem" id="islem" value="0">
						Kime:<br/>
						<input type="text" name="kime" value="'.$kime.'"><br />
						Başlık:<br/>
						<input type="text" name="baslik" value="'.$baslik.'">
					</p>';
			}
			else {
				echo '<p class="listeyazi"><b style="color:#CC6600;">'.dil("Cevap Yaz:").'</b></p>';
			}


			echo '<p style="padding-top:5px;"><textarea name="icerik" rows="10" cols="20" >aa</textarea></p>

				<p style="background-color:#CC6600; color:#FFFFFF; border-bottom:#FFFFFF dotted 1px;">
					<!-- <a href="javascript:void(0)" onclick="yolla(1)">Dosya iliştir</a> -->
					<input type="submit" value="'.dil("Yolla").'">
				</p>

			</form>';


	}

	function mesaj_oku(){
		// Belirtilen id'nin içeriği yazdırılacak

		// !!!!! ----GÜVENLİKK---- !!!!! //
		$sorgu = mysql_query('SELECT * FROM mesaj WHERE mesaj_id='.maske_coz($_GET["id"]));

		$yazan_id = mysql_result($sorgu,0,"atan_id");
		$yazan = uye_adı($yazan_id);

		$baslik = mysql_result($sorgu,0,"baslik");
		$icerik = mysql_result($sorgu,0,"icerik");
		$tarih = mysql_result($sorgu,0,"tarih");

		// Üst menü
		echo '<p class="baslik">
				<b style="border-right:#FFFFFF dotted 1px; padding-right:5px;"><a href="index.php?komut=mesaj">Gelenler</a></b>
				<b><a href="index.php?komut=mesaj&git=gondrlen">Gidenler</a></b><br />
			</p>';

		// Okundu olarak işaretleme

		mysql_query('UPDATE mesaj SET onay=1 WHERE mesaj_id='.maske_coz($_GET["id"]));

		// Alınan verilerin yazılması // Cevapla için bir form kullanılacak

		echo '  <p class="listeyazi"><b style="color:#CC6600;">Yazan: <a class="yazi_a_czgsz" href="index.php?komut=arkadas&git=menu&id='.id_maskele($yazan_id,"mesaj").'"> '.$yazan.'</a></b></p>
				<p class="listeyazi"><b style="color:#CC6600;">Başlık:</b> '.$baslik.'</p>
				<p class="listeyazi"><b style="color:#CC6600;">İçerik:</b><br /> '.$icerik.'</p>';

		if ($_GET["git"] == "oku"){
			echo '	<form action="index.php?komut=mesaj&git=yenimesaj&nereye='.$_GET["id"].'" method="post">
						<input type="hidden" name="islem" id="islem" value="">
						<p style="background-color:#CC6600; color:#FFFFFF;">
							<input type="submit" value="Cevapla">
						</p>
					</form>';
		}
	}

	function mesaj_islemleri(){

		// Ön tanımlı sorgu değerleri:
		$kim = "alan";

		// Önttanımlı değerlerin kurala göre değişmesi
		if ($_POST["komut"] == "giden"){
			$kim = "atan";
		}

		if ($_POST["islem"] == "1"){ // Hepsini silme komutu
			echo "ooo";
			echo 'UPDATE mesaj SET gorunur_'.$kim.'=0 WHERE gorunur_'.$kim.'=1 and '.$kim.'_id='.$_SESSION["id"];
			@mysql_query('UPDATE mesaj SET gorunur_'.$kim.'=0 WHERE gorunur_'.$kim.'=1 and '.$kim.'_id='.$_SESSION["id"]);
		}
		else if ($_POST["islem"] == "2"){ // Hepsini onaylama komutu
			mysql_query('UPDATE mesaj SET onay=1 WHERE '.$kim.'_id="'.$_SESSION["id"]);

		}
		else if ($_POST["islem"] == "3"){ // Seçilileri Silme

			for ($i=0;$i<=10;$i++){ // 10 ifadesi ayarlanabilir !!!!!!!!

				if (isset($_POST['k'.$i])){

					// Silme islemi
					@mysql_query('UPDATE mesaj SET gorunur_'.$kim.'=0 WHERE mesaj_id="'.$_SESSION['mesajid'][$i].'"' )or die(mysql_error());
				}
			}

		}
		else if ($_POST["islem"] == "4"){ // Seçilileri Silme

			for ($i=0;$i<=10;$i++){ // 10 ifadesi ayarlanabilir !!!!!!!!

				if (isset($_POST['k'.$i])){

					// Silme islemi
					@mysql_query('UPDATE mesaj SET onay=1 WHERE mesaj_id="'.$_SESSION['mesajid'][$i].'"' )or die(mysql_error());
				}
			}

		}

	}

	function arkadaslik_istekleri(){ // Blok
	
		$sorgu = mysql_query('SELECT arkadas_istek FROM uye WHERE uyeid='.$_SESSION["id"]);
		if (mysql_result($sorgu,0,"arkadas_istek") != ""){

			// Baslık ve tablo
			echo '<p class="baslik">
					<b>'.dil("Arkadaşlık Kurmak İsteyenler").'</b></br>
				</p>
				<table class="listetab" border="0">';

			$liste = scrpt_parcala(mysql_result($sorgu,0,"arkadas_istek"));
			//scrpt_parcala(scrpt_birlestir($liste));

			//echo uye_adı($liste["istek".$i]["u"]["kim"]);

			///new dbug($liste);
			$i = 0;
			$dur = false;

			while (!$dur){
				if (isset($liste[$i])){
					// Uye id alma;
					$uyeid = $liste[$i]["istek"]["u"]["kim"];

					// Tarih alma;
					$tarih = $liste[$i]["istek"]["s"]["tarih"];

					// Tablo iceriklerini yerlestirme
					echo '<tr>
							<td id="ilk"  width=15 >
								'.uye_foto(false,$uyeid,"padding-left:5px;").'
							</td>
							<td>
								<b><a href="index.php?komut=kisi_onayla&id='.id_maskele($i,"arkadas").'">'.uye_adı($uyeid).'</a></b>
							</td>
						</tr>';
				$i++;
				}
				else{
					$dur = true;
				}

			}
			echo '</table>';
		}
	}
	
	function arkadaslar(){ // Blok
		echo '<p class="baslik">
				<b>'.dil("Arkadaş Listem").'</b></br>
			</p>';

		// Arkadas listesinin alınması açık olup olmama kontrolü;

		$liste = arkadas_listesi(true);
		$i = 0;
		/*
		|p|arkadas:|s ad="konum"|Sıkkk:|u ad="id"|2:;
		*/

		$konumlar = array();
		$dur = false;

		// new dbug($liste);

		while (!$dur){
			if (isset($liste[$i])){
				// Uye id alma;
				$uyeid = $liste[$i]["arkadas"]["u"]["id"];

				// Konum alma;
				$konum = $liste[$i]["arkadas"]["s"]["konum"];

				// Konum tablosunu oluşturma ve doldurma
				if (isset($konumlar[$konum])){
					$konumlar[$konum][] = $uyeid;
				}
				else{
					$konumlar[$konum] = array();
					$konumlar[$konum][] = $uyeid;
				}

				$i++;
			}
			else{
				$dur = true;
			}
		}

		////new dbug($konumlar);

		// Belirlenen Konumlara göre sayfaya yazdırma işlemi yapılıyor
		foreach (array_keys($konumlar) as $id){
			echo '<p class="gurupbaslik">
				<b>'.$id.'</b></br>
			</p><table border=0>';

			foreach ($konumlar[$id] as $idd){
				$uyeid = $idd;
				echo '<tr>
						<td style="padding-left:10px;" class="listetab" width=15 >
							'.uye_foto(false,$uyeid).'
						</td>
						<td>
							<b><a href="index.php?komut=arkadas&git=menu&id='.id_maskele($uyeid,"arkadas").'">'.uye_adı($uyeid).'</a></b>
						</td>
					</tr>';
			}
			echo "</table>";
		}
	}
	
	function arkadas_bulma_yontemleri(){ // Blok
		echo '<p class="baslik">
					<b>'.dil("Arkadaş Bulma Yöntemleri").'</b></br>
			  </p>
			  <p class="yazi"><a href="index.php?komut=arkadas&git=bul">'.dil("Arayarak Bul").'</a></p>
			  <p class="yazi"><a href="index.php?komut=arkadas&git=yeni_uyeler">'.dil("Yeni Üye Olanlara Bakarak Bul").'</a></p>
			  <p class="yazi"><a href="index.php?komut=arkadas&git=cevrimici">'.dil("Şu Anda Açık Olanlara Bakarak Bul").'</a></p>
			  <p class="yazi"><a href="index.php?komut=arkadas&git=tum_uyeler">'.dil("Tüm Üyelere Bakarak Bul").'</a></p>';
	}
	
	function arkadas_pan(){ // Blok

		$liste = array();

		// Yeni arkadas kontrolü yapılıyor

		arkadaslik_istekleri();
		
		arkadaslar();
		
		arkadas_bulma_yontemleri();
	}

	function arkadas_menu(){

		// Başlangıç:bazı veriler; arkadaş olma durumu vs
		$arkadasmı = false;

		$arkadasmı = arkadasmı(maske_coz($_GET["id"]));

		// Üst menüler / uye foto / uye bilgiler

		$bilgi = uye_bilgileri(maske_coz($_GET["id"]));

		echo '<p class="baslik">
				<b>'.dil("Bilgiler").'</b></br>
			</p>

			<table width="200" border="0">
			<tr>
				<td width="70" rowspan="4">'.uye_foto(false,maske_coz($_GET["id"]),70,70).'</td> <!-- Üye fotosunun konulması; -->
				<td>'.dil("Adı:").' '.$bilgi["ad"].'</td>
			</tr>
			<tr>
				<td>'.dil("Soyadı:").' '.$bilgi["soyad"].'</td>
			</tr>
			<tr>
				<td>'.dil("Cinsiyeti:").' '.$bilgi["cinsiyet"].'</td>
			</tr>
		</table></b>
		<b style="color:#CC3300;" >-- -- -- -- -- -- -- -- -- -- -- --</b>
		<p class="arkmenu" ><b>
			'.kaynak_al("arkadaş menü mesajyolla").' <a href="index.php?komut=mesaj&git=yenimesaj&kime='.$_GET["id"].'">'.dil("Mesaj Yolla").'</a><br />
			'.kaynak_al("arkadaş menü elsalla").' <a href="index.php?komut=elsalla&id='.$_GET["id"].'">'.dil("El Salla").'</a><br />
			'.kaynak_al("arkadaş menü sohbetkur").' <a href="index.php?komut=sohbetkur&id='.$_GET["id"].'">'.dil("Sohbet Kur").'</a><br />
			'.kaynak_al("arkadaş menü profilebak").' <a href="index.php?komut=profil&git=id&id='.$_GET["id"].'">'.dil("Profiline Bak").'</a><br />
			'.kaynak_al("arkadaş menü fotoğrafabak").' <a href="index.php?komut=duvar&git=foto&id='.$_GET["id"].'">'.dil("Fotoğraflarına Bak").'</a><br />
			'.kaynak_al("arkadaş menü duvarınıgör").' <a href="">'.dil("Duvarını Gör").'</a><br />
			'.kaynak_al("arkadaş menü önemlimesajıat").' <a href="">'.dil("Önemli Mesajı At").'</a><br /></b>
		</p>
		<b style="color:#CC3300;" >-- -- -- -- -- -- -- -- -- -- -- --</b>
		<p class="arkmenu"><b>';

		if (!$arkadasmı){
			echo kaynak_al("arkadaş menü arkadasteklif").' <a href="index.php?komut=teklif&id='.$_GET["id"].'">'.dil("Arkadaşlık Teklifi Yolla").'</a><br />';
		}
		else{
			echo kaynak_al("arkadaş menü arkadasgurup").' <a href="index.php?komut=gurup_degis&git=sec&id='.$_GET["id"].'">'.dil("Arkadaş Gurubunu Değiştir").'</a><br />
			   '.kaynak_al("arkadaş menü arkadascıkar").' <a href="index.php?komut=arkadasliktan_cikar&id='.$_GET["id"].'">'.dil("Arkadaş Listesinden Çıkar").'</a><br />';
		}

		echo  kaynak_al("arkadaş menü oparator").' <a href="">'.dil("Oparatöre Şikayet Et").'</a><br />
			'.kaynak_al("arkadaş menü ayarlar").' <a href="">'.dil("Kişi İle Ayarlar Yap").'</a><br /></b>
		</p>';
	}
	
	function arkadas_ara_pan(){
		
		// Aratma Panelinin Yerleştirilmesi
		
		echo '<p class="baslik">ARKADAŞ ARA</p>
		<form method="">
			<input type="text" name="ara" >
			<input type="submit" value="bul">
		</form>';
		
		// Arama sonuçlarını alınması
		$liste = arkadas_ara(maske_coz($_GET["id"]));
		
		// Hangi sayfada olunduğunun öğrenilmnesi...
		$sayfa = 1;
		
		if (isset($_GET["sayfa"])){
			$sayfa = "sayfa";
		}
		
		// Elde edilen sonuçların yazdırılması
		foreach($liste as $id){
			
		}

	}

	function butun_kullanıcılar(){
		// Bütün Kullanıcıları listeler;

		$sayfa_dzi = array();
		$sorgu_dzi = array();
		
		// Açık olanları önce başa sonra diğer kullanıcıları sona ekler
		// Sorgulama ve dizine alma işlemi
		$sorgu = mysql_query('SELECT uyeid,cevrimici FROM uye');
		
		while($listele = mysql_fetch_assoc($sorgu)){
			$sorgu_dzi[] = $listele;
		}
		
		// Alınan Liste Sayfalanıyor...
		sayfala($sorgu_dzi,"bütün kullanıcıları arat");
		$sayfa_dzi = sayfa_dizisi($_GET["sayfa"],"bütün kullanıcıları arat"); // Hata Verme OLASILIĞI YÜKSEKKKK
		
		echo '<table border=0>';
			
		foreach ($sayfa_dzi as $dizi){
			// Dizinden çıkan veriyi ekrana dökme...
			
			if ($dizi["cevrimici"] == 1){
				$uye_durum = "çevrimiçi";
			}
			else{
				$uye_durum = "çevrimdışı";
			}
			
			$uyeid = $dizi["uyeid"];
			
			echo '<tr>
					<td style="padding-left:10px;" class="listetab" width=15 >
						'.uye_foto(false,$uyeid).'
					</td>
					<td>
						<b><a href="index.php?komut=arkadas&git=menu&id='.id_maskele($uyeid,"bütün_kullanıcılar").'">'.uye_adı($uyeid).'</a></b>
					</td>
					<td>
						'.kaynak_al($uye_durum).'
					</td>
				</tr>';
		}
		
		echo "</table>";
	}

	function yeni_kaydolanlar(){

	}

	function acık_kullanıcılar(){
		
	}
	
	function gurup_secpan(){
		// Başlığında Gurubu değiştirilecek olan kişinin ismiyle beraber form radiobuton sistemi kurulacaktır ///
		echo '<table class="baslik" border="0">
				<tr>
					<td>'.uye_foto(false,maske_coz($_GET["id"])).'</td>
					<td>'.uye_adı(maske_coz($_GET["id"])).' için</td>
					<td width="200"></td>
				</tr>
				 
			</table><b class="yazi">'.dil("Gurup adı seç").'</b>';


		// scrpt_text ile dizin methoduyla s alanından grup adları çekiliyor

		$sorgu = mysql_query('SELECT arkadas FROM uye WHERE uyeid='.$_SESSION["id"]);
		$scrpt_text = mysql_result($sorgu,0,"arkadas");

		$dizin = scrpt_parcala($scrpt_text);
		$grp_dizin = $dizin["s"];
		$grp_adları = array();

		foreach ($grp_dizin as $icerik){
			$grp_adları[] =  $icerik["gurup"]["s"]["konum"];
		}

		// Alınan adların yazdırılması; // DELÜRTMEİN LAN PHENİ,İİ**
		echo '<form id="form1" action="index.php?komut=gurup_degis&git=isle&id='.maske_coz($_GET["id"]).'" method="post">';

		foreach ($grp_adları as $ad){
			echo '<p style="padding:5px;"><input name="deger" type="radio" value="'.$ad.'"/>'.$ad.'</p>';
		}

		echo '<p class="yazi"><a href="index.php?komut=gurup_degis&git=yeni">'.dil("Yeni Gurup Oluştur -->").'</a></p>';
		$_SESSION["geri_dönme2"] = arındır($_SERVER["QUERY_STRING"]);
		
		echo '<input type="submit" value="'.dil("Değiştir").'"></form>';

		//new dbug($dizin);

	}

	function foto_menu($id = 0,$komut = 'görüntüle'){

		if ($id == 0){
			$id = $_SESSION["id"];
		}
		// Başlangıç: tablolu olarak resimler alt alta listelenecek
		// Ek olarak Resim'i tam ekran görüntüleme ayarlanabilir çözünürlüklerde olacak

		if ($komut == 'görüntüle'){

			// Veritabanından kullancının paylaşmış olduğu fotoğraflar toplanıyor

			@$sorgu = mysql_query('SELECT * FROM paylasımlar WHERE tur="foto" and gondrn_id='.$id)or die(mysql_error());

			if($sorgu){

				echo '<table class="listetab" border="0">';

				if (mysql_num_rows($sorgu) > 0){
					while($listele = mysql_fetch_assoc($sorgu)){
						$icerik = $listele['icerik'];
						if ($icerik != ""){

							// icerik içindeki bilgiler parçalanıp sınıflandırlıyor

							$veriler = scrpt_parcala($icerik);

							$yol = $veriler["s"]["adres"]; // array içindeki veriler veri pacala tarafından tablodan alına veriye göre oluşturulmuştur
							$etiket = $veriler["s"]["tanim"];

							//new dbug($veriler);

							echo '<tr>
									<td id="ilk"  width=15 >
										<img src="'.$yol.'" height=40 width=40 />
									</td>
									<td>
										<b><a href="index.php?komut=yorum&nsne_tur=gonderi_yorum&id='.id_maskele($listele['id'],"fotomenu").'">'.$etiket.'</a></b>
									</td>
								</tr>';
						}
					}
				}
				echo '</table>';
			}
		}
	}

	function ayar_pan(){ ///// !!!! COOKİELERRR !!!!! //// //// HESAP PAN GÜNCELLEMEEE ///
		// Profil ayarlarları - Hesap ayarları - Görsel ayarlar //

		@$sorgu = mysql_query('SELECT * FROM uye_2 WHERE uyeid='.$_SESSION["id"])or die(mysql_error());

		if (isset($_GET["islem"])){
			if ($_GET["islem"] == "hesap"){
				// Kullanıcı adım - Epostam - Eski şifrem - Yeni şifrem - Şifre onay

				$otomat = mysql_result($sorgu,0,"hesap_otomatik");

				$htrla_ad = "";
				$htrla_sifre = "";
				$otmtik_ac = "";

				if ($otomat == 1){
					$htrla_ad = "checked";
				}
				else if ($otomat == 2){
					$htrla_ad = "checked";
					$htrla_sifre = "checked";
				}
				else if ($otomat == 3){
					$otmtik_ac = "checked";
				}

				echo '<p class="baslik">'.dil("Hesap Ayarları").'<p>';

				echo '<form style="padding:5px;" id="form1" action="index.php?komut=ayarlar" method="post">
						<b>'.dil("Kullanıcı Adım:").'</b><br />
						<input type="text" name="kullanıcı" value="'.$_SESSION["kullanıcı_adı"].'"><br />
						<b>'.dil("Eski Şifre:").'</b><br />
						<input type="password" name="ex_sifre"><br />
						<b>'.dil("Yeni Şifre:").'</b><br />
						<input type="password" name="yn_sifre"><br />
						<b>'.dil("Yeni Şifre Onay:").'</b><br />
						<input type="password" name="yn_sifre_ony"><br />

						<b>---</b><br />

						<input name="htrla_ad" type="checkbox" '.$htrla_ad.' /> '.dil("Kullanıcı Adımı Hatırla").' <br />
						<input name="htrla_bilgi" type="checkbox" '.$htrla_sifre.' /> '.dil("Kullanıcı Adımı ve Şifremi Hatırla").' <br />
						<input name="otomatik" type="checkbox" '.$otmtik_ac.' /> '.dil("Oturumumu Direkt Aç").' <br />
						<input value="'.dil("Güncelle").'" type="submit"></form>';

			}
			else if ($_GET["islem"] == "gorsel"){
				// Tema menüsü;
				$tema_menu = "";
				
				$veri = uye_verileri($_SESSION['id']);
				$vrsylan = $veri['grafik_tema'];
				
				$sorgu = mysql_query('SELECT * FROM temalar');
				
				while ($tema = mysql_fetch_array($sorgu)){
					
					if ($tema == $vrsylan){
						$tema_menu .= '<option value="'.$tema['tema_ad'].'" selected="selected">'.$tema['tema_ad'].'</option>';
					}
					else {
						$tema_menu .= '<option value="'.$tema['tema_ad'].'" >'.$tema['tema_ad'].'</option>';
					}
					
				}
				
				// Yazı Boyutunu Değiştir Menüsü... 
				$yazı_boyut = "";
				
				$vrsylan = $veri['grafik_yazi_boyut'];
				
				for ($i = 8;$i <= 18;$i++){
					
					if ($i == $vrsylan){
						$yazı_boyut .= '<option value="'.$i.'" selected="selected">'.$i.'</option>';
					}
					else {
						$yazı_boyut .= '<option value="'.$i.'" >'.$i.'</option>';
					}
					
				}
				
				// Resim Boyutunu Değiştir Menüsü... 
				$img_boyut = "";
				
				$vrsylan = $veri['grafik_res_boyut'];
				
				for ($i = 8;$i <= 18;$i++){
					
					if ($i == $vrsylan){
						$img_boyut .= '<option value="'.$i.'" selected="selected">'.$i.'</option>';
					}
					else {
						$img_boyut .= '<option value="'.$i.'" >'.$i.'</option>';
					}
					
				}
				
				// Resim göster kutucuğu...
				$goster = "";
				
				if ($veri['grafik_res_goster'] == 1){
					$goster = "checked";
				}
				
				echo 
				'<p class="baslik">'.dil("Görsel Ayarlar").'</p>
				
				<form id="form1" action="index.php?komut=ayarlar&islem=isle" method="post">
					<p>'.dil("Tema Değiştir:").'
					<select name="tema">
						'.$tema_menu.'
					</select></p>
					
					<p>'.dil("Yazı Boyutunu Değiştir").'
					<select name="yazi_boyut">
						'.$yazı_boyut.'
					</select></p>
					
					<p>'.dil("Resim Boyutunu Değiştir").'
					<select name="img_boyut">
						'.$img_boyut.'
					</select></p>
					
					<p>'.dil("Resimleri Göster").'
					<input type="checkbox" name="img_gorntule" '.$goster.'></p>
					
					<input type="submit" name="gonder" value="'.dil("Kaydet").'">
				</form>
				';
				
			}
			else if ($_GET["islem"] == "sohbet"){ // TEEEVVVAAMMM
				// Tema menüsü;
				$tema_menu = "";
				
				$veri = uye_verileri($_SESSION['id']);
				$vrsylan = $veri['grafik_tema'];
				
				$sorgu = mysql_query('SELECT * FROM temalar');
				
				while ($tema = mysql_fetch_array($sorgu)){
					
					if ($tema == $vrsylan){
						$tema_menu .= '<option value="'.$tema['tema_ad'].'" selected="selected">'.$tema['tema_ad'].'</option>';
					}
					else {
						$tema_menu .= '<option value="'.$tema['tema_ad'].'" >'.$tema['tema_ad'].'</option>';
					}
					
				}
				
				// Yazı Boyutunu Değiştir Menüsü... 
				$yazı_boyut = "";
				
				$vrsylan = $veri['grafik_yazi_boyut'];
				
				for ($i = 8;$i <= 18;$i++){
					
					if ($i == $vrsylan){
						$yazı_boyut .= '<option value="'.$i.'" selected="selected">'.$i.'</option>';
					}
					else {
						$yazı_boyut .= '<option value="'.$i.'" >'.$i.'</option>';
					}
					
				}
				
				// Resim Boyutunu Değiştir Menüsü... 
				$img_boyut = "";
				
				$vrsylan = $veri['grafik_res_boyut'];
				
				for ($i = 8;$i <= 18;$i++){
					
					if ($i == $vrsylan){
						$img_boyut .= '<option value="'.$i.'" selected="selected">'.$i.'</option>';
					}
					else {
						$img_boyut .= '<option value="'.$i.'" >'.$i.'</option>';
					}
					
				}
				
				// Resim göster kutucuğu...
				$goster = "";
				
				if ($veri['grafik_res_goster'] == 1){
					$goster = "checked";
				}
				
				echo 
				'<p class="baslik">'.dil("Sohbet Ayarları").'</p>
				
				<form id="form1" action="index.php?komut=ayarlar&islem=isle" method="post">
					<p>'.dil("Tema Değiştir:").'
					<select name="tema">
						'.$tema_menu.'
					</select></p>
					
					<p>'.dil("Yazı Boyutunu Değiştir").'
					<select name="yazi_boyut">
						'.$yazı_boyut.'
					</select></p>
					
					<p>'.dil("Resim Boyutunu Değiştir").'
					<select name="img_boyut">
						'.$img_boyut.'
					</select></p>
					
					<p>'.dil("Resimleri Göster").'
					<input type="checkbox" name="img_gorntule" '.$goster.'></p>
					
					<input type="submit" name="gonder" value="'.dil("Kaydet").'">
				</form>
				';
				
			}
			else if ($_GET["islem"] == "isle"){
				if (isset($_POST["eposta"])){ // Doğrulama için yada veri güvennliği için yada kontrolsüz girişi engellemk için yada kontrolsüz girişten kaynaklanacak hata mesajlarını örtpas etmek için
					//ECHO 'UPDATE uye2 SET grnr_eposta='.$_POST["eposta"].',grnr_adsyad='.$_POST["adsyad"].',grnr_cinsiyet='.$_POST["cinsiyet"].',grnr_ktlmsehir='.$_POST["ktlmsehir"].',grnr_iliski='.$_POST["iliski"].',grnr_meslek='.$_POST["meslek"].',grnr_hakkımda='.$_POST["hakkımda"].',grnr_sevdiklerim='.$_POST["sevdiklerim"].',grnr_asıl='.$_POST["asıl"].' WHERE uyeid='.$_SESSION["id"];
					@mysql_query('UPDATE uye_2 SET grnr_eposta='.$_POST["eposta"].',grnr_adsyad='.$_POST["adsyad"].',grnr_cinsiyet='.$_POST["cinsiyet"].',grnr_dogumtar='.$_POST["dogumtar"].',grnr_ktlmsehir='.$_POST["ktlmsehir"].',grnr_medeni='.$_POST["medeni"].',grnr_iliski='.$_POST["iliski"].',grnr_meslek='.$_POST["meslek"].',grnr_hakkımda='.$_POST["hakkımda"].',grnr_sevdiklerim='.$_POST["sevdiklerim"].',grnr_asıl='.$_POST["asıl"].' WHERE uyeid='.$_SESSION["id"])or die(mysql_error());

					sistem_cıktısı(false,dil("Profil Ayarlarınız Kaydedilmiştir"));
					// Son sayfaya dönme //
				}
				if (isset($_POST["tema"])){
					
					$tema = $_POST["tema"];
					$yazi_byt = $_POST["yazi_boyut"];
					$img_byt = $_POST["img_boyut"];
					
					$imgg = 0;
					
					if (isset($_POST["img_gorntule"])){
						$imgg = 1;
					}
					
					//echo 'noliii';
					
					@mysql_query('UPDATE uye_2 SET grafik_tema="'.$tema.'", grafik_yazi_boyut='.$yazi_byt.', grafik_res_boyut='.$img_byt.', grafik_res_goster='.$imgg.' ')or die(mysql_error());
					
					sistem_cıktısı(false,dil("Görsel Ayarlarınız Kaydedilmiştir"));
					
					// Son sayfaya geri dönme
					header('location:index.php?komut=ayarlar&islem=gorsel');
				}
			}
		}
		else{
			// Profil İzin Ayarları

			echo '<p class="baslik">'.dil("Profil Ayarları").'</p>';
			echo '<p style="padding:5px;" class="yazi"><a href="index.php?komut=ayarlar&islem=gorsel">'.dil("Görsel Ayarlar -->").'</a></p>';
			echo '<p style="padding:5px;" class="yazi"><a href="index.php?komut=ayarlar&islem=hesap">'.dil("Hesap Ayarları -->").'</a></p>';
			echo '<p style="padding:5px;" class="yazi"><a href="">'.dil("Sohbet Ayarları -->").'</a></p>';

			echo '<p> ---- </p> ';

			echo '<form style="padding:5px;" id="form1" action="index.php?komut=profil&git=ayarlar&islem=isle" method="post">
					<p><b>'.dil("E-Posta adresimi:").'</b><br>
					<select name="eposta">
						<option '.esitse_yaz(mysql_result($sorgu,0,"grnr_eposta"),1,'selected="checked"').' value="1">'.dil("Herkes Görebilir").'</option>
						<option '.esitse_yaz(mysql_result($sorgu,0,"grnr_eposta"),2,'selected="checked"').' value="2">'.dil("Arkadaşlarım Görebilir").'</option>
						<option '.esitse_yaz(mysql_result($sorgu,0,"grnr_eposta"),3,'selected="checked"').' value="3">'.dil("Sadece Ben Görebilirim").'</option>
					</select></p>
					<p><b>'.dil("Ad ve Soyadımı").'</b><br>
					<select name="adsyad">
						<option '.esitse_yaz(mysql_result($sorgu,0,"grnr_adsyad"),1,'selected="checked"').' value="1">'.dil("Herkes Görebilir").'</option>
						<option '.esitse_yaz(mysql_result($sorgu,0,"grnr_adsyad"),2,'selected="checked"').' value="2">'.dil("Arkadaşlarım Görebilir").'</option>
						<option '.esitse_yaz(mysql_result($sorgu,0,"grnr_adsyad"),3,'selected="checked"').' value="3">'.dil("Sadece Ben Görebilirim").'</option>
					</select></p>
					<p><b>'.dil("Cinsiyetimi").'</b><br>
					<select name="cinsiyet">
						<option '.esitse_yaz(mysql_result($sorgu,0,"grnr_cinsiyet"),1,'selected="checked"').' value="1">'.dil("Herkes Görebilir").'</option>
						<option '.esitse_yaz(mysql_result($sorgu,0,"grnr_cinsiyet"),2,'selected="checked"').' value="2">'.dil("Arkadaşlarım Görebilir").'</option>
						<option '.esitse_yaz(mysql_result($sorgu,0,"grnr_cinsiyet"),3,'selected="checked"').' value="3">'.dil("Sadece Ben Görebilirim").'</option>
					</select></p>
					<p><b>'.dil("Doğum Tarihimi:").'</b><br>
					<select name="dogumtar">
						<option '.esitse_yaz(mysql_result($sorgu,0,"grnr_dogumtar"),1,'selected="checked"').' value="1">'.dil("Herkes Görebilir").'</option>
						<option '.esitse_yaz(mysql_result($sorgu,0,"grnr_dogumtar"),2,'selected="checked"').' value="2">'.dil("Arkadaşlarım Görebilir").'</option>
						<option '.esitse_yaz(mysql_result($sorgu,0,"grnr_dogumtar"),3,'selected="checked"').' value="3">'.dil("Sadece Ben Görebilirim").'</option>
					</select></p>
					<p><b>'.dil("Katıldığım şehri").'</b><br>
					<select name="ktlmsehir">
						<option '.esitse_yaz(mysql_result($sorgu,0,"grnr_ktlmsehir"),1,'selected="checked"').' value="1">'.dil("Herkes Görebilir").'</option>
						<option '.esitse_yaz(mysql_result($sorgu,0,"grnr_ktlmsehir"),2,'selected="checked"').' value="2">'.dil("Arkadaşlarım Görebilir").'</option>
						<option '.esitse_yaz(mysql_result($sorgu,0,"grnr_ktlmsehir"),3,'selected="checked"').' value="3">'.dil("Sadece Ben Görebilirim").'</option>
					</select></p>
					<p><b>'.dil("Medeni durumumu").'</b><br>
					<select name="medeni">
						<option '.esitse_yaz(mysql_result($sorgu,0,"grnr_medeni"),1,'selected="checked"').' value="1">'.dil("Herkes Görebilir").'</option>
						<option '.esitse_yaz(mysql_result($sorgu,0,"grnr_medeni"),2,'selected="checked"').' value="2">'.dil("Arkadaşlarım Görebilir").'</option>
						<option '.esitse_yaz(mysql_result($sorgu,0,"grnr_medeni"),3,'selected="checked"').' value="3">'.dil("Sadece Ben Görebilirim").'</option>
					</select></p>
					<p><b>'.dil("İlişki durumumu").'</b><br>
					<select name="iliski">
						<option '.esitse_yaz(mysql_result($sorgu,0,"grnr_iliski"),1,'selected="checked"').' value="1">'.dil("Herkes Görebilir").'</option>
						<option '.esitse_yaz(mysql_result($sorgu,0,"grnr_iliski"),2,'selected="checked"').' value="2">'.dil("Arkadaşlarım Görebilir").'</option>
						<option '.esitse_yaz(mysql_result($sorgu,0,"grnr_iliski"),3,'selected="checked"').' value="3">'.dil("Sadece Ben Görebilirim").'</option>
					</select></p>
					<p><b>'.dil("Mesleğimi").'</b><br>
					<select name="meslek"><br>
						<option '.esitse_yaz(mysql_result($sorgu,0,"grnr_meslek"),1,'selected="checked"').' value="1">'.dil("Herkes Görebilir").'</option>
						<option '.esitse_yaz(mysql_result($sorgu,0,"grnr_meslek"),2,'selected="checked"').' value="2">'.dil("Arkadaşlarım Görebilir").'</option>
						<option '.esitse_yaz(mysql_result($sorgu,0,"grnr_meslek"),3,'selected="checked"').' value="3">'.dil("Sadece Ben Görebilirim").'</option>
					</select></p>
					<p><b>'.dil("Hakkımda yazısını").'</b><br>
					<select name="hakkımda">
						<option '.esitse_yaz(mysql_result($sorgu,0,"grnr_hakkımda"),1,'selected="checked"').' value="1">'.dil("Herkes Görebilir").'</option>
						<option '.esitse_yaz(mysql_result($sorgu,0,"grnr_hakkımda"),2,'selected="checked"').' value="2">'.dil("Arkadaşlarım Görebilir").'</option>
						<option '.esitse_yaz(mysql_result($sorgu,0,"grnr_hakkımda"),3,'selected="checked"').' value="3">'.dil("Sadece Ben Görebilirim").'</option>
					</select></p>
					<p><b>'.dil("Sevdiklerimi").'</b><br>
					<select name="sevdiklerim">
						<option '.esitse_yaz(mysql_result($sorgu,0,"grnr_sevdiklerim"),1,'selected="checked"').' value="1">'.dil("Herkes Görebilir").'</option>
						<option '.esitse_yaz(mysql_result($sorgu,0,"grnr_sevdiklerim"),2,'selected="checked"').' value="2">'.dil("Arkadaşlarım Görebilir").'</option>
						<option '.esitse_yaz(mysql_result($sorgu,0,"grnr_sevdiklerim"),3,'selected="checked"').' value="3">'.dil("Sadece Ben Görebilirim").'</option>
					</select></p>
					<p><b>'.dil("Asıl Aradığımı").'</b><br>
					<select name="asıl">
						<option '.esitse_yaz(mysql_result($sorgu,0,"grnr_asıl"),1,'selected="checked"').' value="1">'.dil("Herkes Görebilir").'</option>
						<option '.esitse_yaz(mysql_result($sorgu,0,"grnr_asıl"),2,'selected="checked"').' value="2">'.dil("Arkadaşlarım Görebilir").'</option>
						<option '.esitse_yaz(mysql_result($sorgu,0,"grnr_asıl"),3,'selected="checked"').' value="3">'.dil("Sadece Ben Görebilirim").'</option>
					</select><br /></p>
					<p><input value="'.dil("Güncelle").'" type="submit"></p>
				</form>';
		}
	}

	function araclar_menü(){ // OOyy oyy daha çok iş var burada

		echo '	<p class="yazi"><a href="index.php?komut=ifadeler"><b>'.dil("İfadeler").'</b></a></p>
				<p class="yazi"><a href="index.php?komut=burc"><b>'.dil("Günlük Burç").'</b></a></p>
				<p class="yazi"><a href="index.php?komut=ilanlar"><b>'.dil("İlanlar").'</b></a></p>
				<p class="yazi"> ------ </p>
				<p class="yazi"><a href="index.php?komut=hesapkitap"><b>'.dil("Hesap Makinem (gelişmiş)").'</b></a></p>
				<p class="yazi"><a href="index.php?komut=donustrucu"><b>'.dil("Birim Dönüştürücü").'</b></a></p>
				<p class="yazi"><a href="index.php?komut=dosya"><b>'.dil("Dosya Yöneticisi").'</b></a></p>
				<p class="yazi"><a href="index.php?komut=saatt"><b>'.dil("Saat ve Tarih").'</b></a></p>';

	}

	function esitse_yaz($deger1,$deger2,$yaz,$degilse = ""){
		//echo $deger1." == ".$deger2."<br>";
		if ($deger1 == $deger2){
			return $yaz;
		}
		else{
			return $degilse;
		}
	}

	function paylasım_pan($sayfa_ad = "ortak_paylasımlar"){
		// Paylaşım menü - paylaşılanlar...
		$baslik = "";
		
		
		if($sayfa_ad == "ortak_paylasımlar"){
			echo '<p class="baslik">'.dil("Bir şeyler Paylaş").'</p>
				<form enctype="multipart/form-data" action="index.php?komut=paylasimlar&git=ortak" method="POST">
					<p style="padding:5px;">
						'.dil("Hadi durma yaz:").'<br>
						<input type="text" name="yazi"><br />
					<p style="padding:5px;"><input type="submit" value="'.dil("Paylaş!").'"></p>
				</form>';
				
			// Arkadaşların paylaşımlarını görüntüleme....
			// Koşul cümlesinin oluşturulması...
			
			$ark_list = arkadas_listesi(false);
			
			$sql_kosul = "";
			
			foreach ($ark_list as $id){
				$sql_kosul .= $id.",";
			}
				
			// Hata düzeltimi üstdeki döngünün sonucunda koşul bitiminde ayriyetden bir tane daha virgül işareti ortaya çıkar ki buda sql cümlesinin çaılşımamasına veya yanlış sonuçlar doğurmasına neden olur
			// Çözüm: Listelenen sonuçlar içinde kullanıcıda olacağından en dona kullanıcı id'si eklemek 
			
			$sql_kosul .= $_SESSION["id"]; 
			$sql_cumle = 'SELECT id,gondrn_id,tur,icerik,tarih FROM paylasımlar WHERE gondrn_id IN ('.$sql_kosul.') ORDER BY tarih DESC';
			
			//echo $sql_cumle;
			
			// Sorgu ile bütün paylaşılan öğeler alınıyor ve tür'üne göre tarih sıralamasında listeleniyor
			@$sorgu = mysql_query($sql_cumle)or die(mysql_error());
			
			// Öncelikli olarak çıkan sonuç sayfalanıyor...
			// CAHİLLİK BAŞA BELA :D DÖNGÜ YARDIMIYLA SQL_TABLOSUNDAN BİR İD DİZİNİ ALIYORUM...
			
			$dizi = array();
			$son_dizi = array();
			
			while($listele = mysql_fetch_assoc($sorgu)){
				$dizi[] = $listele;
			}
			
			// Bu sayfalama methodu standartdır ve sistemin her yerinde bu standart uygulanacaktır
			sayfala($dizi,$sayfa_ad,5);
			
			$git = "ortak";
			echo '<p>-- -- -- -- -- -- -- -- -- --</p>';
		}
		else if($sayfa_ad == "paylasımlarım"){
			echo '<p class="baslik">'.dil("Bir şeyler Paylaş").'</p>
				<form enctype="multipart/form-data" action="index.php?komut=paylasimlar&git=tekil" method="POST">

					<input type="hidden" name="MAX_FILE_SIZE" value="900000" />

					<p style="padding:5px;">
						'.dil("Hadi durma yaz:").'<br>
						<input type="text" name="yazi"><br />
						<b class="yazi">'.dil("---").'</b><br />
						'.dil("Bir resim paylaş:").'<br />
						<input name="res" type="file" /><br />
						'.dil("Resim için açıklama gir").'<br />
						<input type="text" name="aciklama"><br />
						<b class="yazi">'.dil("---").'</b><br />
						'.dil("Gizlilik Ayarları").'
						<input type="checkbox" name="gizlilik"><br />
					</p>
					<p style="padding:5px;"><input type="submit" value="'.dil("Paylaş!").'"></p>
				</form>';
				
			// Sorgu ile bütün paylaşılan öğeler alınıyor ve tür'üne göre tarih sıralamasında listeleniyor
			@$sorgu = mysql_query('SELECT id,gondrn_id,tur,icerik,tarih FROM paylasımlar WHERE gondrn_id='.$_SESSION["id"].' ORDER BY tarih DESC')or die(mysql_error());
			
			//echo 'SELECT id,gondrn_id,tur,icerik,tarih FROM paylasımlar WHERE gondrn_id='.$_SESSION["id"].' and ORDER BY tarih DESC';
			
			// Öncelikli olarak çıkan sonuç sayfalanıyor...
			// CAHİLLİK BAŞA BELA :D DÖNGÜ YARDIMIYLA SQL_TABLOSUNDAN BİR İD DİZİNİ ALIYORUM...
			
			$dizi = array();
			$son_dizi = array();
			
			while($listele = mysql_fetch_assoc($sorgu)){
				$dizi[] = $listele;
			}
			
			// Bu sayfalama methodu standartdır ve sistemin her yerinde bu standart uygulanacaktır
			sayfala($dizi,$sayfa_ad);
			
			$git = "tekil";
			echo '<p class="baslik">'.dil("Paylaşımlarım").'</p>';
		}
		
		// Daha Önce Paylaşılanlar Yazdırılıyor ...
		
		//new dbug($dizi);
		//new dbug($_SESSION);
		$son_dizi = sayfa_dizisi(@$_GET["sayfa"],$sayfa_ad);
		
		//new dbug($son_dizi);
		
		// Get fonksiyonundan alınan sayfa id'sinin sunucuda barındırdığı dizine göre listeleme yapılıyor...
		
		if ($son_dizi){
			if (count($son_dizi) > 0){
			
				echo '<table width="180" border="0">';
				
				foreach($son_dizi as $listele){
					$kim =  $listele['gondrn_id'];
					$tur =  $listele['tur'];
					$icerik = $listele['icerik'];
					$tarih = $listele['tarih'];
					$id = $listele['id'];
					
					$baslik = "";
					
					// Tarih aafarkına göre yaklaşık geçmiş tarih yazdırlıyor 
					
					//$tarih = dakika_farki($tarih);
					
					// echo "<br>-".$tarih."-<br>";
					
					$baslik = yaklasik_tarih($tarih);
					
					if ($tur == "yazı"){
						if ($icerik != ""){

							echo '
								<tr>
									<td rowspan="2" width=40>'.uye_foto(false,0,40,40).'</td>
									<td colspan="3" >'.uye_adı($kim).'</td>
								</tr>
								<tr>
									<td colspan="2" class="paylasim_ust">'.$baslik.'</td>
								</tr>
								<tr>
									<td colspan="3">'.$icerik.'</td>
								</tr>
								<tr class="paylasim_alt">
									<td><a href="index.php?komut=gonderiyi_paylas&id='.id_maskele($id,"paylasımpan").'">'.dil("Paylaş").'</a></td>
									<td><a href="index.php?komut=yorum&nsne_tur=gonderi_yorum&id='.id_maskele($id,"paylasımpan").'">'.dil("Yorum").'</a></td>
									<td><a href="index.php?komut=begen&id='.id_maskele($id,"paylasımpan").'">'.dil("Beğeni").'('.begeni_sayısı("paylaşım",$id).')</a></td>
								</tr>
								<tr>
									<td colspan="4" class="listetab"></td>
								</tr>';
						}
					}
					else if($tur == "foto"){

						if ($icerik != ""){

							// icerik içindeki bilgiler parçalanıp sınıflandırlıyor
							
							$baslik = uye_adı($kim).' Bir Fotoğraf Paylaştı';
							
							$veriler = scrpt_parcala($icerik);

							$yol = $veriler["s"]["adres"]; // array içindeki veriler veri pacala tarafından tablodan alına veriye göre oluşturulmuştur
							$etiket = $veriler["s"]["tanim"];

							//new dbug($veriler);

							echo '
								<tr>
									<td colspan="4" class="paylasim_ust">'.$baslik.'</td>
								</tr>
								<tr>
									<td rowspan="2" width=40><img src="'.$yol.'" height=40 width=40 /></td>
									<td colspan="3"><a href="foto.php">'.$etiket.'</a></td>
								</tr>
								<tr class="paylasim_alt">
									<td><a href="index.php?komut=gonderiyi_paylas&id='.id_maskele($id,"paylasımpan").'">'.dil("Paylaş").'</a></td>
									<td><a href="index.php?komut=yorum&nsne_tur=gonderi_yorum&id='.id_maskele($id,"paylasımpan").'">'.dil("Yorum").'</a></td>
									<td><a href="index.php?komut=begen&id='.id_maskele($id,"paylasımpan").'">'.dil("Beğeni").'('.begeni_sayısı("paylaşım",$id).')</a></td>
								</tr>
								<tr>
									<td colspan="4" class="listetab"></td>
								</tr>';
						}
					}
				}
				echo '</table>';
			}
			else{
				echo '<p class="yazi">'.dil("Görüntülenecek paylaşım bulunamadı").'</p>';
			}
		}
		else{
			echo '<p class="yazi">'.dil("Görüntülenecek paylaşım bulunamadı").'</p>';
		}
		
		
		echo '<p class="sayfa_gostergec">'.sayfa_no_gorntle(@$_GET["sayfa"],"index.php?komut=paylasimlar&git=".$git."&sayfa=",$sayfa_ad).'</p>';
	}

	function yorum_tab($ne_icin,$id){
		// Geliştirilebilirlik açısından diğer sayfalarda da kullanılabilecek 
		// Ortak bir table oluşturur
		
		// Yorum yaz formu + görüntüleme sistemi...
		
		// Yazma Formu
		
		mesaj_yaz_pan('<b>'.dil("Yorum Yaz").'</b><br />',false);
		
		// ilgili veri tabanı işlemlerinin yapılması...
		$sorgu = false;
		
		if ($ne_icin == "gonderi"){
			
			//echo 'SELECT yorum FROM paylasımlar WHERE id='.$id;
			@$sorgu = mysql_query('SELECT yorum FROM paylasımlar WHERE id='.$id)or die(mysql_error());
			
		}
		
		// Elde edilen scrpt parcalanıyor
		$dizin = scrpt_parcala(mysql_result($sorgu,0,'yorum'));
		
		// Parcalanan script icinden numerik indexli sahte tablolar teker teker taratılıp tabloya yerleştiriliyor 
		echo '<table border="0">';
		
		$tara = true;
		$i = 0;
		
		

		while($tara){
			if(isset($dizin[$i])){ // Böyle bir dizinin varlığı kontrol ediliyor
				
				$yazan = $dizin[$i]["yorum"]["u"]["id"];
				
				$yorum = $dizin[$i]["yorum"]["s"]["icerik"];
				
				// ** Filtreler ** //
				$yorum = mesaj_filtreleme($yorum);
				
				echo '<tr>
							<td id="ilk" width=15 rowspan="2">
								'.uye_foto(false,$yazan,"padding-left:5px;").'
							</td>
							<td>
								<b>'.uye_adı($yazan).'</b>
							</td>
					  </tr>
					  <tr>
							<td clospan="2" width="100%">'.$yorum.'</td>
					  </tr>
					  <tr>
							<td class="listeyazi" colspan="2"></td>
					  </tr>';
				
				$i++;
			}
			else{
				$tara = false;
			}
		}
		
		echo '</table>';
	}
	
	function profil_foto(){
		$dizi = array();
		
		echo '<p class="baslik">'.dil("Profil Fotoğrafınızı Değiştirin").'</p>
			<form enctype="multipart/form-data" method="POST" action="index.php?komut=profil&git=profil_foto_yukle">
			<p>'.dil("Dosya Seçin").'<br />
			<input type="file" name="dosya"><br />
			'.dil("Kayıtlı foğraflardan seç --->").'
			</p>';
		echo '</table>
			<p>
				<input type="submit" name="submit" value="Değiştir"><br />
			</p>
		';
		// Daha Önceden Yüklenmiş Fotoğraflar Bulunuyor // 
		// @$sorgu = mysql_query('SELECT id,gondrn_id,tur,icerik,tarih FROM paylasımlar WHERE gondrn_id='.$_SESSION["id"].' ORDER BY tarih DESC')or die(mysql_error());
		@$sorgu = mysql_query('SELECT id,icerik FROM paylasımlar WHERE gondrn_id='.$_SESSION["id"].' and tur="foto" ')or die(mysql_error());
		
		///echo 'SELECT id,icerik FROM paylasımlar WHERE gondrn_id='.$_SESSION["id"].' and tur="foto" ';
		
		// echo mysql_num_rows($sorgu);
		
		// bütün bi çıktı sessıona kaydedeliyor // sayfalama işlemi
		$i = 0;
		
		while ($icerik = mysql_fetch_array($sorgu)){
			
			$yol = $icerik["icerik"]; // array içindeki veriler veri pacala tarafından tablodan alına veriye göre oluşturulmuştur
			$yol = scrpt_parcala($yol);
			$yol = $yol["s"]["adres"];
			
			$i++;
			
			$dizi[$i] = array(); 
			$dizi[$i][] = $yol;
			$dizi[$i][] = $icerik["id"];
			
			//new dbug($dizi);
			// echo 'a ';
			
		}
		
		//new dbug($dizi);
		
		sayfala($dizi,"profil_foto",11);
		
		$son_dizi = sayfa_dizisi(@$_GET["sayfa"],"profil_foto");
		
		// Yazdırmaa
		
		$x = 1;
		$y = 1;
		

		echo '<table>';
		
		foreach($son_dizi as $yol){
			echo '<td><a href="index.php?komut=profil&git=profil_foto&isle='.id_maskele($yol[1],"profil_res").'"><img src="'.$yol[0].'" height="40" width="40"></a></td>';
			
			if ($x < 3){	
				$x++;
			}
			else {
				echo '</tr>';
				
				$y++;
				$x = 1;
				
				echo '<tr>';
			}
			
		}
		echo '</table>';

		
	}
	
	function ifadeler_pan(){ // Blok
		
		// Alfabetik Sıralamaya Göre Dizilim Uygulanacak...
		// Sayfalama Sistemide bu yönde işlenecek her sayfada yaklasık 3 * 5 adet ifade görüntülenecek
		
		// Hangi harf için liste yapılacağı öğreniliyor
		if (isset($_POST["harf"])){
			$harf = $_POST["harf"];
		}
		else{
			$harf = "k";
		}
		
		echo '<p class="baslik">'.dil("İFADELER").'</p>
				<form class="baslik"  method="POST">
					'.dil("Şuna Göre Listele:").'<br />
					<input type="text" name="harf"><br /><br />
					<input type="submit" value="'.dil("Listele").'">
				</form>';
		
		@$sorgu = mysql_query('SELECT * FROM ifadeler WHERE kısayol LIKE ".'.$harf.'%" ORDER BY kısayol ASC')or die(mysql_error());
		
		$dizi = array();
		
		while ($kıssa = mysql_fetch_array($sorgu)){
			
			$dizi[] = $kıssa;
			
		}
		
		sayfala($dizi,'ifadeler'.$harf,15);
		
		$dizi = sayfa_dizisi(@$_GET["sayfa"],'ifadeler'.$harf);
		
		// Yazdırmaa
		
		$x = 1;
		$y = 1;
		
		echo '<table>';
		
		foreach($dizi as $kayıt){
			// colspan hesaplama //
			$colspan = 1;
			
			if ($kayıt["genislik"] > 40){
				$colspan = 2;
				$x++;
			}
			else if($kayıt["genislik"] > 80){
				$colspan = 3;
				$x += 2;
			}
			
			echo '<td width="40" colspan="'.$colspan.'"><img src="'.$kayıt["adres"].'" height="'.$kayıt["yukseklik"].'" width="'.$kayıt["genislik"].'" ><br />'.$kayıt["kısayol"].'</td>';
			
			if ($x < 3){	
				$x++;
			}
			else {
				echo '</tr>';
				
				$y++;
				$x = 1;
				
				echo '<tr>';
			}
			
		}
		echo '</table>';
		
		echo sayfa_no_gorntle(@$_GET["sayfa"],"index.php?".$_SERVER['QUERY_STRING']."&sayfa=","ifadeler".$harf);
	}
?>




























