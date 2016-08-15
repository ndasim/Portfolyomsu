<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>Untitled Document</title>
<link href="tema.css" rel="stylesheet" type="text/css" />
</head>
<body alink="#000000" vlink="#000000" link="#000000" bgcolor="#CCCC00">
	  	<?php 
			include("ortak.php");
			include("site/sayfala.php");
		?>
	    <img src="baslik.gif" /><br />
	    <?php 
		session_start();
		if (isset($_SESSION["ad"])){
			$posta = posta_kontrol($_SESSION["id"]);
			$arkadas = arkadas_kontrol($_SESSION["id"]);
			$olaylar = olay_kontrol($_SESSION["id"]);
			echo "<p class='gircubuk'><a href='uye.php?komut=profil'>Profil</a>|".$posta."|".$arkadas."|".$olaylar."<a href='ana.php?komut=cıkıs'>Çıkış</a></p>";
			echo "Zaten Giriş Yapmışsız Lütfen Çıkış Yaparak Tekrar Deneyin";
		}
		else{
			echo "<p class='gircubuk'><a href='giris.php'>Giriş</a> | <a href='kayt.php'>Kayıt Ol</a><br/>";
			if (isset($_POST['ad'])){
				$hata=0;
				if($hata){
					if ($hata = 1){
						
					} 
				}
				else{
					//uye_ekle("a","cv","v","b","n","s");
					uye_ekle($_POST['ad'],$_POST['soyad'],$_POST['sifre'],$_POST['lakap'],$_POST['cins'],$_POST['eposta']);
					echo "tmm";
				}
			}
			else{
				echo '<form style=" padding:5px; background-color:#CC6600; color:#FFFFFF" id="form1" action="" method="post">
						Lakap:<br /><input name="kayıt_kullanıcı" type="text" width="100" /><br />
						Şifreniz:<br /><input name="sifre" type="password" width="100" /><br />
						Adınız:<br /><input name="ad" type="text" width="100" /><br />
						Soyadınız:<br /><input name="soyad" type="text" width="100" /><br />
						Cinsiyetiniz:<br />
						<select name="cins">
							<option>Erkek</option>
							<option>Kadın</option>
						</select><br />
						E-posta:<br /><input name="eposta" type="text" width="100" /><br />
						Üyelik Sözleşmesini kabul ediyorum<br /> <input name="kabul" type="checkbox" value="" />
						<br />
						<input name="submit" type="submit" value="Beni kaydet" />
					</form>';
			}
			
		}
		
	?>
<p>Olaylar:<br />
    </p>
<marquee>s</marquee><br />
	<p class="altmenu">
		<a href="chat.php?komut=sicak">Online Chat</a><br />
   		<a href="diger.php?komut=haber">Gündem Haberleri</a><br />
    	<a href="diger.php?komut=geyik">Geyik Merkezi</a><br />
    	<a href="diger.php?komut=sicak">Sıcak Olaylar</a><br />
    </p>
</body>
</html>
