using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Kortspel
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
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

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            sqlitehandler = new SQliteHandler("databastim.db");
            sqlitehandler.CreateTable();

            //ContentLoader for all Textures

            #region
            acec = Content.Load<Texture2D>("ace_of_clubs");
            twoc = Content.Load<Texture2D>("2_of_clubs");
            threec = Content.Load<Texture2D>("3_of_clubs");
            fourc = Content.Load<Texture2D>("4_of_clubs");
            fivec = Content.Load<Texture2D>("5_of_clubs");
            sixc = Content.Load<Texture2D>("6_of_clubs");
            sevenc = Content.Load<Texture2D>("7_of_clubs");
            eightc = Content.Load<Texture2D>("8_of_clubs");
            ninec = Content.Load<Texture2D>("9_of_clubs");
            tenc = Content.Load<Texture2D>("10_of_clubs");
            elevenc = Content.Load<Texture2D>("jack_of_clubs");
            twelvec = Content.Load<Texture2D>("queen_of_clubs");
            thirteenc = Content.Load<Texture2D>("king_of_clubs");

            aces = Content.Load<Texture2D>("ace_of_spades");
            twos = Content.Load<Texture2D>("2_of_spades");
            threes = Content.Load<Texture2D>("3_of_spades");
            fours = Content.Load<Texture2D>("4_of_spades");
            fives = Content.Load<Texture2D>("5_of_spades");
            sixs = Content.Load<Texture2D>("6_of_spades");
            sevens = Content.Load<Texture2D>("7_of_spades");
            eights = Content.Load<Texture2D>("8_of_spades");
            nines = Content.Load<Texture2D>("9_of_spades");
            tens = Content.Load<Texture2D>("10_of_spades");
            elevens = Content.Load<Texture2D>("jack_of_spades");
            twelves = Content.Load<Texture2D>("queen_of_spades");
            thirteens = Content.Load<Texture2D>("king_of_spades");

            aced = Content.Load<Texture2D>("ace_of_diamonds");
            twod = Content.Load<Texture2D>("2_of_diamonds");
            threed = Content.Load<Texture2D>("3_of_diamonds");
            fourd = Content.Load<Texture2D>("4_of_diamonds");
            fived = Content.Load<Texture2D>("5_of_diamonds");
            sixd = Content.Load<Texture2D>("6_of_diamonds");
            sevend = Content.Load<Texture2D>("7_of_diamonds");
            eightd = Content.Load<Texture2D>("8_of_diamonds");
            nined = Content.Load<Texture2D>("9_of_diamonds");
            tend = Content.Load<Texture2D>("10_of_diamonds");
            elevend = Content.Load<Texture2D>("jack_of_diamonds");
            twelved = Content.Load<Texture2D>("queen_of_diamonds");
            thirteend = Content.Load<Texture2D>("king_of_diamonds");

            aceh = Content.Load<Texture2D>("ace_of_hearts");
            twoh = Content.Load<Texture2D>("2_of_hearts");
            threeh = Content.Load<Texture2D>("3_of_hearts");
            fourh = Content.Load<Texture2D>("4_of_hearts");
            fiveh = Content.Load<Texture2D>("5_of_hearts");
            sixh = Content.Load<Texture2D>("6_of_hearts");
            sevenh = Content.Load<Texture2D>("7_of_hearts");
            eighth = Content.Load<Texture2D>("8_of_hearts");
            nineh = Content.Load<Texture2D>("9_of_hearts");
            tenh = Content.Load<Texture2D>("10_of_hearts");
            elevenh = Content.Load<Texture2D>("jack_of_hearts");
            twelveh = Content.Load<Texture2D>("queen_of_hearts");
            thirteenh = Content.Load<Texture2D>("king_of_hearts");

            cardBack = Content.Load<Texture2D>("card_back");
            #endregion

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
