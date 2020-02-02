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
        private readonly ContentManager _contentManager;
        private GraphicsDevice _graphicsDevice;
        private UnitsManager _unitsManager;
        private List<Component> _gameButtons;

        public UIManager(ContentManager contentManager, GraphicsDevice graphicsDevice, UnitsManager unitsManager)
        {
            _contentManager = contentManager;
            _graphicsDevice = graphicsDevice;
            _unitsManager = unitsManager;
        }

        private void UnitButtonClicked(object sender, EventArgs e)
        {
            Debug.WriteLine("Clicked");
            _unitsManager.GenerateUnit(false, new Vector2(0, 300), _contentManager.Load<Texture2D>("unit1"));
        }

        #region MonoMethods
        public void Load()
        {
            Button unitButton = new Button(_contentManager.Load<Texture2D>("Controls/Button"), _contentManager.Load<SpriteFont>("Fonts/Font"))
            {
                Position = new Vector2(350, 200),
                Text = "Generate Unit",
            };

            unitButton.Click += UnitButtonClicked;

            _gameButtons = new List<Component>
            {
                unitButton
            };
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            _gameButtons.ForEach(x => x.Draw(gameTime, spriteBatch));
        }

        public void Update(GameTime gameTime)
        {
            _gameButtons.ForEach(x => x.Update(gameTime));
        }
        #endregion
    }
}
