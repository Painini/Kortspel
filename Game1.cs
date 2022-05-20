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

        Texture2D acec;
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

        Texture2D aces;
        Texture2D twos;
        Texture2D threes;
        Texture2D fours;
        Texture2D fives;
        Texture2D sixs;
        Texture2D sevens;
        Texture2D eights;
        Texture2D nines;
        Texture2D tens;
        Texture2D elevens;
        Texture2D twelves;
        Texture2D thirteens;

        Texture2D aced;
        Texture2D twod;
        Texture2D threed;
        Texture2D fourd;
        Texture2D fived;
        Texture2D sixd;
        Texture2D sevend;
        Texture2D eightd;
        Texture2D nined;
        Texture2D tend;
        Texture2D elevend;
        Texture2D twelved;
        Texture2D thirteend;

        Texture2D aceh;
        Texture2D twoh;
        Texture2D threeh;
        Texture2D fourh;
        Texture2D fiveh;
        Texture2D sixh;
        Texture2D sevenh;
        Texture2D eighth;
        Texture2D nineh;
        Texture2D tenh;
        Texture2D elevenh;
        Texture2D twelveh;
        Texture2D thirteenh;

        Texture2D cardBack;

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

            //ContentLoader for all Textures

            #region
            acec = Content.Load<Texture2D>("ace_of_clubs.png");
            twoc = Content.Load<Texture2D>("2_of_clubs.png");
            threec = Content.Load<Texture2D>("3_of_clubs.png");
            fourc = Content.Load<Texture2D>("4_of_clubs.png");
            fivec = Content.Load<Texture2D>("5_of_clubs.png");
            sixc = Content.Load<Texture2D>("6_of_clubs.png");
            sevenc = Content.Load<Texture2D>("7_of_clubs.png");
            eightc = Content.Load<Texture2D>("8_of_clubs.png");
            ninec = Content.Load<Texture2D>("9_of_clubs.png");
            tenc = Content.Load<Texture2D>("10_of_clubs.png");
            elevenc = Content.Load<Texture2D>("jack_of_clubs.png");
            twelvec = Content.Load<Texture2D>("queen_of_clubs.png");
            thirteenc = Content.Load<Texture2D>("king_of_clubs.png");

            aces = Content.Load<Texture2D>("ace_of_spades.png");
            twos = Content.Load<Texture2D>("2_of_spades.png");
            threes = Content.Load<Texture2D>("3_of_spades.png");
            fours = Content.Load<Texture2D>("4_of_spades.png");
            fives = Content.Load<Texture2D>("5_of_spades.png");
            sixs = Content.Load<Texture2D>("6_of_spades.png");
            sevens = Content.Load<Texture2D>("7_of_spades.png");
            eights = Content.Load<Texture2D>("8_of_spades.png");
            nines = Content.Load<Texture2D>("9_of_spades.png");
            tens = Content.Load<Texture2D>("10_of_spades.png");
            elevens = Content.Load<Texture2D>("jack_of_spades.png");
            twelves = Content.Load<Texture2D>("queen_of_spades.png");
            thirteens = Content.Load<Texture2D>("king_of_spades.png");

            aced = Content.Load<Texture2D>("ace_of_diamonds.png");
            twod = Content.Load<Texture2D>("2_of_diamonds.png");
            threed = Content.Load<Texture2D>("3_of_diamonds.png");
            fourd = Content.Load<Texture2D>("4_of_diamonds.png");
            fived = Content.Load<Texture2D>("5_of_diamonds.png");
            sixd = Content.Load<Texture2D>("6_of_diamonds.png");
            sevend = Content.Load<Texture2D>("7_of_diamonds.png");
            eightd = Content.Load<Texture2D>("8_of_diamonds.png");
            nined = Content.Load<Texture2D>("9_of_diamonds.png");
            tend = Content.Load<Texture2D>("10_of_diamonds.png");
            elevend = Content.Load<Texture2D>("jack_of_diamonds.png");
            twelved = Content.Load<Texture2D>("queen_of_diamonds.png");
            thirteend = Content.Load<Texture2D>("king_of_diamonds.png");

            aceh = Content.Load<Texture2D>("ace_of_hearts.png");
            twoh = Content.Load<Texture2D>("2_of_hearts.png");
            threeh = Content.Load<Texture2D>("3_of_hearts.png");
            fourh = Content.Load<Texture2D>("4_of_hearts.png");
            fiveh = Content.Load<Texture2D>("5_of_hearts.png");
            sixh = Content.Load<Texture2D>("6_of_hearts.png");
            sevenh = Content.Load<Texture2D>("7_of_hearts.png");
            eighth = Content.Load<Texture2D>("8_of_hearts.png");
            nineh = Content.Load<Texture2D>("9_of_hearts.png");
            tenh = Content.Load<Texture2D>("10_of_hearts.png");
            elevenh = Content.Load<Texture2D>("jack_of_hearts.png");
            twelveh = Content.Load<Texture2D>("queen_of_hearts.png");
            thirteenh = Content.Load<Texture2D>("king_of_hearts.png");

            cardBack = Content.Load<Texture2D>("card_back.png");
            #endregion


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
