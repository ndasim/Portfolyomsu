<?php 
	include "ortak.php";
	include "site/yonet_islem.php";
	//new dbug($_SESSION);
?> 
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>Başlıksız Belge</title>
<style type="text/css"> 
<!-- 
body  {
	font: 100% Verdana, Arial, Helvetica, sans-serif;
	background: #666666;
	margin: 0;
	padding: 0;
	text-align: center; 
	color: #000000;
}

.thrColElsHdr #container {
	width: 75em;
	background: #FFFFFF;
	margin: 0 auto;
	border: 1px solid #000000;
	text-align: left;
} 
.thrColElsHdr #header { 
	background: #DDDDDD; 
	padding: 0 10px;
} 
.thrColElsHdr #header h1 {
	margin: 0;
	padding: 10px 0; 
}

.thrColElsHdr #sidebar1 {
	float: left; 
	width: 11em;
	background: #EBEBEB; 
	padding: 15px 0;
}
.thrColElsHdr #sidebar2 {
	float: right; 
	width: 11em; 
	background: #EBEBEB;
	padding: 15px 0;
}

.thrColElsHdr #sidebar1 h3, .thrColElsHdr #sidebar1 p, .thrColElsHdr #sidebar2 p, .thrColElsHdr #sidebar2 h3, a {
	text-decoration:none;
	color:#000000;
	padding-top:2px;
	margin-left: 10px; 
	margin-right: 10px;
	border-bottom:dotted 1px #333399;
}

#sidebar1 a:hover{
	padding-left:5px;
	color:#990000;
}

.thrColElsHdr #mainContent {
 	margin: 0 12em 0 12em;
} 
.thrColElsHdr #footer { 
	padding: 0 10px;
	background:#DDDDDD;
} 
.thrColElsHdr #footer p {
	margin: 0;
	padding: 10px 0; 
}

.fltrt {
	float: right;
	margin-left: 8px;
}
.fltlft {
	float: left;
	margin-right: 8px;
}
.clearfloat {
	clear:both;
    height:0;
    font-size: 1px;
    line-height: 0px;
}
--> 
</style>
<!--[if IE]>
<style type="text/css"> 
/* place css fixes for all versions of IE in this conditional comment */
.thrColElsHdr #sidebar1, .thrColElsHdr #sidebar2 { padding-top: 30px; }
.thrColElsHdr #mainContent { zoom: 1; padding-top: 15px; }
/* the above proprietary zoom property gives IE the hasLayout it needs to avoid several bugs */
</style>
<![endif]-->
<script language="javascript">
	var nsne = false;
	
	function basla(){
		nsne = document.getElementById("git");
		frameayar();
	}
	
	function ac(nereye){
		if (nereye == "sistem_yonetim"){
			nsne.src="sistem.php";
		}
		else if (nereye == "uye_yonetim"){
			nsne.src="uye_list.php";
		}
		else if (nereye == "grafik_yonetim"){
			nsne.src="grafik_yonetim.php";
		}
		else if (nereye == "sohbet_odaları"){
			nsne.src="sohbet_odalari.php";
		}
		else if (nereye == "sayfalar"){
			nsne.src="sayfalar.php";
		}
		else if (nereye == "ifadeler"){
			nsne.src="ifadeler.php";
		}
	}
	
	function frameayar(){
		var yukseklik = 200;
		var genislik = 500;
		
		if (nsne){
			yukseklik = nsne.contentWindow.document.body.scrollHeight+100; // !!! firefox için !!!!
			genislik = nsne.contentWindow.document.body.scrollWidth+100; // !!! firefox için !!!!
			
			//nsne.style.cssText += "height:" + yukseklik + "px;";
			//nsne.style.cssText += "width:" + genislik + "px;";			
		}

	}
	
</script>
</head>

<body class="thrColElsHdr" onload="basla()">
    <div id="container">
      
      <div id="header">
        <h1><center><img src="tema/yonetim/banner.png" /></center></h1>
      </div>
      <?php
	  	 if (oturum_kontrol()){
		 	include "site/yonet_ana.html";
		 }
		 else{
		  	echo '<div id="mainContent">';
          	include "yonetim_gir.php";
      	  	echo '</div>';
		 }
      
      ?>
      
      <br class="clearfloat" />
      
      <div id="footer">
           <p>Sosyalmanya yönetim paneli 2012</p>
      </div>
    </div>
</body>
</html>
