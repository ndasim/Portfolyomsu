using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Windows.Forms;
using fizik_motoru;

namespace metal_tank_savaşı
{
    class oyun_kontrolü
    {

        public event Game1.merkez asım;

        public Texture2D resim;
        public float açı;
        public bool görünürlük;
        public Vector2 koord = new Vector2();
        int numaram;
        Game1 çizdirgeç;
        SpriteFont font;

        public oyun_kontrolü(Game1 oyun,Texture2D gösterilecek_resim) 
        {
            resim = gösterilecek_resim;
            çizdirgeç = oyun;
            oyun.tik += new Game1.merkez(oyun_kontrolü_asım);
            font = oyun.Content.Load<SpriteFont>("SpriteFont1");
        }

        public void oyun_kontrolü_asım()
        {
            //Console.WriteLine("asım" + numaram );
            çizdirgeç.spriteBatch.Begin(SpriteBlendMode.AlphaBlend);
            çizdirgeç.spriteBatch.Draw(resim, koord, null,Color.White,açı,new Vector2(50,50),1.0f,SpriteEffects.None,0);
            çizdirgeç.spriteBatch.DrawString(font, Convert.ToString(açı), new Vector2(20, 20), Color.Red, 0.0f, new Vector2(0, 0), 2.0f, SpriteEffects.None, 1f);
            çizdirgeç.spriteBatch.End();
        }

        public oyun_kontrolü(ref int i)
        {
        }

    }

    class tank
    {
        string kilit_ad;                        // Kilitlenilen tankın adı
        int Tank_Adı;                           // Tankın Mesajlaşma Adı
        bool kitlenme;                          // Bir hedefe kilitlendiğini belirtir
        float ilerleme_yönü;                    // Tankın ilerleme yönü
        int ilerletme_adımları;                 // Tnakın yön değiştirmesi için bazı hareketlerin sıralanmasında kullanılır
        float açı = 0f;
        Vector2[] güzergah = new Vector2[1000]; // Tankın güzergah adresi

        Vector2 refnok;                         // Tankın ilerlemeye başlama noktasıdır 
        Timer ilerletici;                       // Tankın belirli hızda ilerleme fonsiyonu için
        Timer zamanalayıcı;                     // Ateş etmek gibi fonksiyonları gerçekleştirmek için kullanılacak olan timer
        Vector2 koord;                          // Tankın bulunduğu analitik koord
        Point matrix_koord;                     // Tankın bulunduğu matrix koord
        Point hedef_matrix;                     // Tankın ilerlemek için kitlendiği matrix
        oyun_kontrolü Tank;                     // Tankın ta kendisi
        oyun_kontrolü tank_başlığı;             // Tankın ateş eden gövdesi
        nokta_haritası matrix;                  // Matrix koordinatlarında hareket için kullanılan sınıf
        renk renk_okuma ;

        string adım;

        int hız;
        int can;

        public tank(int tank_adı,nokta_haritası Matrix,Game1 oyun,Point çıkış_matrix)
        {
            #region zamanlayıcıların ayarlanması
            ilerletici = new Timer() ;
            zamanalayıcı = new Timer();

            #endregion

            #region eventlerin ayarlanması

            oyun.mesaj += new Game1.mesajmerkezi(hedefi_ayrıştır);
            this.ilerletici.Tick += new EventHandler(ilerletici_Tick);
            this.zamanalayıcı.Tick += new EventHandler(zamanalayıcı_Tick);

            #endregion

            Tank_Adı = tank_adı; // Tank adının yüklenmesi

            Tank = new oyun_kontrolü(oyun, oyun.Content.Load<Texture2D>("tank-gövde")); // Nesne yüklenmesi

            güzergahı_hazırla();

            #region fizik motoruna kayıt
            matrix = Matrix;
            renk_okuma = matrix.noktanın_değerin_oku(çıkış_matrix.X, çıkış_matrix.Y);
            Matrix.noktaya_değer_Ata(çıkış_matrix.X,çıkış_matrix.Y,new renk(1,tank_adı,0,0));

            #endregion 

            #region çıkış koordinatının ayarlanması

            if (renk_okuma.değer_ == 1)
            { matrix_koord = çıkış_matrix; matrix_koord.X += 1; }
            else
            { matrix_koord = çıkış_matrix; }

            koord.X  = matrix_koord.X * 100 + 50;
            koord.Y = matrix_koord.Y * 100 + 50;

            Tank.koord = koord;

            #endregion
        }

        void yinele()
        { }

        void ilerle()
        {
            // Yön Belirleme
            ilerleme_yönü = Convert.ToSingle(Math.Atan2(hedef_matrix.Y - matrix_koord.Y, hedef_matrix.X - matrix_koord.X) * 180 / Math.PI);

            ilerleme_yönü = Convert.ToSingle(Convert.ToInt32(ilerleme_yönü));

            // referans noktası tanklın bulunduğu nokta
            refnok = koord;
            ilerletme_adımları = 1;
            ilerletici.Interval = 1;
            ilerletici.Enabled = true;
        }

