<html>
<head>
<script type="text/javascript" language="javascript">

    function basla() {

        var http_request = false;

        if (window.XMLHttpRequest) { // Mozilla, Safari,...
            http_request = new XMLHttpRequest();
            if (http_request.overrideMimeType) {
                http_request.overrideMimeType('text/xml');
                // See note below about this line
            }
        } else if (window.ActiveXObject) { // IE
            try {
                http_request = new ActiveXObject("Msxml2.XMLHTTP");
            } catch (e) {
                try {
                    http_request = new ActiveXObject("Microsoft.XMLHTTP");
                } catch (e) {}
            }
        }

        if (!http_request) {
            alert('Giving up :( Cannot create an XMLHTTP instance');
            return false;
        }
		
        http_request.onreadystatechange = function() { cýktý(http_request); };
        http_request.open('GET', url, true);
        http_request.send(null);

    }

    function cýktý(http_request) {

        if (http_request.readyState == 4) {
            if (http_request.status == 200) {
                alert(http_request.responseText);
            } else {
                alert('There was a problem with the request.');
            }
        }

    }


function sendForm() {

var formData = new FormData();
formData.append("kullaniciadi", "abutun");
formData.append("sifre", 123456);
formData.append("birdosya", fileInputElement.files[0]);
  
  var xhr = new XMLHttpRequest();
  xhr.open("POST", "upload.php", false)
  xhr.send(data);
  if (xhr.status == 200) {
    output.innerHTML += "Yüklendi!&lt;br /&gt;";
  } else {
    output.innerHTML += "Hata oluþtu (" + xhr.status + ").&lt;br /&gt;";
  }
}
 
</script>
</head>
<body>
<a href="" onclick="sendForm()">aaaa</a>
</body>
</html>