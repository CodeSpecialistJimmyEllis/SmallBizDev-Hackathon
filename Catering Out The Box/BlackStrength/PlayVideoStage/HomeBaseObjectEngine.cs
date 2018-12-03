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
    class HomeBaseObject
    {

        #region Fields
        public Texture2D bottombase;
        public Rectangle bottombaserect;
        public Texture2D explosionart;
        public Rectangle explosionartrect;
        public bool ishit;



        #endregion

        #region Multi Constructor Level Polymorpyism

        public HomeBaseObject()
        {
            ishit = false;


        }

        #endregion


        public void Initialize()
        {
        }
        public void LoadContent(ContentManager Content)
        {
            bottombase = Content.Load<Texture2D>("homebaseobjectengine/fade");
            bottombaserect = new Rectangle(0, 0, 800, 600);

            explosionart = Content.Load<Texture2D>("homebaseobjectengine/explosionart");
            explosionartrect = new Rectangle(0, 0, 64, 64);
        }

        public void UnloadContent()
        {

        }

        public void Update(GameTime gameTime)
        {
            /* 
            this.cloneexplosionrect = this.explosionartrect;
            this.cloneexplosionart = this.explosionart;
            this.clonebottombaserect = this.bottombaserect;
            this.clonebottombase = this.bottombase;
            */ 
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (ishit == true)
            {
                spriteBatch.Draw(explosionart, explosionartrect, Color.Red);
                spriteBatch.Draw(bottombase, bottombaserect, Color.Red);
            }
            else if (ishit == false)
            {
                spriteBatch.Draw(bottombase, bottombaserect, Color.White);
            }


        }


    }

}
