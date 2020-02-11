using Scene.Game.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Scene.Game
{
    public class Scene_Game
    {
        private event EventHandler _changeState;
        private UIManager _uiManager;
        private EnemyManager _enemyManager;
        private UnitsManager _unitsManager;

        public Scene_Game(EventHandler changeState)
        {
            _changeState += changeState;
        }

        public void Initialize(ContentManager Content, GraphicsDevice GraphicsDevice)
        {
            _unitsManager = new UnitsManager(Content, GraphicsDevice);
            _uiManager = new UIManager(Content, GraphicsDevice, _unitsManager);
            _enemyManager = new EnemyManager(Content, GraphicsDevice, _unitsManager);
        }

        public void LoadContent()
        {
            _unitsManager.Load();
            _uiManager.Load();
            _enemyManager.Load();
        }

        public void UnloadContent()
        {

        }

        public void Update(GameTime gameTime)
        {
            _enemyManager.Update(gameTime);
            _uiManager.Update(gameTime);
            _unitsManager.Update(gameTime);
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            _enemyManager.Draw(gameTime, spriteBatch);
            _uiManager.Draw(gameTime, spriteBatch);
            _unitsManager.Draw(gameTime, spriteBatch);
        }
    }
}
