<?php 

	echo '
		<p>
			Aktif Kullan�c� Say�s�:<br />
			Toplam Payla��lan Yaz�:<br />
			Toplam Payla��lan Resim:<br /> 
			Toplam Kullan�c� Say�s�:<br />
			Aktif Y�netici Say�s�:<br />
		</p> ~~~~~~~~~~~~~~ 
		<p>
			Kontrol Edilmemi� Sistem Mesaj� Say�s�<br />
			Kontrol Edilmemi� �ikayet Mesaj� Say�s�<br />
			Kontrol Edilmemi� Mesaj Say�s�<br />
		</p>
		
		<p class="baslik">Yeni Kaydolan Kullan�c�lar ��in Yap�lacak ��lem</p>
		<form id="form1" methot="post">
			<p>
				Aktivasyon Mesaj� �ste:<input type="checkbox" name="aktivasyon"><br />
				Direkt Giri� Yap:<input type="checkbox" name="hemengiris"><br />
				Kay�t Bilgilerini Bir Seferlik Goster:<input type="checkbox" name="goster">
			</p>
		</form>
		</p>
		<p>
			R�tbeleri D�zenle
		</p>
		<p>
			Bak�m
		</p>
		<p>
			G�r�nt�lenmeyen Kullan�c� Mesajlar�n� Sil (Toplam: ??)</br>
			Payla��mdan Kald�r�lm�� Verileri Sil (Toplam: ??)</br>
			Kullan�lmayan Sohbet Odalar�n� Sil (Toplam: ??)</br>
			~ ~ ~ ~
			3 Ayl�k Girilmemi� Hesaplar� Kapat (Toplam: ??)</br>
			6 Ayl�k Girilmemi� Hesaplar� Kapat (Toplam: ??)</br>
			1 Y�l �zerinde Giri� Yap�lmam�� Hesaplar� Kapat (Toplam: ??)</br>
			~ ~ ~ ~
			Veri Taban�n�n Sunucu �zerinde Bir Yede�ini Al
			Sistem Hatas� Bildir
		</p>
	';

?>