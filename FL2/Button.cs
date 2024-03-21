using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FL2
{
    class Button
    {
        Texture2D texture;
        Vector2 position;
        Rectangle rectangle;

        Color colour = new Color(255, 255, 255, 255);

        bool down;
        public bool isclicked;



        public Button()
        {

        }

        public void Load(Texture2D newtexture, Vector2 newposition)
        {
            texture = newtexture;
            position = newposition;
        }
        public void Update(MouseState mouse)
        {
            mouse = Mouse.GetState();

            rectangle=new Rectangle((int)position.X,(int)position.Y,texture.Width,texture.Height);

            Rectangle mouserectangle = new Rectangle(mouse.X, mouse.Y, 1, 1);

            if (mouserectangle.Intersects(rectangle))
            {
                if (colour.A == 255) down = false;
                if (colour.A == 0) down = true;
                if (down) colour.A += 3; else colour.A -= 3;
                if (mouse.LeftButton == ButtonState.Pressed)
                {
                    isclicked = true;
                    colour.A = 255;
                }
            }
            else if (colour.A < 255)
                colour.A += 3;
        }

        public void Draw(SpriteBatch spriteBatch , Vector2 cameraPosition)
        {
            spriteBatch.Draw(texture, position + cameraPosition, Color.White);
        }


    }
}
        

    

