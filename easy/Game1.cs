using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace easy
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        bool fireBallSwitch;

        Texture2D spaceShip;

        Texture2D fireBall;

        Rectangle fireBallRectangle;

        Rectangle spaceShipRectangle;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            
            base.Initialize();
            fireBallSwitch = false;
            fireBallRectangle = new Rectangle(0, 0, 50, 50);
            spaceShipRectangle = new Rectangle(300, 250, 200, 200);
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            spaceShip = this.Content.Load<Texture2D>("Imagen2");

            fireBall = this.Content.Load<Texture2D>("Imagen1");
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
                spaceShipRectangle.X-=3;
            }
            else if (keysState.IsKeyDown(Keys.Right))
            {
                spaceShipRectangle.X += 3;
            }
            else if(keysState.IsKeyDown(Keys.Space))
            {
                fireBallSwitch = true;
                fireBallRectangle.X = spaceShipRectangle.X+(spaceShipRectangle.Width/2)-25;
                fireBallRectangle.Y = spaceShipRectangle.Y;
            }
            if (fireBallSwitch)
            {
                fireBallRectangle.Y-=5;
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            //GraphicsDevice.Clear(new Color(red,green,blue));

            GraphicsDevice.Clear(Color.Black);



            // TODO: Add your drawing code here

            _spriteBatch.Begin();

            if (fireBallSwitch)
            {
                
                _spriteBatch.Draw(fireBall,fireBallRectangle, Color.White);
            }

            _spriteBatch.Draw(spaceShip,new Vector2(spaceShipRectangle.X, spaceShipRectangle.Y),Color.White);

            _spriteBatch.End();

            base.Draw(gameTime);

           
        }
    }
}
