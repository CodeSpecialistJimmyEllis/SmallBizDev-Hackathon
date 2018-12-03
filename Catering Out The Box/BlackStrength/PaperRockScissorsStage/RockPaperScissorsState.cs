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

namespace BlackStrength
{

    public class PaperRockScissorsState : GameScreen
    {

        #region Fields
        LeapComponet leap;
        Texture2D[] fingertexture;
        Rectangle rect;
        SpriteFont font;
        int endmessagenumber;
        int gogochangecount;
        Texture2D backgroundtexture;
        Texture2D key;
        // << graphics >> see what i see screen changes
        Texture2D seewhatiseered;
        Texture2D seewhatiseeblue;
        Song backgroundmusic;

        SoundEffect soundvalidation;
        MouseState mouseKey;
        Vector2 mouselocation = Vector2.Zero;

        bool isHit;
        // assets on left are the assets that allow you to choose 
        Texture2D choicerock;
        Texture2D middlerock;
        Texture2D paper;
        Texture2D scissors;
        Rectangle choicerockrect;
        Rectangle middlerockrect;
        Rectangle paperrect;
        Rectangle scissorsrect;

        Texture2D[] gogowins;
        // deep master of code buttons
        ButtonObject buttonobject;
        ButtonEngine buttonengine;

        SpriteFont boldfont;
        Texture2D scissorswin;
        Texture2D rockwins;
        Texture2D paperwins;
        // variables for the texture and rectangle for the middle rock that ends or begins the situation

        enum WinningBackground
        {
            scissorswins, paperwins, rockwins, neutral
        }

        WinningBackground winningbackground;
        public static Rectangle leapcollision;
        public enum FingerState
        {
            rainbow, paper, rock, scissors
        }

        public static FingerState fingerstate = FingerState.rainbow;

        #endregion

        #region Constructors
        public PaperRockScissorsState()
        {

            gogochangecount = 0;
            // TODO: Add your initialization logic here
            mouseKey = new MouseState();
            fingertexture = new Texture2D[4];
            leapcollision = new Rectangle(0, 0, 128, 128);

            buttonobject = new ButtonObject();
            buttonengine = new ButtonEngine();
            winningbackground = WinningBackground.neutral;
            // <<CONTROL>> IS HIT
            bool isHit = false;
            endmessagenumber = 0;
            gogowins = new Texture2D[3];
            // leap = new LeapComponet(this);
            //this.Components.Add(leap);

        }
        #endregion


