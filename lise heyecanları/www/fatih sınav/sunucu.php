<?php 
	// echo "tamam ülenn";
	
	// Ön tanımlı değerlerin kurulması
	include "dbug.php";
	
	$cevaplar = array(3,1,3,1,2,1,2,2,1,1);
	
	// Gelen Post verileri kontrol ediliyor...
	if (isset($_POST["cevap"])){
		
		$veri = $_POST["cevap"];
		 
		// gelen post verisi aralardaki ";" işaretlerinden parçalanıyor ve düzgün sıralı bir dizi elde ediliyor
		$dizi = explode(";",$veri);
		
		// parçalanmış olan cevap şıkları doğru veya yanlış olarak başka bir dizinin içine kaydediliyorlar
		new dbug($veri);
		new dbug($dizi);
		
		for ($i = 1;$i<= 10;$i++){
			
			// 1: doğru 0:yanlış anlamına gelmektedir
			$donut_dizi = array();
			
			if ($dizi[$i] == $cevaplar[$i - 1]){
				$donut_dizi[] = 1;
			} 
			else{
				$donut_dizi[] = 0;
			}
		}
		
		// Geri yanıt verme işlemi tıpki verilerin geldiği zamanki gibi veriler arasında ";" işareti olacak şekilde dizilip yazdırılıyor
		$donut = "";
		
		foreach ($donut_dizi as $deger){
			$donut .= $deger; 
		}
		
		echo $donut; // ve çıktı ifademiz yazdırılarak dönüt sağlanıyor
	}
?>