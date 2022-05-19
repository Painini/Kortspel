using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Kortspel
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private CardDeck deck;
        private CardDeckHandler deckHandler;
        private SQliteHandler sqlitehandler;

        #region 

        Texture2D onec;
        Texture2D twoc;
        Texture2D threec;
        Texture2D fourc;
        Texture2D fivec;
        Texture2D sixc;
        Texture2D sevenc;
        Texture2D eightc;
        Texture2D ninec;
        Texture2D tenc;
        Texture2D elevenc;
        Texture2D twelvec;
        Texture2D thirteenc;

        Texture2D onec;
        Texture2D twoc;
        Texture2D threec;
        Texture2D fourc;
        Texture2D fivec;
        Texture2D sixc;
        Texture2D sevenc;
        Texture2D eightc;
        Texture2D ninec;
        Texture2D tenc;
        Texture2D elevenc;
        Texture2D twelvec;
        Texture2D thirteenc;

        Texture2D onec;
        Texture2D twoc;
        Texture2D threec;
        Texture2D fourc;
        Texture2D fivec;
        Texture2D sixc;
        Texture2D sevenc;
        Texture2D eightc;
        Texture2D ninec;
        Texture2D tenc;
        Texture2D elevenc;
        Texture2D twelvec;
        Texture2D thirteenc;

        Texture2D onec;
        Texture2D twoc;
        Texture2D threec;
        Texture2D fourc;
        Texture2D fivec;
        Texture2D sixc;
        Texture2D sevenc;
        Texture2D eightc;
        Texture2D ninec;
        Texture2D tenc;
        Texture2D elevenc;
        Texture2D twelvec;
        Texture2D thirteenc;



        #endregion

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            deck = new CardDeck();
            deckHandler = new CardDeckHandler();
            deckHandler.shuffleDeck(deck);
            sqlitehandler = new SQliteHandler("databastim.db");
            sqlitehandler.CreateTable();

            
            //sqlitehandler.UpdatePlayerChipAmount("500", 1);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            MouseReader.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkGreen);

            base.Draw(gameTime);
        }
    }
}
