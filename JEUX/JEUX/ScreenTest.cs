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
    internal class ScreenTest : GameScreen
    {
        private Game1 _myGame;
        // pour récupérer une référence à l’objet game pour avoir accès à tout ce qui est
        // défini dans Game1

        private SpriteBatch _spriteBatch;

        private List<Composantes> _gameComponents;

        private Texture2D _textureBackgroundMenu;

        private readonly ScreenManager _screenManager;

        public SpriteBatch SpriteBatch { get; set; }

        public ScreenTest(Game1 game) : base(game)
        {
            _myGame = game;

            _screenManager = new ScreenManager();
        }
        public override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            var fermerToucheBouton = new Bouton(Content.Load<Texture2D>("Controls/button3"), Content.Load<SpriteFont>("Fonts/Font"))
            {
                Position = new Vector2(1700, 935),
                Text = "FERMER",
            };

            fermerToucheBouton.Click += FermerToucheBouton_Click;

            _gameComponents = new List<Composantes>()
            {
                fermerToucheBouton
            };

            _textureBackgroundMenu = Content.Load<Texture2D>("backgroundMenu");

            base.LoadContent();
        }

        public void FermerToucheBouton_Click(object sender, EventArgs e)
        {
            this.Dispose();
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