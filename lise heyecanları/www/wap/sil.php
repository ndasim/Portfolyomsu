<?php 
	
	include "ortak.php";
	
	isle("anasyfa");
	isle("profil");
	isle("posta");
	isle("yeniposta");
	isle("arkadas");
	isle("arkadass");
	isle("sohbet");
	isle("acıkolan");
	isle("uygulama");
	isle("oyun");
	isle("mp3");
	isle("ayarlar");
	isle("cıkıs");
	
	function isle($deger){ //sil
		
		if (isset($_GET[$deger])){
			if ($_GET[$deger]){
				$url = kaynak_al($deger,true);
				unlink($url);
			
				@mysql_query('UPDATE tema_kaynak SET adres="tema/tema1/bos.gif",tema="1" WHERE ad="'.$deger.'"') or die(mysql_error());
				
				echo $deger." Başarı ile silindi.";
			
			}
		}

	}
	
?>