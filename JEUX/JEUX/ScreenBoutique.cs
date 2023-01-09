/*using jeux.Controls;
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
    internal class ScreenBoutique : GameScreen
    {
        private Game1 _myGame;
        // pour récupérer une référence à l’objet game pour avoir accès à tout ce qui est
        // défini dans Game1

        private SpriteBatch _spriteBatch;

        private List<Composantes> _gameComponents;

        private Texture2D _textureBackgroundMenu;

        private Rectangle boutonFermerBoutique;
        private Rectangle boutonAvatar;

        public ScreenBoutique(Game1 game) : base(game)
        {
            _myGame = game;
        }
        public override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            boutonFermerBoutique = new Rectangle(20, 20, 70, 70);
            boutonAvatar = new Rectangle(0, 0, 50, 50);

            var quitterBouton = new Bouton(Content.Load<Texture2D>("Controls/ButtonClose"), Content.Load<SpriteFont>("Fonts/Font"))
            {
                Position = new Vector2(20, 20)
            };

            var boutiqueBouton = new Bouton(Content.Load<Texture2D>("Controls/ButtonShopTest"), Content.Load<SpriteFont>("Fonts/Font"))
            {
                Position = new Vector2(50, 50)
            };

            _gameComponents = new List<Composantes>()
            { 
                quitterBouton,
                boutiqueBouton,
            };

            _textureBackgroundMenu = Content.Load<Texture2D>("backgroundMenu");

            base.LoadContent();
        }
        public override void Update(GameTime gameTime)
        {
            MouseState _mouseState = Mouse.GetState();
            if (_mouseState.LeftButton == ButtonState.Pressed)
            {
                Console.WriteLine(Mouse.GetState().X + "," + Mouse.GetState().Y);
                if (boutonFermerBoutique.Contains(Mouse.GetState().X, Mouse.GetState().Y))
                { _myGame.Etat = Game1.Etats.FermerBoutique; }

                else if (boutonAvatar.Contains(Mouse.GetState().X, Mouse.GetState().Y))
                { _myGame.Etat = Game1.Etats.FermerBoutique; }
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
}*/
