<?php
	
	$guvenlik = true; // bu satırın tek amacı birden fazlka sayfada include edilmeyi önlemektir
	
	function girdileri_sorgula($islem){
		/* Amaç gelen verilerin gerekli islem kriterlerine uygun olup olmadığını sorgulamaktı */
		
		
		$donut = true;
		
		if ($islem == 'kayıt'){
		
			if ($_POST['kayıt_kullanıcı'] != ""){
				// kosullar ***
			}
			else{
				echo '<p style="color:#CC6600;">Kullanıcı adınızı doldurunuz</p>';
				$donut = false;
			}
			
			if ($_POST['sifre'] != ""){
				// kosullar ***
			}
			else{
				echo '<p style="color:#CC6600;">Lütfen şifre alanını boş bırakmayınız</p>';
				$donut = false;
			}
			
			if ($_POST['ad'] != ""){
				// kosullar ***
			}
			else{
				echo '<p style="color:#CC6600;">Lütfen ad alanını boş bırakmayınız</p>';
				$donut = false;
			}
			
			if ($_POST['soyad'] != ""){
				// kosullar ***
			}
			else{
				echo '<p style="color:#CC6600;">Lütfen soyad alanını boş bırakmayınız</p>';
				$donut = false;
			}
			
			if ($_POST['eposta'] != ""){
				// kosullar ***
			}
			else{
				echo '<p style="color:#CC6600;">Lütfen eposta alanını boş bırakmayınız</p>';
				$donut = false;
			}
			
			if (isset($_POST['kabul'])){
				// kosullar ***
			}
			else{
				echo '<p style="color:#CC6600;">Lütfen kabul ediniz</p>';
				$donut = false;
			}
		
			kayıt_pan(); // Eklemeler olacak !! DİKKAT !!
			
			return $donut;
		}
	
		if ($islem == 'giris'){
		
			if ($_POST['kullanıcı'] != ""){
				// kosullar ***
			}
			else{
				echo '<p style="color:#CC6600;">Lütfen kullanıcı adınızı boş bırakmayınız</p>';
				$donut = false;
			}
			
			if ($_POST['sifre'] != ""){
				// kosullar ***
			}
			else{
				echo '<p style="color:#CC6600;">Lütfen sifre alanını boş bırakmayınız</p>';
				$donut = false;
			}
			
			giris_pan();
			
			return $donut;
		}
	}

	function arındır($girdi){
		
		//// htmlspecialchars() TESTT EDİLECEK // ÖRNek KULLANIM: phpmyadmin klasörü içinde viev_create.php:150 //// 
		
		$degiscek = array("<?","?>","<script","</script","</p>","</b>");
		
		$cıktı = str_replace($degiscek,"",$girdi); // Düşük seviyeli ayıklama
		
		//$cıktı = strip_tags($cıktı); // Yüksek seviyeli ayıklama
		
		return $cıktı;
	}
	
	function karekter_test($girdi){
		$donut;
		$knum;
		
		$arananlar = array("?","<",">",",");
		
		foreach($needles as $needle) {
			//$found[$needle] = stripos($haystack, $needle, $offset);
		}
	}
	
	/// maskelme sistemi değişcekkk //
	
	function id_maskele($id,$nereden = ""){ // Bu fonksiyon ile link olarak script içinde giden veri id'lerini rastgele şifreler ve kaydeder..
		// !!! nereden değişkeni ile bir sayfaya her girildiğinde yeni maske üretimini ortadan kaldırır sistemde kararlılık sağlar... !!! 
		
		// Prensib: gelen id rastgele şifrelenir sessıon içine [maske]=id şeklinde çözülmek üzere kaydedilir
		$dene = true;		
		
		@$maske = $_SESSION["güvenlik"][$nereden."_".$id];
			
		//new dbug($_SESSION["güvenlik"]);
		
		if (!isset($_SESSION["güvenlik"][$nereden."_".$id])){	
			while ($dene){
				if (!isset($_SESSION["güvenlik"][$maske])){ // Olması biraz zor ama üstüste aynı iki değerin binmemesi açısından önemli....
					$maske = randomAlphaNum(10);
					$_SESSION["güvenlik"][$maske] = $id;
					$_SESSION["güvenlik"][$nereden."_".$id] = $maske;
					
					$dene = false;
				}
			}
		}
		
		//echo "a:".$maske;
		return $maske;
	}
	
	function randomAlphaNum($length){ // Alıntıdır Görevi Rastgele Alpha-nümerik değer üretmektir...
		$alphNums = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";       
		$newString = str_shuffle(str_repeat($alphNums, rand(1, $length)));
		
		return substr($newString, rand(0,strlen($newString)-$length), $length);
	}
	
	function maske_coz($maske){ // Oturuma kaydedilmiş veriyi çeker
		$donut = false;
		
		if (isset($_SESSION["güvenlik"][$maske])){
			$donut = $_SESSION["güvenlik"][$maske];
		}
		
		return $donut;
	}
	
	// ** // ** // ** // ** // ** // ** //
	
	function alphanumyaz($dizi){
		//new dbug($dizi);
	}
	
	function alphanum_array($tur){
		if ($tur == "html"){
			$alphNums = "_.0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
		}
		else{
			$alphNums = "_.,:;!?%&()[]{}<>|$*-@#+\"'^/\\=0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyzİı ŞşĞğÇçÜüÖö";
		}
		
		
		$donut = array();
		
		for ($i = 0;$i < mb_strlen($alphNums,'UTF-8');$i++){
			$donut[] = mb_substr($alphNums,$i,1,'UTF-8');
		}
		
		return $donut;
	}
	
	function parcala($girdi){
		$donut = array();
		
		$turkce_krktr = 0;
		$turkce_krktr_alt = 0;
		
		echo 
		
		// PHP HATASINI GİDERMEK İÇİN TÜRKÇE KAREKTERLERİN SAYIMI...
		
		// toplam ı sayısı;
		preg_match_all("@ı@", $girdi , count($turkce_krktr_alt));
		
		$turkce_krktr += count(count($turkce_krktr_alt));
		
		// toplam İ sayısı;
		preg_match_all("@İ@", $girdi , count($turkce_krktr_alt));
		$turkce_krktr += count($turkce_krktr_alt);
		
		// toplam Ş sayısı;
		preg_match_all("@Ş@", $girdi , count($turkce_krktr_alt));
		$turkce_krktr += count($turkce_krktr_alt);
		
		// toplam Ğ sayısı;
		preg_match_all("@Ğ@", $girdi , count($turkce_krktr_alt));
		$turkce_krktr += count($turkce_krktr_alt);
		
		// toplam Ü sayısı;
		preg_match_all("@Ü@", $girdi , count($turkce_krktr_alt));
		$turkce_krktr += count($turkce_krktr_alt);
		
		// toplam Ç sayısı;
		preg_match_all("@Ç@", $girdi , count($turkce_krktr_alt));
		$turkce_krktr += count($turkce_krktr_alt);
		
		// toplam ş sayısı;
		preg_match_all("@ş@", $girdi , count($turkce_krktr_alt));
		$turkce_krktr += count($turkce_krktr_alt);
		
		// toplam ğ sayısı;
		preg_match_all("@ğ@", $girdi , count($turkce_krktr_alt));
		$turkce_krktr += count($turkce_krktr_alt);
		
		// toplam ü sayısı;
		preg_match_all("@ü@", $girdi , count($turkce_krktr_alt));
		$turkce_krktr += count($turkce_krktr_alt);
		
		echo strlen($girdi).'-'.$turkce_krktr.' ';
		
		for ($i = 0;$i < strlen($girdi) - $turkce_krktr;$i++){
			$donut[] = mb_substr($girdi,$i,1,'UTF-8');
		}
		
		//$donut = explode($girdi,"");
		
		return $donut;
	}
	
	function mb_str_split( $string ){ // Alıntıdır php.net // mb_split kullanımı
		# Split at all position not after the start: ^ 
		# and not before the end: $ 
		return preg_split('/(?<!^)(?!$)/u', $string ); 
	} 
	
	function kriptol1n($girdi,$tur = "html"){
		$donut = ""; // çıktı
		
		$alphNums = alphanum_array($tur);
		
		alphanumyaz($alphNums);
		
		/* 
			Girdi'nin harfleri ile anahtarın harfleri alt alta örtüşecek şekilde girdi harflerine parçalanıyor 
			Daha sonra her harfin'in id'isine anahtarda kendisne düşen harfin id'si eklenerek yeni id'olusturuluyor 
			ve bu id'ye ait olan harf çıktı'ya ekleniyor
		*/
		
		// Anahtar <maske> Oluşturuluyor
		
		// $girdi = mb_str_split($girdi);
		$girdi = mb_str_split($girdi);
		$anahtar = mb_str_split("KADİFE");
		
		//new dbug($alphNums);
		//new dbug($girdi);
		//new dbug($anahtar);
		
		$maskele = true;
		$kalan = 0;
		
		$maske = "";
		
		$k = 0;
		
		for ($i = 0;$i < count($girdi);$i++){
			$maske[] = $anahtar[$k];
			
			if ($k < count($anahtar) - 1){
				$k++;
			}
			else{
				$k = 0;
			}
		}
		
		//echo 'Girdi:'.count($girdi).' Maske: '.count($maske);
		
		// array_search("??",array)
		
		for ($i = 0;$i < count($maske);$i++){
			
			$id1 = array_search($girdi[$i],$alphNums);
			$id2 = array_search($maske[$i],$alphNums);
			
			/*
				$id1 = strpos($alphNums,mb_substr($girdi,$i,1,'UTF-8'));
				$id2 = strpos($alphNums,mb_substr($maske,$i,1,'UTF-8'));
			*/
			
			$id = $id1 + $id2;
			
			if ($id > count($alphNums) - 1){
				$id -= count($alphNums);
			}
			
			if ($id > count($alphNums) - 1){
				$id -= count($alphNums);
			}
			
			$harf = $alphNums[$id];
			
			// $harf = mb_substr($alphNums,$id,1,'UTF-8');
			
			$donut .= $harf;
			/*
			echo ' // ** Döngü'.$i.' ** // <br /> 
				* Girdi Harf = '.$girdi[$i].' : '.$id1.'<br />
				* Maske Harf = '.$maske[$i].' : '.$id2.'<br />
				* Sonuç Harf = '.$harf.': '.$id.' <br /><br />';
			*/	
		}
		//echo ' Dönüt:'.$donut;
		
		return $donut;
	}
	
	function kriptol1n_coz($girdi,$tur = "html"){
		$donut = ""; // çıktı
		
		/* Kriptol1n fonksiyonunun tam tersi uygulanacaktır < + işareti yerine - işareti kullanılacaktır*/
		
		$alphNums = alphanum_array($tur);
		
		$girdi = mb_str_split($girdi);
		$anahtar = mb_str_split("KADİFE");
		
		//new dbug($girdi);
		//new dbug($anahtar);
		
		$maskele = true;
		$kalan = 0;
		
		$maske = "";
		
		$k = 0;
		
		for ($i = 0;$i < count($girdi);$i++){
			$maske[] = $anahtar[$k];
			
			if ($k < count($anahtar) - 1){
				$k++;
			}
			else{
				$k = 0;
			}
		}
		
		//echo 'Girdi:'.count($girdi).' Maske: '.count($maske);
		
		// array_search("??",array)
		
		for ($i = 0;$i < count($maske);$i++){
			
			$id1 = array_search($girdi[$i],$alphNums);
			$id2 = array_search($maske[$i],$alphNums);
			
			/*
				$id1 = strpos($alphNums,mb_substr($girdi,$i,1,'UTF-8'));
				$id2 = strpos($alphNums,mb_substr($maske,$i,1,'UTF-8'));
			*/
			
			$id = $id1 - $id2;
			
			if ($id < 0){
				$id = count($alphNums) + $id ;
			}
			
			if ($id < 0){
				$id = count($alphNums) + $id ;
			}
			
			$harf = $alphNums[$id];
			// $harf = mb_substr($alphNums,$id,1,'UTF-8');
			
			$donut .= $harf;
			/*
			echo ' // ** Döngü'.$i.' ** // <br /> 
				* Girdi Harf = '.$girdi[$i].' : '.$id1.'<br />
				* Maske Harf = '.$maske[$i].' : '.$id2.'<br />
				* Sonuç Harf = '.$harf.': '.$id.' <br /><br />';
			*/	
		}
		//echo ' Dönüt:'.$donut;
		return $donut;
	}
		
	
	// ** // ** // ** // ** // ** // ** //
?>