        #region LoadContent
        public override void LoadContent(ContentManager Content)
        {
            // Create a new SpriteBatch, which can be used to draw textures.

            font = Content.Load<SpriteFont>("PaperRockScissors/content/Font1");

            buttonobject.LoadContent(Content);
            buttonengine.LoadContent(Content);

            // << graphics >>> see what is ee words red and blue

            seewhatiseeblue = Content.Load<Texture2D>("PaperRockScissors/backgrounds/seewhatiseeblue");
            seewhatiseered = Content.Load<Texture2D>("PaperRockScissors/backgrounds/seewhatiseered");
            key = Content.Load<Texture2D>("PaperRockScissors/backgrounds/key");

            choicerock = Content.Load<Texture2D>("PaperRockScissors/gameassets/choicerock");
            choicerockrect = new Rectangle(15, 150, 128, 128);
            boldfont = Content.Load<SpriteFont>("PaperRockScissors/content/boldfont");
            scissors = Content.Load<Texture2D>("PaperRockScissors/gameassets/scissors");
            scissorsrect = new Rectangle(15, 300, 128, 128);

            paper = Content.Load<Texture2D>("PaperRockScissors/gameassets/paper");
            paperrect = new Rectangle(15, 450, 128, 128);

            middlerock = Content.Load<Texture2D>("PaperRockScissors/gameassets/middlerock");
            middlerockrect = new Rectangle(550, 250, 128, 128);


            fingertexture[0] = Content.Load<Texture2D>("PaperRockScissors/fingeroptions/rainbowfingers");

            fingertexture[1] = Content.Load<Texture2D>("PaperRockScissors/fingeroptions/paperfinger");
            fingertexture[2] = Content.Load<Texture2D>("PaperRockScissors/fingeroptions/rockfinger");
            fingertexture[3] = Content.Load<Texture2D>("PaperRockScissors/fingeroptions/scissorsfinger");

            // graphics backgroun texture
            backgroundtexture = Content.Load<Texture2D>("PaperRockScissors/gameassets/backgroundtexture");
           // gogowins[0] = Content.Load<Texture2D>("gogowins/gogocanonlywin");
           // gogowins[1] = Content.Load<Texture2D>("gogowins/gogoisthewinner");
           // gogowins[2] = Content.Load<Texture2D>("gogowins/gogowillalwayswin");

            paperwins = Content.Load<Texture2D>("PaperRockScissors/gameassets/paperwins");
            rockwins = Content.Load<Texture2D>("PaperRockScissors/gameassets/rockwins");
            scissorswin = Content.Load<Texture2D>("PaperRockScissors/gameassets/scissorswins");


            #region sound
            backgroundmusic = Content.Load<Song>("PaperRockScissors/sound/bossfight2");
            soundvalidation = Content.Load<SoundEffect>("PaperRockScissors/sound/youwin");

            MediaPlayer.Play(backgroundmusic);
            #endregion
            // leap.LoadContent(Content);
            // TODO: use this.Content to load your game content here
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
            /*  if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                  this.Exit();*/

            // TODO: Add your update logic here
            mouseKey = Mouse.GetState();
            mouselocation.X = mouseKey.X;
            mouselocation.Y = mouseKey.Y;

            buttonengine.Update(gameTime);


            buttonengine.ReceiveFrom_ButtonObject(buttonobject.gogobuttonrect);
            buttonobject.ReceiveFrom_ButtonEngine(buttonengine.SendTo_ButtonObject());

            //collisions to make sure that the options change you must make sure you use the collision of the least moving object no matter what no matter what the situation 
            if (choicerockrect.Intersects(leapcollision))
            {
                fingerstate = FingerState.rock;
            }
            else if (paperrect.Intersects(leapcollision))
            {
                fingerstate = FingerState.paper;
            }

            else if (scissorsrect.Intersects(leapcollision))
            {
                fingerstate = FingerState.scissors;
            }

            // seperate if state ment declaration for winning or losing the game

            if (middlerockrect.Intersects(leapcollision) && (FingerState.paper == fingerstate))
            {
                endmessagenumber = 1;
                isHit = true;
                gogochangecount += 1;
                winningbackground = WinningBackground.paperwins;
            }

            if (middlerockrect.Intersects(leapcollision) && (FingerState.scissors == fingerstate))
            {
                endmessagenumber = 2;
                isHit = true;
                gogochangecount += 1;
                winningbackground = WinningBackground.rockwins;
            }

            if (middlerockrect.Intersects(leapcollision) && (FingerState.rock == fingerstate))
            {
                endmessagenumber = 3;
                isHit = true;
                gogochangecount += 1;
                winningbackground = WinningBackground.rockwins;
            }






        }

        #endregion



