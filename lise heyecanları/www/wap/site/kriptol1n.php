<?php 
		function kriptol1n($girdi,$tur = "html"){
		$donut = ""; // ��kt�
		
		$alphNums = alphanum_array($tur);
		
		//alphanumyaz($alphNums);
		
		/* 
			Girdi'nin harfleri ile anahtar�n harfleri alt alta �rt��ecek �ekilde girdi harflerine par�alan�yor 
			Daha sonra her harfin'in id'isine anahtarda kendisne d��en harfin id'si eklenerek yeni id'olusturuluyor 
			ve bu id'ye ait olan harf ��kt�'ya ekleniyor
		*/
		
		// Anahtar <maske> Olu�turuluyor
		
		// $girdi = mb_str_split($girdi);
		$girdi = mb_str_split($girdi);
		$anahtar = mb_str_split("KAD�FE");
		
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
			echo ' // ** D�ng�'.$i.' ** // <br /> 
				* Girdi Harf = '.$girdi[$i].' : '.$id1.'<br />
				* Maske Harf = '.$maske[$i].' : '.$id2.'<br />
				* Sonu� Harf = '.$harf.': '.$id.' <br /><br />';
			*/	
		}
		//echo ' D�n�t:'.$donut;
		
		return $donut;
	}
	
	function kriptol1n_coz($girdi,$tur = "html"){
		$donut = ""; // ��kt�
		
		/* Kriptol1n fonksiyonunun tam tersi uygulanacakt�r < + i�areti yerine - i�areti kullan�lacakt�r*/
		
		$alphNums = alphanum_array($tur);
		
		$girdi = mb_str_split($girdi);
		$anahtar = mb_str_split("KAD�FE");
		
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
			echo ' // ** D�ng�'.$i.' ** // <br /> 
				* Girdi Harf = '.$girdi[$i].' : '.$id1.'<br />
				* Maske Harf = '.$maske[$i].' : '.$id2.'<br />
				* Sonu� Harf = '.$harf.': '.$id.' <br /><br />';
			*/	
		}
		//echo ' D�n�t:'.$donut;
		return $donut;
	}
	
	function mb_str_split( $string ){ // Al�nt�d�r php.net // mb_split kullan�m�
		# Split at all position not after the start: ^ 
		# and not before the end: $ 
		return preg_split('/(?<!^)(?!$)/u', $string ); 
	} 
	
	function alphanum_array($tur){
		if ($tur == "html"){
			$alphNums = "_.0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
		}
		else{
			$alphNums = "_.,:;!?%&()[]{}<>|$*-@#+\"'^/\\=0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz�� ����������";
		}
		
		
		$donut = array();
		
		for ($i = 0;$i < mb_strlen($alphNums,'UTF-8');$i++){
			$donut[] = mb_substr($alphNums,$i,1,'UTF-8');
		}
		
		return $donut;
	}
?>