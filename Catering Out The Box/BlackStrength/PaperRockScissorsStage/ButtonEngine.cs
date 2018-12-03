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
    class ButtonEngine
    {
        bool timecontrol;

        int timeint;
        Rectangle gogobuttonrect;
        enum ChosenButton
        {
            button1, button2
        }
        ChosenButton chosenbutton = ChosenButton.button1;

        public ButtonEngine()
        {

        }

        public void Initialize()
        {
        }

        public void LoadContent(ContentManager Content)
        {
        }

        public void UnloadContent()
        {
        }

        public void Update(GameTime gameTime)
        {

            if (gogobuttonrect.Intersects(Game1.leapcollision))
            {

                chosenbutton = ChosenButton.button2;

                if (PaperRockScissorsState.fingerstate == PaperRockScissorsState.FingerState.rock)
                {
                    MediaPlayer.Stop();
                    ScreenManager.openingtitlescreenthree = new OpeningTitleScreenThree();
                   ScreenManager.Instance.AddScreen(ScreenManager.openingtitlescreenthree);
                }

            }


            else
            {
                chosenbutton = ChosenButton.button1;


            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
        }

        public string SendTo_ButtonObject()
        {
            if (ChosenButton.button1 == chosenbutton)
            {
                return "button1";
            }
            else if (ChosenButton.button2 == chosenbutton)
            {
                return "button2";
            }

            else
            {
                return "button1";
            }
        }

        public void ReceiveFrom_ButtonObject(Rectangle newgogobuttonrect)
        {

            this.gogobuttonrect = newgogobuttonrect;
        }
    }
}
