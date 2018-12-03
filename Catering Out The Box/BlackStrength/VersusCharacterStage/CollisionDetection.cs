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
    class CollisionDetection
    {
        bool didItCollide;
        Rectangle[] characterRect;

        public Rectangle[] CharacterRect { get { return characterRect; } set { characterRect = value; } }
        public CollisionDetection(Rectangle[] characterOne, Rectangle[] characterTwo)
        {
            characterRect = new Rectangle[2];

            characterRect[0] = characterOne[0];
            characterRect[1] = characterTwo[0];
            didItCollide = false;

        }


        public bool IntersectCollision()
        {


            if (characterRect[0].Intersects(characterRect[1]))
            {
                didItCollide = true;
                return true;
            }

            else
            {
                didItCollide = false;
                return false;
            }
        }
    }
}
