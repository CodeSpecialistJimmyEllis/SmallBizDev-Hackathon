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
    class LeapMotionButtonsButtonMatch
    {

        // leap components
        public static LeapComponet leap;
        public static Rectangle leapCollision;
        Texture2D fingerTexture;
        Rectangle[] fingerLocations;

        //
        Texture2D[] buttons;
        Rectangle[] buttonsRect;
        GameTime storedGameTime;
        Color[] buttonColor;

        enum LeapButtons
        {
            A, B, X, Y, nohit
        }
        LeapButtons leapButtons;


        public LeapMotionButtonsButtonMatch()
        {

            // leap collisions redone
            fingerLocations = new Rectangle[5];
            fingerLocations[0] = new Rectangle(800, 600, 128, 128);
            fingerLocations[1] = new Rectangle(0, 0, 128, 128);
            fingerLocations[2] = new Rectangle(0, 0, 128, 128);
            fingerLocations[3] = new Rectangle(0, 0, 128, 128);
            fingerLocations[4] = new Rectangle(0, 0, 128, 128);
            // leap collision
            leapCollision = new Rectangle(0, 0, 128, 128);
            // TODO: Add your initialization logic here
            storedGameTime = new GameTime();
            buttons = new Texture2D[4];

            /* for (int i = 0; i < 4; i++)
             {
                 buttons = new Texture2D[i];
             }*/

            buttonsRect = new Rectangle[4];

            buttonsRect[0] = new Rectangle(50, 100, 64, 64);
            buttonsRect[3] = new Rectangle(700, 500, 64, 64);
            buttonsRect[2] = new Rectangle(50, 500, 64, 64);
            buttonsRect[1] = new Rectangle(700, 100, 64, 64);
            buttonColor = new Color[4];
            buttonColor[0] = Color.White;
            buttonColor[1] = Color.White;
            buttonColor[2] = Color.White;
            buttonColor[3] = Color.White;
            leapButtons = LeapButtons.nohit;

        }

        public void LoadContent(ContentManager Content)
        {

            buttons[0] = Content.Load<Texture2D>("ButtonMatch/buttons/A");
            buttons[1] = Content.Load<Texture2D>("ButtonMatch/buttons/B");
            buttons[2] = Content.Load<Texture2D>("ButtonMatch/buttons/X");
            buttons[3] = Content.Load<Texture2D>("ButtonMatch/buttons/Y");

            // leap component fingertips
            fingerTexture = Content.Load<Texture2D>("ButtonMatch/ResumeGamePlayState/hero/heroprojectile");

        }

        public void Update(GameTime gameTime)
        {

            #region button algorithim to change color

            // a button
            if (fingerLocations[0].Intersects(buttonsRect[0]))
            {
                buttonColor[0] = Color.Black;
                leapButtons = LeapButtons.A;
                ScreenManager.resumevideogame.Whichbuttonhit = ResumeVideoGame.WhichButtonHit.a;
                ScreenManager.resumevideogame.IsHit = true;
            }
            else
            {
                buttonColor[0] = Color.White;

            }

            // b button
            if (fingerLocations[0].Intersects(buttonsRect[1]))
            {
                buttonColor[1] = Color.Black;
                leapButtons = LeapButtons.B;
                ScreenManager.resumevideogame.Whichbuttonhit = ResumeVideoGame.WhichButtonHit.b;
                ScreenManager.resumevideogame.IsHit = true;
            }
            else
            {
                buttonColor[1] = Color.White;

            }

            // x button

            if (fingerLocations[0].Intersects(buttonsRect[2]))
            {
                buttonColor[2] = Color.Black;
                leapButtons = LeapButtons.X;
                ScreenManager.resumevideogame.Whichbuttonhit = ResumeVideoGame.WhichButtonHit.x;
                ScreenManager.resumevideogame.IsHit = true;
            }
            else
            {
                buttonColor[2] = Color.White;

            }


            // y button

            if (fingerLocations[0].Intersects(buttonsRect[3]))
            {
                buttonColor[3] = Color.Black;
                leapButtons = LeapButtons.Y;
                ScreenManager.resumevideogame.Whichbuttonhit = ResumeVideoGame.WhichButtonHit.y;
                ScreenManager.resumevideogame.IsHit = true;
            }
            else
            {
                buttonColor[3] = Color.White;

            }



            #endregion




        }

        public void Draw(SpriteBatch spriteBatch)
        {



            spriteBatch.Draw(buttons[0], buttonsRect[0], buttonColor[0]);
            spriteBatch.Draw(buttons[1], buttonsRect[1], buttonColor[1]);
            spriteBatch.Draw(buttons[2], buttonsRect[2], buttonColor[2]);
            spriteBatch.Draw(buttons[3], buttonsRect[3], buttonColor[3]);
            foreach (Vector2 fingerLoc in Game1.leap.FingerPoints)
            {
                float tempX = fingerLoc.X;
                float tempY = fingerLoc.Y;
                fingerLocations[0].X = (int)tempX;
                fingerLocations[0].Y = (int)tempY;
                spriteBatch.Draw(fingerTexture, fingerLocations[0], Color.White);
            }



        }
    }
}
