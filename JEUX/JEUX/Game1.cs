using jeux.Controls;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Screens;
using System;
using System.Collections.Generic;

namespace jeux
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        //private List<Composantes> _gameComponents;

        private Color _backgroundColour = Color.CornflowerBlue;

        private Texture2D _textureBackgroundMenu;

        public const int LARGEUR_FENETRE = 1900;
        public const int HAUTEUR_FENETRE = 1040;

        private readonly ScreenManager _screenManager;

        public enum Etats {Menu, Jouer, Controle, Regle, Boutique, Quitter, FermerTouche, 
                            FermerRegle, FermerBoutique};
        private Etats etat;

        private ScreenMenu _menu;
        private ScreenTouche _touche;
        private ScreenRegle _regle;
        private ScreenJouer _jouer;
        private ScreenBoutique _boutique;
        
        public SpriteBatch SpriteBatch 
        { 
            get
                { return this._spriteBatch; } 

            set
                { this._spriteBatch = value; }
        }

        public Etats Etat
        {
            get
                { return this.etat; }

            set
                { this.etat = value; }
        }

        /*public const int hauteurP = 150;
        public const int largeurP = 50;*/

        /*private Texture2D _textureCharacterP;
        private Texture2D _texturePoint;
        private Texture2D _textureObstacleP;
        private Texture2D _textureObstacleD;
        private Texture2D _textureObstacleT;
        private Texture2D _textureObstacleQ;*/

        /*private int score;
        private int credit;
        private int vie;
        private int _sensCharacter;

        private SpriteFont _police;*/

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = LARGEUR_FENETRE;
            _graphics.PreferredBackBufferHeight = HAUTEUR_FENETRE;

            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _screenManager = new ScreenManager();
            Components.Add(_screenManager);

            Etat = Etats.Menu;

            _menu = new ScreenMenu(this);
            _touche = new ScreenTouche(this);
            _regle = new ScreenRegle(this);
            _jouer = new ScreenJouer(this);
            _boutique = new ScreenBoutique(this);

            //_test = new ScreenTest(this);
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _graphics.ApplyChanges();

            IsMouseVisible = true;

            base.Initialize();

            /*_textureCharacterP = Content.Load<Texture2D>("characterP");
            _texturePoint = Content.Load<Texture2D>("Point");
            _textureObstacleP = Content.Load<Texture2D>("ObstacleP");
            _textureObstacleD = Content.Load<Texture2D>("ObstacleD");
            _textureObstacleT = Content.Load<Texture2D>("ObstacleT");
            _textureObstacleQ = Content.Load<Texture2D>("ObstacleQ");*/

            /*credit = 0;
            score = 0;
            vie = 3;*/
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _textureBackgroundMenu = Content.Load<Texture2D>("backgroundMenu");
            _screenManager.LoadScreen(_menu);           

            // TODO: use this.Content to load your game content here
        }        

        protected override void Update(GameTime gameTime)
        {
            // TODO: Add your update logic here

            MouseState _mouseState = Mouse.GetState();
            if (_mouseState.LeftButton == ButtonState.Pressed)
            {
                // Attention, l'état a été mis à jour directement par l'écran en question
                if (this.Etat == Etats.Quitter)
                    Exit();

                else if (this.Etat == Etats.Controle)
                    _screenManager.LoadScreen(_touche);

                else if (this.Etat == Etats.Regle)
                    _screenManager.LoadScreen(_regle);

                else if (this.Etat == Etats.Jouer)
                    _screenManager.LoadScreen(_jouer);

                else if (this.Etat == Etats.FermerTouche)
                    _screenManager.LoadScreen(_menu);

                else if (this.Etat == Etats.FermerRegle)
                    _screenManager.LoadScreen(_menu);

                else if (this.Etat == Etats.Boutique)
                    _screenManager.LoadScreen(_boutique);

                else if (this.Etat == Etats.FermerBoutique)
                    _screenManager.LoadScreen(_menu);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Back))
            {
                if (this.Etat == Etats.Menu)
                    _screenManager.LoadScreen(_menu);
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(_backgroundColour);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _spriteBatch.Draw(_textureBackgroundMenu, new Rectangle(0, 0, LARGEUR_FENETRE, HAUTEUR_FENETRE), Color.White);
            _spriteBatch.End();

            base.Draw(gameTime);

            /*_spriteBatch.DrawString(_police, $"Score  : {score}", _positionScore, Color.White);
            _spriteBatch.DrawString(_police, $"Vie   : {vie}", _positionVie, Color.Red);
            _spriteBatch.DrawString(_police, $"Crédit  : {credit}", _positionCredit, Color.Blue);*/
        }
    }
}
