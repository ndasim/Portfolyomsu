<?php
	
	function baglan(){
		/* mysql e bağlanma islemi */
		$baglanti = @mysql_connect("localhost", "root", "")or die ("Veritabanina bağlanirken bir hata olustu!");
		
		/* mysql de kendi veritabanimizi secim islemi */
		@mysql_select_db("savasmanya",$baglanti)or die("Veritaninda bir hata olustu!");
		mysql_query("SET NAMES 'utf8' COLLATE 'utf8_turkish_ci'");
		mysql_query("SET CHARACTER SET utf8");
		mysql_query("SET COLLATION_CONNECTION = 'utf8_turkish_ci'");
		
		//return $baglanti;
	}
	
	baglan();
?>