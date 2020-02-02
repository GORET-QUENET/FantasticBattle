using FantasticBattle.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace FantasticBattle.Managers
{
    public class UnitsManager
    {
        public List<Unit> FriendlyUnits = new List<Unit>();
        public List<Unit> EnemyUnits = new List<Unit>();

        private readonly ContentManager _contentManager;
        private GraphicsDevice _graphicsDevice;

        public UnitsManager(ContentManager contentManager, GraphicsDevice graphicsDevice)
        {
            _contentManager = contentManager;
            _graphicsDevice = graphicsDevice;
        }

        public void GenerateUnit(bool isEnemy, Vector2 position, Texture2D unitTexture)
        {
            if (isEnemy)
            {
                EnemyUnits.Add(new EnemyUnit(_contentManager, position, unitTexture));
            }
            else
            {
                FriendlyUnits.Add(new FriendlyUnit(_contentManager, position, unitTexture));
            }
        }

        #region MonoMethods
        public void Load()
        {

        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            EnemyUnits.ForEach(x => x.Draw(gameTime, spriteBatch));
            FriendlyUnits.ForEach(x => x.Draw(gameTime, spriteBatch));
        }

        public void Update(GameTime gameTime)
        {
            EnemyUnits.ForEach(x => x.Update(gameTime));
            FriendlyUnits.ForEach(x => x.Update(gameTime));
        }
        #endregion
    }
}
