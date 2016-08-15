<?php
	
	include "ortak.php";
	new dbug($_FILES);
	
	echo '<form id="form1" action="sil.php" methot="post">';
	
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
	
	
	
	function isle($deger){
		
		echo '<table border="0" bgcolor="#CC3300" >';
 		
		if ($_FILES[$deger]["error"] == 0){
		
			$tmp_name = $_FILES[$deger]["tmp_name"];
			$dsyaadı = $_FILES[$deger]["name"];
					
			move_uploaded_file($tmp_name, "tema/tema1/".$dsyaadı);
			
			echo $tmp_name;
			
			//echo 'INSERT INTO tema_kaynak(ad,adres,tema) VALUES ("'.$deger.'","tema/'.$deger.'","1"';
			//echo 'SELECT * FROM tema_kaynak WHERE ad = "'.$deger.'"';
			@$sorgu = mysql_query('SELECT * FROM tema_kaynak WHERE ad = "'.$deger.'"') or die(mysql_error());
			
			if (mysql_num_rows($sorgu)){
				//@mysql_query('UPDATE tema_kaynak SET ad="'.$deger.'",adres="tema/tema1/'.$dsyaadı.'",tema="1" WHERE ad="'.$deger.'" ') or die(mysql_error());
			}
			else {
				//@mysql_query('INSERT INTO tema_kaynak(ad,adres,tema) VALUES ("'.$deger.'","tema/tema1/'.$dsyaadı.'","1")') or die(mysql_error());
			}
			echo '			
			<tr>
				<td>'.kaynak_al($deger).'</td>
				<td><input name="'.$deger.'" type="checkbox" /></td>
			</tr>';
			
		}
		elseif ($_FILES[$deger]["error"] == 2){
			echo 'Seçmiş olduğun dosya boyutlarıdan biri 900000 baytı geçti';
		}
	}
	
	echo '<input type="submit" value="Seçilileri sil" /></table></form>';

?>
