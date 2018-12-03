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
    public class ValidationObjectEngine
    {
        public bool changealternatingvalidations;



        public bool playvalidationsound;

        Texture2D bluevalidation;
        Texture2D redvalidation;
        Texture2D yellowvalidation;
        Texture2D greenvalidation;
        SoundEffect yourgreat;
        public Rectangle validationrect;
        int alternatingvalidations;
        public bool soundtrigger ;
        public bool arttrigger; 
        public ValidationObjectEngine()
        {
            // trigger to see if validation is played or not
            arttrigger = false;
            alternatingvalidations = 0;
            validationrect = new Rectangle(0, 0, 256, 256);
            soundtrigger = false;
            validationrect = new Rectangle(0, 0, 0, 0);

            changealternatingvalidations = false;

            alternatingvalidations = 1;

            playvalidationsound = false;
        }

        public void Initialize()
        {

        }

        public void LoadContent(ContentManager Content)
        {

            yellowvalidation = Content.Load<Texture2D>("PlayVideoStage/validationart/yellowvalidation");
            greenvalidation = Content.Load<Texture2D>("PlayVideoStage/validationart/greenvalidation");
            redvalidation = Content.Load<Texture2D>("PlayVideoStage/validationart/redvalidation");
            bluevalidation = Content.Load<Texture2D>("PlayVideoStage/validationart/bluevalidation");

            yourgreat = Content.Load<SoundEffect>("PlayVideoStage/validationsound/yourgreat");

        }

        public void UnloadContent()
        {
        }

        public void Update(GameTime gameTime)
        {
            // triggered from other classs to see if it is time to go through this process
            if (soundtrigger == true)
            {
                if (playvalidationsound == false)
                {

                    SoundEffect.MasterVolume = 0.1f;
                    //MediaPlayer.Volume = 0.0f;
                    yourgreat.Play();
                    playvalidationsound = true;
                }

                soundtrigger = false;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {

            if (changealternatingvalidations == false)
            {
                if (alternatingvalidations == 1)
                {
                    alternatingvalidations = 2;
                }

                else if (alternatingvalidations == 2)
                {
                    alternatingvalidations = 3;
                }

                else if (alternatingvalidations == 3)
                {
                    alternatingvalidations = 4;
                }

                else if (alternatingvalidations == 4)
                {
                    alternatingvalidations = 1;
                }
                changealternatingvalidations = true;
            }

            if (arttrigger == true)
            {
                if (alternatingvalidations == 1)
                {
                    spriteBatch.Draw(redvalidation, validationrect, Color.White);
                }
                else if (alternatingvalidations == 2)
                {
                    spriteBatch.Draw(bluevalidation, validationrect, Color.White);
                }
                else if (alternatingvalidations == 3)
                {
                    spriteBatch.Draw(yellowvalidation, validationrect, Color.White);
                }
                else if (alternatingvalidations == 4)
                {
                    spriteBatch.Draw(greenvalidation, validationrect, Color.White);
                }
            }
        }
    }
}
