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

namespace CateringOutTheBox
{
    class BackgroundSolutionScrolling
    {
        #region Fields

        #region Standard Number Enumeration

        enum Number
        {
            one = 1, two, three, four, five, six, seven, eight, nine, ten
        }
        Number number;

        #endregion
        #region False Concept Zero

        enum Zero
        {
            zero
        }

        Zero zeroFalseIdea;
        #endregion

        #region Number: backgrounds | data fields: how many, position,
        Vector2[] backgroundPosition;
        Vector2[] backgroundSize;
        int howManyBackgrounds;

        #endregion

        #region Nmber: backgrounds | Object

        Rectangle[] backgroundObjectRect;
        Texture2D[] backgroundObject;
        #endregion


        #region Number: backgrounds | Future/Truth: DataChange Over Time

        Vector2[] backgroundPositionsFutureTruths;

        #endregion
        #endregion


        #region Constructor

        public BackgroundSolutionScrolling()
        {
            howManyBackgrounds = (int)Number.two;


            backgroundSize = new Vector2[(int)Number.two];
            backgroundSize[(int)zeroFalseIdea].X = 1024; // one thousand twenty four
            backgroundSize[(int)zeroFalseIdea].Y = 720; // seven hundred twenty 
            backgroundSize[(int)Number.one].X = 1024; // one thousand twenty four
            backgroundSize[(int)Number.one].Y = 720; // seven hundred twenty

            backgroundPosition = new Vector2[(int)Number.two];
            backgroundPosition[(int)zeroFalseIdea].X = (int)zeroFalseIdea;
            backgroundPosition[(int)zeroFalseIdea].Y = (int)zeroFalseIdea;

            backgroundPosition[(int)Number.one].X = -1024; // negative one thousand twenty four
            backgroundPosition[(int)Number.one].Y = (int)zeroFalseIdea;

            number = Number.one;

            backgroundObject = new Texture2D[(int)Number.two];

            // future truths
            backgroundPositionsFutureTruths = new Vector2[howManyBackgrounds];
            backgroundPositionsFutureTruths[(int)zeroFalseIdea] = new Vector2(1024, 0);
            backgroundPositionsFutureTruths[(int)Number.one] = new Vector2(0, 0);


            backgroundObjectRect = new Rectangle[howManyBackgrounds];
            backgroundObjectRect[(int)zeroFalseIdea] = new Rectangle((int)backgroundPosition[(int)zeroFalseIdea].X, (int)backgroundPosition[(int)zeroFalseIdea].Y, (int)backgroundSize[(int)zeroFalseIdea].X, (int)backgroundSize[(int)zeroFalseIdea].Y);
            backgroundObjectRect[(int)Number.one] = new Rectangle((int)backgroundPosition[(int)Number.one].X, (int)backgroundPosition[(int)Number.one].Y, (int)backgroundSize[(int)Number.one].X, (int)backgroundSize[(int)Number.one].Y);
        }

        #endregion

        public void LoadContent(ContentManager Content)
        {
            backgroundObject[(int)zeroFalseIdea] = Content.Load<Texture2D>("VersusCharacter/background/backgroundA");
            backgroundObject[(int)Number.one] = Content.Load<Texture2D>("VersusCharacter/background/backgroundB");

        }

        public void UnloadContent()
        {
        }

        public void BackgroundScroll()
        {
            if ((backgroundPosition[(int)zeroFalseIdea].X < backgroundPositionsFutureTruths[(int)zeroFalseIdea].X))
            {
                backgroundObjectRect[(int)zeroFalseIdea].X += (int)Number.five;
                if ((backgroundObjectRect[(int)zeroFalseIdea].X) >= (backgroundPositionsFutureTruths[(int)zeroFalseIdea].X))
                {
                    backgroundObjectRect[(int)zeroFalseIdea].X = (int)backgroundPosition[(int)zeroFalseIdea].X;

                }
            }

            if ((backgroundPosition[(int)Number.one].X < backgroundPositionsFutureTruths[(int)Number.one].X))
            {
                backgroundObjectRect[(int)Number.one].X += (int)Number.five;
                if ((backgroundObjectRect[(int)Number.one].X) >= (backgroundPositionsFutureTruths[(int)Number.one].X))
                {
                    backgroundObjectRect[(int)Number.one].X = (int)backgroundPosition[(int)Number.one].X; ;

                }
            }
        }
        public void Update(GameTime gameTime)
        {

            // future / truth/ data change equation!!!!!! 



            BackgroundScroll();



            /*
        else
        {
                
        }*/

            /*
            if ((backgroundPosition[(int)zeroFalseIdea].X >= backgroundPositionsFutureTruths[(int)zeroFalseIdea].X))
            {
                 //(int)backgroundPosition[(int)zeroFalseIdea].X;
            }*/

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(backgroundObject[(int)zeroFalseIdea], backgroundObjectRect[(int)zeroFalseIdea], Color.White);
            spriteBatch.Draw(backgroundObject[(int)Number.one], backgroundObjectRect[(int)Number.one], Color.White);
        }
    }
}
