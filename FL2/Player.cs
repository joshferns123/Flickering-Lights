using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace FL2
{
    class Player
    {
        public Texture2D sprite;
        public Vector2 position;
        public Rectangle boundingBox;
        public bool isVisible;
        private Vector2 respawnPosition;

       
        public Rectangle healthBar;

        public Player(Texture2D newsprite, Vector2 newposition)
        {
            sprite = newsprite;
            position = newposition;
            boundingBox = new Rectangle((int)newposition.X, (int)newposition.Y, sprite.Width, sprite.Height);
            isVisible = true;
            respawnPosition = newposition; 

            
            healthBar = new Rectangle((int)newposition.X, (int)newposition.Y - 10, sprite.Width, 5);
        }

       

        public void Update(List<Enemy> enemies)
        {
            if (isVisible)
            {
                
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

            
            boundingBox.X = (int)position.X;
            boundingBox.Y = (int)position.Y;

           
            healthBar.X = (int)position.X;
            healthBar.Y = (int)position.Y - 10;

            
            foreach (Enemy enemy in enemies)
            {
                if (boundingBox.Intersects(enemy.boundingBox))
                {
                    
                    healthBar.Width -= 1;

                    if (healthBar.Width <= 10)
                    {
                        
                    }
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (isVisible)
            {
                spriteBatch.Draw(sprite, position, Color.White);
                Texture2D redTexture = new Texture2D(spriteBatch.GraphicsDevice, 1, 1);
                redTexture.SetData(new Color[] { Color.Red });
                spriteBatch.Draw(redTexture, healthBar, Color.White);
            }
        }

        public void Respawn()
        {
            
            position = respawnPosition;
            healthBar = new Rectangle((int)respawnPosition.X, (int)respawnPosition.Y - 10, sprite.Width, 5);
            isVisible = true;
        }

        public Rectangle BoundingRectangle
        {
            get
            {
                return new Rectangle((int)position.X, (int)position.Y, sprite.Width, sprite.Height);
            }
        }

        public bool CheckCollision(Rectangle collision)
        {
            return BoundingRectangle.Intersects(collision);
        }
    }

}


