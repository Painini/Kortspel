using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Kortspel
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch sb;
        private SQliteHandler sqlitehandler;
        private Gamestate.Gamestates currentState;
        private List<Button> buttons;
        private Player player;
        private BoundingBoxHandler BBH;
        private List<Card> tempcardlist;
        #region 

        //Texture2D acec;
        //Texture2D twoc;
        //Texture2D threec;
        //Texture2D fourc;
        //Texture2D fivec;
        //Texture2D sixc;
        //Texture2D sevenc;
        //Texture2D eightc;
        //Texture2D ninec;
        //Texture2D tenc;
        //Texture2D elevenc;
        //Texture2D twelvec;
        //Texture2D thirteenc;

        //Texture2D aces;
        //Texture2D twos;
        //Texture2D threes;
        //Texture2D fours;
        //Texture2D fives;
        //Texture2D sixs;
        //Texture2D sevens;
        //Texture2D eights;
        //Texture2D nines;
        //Texture2D tens;
        //Texture2D elevens;
        //Texture2D twelves;
        //Texture2D thirteens;

        //Texture2D aced;
        //Texture2D twod;
        //Texture2D threed;
        //Texture2D fourd;
        //Texture2D fived;
        //Texture2D sixd;
        //Texture2D sevend;
        //Texture2D eightd;
        //Texture2D nined;
        //Texture2D tend;
        //Texture2D elevend;
        //Texture2D twelved;
        //Texture2D thirteend;

        //Texture2D aceh;
        //Texture2D twoh;
        //Texture2D threeh;
        //Texture2D fourh;
        //Texture2D fiveh;
        //Texture2D sixh;
        //Texture2D sevenh;
        //Texture2D eighth;
        //Texture2D nineh;
        //Texture2D tenh;
        //Texture2D elevenh;
        //Texture2D twelveh;
        //Texture2D thirteenh;

        #endregion
        Texture2D[] cardImgs;
        Texture2D cardBack;
        Texture2D buttonTexture;
        CardDeck deck;
        CardDeckHandler deckHandler;
        private int screen_width = 1240;
        private int screen_height = 800;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        private void SpriteBatchHandler()
        {
            deck.GetDeck()[1].Draw(sb);
            
        }

        protected override void Initialize()
        {
            currentState = Gamestate.Gamestates.menu;

            graphics.PreferredBackBufferWidth = screen_width;
            graphics.PreferredBackBufferHeight = screen_height;
            graphics.ApplyChanges();

            buttons = new List<Button>();
            cardImgs = new Texture2D[52];
            deck = new CardDeck();
            deckHandler = new CardDeckHandler();
            player = new Player("poop", 100);
            BBH = new BoundingBoxHandler();
            buttons = new List<Button>();

            player.SetCardsInHand(tempcardlist);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            sb = new SpriteBatch(GraphicsDevice);

            sqlitehandler = new SQliteHandler("databastim.db");
            sqlitehandler.CreateTable();
            //buttons.Add(new Button(buttonTexture ,new Vector2(500, 500)));
            buttons.Add(new Button(buttonTexture, new Vector2(500, 500)));

            //ContentLoader for all Textures
            #region
            cardImgs[0] = Content.Load<Texture2D>("ace_of_clubs");
            cardImgs[1] = Content.Load<Texture2D>("2_of_clubs");
            cardImgs[2] = Content.Load<Texture2D>("3_of_clubs");
            cardImgs[3] = Content.Load<Texture2D>("4_of_clubs");
            cardImgs[4] = Content.Load<Texture2D>("5_of_clubs");
            cardImgs[5] = Content.Load<Texture2D>("6_of_clubs");
            cardImgs[6] = Content.Load<Texture2D>("7_of_clubs");
            cardImgs[7] = Content.Load<Texture2D>("8_of_clubs");
            cardImgs[8] = Content.Load<Texture2D>("9_of_clubs");
            cardImgs[9] = Content.Load<Texture2D>("10_of_clubs");
            cardImgs[10] = Content.Load<Texture2D>("jack_of_clubs");
            cardImgs[11] = Content.Load<Texture2D>("queen_of_clubs");
            cardImgs[12] = Content.Load<Texture2D>("king_of_clubs");

            cardImgs[13] = Content.Load<Texture2D>("ace_of_spades");
            cardImgs[14] = Content.Load<Texture2D>("2_of_spades");
            cardImgs[15] = Content.Load<Texture2D>("3_of_spades");
            cardImgs[16] = Content.Load<Texture2D>("4_of_spades");
            cardImgs[17] = Content.Load<Texture2D>("5_of_spades");
            cardImgs[18] = Content.Load<Texture2D>("6_of_spades");
            cardImgs[19] = Content.Load<Texture2D>("7_of_spades");
            cardImgs[20] = Content.Load<Texture2D>("8_of_spades");
            cardImgs[21] = Content.Load<Texture2D>("9_of_spades");
            cardImgs[22] = Content.Load<Texture2D>("10_of_spades");
            cardImgs[23] = Content.Load<Texture2D>("jack_of_spades");
            cardImgs[24] = Content.Load<Texture2D>("queen_of_spades");
            cardImgs[25] = Content.Load<Texture2D>("king_of_spades");

            cardImgs[26] = Content.Load<Texture2D>("ace_of_diamonds");
            cardImgs[27] = Content.Load<Texture2D>("2_of_diamonds");
            cardImgs[28] = Content.Load<Texture2D>("3_of_diamonds");
            cardImgs[29] = Content.Load<Texture2D>("4_of_diamonds");
            cardImgs[30] = Content.Load<Texture2D>("5_of_diamonds");
            cardImgs[31] = Content.Load<Texture2D>("6_of_diamonds");
            cardImgs[32] = Content.Load<Texture2D>("7_of_diamonds");
            cardImgs[33] = Content.Load<Texture2D>("8_of_diamonds");
            cardImgs[34] = Content.Load<Texture2D>("9_of_diamonds");
            cardImgs[35] = Content.Load<Texture2D>("10_of_diamonds");
            cardImgs[36] = Content.Load<Texture2D>("jack_of_diamonds");
            cardImgs[37] = Content.Load<Texture2D>("queen_of_diamonds");
            cardImgs[38] = Content.Load<Texture2D>("king_of_diamonds");

            cardImgs[39] = Content.Load<Texture2D>("ace_of_hearts");
            cardImgs[40] = Content.Load<Texture2D>("2_of_hearts");
            cardImgs[41] = Content.Load<Texture2D>("3_of_hearts");
            cardImgs[42] = Content.Load<Texture2D>("4_of_hearts");
            cardImgs[43] = Content.Load<Texture2D>("5_of_hearts");
            cardImgs[44] = Content.Load<Texture2D>("6_of_hearts");
            cardImgs[45] = Content.Load<Texture2D>("7_of_hearts");
            cardImgs[46] = Content.Load<Texture2D>("8_of_hearts");
            cardImgs[47] = Content.Load<Texture2D>("9_of_hearts");
            cardImgs[48] = Content.Load<Texture2D>("10_of_hearts");
            cardImgs[49] = Content.Load<Texture2D>("jack_of_hearts");
            cardImgs[50] = Content.Load<Texture2D>("queen_of_hearts");
            cardImgs[51] = Content.Load<Texture2D>("king_of_hearts");
            #endregion
            cardBack = Content.Load<Texture2D>("card_back");
            buttonTexture = Content.Load<Texture2D>("buttoncrop");
            deckHandler.AssignImg(cardImgs, deck);

            

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();


            MouseReader.Update();

            BBH.CardHoverLogic(player);


            if (currentState == Gamestate.Gamestates.menu)
            {

            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkGreen);

           

            sb.Begin();
            SpriteBatchHandler();
            sb.End();

            base.Draw(gameTime);
        }

    }
}
