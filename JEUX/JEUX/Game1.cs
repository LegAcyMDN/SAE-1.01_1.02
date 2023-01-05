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
       
        public const int hauteurP = 150;
        public const int largeurP = 50;
        
        private Texture2D _textureCharacterP;
        private Texture2D _texturePoint;
        private Texture2D _textureObstacleP;
        private Texture2D _textureObstacleD;
        private Texture2D _textureObstacleT;
        private Texture2D _textureObstacleQ;

        /*private int score;
        private int credit;
        private int vie;
        private int _sensCharacter;

        private SpriteFont _police;*/
        
        private Color _backgroundColour = Color.CornflowerBlue;
        private List<Component> _gameComponents;

        private Texture2D _textureBackgroundMenu;

        public const int LARGEUR_FENETRE = 1900;
        public const int HAUTEUR_FENETRE = 1040;

        private readonly ScreenManager _screenManager;

        public SpriteBatch SpriteBatch { get; set; }
        

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            _screenManager = new ScreenManager();
            Components.Add(_screenManager);
        }

        protected override void Initialize()

        {
            /*_textureCharacterP = Content.Load<Texture2D>("characterP");
            _texturePoint = Content.Load<Texture2D>("Point");
            _textureObstacleP = Content.Load<Texture2D>("ObstacleP");
            _textureObstacleD = Content.Load<Texture2D>("ObstacleD");
            _textureObstacleT = Content.Load<Texture2D>("ObstacleT");
            _textureObstacleQ = Content.Load<Texture2D>("ObstacleQ");*/

            /*credit = 0;
            score = 0;
            vie = 3;*/

            // TODO: Add your initialization logic here
            _graphics.PreferredBackBufferWidth = LARGEUR_FENETRE;
            _graphics.PreferredBackBufferHeight = HAUTEUR_FENETRE;
            _graphics.ApplyChanges();

            IsMouseVisible = true;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            var playButton = new Button(Content.Load<Texture2D>("Controls/Button3"), Content.Load<SpriteFont>("Fonts/Font"))
            {
                Position = new Vector2(850 , 421),
                Text = "JOUER",
            };

            playButton.Click += PlayButton_Click;

            var quitButton = new Button(Content.Load<Texture2D>("Controls/Button3"), Content.Load<SpriteFont>("Fonts/Font"))
            {
                Position = new Vector2(0, 935),
                Text = "FERMER",
            };

            quitButton.Click += QuitButton_Click;

            var keyButton = new Button(Content.Load<Texture2D>("Controls/Button3"), Content.Load<SpriteFont>("Fonts/Font"))
            {
                Position = new Vector2(1700, 935),
                Text = "TOUCHE",
            };

            keyButton.Click += KeyButton_Click;

            var ruleButton = new Button(Content.Load<Texture2D>("Controls/Button3"), Content.Load<SpriteFont>("Fonts/Font"))
            {
                Position = new Vector2(1700, 0),
                Text = "REGLE",
            };

            ruleButton.Click += RuleButton_Click;

            _gameComponents = new List<Component>()
            {
                playButton, 
                quitButton,
                keyButton,
                ruleButton,
            };

            _textureBackgroundMenu = Content.Load<Texture2D>("backgroundMenu");

            /*_myScreen1 = new MyScreen1(this); // en leur donnant une référence au Game
            _myScreen2 = new MyScreen2(this);*/
            // TODO: use this.Content to load your game content here
        }

        private void RuleButton_Click(object sender, EventArgs e)
        {
            Exit();
        }

        private void KeyButton_Click(object sender, EventArgs e)
        {
            Exit();
        }

        private void QuitButton_Click(object sender, EventArgs e)
        {
            Exit();
        }

        private void PlayButton_Click(object sender, EventArgs e)
        {
            var random = new Random();

            _backgroundColour = new Color(random.Next(0, 255), random.Next(0, 255),random.Next(0, 255));
        }

        protected override void Update(GameTime gameTime)
        {
            foreach(var component in _gameComponents)
                component.Update(gameTime);

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(_backgroundColour);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();

            _spriteBatch.Draw(_textureBackgroundMenu, new Rectangle(0, 0, LARGEUR_FENETRE, HAUTEUR_FENETRE), Color.White);
            
            foreach (var component in _gameComponents)
                component.Draw(gameTime, _spriteBatch);

            /*_spriteBatch.DrawString(_police, $"Score  : {score}", _positionScore, Color.White);
            _spriteBatch.DrawString(_police, $"Vie   : {vie}", _positionVie, Color.Red);
            _spriteBatch.DrawString(_police, $"Crédit  : {credit}", _positionCredit, Color.Blue);*/

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}