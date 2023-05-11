using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Tiled;
using MonoGame.Extended.Tiled.Renderers;



namespace FL2
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        //variables
        private Vector2 cameraPosition1;
        private Player player1;
        Enemy Enemy1, Enemy2;
        Texture2D background;
       




        int screenHeight;
        int screenWidth;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {

           

            base.Initialize();
        }

        protected override void LoadContent()
        {
           
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            screenWidth=GraphicsDevice.Viewport.Width;
            screenHeight=GraphicsDevice.Viewport.Height;


            background = (Content.Load<Texture2D>("bg"));
            var playerTexture = Content.Load<Texture2D>("Emily");
            player1 = new Player(playerTexture, new Vector2(100, 100));
            Enemy1 = new Enemy(Content.Load<Texture2D>("enemy0"), new Vector2(300, 300), 150, new Rectangle(10, 10, 10, 10));
            Enemy2 = new Enemy(Content.Load<Texture2D>("enemy1"), new Vector2(100, 100), 50, new Rectangle(10, 10, 10, 10));
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
           

         
            player1.Update();
            cameraPosition1 = new Vector2(player1.position.X - _graphics.PreferredBackBufferWidth / 2,
                                      player1.position.Y - _graphics.PreferredBackBufferHeight / 2);
            Enemy1.Update();
            Enemy2.Update();
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, null, null, null, Matrix.CreateTranslation(-cameraPosition1.X, -cameraPosition1.Y, 0));
           _spriteBatch.Draw(background,Vector2.Zero,Color.White);
            
            player1.Draw(_spriteBatch);
            Enemy1.Draw(_spriteBatch);
            Enemy2.Draw(_spriteBatch);
            _spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}