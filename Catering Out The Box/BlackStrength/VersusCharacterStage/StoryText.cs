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
    class StoryText
    {
        #region Fields
        int timePassedBetweenTextChange;

        int changeNumber;
        SpriteFont wordFont;
        Color wordColor;
        string[] chosenWords;
        bool isSentenceChanged;

        bool timeControl;
        Vector2 wordLocationFieldOne;
        Vector2 wordLocationFieldTwo;
        Vector2 wordLocationFieldThree;


        enum Paragraphs
        {
            first, second, third
        }

        Paragraphs paragraphs;

        int sentenceNumberFieldOne;
        int sentenceNumberFieldTwo;
        int sentenceNumberFieldThree;

        #endregion


        #region Constructors
        public StoryText()
        {
            timePassedBetweenTextChange = 0;


            timeControl = false;
            isSentenceChanged = false;
            sentenceNumberFieldOne = 1;
            sentenceNumberFieldTwo = 2;
            sentenceNumberFieldThree = 3;
            changeNumber = 0;
            wordLocationFieldOne = new Vector2(100, 500);
            wordLocationFieldTwo = new Vector2(100, 520);
            wordLocationFieldThree = new Vector2(100, 540);
            wordColor = Color.Black;
            chosenWords = new string[10];
            chosenWords[0] = " ";
            chosenWords[1] = "THE PROCESSOR IS KING OF THE GENIUS GAME AND OF CODE.";
            chosenWords[2] = "THE TRUE NATURE OF CODE IS THE HIGHEST UNDERSTANDING OF MATHEMATICS.";
            chosenWords[3] = "IF THIS IS TRUE THEN SOFTWARE INDUSTRY = GENIUS GAME.";
            chosenWords[4] = "FOR SURELY YOU MUST BE A SCIENTIST TO WIN!";
            chosenWords[5] = "AND THUS THE GENIUS GAME IS SO!";
            chosenWords[6] = "REMEMBER THESE WORDS FOREVER!";
            chosenWords[7] = "FOR THEY ARE THE DECLARATION OF THE TRUE CHAMPION OF LIFE!";
            chosenWords[8] = "THE ONE WHO WILL DEFEAT ALL ENEMIES AND NEVER LOSE AGAIN!";
            chosenWords[9] = "ONLY THROUGH CHRIST JESUS IS THIS SO! JESUS IS LORDD!";

        }

        #endregion

        public void Initialize()
        {

        }

        public void LoadContent(ContentManager Content)
        {
            wordFont = Content.Load<SpriteFont>("VersusCharacter/words/SpriteFont1");
        }


        public void UnloadContent()
        {

        }


        public void TextControl()
        {

        }

        public void Update(GameTime gameTime)
        {
            #region TextControl

            if (timeControl == true)
            {

                if (isSentenceChanged == false)
                {
                    isSentenceChanged = true;
                    timePassedBetweenTextChange = gameTime.TotalGameTime.Seconds;
                }



                if ((timePassedBetweenTextChange + 3) < (gameTime.TotalGameTime.Seconds))
                {


                    paragraphs = Paragraphs.second;
                }

            }




            if (Keyboard.GetState(PlayerIndex.One).IsKeyDown(Keys.Enter) && (Paragraphs.first == paragraphs))
            {



                sentenceNumberFieldOne = 4;
                sentenceNumberFieldTwo = 5;
                sentenceNumberFieldThree = 6;


                timeControl = true;
            }




            else if (Keyboard.GetState(PlayerIndex.One).IsKeyDown(Keys.Enter) && (Paragraphs.second == paragraphs))
            {



                sentenceNumberFieldOne = 7;
                sentenceNumberFieldTwo = 8;
                sentenceNumberFieldThree = 9;


                timeControl = true;

            }
            #endregion

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            // debug conmment out
            /*    spriteBatch.DrawString(wordFont, gameTime.TotalGameTime.Seconds.ToString(), new Vector2(0, 0), wordColor);
                spriteBatch.DrawString(wordFont, "time passed between text change " + timePassedBetweenTextChange.ToString(), new Vector2(0, 20), wordColor);
                spriteBatch.DrawString(wordFont, paragraphs.ToString(), new Vector2(0, 40), wordColor);
                spriteBatch.DrawString(wordFont, "time control" + timeControl.ToString(), new Vector2(0, 60), wordColor); */
            //
            spriteBatch.DrawString(wordFont, chosenWords[sentenceNumberFieldOne], wordLocationFieldOne, wordColor);
            spriteBatch.DrawString(wordFont, chosenWords[sentenceNumberFieldTwo], wordLocationFieldTwo, wordColor);
            spriteBatch.DrawString(wordFont, chosenWords[sentenceNumberFieldThree], wordLocationFieldThree, wordColor);
        }

    }
}
