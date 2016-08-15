<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	<title>Untitled Document</title>
	<script language="javascript">
		var sill = true;
		
		function basla(){
			
		}
		
		function sil(){
			if (sill){
				document.forms[0].ara.value = "";
				sill = false;
			}
		}
	</script>
	<link href="tema/yonetim/uye.css" rel="stylesheet" type="text/css" />
</head>
<body>
	<table width="700">
		<thead>
			<tr>
				<td width="33">İd</td>
				<td width="67">Rütbe</td>
				<td width="91">Kullanıcı Adı</td>
				<td width="67">Şifre</td>
				<td width="73">Ad</td>
				<td width="78">Soyad</td>
				<td width="161">E-Posta Adresi</td>
				<td width="78">Son Giriş Tarihi</td>
				<td width="165">İşlemler</td>
			</tr>
		</thead>
		<tbody>
		<?php	
			// Bütün Üyeler Sorguyla Çağrılıp sayfalandırılıyor...
			include "ortak.php";
			include "site/guvenlik.php";
			
			$sayfa_dzi = array();
			$sorgu_dzi = array();
			if (oturum_kontrol()){
				
				$sorgu = mysql_query("SELECT uyeid,rutbe,ad,soyad,sifre,kullanıcı_adı,eposta FROM uye")or die(mysql_error());
				
				// Liste alımı...
				// Bu bir cahillik örneğidir :D ama neyapam baska türlüsüne bi türlü ısınamadım 
				
				while($listele = mysql_fetch_assoc($sorgu)){
					$sorgu_dzi[] = $listele;
				}
				
				// Sayfalama İşlemi...
				sayfala($sorgu_dzi,"yonetim:uyelistesi",30); // Maks 30 birimlik listelere bölünüyor
			
				// Sayfaya Gitme İşlemi
				if (isset($_GET["sayfa"])){
					$sayfa_dzi = sayfa_dizisi($_GET["sayfa"],"yonetim:uyelistesi");
					//new dbug($sayfa_dzi);
				}
				else{
					$sayfa_dzi = sayfa_dizisi("","yonetim:uyelistesi");
				}
				
				// Yazdırma İşlemi...
				foreach ($sayfa_dzi as $dizi){
					echo '
						<tr>
							<td><a href="uye.php?id='.id_maskele($dizi["uyeid"]).'">'.$dizi["uyeid"].'</a></td>
							<td>'.$dizi["rutbe"].'</td>
							<td><a href="uye.php?id='.id_maskele($dizi["uyeid"]).'">'.$dizi["kullanıcı_adı"].'</a></td>
							<td>'.$dizi["sifre"].'</td>
							<td>'.$dizi["ad"].'</td>
							<td>'.$dizi["soyad"].'</td>
							<td>'.$dizi["eposta"].'</td>
							<td></td>
						</tr>
						<tr>
							<td colspan="8" style="border-top:#CC6600 dotted 1px;"></td>
						</tr>
						';
				}
				
				
			}
		?>
		</tbody>
    </table>
	
    <div style="position:absolute; left: 729px; top: 15px; width: 200px; height: 284px;">
		<table style="border:#CC6600 dotted 1px;">
			<tr>
				<td>Ara:</td>
				<td>
					<form action="" method="post">
						<input id="ara" name="ara" type="text" value="Herhangi bir alanda arat" onclick="javascript:sil()" /><br />
						<input style="margin-left:70px; width:60px;" name="bull" type="submit" value="Ara" />
					</form>				
				</td>
			</tr>
			<tr>
				<td colspan="2" style="border:#CC6600 dotted 1px;"></td>
			</tr>
			<tr>
				<td>Listele:</td>
				<td>
					<form action="" method="post">
						<select name="ne_icin2">
							<option value="id">İd</option>
							<option value="kullanıcı">Kullanıcı Adı</option>
						</select><br />
						<select name="ne_icin">
							<option value="artan">Artan</option>
							<option value="azalan">Azalan</option>
						</select><br>
						<input style="margin-left:70px; width:60px;" name="listele" type="submit" value="Listele" />
					</form>
				</td>
			</tr>
		</table>
		
	</div>
</body>
</html>
