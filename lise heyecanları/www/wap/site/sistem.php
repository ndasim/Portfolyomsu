<?php 

	echo '
		<p>
			Aktif Kullanýcý Sayýsý:<br />
			Toplam Paylaþýlan Yazý:<br />
			Toplam Paylaþýlan Resim:<br /> 
			Toplam Kullanýcý Sayýsý:<br />
			Aktif Yönetici Sayýsý:<br />
		</p> ~~~~~~~~~~~~~~ 
		<p>
			Kontrol Edilmemiþ Sistem Mesajý Sayýsý<br />
			Kontrol Edilmemiþ Þikayet Mesajý Sayýsý<br />
			Kontrol Edilmemiþ Mesaj Sayýsý<br />
		</p>
		
		<p class="baslik">Yeni Kaydolan Kullanýcýlar Ýçin Yapýlacak Ýþlem</p>
		<form id="form1" methot="post">
			<p>
				Aktivasyon Mesajý Ýste:<input type="checkbox" name="aktivasyon"><br />
				Direkt Giriþ Yap:<input type="checkbox" name="hemengiris"><br />
				Kayýt Bilgilerini Bir Seferlik Goster:<input type="checkbox" name="goster">
			</p>
		</form>
		</p>
		<p>
			Rütbeleri Düzenle
		</p>
		<p>
			Bakým
		</p>
		<p>
			Görüntülenmeyen Kullanýcý Mesajlarýný Sil (Toplam: ??)</br>
			Paylaþýmdan Kaldýrýlmýþ Verileri Sil (Toplam: ??)</br>
			Kullanýlmayan Sohbet Odalarýný Sil (Toplam: ??)</br>
			~ ~ ~ ~
			3 Aylýk Girilmemiþ Hesaplarý Kapat (Toplam: ??)</br>
			6 Aylýk Girilmemiþ Hesaplarý Kapat (Toplam: ??)</br>
			1 Yýl Üzerinde Giriþ Yapýlmamýþ Hesaplarý Kapat (Toplam: ??)</br>
			~ ~ ~ ~
			Veri Tabanýnýn Sunucu Üzerinde Bir Yedeðini Al
			Sistem Hatasý Bildir
		</p>
	';

?>