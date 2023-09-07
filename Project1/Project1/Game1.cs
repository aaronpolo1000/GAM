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
        private Texture2D _pruebasTexture;
        // Crea la variable de posición de "pruebas"
        private Vector2 _pruebasPosition;
        // Crea la variable de la velocidad en la que se moverá el sprite.
        private Vector2 _pruebasSpeed = new Vector2(3, 3);

        private Texture2D _manzanaTexture;
        private Vector2 _manzanaPosition;
        private Texture2D _backgroundTexture;
        private Texture2D _bochaTexture;
        private Vector2 _bochaPosition;
        private bool _bochatocada=false, a,b,c,d;




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
            _backgroundTexture = Content.Load<Texture2D>("fondo");
            // Permite calcular los graficos(?)
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            // Carga la textura "pruebas" en la variable.
            _pruebasTexture = Content.Load<Texture2D>("a");
            // Define la posición de inicio del sprite "pruebas".
            _pruebasPosition = new Vector2(100, 100);


            // Carga las textura "manzana" en la variable.
            _manzanaTexture = Content.Load<Texture2D>("c");
            // (?)
            _manzanaPosition = new Vector2(400, 200);
            _bochaTexture = Content.Load<Texture2D>("bocha5");
            _bochaPosition = new Vector2(379, 219);



        }

        protected override void Update(GameTime gameTime)
        {
            // Se utiliza para poder recibir el estado del teclado.
            KeyboardState keyboardState = Keyboard.GetState();

            // Se ejecuta cuando la variable _manzanaTocada es "false".
           
                // Movimiento del sprite "pruebas" controlado por las flechas del teclado

                // Cuando se aprieta la tecla "left" se hace la siguiente operación:
                if (keyboardState.IsKeyDown(Keys.Left) && _pruebasPosition.X > 48)
                {
                    // Se resta la posición actual en "X" por el valor de la velocidad. Si velocidad es 2 se restan 2 posiciones.
                    _pruebasPosition.X -= 3;
                }

                // Cuando se aprieta la tecla "right" se hace la siguiente operación:
                if (keyboardState.IsKeyDown(Keys.Right) && _pruebasPosition.X < 700)
                {
                    // Se suma la posición actual en "X" por el valor de la velocidad.
                    _pruebasPosition.X += 3;
                }

                // Cuando se aprieta la tecla "up" se hace la siguiente operación:
                if (keyboardState.IsKeyDown(Keys.Up) && _pruebasPosition.Y > 33)
                {
                    // Se resta la posición actual en "Y" por el valor de la velocidad.
                    _pruebasPosition.Y -= 3;
                }

                // Cuando se aprieta la tecla "down" se hace la siguiente operación:
                if (keyboardState.IsKeyDown(Keys.Down) && _pruebasPosition.Y < 390)
                {
                    // Se suma la posición actual en "Y" por el valor de la velocidad.
                    _pruebasPosition.Y += 3;
                }
           if (keyboardState.IsKeyDown(Keys.A) && _manzanaPosition.X >48&&_bochatocada==false)
            {
                

                // Se resta la posición actual en "X" por el valor de la velocidad. Si velocidad es 2 se restan 2 posiciones.
                _manzanaPosition.X -= 3;
            }

            // Cuando se aprieta la tecla "right" se hace la siguiente operación:
            if (keyboardState.IsKeyDown(Keys.D) && _manzanaPosition.X <700)
            {
               
                // Se suma la posición actual en "X" por el valor de la velocidad.
                _manzanaPosition.X += 3;
            }

            // Cuando se aprieta la tecla "up" se hace la siguiente operacwwwwwión:
            if (keyboardState.IsKeyDown(Keys.W) && _manzanaPosition.Y > 33)
            {
               
                // Se resta la posición actual en "Y" por el valor de la velocidad.
                _manzanaPosition.Y -= 3;
            }

            // Cuando se aprieta la tecla "down" se hace la siguiente operación:
            if (keyboardState.IsKeyDown(Keys.S) && _manzanaPosition.Y < 390)
            {
                
                // Se suma la posición actual en "Y" por el valor de la velocidad.
                _manzanaPosition.Y += 3;
            }

            // Verificar colisión con la manzana
            Rectangle pruebasRectangle = new Rectangle((int)_pruebasPosition.X, (int)_pruebasPosition.Y, 50, 50);
            Rectangle pruebas1Rectangle = new Rectangle((int)_pruebasPosition.X, (int)_pruebasPosition.Y, 50, 50);
            // Es la caja de coliciones de "pruebas" y se basa en el tamaño de la imgane.
            Rectangle manzanaRectangle = new Rectangle((int)_manzanaPosition.X, (int)_manzanaPosition.Y, 50, 50);
            Rectangle bochaRectangle = new Rectangle((int)_bochaPosition.X, (int)_bochaPosition.Y, 40, 40);

            // Es la caja de coliciones de "manzana" y se basa en el tamaño de la imgane.



            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            // Limpia 20 veces por segundo la imagen.

            _spriteBatch.Begin();
            
            _spriteBatch.Draw(_backgroundTexture, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);
            _spriteBatch.Draw(_pruebasTexture, new Rectangle((int)_pruebasPosition.X, (int)_pruebasPosition.Y, 50, 50), Color.White);
           
                _spriteBatch.Draw(_manzanaTexture, new Rectangle((int)_manzanaPosition.X, (int)_manzanaPosition.Y, 50,50), Color.White);
            _spriteBatch.Draw(_bochaTexture,new Rectangle((int)_bochaPosition.X,(int)_bochaPosition.Y,40,40), Color.White);
            
                
            
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}