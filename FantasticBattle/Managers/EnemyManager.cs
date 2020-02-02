using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace FantasticBattle.Managers
{
    public class EnemyManager
    {
        private readonly ContentManager _contentManager;
        private GraphicsDevice _graphicsDevice;
        private UnitsManager _unitsManager;

        public EnemyManager(ContentManager contentManager, GraphicsDevice graphicsDevice, UnitsManager unitsManager)
        {
            _contentManager = contentManager;
            _graphicsDevice = graphicsDevice;
            _unitsManager = unitsManager;
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

        }
        #endregion
    }
}
