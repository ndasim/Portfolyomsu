<?php ob_start(); ?>

@charset "utf-8";
/* CSS Document */

img, a img{
	border:0;
}

<?php 
	header("Content-type: text/css"); // Başlıkk
	include("ortak.php");
	
	// Varsayılan Tema Öğrenilip İçerdiği Kurallar Sayfaya işleniyorr  
	$sorgu = mysql_query('SELECT * FROM sistem');
	$tema = mysql_result($sorgu,0,'deger');
	
	$sorgu = mysql_query('SELECT * FROM tema_veri WHERE tema_ad="'.$tema.'"');
	
	echo '.sınama{} ';
	
	while ($stil = mysql_fetch_array($sorgu)){
		// Bütün Stil Kurallarının Yazdırılması...
		
		if ($stil['tur'] == 'yok'){
			echo ' '.$stil['kural'].'{'.$stil['komut'].'}  '; 
		}
		elseif ($stil['tur'] == 'sınıf'){
			echo ' .'.$stil['kural'].'{'.$stil['komut'].'}  '; 
		}
		elseif ($stil['tur'] == 'ad'){
			echo ' #'.$stil['kural'].'{'.$stil['komut'].'}  '; 
		}
	}
	
?>
<?php ob_end_flush(); ?>