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
    class ObjectDownEngine
    {
         public bool  CONTROLPOSITIONX;
        public bool  CONTROLPOSITIONY;

        //
        public Vector2 ballposition;
        public int ballspeed;
        public int ballwidth;
        public int ballheight;
        //
        public Random NUMBEROFAPPEARANCEX;
        public int resetCount;
     
    
        public ObjectDownEngine()
        {
           this.resetCount = 0;
           this.NUMBEROFAPPEARANCEX = new Random();
        }


        public void Update(GameTime gameTime)
        {

            this.ballspeed = BallSpeedControl();
            //this.RANDOMBALLDOWN();
          //  this.BALLOFTRUTHMOVEMENT();
        }

        #region Balll Down Randomball down methods 

        public Vector2 RANDOMBALLDOWN(Vector2 newBALLPOSITIONOFTRUTH)
        {
            int BALLOFTRUTHZONE1 = ((500 / 3) * 1);
            int BALLOFTRUTHZONE2 = ((500 / 3) + (500 / 3));
            int BALLOFTRUTHZONE3 = 500;
            Random ZoneRandom = new Random();
            int USEDZONE = ZoneRandom.Next(1, 3);


            newBALLPOSITIONOFTRUTH.Y += 6;

            if (newBALLPOSITIONOFTRUTH.Y == (480 - 27))
            {

                if (USEDZONE == 1)
                {
                    newBALLPOSITIONOFTRUTH.Y = 0;
                    newBALLPOSITIONOFTRUTH.X = NUMBEROFAPPEARANCEX.Next(0, BALLOFTRUTHZONE1);
                    return newBALLPOSITIONOFTRUTH;
                }


                if (USEDZONE == 2)
                {
                    newBALLPOSITIONOFTRUTH.Y = 0;
                    newBALLPOSITIONOFTRUTH.X = NUMBEROFAPPEARANCEX.Next(BALLOFTRUTHZONE1, BALLOFTRUTHZONE2);
                    return newBALLPOSITIONOFTRUTH;
                }


                if (USEDZONE == 3)
                {
                    newBALLPOSITIONOFTRUTH.Y = 0;
                    newBALLPOSITIONOFTRUTH.X = NUMBEROFAPPEARANCEX.Next(BALLOFTRUTHZONE2, BALLOFTRUTHZONE3);
                    return newBALLPOSITIONOFTRUTH;
                }

                else
                {
                    return new Vector2(0, 0);
                }


            }
            else
            {
                return new Vector2(0, 0);
            }


        }


        public Vector2 BALLOFTRUTHMOVEMENT(Vector2 newballposition)
        {

            //THE CONTROL VARIABLES OF THE X AND Y AXES RESPECTABLY
            /*
             * //CONNECTED TO THE BALLOFTRUTHMOVEMENT METHOD AND IS BEFORE THE UPDATEMETHOD
        bool CONTROLPOSITIONX = true;
        bool CONTROLPOSITIONY = false;
             * */



            //CONTROLS THE LEFT AND RIGHT MOVEMENT
            if (newballposition.X == (800 - ballwidth))
            {
                CONTROLPOSITIONX = false;
            }
            if (newballposition.X == 0)
            {
                CONTROLPOSITIONX = true;
            }

            if (newballposition.Y == 480 - ballheight)
            {
                CONTROLPOSITIONY = false;
            }
            if (newballposition.Y == 0)
            {
                CONTROLPOSITIONY = true;
            }

            if (CONTROLPOSITIONX == true)
            {
                newballposition.X = newballposition.X + 2;
            }
            if (CONTROLPOSITIONX == false)
            {
                newballposition.X = newballposition.X - 2;
            }

            //CONTROSL THE UP AND DOWN MOVEMENT

            if (CONTROLPOSITIONY == true)
            {
                newballposition.Y += 2;
            }
            if (CONTROLPOSITIONY == false)
            {
                newballposition.Y -= 2;
            }
            return ballposition;
        }

        

        #endregion 
        #region randomballdown ball down methods
        /*
          public void RANDOMBALLDOWN()
        {
            int BALLOFTRUTHZONE1 = ((800 / 3) * 1);
            int BALLOFTRUTHZONE2 = ((800 / 3) + (800/ 3));
            int BALLOFTRUTHZONE3 = 800;
            Random ZoneRandom = new Random();
            int USEDZONE = ZoneRandom.Next(1, 3);


            this.ballposition.Y += this.ballspeed;

            if (this.ballposition.Y == (600 - this.ballheight))
            {

                if (USEDZONE == 1)
                {
                    this.resetCount = this.resetCount + 1;
                    this.ballposition.Y = 0;
                    this.ballposition.X = this.NUMBEROFAPPEARANCEX.Next(0, BALLOFTRUTHZONE1);
                }


                if (USEDZONE == 2)
                {
                    this.resetCount = this.resetCount + 1;
                    this.ballposition.Y = 0;
                    this.ballposition.X = this.NUMBEROFAPPEARANCEX.Next(BALLOFTRUTHZONE1, BALLOFTRUTHZONE2);
                }


                if (USEDZONE == 3)
                {
                    this.resetCount = this.resetCount + 1;
                    this.ballposition.Y = 0;
                    this.ballposition.X = this.NUMBEROFAPPEARANCEX.Next(BALLOFTRUTHZONE2, BALLOFTRUTHZONE3);
                }



            }



        }

        public void BALLOFTRUTHMOVEMENT()
        {

            //THE CONTROL VARIABLES OF THE X AND Y AXES RESPECTABLY
            /*
             * //CONNECTED TO THE BALLOFTRUTHMOVEMENT METHOD AND IS BEFORE THE UPDATEMETHOD
        bool CONTROLPOSITIONX = true;
        bool CONTROLPOSITIONY = false;
             * */



            //CONTROLS THE LEFT AND RIGHT MOVEMENT */
        /*
            if (this.ballposition.X == (800 - this.ballwidth))
            {
                this.CONTROLPOSITIONX = false;
            }
            if (this.ballposition.X == 0)
            {
                this.CONTROLPOSITIONX = true;
            }

            if (this.ballposition.Y == 600 - this.ballheight)
            {
                this.CONTROLPOSITIONY = false;
            }
            if (this.ballposition.Y == 0)
            {
                this.CONTROLPOSITIONY = true;
            }

            if (this.CONTROLPOSITIONX == true)
            {
                this.ballposition.X = this.ballposition.X + 2;
            }
            if (this.CONTROLPOSITIONX == false)
            {
                this.ballposition.X = this.ballposition.X - 2;
            }

            //CONTROSL THE UP AND DOWN MOVEMENT

            if (this.CONTROLPOSITIONY == true)
            {
                this.ballposition.Y += 2;
            }
            if (this.CONTROLPOSITIONY == false)
            {
                this.ballposition.Y -= 2;
            }

        } */

        #endregion 


        public int BallSpeedControl()
        {
            int speed = 1;
            if (this.resetCount >= 0 && this.resetCount <= 3)
            {
                speed = 6;
            }

            if (this.resetCount >= 4 && this.resetCount <= 6)
            {
                speed = 2;
            }
            if (this.resetCount >= 7 && this.resetCount <= 10)
            {
                speed = 3;
            }
            if (this.resetCount >= 11 && this.resetCount <= 14)
            {
                speed = 4;
            }
            if (this.resetCount >= 15 && this.resetCount <= 18)
            {
                speed = 5;
            }
            if (this.resetCount >= 19 && this.resetCount <= 22)
            {
                speed = 6;
            }

            return speed;

        }

        public void ReceiveFrom_BallObject(Vector2 newballposition, int newballspeed, int newballwidth, int newballheight )
        {

            this.ballposition = newballposition;
            this.ballspeed = newballspeed;
            this.ballwidth = newballwidth;
            this.ballheight = newballheight;

        }
       
        public int SendToBallSpeed_BallObject()
        {
           // public Vector2 ballposition;
     //   public int ballspeed;
       // public int ballwidth;
       //  public int ballheight;

            return ballspeed; 
        }

        public int SendToBallWidth_BallObject()
        {
            return ballwidth;
        }

        public int SendToBallHeight_BallObject()
        {
            return ballheight;
        }

        public Vector2 SendToBallPosition_BallObject()
        {
            return ballposition; 
        }
     
    }
}
