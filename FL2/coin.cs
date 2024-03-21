using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FL2
{
    public class coin
    {
        public Texture2D cointexture { get; private set; }
        public Vector2 coinposition { get; private set; }
        public bool IsCollected { get; set; }

        private Rectangle boundingRectangle;

        public Rectangle BoundingRectangle
        {
            get { return boundingRectangle; }
        }

        public coin(Texture2D newtexture, Vector2 newposition)
        {
            cointexture = newtexture;
            coinposition = newposition;
            IsCollected = false;
            boundingRectangle = new Rectangle((int)coinposition.X, (int)coinposition.Y, cointexture.Width, cointexture.Height);
        }

       

        public void Draw(SpriteBatch spriteBatch)
        {
            if (!IsCollected)
            {
                spriteBatch.Draw(cointexture, coinposition, Color.White);
            }
        }
    }
}

