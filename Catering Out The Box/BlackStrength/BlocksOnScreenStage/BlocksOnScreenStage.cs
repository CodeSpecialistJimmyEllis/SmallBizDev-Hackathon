// JESUS IS LORD! ONLY THROUGH CHRIST JESUS IS THIS POSSIBLE!
// REVEREND. JIMMY ELLIS JESUS IS THE KING!


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
using LeapLibrary;
// using Leap;

namespace BlackStrength
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class BlockGamePlay : GameScreen
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        #region Custom Fields
        //sprite font
        SpriteFont spritefont01;

        // score and such things 
        int score = 0;
        string scorestring;
        int highscore = 18;
        string highscorestring;
        //the detection settings must change in relationship to the character on screen eyes here is the controls for that!!!
        bool blueeyes = true;
        bool greeneyes = false;
        bool redeyes = false;

        bool boxcollisionoccured = false;
        // yo use this to change the things 
        bool tochange = false;

        // random so that you can pick which eye is chosen
        Random random;
        int randomint;

        Texture2D youwinscreen;


        // enum to see which bool for the eyes are used
        enum EyeColors
        {
            blue, red, green
        };

        // backgrounds that change are really good! these backgrounds changes and turn on the eyes and turn off the eyes!
        Texture2D backgroundgreen;
        Texture2D backgroundred;
        Texture2D backgroundblue;

        Rectangle backgroundrect;
        #region boxes
        //we are not using arrays we are going to make all of them by hand!
        Texture2D bluebox2;
        Texture2D bluebox3;
        Texture2D bluebox4;
        Texture2D bluebox5;

        Texture2D bluebox6;
        Texture2D bluebox7;
        Texture2D bluebox8;
        Texture2D bluebox9;

        Rectangle bluebox2rect;
        Rectangle bluebox3rect;
        Rectangle bluebox4rect;
        Rectangle bluebox5rect;

        Rectangle bluebox6rect;
        Rectangle bluebox7rect;
        Rectangle bluebox8rect;
        Rectangle bluebox9rect;

        Texture2D greenbox;
        Texture2D greenbox2;
        Texture2D greenbox3;
        Texture2D greenbox4;
        Texture2D greenbox5;
        Texture2D greenbox6;
        Texture2D greenbox7;
        Texture2D greenbox8;
        Texture2D greenbox9;


        Rectangle greenboxrect;
        Rectangle greenbox2rect;
        Rectangle greenbox3rect;
        Rectangle greenbox4rect;
        Rectangle greenbox5rect;
        Rectangle greenbox6rect;
        Rectangle greenbox7rect;
        Rectangle greenbox8rect;
        Rectangle greenbox9rect;

        Texture2D redbox;
        Texture2D redbox2;
        Texture2D redbox3;
        Texture2D redbox4;
        Texture2D redbox5;
        Texture2D redbox6;
        Texture2D redbox7;
        Texture2D redbox8;

        Texture2D redbox9;

        Rectangle redboxrect;
        Rectangle redbox2rect;
        Rectangle redbox3rect;
        Rectangle redbox4rect;
        Rectangle redbox5rect;
        Rectangle redbox6rect;
        Rectangle redbox7rect;
        Rectangle redbox8rect;
        Rectangle redbox9rect;
        #endregion

        public static LeapComponet leapa;
        Texture2D texture;
        Rectangle rect;
        SpriteFont font;

        // graphics box collide 
        Texture2D bluebox;
        Rectangle blueboxrect;

        //rectangle to put on leapa finger controls for easier intersect collision detection 
        public static Rectangle leapacollision;
        // tells if leap location has changed at all
        Rectangle oldlocation;
        Rectangle newlocation;

        // collision control mechanism for collision detection unit
        bool changecolor = false;
        bool changecolor2 = false;
        bool changecolor3 = false;
        bool changecolor4 = false;
        bool changecolor5 = false;
        bool changecolor6 = false;

        bool changecolor7 = false;
        bool changecolor8 = false;
        bool changecolor9 = false;
        bool changecolor10 = false;
        bool changecolor11 = false;
        bool changecolor12 = false;

        bool changecolor13 = false;
        bool changecolor14 = false;
        bool changecolor15 = false;
        bool changecolor16 = false;

        bool changecolor17 = false;
        bool changecolor18 = false;

        //bool to control if box is drawn or if box is not drawn based on advanced collision detection algorithim 
        bool nodraw = true;
        bool nodraw2 = true;
        bool nodraw3 = true;
        bool nodraw4 = true;
        bool nodraw5 = true;
        bool nodraw6 = true;
        // boolean to decide if the song has already been checke to see if it is on 
        bool soundplayed = false;

        // yo score taken is fine it just makes it so that you can only get one vairable from the score
        bool scoretaken = false;
        bool scoretaken2 = false;
        bool scoretaken3 = false;
        bool scoretaken4 = false;
        bool scoretaken5 = false;
        bool scoretaken6 = false;
        bool scoretaken7 = false;
        bool scoretaken8 = false;
        bool scoretaken9 = false;
        bool scoretaken10 = false;
        bool scoretaken11 = false;
        bool scoretaken12 = false;
        bool scoretaken13 = false;
        bool scoretaken14 = false;
        bool scoretaken15 = false;
        bool scoretaken16 = false;
        bool scoretaken17 = false;
        bool scoretaken18 = false;

        //checks to see if songs are playing
        bool checkforplayingsong = false;
        // checks to see if the same thing hjas happened so that we can decide on whwat to do 
        bool thesame;
        // the algorithim for on and off music booleans and such
        long timestampholder;

        // controls the timestamp so that you can check to see what is correct
        bool timestampcontroller = false;
        // variable to hold how long it takes for drawn objects to disappear 
        static private int timeoutlimit = 1000; // 4 seconds

        // sound that plays only when the leap motion controls are on the screen
        Song leapaonscreen;
        Song backgroundsong;
        SoundEffect tokensuccess;
        SoundEffect youwin;
        Texture2D backgroundtexture;

        // takes time and reads it so that it tells you how long the leapa controller has been in active in the name of solving the problem
        double totaltime;

        #endregion
        public BlockGamePlay()
        {
            // graphics = new GraphicsDeviceManager(this);
            // Content.RootDirectory = "Content";


        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        //  public override void Initialize()
        //  {
        // TODO: Add your initialization logic here

        // Random to decide which eye to show


        //  }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        public override void LoadContent(ContentManager Content)
        {
            base.LoadContent(Content);

            random = new Random();
            randomint = random.Next(1, 3);

            // Create a new SpriteBatch, which can be used to draw textures.
            //spriteBatch = new SpriteBatch(GraphicsDevice);
            font = Content.Load<SpriteFont>("BlocksOnScreen/SpriteFont1");
            texture = Content.Load<Texture2D>("BlocksOnScreen/effect1");

            // graphics backgroun texture
            backgroundtexture = Content.Load<Texture2D>("BlocksOnScreen/backgroundtexture");
            backgroundrect = new Rectangle(0, 0, 800, 600);
            leapacollision = new Rectangle(0, 0, 64, 64);

            #region background eye dues
            backgroundblue = Content.Load<Texture2D>("BlocksOnScreen/backgroundblue");
            backgroundgreen = Content.Load<Texture2D>("BlocksOnScreen/backgroundgreen");
            backgroundred = Content.Load<Texture2D>("BlocksOnScreen/backgroundred");
            youwinscreen = Content.Load<Texture2D>("BlocksOnScreen/youwinscreen");
            #endregion

            #region spritefont loading
            spritefont01 = Content.Load<SpriteFont>("BlocksOnScreen/SpriteFont1");
            #endregion
            #region all boxes
            bluebox = Content.Load<Texture2D>("BlocksOnScreen/bluebox");
            blueboxrect = new Rectangle(150, 330, 64, 64);

            bluebox2 = Content.Load<Texture2D>("BlocksOnScreen/bluebox");
            bluebox2rect = new Rectangle(150, 400, 64, 64);

            bluebox3 = Content.Load<Texture2D>("BlocksOnScreen/bluebox");
            bluebox3rect = new Rectangle(150, 260, 64, 64);

            bluebox4 = Content.Load<Texture2D>("BlocksOnScreen/bluebox");
            bluebox4rect = new Rectangle(150, 190, 64, 64);

            bluebox5 = Content.Load<Texture2D>("BlocksOnScreen/bluebox");
            bluebox5rect = new Rectangle(150, 120, 64, 64);


            bluebox6 = Content.Load<Texture2D>("BlocksOnScreen/bluebox");
            bluebox6rect = new Rectangle(150, 50, 64, 64);


            greenbox = Content.Load<Texture2D>("BlocksOnScreen/greenbox");
            greenboxrect = new Rectangle(300, 120, 64, 64);

            greenbox2 = Content.Load<Texture2D>("BlocksOnScreen/greenbox");
            greenbox2rect = new Rectangle(300, 190, 64, 64);

            greenbox3 = Content.Load<Texture2D>("BlocksOnScreen/greenbox");
            greenbox3rect = new Rectangle(300, 260, 64, 64);

            greenbox4 = Content.Load<Texture2D>("BlocksOnScreen/greenbox");
            greenbox4rect = new Rectangle(300, 330, 64, 64);

            greenbox5 = Content.Load<Texture2D>("BlocksOnScreen/greenbox");
            greenbox5rect = new Rectangle(300, 400, 64, 64);

            greenbox6 = Content.Load<Texture2D>("BlocksOnScreen/greenbox");
            greenbox6rect = new Rectangle(300, 50, 64, 64);


            redbox = Content.Load<Texture2D>("BlocksOnScreen/redbox");
            redboxrect = new Rectangle(450, 50, 64, 64);

            redbox2 = Content.Load<Texture2D>("BlocksOnScreen/redbox");
            redbox2rect = new Rectangle(450, 120, 64, 64);

            redbox3 = Content.Load<Texture2D>("BlocksOnScreen/redbox");
            redbox3rect = new Rectangle(450, 190, 64, 64);

            redbox4 = Content.Load<Texture2D>("BlocksOnScreen/redbox");
            redbox4rect = new Rectangle(450, 260, 64, 64);

            redbox5 = Content.Load<Texture2D>("BlocksOnScreen/redbox");
            redbox5rect = new Rectangle(450, 330, 64, 64);

            redbox6 = Content.Load<Texture2D>("BlocksOnScreen/redbox");
            redbox6rect = new Rectangle(450, 400, 64, 64);
            #endregion
            #region sound
            leapaonscreen = Content.Load<Song>("BlocksOnScreen/leaponscreen");

            backgroundsong = Content.Load<Song>("BlocksOnScreen/backgroundsong");
            tokensuccess = Content.Load<SoundEffect>("BlocksOnScreen/tokensuccess");
            youwin = Content.Load<SoundEffect>("BlocksOnScreen/youwin");
            #endregion



            // leap.LoadContent(Content);
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        public override void UnloadContent()
        {
            base.UnloadContent();
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            //   if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
            //  this.Exit();


            if (checkforplayingsong == false)
            {

                if (MediaPlayer.State == MediaState.Stopped)
                {
                    MediaPlayer.Play(backgroundsong);
                    checkforplayingsong = true;
                }
            }

            if ((MediaPlayer.State == MediaState.Stopped) && (checkforplayingsong == true))
            {
                MediaPlayer.Play(backgroundsong);
                checkforplayingsong = false;
            }


            // changes the game to title screen if game is done
            if ((highscore == 0) && (score == 18))
            {
                ScreenManager.playvideostate = new PlayVideoState();
                ScreenManager.Instance.AddScreen(ScreenManager.playvideostate);
            }

            // TODO: Add your update logic here



            // collision detection vector 2 phoenomina to decide if the screen is or is not leap controller full 
            /*     if (((oldlocation.X != leapcollision.Y) && (oldlocation.X != leapcollision.Y) && (soundplayed == false)))
                {
                
                    MediaPlayer.Play(leaponscreen);
                    soundplayed = true;
                } */

            //  totaltime = gameTime.TotalGameTime.TotalMilliseconds + 1000;
            // if (!((oldlocation.X != leapcollision.Y) && (oldlocation.X != leapcollision.Y) && (soundplayed == false)))   //else if ((leapcollision.X == oldlocation.X) && (leapcollision.Y == oldlocation.Y) && (leapcollision.X <= oldlocation.X + 5) && (leapcollision.X >= oldlocation.X - 5) && (leapcollision.Y >= oldlocation.Y - 5) && (leapcollision.Y <= oldlocation.Y + 5) && (soundplayed == true)) 
            // if ( ((leapcollision.X == oldlocation.X) || (leapcollision.Y == oldlocation.Y)) && (gameTime.TotalGameTime.TotalMilliseconds > totaltime))

            //var frame1 = LeapComponet.controller.Frame();

            /*  if (timestampcontroller == false)
              {
                  timestampholder = frame1.Timestamp + 1000000;
                  timestampcontroller = true; 
              }
              else 
              {
                  timestampholder = frame1.Timestamp; 
              }*/

            /* while (frame1.Timestamp > timestampholder )
                {
                    if (leapcollision.X == newlocation.X)
                    {
                        thesame = true;
                    }
                    else 
                    {
                        thesame = false;
                    }
                } */
            //boxcollisionoccured = false; 

            //collision detection using rectangle intersect method for easier detection
            if (blueboxrect.Intersects(leapacollision))
            {
                tokensuccess.Play();
                changecolor = true;
                //nodraw = true;
                //  boxcollisionoccured = true; 
                tochange = true;
                if (scoretaken == false)
                {
                    score = score + 1;
                    highscore = highscore - 1;
                    scoretaken = true;
                }

            }
            /*  else 
              {
                  changecolor = false;
              } */

            if (bluebox2rect.Intersects(leapacollision))
            {
                tokensuccess.Play();
                tochange = true;
                changecolor2 = true;
                if (scoretaken2 == false)
                {
                    score = score + 1;
                    highscore = highscore - 1;
                    scoretaken2 = true;
                }
            }
            /*  else
              {
                  changecolor2 = false;
              } */


            if (bluebox3rect.Intersects(leapacollision))
            {
                tokensuccess.Play();
                tochange = true;
                changecolor3 = true;
                if (scoretaken3 == false)
                {
                    score = score + 1;
                    highscore = highscore - 1;
                    scoretaken3 = true;
                }
            }
            /*  else
              {
                  changecolor3 = false;
              } */


            if (bluebox4rect.Intersects(leapacollision))
            {
                tokensuccess.Play();
                tochange = true;
                changecolor4 = true;
                if (scoretaken4 == false)
                {
                    score = score + 1;
                    highscore = highscore - 1;
                    scoretaken4 = true;
                }
            }
            /*  else
              {
                  changecolor4 = false;
              } */



            if (bluebox5rect.Intersects(leapacollision))
            {
                tokensuccess.Play();
                tochange = true;
                changecolor5 = true;
                if (scoretaken5 == false)
                {
                    score = score + 1;
                    highscore = highscore - 1;
                    scoretaken5 = true;
                }
            }
            /* else
             {
                 changecolor5 = false;
             } */



            if (bluebox6rect.Intersects(leapacollision))
            {
                tokensuccess.Play();
                tochange = true;

                changecolor6 = true;
                if (scoretaken6 == false)
                {
                    score = score + 1;
                    highscore = highscore - 1;
                    scoretaken6 = true;
                }
            }
            /*  else
              {
                  changecolor6 = false;
              } */


            //collision detection using rectangle intersect method for easier detection
            if (greenboxrect.Intersects(leapacollision))
            {
                tokensuccess.Play();
                tochange = true;
                changecolor7 = true;
                //nodraw = true;
                if (scoretaken7 == false)
                {
                    score = score + 1;
                    highscore = highscore - 1;
                    scoretaken7 = true;
                }
            }
            /*  else 
              {
                  changecolor = false;
              } */

            if (greenbox2rect.Intersects(leapacollision))
            {
                tokensuccess.Play();
                tochange = true;
                changecolor8 = true;
                if (scoretaken8 == false)
                {
                    score = score + 1;
                    highscore = highscore - 1;
                    scoretaken8 = true;
                }
            }
            /*  else
              {
                  changecolor2 = false;
              } */


            if (greenbox3rect.Intersects(leapacollision))
            {
                tokensuccess.Play();
                tochange = true;
                changecolor9 = true;
                if (scoretaken9 == false)
                {
                    score = score + 1;
                    highscore = highscore - 1;
                    scoretaken9 = true;
                }
            }
            /*  else
              {
                  changecolor3 = false;
              } */


            if (greenbox4rect.Intersects(leapacollision))
            {
                tokensuccess.Play();
                tochange = true;
                changecolor10 = true;
                if (scoretaken10 == false)
                {
                    score = score + 1;
                    highscore = highscore - 1;
                    scoretaken10 = true;
                }
            }
            /*  else
              {
                  changecolor4 = false;
              } */



            if (greenbox5rect.Intersects(leapacollision))
            {
                tokensuccess.Play();
                tochange = true;
                changecolor11 = true;
                if (scoretaken11 == false)
                {
                    score = score + 1;
                    highscore = highscore - 1;
                    scoretaken11 = true;
                }
            }
            /* else
             {
                 changecolor5 = false;
             } */



            if (greenbox6rect.Intersects(leapacollision))
            {
                tokensuccess.Play();
                tochange = true;
                changecolor12 = true;
                if (scoretaken12 == false)
                {
                    score = score + 1;
                    highscore = highscore - 1;
                    scoretaken12 = true;
                }
            }
            /*  else
              {
                  changecolor6 = false;
              } */

            //collision detection using rectangle intersect method for easier detection
            if (redboxrect.Intersects(leapacollision))
            {
                tokensuccess.Play();
                tochange = true;
                changecolor13 = true;
                if (scoretaken13 == false)
                {
                    score = score + 1;
                    highscore = highscore - 1;
                    scoretaken13 = true;
                }
                //nodraw = true;
            }
            /*  else 
              {
                  changecolor = false;
              } */

            if (redbox2rect.Intersects(leapacollision))
            {
                tokensuccess.Play();
                tochange = true;
                changecolor14 = true;
                if (scoretaken14 == false)
                {
                    score = score + 1;
                    highscore = highscore - 1;
                    scoretaken14 = true;
                }
            }
            /*  else
              {
                  changecolor2 = false;
              } */


            if (redbox3rect.Intersects(leapacollision))
            {
                tokensuccess.Play();
                tochange = true;
                changecolor15 = true;
                if (scoretaken15 == false)
                {
                    score = score + 1;
                    highscore = highscore - 1;
                    scoretaken15 = true;
                }

            }
            /*  else
              {
                  changecolor3 = false;
              } */


            if (redbox4rect.Intersects(leapacollision))
            {
                tokensuccess.Play();
                tochange = true;
                changecolor16 = true;
                if (scoretaken16 == false)
                {
                    score = score + 1;
                    highscore = highscore - 1;
                    scoretaken16 = true;
                }
            }
            /*  else
              {
                  changecolor4 = false;
              } */



            if (redbox5rect.Intersects(leapacollision))
            {
                tokensuccess.Play();
                tochange = true;
                changecolor17 = true;
                if (scoretaken17 == false)
                {
                    score = score + 1;
                    highscore = highscore - 1;
                    scoretaken17 = true;
                }
            }
            /* else
             {
                 changecolor5 = false;
             } */



            if (redbox6rect.Intersects(leapacollision))
            {
                tokensuccess.Play();
                tochange = true;
                changecolor18 = true;
                if (scoretaken18 == false)
                {
                    score = score + 1;
                    highscore = highscore - 1;
                    scoretaken18 = true;
                }
            }
            /*  else
              {
                  changecolor6 = false;
              } */



            //    base.Update(gameTime);
        }


        //}

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Draw(SpriteBatch spriteBatch)
        {

            if (score == 18)
            {
                bool playyouwin = true;

                spriteBatch.Draw(youwinscreen, backgroundrect, Color.White);
                if (playyouwin == true)
                {
                    youwin.Play();
                    playyouwin = false;
                }

            }


            if (!(highscore == 0))
            {



                //flash screen for gesture
                //   if (leapa.Gestures.Count == 0)
                //   {
                //      GraphicsDevice.Clear(Color.CornflowerBlue);
                //   }
                //  else
                //  {
                //      GraphicsDevice.Clear(Color.DarkBlue);
                //  }


                //Text for leapaController

                // spriteBatch.Draw(backgroundtexture, new Rectangle(0, 0, 800, 600), Color.White);


                random = new Random();


                randomint = random.Next(1, 4);

                // 1 = blue 2 = green 3 = red 
                if ((tochange == true) && (randomint >= 1) && (randomint <= 3))
                {
                    if (1 == randomint)
                    {
                        blueeyes = true;
                        greeneyes = false;
                        redeyes = false;
                    }

                    if (2 == randomint)
                    {
                        greeneyes = true;
                        blueeyes = false;
                        redeyes = false;
                    }

                    if (3 == randomint)
                    {
                        redeyes = true;
                        greeneyes = false;
                        blueeyes = false;
                    }


                    tochange = false;
                }



                if (1 == randomint)
                {

                    spriteBatch.Draw(backgroundblue, backgroundrect, Color.White);

                }
                if (2 == randomint)
                {

                    spriteBatch.Draw(backgroundgreen, backgroundrect, Color.White);

                }
                if (3 == randomint)
                {

                    spriteBatch.Draw(backgroundred, backgroundrect, Color.White);

                }


                // drawing score and such
                scorestring = score.ToString();
                spriteBatch.DrawString(spritefont01, scorestring, new Vector2(0, 0), Color.Black);

                highscorestring = highscore.ToString();
                spriteBatch.DrawString(spritefont01, highscorestring, new Vector2(0, 50), Color.Black);
                //


                //   spriteBatch.DrawString(font, leapa.DebugLine, new Vector2(10, 10), Color.Wheat);

                foreach (Vector2 fingerLoc in Game1.leap.FingerPoints)
                {
                    //  if (changecolor == false)
                    //  {

                    spriteBatch.Draw(texture, fingerLoc, Color.White);
                    spriteBatch.Draw(texture, Game1.leap.FirstHandLoc, Color.White);


                    // }

                    /*  else if (nodraw)
                      {
                        
                          spriteBatch.Draw(texture, fingerLoc, Color.Red);
                          spriteBatch.Draw(texture, leapa.FirstHandLoc, Color.Red);
                     
                      } */
                }
                if (changecolor == false)
                {

                    spriteBatch.Draw(bluebox, blueboxrect, Color.White);
                    //  score = score + 1;
                    //  highscore = highscore - score;
                }



                /*  if (nodraw == false)
                  {
                         
                      
                          spriteBatch.Draw(bluebox, blueboxrect, Color.Red);
                 
                         // nodraw = false;
                  
                  
                  } */

                // long repeated section in which their is no end because someone decided not to use arrays!!!!!

                if (changecolor2 == false)
                {

                    spriteBatch.Draw(bluebox2, bluebox2rect, Color.White);
                }

                /*  if (nodraw2 == false)
                  {


                      spriteBatch.Draw(bluebox2, bluebox2rect, Color.Red);

                      // nodraw = false;


                  } */


                if (changecolor3 == false)
                {

                    spriteBatch.Draw(bluebox3, bluebox3rect, Color.White);
                }

                /* if (nodraw3 == false)
                 {


                     spriteBatch.Draw(bluebox3, bluebox3rect, Color.Red);

                     // nodraw = false;


                 } */



                if (changecolor4 == false)
                {

                    spriteBatch.Draw(bluebox4, bluebox4rect, Color.White);
                }

                /*  if (nodraw4 == false)
                  {


                      spriteBatch.Draw(bluebox4, bluebox4rect, Color.Red);

                      // nodraw = false;


                  } */



                if (changecolor5 == false)
                {

                    spriteBatch.Draw(bluebox5, bluebox5rect, Color.White);
                }

                /*  if (nodraw5 == false)
                  {


                      spriteBatch.Draw(bluebox5, bluebox5rect, Color.Red);

                      // nodraw = false;


                  } */



                if (changecolor6 == false)
                {

                    spriteBatch.Draw(bluebox6, bluebox6rect, Color.White);
                }


                if (changecolor7 == false)
                {

                    spriteBatch.Draw(greenbox, greenboxrect, Color.White);
                }

                if (changecolor8 == false)
                {

                    spriteBatch.Draw(greenbox2, greenbox2rect, Color.White);
                }

                if (changecolor9 == false)
                {

                    spriteBatch.Draw(greenbox3, greenbox3rect, Color.White);
                }

                if (changecolor10 == false)
                {

                    spriteBatch.Draw(greenbox4, greenbox4rect, Color.White);
                }

                if (changecolor11 == false)
                {

                    spriteBatch.Draw(greenbox5, greenbox5rect, Color.White);
                }

                if (changecolor12 == false)
                {

                    spriteBatch.Draw(greenbox6, greenbox6rect, Color.White);
                }

                /*  if (nodraw6 == false)
                  {


                      spriteBatch.Draw(bluebox6, bluebox6rect, Color.Red);

                      // nodraw = false;


                  } */

                /*  spriteBatch.Draw(greenbox, greenboxrect, Color.White);

                   spriteBatch.Draw(greenbox2, greenbox2rect, Color.White);

                   spriteBatch.Draw(greenbox3, greenbox3rect, Color.White);

                   spriteBatch.Draw(greenbox4, greenbox4rect, Color.White);

                   spriteBatch.Draw(greenbox5, greenbox5rect, Color.White);

                   spriteBatch.Draw(greenbox6, greenbox6rect, Color.White); */
                if (changecolor13 == false)
                {


                    spriteBatch.Draw(redbox, redboxrect, Color.White);
                }
                if (changecolor14 == false)
                {

                    spriteBatch.Draw(redbox2, redbox2rect, Color.White);
                }

                if (changecolor15 == false)
                {

                    spriteBatch.Draw(redbox3, redbox3rect, Color.White);
                }

                if (changecolor16 == false)
                {

                    spriteBatch.Draw(redbox4, redbox4rect, Color.White);
                }
                if (changecolor17 == false)
                {

                    spriteBatch.Draw(redbox5, redbox5rect, Color.White);
                }


                if (changecolor18 == false)
                {

                    spriteBatch.Draw(redbox6, redbox6rect, Color.White);


                }





                oldlocation.X = leapacollision.X;
                oldlocation.Y = leapacollision.Y;
                foreach (Vector2 fingerLocC in Game1.leap.FingerPoints)
                {

                    leapacollision.X = (int)fingerLocC.X;
                    leapacollision.Y = (int)fingerLocC.Y;
                }

                newlocation.X = leapacollision.X;
                newlocation.Y = leapacollision.Y;
            }


            // base.Draw(gameTime);


        }
    }
}

// completed gameplay.cs for some reason no functional leapa controls oh well will try again 

