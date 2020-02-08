using FantasticBattle.Controls;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace FantasticBattle.Managers
{
    public class UIManager
    {
        const float TIMER = 1;

        private readonly ContentManager _contentManager;
        private GraphicsDevice _graphicsDevice;
        private UnitsManager _unitsManager;
        private SpriteFont _defaultFont;
        private List<Button> _gameButtons = new List<Button>();
        private List<Sprite> _gameSprites = new List<Sprite>();
        private List<SpriteText> _gameSpritesTexts = new List<SpriteText>();
        private double _timer;

        public int Money;
        public int Health;
        public List<int> SelectedUnitsId;

        public UIManager(ContentManager contentManager, GraphicsDevice graphicsDevice, UnitsManager unitsManager)
        {
            _contentManager = contentManager;
            _graphicsDevice = graphicsDevice;
            _unitsManager = unitsManager;

            Money = 60;
            Health = 100;
            _defaultFont = _contentManager.Load<SpriteFont>("Fonts/Font");
            _timer = TIMER;
            SelectedUnitsId = new List<int>{0, 0, 0, 0, 0, 0, 0};

            _unitsManager.EnemyFinished += EnemyFinish;
            _unitsManager.FriendlyFinished += FriendlyFinish;
        }

        private void UnitButtonClicked(object sender, EventArgs e)
        {
            Debug.WriteLine("Clicked");

            Button buttonClicked = (Button)sender;
            string name = GameConfig.Instance.UnitsName[buttonClicked.Id];

            if (_unitsManager.UnitsInformation[name].Cost <= Money)
            {
                _unitsManager.GenerateUnit(false, new Vector2(0, 300), name);
                Money -= _unitsManager.UnitsInformation[name].Cost;
            }
        }

        private void EnemyFinish(object sender, EventArgs e)
        {
            string name = (string)sender;
            int dammage = _unitsManager.UnitsInformation[name].Dammage;
            Health -= dammage;
        }

        private void FriendlyFinish(object sender, EventArgs e)
        {
            Console.WriteLine("have finish");
        }

        #region MonoMethods
        public void Load()
        {
            for(int i = 0; i < SelectedUnitsId.Count; i++)
            {
                Button unitButton = new Button(_contentManager.Load<Texture2D>("UI/ui_button_table"), null)
                {
                    Position = new Vector2(100 + 88 * i, _graphicsDevice.Viewport.Bounds.Height - 78),
                    Id = SelectedUnitsId[i]
                };
                unitButton.Click += UnitButtonClicked;

                _gameButtons.Add(unitButton);
            }

            Sprite moneyIcon = new Sprite(_contentManager.Load<Texture2D>("UI/ui_coin"))
            {
                Position = new Vector2(20, 40)
            };
            _gameSprites.Add(moneyIcon);
            Sprite healthBar = new Sprite(_contentManager.Load<Texture2D>("UI/healthBar"))
            {
                Position = new Vector2(20, 20)
            };
            _gameSprites.Add(healthBar);
            Sprite healthGauge = new Sprite(_contentManager.Load<Texture2D>("UI/healthBarGauge"))
            {
                Position = new Vector2(20, 20)
            };
            _gameSprites.Add(healthGauge);
            SpriteText moneyFont = new SpriteText(_defaultFont)
            {
                Position = new Vector2(58, 50),
                Text = Money.ToString()
            };
            _gameSpritesTexts.Add(moneyFont);
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            _gameButtons.ForEach(x => x.Draw(gameTime, spriteBatch));
            _gameSprites.ForEach(x => x.Draw(gameTime, spriteBatch));
            _gameSpritesTexts.ForEach(x => x.Draw(gameTime, spriteBatch));
        }

        public void Update(GameTime gameTime)
        {
            _gameButtons.ForEach(x => x.Update(gameTime));
            _gameSprites.ForEach(x => x.Update(gameTime));
            _gameSpritesTexts.ForEach(x => x.Update(gameTime));

            //Money text
            _gameSpritesTexts[0].Text = Money.ToString();

            //HeathGauge
            _gameSprites[2].WidthPercent = Health;

            if (Health > 75)
                _gameSprites[2].Color = Color.Green;
            else if (Health > 40)
                _gameSprites[2].Color = Color.Orange;
            else
                _gameSprites[2].Color = Color.Red;

            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
            _timer -= elapsed;
            if (_timer < 0)
            {
                SlowUpdate(gameTime);
                _timer = TIMER;
            }
        }

        //Cette méthode est appelé toutes les TIMER secondes dans l'Update
        public void SlowUpdate(GameTime gameTime)
        {
            Money += 10;
        }
        #endregion
    }
}
