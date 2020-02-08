using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace FantasticBattle.Entities
{
    public class FriendlyUnit : Unit
    {
        public FriendlyUnit(ContentManager contentManager,
                    GraphicsDevice graphicsDevice,
                    Vector2 position,
                    Texture2D unitTexture,
                    string name,
                    EventHandler finish,
                    int id)
            : base(contentManager,
                  graphicsDevice,
                  position,
                  unitTexture,
                  name,
                  finish,
                  id)
        {

        }

        #region MonoMethods
        public void Update(GameTime gameTime, List<EnemyUnit> enemyList, List<FriendlyUnit> friendlyList)
        {
            bool obstacle = false;

            foreach (var enemy in enemyList)
            {
                if (base.Rectangle.Intersects(enemy.Rectangle))
                    obstacle = true;
            }

            foreach (var friendly in friendlyList)
            {
                if (base.Rectangle.Intersects(friendly.Rectangle) && ID != friendly.ID)
                    obstacle = true;
            }

            if(!obstacle)
                Position.X += (float)(_speed * gameTime.ElapsedGameTime.TotalSeconds);

            if (Position.X > _graphicsDevice.Viewport.Bounds.Width)
                HaveFinish();
            base.Update(gameTime);
        }
        #endregion
    }
}
