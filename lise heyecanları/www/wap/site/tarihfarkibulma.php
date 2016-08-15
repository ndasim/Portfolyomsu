<?
	//********************************************//
	///////  tarih farkı hesaplama scripti/////////
	///////          www.yetisdayi.com      ///////////
	////php,web tasarımcıların,programcıların arkadaşlık mekanı //////
	//////   msn:admin@oobul.com        ///////////
	///////    mervan poyraz            ////////////
	//********************************************//

	function tarihfarki($tarih_gir){		///girilecek olan tarihimizin arasındaki "-" işaretinin olması lazım.Örnek olara 02-12-2006 gibi
		///eğer başka bir kesme kullanacaksanız aşağıda explode satırında bulunan "-" değiştirmeniz yeterli
		
		///explode komutu ile tarihimizi parçalara ayırıp değişkenlere aktarıyoruz
		$yeni_tarih=explode(".",$tarih_gir);
		
		$ilk_gun=$yeni_tarih[0];
		$ilk_ay=$yeni_tarih[1];
		$ilk_yil=$yeni_tarih[2];
		
		$son_gun=date("d");
		$son_ay=date("m");
		$son_yil=date("Y");
		
		///burada aylarımızın kaç gün çektiğini değişkenlere aktarıyoruz
		$ek[1]=31;
		$ek[2]=28;
		$ek[3]=31;
		$ek[4]=30;
		$ek[5]=31;
		$ek[6]=30;
		$ek[7]=31;
		$ek[8]=31;
		$ek[9]=30;
		$ek[10]=31;
		$ek[11]=30;
		$ek[12]=31;

		///önce yıl farkı varsa bundan doğan farkı GÜN olarak hesaplayalım

		$yil_fark=($son_yil - $ilk_yil) * 365 ;
		
		////for döngüsüyle ayları topluyorum
		for($i=1;$i < $son_ay;$i++){			$son_ay_toplam = $son_ay_toplam+$ek[$i];
		}
		
		///şimdiki  gün ve ay  toplamımız
		$toplam_son_gun = $son_ay_toplam + $son_gun;
		
		////girilen ay'ı hesaplayalım
		for($m=1;$m < $ilk_ay;$m++){			$ilk_ay_toplam = $ilk_ay_toplam + $ek[$m];		}
		
		 ////girilen ay ve günü hesaplayalım
		$toplam_ilk_gun = $ilk_ay_toplam + $ilk_gun;
		
		$sonuc = $toplam_son_gun-$toplam_ilk_gun + $yil_fark;
		
		return $sonuc;
	}

?>


<?
	/*
		///////yukarıdaki tarihfarki(); fonksiyonumuzu sayfanıza import edip
		//////aşağıdaki gibi kullanabilirsiniz...
		
		$tarih_gir="01-02-2007";
		
		tarihfarki($tarih_gir);
	*/
?>


