using FantasticBattle.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace FantasticBattle.Managers
{
    public class UnitsManager
    {
        public List<FriendlyUnit> FriendlyUnits = new List<FriendlyUnit>();
        public List<EnemyUnit> EnemyUnits = new List<EnemyUnit>();
        public Dictionary<string, UnitInformation> UnitsInformation = new Dictionary<string, UnitInformation>();
        public event EventHandler EnemyFinished;
        public event EventHandler FriendlyFinished;

        private readonly ContentManager _contentManager;
        private GraphicsDevice _graphicsDevice;
        private EnemyUnit _enemyToRemove = null;
        private FriendlyUnit _friendlyToRemove = null;

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
                EnemyUnits.Add(new EnemyUnit(_contentManager, 
                    _graphicsDevice, 
                    position, 
                    texture2D, 
                    name, 
                    EnemyFinish,
                    EnemyUnits.Count + FriendlyUnits.Count));
            }
            else
            {
                FriendlyUnits.Add(new FriendlyUnit(_contentManager, 
                    _graphicsDevice, 
                    position, 
                    texture2D, 
                    name, 
                    FriendlyFinish,
                    EnemyUnits.Count + FriendlyUnits.Count));
            }
        }

        private void EnemyFinish(object sender, EventArgs e)
        {
            _enemyToRemove = (EnemyUnit)sender;
            EnemyFinished.Invoke(_enemyToRemove.Name, new EventArgs());
        }

        private void FriendlyFinish(object sender, EventArgs e)
        {
            _friendlyToRemove = (FriendlyUnit)sender;
            FriendlyFinished.Invoke(_friendlyToRemove.Name, new EventArgs());
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
            EnemyUnits.ForEach(x => x.Update(gameTime, EnemyUnits, FriendlyUnits));
            FriendlyUnits.ForEach(x => x.Update(gameTime, EnemyUnits, FriendlyUnits));

            if(_enemyToRemove != null)
            {
                EnemyUnits.Remove(_enemyToRemove);
                _enemyToRemove = null;
            }
            if (_friendlyToRemove != null)
            {
                FriendlyUnits.Remove(_friendlyToRemove);
                _friendlyToRemove = null;
            }
        }
        #endregion
    }
}
