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
		baglan();
	?>
	<img src="baslik.gif" /></p>
	  <?php 
		session_start();
		if (isset($_SESSION["ad"])){
			$posta = posta_kontrol($_SESSION["id"]);
			$arkadas = arkadas_kontrol($_SESSION["id"]);
			$olaylar = olay_kontrol($_SESSION["id"]);
			echo "<p class='gircubuk'><a href='uye.php?komut=profil'>Profil</a>|".$posta."|".$arkadas."|".$olaylar."<a href='ana.php?komut=cıkıs'>Çıkış</a></p>";
			echo "<p style='color:#CC6600;'>Üzgünüz Ama Siz Zaten Giriş Yapmıştınız</p>"; 
		}
		else{
			echo "<p class='gircubuk'><a href='giris.php'>Giriş</a> | <a href='kayt.php'>Kayıt Ol</a></p>";
			if (isset($_POST['lakap'])){
				$hata=0;
				if($hata){
					if ($hata = 1){
						
					}
				}
				else{
					//uye_ekle("a","cv","v","b","n","s");
					$sonuc = giris($_POST['lakap'],$_POST['sifre']);
					if ($sonuc = "basarılı"){
						header("Location:uye.php");
					}
					
				}
			}
			else{
				echo '<form style=" padding:5px; background-color:#CC6600; color:#FFFFFF" id="form1" action="" method="post">
						Kullanıcı Adınız:<br /><input name="lakap" type="text" width="100" /><br />
						Şifreniz:<br /><input name="sifre" type="password" width="100" /><br />
						<input name="submit" type="submit" value="Giriş" />
					</form>';
			}
		}
		
	?>
	
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
