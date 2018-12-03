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
    public class Character
    {
        #region Analysis | Number Perspective

        /*  There are four variables that mean the number| How Many <> Number| Object  <> Number | FutureTruth
         *  First and foremost number is bird
         * There is only one bird
         * the int howManyBirds is the bird
         * The bird object is both the Rectangle that is used to calculate the math and the Texture2D which is the rectangle as a object
         * those are Texture2D birdObject which is just a picture that represents what happens to birdObjectRect 
         * Lastly the future/truth is the position that I choose for it to be in which is birdPositionFutureTruth
         * Enter is used to cause this equation to occur as such the equation is the mathematics of settings the vector2 birdPositionFutureTruth
         * to the birdObjectRect which moves the rectangle on a cartision plane which makes a bird looks like it moves accross the screen.
         * 
         * 
         */
        #endregion
        #region Fields
        #region false principle zero | Constructor Enumeration
        // false principle zero
        enum Zero
        {
            zero
        }
        Zero zeroFalseIdea;
        ///

        // constructor enumeration for multi constructor level polymorphism
        enum ConstructorLevel
        {
            one, two, three, four, five
        }

        ConstructorLevel constructorChoice;
        #endregion

        #region Number: How Many?
        // number is bird. how many birds.
        int howManyBirds;
        int movementSpeed;

        enum MovementDirection
        {
            left, right
        }

        MovementDirection directionMoving;
        string movementDirection;
        #endregion

        #region Number: Object
        // number is object.
        Texture2D[] birdObject;
        Rectangle[] birdObjectRect;
        Vector2 characterSize;
        #endregion

        #region Number: Future/Truth
        //number is future
        Vector2 birdPositionFutureTruth;

        // why is their no variable for equations?
        // answer: it is a miscalculation. Equations must not be numbers. variables help humans use numbers properly.  class BirdNumber
        #endregion
        #endregion

        #region Properties


        public Rectangle[] BirdObjectRect
        {
            get
            {
                return birdObjectRect;
            }

            set
            {
                if (value != null)
                {
                    value = birdObjectRect;
                }
            }
        }
        #endregion
        #region Constructors

        // constructor level choice one empty constructor is always one
        public Character()
        {

            constructorChoice = ConstructorLevel.one;
            #region Setting Values | Number: How Many
            // number is bird. how many birds.
            this.howManyBirds = 1;
            directionMoving = MovementDirection.right;
            // movement speed data field that is part of equation but does not change.
            // equation is the keyboard statemovement modifier
            this.movementSpeed = 3;
            #endregion
            #region Setting Values | Number: Object
            // number is object.
            this.birdObjectRect = new Rectangle[howManyBirds];

            this.characterSize = new Vector2(128, 128);
            this.birdObjectRect[(int)zeroFalseIdea] = new Rectangle((int)zeroFalseIdea, 360, (int)characterSize.X, (int)characterSize.Y);



            this.birdObject = new Texture2D[howManyBirds];

            #endregion

            #region Setting Values | Number: Truth/Future
            //number is future

            this.birdPositionFutureTruth.X = 500;
            this.birdPositionFutureTruth.Y = 0;
            // why is their no variable for equations?
            // answer: it is a miscalculation. Equations must not be numbers. variables help humans use numbers properly.  class BirdNumber
            #endregion



        }
        // complete overloaded constructor
        // always constructor level 2 
        public Character(int newMovementSpeed, Rectangle[] newBirdObjectRect, Texture2D[] newBirdObject, Vector2 newBirdPositionFutureTruth, string newMovementDirection)
        {

            constructorChoice = ConstructorLevel.two;
            #region Setting Values | Number: How Many
            // number is bird. how many birds.
            howManyBirds = 1;

            #region Movement Direction Control Statements
            if (newMovementDirection == "left")
            {
                directionMoving = MovementDirection.left;

            }

            else if (newMovementDirection == "right")
            {
                directionMoving = MovementDirection.right;
            }

            else
            {
                directionMoving = MovementDirection.right;
            }

            #endregion

            // movement speed data field that is part of equation but does not change.
            // equation is the keyboard statemovement modifier
            this.movementSpeed = newMovementSpeed;
            #endregion
            #region Setting Values | Number: Object
            // number is object.
            //birdObjectRect = new Rectangle[howManyBirds];


            this.birdObjectRect = newBirdObjectRect;



            this.birdObject = newBirdObject;

            #endregion

            #region Setting Values | Number: Truth/Future
            //number is future


            this.birdPositionFutureTruth = newBirdPositionFutureTruth;

            // why is their no variable for equations?
            // answer: it is a miscalculation. Equations must not be numbers. variables help humans use numbers properly.  class BirdNumber
            #endregion




        }


        // complete overload minus texture and rectangle
        // custom constructors. always constructor level 3 and beyond.
        // this is constructor level 3. 
        public Character(int newMovementSpeed, Vector2 newBirdPositionFutureTruth, string newMovementDirection)
        {

            constructorChoice = ConstructorLevel.three;
            #region Setting Values | Number: How Many
            // number is bird. how many birds.
            howManyBirds = 1;



            #region Movement Direction Control Statements
            if (newMovementDirection == "left")
            {
                directionMoving = MovementDirection.left;

            }

            else if (newMovementDirection == "right")
            {
                directionMoving = MovementDirection.right;
            }

            else
            {
                directionMoving = MovementDirection.right;
            }

            #endregion

            // movement speed data field that is part of equation but does not change.
            // equation is the keyboard statemovement modifier
            this.movementSpeed = newMovementSpeed;
            #endregion
            #region Setting Values | Number: Object
            // number is object.
            birdObjectRect = new Rectangle[howManyBirds];


            this.birdObjectRect[(int)zeroFalseIdea] = new Rectangle((int)zeroFalseIdea, 360, (int)characterSize.X, (int)characterSize.Y);



            this.birdObject = new Texture2D[howManyBirds];

            #endregion

            #region Setting Values | Number: Truth/Future
            //number is future


            this.birdPositionFutureTruth = newBirdPositionFutureTruth;

            // why is their no variable for equations?
            // answer: it is a miscalculation. Equations must not be numbers. variables help humans use numbers properly.  class BirdNumber
            #endregion




        }

        // constructor four. custom constructor. overload  birdPositionFutureTruth
        public Character(Vector2 newBirdPositionFutureTruth, string newMovementDirection)
        {

            constructorChoice = ConstructorLevel.four;
            #region Setting Values | Number: How Many
            // number is bird. how many birds.
            this.howManyBirds = 1;



            #region Movement Direction Control Statements
            if (newMovementDirection == "left")
            {
                directionMoving = MovementDirection.left;

            }

            else if (newMovementDirection == "right")
            {
                directionMoving = MovementDirection.right;
            }

            else
            {
                directionMoving = MovementDirection.right;
            }

            #endregion

            // movement speed data field that is part of equation but does not change.
            // equation is the keyboard statemovement modifier
            this.movementSpeed = 3;
            #endregion
            #region Setting Values | Number: Object
            // number is object.
            this.birdObjectRect = new Rectangle[howManyBirds];

            this.characterSize = new Vector2(128, 128);
            this.birdObjectRect[(int)zeroFalseIdea] = new Rectangle((int)zeroFalseIdea, 360, (int)characterSize.X, (int)characterSize.Y);



            this.birdObject = new Texture2D[howManyBirds];

            #endregion

            #region Setting Values | Number: Truth/Future
            //number is future

            this.birdPositionFutureTruth = newBirdPositionFutureTruth;
            // why is their no variable for equations?
            // answer: it is a miscalculation. Equations must not be numbers. variables help humans use numbers properly.  class BirdNumber
            #endregion



        }


        // constructor five
        public Character(Vector2 newBirdPositionFutureTruth, string newMovementDirection, Rectangle[] newBirdObjectRect)
        {

            constructorChoice = ConstructorLevel.five;
            #region Setting Values | Number: How Many
            // number is bird. how many birds.
            this.howManyBirds = 1;



            #region Movement Direction Control Statements
            if (newMovementDirection == "left")
            {
                directionMoving = MovementDirection.left;

            }

            else if (newMovementDirection == "right")
            {
                directionMoving = MovementDirection.right;
            }

            else
            {
                directionMoving = MovementDirection.right;
            }

            #endregion

            // movement speed data field that is part of equation but does not change.
            // equation is the keyboard statemovement modifier
            this.movementSpeed = 3;
            #endregion
            #region Setting Values | Number: Object
            // number is object.
            this.birdObjectRect = new Rectangle[howManyBirds];

            this.characterSize = new Vector2(128, 128);
            this.birdObjectRect = newBirdObjectRect;



            this.birdObject = new Texture2D[howManyBirds];

            #endregion

            #region Setting Values | Number: Truth/Future
            //number is future

            this.birdPositionFutureTruth = newBirdPositionFutureTruth;
            // why is their no variable for equations?
            // answer: it is a miscalculation. Equations must not be numbers. variables help humans use numbers properly.  class BirdNumber
            #endregion



        }

        #endregion

        public void Initialize()
        {

        }

        public void LoadContent(ContentManager Content)
        {

            #region  <<< Graphics >>> | Number : Object
            // <<< Graphics >>> | Number : Object

            if ((ConstructorLevel.one == constructorChoice) || (ConstructorLevel.three == constructorChoice) || (ConstructorLevel.four == constructorChoice) || (ConstructorLevel.five == constructorChoice))
            {
                birdObject[(int)zeroFalseIdea] = Content.Load<Texture2D>("VersusCharacter/bird");
            }
            #endregion

        }

        public void Update(GameTime gameTime)
        {

            BirdMovement();
            /*
            if (Keyboard.GetState(PlayerIndex.One).IsKeyDown(Keys.R))
            {
                birdObjectRect[(int)zeroFalseIdea].X = (int)zeroFalseIdea;
                birdObjectRect[(int)zeroFalseIdea].Y = (int)zeroFalseIdea;
            }*/


        }

        public void BirdMovement()
        {
            #region <<< Pheonomina / Input >>> | Number | Equation Ending in Future/Truth



            // Movement to the Right 
            if (MovementDirection.right == directionMoving)
            {
                //if (Keyboard.GetState(PlayerIndex.One).IsKeyDown(Keys.Enter))
                if ((LeapMotionButtons.LeapButtons.A == VersusCharacter.leapMotionButtons.P_LeapButtons) || (LeapMotionButtons.LeapButtons.B == VersusCharacter.leapMotionButtons.P_LeapButtons))
                {

                    if (birdObjectRect[(int)zeroFalseIdea].X <= (int)birdPositionFutureTruth.X)
                    {
                        birdObjectRect[(int)zeroFalseIdea].X += movementSpeed;
                    }

                    if (birdObjectRect[(int)zeroFalseIdea].Y <= (int)birdPositionFutureTruth.Y)
                    {
                        birdObjectRect[(int)zeroFalseIdea].Y += movementSpeed;

                    }

                    // birdObjectRect[(int)zeroFalseIdea].X = (int)birdPositionFutureTruth.X;
                    // birdObjectRect[(int)zeroFalseIdea].Y = (int)birdPositionFutureTruth.Y;

                }
            }

            // movement to the left
            else if (MovementDirection.left == directionMoving)
            {
                if ((LeapMotionButtons.LeapButtons.A == VersusCharacter.leapMotionButtons.P_LeapButtons) || (LeapMotionButtons.LeapButtons.B == VersusCharacter.leapMotionButtons.P_LeapButtons))
                {

                    if (birdObjectRect[(int)zeroFalseIdea].X >= (int)birdPositionFutureTruth.X)
                    {
                        birdObjectRect[(int)zeroFalseIdea].X -= movementSpeed;
                    }

                    if (birdObjectRect[(int)zeroFalseIdea].Y >= (int)birdPositionFutureTruth.Y)
                    {
                        birdObjectRect[(int)zeroFalseIdea].Y -= movementSpeed;

                    }

                    // birdObjectRect[(int)zeroFalseIdea].X = (int)birdPositionFutureTruth.X;
                    // birdObjectRect[(int)zeroFalseIdea].Y = (int)birdPositionFutureTruth.Y;

                }
            }



            #endregion



        }

        public void UnloadContent()
        {
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            #region <<< GRAPHICS DISPLAY >>> | NUMBER | OBJECT
            // <<< GRAPHICS DISPLAY >>> | NUMBER | OBJECT 
            spriteBatch.Draw(birdObject[(int)zeroFalseIdea], birdObjectRect[(int)zeroFalseIdea], Color.White);
            #endregion
        }
    }
}
