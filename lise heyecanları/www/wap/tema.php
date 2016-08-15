<?php 
	header("Content-type: text/css"); // Başlıkk
	include("ortak.php");
	
	function stil($ad){
		
		$donut = false;
		
		// Varsayılan temanın öğrenilmesi...
		$sorgu = mysql_query('SELECT * FROM sistem WHERE ad="tema"');
		$tema = mysql_result($sorgu,0,'deger');
		
		if (isset($_SESSION["önizleme"])){
			$donut = $_SESSION["önizleme"]['css'.$ad];
			//echo "ehö ühü ehe";
		}
		else{
			if (oturum_kontrol()){
				$sorgu = mysql_query('SELECT * FROM tema_veri 
									WHERE tema_ad="'.$_SESSION["tema"].'" and kural="'.$ad.'"');
			}
			else{
				@$sorgu = mysql_query('SELECT * FROM tema_veri 
									WHERE tema_ad="'.$tema.'" and kural="'.$ad.'"') or die(mysql_error());
				
				//echo 'cızzz sql_cümlesi:'.'SELECT * FROM tema_veri 
									//WHERE tema_ad="varsayılan" and obje_ad="'.$ad.'"';
			}
			
			if ($sorgu != false){
				if (mysql_num_rows($sorgu) > 0){
					$donut = mysql_result($sorgu,0,"komut");
					
					//echo "cızzz deneyy cızzz dönüt:".$donut;
				}
			}
		}
		
		return $donut;
	}
?>

@charset "utf-8";
/* CSS Document */

img, a img{
	border:0;
}

.gircubuk{
	<?php if(stil("gircubuk") != ""){echo stil("gircubuk");}else{echo "color:#FFFFFF; background-color:#CC9900;";} ?>
}

* {
	<?php if(stil("*") != ""){echo stil("*");}else{echo "margin: 0px;";} ?>
}

a {
	<?php if(stil("a") != ""){echo stil("a");}else{echo "color:#FFFFFF;";} ?>
}

#posta_tab a{
	<?php if(stil("posta_tab a") != ""){echo stil("posta_tab a");}else{echo "color:#CC3300;";} ?>
}

table a{
	<?php if(stil("table a") != ""){echo stil("table a");}else{echo "color:#000000; /*padding:4px;*/ text-decoration: none;";} ?>
	
}

a[title~="a"] {
	color:#CC3300;
	padding:4px;
	font-weight:bold;
}

a[title~="b"] {
	color:#CC3300;
	padding:4px;
	font-weight:bold;
}

p {
	<?php if(stil("p") != ""){echo stil("p");}else{echo "padding: 4px; display: block;";} ?>
}

.sayfa_gostergec{
	<?php if(stil("sayfa_gostergec") != ""){echo stil("sayfa_gostergec");}else{echo "background:#CC6600; color:#CC6600;";} ?>
}

.sayfa_gostergec a{
	<?php if(stil("sayfa_gostergec a") != ""){echo stil("sayfa_gostergec a");}else{echo "background:#CC6600; text-decoration:none;";} ?>
}

.altmenu{
	<?php if(stil("altmenu") != ""){echo stil("altmenu");}else{echo "background:#CC6600;";} ?>
}

.govde{
	<?php if(stil("govde") != ""){echo stil("govde");}else{echo "color: #FFFFFF; background-color:#CC6600; padding-left: 15px;";} ?>
}

.arkmenu a{
	<?php if(stil("arkmenu a") != ""){echo stil("arkmenu a");}else{echo "color: #CC3300; text-align: middle;";} ?>
}

.baslik{
	<?php if(stil("baslik") != ""){echo stil("baslik");}else{echo "background:#CC3300; color:#FFFFFF;";} ?>
}

.altbaslik {
	<?php if(stil("altbaslik") != ""){echo stil("altbaslik");}else{echo "background:#CC6600; color:#FFFFFF;";} ?>
}

.listetab {
	<?php if(stil("listetab") != ""){echo stil("listetab");}else{echo "border-bottom:#CC6600 dotted 1px;";} ?>
	
}

.listetab #ilk {
	<?php if(stil("listetab #ilk") != ""){echo stil("listetab #ilk");}else{echo "border-right:#CC6600 dotted 1px; padding-right:5px;";} ?>

}

.yancizgi {
	<?php if(stil("yancizgi") != ""){echo stil("yancizgi");}else{echo "	padding-right:5px; border-right:#FFFFFF dotted 2px;";} ?>
}

.siyah {
	<?php if(stil("siyah") != ""){echo stil("siyah");}else{echo "color:#000000;";} ?>
}

.yazi {
	<?php if(stil("yazi") != ""){echo stil("yazi");}else{echo "color:#CC3300;";} ?>
}

.yazi a{
	<?php if(stil("yazi a") != ""){echo stil("yazi a");}else{echo "color:#CC3300;";} ?>
}

.yazi1 {
	<?php if(stil("yazi1") != ""){echo stil("yazi1");}else{echo "color:#CC3300;";} ?>
}

.gurupbaslik{
	<?php if(stil("gurupbaslik") != ""){echo stil("gurupbaslik");}else{echo "color:#CC3300; border-bottom:#CC6600 dotted 1px;";} ?>
}

.tabbaslik{
	<?php if(stil("tabbaslik") != ""){echo stil("tabbaslik");}else{echo "border-right:#FFFFFF dotted 1px; padding-right:5px;";} ?>
}

.listeyazi {
	<?php if(stil("listeyazi") != ""){echo stil("listeyazi");}else{echo "border-bottom:#CC6600 dotted 1px;";} ?>
}

.paylasim_ust{
	<?php if(stil("paylasim_ust") != ""){echo stil("paylasim_ust");}else{echo "font-style:italic; font-size: 12px; color: #3300FF;";} ?>
}

.paylasim_alt{
	<?php if(stil("paylasim_alt") != ""){echo stil("paylasim_alt");}else{echo "font-size: 10px; color: #3300FF;";} ?>
}

.paylasim_alt a{
	<?php if(stil("paylasim_alt a") != ""){echo stil("paylasim_alt a");}else{echo "font-size: 10px; color: #3300FF;";} ?>
}

.paylasim_alt1{
	<?php if(stil("paylasim_alt1") != ""){echo stil("paylasim_alt1");}else{echo "font-size: 14px; color: #3300FF;";} ?>
}

.paylasim_alt1 a{
	<?php if(stil("paylasim_alt1 a") != ""){echo stil("paylasim_alt1 a");}else{echo "font-size: 14px; color: #3300FF;";} ?>
}