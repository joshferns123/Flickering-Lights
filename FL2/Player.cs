using Microsoft.VisualBasic.Devices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Keyboard = Microsoft.Xna.Framework.Input.Keyboard;

namespace FL2
{
    class Player
    {
       public Texture2D sprite;
        public Vector2 position;

        public Player(Texture2D newsprite, Vector2 newposition)
        {
            sprite = newsprite;
            position = newposition;
        }

        public void Update()
        {
            // Movement of the player
            var keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyDown(Keys.Left))
            {
                position.X -= 2f;
            }
            else if (keyboardState.IsKeyDown(Keys.Right))
            {
                position.X += 2f;
            }
            if (keyboardState.IsKeyDown(Keys.Up))
            {
                position.Y -= 2f;
            }
            else if (keyboardState.IsKeyDown(Keys.Down))
            {
                position.Y += 2f;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, position, Color.White);
        }
    }
}

