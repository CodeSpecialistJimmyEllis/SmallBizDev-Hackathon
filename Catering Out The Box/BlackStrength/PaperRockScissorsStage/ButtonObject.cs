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
    class ButtonObject
    {

        Texture2D[] gogobutton;
        public Rectangle gogobuttonrect;
        int chosenbutton;
        public ButtonObject()
        {
            this.chosenbutton = 0;
            gogobutton = new Texture2D[2];

            gogobuttonrect = new Rectangle(525, 500, 256, 128);

        }

        public void Initialize()
        {

        }

        public void LoadContent(ContentManager Content)
        {
            gogobutton[0] = Content.Load<Texture2D>("PaperRockScissors/buttons/button");
            gogobutton[1] = Content.Load<Texture2D>("PaperRockScissors/buttons/buttonhit");

        }

        public void UnloadContent()
        {
        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (chosenbutton == 0)
            {
                spriteBatch.Draw(gogobutton[chosenbutton], gogobuttonrect, Color.White);
            }
            else if (chosenbutton == 1)
            {
                spriteBatch.Draw(gogobutton[chosenbutton], gogobuttonrect, Color.Black);
            }
        }

        public void SendTo_ButtonEngine()
        {
        }
        public void ReceiveFrom_ButtonEngine(string newchosenbutton)
        {

            if (newchosenbutton == "button1")
            {
                chosenbutton = 0;
            }

            else if (newchosenbutton == "button2")
            {
                chosenbutton = 1;
            }

        }
    }
}
