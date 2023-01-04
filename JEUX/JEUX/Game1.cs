using jeux.Controls;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace jeux
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Color _backgroundColour = Color.CornflowerBlue;
        private List<Component> _gameComponents;

        private Texture2D _textureBackgroundMenu;

        public const int LARGEUR_FENETRE = 1900;
        public const int HAUTEUR_FENETRE = 1040;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
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
                Position = new Vector2(200 , 250),
                Text = "Play",
            };

            playButton.Click += PlayButton_Click;

            var quitButton = new Button(Content.Load<Texture2D>("Controls/Button3"), Content.Load<SpriteFont>("Fonts/Font"))
            {
                Position = new Vector2(1000, 250),
                Text = "Quit",
            };

            quitButton.Click += QuitButton_Click;

            _gameComponents = new List<Component>()
            {
                playButton,
                quitButton,
            };

            _textureBackgroundMenu = Content.Load<Texture2D>("backgroundMenu");
            // TODO: use this.Content to load your game content here
        }

        private void QuitButton_Click(object sender, System.EventArgs e)
        {
            Exit();
        }

        private void PlayButton_Click(object sender, System.EventArgs e)
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

            _spriteBatch.Begin();
            _spriteBatch.Draw(_textureBackgroundMenu, new Rectangle(0, 0, LARGEUR_FENETRE, HAUTEUR_FENETRE), Color.White);
            foreach (var component in _gameComponents)
                component.Draw(gameTime, _spriteBatch);
            _spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}