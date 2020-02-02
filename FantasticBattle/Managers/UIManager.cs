using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace FantasticBattle.Managers
{
    public class UIManager
    {
        private readonly ContentManager _contentManager;
        private GraphicsDevice _graphicsDevice;
        private SpriteBatch _spriteBatch;
        private UnitsManager _unitsManager;

        public UIManager(ContentManager contentManager, GraphicsDevice graphicsDevice, SpriteBatch spriteBatch, UnitsManager unitsManager)
        {
            _contentManager = contentManager;
            _graphicsDevice = graphicsDevice;
            _spriteBatch = spriteBatch;
            _unitsManager = unitsManager;
        }

        #region MonoMethods
        public void Load()
        {

        }

        public void Draw(GameTime gameTime)
        {

        }

        public void Update(GameTime gameTime)
        {

        }
        #endregion
    }
}
