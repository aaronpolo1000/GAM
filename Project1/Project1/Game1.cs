﻿using Microsoft.Xna.Framework;
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
        private Texture2D _menu;
        private Texture2D _personajes;
        private Texture2D _bochaTexture;
        private Vector2 _bochaPosition;
        private Vector2 _bochaSpeed= new Vector2(0,0);
        private bool _bochatocada=false, a,b,c,d;
        private Texture2D _barraizquierda;
        private Texture2D _barraderecha;
        private Texture2D _barraabajo;
        private Texture2D _barraarriba;
        private Texture2D _barraizquierdaarco;
        private Vector2 _barraarribaPosition;
        private Vector2 _barraabajoPosition;
        private Vector2 _barraizquierdaPosition;
        private Vector2 _barraderechaPosition;
        private int pantalla = 1;
        private SpriteFont myFont;
        private Texture2D _river;
        private Vector2 _riverPosition;
        private Texture2D _boca;
        private Vector2 _bocaPosition;
        private Texture2D _racing;
        private Vector2 _racingPosition;
        private Texture2D _independiente;
        private Vector2 _independientePosition;
        private Texture2D _riverjuga;
        private Vector2 _riverjugaPosition;
        private Texture2D _tevez;
        private Vector2 _tevezPosition;
        private Texture2D _racingjuga;
        private Vector2 _racingjugaPosition;
        private Texture2D _rojojuga;
        private Vector2 _rojojugaPosition; 
        private enum Team { River, Boca, Racing, Independiente }
        private Team _selectedTeam = Team.River;
        private KeyboardState _previousKeyboardState;

        private Vector2 _barraizquierdaPositionarco;
        private Texture2D _barraderechaarco;
        private Vector2 _barraderechaPositionarco;
        private Texture2D _barragolizquierda;
        private Vector2 _barragolizquierdaPosition;
        private Texture2D _barragolderecha;
        private Vector2 _barragolderechaPosition;
        private int equipo1 = 0;
        private int equipo2 = 0;
        private Texture2D _fondo4;
        private Texture2D _contador;
        private Vector2 _contadorPosition;
        private bool pausa = false;
        private Texture2D _pausa;
        private Vector2 _pausaPosition;
      




        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = 1200;
            _graphics.PreferredBackBufferHeight = 720;
            _graphics.IsFullScreen = true;
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
          
            _pausa=Content.Load<Texture2D>("pausa5");
            _pausaPosition = new Vector2(443,290);
            _contador = Content.Load<Texture2D>("marcador8");
            _contadorPosition = new Vector2(443,0);
            _riverjuga = Content.Load<Texture2D>("riverjuga");
            _riverjugaPosition = new Vector2(200, 400);
            _tevez = Content.Load<Texture2D>("tevez");
            _tevezPosition = new Vector2(200, 400);
            _racingjuga = Content.Load<Texture2D>("racingjuga");
            _racingjugaPosition = new Vector2(200, 400);
            _rojojuga = Content.Load<Texture2D>("rojo");
            _rojojugaPosition = new Vector2(200, 400);
            _river =Content.Load<Texture2D>("river");
            _riverPosition =new Vector2(200,100);
            _boca = Content.Load<Texture2D>("boca");
            _bocaPosition = new Vector2(300, 100);
            _racing = Content.Load<Texture2D>("racing");
            _racingPosition = new Vector2(400, 100);
            _independiente = Content.Load<Texture2D>("independiente");
            _independientePosition = new Vector2(500, 100);
            myFont = Content.Load<SpriteFont>("borja");
            _backgroundTexture = Content.Load<Texture2D>("fondo");
            _menu = Content.Load<Texture2D>("fondo2");
            _personajes = Content.Load<Texture2D>("personajes");
           
            // Permite calcular los graficos(?)
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            // Carga la textura "pruebas" en la variable.
            _p1Texture = Content.Load<Texture2D>("a");
            // Define la posición de inicio del sprite "pruebas".
            _p1Position = new Vector2(321, 340);


            // Carga las textura "manzana" en la variable.
            _p2Texture = Content.Load<Texture2D>("a");
            // (?)
            _p2Position = new Vector2(921, 340);
            _bochaTexture = Content.Load<Texture2D>("bocha5");
            _bochaPosition = new Vector2(621, 340);
            _bochaSpeed = new Vector2(0, 0);
            _barraizquierda = Content.Load<Texture2D>("p");
            _barraderecha = Content.Load<Texture2D>("p");
            _barraarriba = Content.Load<Texture2D>("k");
            _barraabajo = Content.Load<Texture2D>("k");
            _barraderechaPosition = new Vector2(1183, 20);
            _barraarribaPosition = new Vector2(48, 60);
            _barraabajoPosition = new Vector2(48, 650);
            _barraizquierdaPosition = new Vector2(65, 30);
            _barraizquierdaarco = Content.Load<Texture2D>("p");
            _barraizquierdaPositionarco = new Vector2(65,430);
            _barraderechaarco = Content.Load<Texture2D>("p");
            _barraderechaPositionarco = new Vector2(1183, 430);
            _barragolizquierda =Content.Load<Texture2D>("p");
            _barragolizquierdaPosition = new Vector2(37, 272);
            _barragolderecha=Content.Load<Texture2D>("p");
            _barragolderechaPosition = new Vector2(1220,272);
           



        }

        protected override void Update(GameTime gameTime)
        {
            if (pantalla == 1)
            {
                KeyboardState inicio = Keyboard.GetState();
                if (inicio.IsKeyDown(Keys.Enter))
                {
                    pantalla = 2;

                }
            }
            else if (pantalla == 2)
            {


                Rectangle river = new Rectangle((int)_riverPosition.X, (int)_riverPosition.Y, 200, 200);
                Rectangle boca = new Rectangle((int)_bocaPosition.X, (int)_bocaPosition.Y, 200, 200);
                Rectangle racing = new Rectangle((int)_racingPosition.X, (int)_racingPosition.Y, 200, 200);
                Rectangle independiente = new Rectangle((int)_independientePosition.X, (int)_independientePosition.Y, 200, 200);
                KeyboardState inicio2 = Keyboard.GetState();
                KeyboardState keyboardState = Keyboard.GetState();
                if (keyboardState.IsKeyDown(Keys.Right) && !_previousKeyboardState.IsKeyDown(Keys.Right))
                {
                    // Cambia al siguiente equipo
                    if (_selectedTeam == Team.River) _selectedTeam = Team.Boca;
                    else if (_selectedTeam == Team.Boca) _selectedTeam = Team.Racing;
                    else if (_selectedTeam == Team.Racing) _selectedTeam = Team.Independiente;
                    else if (_selectedTeam == Team.Independiente) _selectedTeam = Team.River;

                }

                if (keyboardState.IsKeyDown(Keys.Left) && !_previousKeyboardState.IsKeyDown(Keys.Left))
                {
                    // Cambia al equipo anterior
                    if (_selectedTeam == Team.River) _selectedTeam = Team.Independiente;
                    else if (_selectedTeam == Team.Boca) _selectedTeam = Team.River;
                    else if (_selectedTeam == Team.Racing) _selectedTeam = Team.Boca;
                    else if (_selectedTeam == Team.Independiente) _selectedTeam = Team.Racing;

                }
                if (inicio2.IsKeyDown(Keys.D))
                {
                    pantalla = 3;

                }
                _previousKeyboardState = keyboardState;

            }
            else if (pantalla == 3)
            {
              
                KeyboardState inicio3 = Keyboard.GetState();
                Rectangle pruebasRectangle = new Rectangle((int)_p1Position.X, (int)_p1Position.Y, 30, 30);
                // Es la caja de coliciones de "pruebas" y se basa en el tamaño de la imgane.
                Rectangle manzanaRectangle = new Rectangle((int)_p2Position.X, (int)_p2Position.Y, 30, 30);
                Rectangle bochaRectangle = new Rectangle((int)_bochaPosition.X, (int)_bochaPosition.Y, 30, 30);
                Rectangle lineaRectanglearcoderecha = new Rectangle((int)_barraderechaPositionarco.X, (int)_barraderechaPositionarco.Y, 1, 192);
                Rectangle lineaRectanglearcoizquierza = new Rectangle((int)_barraizquierdaPositionarco.X, (int)_barraizquierdaPositionarco.Y, 10, 192);
                Rectangle lineaRectangle = new Rectangle((int)_barraizquierdaPosition.X, (int)_barraizquierdaPosition.Y, 10, 250);
                Rectangle linea2Rectangle = new Rectangle((int)_barraderechaPosition.X, (int)_barraderechaPosition.Y, 1, 250);
                Rectangle linea3Rectangle = new Rectangle((int)_barraarribaPosition.X, (int)_barraarribaPosition.Y, 1200, 1);
                Rectangle linea4Rectangle = new Rectangle((int)_barraabajoPosition.X, (int)_barraabajoPosition.Y, 1200, 140);
                Rectangle lineagolizquierda = new Rectangle((int)_barragolizquierdaPosition.X, (int)_barragolizquierdaPosition.Y, 10, 200);
                Rectangle lineagolderecha = new Rectangle((int)_barragolderechaPosition.X,(int)_barragolderechaPosition.Y,10,200);

                // Se utiliza para poder recibir el estado del teclado.
                KeyboardState keyboardState = Keyboard.GetState();
                bool _p1movimiento = false;
                bool _p2movimiento = false;
                float friccion1 = 0.99f;
                float friccion = 0.6f;
                Vector2 velocidad = new Vector2(2f, 2f);
                if (bochaRectangle.Intersects(linea3Rectangle) )
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
                if (bochaRectangle.Intersects(linea2Rectangle) || bochaRectangle.Intersects(lineaRectanglearcoderecha))
                {
                    Vector2 normal = Vector2.Normalize(new Vector2(linea2Rectangle.X - bochaRectangle.X, linea2Rectangle.Y - bochaRectangle.Y));

                    float velocidadPerpendicular = (Vector2.Dot(velocidad, normal));

                    Vector2 velocidadParalela = velocidad - velocidadPerpendicular * normal;

                    velocidad = velocidadParalela - velocidadPerpendicular * normal;
                    _bochaSpeed.X = -velocidad.X;
                }

                if (bochaRectangle.Intersects(lineaRectangle) || bochaRectangle.Intersects(lineaRectanglearcoizquierza))
                {
                    Vector2 normal = Vector2.Normalize(new Vector2(lineaRectangle.X - bochaRectangle.X, lineaRectangle.Y - bochaRectangle.Y));

                    float velocidadPerpendicular = (Vector2.Dot(velocidad, normal));

                    Vector2 velocidadParalela = velocidad - velocidadPerpendicular * normal;

                    velocidad = velocidadParalela - velocidadPerpendicular * normal * 4;
                    _bochaSpeed.X = velocidad.X;
                }






                if (keyboardState.IsKeyDown(Keys.Left) && pausa==false)
                {
                    _p1Speed.X -= 2;
                    _p1movimiento = false;
                }

                else if (keyboardState.IsKeyDown(Keys.Right) && pausa == false)
                {


                    _p1Speed.X += 2;
                    _p1movimiento = false;
                }
                else
                {
                    _p1movimiento = true;
                    _p1Speed.X = 0;
                }




                if (bochaRectangle.Intersects(pruebasRectangle) && !_p1movimiento && keyboardState.IsKeyDown(Keys.P))
                {

                    _bochaSpeed = Vector2.Normalize(_p1Speed) * 4;

                }
                if (bochaRectangle.Intersects(lineagolizquierda)) {
                    equipo2 = equipo2 + 1;
                    _bochaSpeed *=0;
                    _p1Position.X = 321;
                    _p1Position.Y = 340;
                    _p2Position.X = 921;
                    _p2Position.Y = 340;
                    _bochaPosition.X = 621;
                    _bochaPosition.Y = 340;
                   
                    
                }
                if (bochaRectangle.Intersects(lineagolderecha)) {
                    equipo1 = equipo1 + 1;
                    _bochaSpeed *= 0;
                    _p1Position.X = 321;
                    _p1Position.Y = 340;
                    _p2Position.X = 921;
                    _p2Position.Y = 340;
                    _bochaPosition.X = 621;
                    _bochaPosition.Y = 340;
                }
                if (pausa == false)
                {
                    _bochaPosition.X += _bochaSpeed.X;
                    _bochaSpeed *= friccion1;
                }
                _p1Position.X += _p1Speed.X;
                    _p1Speed *= friccion;
                



                if (keyboardState.IsKeyDown(Keys.Up) && pausa == false)
                {
                    _p1Speed.Y -= 2; _p1movimiento = false;
                }

                else if (keyboardState.IsKeyDown(Keys.Down) && pausa == false)
                {


                    _p1Speed.Y += 2; _p1movimiento = false;
                }
                else
                {
                    _p1Speed.Y = 0; _p1movimiento = true;
                }



                if (bochaRectangle.Intersects(pruebasRectangle) && !_p1movimiento && keyboardState.IsKeyDown(Keys.P))
                {

                    _bochaSpeed = Vector2.Normalize(_p1Speed) * 4;

                }
                if (pausa == false)
                {
                    _bochaPosition.Y += _bochaSpeed.Y;
                    _bochaSpeed *= friccion1;
                }
                _p1Position.Y += _p1Speed.Y;
                _p1Speed *= friccion;











                if (keyboardState.IsKeyDown(Keys.A) && pausa == false)
                {
                    _p2Speed.X -= 2; _p2movimiento = false;
                }

                else if (keyboardState.IsKeyDown(Keys.D) && pausa == false)
                {


                    _p2Speed.X += 2; _p2movimiento = false;
                }
                else
                {
                    _p2Speed.X = 0; _p2movimiento = true;
                }
                if (bochaRectangle.Intersects(manzanaRectangle) && !_p2movimiento && keyboardState.IsKeyDown(Keys.T))
                {

                    {
                        _bochaSpeed = Vector2.Normalize(_p2Speed) * 4;
                    }
                }
                if (pausa == false)
                {
                    _bochaPosition.X += _bochaSpeed.X;
                    _bochaSpeed *= friccion1;
                }
                _p2Position.X += _p2Speed.X;
                _p2Speed *= friccion;


                if (keyboardState.IsKeyDown(Keys.W) && pausa == false)
                {
                    _p2Speed.Y -= 2; _p2movimiento = false;
                }

                else if (keyboardState.IsKeyDown(Keys.S) && pausa == false)
                {


                    _p2Speed.Y += 2; _p2movimiento = false;
                }
                else
                {
                    _p2Speed.Y = 0; _p2movimiento = true;
                }

                if (bochaRectangle.Intersects(manzanaRectangle) && !_p2movimiento && keyboardState.IsKeyDown(Keys.T))
                {

                    {
                        _bochaSpeed = Vector2.Normalize(_p2Speed) * 4;
                    }
                }

                if (pausa == false)
                {
                    _bochaPosition.Y += _bochaSpeed.Y;
                    _bochaSpeed *= friccion1;
                }
                    _p2Position.Y += _p2Speed.Y;
                _p2Speed *= friccion;
                if (pruebasRectangle.Intersects(manzanaRectangle))
                {
                    // Determinar la dirección del empuje
                    Vector2 pushDirection = _p2Position - _p1Position;
                    pushDirection.Normalize();

                    // La cantidad de empuje puede ser una constante o basada en la profundidad de superposición.
                    // Aquí simplemente empujamos por una constante
                    const float pushAmount = 3.8f; // Ajusta según tus necesidades
                    _p2Position += pushDirection * pushAmount;
                }
                if (manzanaRectangle.Intersects(pruebasRectangle))
                {
                    // Determinar la dirección del empuje
                    Vector2 pushDirection = _p1Position - _p2Position;
                    pushDirection.Normalize();

                    // La cantidad de empuje puede ser una constante o basada en la profundidad de superposición.
                    // Aquí simplemente empujamos por una constante
                    const float pushAmount = 3.8f; // Ajusta según tus necesidades
                    _p1Position += pushDirection * pushAmount;
                }


                if (bochaRectangle.Intersects(manzanaRectangle))
                {
                    // Determinar la dirección del empuje
                    Vector2 pushDirection = _bochaPosition - _p2Position;
                    pushDirection.Normalize();

                    // La cantidad de empuje puede ser una constante o basada en la profundidad de superposición.
                    // Aquí simplemente empujamos por una constante
                    const float pushAmount = 4.5f; // Ajusta según tus necesidades
                    _bochaPosition += pushDirection * pushAmount;

                }
                if (bochaRectangle.Intersects(pruebasRectangle))
                {
                    // Determinar la dirección del empuje
                    Vector2 pushDirection = _bochaPosition - _p1Position;
                    pushDirection.Normalize();

                    // La cantidad de empuje puede ser una constante o basada en la profundidad de superposición.
                    // Aquí simplemente empujamos por una constante
                    const float pushAmount = 4f; // Ajusta según tus necesidades
                    _bochaPosition += pushDirection * pushAmount;

                }
                if (inicio3.IsKeyDown(Keys.Escape)) {
                    pausa = true;
                    
                
                }
                if (pausa==true) {
                    if (inicio3.IsKeyDown(Keys.Q))
                    {
                        pausa = false;

                    }
                   
                    
                }

             
            }
            base.Update(gameTime); 
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            // Limpia 20 veces por segundo la imagen.

            _spriteBatch.Begin();


            if (pantalla == 1)
            {
                _spriteBatch.Draw(_menu, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);
                string texto = "PRESIONE ENTER PARA INICIAR";
                Vector2 posicion = new Vector2(290, 380);
                Color color = Color.White;

                _spriteBatch.DrawString(myFont, texto, posicion, color);
            }

            else if (pantalla == 2)
            {
                _spriteBatch.Draw(_personajes, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);
                _spriteBatch.Draw(_river, new Rectangle((int)_riverPosition.X,(int)_riverPosition.Y,90,90), _selectedTeam == Team.River ? Color.Red : Color.White);
                _spriteBatch.Draw(_boca, new Rectangle((int)_bocaPosition.X, (int)_bocaPosition.Y, 90, 90), _selectedTeam == Team.Boca ? Color.Red : Color.White);
                _spriteBatch.Draw(_racing, new Rectangle((int)_racingPosition.X, (int)_racingPosition.Y, 90, 90), _selectedTeam == Team.Racing ? Color.Red : Color.White);
                _spriteBatch.Draw(_independiente, new Rectangle((int)_independientePosition.X, (int)_independientePosition.Y, 90, 90), _selectedTeam == Team.Independiente ? Color.Red : Color.White);

                if (_selectedTeam == Team.River)
                {
                    _spriteBatch.Draw(_riverjuga, new Rectangle((int)_riverjugaPosition.X, (int)_riverjugaPosition.Y, 180, 180), Color.White);
                }
                else if (_selectedTeam == Team.Boca)
                {
                    _spriteBatch.Draw(_tevez, new Rectangle((int)_tevezPosition.X, (int)_tevezPosition.Y, 180, 180), Color.White);
                }
                else if (_selectedTeam == Team.Racing)
                {
                    _spriteBatch.Draw(_racingjuga, new Rectangle((int)_racingjugaPosition.X, (int)_racingjugaPosition.Y, 180, 180), Color.White);
                }
                else if (_selectedTeam == Team.Independiente)
                {
                    _spriteBatch.Draw(_rojojuga, new Rectangle((int)_rojojugaPosition.X, (int)_rojojugaPosition.Y, 180, 180), Color.White);
                }


            }
            else if (pantalla==3) {
                
                string resul=Convert.ToString(equipo1);

                Vector2 posicion = new Vector2(477,35);
                Color color = Color.Red;

                string resul2= Convert.ToString(equipo2);
                Vector2 posicion2 = new Vector2(800, 35);
                Color color2 = Color.Red;



             
                _spriteBatch.Draw(_backgroundTexture, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);
                _spriteBatch.Draw(_p1Texture, new Rectangle((int)_p1Position.X, (int)_p1Position.Y, 45, 45), Color.White);

                _spriteBatch.Draw(_p2Texture, new Rectangle((int)_p2Position.X, (int)_p2Position.Y, 45, 45), Color.BlueViolet);
                _spriteBatch.Draw(_bochaTexture, new Rectangle((int)_bochaPosition.X, (int)_bochaPosition.Y, 40, 40), Color.White);
                _spriteBatch.Draw(_contador, new Rectangle((int)_contadorPosition.X, (int)_contadorPosition.Y, 390, 60), Color.White);
                _spriteBatch.DrawString(myFont, resul, posicion, color);
                _spriteBatch.DrawString(myFont, resul2, posicion2, color2);               
                _spriteBatch.Draw(_barraizquierdaarco, new Rectangle((int)_barraizquierdaPositionarco.X, (int)_barraizquierdaPositionarco.Y, 30, 447), Color.Transparent);
                _spriteBatch.Draw(_barraizquierda, new Rectangle((int)_barraizquierdaPosition.X, (int)_barraizquierdaPosition.Y, 30, 192), Color.Transparent);
                _spriteBatch.Draw(_barraderecha, new Rectangle((int)_barraderechaPosition.X, (int)_barraderechaPosition.Y, 30, 192), Color.Red);
                _spriteBatch.Draw(_barraderechaarco, new Rectangle((int)_barraderechaPositionarco.X, (int)_barraderechaPositionarco.Y, 30, 192), Color.Transparent);
                _spriteBatch.Draw(_barraarriba, new Rectangle((int)_barraarribaPosition.X, (int)_barraarribaPosition.Y, 1200, 1), Color.Transparent);
                _spriteBatch.Draw(_barraabajo, new Rectangle((int)_barraabajoPosition.X, (int)_barraabajoPosition.Y, 1200, 1), Color.Transparent);
                _spriteBatch.Draw(_barragolizquierda, new Rectangle((int)_barragolizquierdaPosition.X, (int)_barragolizquierdaPosition.Y, 30, 175), Color.Red);
                _spriteBatch.Draw(_barragolderecha, new Rectangle((int)_barragolderechaPosition.X,(int)_barragolderechaPosition.Y,30,170),Color.Red);

                if (pausa == true) {
                    _spriteBatch.Draw(_pausa, new Rectangle((int)_pausaPosition.X, (int)_pausaPosition.Y, 200, 200),Color.White);
                   


                }

            }


            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
