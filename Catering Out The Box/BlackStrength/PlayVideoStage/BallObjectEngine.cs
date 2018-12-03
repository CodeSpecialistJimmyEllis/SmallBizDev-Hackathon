#region References
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
#endregion

namespace BlackStrength
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class BallObjectEngine
    {

        //TO DO: BALL OBJECT ENGINE RANDOM FALL FEATURE

        // RANDOM NUMBER TO SET THE SCREEN TO DISPLAY BALLOFTRUTH
        Random NUMBEROFAPPEARANCEX;

        Random ballthatfalls;
        //BALLOFTRUTH SPEED
        int BALLOFTRUTHSPEED;
        //STATUS BAR ON RIGHT   
        public static Color objectcolor;
        Texture2D[] rocks;
        Texture2D[] monsters;
        Texture2D[] clouds;
        Texture2D stopsign;
        Texture2D fireball;
        bool isReset = false;
        //GAME ASSETS ON LEFT
        Texture2D BALLOFTRUTH;
        public Rectangle BALLPOSITIONOFTRUTH;
        int randomchoice;
        Rectangle ballcollisionrect;
        Vector2 PADDLEPOSITION;
        SpriteFont Font1;
        bool chooserandom;
        Vector2 FONTOFTRUEMEDITATIONPOSITION;


        Vector2 FONTOFTRUEATTENTIONPOSITION;
        int seconds;
        //SpriteFont FONTOFTRUESCORE;
        //Vector2 FONTOFTRUESCOREPOSITION = Vector2.Zero;
        //Texture2D BACKGROUND;
        // Vector2 BACKGROUNDPOSITION = Vector2.Zero;
        #region Properties
        public bool IsReset
        {
            get
            {
                if (isReset != null)
                    return isReset;
                else
                    return false;
            }

            set
            {
                if (value == true || value == false)
                    isReset = value;
                else
                    isReset = isReset;
            }
        }
        public Rectangle Ballcollisionrect
        {
            get
            {

                return ballcollisionrect;

            }

        }

        public Rectangle BallPositionOfTruth
        {
            get
            {

                return BALLPOSITIONOFTRUTH;
            }

            set
            {

                value = BALLPOSITIONOFTRUTH;

            }
        }

        public int BallPositionOfTruthY
        {
            get
            {

                return BALLPOSITIONOFTRUTH.Y;

            }

            set
            {

                value = BALLPOSITIONOFTRUTH.Y;

            }
        }
        #endregion
        bool CONTROLPOSITIONX;
        bool CONTROLPOSITIONY;


        public BallObjectEngine()
        {
            NUMBEROFAPPEARANCEX = new Random();
            ballthatfalls = new Random();
            // ballcollisionrect = new Rectangle(0, 0, (int)BALLPOSITIONOFTRUTH.X, (int)BALLPOSITIONOFTRUTH.Y);
            //  BALLPOSITIONOFTRUTH = Vector2.Zero;
            BALLPOSITIONOFTRUTH = new Rectangle(128, 96, 128, 128);
            PADDLEPOSITION = Vector2.Zero;
            FONTOFTRUEMEDITATIONPOSITION = Vector2.Zero;
            FONTOFTRUEATTENTIONPOSITION = Vector2.Zero;
            BALLOFTRUTHSPEED = 6;
            CONTROLPOSITIONY = false;
            CONTROLPOSITIONX = true;
            int seconds = 0;
            rocks = new Texture2D[4];
            monsters = new Texture2D[2];
            clouds = new Texture2D[3];
            //fireball
            // stop sign
            chooserandom = false;
            ballcollisionrect = new Rectangle(128, 96, (int)BALLPOSITIONOFTRUTH.X, (int)BALLPOSITIONOFTRUTH.Y);
            objectcolor = Color.White ;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        public void Initialize()
        {
            // TODO: Add your initialization logic here


        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        public void LoadContent(ContentManager Content)
        {
            // Create a new SpriteBatch, which can be used to draw textures.




            //DISPLAYS LINE THAT SEPERATES STATS FROM GAMECODE AND POSITION


            //DISPLAY SCORE ON RIGHT

            Font1 = Content.Load<SpriteFont>("content/Font1");
            //DISPLAYS ATTENTION METER 


            //DISPLAYS MEDITATION METER 

            // IN GAME ASSETS ON LEFT
        //    BALLOFTRUTH = Content.Load<Texture2D>("ballobjectengine/ball");
            //BALLPOSITIONOFTRUTH.X;
            //BALLPOSITIONOFTRUTH.Y;

            // Loading the sprites fonts THE MEDITATION READING OF TRUTH

            rocks[0] = Content.Load<Texture2D>("PlayVideoStage/ballobjectengine/ball01");
            rocks[1] = Content.Load<Texture2D>("PlayVideoStage/ballobjectengine/ball02");
            rocks[2] = Content.Load<Texture2D>("PlayVideoStage/ballobjectengine/ball03");
            rocks[3] = Content.Load<Texture2D>("PlayVideoStage/ballobjectengine/ball04");
          //  fireball = Content.Load<Texture2D>("ballobjectengine/fireball");

           // clouds[0] = Content.Load<Texture2D>("ballobjectengine/clouds01");
           // clouds[1] = Content.Load<Texture2D>("ballobjectengine/clouds02");
           // clouds[2] = Content.Load<Texture2D>("ballobjectengine/clouds03");
            //LOADING sprite font for the SCORE OF TRUTH
            stopsign = Content.Load<Texture2D>("PlayVideoStage/ballobjectengine/stopsign");
            monsters[0] = Content.Load<Texture2D>("PlayVideoStage/ballobjectengine/monster01");
          //  monsters[1] = Content.Load<Texture2D>("ballobjectengine/monster02");


           // ballcollisionrect = new Rectangle(BALLOFTRUTH.Width, BALLOFTRUTH.Height, (int)BALLPOSITIONOFTRUTH.X, (int)BALLPOSITIONOFTRUTH.Y);
            //
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        public void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        /// 
        //CONNECTED TO THE BALLMOVEMENT METHOD AND IS BEFORE THE UPDATEMETHOD

        public void Update(GameTime gameTime)
        {
            // Allows the game to exit
            RANDOMBALLDOWN();
            ballcollisionrect.X = (int)BALLPOSITIONOFTRUTH.X;
            ballcollisionrect.Y = (int)BALLPOSITIONOFTRUTH.Y;

            //   ballcollisionrect.X = (int)BALLPOSITIONOFTRUTH.X;
            //   ballcollisionrect.Y = (int)BALLPOSITIONOFTRUTH.Y;
            //   BALLPOSITIONOFTRUTH.Y += 1;
            // TODO: Add your update logic here

            /*
            if (Keyboard.GetState(PlayerIndex.One).IsKeyDown(Keys.Down))
            {
                    POSITIONOFWAY.Y = POSITIONOFWAY.Y + speed;
                TIFA.Pause();
           
                //TIFATRUTH



            }

            if (Keyboard.GetState(PlayerIndex.One).IsKeyDown(Keys.Up))
            {
                POSITIONOFWAY.Y = POSITIONOFWAY.Y - speed;
                TIFA.Pause();


            }

            if (Keyboard.GetState(PlayerIndex.One).IsKeyDown(Keys.Left))
            {
                POSITIONOFWAY.X = POSITIONOFWAY.X - speed;
                TIFA.Pause();

            }
            if (Keyboard.GetState(PlayerIndex.One).IsKeyDown(Keys.Right))
            {
                POSITIONOFWAY.X = POSITIONOFWAY.X + speed;
                TIFA.Pause();

            }

            if (Keyboard.GetState(PlayerIndex.One).IsKeyDown(Keys.A))
            {

            }
            if ((Keyboard.GetState(PlayerIndex.One).IsKeyUp(Keys.Down)) && (Keyboard.GetState(PlayerIndex.One).IsKeyUp(Keys.Up)) && (Keyboard.GetState(PlayerIndex.One).IsKeyUp(Keys.Left)) && (Keyboard.GetState(PlayerIndex.One).IsKeyUp(Keys.Right)) && (TIFASTATE == ("Stopped")))
            {

                TIFA.Play();
            }
            */


        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            if (chooserandom == false)
            {
                randomchoice = ballthatfalls.Next(1, 5);
                chooserandom = true;
            }
            if (randomchoice == 1)
            {
                spriteBatch.Draw(rocks[0], BALLPOSITIONOFTRUTH, objectcolor);
            }
            else if (randomchoice == 2)
            {
                spriteBatch.Draw(rocks[1], BALLPOSITIONOFTRUTH, objectcolor);
            }
            else if (randomchoice == 3)
            {
                spriteBatch.Draw(rocks[2], BALLPOSITIONOFTRUTH, objectcolor);
            }

            else if (randomchoice == 4)
            {
                spriteBatch.Draw(rocks[3], BALLPOSITIONOFTRUTH, objectcolor);
            }



            // TODO: Add your drawing code here


            //STATUS


            //GAMEPLAY
            //  spriteBatch.Draw(PADDLE, PADDLEPOSITION, Color.White);
            //spriteBatch.DrawString(Font1, seconds.ToString(), new Vector2(100, 100), Color.Red);
            /*
             * 
            
           
             */
            #region old algorithim of seconds
            /*
            if (seconds <= 30)
            {
                spriteBatch.Draw(BALLOFTRUTH, BALLPOSITIONOFTRUTH, Color.White);
            }
            else if ((seconds >= 30) && (seconds <= 40))
            {
                //rocks
                spriteBatch.Draw(BALLOFTRUTH, BALLPOSITIONOFTRUTH, Color.White);
            }
            else if ((seconds >= 38) && (seconds <= 46))
            {
                //dragons
                spriteBatch.Draw(monsters[0], BALLPOSITIONOFTRUTH, Color.White);
            }
            else if ((seconds >= 41) && (seconds <= 51))
            {
                // fire
                spriteBatch.Draw(fireball, BALLPOSITIONOFTRUTH, Color.White);
            }
            else if ((seconds >= 52) && (seconds <= 56))
            {
                // clouds
                spriteBatch.Draw(clouds[0], BALLPOSITIONOFTRUTH, Color.White);
            }

            else if ((seconds >= 57) && (seconds <= 75))
            {
                // stop sign
                spriteBatch.Draw(stopsign, BALLPOSITIONOFTRUTH, Color.White);
            }
           /* else
            {
                spriteBatch.Draw(BALLOFTRUTH, BALLPOSITIONOFTRUTH, Color.White);
            }*/
            /*
             else if ((seconds >= 73) && (seconds <= 77))
             {
                 // rocks
                 spriteBatch.Draw(rocks[1], BALLPOSITIONOFTRUTH, Color.White);
             }

             else if ((seconds >= 79) && (seconds <= 81))
             {
                 // dragons
                 spriteBatch.Draw(monsters[1], BALLPOSITIONOFTRUTH, Color.White);

             }

             else if ((seconds >= 81) && (seconds <= 85))
             {

                 // clouds
                 spriteBatch.Draw(clouds[1], BALLPOSITIONOFTRUTH, Color.White);
             }
           /*  else
             {
                 spriteBatch.Draw(BALLOFTRUTH, BALLPOSITIONOFTRUTH, Color.White);
             }*/
            #endregion


        }
        public void RANDOMBALLDOWN()
        {
            int BALLOFTRUTHZONE1 = ((800 / 3) * 1);
            int BALLOFTRUTHZONE2 = ((800 / 3) + (800 / 3));
            int BALLOFTRUTHZONE3 = 800;
            Random ZoneRandom = new Random();
            int USEDZONE = ZoneRandom.Next(1, 3);


            BALLPOSITIONOFTRUTH.Y += 6;


            if (BALLPOSITIONOFTRUTH.Y == (600))
            {

                if (USEDZONE == 1)
                {
                    BALLPOSITIONOFTRUTH.Y = 0;
                    objectcolor = Color.White;
                      PlayVideoGameState.colorcontrol = false;
                      PlayVideoGameState.isscorehit = false;
                    chooserandom = false;
                    PlayVideoGameState.validationobjectengine.arttrigger = false;
                    PlayVideoGameState.validationobjectengine.playvalidationsound = false;
                    PlayVideoGameState.validationobjectengine.changealternatingvalidations = false;
                    BALLPOSITIONOFTRUTH.X = NUMBEROFAPPEARANCEX.Next(0, BALLOFTRUTHZONE1);
                }


                if (USEDZONE == 2)
                {
                    BALLPOSITIONOFTRUTH.Y = 0;
                    objectcolor = Color.White;
                     PlayVideoGameState.colorcontrol = false;
                     PlayVideoGameState.isscorehit = false;
                     PlayVideoGameState.validationobjectengine.arttrigger = false;
                    PlayVideoGameState.validationobjectengine.playvalidationsound = false;
                    PlayVideoGameState.validationobjectengine.changealternatingvalidations = false;
                    chooserandom = false;
                    BALLPOSITIONOFTRUTH.X = NUMBEROFAPPEARANCEX.Next(BALLOFTRUTHZONE1, BALLOFTRUTHZONE2);
                }


                if (USEDZONE == 3)
                {
                    BALLPOSITIONOFTRUTH.Y = 0;
                    objectcolor = Color.White;
                         PlayVideoGameState.colorcontrol = false;
                      PlayVideoGameState.isscorehit = false;
                    chooserandom = false;
                    PlayVideoGameState.validationobjectengine.playvalidationsound = false;
                    PlayVideoGameState.validationobjectengine.changealternatingvalidations = false;
                    PlayVideoGameState.validationobjectengine.arttrigger = false;
                    BALLPOSITIONOFTRUTH.X = NUMBEROFAPPEARANCEX.Next(BALLOFTRUTHZONE2, BALLOFTRUTHZONE3);
                }



            }



        }

        public void BALLOFTRUTHMOVEMENT()
        {

            //THE CONTROL VARIABLES OF THE X AND Y AXES RESPECTABLY
            /*
             * //CONNECTED TO THE BALLOFTRUTHMOVEMENT METHOD AND IS BEFORE THE UPDATEMETHOD
        bool CONTROLPOSITIONX = true;
        bool CONTROLPOSITIONY = false;
             * */



            //CONTROLS THE LEFT AND RIGHT MOVEMENT
            if (BALLPOSITIONOFTRUTH.X == (800 - BALLOFTRUTH.Width))
            {
                CONTROLPOSITIONX = false;
            }
            if (BALLPOSITIONOFTRUTH.X == 0)
            {
                CONTROLPOSITIONX = true;
            }

            if (BALLPOSITIONOFTRUTH.Y == 480 - BALLOFTRUTH.Height)
            {
                CONTROLPOSITIONY = false;
            }
            if (BALLPOSITIONOFTRUTH.Y == 0)
            {
                CONTROLPOSITIONY = true;
            }

            if (CONTROLPOSITIONX == true)
            {
                BALLPOSITIONOFTRUTH.X = BALLPOSITIONOFTRUTH.X + 2;
            }
            if (CONTROLPOSITIONX == false)
            {
                BALLPOSITIONOFTRUTH.X = BALLPOSITIONOFTRUTH.X - 2;
            }

            //CONTROSL THE UP AND DOWN MOVEMENT

            if (CONTROLPOSITIONY == true)
            {
                BALLPOSITIONOFTRUTH.Y += 2;
            }
            if (CONTROLPOSITIONY == false)
            {
                BALLPOSITIONOFTRUTH.Y -= 2;
            }

        }



        public void ReceiveFrom_TimeEngine(int newseconds)
        {

            this.seconds = newseconds;

        }

        public void SendTo_TimeEngine()
        {

        }


    }



}
