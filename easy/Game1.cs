using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections;
using System.Collections.Generic;


namespace easy
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;

        private SpriteBatch _spriteBatch;

        Texture2D spaceShip;

        Texture2D fireBall;

        Rectangle spaceShipRectangle;

        List<Rectangle> fireballRectangles;





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

            spaceShipRectangle = new Rectangle(300, 250, 200, 200);

            fireballRectangles = new List<Rectangle>();
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
                fireballRectangles.Add(new Rectangle(spaceShipRectangle.X + (spaceShipRectangle.Width / 2) - 25, spaceShipRectangle.Y+10,50,50));

                //fireBallRectangle.X = spaceShipRectangle.X+(spaceShipRectangle.Width/2)-25;

                //fireBallRectangle.Y = spaceShipRectangle.Y;
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            //GraphicsDevice.Clear(new Color(red,green,blue));

            GraphicsDevice.Clear(Color.Black);



            // TODO: Add your drawing code here

            _spriteBatch.Begin();

            foreach (var item in fireballRectangles)
            {
                _spriteBatch.Draw(fireBall, item, Color.White);
            }

            _spriteBatch.Draw(spaceShip,spaceShipRectangle,Color.White);

            _spriteBatch.End();

            base.Draw(gameTime);

           
        }
    }
}
