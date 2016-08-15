<?php ob_start(); ?>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
	<?php 
		include("ortak.php");
		include("site/sayfala.php");
		include("site/guvenlik.php");
	?>
	<head>
		<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
		<title>Sosyal Manya</title>
		<link href="tema_a.php" rel="stylesheet" type="text/css" />
		<style type="text/css">
			<?php 
				sayfa_css();
			?>
		</style>
		<script type="text/javascript" language="javascript" src="site/cssoku.js"></script>
	</head>
	<body class="govde" onload="basla()">
		<?php 
			//new dbug($_SESSION);
			sayfa_kur();
			gecmis_ekle();
		?>
	</body>
</html>
<?php ob_end_flush(); ?>