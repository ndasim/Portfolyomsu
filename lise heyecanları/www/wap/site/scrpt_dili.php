<?php 
	
	/*|u ad="bilgi"|5;|p|istek:|u ad="kim"|1:|s ad="tarih"|52215;|p|istek:|u ad="kim"|2:|s ad="tarih"|52215;|p|istek:|u ad="kim"|3:|s ad="tarih"|52215;|p|istek:|u ad="kim"|4:|s ad="tarih"|52215; */

	function scrpt_parcala($veri){
		//  Bu fonksiyon bir birine ';' işaretiyle birleştirilmiş veri türlerini ayırır
		
		/* Veri Türleri: 
			|s| : String türündeki değerler için kullanılır
			|p| : Bir birine ':' isaretiyle bağlanmıs ve bir alt dizin için kullanılır
			|u| : uyeid için kullanılır
		*/
		
		$liste = explode(";",$veri);
		//echo $veri."<br>";
		// Donut yapısının olusturulması
		$donut = array();
		$donut['s'] = array();
		$donut['u'] = array();
		
		$altdizn = array();
		
		$i = 0;
		
		foreach ($liste as $icerik){
			$etiket = substr($icerik,0,2);
			$veritür = substr($icerik,1,1);
			
			// Alt dizinleri ayrıca olusturma
			if ($etiket == '|p'){
			
				if (alt_dizin($icerik,"adı") == "s"){
					$donut["s"][] = alt_dizin($icerik,"kendisi");
				}
				else if (alt_dizin($icerik,"adı") == "u"){
					$donut["u"][] = alt_dizin($icerik,"kendisi");
				}
				else{
					$donut[] = alt_dizin($icerik,"kendisi");
					//echo alt_dizin($icerik,"adı");
				}
				
			}
			else{
				if ($icerik != ""){
					// get between ile etiketin adı okunuyor
					//echo "!!!!!!!!!!!!".$icerik."!!!!!!!!!!----<br>"; 
					$etiketid = arada_kalanlar($icerik,$etiket.' ad="','"|');
					
					// Eğer adın tanımlanmışsa bu dizine anahtar kelime olarak beraberiyle eklenir
					if ($etiketid != ""){ 
						$donut[$veritür][$etiketid] =str_replace($etiket.' ad="'.$etiketid.'"|',"",$icerik);  // dizine arındırarak girme
						//echo "<br>eklendih <br>"; 
					}
					else { // etiketin adı yoksa sadece sıradalı anahtar ile giriliyor
						$donut[$veritür][$i] = str_replace($etiket."|","",$icerik); 
						//echo "<br>eklendi<br>"; 
					}
					
					//$donut[] = $icerik;
					//echo $icerik;
				}
			}
			$i++;
		}
		
		////new dbug($donut);
		
		return $donut;
		
	}
	
	function scrpt_birlestir($giris){ //DİİKKAAATT SİLME KOMUTLARI TEST EDİLMEDİ
		$donut = "";
		//* Bu fonksiyonla işlenmiş script dizinleri kaydedilmek üzere string'e dönüştürülürler *//
		
		/* Prensip: scrpt sadece bu sisteme özgü bir script dili olduğu için belli kurallar çerçevesinde birleştirilecektir
			dil yapısı: ilk tanımlar u ve s yapılarıdır ki bunlar array olarak adlarına göre yazılırlar
			daha sonra dizindeki adsız yani anahtarsız olarak başlayan alt dizinler sahte tablo diye tabir edilen
			alt ad alanlarıdır bunlarda kendi içlerinde u ve s yapılarını taşırlar.
		*/
		
		if (is_array($giris)){
			// Başlangıç: u ve s yapıları scripte dökülür
			// u'ları yazdırma
			for ($i=0;$i<count($giris["u"]);$i++){
				
				// birden fazla kayıt olacağından hepsinin adın öğrenip teker teker işlem.
				$tst = array_keys($giris["u"]);
				
				$ad = $tst[$i];
				if (!isset($giris["u"][$ad]["sil"])){ // Bu gönderilen verinin silinmesi anlamına gelir yani bu veri dikkate alınmaz
					if (!is_array($giris["u"][$ad])){ // Array olma olasılığı bulunmaktadır
						$icerik = $giris["u"][$ad];
						$donut .= '|u ad="'.$ad.'"|'.$icerik.';';
					}
					else{
						for ($i=0;$i<count($giris["u"]);$i++){
							if (isset($giris["u"][$i])){ // Temel alanların altındaki alt alanlar sorgulanıyor
								if (!isset($giris["u"][$i]["sil"])){ 
									$tabdizn = $giris["u"][$i];
									
									// Aynı işlemler bir alt dizn içinde geçerlidir;
									// Tek fark başlarında bir alan adı oluşudur 
									// ve ; ile deil : ile bitmeleridir
									
									////new dbug($giris["u"]);
									
									$tst = array_keys($giris["u"][$i]);
									$tabad = $tst[0];
									
									//echo $tst[0];
									
									$donut .= '|p ad="'.$tabad.'" tur="u"|:';
									
									//echo $tabad;
									
									//u'ları yazdırma
									if (isset($tabdizn[$tabad]["u"])){
										for ($ii=0;$ii<count($tabdizn[$tabad]["u"]);$ii++){
											// birden fazla kayıt olacağından hepsinin adın öğrenip teker teker işlem.
											$tst = array_keys($tabdizn[$tabad]["u"]);
											
											$ad = $tst[$ii];
											$icerik = $tabdizn[$tabad]["u"][$ad];
											
											$donut .= '|u ad="'.$ad.'"|'.$icerik.':';
										}
									}
									
									// s'leri yazdırma
									if (isset($tabdizn[$tabad]["s"])){
										for ($ii=0;$ii<count($tabdizn[$tabad]["s"]);$ii++){
											
											$tst = array_keys($tabdizn[$tabad]["s"]);
											
											$ad = $tst[$ii];
											$icerik = $tabdizn[$tabad]["s"][$ad];
											
											$donut .= '|s ad="'.$ad.'"|'.$icerik.':';
										}
									}
									
									$donut .= ";";
								}
								else{
									echo "=====------sil-------=====";
								}
							}
						}
					}
				}
				
			}
			// s'leri yazdırma
			for ($i=0;$i<count($giris["s"]);$i++){
				
				// birden fazla kayıt olacağından hepsinin adın öğrenip teker teker işlem.
				$tst = array_keys($giris["s"]);
				
				$ad = $tst[$i];
				if (!isset($giris["s"][$ad]["sil"])){ // Bu gönderilen verinin silinmesi anlamına gelir yani bu veri dikkate alınmaz
					if (!is_array($giris["s"][$ad])){ // Array olma olasılığı bulunmaktadır
						$icerik = $giris["s"][$ad];
						$donut .= '|s ad="'.$ad.'"|'.$icerik.';';
					}
					else{
						for ($i=0;$i<count($giris["s"]);$i++){
							if (isset($giris["s"][$i])){
								//echo $i."aa";
								if (!isset($giris["s"][$i]["sil"])){ 
									$tabdizn = $giris["s"][$i];
									
									// Aynı işlemler bir alt dizn içinde geçerlidir;
									// Tek fark başlarında bir alan adı oluşudur 
									// ve ; ile deil : ile bitmeleridir
									
									////new dbug($giris["s"]);
									
									$tst = array_keys($giris["s"][$i]);
									$tabad = $tst[0];
									
									//echo $tst[0];
									
									$donut .= '|p ad="'.$tabad.'" tur="s"|:';
									
									//echo $tabad;
									
									//u'ları yazdırma
									if (isset($tabdizn[$tabad]["u"])){
										for ($ii=0;$ii<count($tabdizn[$tabad]["u"]);$ii++){
											// birden fazla kayıt olacağından hepsinin adın öğrenip teker teker işlem.
											$tst = array_keys($tabdizn[$tabad]["u"]);
											
											$ad = $tst[$ii];
											$icerik = $tabdizn[$tabad]["u"][$ad];
											
											$donut .= '|u ad="'.$ad.'"|'.$icerik.':';
										}
									}
									// s'leri yazdırma
									if (isset($tabdizn[$tabad]["s"])){
										for ($ii=0;$ii<count($tabdizn[$tabad]["s"]);$ii++){
											
											$tst = array_keys($tabdizn[$tabad]["s"]);
											
											$ad = $tst[$ii];
											$icerik = $tabdizn[$tabad]["s"][$ad];
											
											$donut .= '|s ad="'.$ad.'"|'.$icerik.':';
										}
									}
									$donut .= ";";
									//echo $donut;
								}
								else{
									echo "=====------sil-------=====";
								}
							}
						}
					}
				}
				
			}
			
			// Dewam: İndexleri otomatik sayı olan sahte tabloları alıyoruz
			
			//echo count($giris);
			
			for ($i=0;$i<count($giris);$i++){
				if (isset($giris[$i])){
					if (!isset($giris[$i]["sil"])){ // Bu gönderilen verinin silinmesi anlamına gelir yani bu veri dikkate alınmaz
						$tabdizn = $giris[$i];
						
						// Aynı işlemler bir alt dizn içinde geçerlidir;
						// Tek fark başlarında bir alan adı oluşudur 
						// ve ; ile deil : ile bitmeleridir
						
						////new dbug($giris);
						
						$tst = array_keys($giris[$i]);
						$tabad = $tst[0];
						
						//echo $tst[0];
						
						$donut .= '|p ad="'.$tabad.'" |:';
						
						//echo $tabad;
						
						//u'ları yazdırma
						if (isset($tabdizn[$tabad]["u"])){
							for ($ii=0;$ii<count($tabdizn[$tabad]["u"]);$ii++){
								// birden fazla kayıt olacağından hepsinin adın öğrenip teker teker işlem.
								$tst = array_keys($tabdizn[$tabad]["u"]);
								
								$ad = $tst[$ii];
								$icerik = $tabdizn[$tabad]["u"][$ad];
								
								$donut .= '|u ad="'.$ad.'"|'.$icerik.':';
							}
						}
						// s'leri yazdırma
						if (isset($tabdizn[$tabad]["s"])){
							for ($ii=0;$ii<count($tabdizn[$tabad]["s"]);$ii++){
								
								$tst = array_keys($tabdizn[$tabad]["s"]);
								
								$ad = $tst[$ii];
								$icerik = $tabdizn[$tabad]["s"][$ad];
								
								$donut .= '|s ad="'.$ad.'"|'.$icerik.':';
							}
						}
						
						$donut .= ";";
					}
					else{
						echo "=====------sil-------=====";
					}
				}
			}
		}
		//echo $donut;
		return $donut;
	}
	
	function arada_kalanlar($giris,$ilk_krkter,$son_krkter){ // Farklı bir kaynaktan alınmıştır // Düzenleme yapılmıştır
		//echo 'giriş ='.$giris.'___'.$ilk_krkter.'___'.$son_krkter.' <br>';
		//$onbellek = $input;
		//$substr = substr($input, strlen($start)+strpos($input, $start), (strlen($input) - strpos($input, $end))*(-1)); 
		$devam = true;
		
		$ilk_nok = strpos($giris, $ilk_krkter) + strlen($ilk_krkter);
		$son_nok = strpos($giris, $son_krkter);
		
		$ilk_krkter_gnslk = strlen($ilk_krkter);
		$sn_krkter_gnslk = strlen($son_krkter);
		
		$donut = mb_substr($giris,$ilk_nok,$son_nok - $ilk_nok,'UTF-8');
		
		//echo "___ilk konum=".strpos($giris, $ilk_krkter).'___ilkgenişlik='.strlen($ilk_krkter)."___son konum=".strpos($giris, $son_krkter).'___son_genişlik'.strlen($son_krkter)."___".$donut."___<br>";
		
		/*
		while ($i < 5){
			// Belirtilen karektere kadar sayma işlemi sağlanacak ve çıktı alınacaktır
			
			$krkter = mb_substr($giris,$ilknok+$i+strlen($ilk_krkter),strlen($son_krkter),'UTF-8');
			
			//echo '('.$giris.','.$ilknok+$i+strlen($ilk_krkter).','.strlen($son_krkter).')<br />';
			$basnok = $ilknok + $i;
			
			
			if ($krkter == $son_krkter){
				$devam = false; 
				$donut = substr($giris,$basnok,$i);
			}
			else{
				
			}
		
			$i++;
		}
		*/
		
		//if ($substr == ""){$substr = $onbellek;}
		
		//echo 'cıkıs '.$donut.' <br>';
		return $donut; 
	}
	
	function alt_dizin($girdi,$tür){
		// Yeni olsuturulacak alt dizn parcalanıyor
		
		$donut = false;
		$liste = explode(":",$girdi);
		//echo $icerik." ";
			
		if ($tür == "kendisi"){
			$donut = array();
			
			// olusan listenin ilk değeri
			if (count($liste) > 0){
				// Çıkan listenin değeri her zaman alt_dizin adıdır... 
				//$altd_ad = str_replace("|p|","",$liste[0]); // alt dizin adı |p| etiketinden arındırılıyor
				
				$altd_ad = arada_kalanlar($liste[0],'|p ad="','" ');
				
				//echo "ad :".$altd_ad;
				
				$dizi = array();
				$donut = array();
				
				$i=0;
				
				foreach ($liste as $icerik){
					$i++;
					if ($icerik != ""){
						if (substr($icerik,0,2) != "|p"){ // etiketin p olmamasına dikkat ediliyor
							
							$etiket = substr($icerik,0,2); // Seçme işlemlerinde kullanılacak
							$veritür = substr($icerik,1,1);
							
							$etiketid = arada_kalanlar($icerik,$etiket.' ad="','"|'); // etiketin adı öğreniliyor
							//echo "<br>ad: $etiketid <br>";
							$donut[$altd_ad][$veritür][$etiketid] = str_replace($etiket.' ad="'.$etiketid.'"|',"",$icerik); // gerekli temizlik yapıldıktan sonra girme yapılıyor
							
							/*echo "<br><br>".$icerik."<br>";
							echo "<br>".$altd_ad." / ".$veritür." / ".$etiketid." = ".str_replace($etiket.' ad="'.$etiketid.'"|',"",$icerik);
							
							echo '<br>test = $donut['.$altd_ad.']['.$veritür.']['.$etiketid.'].<br>';
							*/
							
							//$donut[$i][$altd_ad][] = $icerik;
						}
					}
				}
			}
		}
		else if($tür == "adı"){
			// Çıkan listenin değeri her zaman alt_dizin adıdır...
			//$donut = str_replace("|p|","",$liste[0]); // alt dizin adı |p| etiketinden arındırılıyor
			$altd_ad = arada_kalanlar($liste[0],'|p ad="','" ');
			//echo "===__===".$altd_ad."===__===";
			$donut = arada_kalanlar($liste[0],'|p ad="'.$altd_ad.'" tur="','"|');
			//echo $altd_ad; 
		}
		
		////new dbug($dizi);
		
		return $donut;
	}
	
	function scrpt_güncelle($giris,$diznid,$deger){
		
	}
	
	function scrpt_sil($giris,$index,$anatur = ""){
		// Veri öncelikle parçalanır;
		$dizi = scrpt_parcala($giris);
		
		// İlgili dizi bulunur ve silinir;
		if ($anatur == ""){
			// Sahte tablo silme işlemi
			$dizi[$index]["sil"] = true;
			echo "asasa";
		}
		else{
			// !! dikkat veri id kesinlikle alan adı olmalıdrı çünkü ana turden silme yapılacaktır
			$dizi[$anatur][$verid]["sil"] = true;
		}
		
	
		$scrpt_sonuc = scrpt_birlestir($dizi);
		
		return $scrpt_sonuc;
	}
	
	function scrpt_ekle($giris,$veritür,$ad,$veri){
		$donut = $giris;
		
		if ($veritür != ""){
			if ($veri != ""){
				if ($ad != ""){
					$donut .= "|".$veritur." ad=".$ad."|".$veri.";";
				}
				else{
					$donut .= "|".$veritur."|".$veri.";";
				}
			}
		}
		
		return $donut;
	}
	
	function scrpt_tab_basla($tabad){
		$donut = false;
		
		if (!isset($_SESSION["scrpt_tab_".$tabad])){
			$_SESSION["scrpt_tab_".$tabad] = true;
			$_SESSION["scrpt_tab_".$tabad."_veri"] = array();
			
			$donut = true;
		}
		
		return $donut;

	}
	
	function scrpt_tab_ekle($tabad,$veritür,$ad,$veri){
		$donut = "";
		
		if ($veritür != ""){
			if ($veri != ""){
				if ($ad != ""){
					$donut .= "|".$veritur." ad=".$ad."|".$veri.":";
				}
				else{
					$donut .= "|".$veritur."|".$veri.":";
				}
			}
		}
		
		$_SESSION["scrpt_tab_".$tabad."_veri"][] = $donut;
	}
	
	function scrpt_tab_bitir($giris,$tabad){
		$donut = $giris;
		
		$donut .= "|p|".$tabad.":";
		
		foreach ($_SESSION["scrpt_tab_".$tabad."_veri"] as $veri){
			$donut .= "|p|".$veri;
		}
		
		//unset($_SESSION("scrpt_tab_".$tabad));
		//unset($_SESSION("scrpt_tab_".$tabad."_veri");
		
		return $donut;
	}

	function scrpt_sub($giris,$index){
		// Dizinin içinden kesit alır
		
		$donut = false;
		$dizin = scrpt_parcala($giris);
		
		if (isset($dizin[$index])){
			$donut = $dizin[$index];
		}
		return $donut;
	}
	
	function scrptcan_parcala($veri){ // Scrpt dilinin en düşük versiyonudur...
		// Bu versiyon sadece ";" arasındaki değerleri array içine aktarır
		
		$donut = array();
		
		$donut = explode(";",$veri);
		
		// echo "---- Giriş parçalama için : ".$veri."----";
		
		return $donut;
	}
	
	function scrptcan_birlestir($giris){
		$donut = "";
		
		foreach ($giris as $deger){
			$donut .= $deger.";";
		}
		
		// echo "---- Çıkış parçalama için : ".$donut."----";
		
		return $donut;
	}
?>










