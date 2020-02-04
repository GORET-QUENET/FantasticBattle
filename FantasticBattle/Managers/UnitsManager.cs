using FantasticBattle.Entities;
using FantasticBattle.Enums;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace FantasticBattle.Managers
{
    public class UnitsManager
    {
        public List<FriendlyUnit> FriendlyUnits = new List<FriendlyUnit>();
        public List<EnemyUnit> EnemyUnits = new List<EnemyUnit>();
        public Dictionary<string, UnitInformation> UnitsInformation = new Dictionary<string, UnitInformation>();

        private readonly ContentManager _contentManager;
        private GraphicsDevice _graphicsDevice;

        public UnitsManager(ContentManager contentManager, GraphicsDevice graphicsDevice)
        {
            _contentManager = contentManager;
            _graphicsDevice = graphicsDevice;
        }

        public void GenerateUnit(bool isEnemy, Vector2 position, string name)
        {
            string path = string.Format("Units/{0}s/{1}", 
                UnitsInformation[name].Race, 
                UnitsInformation[name].Texture);
            Texture2D texture2D = _contentManager.Load<Texture2D>(path);
            if (isEnemy)
            {
                EnemyUnits.Add(new EnemyUnit(_contentManager, position, texture2D));
            }
            else
            {
                FriendlyUnits.Add(new FriendlyUnit(_contentManager, position, texture2D));
            }
        }

        #region MonoMethods
        public void Load()
        {
            string json = File.ReadAllText(@"Entities\UnitsInformation.json");
            UnitsInformation = JsonConvert.DeserializeObject<Dictionary<string, UnitInformation>>(json);
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
