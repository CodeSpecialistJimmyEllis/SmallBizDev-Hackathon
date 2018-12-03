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
    public class BallObject
    {

        #region Fields 
        // RANDOM NUMBER TO SET THE SCREEN TO DISPLAY BALLOFTRUTH
       
        //BALLOFTRUTH SPEED
        public  int BALLOFTRUTHSPEED;
        //STATUS BAR ON RIGHT
        public Rectangle ballrect;
        public Texture2D BALLOFTRUTH;
        public  int resetCount;
        public  Vector2 BALLPOSITIONOFTRUTH;

      
            
        public bool controlpositionx;
        public bool controlpositiony;

      
        //SpriteFont FONTOFTRUESCORE;
        //Vector2 FONTOFTRUESCOREPOSITION = Vector2.Zero;
        //Texture2D BACKGROUND;
        // Vector2 BACKGROUNDPOSITION = Vector2.Zero;

        #endregion

  


        
       



        public BallObject()
        {

            this.resetCount = 0;
         this.BALLPOSITIONOFTRUTH = Vector2.Zero;

         this.BALLOFTRUTHSPEED = 1;
        }
    
        public void Initialize()
        {

        }

        public void LoadContent(ContentManager Content)
        {

            this.ballrect = new Rectangle(0, 0, 27, 24);



            //DISPLAY SCORE ON RIGHT
     



            // IN GAME ASSETS ON LEFT
            this.BALLOFTRUTH = Content.Load<Texture2D>("ballgameengine/ball");
            //BALLPOSITIONOFTRUTH.X;
            //BALLPOSITIONOFTRUTH.Y;
     




            //LOADING sprite font for the SCORE OF TRUTH


            //
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
        //CONNECTED TO THE BALLMOVEMENT METHOD AND IS BEFORE THE UPDATEMETHOD

        public void Update(GameTime gameTime)
        {
            // Allows the game to exit


          //  ControlledBy_BallEngine();
          //  ballrect.X = (int)BALLPOSITIONOFTRUTH.X;
           // ballrect.Y = (int)BALLPOSITIONOFTRUTH.Y;



            


        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public void Draw(SpriteBatch spriteBatch)
        {



            // TODO: Add your drawing code here
           
        //    spriteBatch.Draw(SCORE, SCOREPOSITION, Color.White);

            //GAMEPLAY
            spriteBatch.Draw(BALLOFTRUTH, this.BALLPOSITIONOFTRUTH, Color.White);
     



        }

        public void ControlledBy_BallEngine(bool newcontrolpositionx, bool newcontrolpositiony, Vector2 newballposition)
        {
            this.BALLPOSITIONOFTRUTH = newballposition;
            this.controlpositionx = newcontrolpositionx;
            this.controlpositiony = newcontrolpositiony;
        }


     /*   public Texture2D SendTexture2DTo_BallEngine()
        {

            return 
        }*/

      





    }
}
