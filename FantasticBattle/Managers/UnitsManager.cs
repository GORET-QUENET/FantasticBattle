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
        private SpriteBatch _spriteBatch;

        public UnitsManager(ContentManager contentManager, GraphicsDevice graphicsDevice, SpriteBatch spriteBatch)
        {
            _contentManager = contentManager;
            _graphicsDevice = graphicsDevice;
            _spriteBatch = spriteBatch;
        }

        #region MonoMethods
        public void Load()
        {

        }

        public void Draw(GameTime gameTime)
        {
            EnemyUnits.ForEach(x => x.Draw(gameTime));
            FriendlyUnits.ForEach(x => x.Draw(gameTime));
        }

        public void Update(GameTime gameTime)
        {
            EnemyUnits.ForEach(x => x.Update(gameTime));
            FriendlyUnits.ForEach(x => x.Update(gameTime));
        }
        #endregion

        public void GenerateUnit(bool isEnemy, Vector2 position, Texture2D unitTexture)
        {
            if(isEnemy)
            {
                EnemyUnits.Add(new EnemyUnit(_contentManager, _spriteBatch, position, unitTexture));
            }
            else
            {
                FriendlyUnits.Add(new FriendlyUnit(_contentManager, _spriteBatch, position, unitTexture));
            }
        }
    }
}
