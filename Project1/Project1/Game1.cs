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

        // Jugador 1
        private Vector2 _p1Speed = new Vector2(3, 3);
        private Texture2D _p1Texture;
        private Vector2 _p1Position;

        //Jugador 2
        private Vector2 _p2Speed = new Vector2(3, 3);
        private Texture2D _p2Texture;
        private Vector2 _p2Position;


        //Bocha(pelota)
        private Vector2 _bochaPosition;
        private Vector2 _bochaSpeed = new Vector2(0, 0);
        private Texture2D _bochaTexture;


        //Menu Partida
        private Texture2D _backgroundTexture;
        private Texture2D _barraizquierda;
        private Texture2D _barraderecha;
        private Texture2D _barraabajo;
        private Texture2D _barraarriba;
        private Texture2D _barraizquierdaarco;
        private Vector2 _barraarribaPosition;
        private Vector2 _barraabajoPosition;
        private Vector2 _barraizquierdaPosition;
        private Vector2 _barraderechaPosition;
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
        private Texture2D _final;
        private Vector2 _finalPosition;
        private float contadorSegundos = 0.0f;
        private float contadorSegundos2 = 0.0f;
        private DateTime tiempo, tiempoActual;
        private DateTime tiempo1, tiempoActual1;
        private TimeSpan dif;
        private TimeSpan dif1;
        private bool estado = true, si = false;
        private DateTime tiempo3, tiempoActual3;
        private TimeSpan dif3;
        private bool tiempoestado = true;
        private bool final = true;
        private string nombrequip1;
        private string nombrequip2;


        //Menu inicial
        private int pantalla = 1;

        //Menu de personajes
        private Texture2D _menu;
        private Texture2D _personajes;
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
        private Team _selectedTeam2 = Team.Boca;
        private KeyboardState _previousKeyboardState;
        private int elegido;
        private int elegido2;
    



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
          //Carga de textura menu personajes
            _pausa=Content.Load<Texture2D>("pausa5");
            _pausaPosition = new Vector2(443,290);
            _final = Content.Load<Texture2D>("final");
            _finalPosition = new Vector2(450, 180);
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
            // Carga las texturas de partida
            _p1Texture = Content.Load<Texture2D>("a");
            _p1Position = new Vector2(321, 340);
            _p2Texture = Content.Load<Texture2D>("a");
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
            if (pantalla == 1)//Menu inicial
            {
                KeyboardState inicio = Keyboard.GetState();
                if (inicio.IsKeyDown(Keys.Enter))
                {
                    pantalla = 2;

                }
            }
            else if (pantalla == 2)//Menu de personajes
            {


                Rectangle river = new Rectangle((int)_riverPosition.X, (int)_riverPosition.Y, 200, 200);
                Rectangle boca = new Rectangle((int)_bocaPosition.X, (int)_bocaPosition.Y, 200, 200);
                Rectangle racing = new Rectangle((int)_racingPosition.X, (int)_racingPosition.Y, 200, 200);
                Rectangle independiente = new Rectangle((int)_independientePosition.X, (int)_independientePosition.Y, 200, 200);
                KeyboardState inicio2 = Keyboard.GetState();
                KeyboardState keyboardState = Keyboard.GetState();

                if (keyboardState.IsKeyDown(Keys.D) && !_previousKeyboardState.IsKeyDown(Keys.D))
                {
                    // Cambia al siguiente equipo
                    if (_selectedTeam2 == Team.River) _selectedTeam2 = Team.Boca;
                    else if (_selectedTeam2 == Team.Boca) _selectedTeam2 = Team.Racing;
                    else if (_selectedTeam2 == Team.Racing) _selectedTeam2 = Team.Independiente;
                    else if (_selectedTeam2 == Team.Independiente) _selectedTeam2 = Team.River;

                }

                if (keyboardState.IsKeyDown(Keys.A) && !_previousKeyboardState.IsKeyDown(Keys.A))
                {
                    // Cambia al equipo anterior
                    if (_selectedTeam2 == Team.River) _selectedTeam2 = Team.Independiente;
                    else if (_selectedTeam2 == Team.Boca) _selectedTeam2 = Team.River;
                    else if (_selectedTeam2 == Team.Racing) _selectedTeam2 = Team.Boca;
                    else if (_selectedTeam2 == Team.Independiente) _selectedTeam2 = Team.Racing;

                }

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
                if (inicio2.IsKeyDown(Keys.P))
                {
                    if (_selectedTeam == Team.River)
                    {
                        elegido = 1;
                        nombrequip1 = "RIVER";
                    }
                    if (_selectedTeam == Team.Boca)
                    {
                        elegido = 1;
                        nombrequip1 = "BOCA";
                    }
                    if (_selectedTeam == Team.Racing)
                    {
                        elegido = 1;
                        nombrequip1 = "RACING";
                    }
                    if (_selectedTeam == Team.Independiente)
                    {
                        elegido = 1;
                        nombrequip1 = "IND";
                    }
                    if (_selectedTeam2 ==Team.River) {
                        elegido2 = 1;
                        nombrequip2 = "RIVER";
                    }
                    if (_selectedTeam2 == Team.Boca)
                    {
                        elegido2 = 1;
                        nombrequip2 = "BOCA";
                    }
                    if (_selectedTeam2 == Team.Racing)
                    {
                        elegido2 = 1;
                        nombrequip2 = "RACING";
                    }
                    if (_selectedTeam2 == Team.Independiente)
                    {
                        elegido2 = 1;
                        nombrequip2 = "IND";
                    }
                    pantalla = 3;

                }
                _previousKeyboardState = keyboardState;

            }
            else if (pantalla == 3)
            {
                if (tiempoestado)
                {
                    tiempo3 = DateTime.Now;
                    tiempoActual3 = DateTime.Now;
                    tiempoestado = false;
                }
                tiempoActual3 = DateTime.Now;
                dif3= tiempoActual3 - tiempo3;
                KeyboardState inicio3 = Keyboard.GetState();
                //Cajas de colisiones
                Rectangle pruebasRectangle = new Rectangle((int)_p1Position.X, (int)_p1Position.Y, 30, 30);
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

                //Rebote de la pelota
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


                if (elegido==1)
                {

                    if (estado)
                    {
                        if (!si)
                        {
                          
                            Debug.Write("hola");
                            tiempo = DateTime.Now;
                            tiempoActual = DateTime.Now;

                            si = true;

                        }
                        tiempoActual = DateTime.Now;
                        dif = tiempoActual - tiempo;
                        Debug.Write(dif.TotalSeconds.ToString());
                        if (bochaRectangle.Intersects(pruebasRectangle) && !_p1movimiento && keyboardState.IsKeyDown(Keys.P))
                        {
                            _bochaSpeed = Vector2.Normalize(_p1Speed) * 4;

                        }
                        if (bochaRectangle.Intersects(manzanaRectangle) && !_p2movimiento && keyboardState.IsKeyDown(Keys.T))
                        {

                            
                                _bochaSpeed = Vector2.Normalize(_p2Speed) * 4;
                            
                        }

                        if (dif.Seconds == 30)
                        {
                            dif = tiempoActual - tiempoActual;
                            si = false;
                            estado = false;
                        }
                    }
                    if (!estado)
                    {
                        Debug.Write("fino");
                        if (!si)
                        {
                            tiempo1 = DateTime.Now;
                            tiempoActual1 = DateTime.Now;

                            si = true;
                        }
                        tiempoActual1 = DateTime.Now;
                        dif1 = tiempoActual1 - tiempo1;
                        if (bochaRectangle.Intersects(pruebasRectangle) && !_p1movimiento && keyboardState.IsKeyDown(Keys.P))
                        {
                            _bochaSpeed = Vector2.Normalize(_p1Speed) * 10;
                        }
                        if (bochaRectangle.Intersects(manzanaRectangle) && !_p2movimiento && keyboardState.IsKeyDown(Keys.T))
                        {

                            
                                _bochaSpeed = Vector2.Normalize(_p2Speed) * 10;
                            
                        }
                        if (dif1.Seconds == 10)
                        {
                            dif1 = tiempoActual1 - tiempoActual1;
                            si = false;
                            estado = true;
                        }
                    }
                }
                //Reinicio despues de gol
                if (bochaRectangle.Intersects(lineagolizquierda))
                {
                    equipo2 = equipo2 + 1;
                    _bochaSpeed *= 0;
                    _p1Position.X = 321;
                    _p1Position.Y = 340;
                    _p2Position.X = 921;
                    _p2Position.Y = 340;
                    _bochaPosition.X = 621;
                    _bochaPosition.Y = 340;


                }
                if (bochaRectangle.Intersects(lineagolderecha))
                {
                    equipo1 = equipo1 + 1;
                    _bochaSpeed *= 0;
                    _p1Position.X = 321;
                    _p1Position.Y = 340;
                    _p2Position.X = 921;
                    _p2Position.Y = 340;
                    _bochaPosition.X = 621;
                    _bochaPosition.Y = 340;
                }
                if (pausa == false || final == true)
                {
                    _bochaPosition.X += _bochaSpeed.X;
                    _bochaSpeed *= friccion1;

                }


                //Movimiento jugador1
                if (keyboardState.IsKeyDown(Keys.Left) && pausa==false && final == true)
                {
                    _p1Speed.X -= 2;
                    _p1movimiento = false;
                }

                else if (keyboardState.IsKeyDown(Keys.Right) && pausa == false && final == true)
                {


                    _p1Speed.X += 2;
                    _p1movimiento = false;
                }
                else
                {
                    _p1movimiento = true;
                    _p1Speed.X = 0;
                }




              
                _p1Position.X += _p1Speed.X;
                    _p1Speed *= friccion;
                



                if (keyboardState.IsKeyDown(Keys.Up) && pausa == false && final == true)
                {
                    _p1Speed.Y -= 2; _p1movimiento = false;
                }

                else if (keyboardState.IsKeyDown(Keys.Down) && pausa == false && final == true)
                {


                    _p1Speed.Y += 2; _p1movimiento = false;
                }
                else
                {
                    _p1Speed.Y = 0; _p1movimiento = true;
                }



          
                    if (pausa == false|| final==true)
                {
                    _bochaPosition.Y += _bochaSpeed.Y;
                    _bochaSpeed *= friccion1;
                }
                _p1Position.Y += _p1Speed.Y;
                _p1Speed *= friccion;









                //Movimiento jugador2

                if (keyboardState.IsKeyDown(Keys.A) && pausa == false && final == true)
                {
                    _p2Speed.X -= 2; _p2movimiento = false;
                }

                else if (keyboardState.IsKeyDown(Keys.D) && pausa == false && final == true)
                {


                    _p2Speed.X += 2; _p2movimiento = false;
                }
                else
                {
                    _p2Speed.X = 0; _p2movimiento = true;
                }
               
                if (pausa == false || final == true)
                {
                    _bochaPosition.X += _bochaSpeed.X;
                    _bochaSpeed *= friccion1;
                }
                _p2Position.X += _p2Speed.X;
                _p2Speed *= friccion;


                if (keyboardState.IsKeyDown(Keys.W) && pausa == false && final==true)
                {
                    _p2Speed.Y -= 2; _p2movimiento = false;
                }

                else if (keyboardState.IsKeyDown(Keys.S) && pausa == false && final == true)
                {


                    _p2Speed.Y += 2; _p2movimiento = false;
                }
                else
                {
                    _p2Speed.Y = 0; _p2movimiento = true;
                }

               

                if (pausa == false || final == true)
                {
                    _bochaPosition.Y += _bochaSpeed.Y;
                    _bochaSpeed *= friccion1;
                }
                    _p2Position.Y += _p2Speed.Y;
                _p2Speed *= friccion;






                //Evita la superposicion
                if (pruebasRectangle.Intersects(manzanaRectangle))
                {
                    Vector2 pushDirection = _p2Position - _p1Position;
                    pushDirection.Normalize();

                    const float pushAmount = 3.8f;
                    _p2Position += pushDirection * pushAmount;
                }
                if (manzanaRectangle.Intersects(pruebasRectangle))
                {
                    Vector2 pushDirection = _p1Position - _p2Position;
                    pushDirection.Normalize();

                    const float pushAmount = 3.8f; 
                    _p1Position += pushDirection * pushAmount;
                }


                if (bochaRectangle.Intersects(manzanaRectangle))
                {
                    Vector2 pushDirection = _bochaPosition - _p2Position;
                    pushDirection.Normalize();

                    const float pushAmount = 4.5f;
                    _bochaPosition += pushDirection * pushAmount;

                }
                if (bochaRectangle.Intersects(pruebasRectangle))
                {
                    Vector2 pushDirection = _bochaPosition - _p1Position;
                    pushDirection.Normalize();

                    const float pushAmount = 4f; 
                    _bochaPosition += pushDirection * pushAmount;

                }






                //Menu pausa

                if (inicio3.IsKeyDown(Keys.Escape)) {
                    pausa = true;
                    
                
                }
                if (pausa==true) {
                    if (inicio3.IsKeyDown(Keys.Q))
                    {
                        pausa = false;

                    }
                    if (inicio3.IsKeyDown(Keys.P)) {
                        Exit();
                    }
                   
                    
                }
                if (final==false) {
                    if (inicio3.IsKeyDown(Keys.Escape)) {
                        Exit();
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

            //Draw de los Menus
            if (pantalla == 1)
            {
                _spriteBatch.Draw(_menu, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);
                string texto = "PRESIONE ENTER PARA INICIAR";
                Vector2 posicion = new Vector2(490, 600);
                Color color = Color.White;

                _spriteBatch.DrawString(myFont, texto, posicion, color);
            }

            else if (pantalla == 2)
            {
                string cont9 = "Presione P para continuar.";
                Vector2 posicio9 = new Vector2(550, 80);
                Color color9 = Color.White;
                string contk = "Nota:Cada 30 segundos habra un lapso de tiempo en el cual la potencia de disparo se aumentara en ambos jugadores por 10 segundos.";
                Vector2 posiciok = new Vector2(150, 600);
                Color colork = Color.White;

                _spriteBatch.Draw(_personajes, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);
                _spriteBatch.Draw(_river, new Rectangle((int)_riverPosition.X,(int)_riverPosition.Y,90,90), _selectedTeam == Team.River ? Color.Red : Color.White);
                _spriteBatch.Draw(_boca, new Rectangle((int)_bocaPosition.X, (int)_bocaPosition.Y, 90, 90), _selectedTeam == Team.Boca ? Color.Red : Color.White);
                _spriteBatch.Draw(_racing, new Rectangle((int)_racingPosition.X, (int)_racingPosition.Y, 90, 90), _selectedTeam == Team.Racing ? Color.Red : Color.White);
                _spriteBatch.Draw(_independiente, new Rectangle((int)_independientePosition.X, (int)_independientePosition.Y, 90, 90), _selectedTeam == Team.Independiente ? Color.Red : Color.White);
                _spriteBatch.Draw(_river, new Rectangle(700, (int)_riverPosition.Y, 90, 90), _selectedTeam2 == Team.River ? Color.Blue : Color.White);
                _spriteBatch.Draw(_boca, new Rectangle(800, (int)_bocaPosition.Y, 90, 90), _selectedTeam2 == Team.Boca ? Color.Blue : Color.White);
                _spriteBatch.Draw(_racing, new Rectangle(900, (int)_racingPosition.Y, 90, 90), _selectedTeam2 == Team.Racing ? Color.Blue : Color.White);
                _spriteBatch.Draw(_independiente, new Rectangle(1000, (int)_independientePosition.Y, 90, 90), _selectedTeam2 == Team.Independiente ? Color.Blue : Color.White);
                _spriteBatch.DrawString(myFont, contk, posiciok, colork);
                _spriteBatch.DrawString(myFont, cont9, posicio9, color9);
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


                

                if (_selectedTeam2== Team.River)
                {
                    _spriteBatch.Draw(_riverjuga, new Rectangle(800, (int)_riverjugaPosition.Y, 180, 180), Color.White);
                }
                else if (_selectedTeam2 == Team.Boca)
                {
                    _spriteBatch.Draw(_tevez, new Rectangle(800, (int)_tevezPosition.Y, 180, 180), Color.White);
                }
                else if (_selectedTeam2 == Team.Racing)
                {
                    _spriteBatch.Draw(_racingjuga, new Rectangle(800, (int)_racingjugaPosition.Y, 180, 180), Color.White);
                }
                else if (_selectedTeam2 == Team.Independiente)
                {
                    _spriteBatch.Draw(_rojojuga, new Rectangle(800, (int)_rojojugaPosition.Y, 180, 180), Color.White);
                }


            }
            else if (pantalla==3) {
                string conth = "Presione P para pausar";
                Vector2 posicionh = new Vector2(1100, 35);
                Color colorh = Color.White;
                string  cont="Contador:"+Convert.ToString(dif3.Seconds);
                Vector2 posicion4 = new Vector2(250, 35);
                Color color4 = Color.White;


                string resul=Convert.ToString(equipo1);

                Vector2 posicion = new Vector2(477,30);
                Color color = Color.White;

                string resul2= Convert.ToString(equipo2);
                Vector2 posicion2 = new Vector2(800, 30);
                Color color2 = Color.White;
                string resulq = Convert.ToString(nombrequip1);

                Vector2 posicionq = new Vector2(530, 30);
                Color colorq = Color.White;
                string resulz = Convert.ToString(nombrequip2);

                Vector2 posicionz = new Vector2(705, 30);
                Color colorz = Color.White;




                _spriteBatch.Draw(_backgroundTexture, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);
                _spriteBatch.Draw(_p1Texture, new Rectangle((int)_p1Position.X, (int)_p1Position.Y, 45, 45), _selectedTeam == Team.River ? Color.White : Color.Blue);

                _spriteBatch.Draw(_p2Texture, new Rectangle((int)_p2Position.X, (int)_p2Position.Y, 45, 45), _selectedTeam2 == Team.River ? Color.Red : Color.Blue);
                _spriteBatch.Draw(_bochaTexture, new Rectangle((int)_bochaPosition.X, (int)_bochaPosition.Y, 40, 40), Color.White);
                _spriteBatch.Draw(_contador, new Rectangle((int)_contadorPosition.X, (int)_contadorPosition.Y, 390, 60), Color.White);
                _spriteBatch.DrawString(myFont, resul, posicion, color);
                _spriteBatch.DrawString(myFont, resul2, posicion2, color2);
                _spriteBatch.DrawString(myFont, cont, posicion4, color4);
                _spriteBatch.DrawString(myFont, conth, posicionh, colorh);
                _spriteBatch.DrawString(myFont, resulq, posicionq, colorq);
                _spriteBatch.DrawString(myFont, resulz, posicionz, colorz);
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
                if (dif3.Seconds >= 120)
                {
                    string resuld = Convert.ToString(nombrequip1);

                    Vector2 posiciond = new Vector2(550, 270);
                    Color colord = Color.White;
                    string resulv = Convert.ToString(nombrequip2);

                    Vector2 posicionv = new Vector2(740, 270);
                    Color colorv = Color.White;

                    string resulb = Convert.ToString(equipo1);

                    Vector2 posicionb = new Vector2(570, 330);
                    Color colorb = Color.White;
                    string resulc = Convert.ToString(equipo2);

                    Vector2 posicionc = new Vector2(760, 330);
                    Color colorc = Color.White;
                    final = false;
                    _spriteBatch.Draw(_final, new Rectangle((int)_finalPosition.X, (int)_finalPosition.Y, 450, 450), Color.White);
                    _spriteBatch.DrawString(myFont, resulb, posicionb, colorb);
                    _spriteBatch.DrawString(myFont, resulc, posicionc, colorc);
                    _spriteBatch.DrawString(myFont, resuld, posiciond, colord);
                    _spriteBatch.DrawString(myFont, resulv, posicionv, colorv);
                }
                if (equipo1==2 || equipo2==2)
                {
                    string resuld = Convert.ToString(nombrequip1);

                    Vector2 posiciond = new Vector2(550, 270);
                    Color colord = Color.White;
                    string resulv = Convert.ToString(nombrequip2);

                    Vector2 posicionv = new Vector2(740, 270);
                    Color colorv = Color.White;

                    string resulb = Convert.ToString(equipo1);

                    Vector2 posicionb = new Vector2(570, 330);
                    Color colorb = Color.White;
                    string resulc = Convert.ToString(equipo2);

                    Vector2 posicionc = new Vector2(760, 330);
                    Color colorc = Color.White;
                    final = false;
                    _spriteBatch.Draw(_final, new Rectangle((int)_finalPosition.X, (int)_finalPosition.Y, 450, 450), Color.White);
                    _spriteBatch.DrawString(myFont, resulb, posicionb, colorb);
                    _spriteBatch.DrawString(myFont, resulc, posicionc, colorc);
                    _spriteBatch.DrawString(myFont, resuld, posiciond, colord);
                    _spriteBatch.DrawString(myFont, resulv, posicionv, colorv);

                }
                
            }


            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
