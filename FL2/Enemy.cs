using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FL2
{
     class Enemy
    {
        Texture2D texture;
        Rectangle rectangle;
        Vector2 position;
        Vector2 origin;
        Vector2 velocity;
        float rotation = 0f;

        bool right;
        float distance;
        float olddistance;

        public Enemy(Texture2D newtexture, Vector2 newposition, float newdistance,Rectangle newrectangle)
        {
            texture = newtexture;
            position = newposition;
            distance = newdistance;
            rectangle = newrectangle;

            olddistance = distance;
        }
        public void Update()
        {
            position += velocity;
            origin = new Vector2(texture.Width / 2, texture.Height / 2);

            if (distance <= 0)
            {
                right = true;
                velocity.X = 1f;
            }
            else if (distance >= olddistance)
            {
                right = false;
                velocity.X = -1f;
            }
            if (right) distance += 1; else distance -= 1;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (velocity.X > 0)
                spriteBatch.Draw(texture, position, null, Color.White, rotation, origin, 1f, SpriteEffects.None, 0f);
            else
                spriteBatch.Draw(texture, position, null, Color.White, rotation, origin, 1f, SpriteEffects.FlipHorizontally, 0f);
        }
    }
}
