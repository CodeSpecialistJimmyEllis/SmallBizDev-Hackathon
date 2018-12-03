// IridelGameDepaul Game 85 //

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



namespace BlackStrength
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class ResumeVideoGame : GameScreen
    {

        #region Fields
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        LeapMotionButtons leapMotionButtons;

        bool playSound;
        Song deepestmasterofcode;
        Texture2D background;
        bool isHit;
        public bool IsHit { get { return isHit; } set { isHit = value; } }
        public enum WhichButtonHit
        {
            a, b, x, y, up, down, left, right
        }



        WhichButtonHit whichbuttonhit;
        public WhichButtonHit Whichbuttonhit
        {
            get
            {
                return whichbuttonhit;
            }

            set
            {
                whichbuttonhit = value;
            }
        }

        WhichButtonHit thebuttonhit;
        /*
        enum ButtonToHit
        {
            hita,hitb,hitx,hity,hitup,hitdown,hitleft,hitright
        }

        ButtonToHit buttontohit;
        */
        //gamepad 
        GamePadState gamepadstate;



        // Sprite Font for drawing words to the screen

        SpriteFont spritefont1;
        Color hitbuttoncolor;

        // Random number choosen
        Random random;
        int chosenrandom;


        //button textures and rectangles
        Texture2D A;
        Texture2D B;
        Texture2D X;
        Texture2D Y;

        Rectangle Arect;
        Rectangle Brect;
        Rectangle Xrect;
        Rectangle Yrect;

        Rectangle hitbuttonlocation;
        Texture2D start;
        Rectangle startrect;

        Texture2D select;
        Rectangle selectrect;

        Texture2D up;
        Rectangle uprect;

        Texture2D left;
        Rectangle leftrect;

        Texture2D down;
        Rectangle downrect;

        Texture2D right;
        Rectangle rightrect;

        Texture2D leftbutton;
        Rectangle leftbuttonrect;

        Texture2D rightbutton;
        Rectangle rightbuttonrect;

        Texture2D lefttrigger;
        Rectangle lefttriggerrect;

        Texture2D righttrigger;
        Rectangle righttriggerrect;

        Color buttoncolor;

        SoundEffect boom;
        // button hit variable locations and sizes
        int xaxis;
        int yaxis;
        int widthsize;
        int heightsize;
        Texture2D score;
        int scorenumber;

        // buton to hit variable location and sizes


        #region Code Fight GamePlay Code

        Texture2D JimmyEllis;
        Rectangle JimmyEllisRectangle;
        Color herocolor;
        Texture2D[] villians;
        Rectangle villiansrect;
        bool speedup;
        Texture2D heroprojectile;
        Rectangle heroprojectilerect;
        int heroprojectilespeed;
        Texture2D villianprojectile;
        Rectangle villianprojecticerect;
        Color villiancolor;
        int villianspeed;

        #endregion


        int hitxaxis;
        int hityaxis;

        int hitwidthsize;
        int hitheightsize;
        int state;
        #endregion

        #region Constructors
        public ResumeVideoGame(int newstate)
        {
            leapMotionButtons = new LeapMotionButtons();
            // TODO: Add your initialization logic here
            random = new Random();
            buttoncolor = new Color();
            buttoncolor = Color.White;

            scorenumber = 0;

            this.state = newstate;
            playSound = false;
            // setting of button to hit variables
            xaxis = 0;
            yaxis = 150;
            widthsize = 128;
            heightsize = 128;


            #region Code Fight Initialize
            herocolor = Color.White;
            villiancolor = Color.White;
            villianspeed = 1;
            JimmyEllisRectangle = new Rectangle(0, 300, 128, 128);
            villiansrect = new Rectangle(670, 300, 128, 128);

            heroprojectilerect = new Rectangle(50, 320, 64, 64);
            heroprojectilespeed = 100;
            villianprojecticerect = new Rectangle(670, 300, 128, 128);

            #endregion
            hitbuttoncolor = Color.Magenta;

            // setting of hit button variables
            hitxaxis = 650;
            hityaxis = 150;
            hitwidthsize = 128;
            hitheightsize = 128;
            hitbuttonlocation = new Rectangle(hitxaxis, hityaxis, hitwidthsize, hitheightsize);

            thebuttonhit = WhichButtonHit.a;

            #region Code Fight Code
            villians = new Texture2D[4];

            speedup = false;

            #endregion
            Arect = new Rectangle(xaxis, yaxis, widthsize, heightsize);
            Brect = new Rectangle(xaxis, yaxis, widthsize, heightsize);
            Xrect = new Rectangle(xaxis, yaxis, widthsize, heightsize);
            Yrect = new Rectangle(xaxis, yaxis, widthsize, heightsize);



            isHit = false;
            uprect = new Rectangle(xaxis, yaxis, widthsize, heightsize);
            downrect = new Rectangle(xaxis, yaxis, widthsize, heightsize);
            leftrect = new Rectangle(xaxis, yaxis, widthsize, heightsize);
            rightrect = new Rectangle(xaxis, yaxis, widthsize, heightsize);

            chosenrandom = 0;
            gamepadstate = new GamePadState();

        }


        public ResumeVideoGame()
        {
            leapMotionButtons = new LeapMotionButtons();
            // TODO: Add your initialization logic here
            random = new Random();
            buttoncolor = new Color();
            buttoncolor = Color.White;

            scorenumber = 0;

            state = 0;
            playSound = false;
            // setting of button to hit variables
            xaxis = 0;
            yaxis = 150;
            widthsize = 128;
            heightsize = 128;


            #region Code Fight Initialize
            herocolor = Color.White;
            villiancolor = Color.White;
            villianspeed = 1;
            JimmyEllisRectangle = new Rectangle(0, 300, 128, 128);
            villiansrect = new Rectangle(670, 300, 128, 128);

            heroprojectilerect = new Rectangle(50, 320, 64, 64);
            heroprojectilespeed = 100;
            villianprojecticerect = new Rectangle(670, 300, 128, 128);

            #endregion
            hitbuttoncolor = Color.Magenta;

            // setting of hit button variables
            hitxaxis = 650;
            hityaxis = 150;
            hitwidthsize = 128;
            hitheightsize = 128;
            hitbuttonlocation = new Rectangle(hitxaxis, hityaxis, hitwidthsize, hitheightsize);

            thebuttonhit = WhichButtonHit.a;

            #region Code Fight Code
            villians = new Texture2D[4];

            speedup = false;

            #endregion
            Arect = new Rectangle(xaxis, yaxis, widthsize, heightsize);
            Brect = new Rectangle(xaxis, yaxis, widthsize, heightsize);
            Xrect = new Rectangle(xaxis, yaxis, widthsize, heightsize);
            Yrect = new Rectangle(xaxis, yaxis, widthsize, heightsize);



            isHit = false;
            uprect = new Rectangle(xaxis, yaxis, widthsize, heightsize);
            downrect = new Rectangle(xaxis, yaxis, widthsize, heightsize);
            leftrect = new Rectangle(xaxis, yaxis, widthsize, heightsize);
            rightrect = new Rectangle(xaxis, yaxis, widthsize, heightsize);

            chosenrandom = 0;
            gamepadstate = new GamePadState();

        }
        #endregion

        #region LoadContent
        public override void LoadContent(ContentManager Content)
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            base.LoadContent(Content);
            boom = Content.Load<SoundEffect>("ResumeGamePlayState/boom");
            leapMotionButtons.LoadContent(Content);
            JimmyEllis = Content.Load<Texture2D>("ResumeGamePlayState/hero/hero");
            heroprojectile = Content.Load<Texture2D>("ResumeGamePlayState/hero/heroprojectile");
            villianprojectile = Content.Load<Texture2D>("ResumeGamePlayState/villians/villianprojectile");
            villians[0] = Content.Load<Texture2D>("ResumeGamePlayState/villians/villian01");
            villians[1] = Content.Load<Texture2D>("ResumeGamePlayState/villians/villian02");
            villians[2] = Content.Load<Texture2D>("ResumeGamePlayState/villians/villian03");
            villians[3] = Content.Load<Texture2D>("ResumeGamePlayState/villians/villian04");
            // backgroun
            background = Content.Load<Texture2D>("ResumeGamePlayState/background");
            A = Content.Load<Texture2D>("ResumeGamePlayState/buttonfolder/A");
            B = Content.Load<Texture2D>("ResumeGamePlayState/buttonfolder/B");
            X = Content.Load<Texture2D>("ResumeGamePlayState/buttonfolder/X");
            Y = Content.Load<Texture2D>("ResumeGamePlayState/buttonfolder/Y");
            /*
            start = Content.Load<Texture2D>("");
            select = Content.Load<Texture2D>("");
            */

            deepestmasterofcode = Content.Load<Song>("ResumeGamePlayState/bgmusic01");
            MediaPlayer.Play(deepestmasterofcode);
            //score image


            spritefont1 = Content.Load<SpriteFont>("ResumeGamePlayState/SpriteFont1");
            score = Content.Load<Texture2D>("ResumeGamePlayState/scoretext");

            left = Content.Load<Texture2D>("ResumeGamePlayState/buttonfolder/LEFT");
            right = Content.Load<Texture2D>("ResumeGamePlayState/buttonfolder/RIGHT");
            up = Content.Load<Texture2D>("ResumeGamePlayState/buttonfolder/UP");
            down = Content.Load<Texture2D>("ResumeGamePlayState/buttonfolder/DOWN");


            /*
            leftbutton = Content.Load<Texture2D>("");
            lefttrigger = Content.Load<Texture2D>("");

            righttrigger = Content.Load<Texture2D>("");
            rightbutton = Content.Load<Texture2D>("");
            */

        }
        #endregion

        #region UnloadContent

        public override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }
        #endregion

        #region Update
        public override void Update(GameTime gameTime)
        {
            // Allows the game to exit

            gamepadstate = GamePad.GetState(PlayerIndex.One);
            leapMotionButtons.Update(gameTime);
            #region read controller or keyboard to find out what is hit todo: leap motion support
            if (gamepadstate.IsButtonDown(Buttons.A) || Keyboard.GetState(PlayerIndex.One).IsKeyDown(Keys.A))
            {
                isHit = true;
                whichbuttonhit = WhichButtonHit.a;
                herocolor = Color.White;
            }

            else if (gamepadstate.IsButtonDown(Buttons.B) || Keyboard.GetState(PlayerIndex.One).IsKeyDown(Keys.B))
            {
                isHit = true;
                whichbuttonhit = WhichButtonHit.b;
                herocolor = Color.White;
            }

            else if (gamepadstate.IsButtonDown(Buttons.X) || Keyboard.GetState(PlayerIndex.One).IsKeyDown(Keys.X))
            {
                isHit = true;
                whichbuttonhit = WhichButtonHit.x;
                herocolor = Color.White;
            }

            else if (gamepadstate.IsButtonDown(Buttons.Y) || Keyboard.GetState(PlayerIndex.One).IsKeyDown(Keys.Y))
            {
                isHit = true;
                whichbuttonhit = WhichButtonHit.y;
                herocolor = Color.White;
            }



            else if (gamepadstate.IsButtonDown(Buttons.DPadUp) || Keyboard.GetState(PlayerIndex.One).IsKeyDown(Keys.Up))
            {
                isHit = true;
                whichbuttonhit = WhichButtonHit.up;
                herocolor = Color.White;
            }

            else if (gamepadstate.IsButtonDown(Buttons.DPadDown) || Keyboard.GetState(PlayerIndex.One).IsKeyDown(Keys.Down))
            {
                isHit = true;
                whichbuttonhit = WhichButtonHit.down;
                herocolor = Color.White;
            }

            else if (gamepadstate.IsButtonDown(Buttons.DPadLeft) || Keyboard.GetState(PlayerIndex.One).IsKeyDown(Keys.Left))
            {
                isHit = true;
                whichbuttonhit = WhichButtonHit.left;
                herocolor = Color.White;
            }
            else if (gamepadstate.IsButtonDown(Buttons.DPadRight) || Keyboard.GetState(PlayerIndex.One).IsKeyDown(Keys.Right))
            {
                isHit = true;
                whichbuttonhit = WhichButtonHit.right;
                herocolor = Color.White;
            }

            #endregion
            // TODO: Add your update logic here
            #region code fight

            if (((scorenumber == 3) || (scorenumber > 3)) && (state == 0))
            {
                ScreenManager.Instance.AddScreen(new PlayVideoState());
            }
            else if (((scorenumber == 3) || (scorenumber > 3)) && (state == 1))
            {
                ScreenManager.Instance.AddScreen(new PlayVideoState(1));

            }
            else if (((scorenumber == 3) || (scorenumber > 3)) && (state == 2))
            {
             //   ScreenManager.Instance.AddScreen(new JobSkills());

            }

            if (villiansrect.Intersects(heroprojectilerect))
            {
                playSound = true;
                scorenumber += 1;
                villiancolor = Color.Blue;
                villianprojecticerect.X = 630;
                heroprojectilerect.X = 50;

                if (speedup == true)
                {
                    speedup = false;
                    villianspeed += 1;
                }

                if (playSound == true)
                {
                    playSound = false;
                    boom.Play();
                }
            }

            else if (!(villiansrect.Intersects(heroprojectilerect) && (villianprojecticerect.X < 500)))
            {
                villiancolor = Color.White;
            }

            if (JimmyEllisRectangle.Intersects(villianprojecticerect))
            {

                herocolor = Color.Blue;
                villianprojecticerect.X = 630;
                scorenumber -= 1;


            }


            villianprojecticerect.X -= villianspeed;

            /*
                        else if ()
                        {

                        }

                        else ()
                        {

                        }*/

            #endregion
            #region random algorithim





            if ((isHit == true) && (thebuttonhit == whichbuttonhit))
            {

                #region code fight
                if ((isHit == true) && (whichbuttonhit == thebuttonhit))
                {
                    isHit = false;
                    heroprojectilerect.X += heroprojectilespeed;
                }
                #endregion code fight
                isHit = false;

                // change to 5 so that abxy only appears change to 8 or 9 so that all appear
                chosenrandom = random.Next(0, 5);

                if (chosenrandom == 1)
                {
                    thebuttonhit = WhichButtonHit.a;

                }

                else if (chosenrandom == 2)
                {
                    thebuttonhit = WhichButtonHit.b;
                }

                else if (chosenrandom == 3)
                {
                    thebuttonhit = WhichButtonHit.x;
                }
                else if (chosenrandom == 4)
                {
                    thebuttonhit = WhichButtonHit.y;
                }
                /*
            else if (chosenrandom == 5)
            {
                thebuttonhit = WhichButtonHit.up;
            }
            else if (chosenrandom == 6)
            {
                thebuttonhit = WhichButtonHit.down;
            }
            else if (chosenrandom == 7)
            {
                thebuttonhit = WhichButtonHit.left;
            }
            else if (chosenrandom == 8)
            {
                thebuttonhit = WhichButtonHit.right;
            }
            */
            }

            #endregion


            #region Code Fight Update




            #endregion


        }
        #endregion

        #region Draw
        public override void Draw(SpriteBatch spriteBatch)
        {


            // TODO: Add your drawing code here

            #region Drawing What is Hit To The Screen



            spriteBatch.Draw(background, new Rectangle(0, 0, 800, 600), Color.White);
            if (WhichButtonHit.a == whichbuttonhit)
            {
                spriteBatch.Draw(A, Arect, buttoncolor);
            }
            else if (WhichButtonHit.b == whichbuttonhit)
            {
                spriteBatch.Draw(B, Brect, buttoncolor);
            }
            else if (WhichButtonHit.x == whichbuttonhit)
            {
                spriteBatch.Draw(X, Xrect, buttoncolor);
            }
            else if (WhichButtonHit.y == whichbuttonhit)
            {
                spriteBatch.Draw(Y, Yrect, buttoncolor);
            }

            else if (WhichButtonHit.up == whichbuttonhit)
            {
                spriteBatch.Draw(up, uprect, buttoncolor);
            }

            else if (WhichButtonHit.down == whichbuttonhit)
            {
                spriteBatch.Draw(down, uprect, buttoncolor);
            }

            else if (WhichButtonHit.left == whichbuttonhit)
            {
                spriteBatch.Draw(left, uprect, buttoncolor);
            }

            else if (WhichButtonHit.right == whichbuttonhit)
            {
                spriteBatch.Draw(right, uprect, buttoncolor);
            }


            #endregion


            #region What to hit on the screen


            if (WhichButtonHit.a == thebuttonhit)
            {
                spriteBatch.Draw(A, hitbuttonlocation, hitbuttoncolor);
            }

            else if (WhichButtonHit.b == thebuttonhit)
            {
                spriteBatch.Draw(B, hitbuttonlocation, hitbuttoncolor);
            }

            else if (WhichButtonHit.x == thebuttonhit)
            {
                spriteBatch.Draw(X, hitbuttonlocation, hitbuttoncolor);
            }

            else if (WhichButtonHit.y == thebuttonhit)
            {
                spriteBatch.Draw(Y, hitbuttonlocation, hitbuttoncolor);
            }

            else if (WhichButtonHit.up == thebuttonhit)
            {
                spriteBatch.Draw(up, hitbuttonlocation, hitbuttoncolor);
            }


            else if (WhichButtonHit.down == thebuttonhit)
            {
                spriteBatch.Draw(down, hitbuttonlocation, hitbuttoncolor);
            }


            else if (WhichButtonHit.left == thebuttonhit)
            {
                spriteBatch.Draw(left, hitbuttonlocation, hitbuttoncolor);
            }


            else if (WhichButtonHit.right == thebuttonhit)
            {
                spriteBatch.Draw(right, hitbuttonlocation, hitbuttoncolor);
            }




            #endregion









            spriteBatch.Draw(score, new Rectangle((400 - score.Height / 2), 500, 200, 100), Color.White);
            spriteBatch.DrawString(spritefont1, scorenumber.ToString(), new Vector2(460, 510), Color.White);


            #region Code Fight Draw


            spriteBatch.Draw(JimmyEllis, JimmyEllisRectangle, herocolor);
            spriteBatch.Draw(villians[0], villiansrect, villiancolor);
            spriteBatch.Draw(villianprojectile, villianprojecticerect, Color.White);
            spriteBatch.Draw(heroprojectile, heroprojectilerect, Color.White);

            leapMotionButtons.Draw(spriteBatch);

            #endregion

        }
    }

        #endregion
}
