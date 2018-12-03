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
using System.Diagnostics;
namespace CateringOutTheBox
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class VersusCharacter : GameScreen 
    {

        // leap
        public static LeapComponet leap;
        public static Rectangle leapCollision;
        Texture2D fingerTexture;
        Rectangle[] fingerLocations;
        //


        Texture2D backgroundStatic;
        // collisionDetection
        bool isCollisionDetected;

        // debug 
        SpriteFont debugFont;
        // leap buttons
        public static LeapMotionButtons leapMotionButtons;
        public static LeapMotionButtons P_leapMotionButtons { get { return leapMotionButtons; } }
        // Collision Detection Class
        CollisionDetection collisionDetection;

        Character secondCharacter;

        //a bird number. the data fields, the object, and it's future in motion calculC:\Users\GeniusGameEmployee\Documents\Visual Studio 2012\Projects\GENIUS GAME CONTINUED\WindowsGame8\WindowsGame8\Game1.csated, solved, and repeated.
        Character firstCharacter;
        // a scrolling background number. the data fields, thre objects, and it's future in motion calculated, solved, and repeated.
        BackgroundSolutionScrolling scrollingBackground;

        // a story text number. the data fields, thre objects, and it's future in motion calculated, solved, and repeated.
        StoryText storyText;

        // a number is an object in object oriented programming. Everything a number is is what an object is. Now I truly understand
        // object oriented programming on a root level to advanced level to beyond level as such I am MASTER. 


        // NUMBER | Screen Size TRUTH FUTURE
        Vector2 screenSizeFutureTruth = new Vector2(800, 600);

        public VersusCharacter()
        {


            isCollisionDetected = false;

            leapCollision = new Rectangle(0, 0, 128, 128);

            // TODO: Add your initialization logic here

            leapMotionButtons = new LeapMotionButtons();

            // Variables for constructors only
            Rectangle[] characterOneRect = new Rectangle[1];
            characterOneRect[0] = new Rectangle(0, 360, 128, 128);

            Rectangle[] characterTwoRect = new Rectangle[1];
            characterTwoRect[0] = new Rectangle(670, 360, 128, 128);
            // calling the bird constructor and thus creating the object
            firstCharacter = new Character(new Vector2(512, 360), "right", characterOneRect);
            secondCharacter = new Character(new Vector2(512, 360), "left", characterTwoRect);
            firstCharacter.Initialize();
            secondCharacter.Initialize();
            // calling the constructor of the backgroudn solution and thus creating the object
            scrollingBackground = new BackgroundSolutionScrolling();


            // calling the constructor of the story text object thus creating the object
            storyText = new StoryText();
            collisionDetection = new CollisionDetection(firstCharacter.BirdObjectRect, secondCharacter.BirdObjectRect);


            // leap 
            fingerLocations = new Rectangle[5];
            fingerLocations[0] = new Rectangle(800, 600, 128, 128);
            fingerLocations[1] = new Rectangle(0, 0, 128, 128);
            fingerLocations[2] = new Rectangle(0, 0, 128, 128);
            fingerLocations[3] = new Rectangle(0, 0, 128, 128);
            fingerLocations[4] = new Rectangle(0, 0, 128, 128);
            // leap collision
            leapCollision = new Rectangle(0, 0, 128, 128);
            // TODO: Add your initialization logic here

        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        public override void LoadContent(ContentManager Content)
        {
            base.LoadContent(Content);
            // Create a new SpriteBatch, which can be used to draw textures.

            // loading the content of the number/object's bird, scrollingbackground, and the story text.
            firstCharacter.LoadContent(Content);
            secondCharacter.LoadContent(Content);
            scrollingBackground.LoadContent(Content);
            storyText.LoadContent(Content);
            leapMotionButtons.LoadContent(Content);
            backgroundStatic = Content.Load<Texture2D>("VersusCharacter/background/backgroundStatic");
            // leap 
            // buttons art


            //debug font loading
            debugFont = Content.Load<SpriteFont>("content/Font1");
            // leap component fingertips
            fingerTexture = Content.Load<Texture2D>("VersusCharacter/leap/finger");
            // TODO: use this.Content to load your game content here
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
        bool goToLinkA = false;
        public override void Update(GameTime gameTime)
        {
            // Allows the game to exit



            // loading the update methods for the bird, scrolling backgroudn, and storytext number/object
            firstCharacter.Update(gameTime);
            secondCharacter.Update(gameTime);
            scrollingBackground.Update(gameTime);
            storyText.Update(gameTime);

            // collision detection
            collisionDetection.CharacterRect[0] = firstCharacter.BirdObjectRect[0];
            collisionDetection.CharacterRect[1] = secondCharacter.BirdObjectRect[0];
           isCollisionDetected = collisionDetection.IntersectCollision();
            leapMotionButtons.Update(gameTime);
            // TODO: Add your update logic here

            if (isCollisionDetected == true && leapMotionButtons.ButtonsRect[0].Intersects(fingerLocations[0]))
            {
                /*
                ScreenManager.openingtitlescreenfour = new OpeningTitleScreenFour();
                ScreenManager.Instance.AddScreen(ScreenManager.openingtitlescreenfour);
                 */

                if (goToLinkA == false)
                {
                    goToLinkA = true;
                    Process.Start("iexplore.exe", "https://www.facebook.com/CateringOutTheBox");
                   
                    goToLinkA = true;
                }


            }


            else if (isCollisionDetected == true && leapMotionButtons.ButtonsRect[1].Intersects(fingerLocations[0]))
            {
                /*
                ScreenManager.openingtitlescreenfour = new OpeningTitleScreenFour();
                ScreenManager.Instance.AddScreen(ScreenManager.openingtitlescreenfour);
                 */

                if (goToLinkA == false)
                {
                    goToLinkA = true;
                    Process.Start("iexplore.exe", "http://www.cateringoutthebox.com");
                    goToLinkA = true;
                }

            }


        }




        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Draw(SpriteBatch spriteBatch)
        {


            // TODO: Add your drawing code here
            spriteBatch.Draw(backgroundStatic, new Rectangle(0, 0, 800, 600), Color.White);
            // callling the draw methods for the scrolling backgroudn and bird and storyText objects objects/numbers
            scrollingBackground.Draw(spriteBatch);
            firstCharacter.Draw(spriteBatch);
            secondCharacter.Draw(spriteBatch);
           // storyText.Draw(spriteBatch);

            foreach (Vector2 fingerLoc in Game1.leap.FingerPoints)
            {
                float tempX = fingerLoc.X;
                float tempY = fingerLoc.Y;
                fingerLocations[0].X = (int)tempX;
                fingerLocations[0].Y = (int)tempY;
                spriteBatch.Draw(fingerTexture, fingerLocations[0], Color.White);
            }

            leapMotionButtons.Draw(spriteBatch);

           // debug draw
            spriteBatch.DrawString(debugFont, isCollisionDetected.ToString(), new Vector2(0, 0), Color.White);
            
        }
    }
}
