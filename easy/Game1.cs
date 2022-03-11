using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace easy
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        byte red;
        byte green;
        byte blue;

        int positionx;

        int positiony;

        Texture2D spaceShip;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            red = 100;
            blue = 50;
            green = 70;
            base.Initialize();
            positionx = 300;
            positiony = 250;
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            spaceShip = this.Content.Load<Texture2D>("Imagen2");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            KeyboardState keysState = Keyboard.GetState();

            // TODO: Add your update logic here
            //red++;
            //green++;
            //blue++;

            if (keysState.IsKeyDown(Keys.Left))
            {
                positionx = positionx-=1;
            }
            else if (keysState.IsKeyDown(Keys.Right))
            {
                positionx = positionx += 1;
            }

            
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            //GraphicsDevice.Clear(new Color(red,green,blue));

            GraphicsDevice.Clear(Color.Black);



            // TODO: Add your drawing code here

            _spriteBatch.Begin();

            _spriteBatch.Draw(spaceShip,new Vector2(positionx,positiony),Color.White);

            _spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
