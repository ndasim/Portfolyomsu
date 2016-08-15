<?php 
	ob_start(); 
	include "dbug.php";
	// include "site/sayfala.php";
?>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
	<head>
		<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
		<title>Untitled Document</title>
		<link href="tema/yonetim/uye.css" rel="stylesheet" type="text/css" />
		<script type="text/javascript" language="javascript">

			var baglanti = false;
			var formdata = false;
			var islm_bklme = false;
			
			function baglan() {
				
				if (window.XMLHttpRequest) { // Mozilla, Safari,...
					baglanti = new XMLHttpRequest();
					baglanti = new XMLHttpRequest();
					if (baglanti.overrideMimeType) {
						baglanti.overrideMimeType('text/xml');
						// See note below about this line
					}
				} else if (window.ActiveXObject) { // IE
					try {
						baglanti = new ActiveXObject("Msxml2.XMLHTTP");
					} catch (e) {
						try {
							baglanti = new ActiveXObject("Microsoft.XMLHTTP");
						} catch (e) {}
					}
				}

				if (!baglanti) {
					alert('Lütfen AJAX Desteği Olan Bir Tarayıcıyla Bağlanın');
					return false;
				}
				baglanti.onreadystatechange = function(){donut();};
				
				
			}
			
			function nl2(text){
				// Gereksiz php artık /n/p karekterlerinden temizleme yapımı
				text = escape(text);
				if(text.indexOf('%0D%0A') > -1){
					re_nlchar = /%0D%0A/g ;
				}else if(text.indexOf('%0A') > -1){
					re_nlchar = /%0A/g ;
				}else if(text.indexOf('%0D') > -1){
					re_nlchar = /%0D/g ;
				}
				text = unescape( text.replace(re_nlchar,'') );
				
				// :-adn-: bulunan yerleri /n/p olarak değiştirme;
				text = escape(text);
				if(text.indexOf('%3A-adn-%3A') > -1){
					re_nlchar = /%3A-adn-%3A/g ;
				}
				
				return unescape( text.replace(re_nlchar,'%0D%0A') );
			}
			
			function gonder(){
				
				var formdata = document.forms[0];
				var data = createQuery(document.forms[0]);
				
				//data.append("CustomField", "Ekstra Veri");
				
				baglanti.open('GET','yonet_islem.php?komut=ifadeler&' + data, false);
				// header("Content-Type", "charset=utf-8");
				baglanti.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
				baglanti.setRequestHeader("Content-length", data.length);
				baglanti.setRequestHeader("Connection", "close");
				
				baglanti.send(null);
			}
			
			function createQuery(form){ // Alıntıdır www.webmastersitesi.com/javascript/19275-ajax-uygulamalarinda-turkce-karakter-sorunu.htm
				var elements = form.elements;
				var pairs = new Array();

				for (var i = 0; i < elements.length; i++) {

				if ((name = elements[i].name) && (value = elements[i].value))
				pairs.push(escape(name) + "=" + encodeURIComponent(value));
				}
				//pairs.push("param1=1");
				return pairs.join("&");
			}		
			
			function donut() {

				if (baglanti.readyState == 4) {
					if (baglanti.status == 200) {
						
						$donut = nl2(baglanti.responseText);
						alert($donut);
						
						// var iframe = document.getElementById("onizleme");
						// iframe.src = iframe.src;
					} 
					else {
						alert('Sunucu üzerinde bir hata oluştu. Durum Kodu:' + baglanti.status);
					}
				}

			}
			
			function nesne(id,no){
				this.ad = id;
				this.nesne = document.getElementById(id);
				this.no = no;
			}
			
		</script>
	</head>
	<body onload="baglan()">
		<form name="form1" action="#" method="post">
			<table>
				<tr>
					<td>Resimin dosyası: </td>
					<td><input name="ifade" type="text"></td>
				</tr>
				<tr>
					<td>İfadenin kısayolu:</td>
					<td><input type="text" name="kısayol" value="<?php echo $_GET["kısayol"]; ?>"></td>
				</tr>
				<tr>
					<td>Genişlik: <input name="genislik" type="text" value="<?php echo $_GET["genislik"]; ?>"></td>
					<td>Yükseklik:<input name="yukseklik" type="text" value="<?php echo $_GET["yukseklik"]; ?>"></td>
				</tr>
				<tr>
					<td><a href="#" onclick="gonder()">Gönder</a></td>
				</tr>
				<tr>
					<td rowspan="5">Kurallar:</td>
					<td></td>
				</tr>
				<tr>
					<td colspan="2" style="color:#FF0000;">** Dosya kesinlikle resim dosyası olmalıdır</td>
				</tr>
				<tr>
					<td colspan="2" style="color:#FF0000;">** Kısayol yazarken "." ve " " işareti kullanılmamalıdır </td>
				</tr>
				<tr>
					<td colspan="2" style="color:#FF0000;">** Boyut Kısmı Boş Kalabilir </td>
				</tr>
			</table>
			<input type="hidden" name="ex_kısayol" value="<?php echo $_GET["kısayol"]; ?>">
			<?php new dbug($_GET); ?>
		</form>
	</body>
</html>

