        #region Draw
        public override void Draw(SpriteBatch spriteBatch)
        {
            //flash screen for gesture



            //Text for LeapController


            spriteBatch.Draw(backgroundtexture, new Rectangle(0, 0, 800, 600), Color.White);
            //spriteBatch.DrawString(font, leap.DebugLine, new Vector2(10, 10), Color.Wheat);

            spriteBatch.DrawString(boldfont, "THE ONLY TRUE VICTORY IS NOT SEEING THE KEY. . .", new Vector2(0, 100), Color.White);            //ROTATING MESSAGE DEPENDING ON WHO WINS OR WHO LOSES DISPLAYS AFTE4R YOU MAKE CHOICE AND TOUCH ROCK
            spriteBatch.DrawString(boldfont, "IT'S CREATING THE KEY FROM WHAT YOU SEE!", new Vector2(0, 120), Color.White);

            if (endmessagenumber == 1)
            {
                spriteBatch.Draw(seewhatiseeblue, new Rectangle(0, 0, 800, 600), Color.White);

                if (isHit == true)
                {
                    soundvalidation.Play();
                    isHit = false;
                }
            }
            else if (endmessagenumber == 2)
            {
                spriteBatch.Draw(seewhatiseered, new Rectangle(0, 0, 800, 600), Color.White);
                if (isHit == true)
                {
                    soundvalidation.Play();
                    isHit = false;
                }
            }
            else if (endmessagenumber == 3)
            {
                spriteBatch.Draw(key, new Rectangle(0, 0, 800, 600), Color.White);
                if (isHit == true)
                {
                    soundvalidation.Play();
                    isHit = false;
                }
            }

            // <<graphics, pheonomina>> vgips basically makes screen differently upon touch of choice
            /*
            if (winningbackground == WinningBackground.rockwins)
            {
             //   spriteBatch.Draw(rockwins, new Rectangle(0, 0, 800, 600), Color.White);
            }

            else if (winningbackground == WinningBackground.paperwins)
            {
                spriteBatch.Draw(seewhatiseeblue, new Rectangle(0, 0, 800, 600), Color.White);
            }

            else if (winningbackground == WinningBackground.scissorswins)
            {
                spriteBatch.Draw(seewhatiseered, new Rectangle(0, 0, 800, 600), Color.White);
            }
             * */
            // draw paper rock scissors choices lol
            spriteBatch.Draw(choicerock, choicerockrect, Color.White);
            spriteBatch.Draw(scissors, scissorsrect, Color.White);
            spriteBatch.Draw(paper, paperrect, Color.White);

            //rock that you hit to win or lose game the rock on the far right
            spriteBatch.Draw(middlerock, middlerockrect, Color.White);
            #region Choice Fingers Code
            if (FingerState.rainbow == fingerstate)
            {

                foreach (Vector2 fingerLoc in Game1.leap.FingerPoints)
                {
                    //  if (changecolor == false)
                    //  {

                    spriteBatch.Draw(fingertexture[0], fingerLoc, Color.White);
                    //    spriteBatch.Draw(fingertexture[0], Game1.leapa.FirstHandLoc, Color.White);
                    leapcollision.X = (int)fingerLoc.X;
                    leapcollision.Y = (int)fingerLoc.Y;

                    // }

                    /*  else if (nodraw)
                      {
                        
                          spriteBatch.Draw(texture, fingerLoc, Color.Red);
                          spriteBatch.Draw(texture, leapa.FirstHandLoc, Color.Red);
                     
                      } */
                }
                /*foreach (Vector2 fingerLoc in Game1.leap.FingerPoints)
                {

                    spriteBatch.Draw(fingertexture[0], fingerLoc, Color.White);
                    spriteBatch.Draw(fingertexture[0], Game1.leap.FirstHandLoc, Color.White);
                    leapcollision.X = (int)fingerLoc.X;
                    leapcollision.Y = (int)fingerLoc.Y;

                }*/
            }


            else if (FingerState.paper == fingerstate)
            {

                foreach (Vector2 fingerLoc in Game1.leap.FingerPoints)
                {
                    //  if (changecolor == false)
                    //  {

                    spriteBatch.Draw(fingertexture[1], fingerLoc, Color.White);
                    // spriteBatch.Draw(fingertexture[1], Game1.leapa.FirstHandLoc, Color.White);
                    leapcollision.X = (int)fingerLoc.X;
                    leapcollision.Y = (int)fingerLoc.Y;

                    // }

                    /*  else if (nodraw)
                      {
                        
                          spriteBatch.Draw(texture, fingerLoc, Color.Red);
                          spriteBatch.Draw(texture, leapa.FirstHandLoc, Color.Red);
                     
                      } */
                }
                /*
                foreach (Vector2 fingerLoc in Game1.leap.FingerPoints)
                {

                    spriteBatch.Draw(fingertexture[1], fingerLoc, Color.White);
                    spriteBatch.Draw(fingertexture[1], leap.FirstHandLoc, Color.White);
                    leapcollision.X = (int)fingerLoc.X;
                    leapcollision.Y = (int)fingerLoc.Y;
                } */
            }

            else if (FingerState.rock == fingerstate)
            {

                foreach (Vector2 fingerLoc in Game1.leap.FingerPoints)
                {
                    //  if (changecolor == false)
                    //  {

                    spriteBatch.Draw(fingertexture[2], fingerLoc, Color.White);
                    spriteBatch.Draw(fingertexture[2], Game1.leap.FirstHandLoc, Color.White);
                    leapcollision.X = (int)fingerLoc.X;
                    leapcollision.Y = (int)fingerLoc.Y;

                    // }

                    /*  else if (nodraw)
                      {
                        
                          spriteBatch.Draw(texture, fingerLoc, Color.Red);
                          spriteBatch.Draw(texture, leapa.FirstHandLoc, Color.Red);
                     
                      } */
                }
                /*   foreach (Vector2 fingerLoc in Game1.leap.FingerPoints)
                   {

                       spriteBatch.Draw(fingertexture[2], fingerLoc, Color.White);
                       spriteBatch.Draw(fingertexture[2], leap.FirstHandLoc, Color.White);
                   
                   }*/
            }

            else if (FingerState.scissors == fingerstate)
            {
                foreach (Vector2 fingerLoc in Game1.leap.FingerPoints)
                {
                    //  if (changecolor == false)
                    //  {

                    spriteBatch.Draw(fingertexture[3], fingerLoc, Color.White);
                    spriteBatch.Draw(fingertexture[3], Game1.leap.FirstHandLoc, Color.White);
                    leapcollision.X = (int)fingerLoc.X;
                    leapcollision.Y = (int)fingerLoc.Y;

                    // }

                    /*  else if (nodraw)
                      {
                        
                          spriteBatch.Draw(texture, fingerLoc, Color.Red);
                          spriteBatch.Draw(texture, leapa.FirstHandLoc, Color.Red);
                     
                      } */
                }
            }
            #endregion

            buttonobject.Draw(spriteBatch);



        }

        #endregion
    }
}