        void güzergahı_hazırla()
        {
            int i = 0;
            for (i = 0; i < 1000; i++)
            {
                güzergah[i] = new Vector2(0, 0);
            }
        }

        void güzergah_belirle()
        {

            int uzaklık = 2;
            int i;
            renk r;
            float  x = 0, y = 0;
            
            for (i = 0 ; i < uzaklık ; i++)

            // X koordiantının kontrol edilmesi

            if (matrix_koord.X == hedef_matrix.X)
            {
                y += 1;
                x = matrix_koord.X;
                r = matrix.noktanın_değerin_oku(x,y);
                if (r.değer_  == 1)
                {
                    x += 1;
                    r = matrix.noktanın_değerin_oku(x, y);
                    if (r.değer_ == 1)
                    {
                        x -= 2;
                        r = matrix.noktanın_değerin_oku(x, y);
                        if (r.değer_ == 1)
                        {
                            y -= 1;
                            x += 2;
                            r = matrix.noktanın_değerin_oku(x, y);
                            if (r.değer_ == 1)
                            {
                                x -= 2;
                                r = matrix.noktanın_değerin_oku(x, y);
                                if (r.değer_ == 1)
                                {
                                    y -= 1;
                                    x += 2;
                                    r = matrix.noktanın_değerin_oku(x, y);
                                    if (r.değer_ == 1)
                                    {
                                        x -= 1;
                                        r = matrix.noktanın_değerin_oku (x, y);
                                        if (r.değer_ == 1)
                                        {
                                            x -= 1;
                                            r = matrix.noktanın_değerin_oku(x, y);
                                            if (r.değer_ == 1)
                                            {

                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            else if (matrix_koord.X < hedef_matrix.X)
            { 
            }
            else if (matrix_koord.X > hedef_matrix.X) 
            { 
            }

            // Y koordinatının kontrol edilmesi

            if (matrix_koord.Y == hedef_matrix.Y)
            {
            }
            else if (matrix_koord.Y < hedef_matrix.Y)
            {
            }
            else if (matrix_koord.Y > hedef_matrix.Y)
            {
            }
        }

        int i;
        private void ilerletici_Tick(object sender, EventArgs e)
        { 
            // Tank başlığını dönmesi
            if (ilerletme_adımları == 1)
            {
                //if (tank_başlığı.açı != ilerleme_yönü)
                //{
                    //tank_başlığı.açı += 1;
                //    tank_başlığı.açı = Convert.ToSingle(ilerleme_yönü);
                //}
                //else
                //{
                //    ilerletme_adımları = 2;
                //    i = 0;
                //}
            ilerletme_adımları = 2;
            }
            else if (ilerletme_adımları == 2)
            {
                if (Tank.açı != MathHelper.ToRadians(Math.Abs(ilerleme_yönü)))
                {
                    
                    açı += 1f; // ilerleme yönü double olduğu için tutmuyor

                    Tank.açı = MathHelper.ToRadians(açı);
                }
                else
                {
                    ilerletme_adımları = 3;
                }
            }
            else if (ilerletme_adımları == 3)
            {
                i += 1;
                matrix.noktaya_değer_Ata(Convert.ToInt32 ( (koord.X - 50 ) / 100),Convert.ToInt32( (koord.Y - 50) / 100), new renk(0));
                koord.X = refnok.X + Convert.ToSingle (i * Math.Cos(ilerleme_yönü * Math.PI / 180));
                koord.Y = refnok.Y + Convert.ToSingle(i * Math.Sin(ilerleme_yönü * Math.PI / 180));
                matrix.noktaya_değer_Ata(Convert.ToInt32((koord.X - 50) / 100), Convert.ToInt32((koord.Y - 50) / 100), new renk(1));

                Tank.koord = koord;

                if (Math.Abs(koord.X - 50) / 100 == hedef_matrix.X) 
                {
                    if (Math.Abs((koord.Y - 50) / 100) == hedef_matrix.Y)
                    { 
                        ilerletme_adımları = 0;
                        ilerletici.Enabled = false;
                    }
                    
                }

            }
        }

        private void zamanalayıcı_Tick(object sender, EventArgs e)
        {

        }

        void etrafı_tara()
        {

        }

        void ateş_et()
        { 
        
        }

        void hedefi_kontrol_et()
        { 
        
        }

        void hedefi_ayrıştır(int tank_adı, Point Hedef_matrix,bool düşman)
        {
            if (tank_adı == Tank_Adı)
            {
                hedef_matrix = Hedef_matrix;
                ilerle();
            }
        }

    }

    class mermi
    {
        Point başlamanok;
        double yön;
        oyun_kontrolü kurşun;

        public void mermi1(Game1 oyun)
        { 
        
        }

        void yenilen()
        { 
        
        }
    
    }

    class güdümlü_füze
    {
        Point başlama_nok;
        int fırlatma_yön;
    }
}
