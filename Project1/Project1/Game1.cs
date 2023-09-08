using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Collections.Generic;
using System;
using System.Diagnostics;

namespace Project1
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        // Encarga de dibujar las texturas en pantalla.
        private SpriteBatch _spriteBatch;
        // Crea la variable de textura 2D "pruebas".
        private Texture2D _p1Texture;
        // Crea la variable de posición de "pruebas"
        private Vector2 _p1Position;
        // Crea la variable de la velocidad en la que se moverá el sprite.
        private Vector2 _p1Speed = new Vector2(3, 3);
        private Vector2 _p2Speed = new Vector2(3, 3);
        private Texture2D _p2Texture;
        private Vector2 _p2Position;
        private Texture2D _backgroundTexture;
        private Texture2D _bochaTexture;
        private Vector2 _bochaPosition;
        private Vector2 _bochaSpeed= new Vector2(0,0);
        private bool _bochatocada=false, a,b,c,d;





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
            _backgroundTexture = Content.Load<Texture2D>("fondo");
            // Permite calcular los graficos(?)
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            // Carga la textura "pruebas" en la variable.
            _p1Texture = Content.Load<Texture2D>("a");
            // Define la posición de inicio del sprite "pruebas".
            _p1Position = new Vector2(100, 100);


            // Carga las textura "manzana" en la variable.
            _p2Texture = Content.Load<Texture2D>("c");
            // (?)
            _p2Position = new Vector2(500, 200);
            _bochaTexture = Content.Load<Texture2D>("bocha5");
            _bochaPosition = new Vector2(379, 219);
            _bochaSpeed = new Vector2(0, 0);


        }

        protected override void Update(GameTime gameTime)
        {
            Rectangle pruebasRectangle = new Rectangle((int)_p1Position.X, (int)_p1Position.Y, 30, 30);
            // Es la caja de coliciones de "pruebas" y se basa en el tamaño de la imgane.
            Rectangle manzanaRectangle = new Rectangle((int)_p2Position.X, (int)_p2Position.Y, 30, 30);
            Rectangle bochaRectangle = new Rectangle((int)_bochaPosition.X, (int)_bochaPosition.Y, 40, 40);
            // Se utiliza para poder recibir el estado del teclado.
            KeyboardState keyboardState = Keyboard.GetState();

           

                if (keyboardState.IsKeyDown(Keys.Left) && _p1Position.X > 48)
                {
                _p1Speed.X -= 2;
                }

               else if (keyboardState.IsKeyDown(Keys.Right) && _p1Position.X < 700)
                {
               

                _p1Speed.X += 2;
                }
            else
            {
                _p1Speed.X = 0;
            }

            float friccion1 = 0.9f;

            float friccion = 0.4f;
            if ( _bochaPosition.X > 48 && _bochaPosition.X < 700)
            {

                _bochaPosition.X += _bochaSpeed.X;
                _bochaSpeed *= friccion1;
            }
            _p1Position.X += _p1Speed.X;
            _p1Speed *= friccion;
            if (bochaRectangle.Intersects(pruebasRectangle))
            {
                _bochaSpeed = Vector2.Normalize(_p1Speed)*5;
            }
            _bochaPosition.X += _bochaSpeed.X;
            _bochaSpeed *= friccion;









            if (keyboardState.IsKeyDown(Keys.Up) && _p1Position.Y > 33)
            {
                _p1Speed.Y -= 2;
            }

            else if (keyboardState.IsKeyDown(Keys.Down) && _p1Position.Y < 390)
            {


                _p1Speed.Y += 2;
            }
            else
            {
                _p1Speed.Y = 0;
            }

         
            if (_bochaPosition.Y > 33 && _bochaPosition.Y < 390)
            {

                _bochaPosition.Y += _bochaSpeed.Y;
                _bochaSpeed *= friccion1;
            }
            _p1Position.Y += _p1Speed.Y;
            _p1Speed *= friccion;
            if (bochaRectangle.Intersects(pruebasRectangle))
            {
                _bochaSpeed = Vector2.Normalize(_p1Speed) * 5;
            }
            _bochaPosition.Y += _bochaSpeed.Y;
            _bochaSpeed *= friccion;












            if (keyboardState.IsKeyDown(Keys.A) && _p2Position.X > 48)
            {
                _p2Speed.X -= 2;
            }

            else if (keyboardState.IsKeyDown(Keys.D) && _p2Position.X < 700)
            {


                _p2Speed.X += 2;
            }
            else
            {
                _p2Speed.X = 0;
            }


            if (_bochaPosition.X > 48 && _bochaPosition.X < 700)
            {

                _bochaPosition.X += _bochaSpeed.X;
                _bochaSpeed *= friccion1;
            }
            _p2Position.X += _p2Speed.X;
            _p2Speed *= friccion;
            if (bochaRectangle.Intersects(manzanaRectangle))
            {
                _bochaSpeed = Vector2.Normalize(_p2Speed) * 5;
            }
            _bochaPosition.X += _bochaSpeed.X;
            _bochaSpeed *= friccion;









            if (keyboardState.IsKeyDown(Keys.W) && _p2Position.Y > 33)
            {
                _p2Speed.Y -= 2;
            }

            else if (keyboardState.IsKeyDown(Keys.S) && _p2Position.Y < 390)
            {


                _p2Speed.Y += 2;
            }
            else
            {
                _p2Speed.Y = 0;
            }


            if (_bochaPosition.Y > 33 && _bochaPosition.Y < 390)
            {

                _bochaPosition.Y += _bochaSpeed.Y;
                _bochaSpeed *= friccion1;
            }
            _p2Position.Y += _p2Speed.Y;
            _p2Speed *= friccion;
            if (bochaRectangle.Intersects(manzanaRectangle))
            {
                _bochaSpeed = Vector2.Normalize(_p2Speed) * 5;
            }
            _bochaPosition.Y += _bochaSpeed.Y;
            _bochaSpeed *= friccion;







            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            // Limpia 20 veces por segundo la imagen.

            _spriteBatch.Begin();
            
            _spriteBatch.Draw(_backgroundTexture, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);
            _spriteBatch.Draw(_p1Texture, new Rectangle((int)_p1Position.X, (int)_p1Position.Y, 50, 50), Color.White);
           
                _spriteBatch.Draw(_p2Texture, new Rectangle((int)_p2Position.X, (int)_p2Position.Y, 50,50), Color.White);
            _spriteBatch.Draw(_bochaTexture,new Rectangle((int)_bochaPosition.X,(int)_bochaPosition.Y,40,40), Color.White);
            
                
            
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}