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
        private Texture2D _barraizquierda;
        private Texture2D _barraderecha;
        private Texture2D _barraabajo;
        private Texture2D _barraarriba;
        private Vector2 _barraarribaPosition;
        private Vector2 _barraabajoPosition;
        private Vector2 _barraizquierdaPosition;
        private Vector2 _barraderechaPosition;





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
            _p1Position = new Vector2(500, 200);


            // Carga las textura "manzana" en la variable.
            _p2Texture = Content.Load<Texture2D>("c");
            // (?)
            _p2Position = new Vector2(100, 100);
            _bochaTexture = Content.Load<Texture2D>("bocha5");
            _bochaPosition = new Vector2(379, 219);
            _bochaSpeed = new Vector2(0, 0);
            _barraizquierda = Content.Load<Texture2D>("p");
            _barraderecha = Content.Load<Texture2D>("p");
            _barraarriba = Content.Load<Texture2D>("k");
            _barraabajo = Content.Load<Texture2D>("k");
            _barraizquierdaPosition = new Vector2(36, -38);
            _barraderechaPosition = new Vector2(734, -38);
            _barraarribaPosition = new Vector2(48, 40);
            _barraabajoPosition = new Vector2(48, 430);
        }

        protected override void Update(GameTime gameTime)
        {
            Rectangle pruebasRectangle = new Rectangle((int)_p1Position.X, (int)_p1Position.Y, 30, 30);
            // Es la caja de coliciones de "pruebas" y se basa en el tamaño de la imgane.
            Rectangle manzanaRectangle = new Rectangle((int)_p2Position.X, (int)_p2Position.Y, 30, 30);
            Rectangle bochaRectangle = new Rectangle((int)_bochaPosition.X, (int)_bochaPosition.Y, 30, 30);
            Rectangle lineaRectangle = new Rectangle((int)_barraizquierdaPosition.X,(int)_barraizquierdaPosition.Y, 10, 700);
            Rectangle linea2Rectangle = new Rectangle((int)_barraderechaPosition.X, (int)_barraderechaPosition.Y, 1, 700);
            Rectangle linea3Rectangle = new Rectangle((int)_barraarribaPosition.X, (int)_barraarribaPosition.Y, 705, 1);
            Rectangle linea4Rectangle = new Rectangle((int)_barraabajoPosition.X, (int)_barraabajoPosition.Y, 705, 40);

            // Se utiliza para poder recibir el estado del teclado.
            KeyboardState keyboardState = Keyboard.GetState();
            bool _p1movimiento = false;
            bool _p2movimiento = false;
            float friccion1 = 0.99f;
            float friccion = 0.6f;
            Vector2 velocidad = new Vector2(2f, 2f);
            if (bochaRectangle.Intersects(linea3Rectangle))
            {
                Vector2 normal = Vector2.Normalize(new Vector2(linea3Rectangle.X - bochaRectangle.X, linea3Rectangle.Y - bochaRectangle.Y));

                float velocidadPerpendicular = (Vector2.Dot(velocidad, normal));

                Vector2 velocidadParalela = velocidad - velocidadPerpendicular * normal;

                velocidad = velocidadParalela - velocidadPerpendicular * normal;
                _bochaSpeed.Y = velocidad.Y;
            }
            if (bochaRectangle.Intersects(linea4Rectangle))
            {
                Vector2 normal = Vector2.Normalize(new Vector2(linea4Rectangle.X - bochaRectangle.X, linea4Rectangle.Y - bochaRectangle.Y));

                float velocidadPerpendicular = (Vector2.Dot(velocidad, normal));

                Vector2 velocidadParalela = velocidad - velocidadPerpendicular * normal;

                velocidad = velocidadParalela - velocidadPerpendicular * normal;
                _bochaSpeed.Y = -velocidad.Y;
            }
            if (bochaRectangle.Intersects(linea2Rectangle))
            {
                Vector2 normal = Vector2.Normalize(new Vector2(linea2Rectangle.X - bochaRectangle.X, linea2Rectangle.Y - bochaRectangle.Y));

                float velocidadPerpendicular = (Vector2.Dot(velocidad, normal));

                Vector2 velocidadParalela = velocidad - velocidadPerpendicular * normal;

                velocidad = velocidadParalela - velocidadPerpendicular * normal;
                _bochaSpeed.X = -velocidad.X;
            }
            if (bochaRectangle.Intersects(lineaRectangle))
            {
                Vector2 normal = Vector2.Normalize(new Vector2(lineaRectangle.X - bochaRectangle.X, lineaRectangle.Y - bochaRectangle.Y));

                float velocidadPerpendicular = (Vector2.Dot(velocidad, normal));

                Vector2 velocidadParalela = velocidad - velocidadPerpendicular * normal;

                velocidad = velocidadParalela - velocidadPerpendicular * normal*4;
                _bochaSpeed.X = velocidad.X;
            }






            if (keyboardState.IsKeyDown(Keys.Left) && _p1Position.X > 44)
                {
                _p1Speed.X -= 2;
                _p1movimiento = false;
            }

               else if (keyboardState.IsKeyDown(Keys.Right) && _p1Position.X < 710)
                {
               

                _p1Speed.X += 2;
                _p1movimiento = false;
            }
            else
            {
                _p1movimiento = true;
                _p1Speed.X = 0;
            }

       

     
            if (bochaRectangle.Intersects(pruebasRectangle) && !_p1movimiento)
            {

                _bochaSpeed = Vector2.Normalize(_p1Speed) * 3;

            }
            if ( _bochaPosition.X > 32 && _bochaPosition.X < 713)
            {

                _bochaPosition.X += _bochaSpeed.X;
                _bochaSpeed *= friccion1;
            }
            _p1Position.X += _p1Speed.X;
            _p1Speed *= friccion;
          
       


            if (keyboardState.IsKeyDown(Keys.Up) && _p1Position.Y > 33)
            {
                _p1Speed.Y -= 2; _p1movimiento = false;
            }

            else if (keyboardState.IsKeyDown(Keys.Down) && _p1Position.Y < 401)
            {


                _p1Speed.Y += 2; _p1movimiento = false;
            }
            else
            {
                _p1Speed.Y = 0; _p1movimiento = true;
            }

            if (bochaRectangle.Intersects(pruebasRectangle) && !_p1movimiento )
            {
                _bochaSpeed = Vector2.Normalize(_p1Speed) * 3;
            }
        
            if (_bochaPosition.Y > 33 && _bochaPosition.Y < _barraabajoPosition.Y)
            {
                 

                _bochaPosition.Y += _bochaSpeed.Y;
                _bochaSpeed *= friccion1;
            }
        
            _p1Position.Y += _p1Speed.Y;
            _p1Speed *= friccion;
        










            if (keyboardState.IsKeyDown(Keys.A) && _p2Position.X > 48)
            {
                _p2Speed.X -= 2; _p2movimiento = false;
            }

            else if (keyboardState.IsKeyDown(Keys.D) && _p2Position.X < 705)
            {


                _p2Speed.X += 2; _p2movimiento = false;
            }
            else
            {
                _p2Speed.X = 0; _p2movimiento = true;
            }
            if (bochaRectangle.Intersects(manzanaRectangle)&&!_p2movimiento)
            {

                {
                    _bochaSpeed = Vector2.Normalize(_p2Speed) * 3;
                }
            }

            if (_bochaPosition.X > 48 && _bochaPosition.X < 700)
            {

                _bochaPosition.X += _bochaSpeed.X;
                _bochaSpeed *= friccion1;
            }
            _p2Position.X += _p2Speed.X;
            _p2Speed *= friccion;
       
 
            if (keyboardState.IsKeyDown(Keys.W) && _p2Position.Y > 33)
            {
                _p2Speed.Y -= 2; _p2movimiento = false;
            }

            else if (keyboardState.IsKeyDown(Keys.S) && _p2Position.Y < 400)
            {


                _p2Speed.Y += 2; _p2movimiento = false;
            }
            else
            {
                _p2Speed.Y = 0; _p2movimiento = true;
            }

            if (bochaRectangle.Intersects(manzanaRectangle)&&!_p2movimiento )
            {
               
                    _bochaSpeed = Vector2.Normalize(_p2Speed) * 3;
                
            }
            if (_bochaPosition.Y > 33 && _bochaPosition.Y < 390)
            {

                _bochaPosition.Y += _bochaSpeed.Y;
                _bochaSpeed *= friccion1;
            }
            _p2Position.Y += _p2Speed.Y;
            _p2Speed *= friccion;
       



            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            // Limpia 20 veces por segundo la imagen.

            _spriteBatch.Begin();
            
            _spriteBatch.Draw(_backgroundTexture, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);
            _spriteBatch.Draw(_p1Texture, new Rectangle((int)_p1Position.X, (int)_p1Position.Y, 45, 45), Color.White);
           
                _spriteBatch.Draw(_p2Texture, new Rectangle((int)_p2Position.X, (int)_p2Position.Y, 45,45), Color.White);
            _spriteBatch.Draw(_bochaTexture,new Rectangle((int)_bochaPosition.X,(int)_bochaPosition.Y,40,40), Color.White);
            _spriteBatch.Draw(_barraizquierda,new Rectangle((int)_barraizquierdaPosition.X,(int)_barraizquierdaPosition.Y,30,700), Color.Transparent);
            _spriteBatch.Draw(_barraderecha, new Rectangle((int)_barraderechaPosition.X, (int)_barraderechaPosition.Y, 30, 700), Color.Transparent);
            _spriteBatch.Draw(_barraarriba, new Rectangle((int)_barraarribaPosition.X, (int)_barraarribaPosition.Y, 705, 1), Color.Transparent);
            _spriteBatch.Draw(_barraabajo, new Rectangle((int)_barraabajoPosition.X, (int)_barraabajoPosition.Y, 705, 1), Color.Transparent);



            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}