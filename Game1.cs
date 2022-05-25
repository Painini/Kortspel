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
        private Gamestate.Gamestates newState;
        private BlackjackHandler blackjackHandler;
        private List<Button> menuButtons;
        private List<Button> bettingButtons;
        private List<Button> playButtons;
        private List<Chip> chips;
        private Player player;
        private Dealer dealer;
        private BoundingBoxHandler bBoxHandler;
        private SpriteFont font;
        private Texture2D[] cardImgs;
        private Texture2D[] chipImgs;
        private Texture2D cardBack;
        private Texture2D buttonTexture;
        private List<TextBackground> textBgs;
        private Texture2D whiteBg;
        private CardDeck deck;
        private CardDeckHandler deckHandler;
        private int screen_width = 1240;
        private int screen_height = 800;
        bool flag;
        int clicked;
        int clearance;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        private void SpriteBatchHandler(GameTime gameTime)
        {
            if (currentState == Gamestate.Gamestates.menu)
            {
                foreach (Button b in menuButtons)
                {
                    b.Draw(sb, font);
                }
            }

            if (currentState == Gamestate.Gamestates.betting)
            {
                foreach (TextBackground txt in textBgs)
                {
                    txt.Draw(sb, font);

                }

                foreach (Chip c in chips)
                {
                    c.Draw(sb);
                }
                
                foreach (Button b in bettingButtons)
                {
                    b.Draw(sb, font);
                }
            }

            if (currentState == Gamestate.Gamestates.play)
            {
                foreach (Card c in player.GetCardsInHand())
                {
                    c.Draw(sb);
                }

                foreach (Card c in dealer.GetCardsInHand())
                {
                    c.Draw(sb);
                }

                textBgs[2].Draw(sb, font);
                textBgs[3].Draw(sb, font);

                foreach (Button b in playButtons)
                {
                    b.Draw(sb, font);
                }
            }
        }

        protected override void Initialize()
        {
            currentState = Gamestate.Gamestates.menu;


            graphics.PreferredBackBufferWidth = screen_width;
            graphics.PreferredBackBufferHeight = screen_height;
            graphics.ApplyChanges();


            sqlitehandler = new SQliteHandler("databastim.db");
            sqlitehandler.CreateTable();


            cardImgs = new Texture2D[52];
            deck = new CardDeck();
            deckHandler = new CardDeckHandler();

            chipImgs = new Texture2D[6];

            player = new Player("Tim", 20);
            dealer = new Dealer();
            bBoxHandler = new BoundingBoxHandler();
            blackjackHandler = new BlackjackHandler();

            menuButtons = new List<Button>();
            bettingButtons = new List<Button>();
            playButtons = new List<Button>();
            flag = true;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            sb = new SpriteBatch(GraphicsDevice);
            
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

            #region
            chipImgs[0] = Content.Load<Texture2D>("chip5");
            chipImgs[1] = Content.Load<Texture2D>("chip25");
            chipImgs[2] = Content.Load<Texture2D>("chip50");
            chipImgs[3] = Content.Load<Texture2D>("chip100");
            chipImgs[4] = Content.Load<Texture2D>("chip500");
            chipImgs[5] = Content.Load<Texture2D>("chip1000");
            #endregion
            cardBack = Content.Load<Texture2D>("card_back");          
            buttonTexture = Content.Load<Texture2D>("buttoncrop");
            whiteBg = Content.Load<Texture2D>("whitebg");
            font = Content.Load<SpriteFont>("font");

            textBgs = new List<TextBackground>();
            chips = new List<Chip>();

            textBgs.Add(new TextBackground(whiteBg, new Vector2(150, screen_height / 2 - whiteBg.Height), "Your Chips:" + player.GetChipAmount().ToString()));
            textBgs.Add(new TextBackground(whiteBg, new Vector2(150, screen_height / 2 + whiteBg.Height), "Bet Chips:" + blackjackHandler.GetBetChips().ToString()));

            menuButtons.Add(new Button(buttonTexture, new Vector2(520, 500), "Start Betting :)"));
            menuButtons.Add(new Button(buttonTexture, new Vector2(720, 500), "Exit :C"));
            bettingButtons.Add(new Button(buttonTexture, new Vector2(1100, screen_height / 2), "Deal Cards"));

            chips.Add(new Chip(chipImgs[0], 5, new Vector2(screen_width / 3, screen_height / 3)));
            chips.Add(new Chip(chipImgs[1], 25, new Vector2(screen_width / 2, screen_height / 3)));
            chips.Add(new Chip(chipImgs[2], 50, new Vector2(screen_width / 3 * 2, screen_height / 3)));
            chips.Add(new Chip(chipImgs[3], 100, new Vector2(screen_width / 3, screen_height / 3 * 2)));
            chips.Add(new Chip(chipImgs[4], 500, new Vector2(screen_width / 2, screen_height / 3 * 2)));
            chips.Add(new Chip(chipImgs[5], 1000, new Vector2(screen_width / 3 * 2, screen_height / 3 * 2)));

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();


            MouseReader.Update();

            foreach (TextBackground txt in textBgs)
            {
                txt.Update(player, blackjackHandler);
            }

            //foreach (Card c in deck.GetDeck())
            //{
            //    c.Update(deck.GetDeck());
            //}
            

            //BBH.CardHoverLogic(player);


            if (currentState == Gamestate.Gamestates.menu)
            {
                foreach (Button b in menuButtons)
                {
                    clicked = bBoxHandler.Click(b);
                    int index = menuButtons.IndexOf(b);

                    if (clicked == 1 && index == 0)
                    {
                        newState = Gamestate.Gamestates.betting;
                        currentState = GamestateHandler.ChangeGameState(currentState, newState);
                    }
                    if (clicked == 1 && index == 1)
                    {
                        ButtonClickHandler.Exit();
                    }
                }           
            }

            if (currentState == Gamestate.Gamestates.betting)
            {
                if (flag)
                {
                    blackjackHandler.GameStartSetup(deck, player);
                    flag = false;
                }

                foreach (Chip c in chips)
                {
                    clicked = bBoxHandler.Click(c);

                    if (clicked == 1)
                    {
                        blackjackHandler.Bet(c.GetChipValue(), player);
                    }
                    else if (clicked == 2)
                    {
                        blackjackHandler.RemoveBet(c.GetChipValue(), player);
                    }
                }

                foreach (Button b in bettingButtons)
                {
                    clicked = bBoxHandler.Click(b);

                    if (clicked == 1)
                    {
                        newState = Gamestate.Gamestates.play;
                        currentState = GamestateHandler.ChangeGameState(currentState, newState);
                    }
                }
            }

            if (currentState == Gamestate.Gamestates.play)
            {
                if (!flag)
                {
                    clearance = screen_width / 9;
                    deck = deckHandler.AssignImg(cardImgs, deck);
                    deckHandler.AssignValues(deck);
                    blackjackHandler.RoundStart(deck, player, dealer, cardBack);
                    flag = true;

                    textBgs.Add(new TextBackground(whiteBg, new Vector2(screen_width / 2 - 200, screen_height / 2), blackjackHandler.CalcPlayerSum(player).ToString()));
                    textBgs.Add(new TextBackground(whiteBg, new Vector2(screen_width / 2 + 200, screen_height / 2), blackjackHandler.CalcDealerSum(dealer).ToString()));
                    playButtons.Add(new Button(buttonTexture, new Vector2(1000, screen_height / 2 + 150), "Hit"));
                    playButtons.Add(new Button(buttonTexture, new Vector2(1000, screen_height / 2 + 250), "Stand"));

                    //See why the hell sometimes it only shows 1 card for player IGNORE FOR NOW TRY TO DO BLACKJACK LOGIC FIRST
                    foreach (Card c in player.GetCardsInHand())
                    {
                        c.SetPos(new Vector2(screen_width / 6 + clearance, screen_height / 4 * 3));
                        clearance += screen_width / 9;
                    }

                    foreach (Card c in dealer.GetCardsInHand())
                    {
                        c.SetPos(new Vector2(screen_width / 3 + clearance, screen_height / 4));
                        clearance += screen_width / 9;
                    }

                }

                foreach (Button b in playButtons)
                {
                    clicked = bBoxHandler.Click(b);

                    int index = playButtons.IndexOf(b);
                    if (clicked == 1 && index == 0)
                    {
                         bool result = blackjackHandler.PlayerHit(deck, player, dealer);

                        if (result)
                        {
                            newState = Gamestate.Gamestates.result;
                            GamestateHandler.ChangeGameState(currentState, newState);
                        }

                    }

                    if (clicked == 1 && index == 1)
                    {
                        blackjackHandler.PlayerStand(deck, dealer, player, cardBack);
                    }


                }

                

            }
            
            if (currentState == Gamestate.Gamestates.result)
            {
                blackjackHandler.ResultCalcAndChipExchange(player);
            }

            while (false)
            {
                DestroyEarthHandler.AnnihilateEarth();
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkGreen);

            sb.Begin();
            SpriteBatchHandler(gameTime);
            sb.End();

            base.Draw(gameTime);
        }

    }
}
