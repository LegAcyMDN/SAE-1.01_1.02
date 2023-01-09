using jeux.Controls;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
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

        private SpriteBatch _spriteBatch;

        private List<Composantes> _gameComponents;

        private Texture2D _textureBackgroundMenu;

        public const int LARGEUR_FENETRE = 1900;
        public const int HAUTEUR_FENETRE = 1040;

        private Rectangle boutonFermer;
        private Rectangle boutonTouche;
        private Rectangle boutonRegle;
        private Rectangle boutonJouer;
        private Rectangle boutonBoutique;

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

            boutonFermer = new Rectangle(20, 950, 170, 1000);
            boutonTouche = new Rectangle(1725, 950, 1875, 1020);
            boutonRegle = new Rectangle(1725, 15, 1875, 80);
            boutonJouer = new Rectangle(875, 415, 1025, 485);
            boutonBoutique = new Rectangle(850, 900, 950, 1000);

            var jouerBouton = new Bouton(Content.Load<Texture2D>("Controls/Button3"), Content.Load<SpriteFont>("Fonts/Font"))
            {
                Position = new Vector2(850, 400),
                Text = "JOUER",
            };

            var quitterBouton = new Bouton(Content.Load<Texture2D>("Controls/Button3"), Content.Load<SpriteFont>("Fonts/Font"))
            {
                Position = new Vector2(0, 935),
                Text = "FERMER",
            };

            var toucheBouton = new Bouton(Content.Load<Texture2D>("Controls/Button3"), Content.Load<SpriteFont>("Fonts/Font"))
            {
                Position = new Vector2(1700, 935),
                Text = "TOUCHE",
            };

            var regleBouton = new Bouton(Content.Load<Texture2D>("Controls/Button3"), Content.Load<SpriteFont>("Fonts/Font"))
            {
                Position = new Vector2(1700, 0),
                Text = "REGLE",
            };

            var boutiqueBouton = new Bouton(Content.Load<Texture2D>("Controls/ShopPixel"), Content.Load<SpriteFont>("Fonts/Font"))
            {
                Position = new Vector2(850, 900),
            };

            _gameComponents = new List<Composantes>()
            {
                jouerBouton,
                quitterBouton,
                toucheBouton,
                regleBouton,
                boutiqueBouton
            };

            _textureBackgroundMenu = Content.Load<Texture2D>("backgroundMenu");

            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            foreach (var component in _gameComponents)
                component.Update(gameTime);

            MouseState _mouseState = Mouse.GetState();
            if (_mouseState.LeftButton == ButtonState.Pressed)
            {
                Console.WriteLine(Mouse.GetState().X + "," + Mouse.GetState().Y);
                if (boutonFermer.Contains(Mouse.GetState().X, Mouse.GetState().Y))
                { _myGame.Etat = Game1.Etats.Quitter; }

                else if (boutonTouche.Contains(Mouse.GetState().X, Mouse.GetState().Y))
                { _myGame.Etat = Game1.Etats.Controle; }

                else if (boutonRegle.Contains(Mouse.GetState().X, Mouse.GetState().Y))
                { _myGame.Etat = Game1.Etats.Regle; }

                else if (boutonJouer.Contains(Mouse.GetState().X, Mouse.GetState().Y))
                { _myGame.Etat = Game1.Etats.Jouer; }

                else if (boutonBoutique.Contains(Mouse.GetState().X, Mouse.GetState().Y))
                { _myGame.Etat = Game1.Etats.Boutique; }
            }
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