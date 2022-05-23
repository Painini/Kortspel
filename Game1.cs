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
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private SQliteHandler sqlitehandler;
        private Gamestate.Gamestates currentState;
        private List<Button> buttons;
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

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            currentState = Gamestate.Gamestates.menu;
            buttons = new List<Button>();
            cardImgs = new Texture2D[52];


            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            sqlitehandler = new SQliteHandler("databastim.db");
            sqlitehandler.CreateTable();
            buttons.Add(new Button(buttonTexture ,new Vector2(500, 500)));


            //ContentLoader for all Textures

            #region
            cardImgs[0] = Content.Load<Texture2D>("ace_of_clubs");
            cardImgs[1] = Content.Load<Texture2D>("2_of_clubs");
            cardImgs[0] = Content.Load<Texture2D>("3_of_clubs");
            cardImgs[0] = Content.Load<Texture2D>("4_of_clubs");
            cardImgs[0] = Content.Load<Texture2D>("5_of_clubs");
            cardImgs[0] = Content.Load<Texture2D>("6_of_clubs");
            cardImgs[0] = Content.Load<Texture2D>("7_of_clubs");
            cardImgs[0] = Content.Load<Texture2D>("8_of_clubs");
            cardImgs[0] = Content.Load<Texture2D>("9_of_clubs");
            cardImgs[0] = Content.Load<Texture2D>("10_of_clubs");
            cardImgs[0] = Content.Load<Texture2D>("jack_of_clubs");
            cardImgs[0] = Content.Load<Texture2D>("queen_of_clubs");
            cardImgs[0] = Content.Load<Texture2D>("king_of_clubs");

            cardImgs[0] = Content.Load<Texture2D>("ace_of_spades");
            cardImgs[0] = Content.Load<Texture2D>("2_of_spades");
            cardImgs[0] = Content.Load<Texture2D>("3_of_spades");
            cardImgs[0] = Content.Load<Texture2D>("4_of_spades");
            cardImgs[0] = Content.Load<Texture2D>("5_of_spades");
            cardImgs[0] = Content.Load<Texture2D>("6_of_spades");
            cardImgs[0] = Content.Load<Texture2D>("7_of_spades");
            cardImgs[0] = Content.Load<Texture2D>("8_of_spades");
            cardImgs[0] = Content.Load<Texture2D>("9_of_spades");
            cardImgs[0] = Content.Load<Texture2D>("10_of_spades");
            cardImgs[0] = Content.Load<Texture2D>("jack_of_spades");
            cardImgs[0] = Content.Load<Texture2D>("queen_of_spades");
            cardImgs[0] = Content.Load<Texture2D>("king_of_spades");

            cardImgs[0] = Content.Load<Texture2D>("ace_of_diamonds");
            cardImgs[0] = Content.Load<Texture2D>("2_of_diamonds");
            cardImgs[0] = Content.Load<Texture2D>("3_of_diamonds");
            cardImgs[0] = Content.Load<Texture2D>("4_of_diamonds");
            cardImgs[0] = Content.Load<Texture2D>("5_of_diamonds");
            cardImgs[0] = Content.Load<Texture2D>("6_of_diamonds");
            cardImgs[0] = Content.Load<Texture2D>("7_of_diamonds");
            cardImgs[0] = Content.Load<Texture2D>("8_of_diamonds");
            cardImgs[0] = Content.Load<Texture2D>("9_of_diamonds");
            cardImgs[0] = Content.Load<Texture2D>("10_of_diamonds");
            cardImgs[0] = Content.Load<Texture2D>("jack_of_diamonds");
            cardImgs[0] = Content.Load<Texture2D>("queen_of_diamonds");
            cardImgs[0] = Content.Load<Texture2D>("king_of_diamonds");

            cardImgs[0] = Content.Load<Texture2D>("ace_of_hearts");
            cardImgs[0] = Content.Load<Texture2D>("2_of_hearts");
            cardImgs[0] = Content.Load<Texture2D>("3_of_hearts");
            cardImgs[0] = Content.Load<Texture2D>("4_of_hearts");
            cardImgs[0] = Content.Load<Texture2D>("5_of_hearts");
            cardImgs[0] = Content.Load<Texture2D>("6_of_hearts");
            cardImgs[0] = Content.Load<Texture2D>("7_of_hearts");
            eighth = Content.Load<Texture2D>("8_of_hearts");
            nineh = Content.Load<Texture2D>("9_of_hearts");
            tenh = Content.Load<Texture2D>("10_of_hearts");
            elevenh = Content.Load<Texture2D>("jack_of_hearts");
            twelveh = Content.Load<Texture2D>("queen_of_hearts");
            thirteenh = Content.Load<Texture2D>("king_of_hearts");
            #endregion
            cardBack = Content.Load<Texture2D>("card_back");
            buttonTexture = Content.Load<Texture2D>("buttoncrop");


        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            MouseReader.Update();

            if (currentState == Gamestate.Gamestates.menu)
            {

            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkGreen);

            SpriteBatchHandler();

            base.Draw(gameTime);
        }

        private void SpriteBatchHandler()
        {

        }
    }
}
