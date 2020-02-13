using Utils.Controls;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Scene.Game.Managers
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
        private HealthBar _myHealthBar;
        private HealthBar _enemyHealthBar;
        private double _timer;

        public int Money;
        public List<int> SelectedUnitsId;

        public UIManager(ContentManager contentManager, GraphicsDevice graphicsDevice, UnitsManager unitsManager)
        {
            _contentManager = contentManager;
            _graphicsDevice = graphicsDevice;
            _unitsManager = unitsManager;

            Money = 60;
            _defaultFont = _contentManager.Load<SpriteFont>("Fonts/Font");
            _timer = TIMER;
            SelectedUnitsId = new List<int>{0, 0, 0, 0, 0, 0, 0};

            _unitsManager.EnemyFinished += EnemyFinish;
            _unitsManager.FriendlyFinished += FriendlyFinish;
            _unitsManager.EarnMoney += EarnMoneyByKill;
        }

        private void UnitButtonClicked(object sender, EventArgs e)
        {
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
            int dammage = (int)sender;
            _myHealthBar.Health -= dammage;
        }

        private void FriendlyFinish(object sender, EventArgs e)
        {
            int dammage = (int)sender;
            _enemyHealthBar.Health -= dammage;
        }

        private void EarnMoneyByKill(object sender, EventArgs e)
        {
            Money += (int)sender / 10;
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

            _myHealthBar = new HealthBar(_contentManager, 100, new Vector2(20, 20));
            _enemyHealthBar = new HealthBar(_contentManager, 100, new Vector2(590, 20));

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
            _myHealthBar.Draw(gameTime, spriteBatch);
            _enemyHealthBar.Draw(gameTime, spriteBatch);
        }

        public void Update(GameTime gameTime)
        {
            _gameButtons.ForEach(x => x.Update(gameTime));
            _gameSprites.ForEach(x => x.Update(gameTime));
            _gameSpritesTexts.ForEach(x => x.Update(gameTime));
            _myHealthBar.Update(gameTime);
            _enemyHealthBar.Update(gameTime);

            //Money text
            _gameSpritesTexts[0].Text = Money.ToString();

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
