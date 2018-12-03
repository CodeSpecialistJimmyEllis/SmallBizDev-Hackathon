﻿// JESUS IS LORD! ONLY THROUGH CHRIST JESUS WHO IS GOD IS THIS POSSIBLE! JESUS IS LORD!

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace BlackStrength
{
    public class VideoGameVideo : GameScreen
    {

        #region Fields
        KeyboardState keyState;

        //JESUS IS LORD <<< GRAPHICS >>> DISPLAYS THE TEXT ON THE SCREEN JESUS IS LORD
        //JESUS IS LORD! <<< GRPAHICS >>> FONT USED TO DISPLAY MESSAGES
        SpriteFont font;

        //JESUS IS LORD <<< GRAPHICS >>> FONT USED TO DISPLAY MESSAGES
        SpriteFont font2;

        // JESUS IS LORD! <<< GRAPHICS / BACKGROUND >>> LOADS THE BACKGROUND FOR GOKU WIN JESUS IS LORD!
        Texture2D gWinBackground;
        Rectangle gWinRect;

        #region control fields
        //ALLOWS YOU TO GO STRAIGHT TO ALTERNATE ENDINGS IF YOU'VE PLAYED THE GAME ONCE!
        bool isLooped = true;
        #endregion
        // <<< JESUS IS LORD!! <<< VIDEO JESUS IS THE KING>> CREATES THE VIDEO AND THE VIDE PLAYER FOR PLAYING VIDE JESUS IS LORD!! JESUSI S THE KING!
        Video gokuWinsVid;
        VideoPlayer gokuPlayer;
        // JESUS IS LORD <<< GRAPHICS / VIDEO >>> TEXTURE VIDEO DISPLAYS ON
        Texture2D gokuVidTexture;
        Rectangle gokuVidRect;
        // JESUS IS LORD! <<< GRAPHICS / SPRITES >>> THE SPRITES THAT APPEAR ON THE SCREEN ARE SUPERMAN HAVING LOST AND GOKU HAVING WON

        //JESUS IS LORD <<< CONTROL FLOW>>> 
        bool isDisposed = false;

        #endregion

        #region Constructors
        public VideoGameVideo()
        {


        }

        #endregion 

        #region LoadContent
        public override void LoadContent(ContentManager Content)
        {
            base.LoadContent(Content);

            #region LoadText
            //JESUS IS LORD <<< GRAPHICS >>> LOAD RESPECTIVE SPRITE FONTS FOR RESPECTIVE TEXT DISPLAY ON SCREEN JESUS IS LORD!
            if (font == null)
                font = content.Load<SpriteFont>("VideoGameVideo/content/Font1");
            if (font2 == null)
                font2 = content.Load<SpriteFont>("VideoGameVideo/content/Font2");
            #endregion
            #region Backgrounds
            // JESUS IS LORD <<< GRAPHICS / BACKGROUND >>> LOAD THE BACKGROUND AND CREATE IT'S RECTANGLE DIMENSIONS 

            gWinBackground = content.Load<Texture2D>("VideoGameVideo/backgrounds/videobackground");
            gWinRect = new Rectangle(800, 600, 800, 600);

            #endregion

            #region Sprites
            // JESUS IS LORD <<< GRAPHICS /// SPRITES >>> THE SPRITES ARE GOKU HAVING WON AND SUPERMAN HAVING LOST APPEARING ON THE SCREEN JESUS IS LORD!



            #endregion
            #region Sounds

            // JESUS IS LORD!!! <<< SOUNDS /// SOUND EFFECTS & BACKGROUND MUSIC >>>> THE BACKGROUND MUSIC PLAYED AND THE SOUND EFFECTS OF SUPERMAN HAVING LOST 

            // TODO: SUPER MAN WORDS OF LOST. GOKU WORDS OF VICTORY. 

            #endregion

            #region Video

            // JESUS IS LORD!!! <<< VIDEO>>> JESUS IS LORD! THE VIDE WHERE GOKU WINS
            gokuPlayer = new VideoPlayer();
            gokuVidRect = new Rectangle(0, 0, 800, 600);
            gokuWinsVid = content.Load<Video>("VideoGameVideo/videos/videogamevideo01");
            gokuPlayer.Volume = 1.0f;

            //gokuPlayer.Volume = 5;
            gokuPlayer.Play(gokuWinsVid);

            #endregion



        }
        #endregion

        #region UnloadContent
        public override void UnloadContent()
        {
            gokuVidTexture.Dispose();
            //  gokuVidRect.Dispose();
            gokuPlayer.Dispose();

            base.UnloadContent();
        }
        #endregion

        #region Update
        public override void Update(GameTime gameTime)
        {

            keyState = Keyboard.GetState();
            if (keyState.IsKeyDown(Keys.Enter))
              //  ScreenManager.Instance.AddScreen(new SplashScreen());

            if (isDisposed == false)
            {
                if (gokuPlayer.State == MediaState.Stopped)
                {
                    if (isDisposed == false)
                    {

                        // UnloadContent();
                        //isDisposed = true;
                        gWinRect.X = 0;
                        gWinRect.Y = 0;
                    }
                }
            }
            keyState = Keyboard.GetState();
            if (keyState.IsKeyDown(Keys.D9))
            {
              //  ScreenManager.Instance.AddScreen(new SplashScreen(isLooped));

                UnloadContent();
                gokuPlayer.Dispose();
                gokuVidTexture.Dispose();


            }

        }
        #endregion

        #region Draw
        public override void Draw(SpriteBatch spriteBatch)
        {
            /*    spriteBatch.DrawString(font, "TitleScreen",
                   new Vector2(100, 100), Color.Black); */

            if (isDisposed == false)
            {
                gokuVidTexture = gokuPlayer.GetTexture();


                spriteBatch.Draw(gokuVidTexture, gokuVidRect, Color.White);
            }

            spriteBatch.Draw(gWinBackground, gWinRect, Color.White);
            spriteBatch.DrawString(font, "HIT 9 TO RESTART GAME", new Vector2(70, 550), Color.White);


        }

        #endregion
    }
}
