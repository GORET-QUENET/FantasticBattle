using FantasticBattle.Controls;
using FantasticBattle.Enums;
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
        private List<Component> _gameButtons;
        private SpriteText _moneyFont;
        private double _timer;

        public int Money;

        public UIManager(ContentManager contentManager, GraphicsDevice graphicsDevice, UnitsManager unitsManager)
        {
            _contentManager = contentManager;
            _graphicsDevice = graphicsDevice;
            _unitsManager = unitsManager;

            Money = 60;
            _defaultFont = _contentManager.Load<SpriteFont>("Fonts/Font");
            _timer = TIMER;
        }

        private void UnitButtonClicked(object sender, EventArgs e)
        {
            Debug.WriteLine("Clicked");
            
            Button buttonClicked = (Button)sender;
            // Ici lorsque l'ont fait (Enum)0 ça retourne l'élément de l'enum d'index 0.
            // Ici le orc_simple.
            // Le .ToString("g") permet la convertion de l'enum en string.
            string name = ((Eunit)buttonClicked.Id).ToString("g");

            if (_unitsManager.UnitsInformation[name].Cost <= Money)
            {
                _unitsManager.GenerateUnit(false, new Vector2(0, 300), name);
                Money -= _unitsManager.UnitsInformation[name].Cost;
            }
        }

        #region MonoMethods
        public void Load()
        {
            Button unitButton = new Button(_contentManager.Load<Texture2D>("Controls/Button"), _defaultFont)
            {
                Position = new Vector2(350, 200),
                Text = "Generate Unit",
                Id = 0
            };
            unitButton.Click += UnitButtonClicked;

            _gameButtons = new List<Component>
            {
                unitButton
            };

            SpriteText moneyFont = new SpriteText(_defaultFont)
            {
                Position = new Vector2(20, 20),
                Text = Money.ToString()
            };
            _moneyFont = moneyFont;
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            _gameButtons.ForEach(x => x.Draw(gameTime, spriteBatch));
            _moneyFont.Draw(gameTime, spriteBatch);
        }

        public void Update(GameTime gameTime)
        {
            _gameButtons.ForEach(x => x.Update(gameTime));
            _moneyFont.Text = Money.ToString();
            _moneyFont.Update(gameTime);

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
