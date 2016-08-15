<?php
	include "veritabani.php";

	baglan();
	
	if (isset($_GET["k_x"])){
		
		mysql_query('UPDATE deneme SET x='.$_GET["k_x"].',y='.$_GET["k_y"].' WHERE 1');
		echo "baþarýlý";
		
	}
	
	if (isset($_GET["getir"])){
		
		$sorgu = mysql_query("SELECT * FROM deneme WHERE 1") or die(mysql_error());
		
		$x = mysql_result($sorgu,0,"x");
		$y = mysql_result($sorgu,0,"y");
		
		echo "k_x=".tamamla($x).";k_y=".tamamla($y)."    ";
	}
	
	function tamamla($sayý,$kac=3){
		
		$uzunluk = strlen($sayý);
		$dönüt = $sayý;
		
		while ($uzunluk < $kac){
			$dönüt .= "_";
			$uzunluk++;
		} 
		
		return $dönüt;
	}
?>