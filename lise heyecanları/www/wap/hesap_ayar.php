<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
	<head>
		<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
		<link href="tema/yonetim/uye.css" rel="stylesheet" type="text/css" />
	</head>
	<body>
		<b class="baslik">Kullanıcın Hesap Ayarlarını Değiştir</b>
		<?php
			// Ön Yükleme...
			include "ortak.php";
			include "site/guvenlik.php";
			
			// Kullanıcı ayarları
			
			// Alan adları alınıyor...
			
			$alann = array();
			$alan_ad = "";
			$alan_tur = "";
			
			$i = 1;
			
			$sorgu = mysql_query('SELECT * FROM uye_2');
			
			while($alan_ad = mysql_field_name($sorgu, $i)){
				$alan_tur = mysql_field_type($sorgu, $i);
				
				$alann[$i] = array();
				$alann[$i]["ad"] = $alan_ad;
				$alann[$i]["tür"] = $alan_tur;
				$i++;
			}

			// Çıkan alanadlarının herbirini işleyecek şekilde yazdırılması yani: hepsinin değerinin değiştirimesine olanak tanıyan tablo yapımı...
			
			echo '<table>
					<thead>
						<tr>
							<td>Özellik</td>
							<td>Veri türü</td>
							<td>Verilecek Değer</td>
						</tr>
					</thead>';
			
			foreach ($alann as $ad){
				// Önceden tanımlanmış değerin alınması...
				
				$sorgu = mysql_query('SELECT '.$ad["ad"].' FROM uye_2 WHERE uyeid='.$_SESSION["id"]);
				$deger = mysql_result($sorgu,0,$ad["ad"]);
				
				echo '
					<tr>
						<td>'.$ad["ad"].'</td>
						<td>'.$ad["tür"].'</td>
						<td>'.$deger.'</td>
					</tr>
					';
			}
			
			echo '</table>';
			
		?>
	</body>
</html>