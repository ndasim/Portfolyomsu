<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>Başlıksız Belge</title>
</head>
<body>
<?php
	include "dbug.php";
	require 'kriptol1n.php'; 
	
	if (isset($_POST["sifre"])){
		$sifre = kriptol1n($_POST["sifre"]);
		$saglama = kriptol1n_coz($sifre);
		echo 'Sağlaması:'.$saglama;
	}

	
?>
<form method="post">
	<textarea name="sifre"></textarea>
	<input type="submit" value="Şifrele Bakem">
</form>
</body>
</html>