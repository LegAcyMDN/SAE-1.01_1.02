using jeux.Controls;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Screens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jeux
{
    internal class ScreenMenu : GameScreen
    {
        private Game1 _myGame;
        // pour récupérer une référence à l’objet game pour avoir accès à tout ce qui est
        // défini dans Game1

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Color _backgroundColour = Color.CornflowerBlue;
        private List<Composantes> _gameComponents;

        private Texture2D _textureBackgroundMenu;

        public const int LARGEUR_FENETRE = 1900;
        public const int HAUTEUR_FENETRE = 1040;

        private readonly ScreenManager _screenManager;

        public SpriteBatch SpriteBatch { get; set; }        

        public ScreenMenu(Game1 game) : base(game)
        {
            _myGame = game;
            
            Content.RootDirectory = "Content";

            _screenManager = new ScreenManager();
        }

        
        public override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            var jouerBouton = new Bouton(Content.Load<Texture2D>("Controls/Button3"), Content.Load<SpriteFont>("Fonts/Font"))
            {
                Position = new Vector2(850, 421),
                Text = "JOUER",
            };

            jouerBouton.Click += JouerBouton_Click;

            var quitterBouton = new Bouton(Content.Load<Texture2D>("Controls/Button3"), Content.Load<SpriteFont>("Fonts/Font"))
            {
                Position = new Vector2(0, 935),
                Text = "FERMER",
            };

            quitterBouton.Click += QuitterBouton_Click;

            var toucheBouton = new Bouton(Content.Load<Texture2D>("Controls/Button3"), Content.Load<SpriteFont>("Fonts/Font"))
            {
                Position = new Vector2(1700, 935),
                Text = "TOUCHE",
            };

            toucheBouton.Click += ToucheBouton_Click;

            var regleBouton = new Bouton(Content.Load<Texture2D>("Controls/Button3"), Content.Load<SpriteFont>("Fonts/Font"))
            {
                Position = new Vector2(1700, 0),
                Text = "REGLE",
            };

            regleBouton.Click += RegleBouton_Click;

            _gameComponents = new List<Composantes>()
            {
                jouerBouton,
                quitterBouton,
                toucheBouton,
                regleBouton,
            };

            _textureBackgroundMenu = Content.Load<Texture2D>("backgroundMenu");

            base.LoadContent();
        }

        private void RegleBouton_Click(object sender, EventArgs e)
        {
            //_screenManager.LoadScreen(_regle);
        }

        private void ToucheBouton_Click(object sender, EventArgs e)
        {
            //_screenManager.LoadScreen(_test);
        }

        private void QuitterBouton_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void JouerBouton_Click(object sender, EventArgs e)
        {
            var random = new Random();

            _backgroundColour = new Color(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255));
        }

        public override void Update(GameTime gameTime)
        {
            foreach (var component in _gameComponents)
                component.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin();
            _spriteBatch.Draw(_textureBackgroundMenu, new Rectangle(0, 0, 1900, 1040), Color.White);
            foreach (var component in _gameComponents)
                component.Draw(gameTime, _spriteBatch);
            _spriteBatch.End();
        }
    }
}