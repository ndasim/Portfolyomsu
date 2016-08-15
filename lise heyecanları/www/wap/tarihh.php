Yaklaşık Geçmiş Zaman Bildirme Formu; 
<form name="formm" action="#" method="post">

	A:<input type="text" name="tarih"><br /><br />
	
	<input type="submit" name="gg" value="Görüntüle"><br>
	
</form>

<?php 
	require "site/tarih_farki.php";
	
	if (isset($_POST["tarih"])){
		
		echo yaklasik_tarih($_POST["tarih"]);
		
	}
?>