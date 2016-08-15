<?php
	//********************************************//
	///////  tarih farkı hesaplama scripti/////////
	///////          www.yetisdayi.com      ///////////
	////php,web tasarımcıların,programcıların arkadaşlık mekanı //////
	//////   msn:admin@oobul.com        ///////////
	///////    mervan poyraz            ////////////
	//********************************************//

	function gun_farki($tarih){
	
		
		$durum = '-Gün Farkı Alınıyor...'.'<br />';
		$durum .= '-- Tarih Praçlama İşlemi: Gün, Ay, Yıl'.'<br />';
		
		$yeni_tarih = explode(".",$tarih);
		
		$ilk_gun = $yeni_tarih[0];
		$ilk_ay = $yeni_tarih[1];
		$ilk_yil = $yeni_tarih[2];
		
		$durum .= '---Gün:'.$ilk_gun.'<br />';
		$durum .= '---Ay:'.$ilk_ay.'<br />';
		$durum .= '---Yıl:'.$ilk_yil.'<br />';
		
		$durum .= '-- Günümüz Tarihi ile aradaki gün sayısı hesaplanıyor...'.'<br />';
		
		$son_gun = date("d");
		$son_ay = date("m");
		$son_yil = date("y");
		
		$ilk_yil_toplam = 0;
		$son_yil_toplam = 0;
		
		$ilk_ay_toplam = 0;
		$son_ay_toplam = 0;
		
		// $yil_fark = 0;
		
		$toplam_son_gun = 0;
		$toplam_ilk_gun = 0;
		
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
		
		$durum .= '--- Güncel Tarihin Geçirmiş Olduğu Toplam Gün Sayısı Hesaplanıyor ('.date('d.m.y').')'.'<br />';
		
		$son_yil_toplam = $son_yil * 365;
	
		$durum .= '---- Bu yıla kadar geçmiş toplam günsayısı = '.$son_yil.' * 365 = '.$son_yil_toplam.'<br />';
		
		for ($i = 1; $i < $son_ay; $i++){
			$son_ay_toplam += $ek[$i];
		}
		
		$son_ay_toplam += $son_gun;
		
		$toplam_son_gun = $son_ay_toplam + $son_yil_toplam;
		
		$durum .= '---- Yıl Başından beri geçmiş toplam günsayısı = ay to gun('.$son_ay.') + '.$son_gun.' = '.$son_ay_toplam.'<br />';
		$durum .= '----------------------------------------TOPLAM = '.$toplam_son_gun .'<br />'.'<br />';
		
		$durum .= '--- Girilen Tarihin Toplam Gün Sayısı Hesaplanıyor ('.$tarih.') '.'<br />';
		
		$ilk_yil_toplam = $ilk_yil * 365;
	
		$durum .= '---- Verilen yıla kadar geçmiş toplam günsayısı = '.$ilk_yil.' * 365 = '.$ilk_yil_toplam.'<br />';
		
		for ($i = 1; $i < $ilk_ay; $i++){
			$ilk_ay_toplam += $ek[$i];
		}
		
		$ilk_ay_toplam += $ilk_gun;
		
		$toplam_ilk_gun = $ilk_ay_toplam + $ilk_yil_toplam;
		
		$durum .= '---- Verilen Yıl Baından beri geçmiş toplam günsayısı = ay to gun('.$ilk_ay.') + '.$ilk_gun.' = '.$ilk_ay_toplam.'<br />';
		$durum .= '----------------------------------------TOPLAM = '.$toplam_ilk_gun.'<br />' ;
		
		$sonuc = $toplam_son_gun - $toplam_ilk_gun;
		
		$durum .= '-----------------------------İKİ TARİH ARASINDAKİ GÜN FARKI = '.$sonuc.'<br />';
		
		// echo $durum;
		
		return $sonuc;
	}

	function saniye_farki($tarih){

		$durum = '';
		
		$dizi = explode(", ",$tarih);
		
		//new dbug($dizi);
		
		// echo '-Saniye Farkı Alınıyor...<br />';
		
		$altdizi = explode(":",$dizi[1]);
		
		//new dbug($altdizi);
		
		$saat = $altdizi[0];
		$dakika = $altdizi[1];
		$saniye = $altdizi[2];
		
		$saat_s = date("G");
		$dakika_s = date("i");
		$saniye_s = date("s");
		
		$toplam_son_saniye = ($saat_s * 3600) + ($dakika_s * 60) + $saniye_s;
		
		$durum .= 'Sistem Saatinin Gün Boyunca Geçtiği Saniye Sayısı ('.date("G:i:s").') = ('.$saat_s.' * 3600) + ('.$dakika_s.' * 60 ) + '.$saniye_s.' = '.$toplam_son_saniye.'<br />';

		//
		
		$toplam_ilk_saniye = ($saat * 3600) + ($dakika * 60) + $saniye;
		
		$durum .= 'Girilen Saatinin Gün Boyunca Geçtiği Saniye Sayısı ('.date("G:i:s").') = ('.$saat.' * 3600) + ('.$dakika.' * 60 ) + '.$saniye.' = '.$toplam_ilk_saniye.'<br />';

		
		$donut = $toplam_son_saniye - $toplam_ilk_saniye;
		
		$durum .= 'Toplam Saniye Farkı = '.$donut.'<br />';
		
		// echo $durum;
		
		return $donut;
	}
	
	function yaklasik_tarih($tarih,$kip = "oldu"){
		
		$donut = '';
	
		$tarih_d = explode(", ",$tarih);

		// Öncelikli olarak dakika farkı alınıyor 
		
		
		$gun = gun_farki($tarih_d[0]);
		
		if ($gun == 0){
			$saniye = saniye_farki($tarih);
			
			if ($saniye < 5){
				$donut = '5 sn';
			}
			else if ($saniye < 10){
				$donut = '10 sn';
			}
			else if ($saniye < 20){
				$donut = '20 sn';
			}
			else if ($saniye < 30){
				$donut = '30 sn';
			}
			else if ($saniye < 60){
				$donut = '1 dk';
			}
			else if ($saniye < 120){ // 2 dk
				$donut = '2 dk';
			}
			else if ($saniye < 300){ // 5 dk
				$donut = '5 dk';
			}
			else if ($saniye < 600){ // 10 dk
				$donut = '10 dk';
			}
			else if ($saniye < 1200){ // 20 dk
				$donut = '20 dk';
			}
			else if ($saniye < 2400){ // 30 dk
				$donut = '30 dk';
			}
			else if ($saniye < 3600){ // 1 saat
				$donut = '1 saat';
			}
			else if ($saniye < 7200){ // 2 saat
				$donut = '2 saat';
			}
			else if ($saniye < 10800){ // 3 saat
				$donut = '3 saat';
			}
			else if ($saniye < 14400){ // 4 saat
				$donut = '4 saat';
			}
			else if ($saniye < 18000){ // 4 saat
				$donut = '5 saat';
			}
			else if ($saniye < 21600){ // 6 saat
				$donut = '6 saat';
			}
			else if ($saniye < 43200){ // 12 saat
				$donut = '12 saat';
			}
			else if ($saniye < 86400){ // 24 saat
				$donut = '24 saat';
			}
			
		}
		else if ($gun < 60 ) {
			$donut = $gun.' gün ';
		}
		
		$donut = '~ '.$donut.' '.$kip;

		
		// eğer dakika farkı en yuvarlak biçimde msl: 10dk 20dk 5dk gibi süre içinde verilecek
		// 60 dan yukarı değerler için yakalsık saat değeri verilecek
		// eğer 3600 'den yukarı çıkarsa yuvarlak gün ve ay değerleri verilecek;
	
		
		
		//echo $donut ;
		
		return $donut;
	}
	
?>

