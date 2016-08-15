using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;
using fizik_motoru;

namespace metal_tank_savaşı
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        fizik_motoru.nokta_haritası matrix;

        GraphicsDeviceManager graphics;
        oyun_kontrolü a;

        Texture2D matrix_belirtme;
        Texture2D nesne_seçme;
        Texture2D hedef_belirtme;
        Texture2D seçim_faresi;
        Texture2D Fare;

        Point matrix_koord;
        SpriteFont Font1;
        MouseState fare = Mouse.GetState();

        tank Tank;

        bool düşman_seçme = false ;

        public SpriteBatch spriteBatch;

        public delegate void merkez();
        public delegate void mesajmerkezi(int tank_adı, Point Hedef_matrix, bool düşman);

        public event mesajmerkezi mesaj;
        public event merkez tik;

        int seçilmiş_tank;
        

        //------------------------------------------------------------------------------------//

        public void çiz()
        {
            string ss;
            if (this.tik != null)
                this.tik();
            ss = matrix_koord.X + " " + matrix_koord.Y;
            spriteBatch.Begin();
            spriteBatch.DrawString(Font1, ss, new Vector2(10, 10), new Color(255, 255, 255));
            spriteBatch.Draw(seçim_faresi, new Vector2(matrix_koord.X * 100, matrix_koord.Y * 100), new Color(255, 2555, 255, 255));
            spriteBatch.Draw(Fare, new Vector2(fare.X, fare.Y), new Color(255, 255, 255, 255));
            spriteBatch.End();

        }

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

        }

        private void oyun_kontrolü_asım(bool i)
        {
            Console.WriteLine("asım");
        }

        protected override void Initialize()
        {

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            Font1 = Content.Load<SpriteFont>("SpriteFont1");

            hedef_belirtme = Content.Load<Texture2D>("hedef belirtme");
            matrix_belirtme = Content.Load<Texture2D>("boş");
            nesne_seçme = Content.Load<Texture2D>("seçim");
            Fare = Content.Load<Texture2D>("standart");

            seçim_faresi = matrix_belirtme;

            matrix = new nokta_haritası(10, 10);

            matrix.fiziksel_haritayı_göster();

            seçilmiş_tank = 0;

            Tank = new tank(1,matrix,this,new Point(1,1));

            düşman_seçme = false;
           // asım += new merkez (a.oyun_kontrolü_asım);
            
        }

        protected override void UnloadContent()
        {

        }

        void hareket_mesajı_gönder()
        {
            if (mesaj != null)
            {
                mesaj(seçilmiş_tank, matrix_koord, false);
            }
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed )
                this.Exit();
            fare = Mouse.GetState();

            renk  i = new renk();
            i = matrix.noktanın_değerin_oku(matrix_koord.X, matrix_koord.Y);

            #region koordinat ayarlama

            if (fare.X > 0)
            { matrix_koord.X = fare.X / 100; }

            if (fare.Y > 0)
            { matrix_koord.Y = fare.Y / 100; }

            if (i.değer_ == 1)
            {
                if (seçilmiş_tank != 1)
                {
                    seçim_faresi = nesne_seçme;
                }
                else
                {
                    seçim_faresi = hedef_belirtme;
                    // Düşman seçme olayı
                }
            }
            else 
            {
                if (düşman_seçme == true)
                { 
                    seçim_faresi = hedef_belirtme; 
                }
                else
                {seçim_faresi = matrix_belirtme; }
            }
            

            #endregion

            #region fare tıklama olayı

            if (fare.LeftButton == ButtonState.Pressed)
            {

               if (i.değer_ == 0)
               {
                   if (seçilmiş_tank == 0) { }
                   else 
                   {
                       hareket_mesajı_gönder();
                   } 
               }
               else if (i.değer_ == 1)
               {
                   seçilmiş_tank = i.değer_1;
                   düşman_seçme = true;
               }

            }

            if (fare.RightButton == ButtonState.Pressed)
            {
                seçilmiş_tank = 0;
            }

            #endregion

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            çiz();
            base.Draw(gameTime);
        }
    }
}