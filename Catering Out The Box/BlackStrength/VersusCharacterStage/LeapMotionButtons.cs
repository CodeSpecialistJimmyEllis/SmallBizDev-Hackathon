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


namespace CateringOutTheBox
{
    public class LeapMotionButtons
    {

        // leap components
        public static LeapComponet leap;
        public static Rectangle leapCollision;
        Texture2D fingerTexture;
        Rectangle[] fingerLocations;

        //
        Texture2D[] buttons;
       Rectangle[] buttonsRect;
       public Rectangle[] ButtonsRect { get { return buttonsRect; } set { buttonsRect = value; } }
        GameTime storedGameTime;
        Color[] buttonColor;

        public enum LeapButtons
        {
            A, B, nohit
        }
        LeapButtons leapButtons;

        public LeapButtons P_LeapButtons { get { return leapButtons; } set { leapButtons = value; } }
        public LeapMotionButtons()
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
            buttons = new Texture2D[2];

            /* for (int i = 0; i < 4; i++)
             {
                 buttons = new Texture2D[i];
             }*/

            buttonsRect = new Rectangle[2];

            buttonsRect[0] = new Rectangle(100, 300, 256, 256);

            buttonsRect[1] = new Rectangle(400, 300, 256, 256);
            buttonColor = new Color[2];
            buttonColor[0] = Color.White;
            buttonColor[1] = Color.White;

            leapButtons = LeapButtons.nohit;

        }

        public void LoadContent(ContentManager Content)
        {

            buttons[0] = Content.Load<Texture2D>("VersusCharacter/buttons/A");
            buttons[1] = Content.Load<Texture2D>("VersusCharacter/buttons/B");


            // leap component fingertips
            fingerTexture = Content.Load<Texture2D>("VersusCharacter/leap/finger");

        }

        public void Update(GameTime gameTime)
        {

            #region button algorithim to change color

            // a button
            if (fingerLocations[0].Intersects(buttonsRect[0]))
            {
                buttonColor[0] = Color.Black;
                leapButtons = LeapButtons.A;

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
            }
            else
            {
                buttonColor[1] = Color.White;
            }

            // x button




            #endregion




        }

        public void Draw(SpriteBatch spriteBatch)
        {



            spriteBatch.Draw(buttons[0], buttonsRect[0], buttonColor[0]);
            spriteBatch.Draw(buttons[1], buttonsRect[1], buttonColor[1]);

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
