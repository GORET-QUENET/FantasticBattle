using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Scene.Game.Managers
{
    public class EnemyManager
    {
        const float TIMER = 1;

        private readonly ContentManager _contentManager;
        private GraphicsDevice _graphicsDevice;
        private UnitsManager _unitsManager;
        private double _timer;

        public int Money;
        public int Health;

        public EnemyManager(ContentManager contentManager, GraphicsDevice graphicsDevice, UnitsManager unitsManager)
        {
            _contentManager = contentManager;
            _graphicsDevice = graphicsDevice;
            _unitsManager = unitsManager;

            Money = 60;
            Health = 100;
        }
        #region MonoMethods
        public void Load()
        {

        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {

        }

        public void Update(GameTime gameTime)
        {
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

            string name = GameConfig.Instance.UnitsName[0];

            if (_unitsManager.UnitsInformation[name].Cost <= Money)
            {
                _unitsManager.GenerateUnit(true, new Vector2(_graphicsDevice.Viewport.Bounds.Width, 300), name);
                Money -= _unitsManager.UnitsInformation[name].Cost;
            }
        }
        #endregion
    }
}
