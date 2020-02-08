using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace FantasticBattle.Entities
{
    public class EnemyUnit : Unit
    {
        public EnemyUnit(ContentManager contentManager,
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

            foreach(var enemy in enemyList)
            {
                if (base.Rectangle.Intersects(enemy.Rectangle) && ID != enemy.ID)
                    obstacle = true;
            }

            foreach (var friendly in friendlyList)
            {
                if (base.Rectangle.Intersects(friendly.Rectangle))
                    obstacle = true;
            }

            if (!obstacle)
                Position.X -= (float)(_speed * gameTime.ElapsedGameTime.TotalSeconds);

            if(Position.X < 0)
                HaveFinish();

            base.Update(gameTime);
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_unitTexture, Position, base.SourceRect, Color.White,0, Vector2.Zero, Vector2.One, SpriteEffects.FlipHorizontally, 0);
        }
        #endregion
    }
}
