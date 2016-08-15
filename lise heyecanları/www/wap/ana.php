<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>Untitled Document</title>
<link href="tema.css" rel="stylesheet" type="text/css" />
</head>
<body bgcolor="#CCCC00">
	<?php 
		include("ortak.php");
		include("site/sayfala.php");
		baglan();
		sayfa_kur();
	?>
	<img src="baslik.gif" /></p>
	<?php
		
		session_start();
	  
		$komut = "";
		
		if (isset($_GET["komut"])){
			$komut = $_GET["komut"];
		}
		
		if ($komut == "cıkıs"){
			session_destroy();
			echo "<p class='gircubuk'><a href='giris.php'>Giriş</a> | <a href='kayt.php'>Kayıt Ol</a></p>";
		}
		else{
			session_start();
			if (isset($_SESSION["ad"])){
				$posta = posta_kontrol($_SESSION["id"]);
				$olaylar = olay_kontrol($_SESSION["id"]);
				echo "<p class='gircubuk'><a href='uye.php?komut=profil'>Profil</a>|".$posta."|".$arkadas."|".$olaylar."<a href='ana.php?komut=cıkıs'>Çıkış</a></p>";
			}
			else{
				echo "<p class='gircubuk'><a href='giris.php'>Giriş</a> | <a href='kayt.php'>Kayıt Ol</a></p>";
			}
		}

		
	?>
	<p class="govde">
    <img src ="tema/nokta.gif">Çevrim içi Arkadaşlık<br />
    <img src ="tema/nokta.gif">Çevrim içi sohbetler<br />
    <img src ="tema/nokta.gif">Oyunlar,Etkinlikler,Astroloji<br />
    <img src ="tema/nokta.gif">Resim,Video paylaşımı<br />
    <img src ="tema/nokta.gif">Hızlı ve kaliteli gezinti<br />
    <img src ="tema/nokta.gif">Son dakika haberleri<br />
    <img src ="tema/nokta.gif">Gündemden haberler<br />
    <img src ="tema/nokta.gif">Ve Renkli Sosyal Yaşam<br />
    </p>
    <p style="color:#CC6600;"><b>Olaylar:</b><br />
    </p>
<marquee></marquee>
	<p class="altmenu">
		<a href="chat.php?komut=sicak">Online Chat</a><br />
   		<a href="diger.php?komut=haber">Gündem Haberleri</a><br />
    	<a href="diger.php?komut=geyik">Geyik Merkezi</a><br />
    	<a href="diger.php?komut=sicak">Sıcak Olaylar</a><br />
    </p>
</body>
</html>
