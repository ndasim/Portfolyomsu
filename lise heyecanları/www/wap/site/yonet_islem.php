<?php  
	
	// Tüm veriler Burada Ateşleniyor;
	gelen_veriler();
	
	function gelen_veriler(){
		$komut = $_GET["komut"];
		
		//echo "asasas";
		
		if ($komut == "giris"){
			//echo "asasasg  ".$_POST["kullanıcı"];
			if (!oturum_kontrol()){
				if (isset($_POST["kullanıcı"])){
					
					$sonuc = oturum_baslat('yönetici');
					
					if ($sonuc){
						echo "tmm";
					}
					else{
						echo "Lütfen Tekrar deneyiniz sonuç alamıyorsanız yöneticiye başvurun";
					}
				}
				//new dbug($_POST);
			}
			
		}
		else if ($komut == "sis_yonetim"){
			//echo "asasasg  ".$_POST["kullanıcı"];
			if (isset($_POST["kullanıcı"])){
				if ($sonuc){
					include "sistem.php";
				}
				else{
					echo "Lütfen Tekrar deneyiniz sonuç alamıyorsanız yöneticiye başvurun";
				}
			}
			//new dbug($_POST);
		}
		else if ($komut == "grafik"){
		
			if (isset($_POST["onizleme"])){
				
				/* Bu aşamada formdaki bütün veriler sessiona kaydedilir... */
				
				$_SESSION["önizleme"] = $_POST;
				
				header("location:onizleme.php");
				
			}
		}	
	}
	
	//new dbug($_SESSION);

?>













































