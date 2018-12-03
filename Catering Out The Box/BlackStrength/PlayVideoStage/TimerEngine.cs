

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

namespace BlackStrength
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class TimeEngineVideoStage
    {
    
        SpriteFont font;
        string time;
        TimeSpan timer, eTime, cTime;
        Vector2 position = new Vector2(50, 550);

        public TimeEngineVideoStage()
        {
            this.time = "";
            this.cTime = new TimeSpan(0, 0, 0);
           
        
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
         public void Initialize()
        {
            // TODO: Add your initialization logic here

           
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
         public void LoadContent(ContentManager Content)
        {
            // Create a new SpriteBatch, which can be used to draw textures.
          
            font = Content.Load<SpriteFont>("timeengine/SpriteFont1");
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
         public void UnloadContent()
        {
          
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        /// 




         public void Update(GameTime gameTime)
        {
            // Allows the game to exit
          
            // TODO: Add your update logic here
            timer += gameTime.ElapsedGameTime;
            eTime = gameTime.TotalGameTime;
            if (eTime.Minutes < 10)
                time = "Time - 0" + (int)(eTime.Minutes);
            else
                time = "Time - " + (int)(eTime.Minutes);
            if (eTime.Seconds < 10)
                time += ":0" + (int)(eTime.Seconds);
            else
                time += ":" + (int)(eTime.Seconds);

        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
         public void Draw(SpriteBatch spriteBatch)
        {
         

            // TODO: Add your drawing code he   re
           
            spriteBatch.DrawString(font, timer.ToString(), position, Color.Red);

          /*  if ((int)eTime.Seconds > 2)
            {
                spriteBatch.DrawString(font, timer.ToString(), new Vector2(0, 0), Color.Blue);
            }*/
        
       
        }

       public int SendTo_BallObjectEngine()
        {


            return (int)eTime.Seconds; 
            // sends timer information to the ball object engine through game1.cs
        }

        public void ReceiveFrom_BallObjectEngine()
        {
            // controls the timer from the ball object engine through game1.cs

        }
    }
}
