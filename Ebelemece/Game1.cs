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

namespace Ebelemece
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        // genel
        bool baslangic = true;
        int menu = -1;
        SpriteFont font;
        SpriteFont baslik;
        Texture2D araclar;
        string[] isim = new string[12];
        string[] dosyakonumu = new string[12];

        // menü
        Vector3[] tablo = new Vector3[12];
        int sýra = 0;
        Vector2 arackoordinat = new Vector2(0, 50);
        Texture2D tab;

        // oyun
        Texture2D zemin;
        int[] hizsayar = { 0, 0, 0, 0, 0, 0, 0, 0 };
        string[] ad = new string[8];
        string[] dosya = new string[8];
        int sayac = 0;
        int bomba = 9;
        Vector2[] arabakoordinat = new Vector2[8];
        float[] hiz = new float[12];
        float[] oan = new float[8];
        float[] maximumhiz = new float[8];
        int sss = 0;
        float[] hizlanma = new float[8];
        float[] hizkazanci = new float[8];
        float[] acc = new float[12];
        float[] yon = new float[8];
        float[] donustehizkaybi = new float[12];
        int[] yariscisiram = new int[8];
        string text = "Oyun Basladi Bomba Bekleniyor";
        bool oyunbasladi = true;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            //graphics.IsFullScreen = true;
            graphics.ApplyChanges();
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            font = Content.Load<SpriteFont>("Courier New");
            baslik = Content.Load<SpriteFont>("SpriteFont1");
            tab = Content.Load<Texture2D>("gray");
            zemin = Content.Load<Texture2D>("land");

            //Oyundakiler
            arabakoordinat[0] = new Vector2(100,100);
            arabakoordinat[1] = new Vector2(100,500);
            arabakoordinat[2] = new Vector2(300, 100);
            arabakoordinat[3] = new Vector2(300, 500);
            arabakoordinat[4] = new Vector2(500, 100);
            arabakoordinat[5] = new Vector2(500, 500);
            arabakoordinat[6] = new Vector2(700, 100);
            arabakoordinat[7] = new Vector2(700, 500);

            //Champion
            isim[0] = "Champion";
            dosyakonumu[0] = "champ";
            tablo[0] = new Vector3(7,10,6);
            hiz[0] = 10.5f;
            acc[0] = 0.24f;
            donustehizkaybi[0] = 0.1f;

            //Leader
            isim[1] = "Leader";
            dosyakonumu[1] = "leader";
            tablo[1] = new Vector3(10, 9, 4);
            hiz[1] = 12;
            acc[1] = 0.22f;
            donustehizkaybi[1] = 0.15f;

            //Golden
            isim[2] = "Golden";
            dosyakonumu[2] = "golden";
            tablo[2] = new Vector3(9, 8, 6);
            hiz[2] = 11.5f;
            acc[2] = 0.2f;
            donustehizkaybi[2] = 0.1f;

            //Mafia
            isim[3] = "Mafia";
            dosyakonumu[3] = "mafia";
            tablo[3] = new Vector3(8, 6, 8);
            hiz[3] = 11;
            acc[3] = 0.16f;
            donustehizkaybi[3] = 0.05f;

            //SC 2000
            isim[4] = "SC 2000";
            dosyakonumu[4] = "sc";
            tablo[4] = new Vector3(3, 14, 8);
            hiz[4] = 8.5f;
            acc[4] = 0.44f;
            donustehizkaybi[4] = 0.05f;

            //RGB
            isim[5] = "RGB";
            dosyakonumu[5] = "rgb";
            tablo[5] = new Vector3(7, 8, 6);
            hiz[5] = 10.5f;
            acc[5] = 0.2f;
            donustehizkaybi[5] = 0.1f;

            //Sketch
            isim[6] = "Sketch";
            dosyakonumu[6] = "sketch";
            tablo[6] = new Vector3(5, 8, 8);
            hiz[6] = 9.5f;
            acc[6] = 0.2f;
            donustehizkaybi[6] = 0.05f;

            //Guide
            isim[7] = "Guide";
            dosyakonumu[7] = "guide";
            tablo[7] = new Vector3(4, 10, 8);
            hiz[7] = 9;
            acc[7] = 0.24f;
            donustehizkaybi[7] = 0.05f;

            //X
            isim[8] = "X";
            dosyakonumu[8] = "x";
            tablo[8] = new Vector3(7, 6, 8);
            hiz[8] = 10.5f;
            acc[8] = 0.16f;
            donustehizkaybi[8] = 0.05f;

            //Mixer
            isim[9] = "Mixer";
            dosyakonumu[9] = "mixer";
            tablo[9] = new Vector3(6, 8, 7);
            hiz[9] = 10f;
            acc[9] = 0.2f;
            donustehizkaybi[9] = 0.7f;

            //Zr Lost
            isim[10] = "Zr Lost";
            dosyakonumu[10] = "zr";
            tablo[10] = new Vector3(11, 2, 12);
            hiz[10] = 12;
            acc[10] = 0.08f;
            donustehizkaybi[10] = 0f;

            //Snake
            isim[11] = "Snake";
            dosyakonumu[11] = "snake";
            tablo[11] = new Vector3(13, 8, 3);
            hiz[11] = 14;
            acc[11] = 0.2f;
            donustehizkaybi[11] = 0.17f;
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }
        bool basildi = false;
        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            KeyboardState klavye = Keyboard.GetState();
            if (klavye.IsKeyDown(Keys.Escape))
            {
                this.Exit();
            }

            if (menu == -1 && klavye.IsKeyDown(Keys.Space))
            {
                menu = 0;
            }

            if (menu == 0)
            {
                if (klavye.IsKeyDown(Keys.Left))
                {
                    if (!basildi)
                    {
                        basildi = true;
                        arackoordinat.X -= 375;
                        sýra--;
                    }
                }
                else if (klavye.IsKeyDown(Keys.Right))
                {
                    if (!basildi)
                    {
                        basildi = true;
                        arackoordinat.X += 375;
                        sýra++;
                    }
                }
                else
                {
                    basildi = false;
                }
                if (sýra <= -1)
                {
                    sýra = 11;
                    arackoordinat.X = 375 * 11;
                }
                if (sýra >= 12)
                {
                    sýra = 0;
                    arackoordinat.X = 0;
                }
                if (klavye.IsKeyDown(Keys.Enter))
                {
                    menu = 1;
                    bas:
                    Random rnd = new Random();
                    yariscisiram[0] = sýra;
                    yariscisiram[1] = rnd.Next(0, 12);
                    yariscisiram[2] = rnd.Next(0, 12);
                    yariscisiram[3] = rnd.Next(0, 12);
                    yariscisiram[4] = rnd.Next(0, 12);
                    yariscisiram[5] = rnd.Next(0, 12);
                    yariscisiram[6] = rnd.Next(0, 12);
                    yariscisiram[7] = rnd.Next(0, 12);
                    if (yariscisiram[0] == yariscisiram[1] || yariscisiram[0] == yariscisiram[2] || yariscisiram[0] == yariscisiram[3] || yariscisiram[0] == yariscisiram[4] || yariscisiram[0] == yariscisiram[5] || yariscisiram[0] == yariscisiram[6] || yariscisiram[0] == yariscisiram[7] || yariscisiram[1] == yariscisiram[2] || yariscisiram[1] == yariscisiram[3] || yariscisiram[1] == yariscisiram[4] || yariscisiram[1] == yariscisiram[5] || yariscisiram[1] == yariscisiram[6] || yariscisiram[1] == yariscisiram[7] || yariscisiram[2] == yariscisiram[3] || yariscisiram[2] == yariscisiram[4] || yariscisiram[2] == yariscisiram[5] || yariscisiram[2] == yariscisiram[6] || yariscisiram[2] == yariscisiram[7] || yariscisiram[3] == yariscisiram[4] || yariscisiram[3] == yariscisiram[5] || yariscisiram[3] == yariscisiram[6] || yariscisiram[3] == yariscisiram[7] || yariscisiram[4] == yariscisiram[5] || yariscisiram[4] == yariscisiram[6] || yariscisiram[4] == yariscisiram[7] || yariscisiram[5] == yariscisiram[6] || yariscisiram[5] == yariscisiram[7] || yariscisiram[6] == yariscisiram[7])
                    {
                        goto bas;
                    }
                }
            }

            if (menu == 1)
            {
                if (klavye.IsKeyDown(Keys.Space))
                {
                    menu = 2;
                    for (int i = 0; i < 8; i++)
                    {
                        int ii = yariscisiram[i];
                        maximumhiz[i] = hiz[ii];
                        hizlanma[i] = acc[ii];
                        hizkazanci[i] = donustehizkaybi[ii];
                        ad[i] = isim[ii];
                        dosya[i] = dosyakonumu[ii];
                        yon[i] = 0;
                        oan[i] = 0;
                    }
                    sayac = 6000;
                }
            }

            if (menu == 2)
            {
                if (klavye.IsKeyDown(Keys.Z))
                {
                    baslangic = true;
                    oan[0] = 0;
                    for (int i = 1; i < 8; i++)
                    {
                        oan[i] = 0;
                    }
                    oyunbasladi = true;
                    bomba = 9;
                    text = "Oyun Basladi Bomba Bekleniyor";
                    menu = -1;
                    arabakoordinat[0] = new Vector2(100, 100);
                    arabakoordinat[1] = new Vector2(100, 500);
                    arabakoordinat[2] = new Vector2(300, 100);
                    arabakoordinat[3] = new Vector2(300, 500);
                    arabakoordinat[4] = new Vector2(500, 100);
                    arabakoordinat[5] = new Vector2(500, 500);
                    arabakoordinat[6] = new Vector2(700, 100);
                    arabakoordinat[7] = new Vector2(700, 500);
                }
                if (sayac == 5500)
                {
                    Random rnd = new Random();
                    bomba = rnd.Next(0, 8);
                    text = ad[bomba] + " Bomba Oldu";
                }
                if (sss > 0)
                {
                    sss++;
                    if (sss > 30)
                    {
                        sss = 0;
                    }
                }
                sayac--;
                if (sayac == 0)
                {
                    oyunbasladi = false;
                }

                if (oyunbasladi && menu == 2)
                {
                    //çarpýþma algoritmasý
                    if (sayac < 5500)
                    {
                        for (int i = 0; i < 8; i++)
                        {
                            if (bomba == i)
                            {
                            }
                            else if (arabakoordinat[bomba].X + 15 > arabakoordinat[i].X && arabakoordinat[bomba].X - 15 < arabakoordinat[i].X && arabakoordinat[bomba].Y + 15 > arabakoordinat[i].Y && arabakoordinat[bomba].Y - 15 < arabakoordinat[i].Y && sss == 0)
                            {
                                sss = 1;
                                bomba = i;
                                text = "Bomba " + ad[i] + "'de";
                            }
                        }
                    }

                    // oyuncu kontrolleri
                    
                    if (klavye.IsKeyDown(Keys.Left))
                    {
                        yon[0] -= 0.1f;
                        oan[0] -= hizkazanci[0];
                        oan[0] -= hizlanma[0];
                        if (oan[0] < 5 && hizkazanci[0] > 0)
                        {
                            oan[0] = 5;
                        }
                    }
                    if (klavye.IsKeyDown(Keys.Right))
                    {
                        yon[0] += 0.1f;
                        oan[0] -= hizkazanci[0];
                        oan[0] -= hizlanma[0];
                        if (oan[0] < 5 && hizkazanci[0] > 0)
                        {
                            oan[0] = 5;
                        }
                    }
                    if (sayac < 5500)
                    {
                        oan[0] += hizlanma[0];
                        if (oan[0] > maximumhiz[0])
                        {
                            oan[0] = maximumhiz[0];
                        }
                    }
                    if (arabakoordinat[0].X < 0)
                    {
                        arabakoordinat[0].X = 0;
                        oan[0] = 1;
                    }
                    else if (arabakoordinat[0].X > 800)
                    {
                        arabakoordinat[0].X = 800;
                        oan[0] = 1;
                    }
                    if (arabakoordinat[0].Y < 0)
                    {
                        arabakoordinat[0].Y = 0;
                        oan[0] = 1;
                    }
                    else if (arabakoordinat[0].Y > 600)
                    {
                        arabakoordinat[0].Y = 600;
                        oan[0] = 1;
                    }
                    arabakoordinat[0].X += (float)(oan[0] * Math.Cos(yon[0]));
                    arabakoordinat[0].Y += (float)(oan[0] * Math.Sin(yon[0]));

                    //yapay zeka
                    if (sayac < 5500)
                    {
                        for (int i = 1; i < 8; i++)
                        {
                            if (bomba == i)
                            {
                                if (sayac < 5500 && menu == 2)
                                {
                                    Random rnd = new Random();
                                    int a = rnd.Next(1, 100);
                                    if (a < 24)
                                    {
                                        yon[i] -= 0.1f;
                                    }
                                    if (a < 47)
                                    {
                                        yon[i] += 0.1f;
                                    }
                                    oan[i] += hizlanma[i];
                                    if (oan[i] > maximumhiz[i])
                                    {
                                        oan[i] = maximumhiz[i];
                                    }
                                    if (arabakoordinat[i].X < 50)
                                    {
                                        arabakoordinat[i].X = 50;
                                        yon[i] = 0f;
                                    }
                                    else if (arabakoordinat[i].X > 750)
                                    {
                                        arabakoordinat[i].X = 750;
                                        yon[i] = 3.14f;
                                    }
                                    if (arabakoordinat[i].Y < 50)
                                    {
                                        arabakoordinat[i].Y = 50;
                                        yon[i] = 1.57f;
                                    }
                                    else if (arabakoordinat[i].Y > 550)
                                    {
                                        arabakoordinat[i].Y = 550;
                                        yon[i] -= -1.57f;
                                    }
                                    if (arabakoordinat[i].Y >= 550 && arabakoordinat[i].X >= 750)
                                    {
                                        yon[i] = -2.25f;
                                    }
                                    if (arabakoordinat[i].Y <= 50 && arabakoordinat[i].X >= 750)
                                    {
                                        yon[i] = 2.25f;
                                    }
                                    if (arabakoordinat[i].Y >= 550 && arabakoordinat[i].X <= 50)
                                    {
                                        yon[i] = -0.75f;
                                    }
                                    if (arabakoordinat[i].Y <= 50 && arabakoordinat[i].X <= 50)
                                    {
                                        yon[i] = 0.75f;
                                    }
                                    arabakoordinat[i].X += (float)(oan[i] * Math.Cos(yon[i]));
                                    arabakoordinat[i].Y += (float)(oan[i] * Math.Sin(yon[i]));
                                }
                            }
                            else
                            {
                                oan[i] += hizlanma[i];
                                if (oan[i] > maximumhiz[i])
                                {
                                    oan[i] = maximumhiz[i];
                                }
                                if (sayac < 5500 && menu == 2)
                                {
                                    if (arabakoordinat[bomba].X >= arabakoordinat[i].X && arabakoordinat[bomba].Y >= arabakoordinat[i].Y && yon[i] < 0.75f)
                                    {
                                        yon[i] += 0.15f;
                                        hizsayar[i]++;
                                        if (hizsayar[i] > 20)
                                        {
                                            oan[i] -= hizkazanci[i];
                                            oan[i] -= hizlanma[i];
                                        }
                                        if (hizsayar[i] > 40)
                                        {
                                            hizsayar[i] = 0;
                                        }
                                        if (oan[i] < 5 && hizkazanci[i] > 0)
                                        {
                                            oan[i] = 5;
                                        }
                                    }
                                    else if (arabakoordinat[bomba].X > arabakoordinat[i].X && arabakoordinat[bomba].Y > arabakoordinat[i].Y && yon[i] > 0.75f && yon[i] > 4f && yon[i] < 6.29f)
                                    {
                                        yon[i] += 0.15f;
                                        hizsayar[i]++;
                                        if (hizsayar[i] > 20)
                                        {
                                            oan[i] -= hizkazanci[i];
                                            oan[i] -= hizlanma[i];
                                        }
                                        if (hizsayar[i] > 40)
                                        {
                                            hizsayar[i] = 0;
                                        }
                                        if (oan[i] < 5 && hizkazanci[i] > 0)
                                        {
                                            oan[i] = 5;
                                        }
                                    }
                                    else if (arabakoordinat[bomba].X > arabakoordinat[i].X && arabakoordinat[bomba].Y > arabakoordinat[i].Y && yon[i] > 0.75f)
                                    {
                                        yon[i] -= 0.15f;
                                        hizsayar[i]++;
                                        if (hizsayar[i] > 20)
                                        {
                                            oan[i] -= hizkazanci[i];
                                            oan[i] -= hizlanma[i];
                                        }
                                        if (hizsayar[i] > 40)
                                        {
                                            hizsayar[i] = 0;
                                        }
                                        if (oan[i] < 5 && hizkazanci[i] > 0)
                                        {
                                            oan[i] = 5;
                                        }
                                    }
                                    else if (arabakoordinat[bomba].X <= arabakoordinat[i].X && arabakoordinat[bomba].Y >= arabakoordinat[i].Y && yon[i] < 2.25f)
                                    {
                                        yon[i] += 0.15f;
                                        hizsayar[i]++;
                                        if (hizsayar[i] > 20)
                                        {
                                            oan[i] -= hizkazanci[i];
                                            oan[i] -= hizlanma[i];
                                        }
                                        if (hizsayar[i] > 40)
                                        {
                                            hizsayar[i] = 0;
                                        }
                                        if (oan[i] < 5 && hizkazanci[i] > 0)
                                        {
                                            oan[i] = 5;
                                        }
                                    }
                                    else if (arabakoordinat[bomba].X < arabakoordinat[i].X && arabakoordinat[bomba].Y > arabakoordinat[i].Y && yon[i] > 2.25f)
                                    {
                                        yon[i] -= 0.15f;
                                        hizsayar[i]++;
                                        if (hizsayar[i] > 20)
                                        {
                                            oan[i] -= hizkazanci[i];
                                            oan[i] -= hizlanma[i];
                                        }
                                        if (hizsayar[i] > 40)
                                        {
                                            hizsayar[i] = 0;
                                        }
                                        if (oan[i] < 5 && hizkazanci[i] > 0)
                                        {
                                            oan[i] = 5;
                                        }
                                    }
                                    else if (arabakoordinat[bomba].X >= arabakoordinat[i].X && arabakoordinat[bomba].Y <= arabakoordinat[i].Y && yon[i] < 5.55f && yon[i] < 2f && yon[i] > 0f)
                                    {
                                        yon[i] -= 0.15f;
                                        hizsayar[i]++;
                                        if (hizsayar[i] > 20)
                                        {
                                            oan[i] -= hizkazanci[i];
                                            oan[i] -= hizlanma[i];
                                        }
                                        if (hizsayar[i] > 40)
                                        {
                                            hizsayar[i] = 0;
                                        }
                                        if (oan[i] < 5 && hizkazanci[i] > 0)
                                        {
                                            oan[i] = 5;
                                        }
                                    }
                                    else if (arabakoordinat[bomba].X >= arabakoordinat[i].X && arabakoordinat[bomba].Y <= arabakoordinat[i].Y && yon[i] < 5.55f)
                                    {
                                        yon[i] += 0.15f;
                                        hizsayar[i]++;
                                        if (hizsayar[i] > 20)
                                        {
                                            oan[i] -= hizkazanci[i];
                                            oan[i] -= hizlanma[i];
                                        }
                                        if (hizsayar[i] > 40)
                                        {
                                            hizsayar[i] = 0;
                                        }
                                        if (oan[i] < 5 && hizkazanci[i] > 0)
                                        {
                                            oan[i] = 5;
                                        }
                                    }
                                    else if (arabakoordinat[bomba].X > arabakoordinat[i].X && arabakoordinat[bomba].Y < arabakoordinat[i].Y && yon[i] > 5.55f)
                                    {
                                        yon[i] -= 0.15f;
                                        hizsayar[i]++;
                                        if (hizsayar[i] > 20)
                                        {
                                            oan[i] -= hizkazanci[i];
                                            oan[i] -= hizlanma[i];
                                        }
                                        if (hizsayar[i] > 40)
                                        {
                                            hizsayar[i] = 0;
                                        }
                                        if (oan[i] < 5 && hizkazanci[i] > 0)
                                        {
                                            oan[i] = 5;
                                        }
                                    }
                                    else if (arabakoordinat[bomba].X <= arabakoordinat[i].X && arabakoordinat[bomba].Y <= arabakoordinat[i].Y && yon[i] < 4.05f)
                                    {
                                        yon[i] += 0.15f;
                                        hizsayar[i]++;
                                        if (hizsayar[i] > 20)
                                        {
                                            oan[i] -= hizkazanci[i];
                                            oan[i] -= hizlanma[i];
                                        }
                                        if (hizsayar[i] > 40)
                                        {
                                            hizsayar[i] = 0;
                                        }
                                        if (oan[i] < 5 && hizkazanci[i] > 0)
                                        {
                                            oan[i] = 5;
                                        }
                                    }
                                    else if (arabakoordinat[bomba].X < arabakoordinat[i].X && arabakoordinat[bomba].Y < arabakoordinat[i].Y && yon[i] > 4.05f)
                                    {
                                        yon[i] -= 0.15f;
                                        hizsayar[i]++;
                                        if (hizsayar[i] > 20)
                                        {
                                            oan[i] -= hizkazanci[i];
                                            oan[i] -= hizlanma[i];
                                        }
                                        if (hizsayar[i] > 40)
                                        {
                                            hizsayar[i] = 0;
                                        }
                                        if (oan[i] < 5 && hizkazanci[i] > 0)
                                        {
                                            oan[i] = 5;
                                        }
                                    }
                                    arabakoordinat[i].X += (float)(oan[i] * Math.Cos(yon[i]));
                                    arabakoordinat[i].Y += (float)(oan[i] * Math.Sin(yon[i]));
                                    if (arabakoordinat[i].X < 0)
                                    {
                                        arabakoordinat[i].X = 0;
                                        yon[i] = 0f;
                                        Random rnd = new Random();
                                        int a = rnd.Next(0,100);
                                        if (a < 40)
                                        {
                                            oan[i] = 5;
                                        }
                                    }
                                    else if (arabakoordinat[i].X > 800)
                                    {
                                        arabakoordinat[i].X = 800;
                                        yon[i] = 3.14f;
                                        Random rnd = new Random();
                                        int a = rnd.Next(0, 100);
                                        if (a < 40)
                                        {
                                            oan[i] = 5;
                                        }
                                    }
                                    if (arabakoordinat[i].Y < 0)
                                    {
                                        arabakoordinat[i].Y = 0;
                                        yon[i] = 1.57f;
                                        Random rnd = new Random();
                                        int a = rnd.Next(0, 100);
                                        if (a < 40)
                                        {
                                            oan[i] = 5;
                                        }
                                    }
                                    else if (arabakoordinat[i].Y > 600)
                                    {
                                        arabakoordinat[i].Y = 600;
                                        yon[i] = 3.75f;
                                        Random rnd = new Random();
                                        int a = rnd.Next(0, 100);
                                        if (a < 40)
                                        {
                                            oan[i] = 5;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Gray);
            spriteBatch.Begin();
            if (menu == 0)
            {
                for (int i = 0; i < 12; i++)
                {
                    araclar = Content.Load<Texture2D>(dosyakonumu[i]);
                    spriteBatch.Draw(araclar, new Rectangle((int)(((i + 1) * 375) - arackoordinat.X),50,50,50),Color.White);
                    spriteBatch.DrawString(font, isim[sýra], new Vector2(375, 100), Color.Black);
                    spriteBatch.DrawString(font, "MAXIMUM HIZ:", new Vector2(20, 200), Color.Red);
                    spriteBatch.DrawString(font, "HIZLANMA HIZI:", new Vector2(20, 250), Color.Red);
                    spriteBatch.DrawString(font, "DONUSLERDE HIZ KAZANCI:", new Vector2(20, 300), Color.Red);
                    spriteBatch.Draw(tab, new Rectangle(230, 200, (int)(tablo[sýra].X) * 25, 30), Color.DarkGray);
                    spriteBatch.Draw(tab, new Rectangle(230, 250, (int)(tablo[sýra].Y) * 25, 30), Color.DarkGray);
                    spriteBatch.Draw(tab, new Rectangle(230, 300, (int)(tablo[sýra].Z) * 25, 30), Color.DarkGray);
                }
                spriteBatch.DrawString(font, isim[sýra] + "'I/U SECMEK ICIN ENTER'A BASIN", new Vector2(300, 500), Color.Red);
            }
            if (menu == 1)
            {
                for (int i = 0; i < 8; i++)
                {
                    for (int ii = 0; ii < 12; ii++)
                    {
                        if (yariscisiram[i] == ii)
                        {
                            araclar = Content.Load<Texture2D>(dosyakonumu[ii]);
                            if (i == 0)
                            {
                                spriteBatch.Draw(araclar, new Rectangle(50, i * 50 + 100, 50, 50), Color.White);
                                spriteBatch.DrawString(font, isim[ii] + " (Oyuncu)", new Vector2(150, i * 50 + 100), Color.Black);
                            }
                            else
                            {
                                spriteBatch.Draw(araclar, new Rectangle(50, i * 50 + 100, 50, 50), Color.White);
                                spriteBatch.DrawString(font, isim[ii] + " (Bilgisayar)", new Vector2(150, i * 50 + 100), Color.Black);
                            }
                        }
                    }
                }
                spriteBatch.DrawString(font, "EBELEMECEYE KATILANLAR", new Vector2(100, 50), Color.Red);
                spriteBatch.DrawString(font, "BASLAMAK ICIN BOSLUGA BASIN", new Vector2(100, 500), Color.Red);
            }
            if (menu == 2)
            {
                spriteBatch.Draw(zemin, new Rectangle(0, 0, 800, 600), new Rectangle(0, 0, 10, 10), Color.White);
                for (int i = 0; i < 8; i++)
                {
                    if (bomba == i)
                    {
                        araclar = Content.Load<Texture2D>("bomba");
                    }
                    else
                    {
                        araclar = Content.Load<Texture2D>(dosya[i]);
                    }
                    spriteBatch.Draw(araclar, new Rectangle((int)arabakoordinat[i].X, (int)arabakoordinat[i].Y, 50, 50), new Rectangle(0,0,50,50), new Color(255,255,255),yon[i], new Vector2(araclar.Width/2,araclar.Height/2),SpriteEffects.None,0);
                    if (!oyunbasladi)
                    {
                        if (bomba == 0)
                        {
                            spriteBatch.DrawString(font, "PATLADINIZ (OYUNU KAZANDINIZ) YENI OYUN ICIN Z TUSUNA BASIN)", new Vector2(100, 300), Color.Red);
                        }
                        else
                        {
                            spriteBatch.DrawString(font, ad[bomba] + " PATLADI (OYUNU KAZANDI) YENI OYUN ICIN Z TUSUNA BASIN", new Vector2(100, 300), Color.Red);
                        }
                    }
                }
                if (sayac < 1000)
                {
                    spriteBatch.DrawString(font, "" + (int)(sayac / 100), new Vector2(750, 40),new Color(250,0,0));
                }
                else if (sayac < 2000)
                {
                    spriteBatch.DrawString(font, "" + (int)(sayac / 100), new Vector2(750, 40), new Color(250, 125, 0));
                }
                else if (sayac < 3000)
                {
                    spriteBatch.DrawString(font, "" + (int)(sayac / 100), new Vector2(750, 40), new Color(250, 220, 0));
                }
                else if (sayac < 4000)
                {
                    spriteBatch.DrawString(font, "" + (int)(sayac / 100), new Vector2(750, 40), new Color(220, 250, 0));
                }
                else if (sayac < 5000)
                {
                    spriteBatch.DrawString(font, "" + (int)(sayac / 100), new Vector2(750, 40), new Color(125, 250, 0));
                }
                else if (sayac < 6000)
                {
                    spriteBatch.DrawString(font, "" + (int)(sayac / 100), new Vector2(750, 40), new Color(0, 250, 0));
                }
                spriteBatch.DrawString(font, "HIZ: " + (int)oan[0], new Vector2(30, 550), Color.Black);
                spriteBatch.DrawString(font, text, new Vector2(30, 30), Color.Red);
            }
            if (menu == -1)
            {
                spriteBatch.DrawString(baslik, "EBELEMECE", new Vector2(250, 100), Color.Black);
                Random rnd = new Random();
                if (baslangic)
                {
                    baslangic = false;
                    int a = rnd.Next(0,12);
                    if (a == 0 || a == 1 || a == 2)
                    {
                        araclar = Content.Load<Texture2D>("champ");
                    }
                    else if (a == 3 || a == 4 || a == 5)
                    {
                        araclar = Content.Load<Texture2D>("leader");
                    }
                    else if (a == 6)
                    {
                        araclar = Content.Load<Texture2D>("mafia");
                    }
                    else if (a == 7 || a == 8)
                    {
                        araclar = Content.Load<Texture2D>("sketch");
                    }
                    else if (a == 9 || a == 10)
                    {
                        araclar = Content.Load<Texture2D>("zr");
                    }
                    else
                    {
                        araclar = Content.Load<Texture2D>("snake");
                    }
                }
                spriteBatch.Draw(araclar, new Rectangle(300, 300, 200, 200), new Rectangle(0, 0, 50, 50), Color.White);
                spriteBatch.DrawString(font, "Baslamak icin bosluga basin", new Vector2(300, 500), Color.Black);
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
