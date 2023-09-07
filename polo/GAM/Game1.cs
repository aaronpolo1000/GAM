using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace GAM
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D _p1Texture;
        private Vector2 _p1Position;

        private Texture2D _p2Texture;
        private Vector2 _p2Position;

        private Song _backgroundMusic;

        private bool _manzanaTocada = false; // Bandera para controlar si se tocó la manzana

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _p1Texture = Content.Load<Texture2D>("messi");
            _p1Position = new Vector2(100, 100);


            _p2Texture = Content.Load<Texture2D>("copa");
            _p2Position = new Vector2(GraphicsDevice.Viewport.Width / 2 - _p2Texture.Width / 2, GraphicsDevice.Viewport.Height / 2 - _p2Texture.Height / 2);

        }

        protected override void Update(GameTime gameTime)
        {
            KeyboardState keyboardState = Keyboard.GetState();


                if (keyboardState.IsKeyDown(Keys.Left))
                    _p1Position.X -= 2;

                if (keyboardState.IsKeyDown(Keys.Right))
                    _p1Position.X += 2;

                if (keyboardState.IsKeyDown(Keys.Up))
                    _p1Position.Y -= 2;

                if (keyboardState.IsKeyDown(Keys.Down))
                    _p1Position.Y += 2;

            if (keyboardState.IsKeyDown(Keys.Left))
                _p2Position.X -= 2;

            if (keyboardState.IsKeyDown(Keys.Right))
                _p2Position.X += 2;

            if (keyboardState.IsKeyDown(Keys.Up))
                _p2Position.Y -= 2;

            if (keyboardState.IsKeyDown(Keys.Down))
                _p2Position.Y += 2;

            Rectangle pruebasRectangle = new Rectangle((int)_p1Position.X, (int)_p1Position.Y, _p1Texture.Width, _p1Texture.Height);
                Rectangle manzanaRectangle = new Rectangle((int)_p2Position.X, (int)_p2Position.Y, _p2Texture.Width, _p2Texture.Height);

                if (pruebasRectangle.Intersects(manzanaRectangle))
                {
                    _manzanaTocada = true;
                }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            // Limpia 20 veces por segundo la imagen.

            _spriteBatch.Begin();
            _spriteBatch.Draw(_p1Texture, _p1Position, Color.White);
            if (!_manzanaTocada)
                _spriteBatch.Draw(_p2Texture, _p2Position, Color.White);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
