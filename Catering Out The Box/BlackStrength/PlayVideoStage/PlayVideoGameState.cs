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

namespace BlackStrength
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class PlayVideoGameState : GameScreen
    {

        #region Fields
        public static ValidationObjectEngine validationobjectengine;
        KeyboardState keyState;
        SpriteFont spriteFont; 
        Texture2D scoretext; 
        Texture2D masterbackground;
        //HomeBaseObject homebase;
        BallObjectEngine ballobjectengine;
        Rectangle masterbackgroundrect;
        TimeEngine timer;
        Song mainsong;
        SoundEffect boom;
        bool playsound;
        ScrollingBackground forward;
        // displays enter words forever
        Texture2D wronghands;
        bool displayenter;
        public LeapComponet leap;
        Texture2D[] fingertextures;
        Vector2 leapcollisionmin;
        Vector2 leapcollisionrightmax;
        Vector2 leapcollisionrightmin;
        Rectangle leapcollisionmax;
        Texture2D gWinBackground;
        Rectangle gWinRect;
        ScrollingBackgroundTopPV scrollingbackgroundtop;
        ScrollingBackgroundBottomPV scrollingbackgroundbottom;
       public static int score;
        SpriteFont LargeFont;
        #region control fields
        //ALLOWS YOU TO GO STRAIGHT TO ALTERNATE ENDINGS IF YOU'VE PLAYED THE GAME ONCE!
        bool isLooped;
        bool isDisposed;
        #endregion
       public static bool colorcontrol;
      public static bool isscorehit = false;
        #region V I D E O 
        Video gokuWinsVid;
        VideoPlayer gokuPlayer;
        // JESUS IS LORD <<< GRAPHICS / VIDEO >>> TEXTURE VIDEO DISPLAYS ON
        Texture2D gokuVidTexture;
        Rectangle gokuVidRect;

        
        #endregion 

        #endregion 

        #region Constructor 
        public PlayVideoGameState()
        {
            validationobjectengine = new ValidationObjectEngine();
            bool isLooped = true;
            bool isDisposed = false;
            leapcollisionmax = new Rectangle(0, 0, 128, 96);
            scrollingbackgroundtop = new ScrollingBackgroundTopPV();
            scrollingbackgroundbottom = new ScrollingBackgroundBottomPV();
            forward = new ScrollingBackground();
            playsound = false; 
            //intiilaliexz display enter
            displayenter = false;
            bool isscorehit;
           // leap = new LeapComponet(this);
            //this.Components.Add(leap);
                fingertextures = new Texture2D[5];
                score = 0;
                colorcontrol = false;
            ballobjectengine = new BallObjectEngine();
          //  homebase = new HomeBaseObject();
            timer = new TimeEngine();
            // TODO: Add your initialization logic here
            timer.Initialize();
            fingertextures = new Texture2D[5];
            // mainsong = new Song();
        }

        #endregion 

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
    

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        /// 
        #region LoadContent
        public override void LoadContent(ContentManager Content)
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            forward.LoadContent(Content);
            ballobjectengine.LoadContent(Content);
            scrollingbackgroundbottom.LoadContent(Content);
            scrollingbackgroundtop.LoadContent(Content);
            //homebase.LoadContent(Content);
            masterbackground = Content.Load<Texture2D>("PlayVideoStage/backgrounds/background01");
            masterbackgroundrect = new Rectangle(0, 0, 800, 600);
            timer.LoadContent(Content);
            scoretext = Content.Load<Texture2D>("PlayVideoStage/score/scoretext");
            //
            spriteFont = Content.Load<SpriteFont>("PlayVideoStage/content/Font1");

                      validationobjectengine.LoadContent(Content);
          //<< graphics >>> background after game falls 

            gWinBackground = Content.Load<Texture2D>("backgrounds/TitleScreen");
            gWinRect = new Rectangle(800, 600, 800, 600);

          // << GRAPHICS >> LARGE FONT THAT DISPLAYS SCORE
            LargeFont = Content.Load<SpriteFont>("PlayVideoStage/content/LargeFont");
            // wronghands = Content.Load<Texture2D>("backgrounds/WRONGHANDS");
            fingertextures[0] = Content.Load<Texture2D>("PlayVideoStage/fingers/fingersall");
            fingertextures[1] = Content.Load<Texture2D>("PlayVideoStage/fingers/fingersall");
            fingertextures[2] = Content.Load<Texture2D>("PlayVideoStage/fingers/fingersall");
            fingertextures[3] = Content.Load<Texture2D>("PlayVideoStage/fingers/fingersall");
            fingertextures[4] = Content.Load<Texture2D>("PlayVideoStage/fingers/fingersall");
            //
            leapcollisionmax.X = 400;
            leapcollisionmax.Y = 800;

            leapcollisionmin.X = 0;
            leapcollisionmin.Y = 500;
            boom = Content.Load<SoundEffect>("PlayVideoStage/sound/boom");
           /* mainsong = Content.Load<Song>("music/mainsong");
            MediaPlayer.Play(mainsong ); */
            SoundEffect.MasterVolume = 0.4f;
            leapcollisionrightmax.X = 600;
            leapcollisionrightmax.Y = 800;

            leapcollisionrightmin.X = 401;
            leapcollisionrightmin.Y = 500;

            #region Video

            // JESUS IS LORD!!! <<< VIDEO>>> JESUS IS LORD! THE VIDE WHERE GOKU WINS
            gokuPlayer = new VideoPlayer();
            gokuVidRect = new Rectangle(0, 0, 800, 600);
            gokuWinsVid = Content.Load<Video>("PlayVideoStage/videos/opening");
            gokuPlayer.Volume = 1.0f;

            //gokuPlayer.Volume = 5;
            gokuPlayer.Play(gokuWinsVid);

            #endregion
            // TODO: use this.Content to load your game content here
        }

        #endregion

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        public override void UnloadContent()
        {
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


            keyState = Keyboard.GetState();
            scrollingbackgroundtop.Update(gameTime);
            scrollingbackgroundbottom.Update(gameTime);

            validationobjectengine.Update(gameTime);
            validationobjectengine.validationrect = ballobjectengine.BALLPOSITIONOFTRUTH;
                if (gokuPlayer.State == MediaState.Stopped)
                {
                    
                        // UnloadContent();
                        //isDisposed = true;
                        gWinRect.X = 0;
                        gWinRect.Y = 0;
                    
                }
            
            keyState = Keyboard.GetState();
            forward.Update(gameTime);
            #region KEYBOARD COMMANDS TO CONTROL AFTER VIDEO JESUS IS GOD!
            if (keyState.IsKeyDown(Keys.Enter) && (gokuPlayer.State == MediaState.Stopped))
            {
               // ScreenManager.Instance.AddScreen(new OpeningTitleScreen(isLooped));

                UnloadContent();
                gokuPlayer.Dispose();
                gokuVidTexture.Dispose();
                ScreenManager.Instance.AddScreen(new OpeningTitleScreen());

            }

            if (keyState.IsKeyDown(Keys.P))
            {
                //ScreenManager.Instance.AddScreen(new PlayVideoGameState(isLooped));

                UnloadContent();
                gokuPlayer.Dispose();
                gokuVidTexture.Dispose();
                //ScreenManager.Instance.AddScreen(new EndingTitleScreen());

            }

            #endregion 
            //   homebase.explosionartrect.X = theball.ballrect.X;
           // homebase.explosionartrect.Y = theball.ballrect.Y;
            ballobjectengine.Update(gameTime);
            //homebase.Update(gameTime);
            timer.Update(gameTime);


           // collisions are in the update method. finger ocllisons with falling stuff pheonomina 
            if ((ballobjectengine.BallPositionOfTruth.Intersects(leapcollisionmax)) || (leapcollisionmax.Intersects(ballobjectengine.BallPositionOfTruth)) || (leapcollisionmax.X == ballobjectengine.BallPositionOfTruth.X && leapcollisionmax.Y == ballobjectengine.BallPositionOfTruth.Y))
            //     if (leapcollisionmax.Intersects(ballobjectengine.BallPositionOfTruth)) 
            {

                validationobjectengine.arttrigger = true;
                validationobjectengine.soundtrigger = true;
                if (playsound == false)
                {
                    boom.Play();
                    playsound = true; 
                }
                if (colorcontrol == false)
                {
                    BallObjectEngine.objectcolor = Color.White;
                    colorcontrol = true;
                   
                }

                if (isscorehit == false)
                {
                    score += 1;
                    isscorehit = true; 
                    playsound = false;
                }
            }
            // TODO: Add your update logic here\
      /*
            if (bottombaserect.Intersects(theball.Ballrect))
            {
                ishit = true;
            }

            if (!bottombaserect.Intersects(theball.Ballrect))
            {
                ishit = false;
            }
            */

            ballobjectengine.ReceiveFrom_TimeEngine(timer.SendTo_BallObjectEngine());
            
           // theball.Ballpositionoftruth.X;
          
            
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
       public override void Draw(SpriteBatch spriteBatch)
        {


    

            if ((isDisposed == false) || (gokuPlayer.State == MediaState.Playing))
            {
                gokuVidTexture = gokuPlayer.GetTexture();


                spriteBatch.Draw(gokuVidTexture, gokuVidRect, Color.White);
            }

            scrollingbackgroundtop.Draw(spriteBatch);
            scrollingbackgroundbottom.Draw(spriteBatch);
               // spriteBatch.Draw(gWinBackground, gWinRect, Color.White);
                forward.Draw(spriteBatch);
           //    spriteBatch.Draw(wronghands, new Rectangle(0, 0, 800, 600), Color.White); 
            
           
          
          /*  if (gokuPlayer.State == MediaState.Stopped || gokuPlayer.State == MediaState.Paused)
            {
                spriteBatch.DrawString(LargeFont, "PRESS ENTER AFTER VIDEO", new Vector2(0, 400), Color.White);
            }*/
        
         
            /*    if (displayenter == true)
                {
             
                }
                else
                {
                }*/

        

            ballobjectengine.Draw(spriteBatch);
            validationobjectengine.Draw(spriteBatch);
           // spriteBatch.Draw(masterbackground, masterbackgroundrect, Color.White);

           // homebase.Draw(spriteBatch);
          
            timer.Draw(spriteBatch);


            spriteBatch.Draw(scoretext, new Rectangle(0, 0, 300, 75), Color.White);
            //spriteBatch.DrawString(spriteFont, score.ToString(), new Vector2(320, 75); 


            foreach (Vector2 fingerLoc in Game1.leap.FingerPoints)
            {

                spriteBatch.Draw(fingertextures[0], fingerLoc, Color.White);
                leapcollisionmax.X = (int)fingerLoc.X;
                leapcollisionmax.Y = (int)fingerLoc.Y;
            //    spriteBatch.Draw(fingertextures[0], leap.FirstHandLoc, Color.White);

            }

            spriteBatch.DrawString(LargeFont, score.ToString(), new Vector2(310, 0), Color.White);
            /*
            spriteBatch.Draw(fingertextures[0], leap.Fingerarray[0], Color.White);

            spriteBatch.Draw(fingertextures[1], leap.Fingerarray[1], Color.White);


            spriteBatch.Draw(fingertextures[2], leap.Fingerarray[2], Color.White);

            spriteBatch.Draw(fingertextures[3], leap.Fingerarray[3], Color.White);

            spriteBatch.Draw(fingertextures[4], leap.Fingerarray[4], Color.White);*/
       /*     if (ishit == true)
            {
                spriteBatch.Draw(explosionart, explosionartrect, Color.Red);
                spriteBatch.Draw(bottombase, bottombaserect, Color.Red);
            }
            else if (ishit == false)
            {
                spriteBatch.Draw(bottombase, bottombaserect, Color.White);
            }*/
         
            // TODO: Add your drawing code here
       
        }
    }
}
