using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace jeux
{
    public class Game1 : Game
    {
       
        public const int hauteurP = 150;
         public const int largeurP = 50;
      

       
        private Texture2D _textureCharacterP;
        private Texture2D _texturePoint;
        private Texture2D _textureObstacleP;
        private Texture2D _textureObstacleD;
        private Texture2D _textureObstacleT;
        private Texture2D _textureObstacleQ;


        private int score;
        private int credit;
        private int vie;
        int _sensCharacter;


        private SpriteFont _police;
        

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

        }

        protected override void Initialize()
        { 
           

            _textureCharacterP = Content.Load<Texture2D>("characterP");
            _texturePoint = Content.Load<Texture2D>("Point");
            _textureObstacleP = Content.Load<Texture2D>("ObstacleP");
            _textureObstacleD = Content.Load<Texture2D>("ObstacleD");
            _textureObstacleT = Content.Load<Texture2D>("ObstacleT");
            _textureObstacleQ = Content.Load<Texture2D>("ObstacleQ");


            


            credit = 0;
            score = 0;
            vie = 3;


            _graphics.ApplyChanges();
             base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            // TODO: Add your drawing code here

            _spriteBatch.DrawString(_police, $"Score  : {score}", _positionScore, Color.White);
            _spriteBatch.DrawString(_police, $"Vie   : {vie}", _positionVie, Color.Red);
            _spriteBatch.DrawString(_police, $"Crédit  : {credit}", _positionCredit, Color.Blue);



            _spriteBatch.Begin();
            base.Draw(gameTime);


        }
    }
}