<?php 
		function kriptol1n($girdi,$tur = "html"){
		$donut = ""; // çýktý
		
		$alphNums = alphanum_array($tur);
		
		//alphanumyaz($alphNums);
		
		/* 
			Girdi'nin harfleri ile anahtarýn harfleri alt alta örtüþecek þekilde girdi harflerine parçalanýyor 
			Daha sonra her harfin'in id'isine anahtarda kendisne düþen harfin id'si eklenerek yeni id'olusturuluyor 
			ve bu id'ye ait olan harf çýktý'ya ekleniyor
		*/
		
		// Anahtar <maske> Oluþturuluyor
		
		// $girdi = mb_str_split($girdi);
		$girdi = mb_str_split($girdi);
		$anahtar = mb_str_split("KADÝFE");
		
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
		$donut = ""; // çýktý
		
		/* Kriptol1n fonksiyonunun tam tersi uygulanacaktýr < + iþareti yerine - iþareti kullanýlacaktýr*/
		
		$alphNums = alphanum_array($tur);
		
		$girdi = mb_str_split($girdi);
		$anahtar = mb_str_split("KADÝFE");
		
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
	
	function mb_str_split( $string ){ // Alýntýdýr php.net // mb_split kullanýmý
		# Split at all position not after the start: ^ 
		# and not before the end: $ 
		return preg_split('/(?<!^)(?!$)/u', $string ); 
	} 
	
	function alphanum_array($tur){
		if ($tur == "html"){
			$alphNums = "_.0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
		}
		else{
			$alphNums = "_.,:;!?%&()[]{}<>|$*-@#+\"'^/\\=0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyzÝý ÞþÐðÇçÜüÖö";
		}
		
		
		$donut = array();
		
		for ($i = 0;$i < mb_strlen($alphNums,'UTF-8');$i++){
			$donut[] = mb_substr($alphNums,$i,1,'UTF-8');
		}
		
		return $donut;
	}
?>