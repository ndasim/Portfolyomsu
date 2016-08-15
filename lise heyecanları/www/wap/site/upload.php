<?php

	echo $_POST["sifre"];
	
/*
foreach ($_FILES["file"]["error"] as $anahtar => $hata) {
    if ($hata == UPLOAD_ERR_OK) {
		echo "tmm";
        $tmp_name = $_FILES["file"]["tmp_name"][$anahtar];
        $name = $_FILES["file"]["name"][$anahtar];
        move_uploaded_file($tmp_name, "data/$name");
    }
}
*/
?>
