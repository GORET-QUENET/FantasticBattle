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
        public void Update(GameTime gameTime, EnemyUnit enemy, FriendlyUnit friendly)
        {
            bool obstacle = false;

            if (enemy != null && Rectangle.Intersects(enemy.Rectangle))
                obstacle = true;

            if (friendly != null && Rectangle.Intersects(friendly.Rectangle))
                obstacle = true;

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
