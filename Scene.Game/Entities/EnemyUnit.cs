using Scene.Game.Enums;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Scene.Game.Entities
{
    public class EnemyUnit : Unit
    {
        public EnemyUnit(ContentManager contentManager,
                    GraphicsDevice graphicsDevice,
                    Vector2 position, 
                    Texture2D unitTexture,
                    int health) 
            : base(contentManager, 
                  graphicsDevice,
                  position, 
                  unitTexture,
                  health)
        {

        }

        #region MonoMethods
        public void Update(GameTime gameTime, EnemyUnit enemy, FriendlyUnit friendly)
        {
            if (enemy != null && Rectangle.Intersects(enemy.Rectangle))
                UnitState = EUnitState.Idle;

            else if (friendly != null && Rectangle.Intersects(friendly.Rectangle))
            {
                UnitState = EUnitState.Fight;
                _opponent = friendly;
            }
            else if (UnitState == EUnitState.Idle)
                UnitState = EUnitState.Walk;

            if (UnitState == EUnitState.Walk)
                Position.X -= (float)(_speed * gameTime.ElapsedGameTime.TotalSeconds);

            if(Position.X < 0)
                HaveFinish();

            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
            _timer -= elapsed;
            if (_timer < 0)
            {
                SlowUpdate(gameTime);
                _timer = TIMER;
            }
            base.Update(gameTime);
        }

        //Cette méthode est appelé toutes les TIMER secondes dans l'Update
        public void SlowUpdate(GameTime gameTime)
        {
            if (UnitState == EUnitState.Fight)
                Attack(_opponent);            
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            _healthBar.Draw(gameTime, spriteBatch);
            _dammageTakenList.ForEach(x => x?.Draw(gameTime, spriteBatch));
            spriteBatch.Draw(_unitTexture, Position, base.SourceRect, Color, 0, Vector2.Zero, Vector2.One, SpriteEffects.FlipHorizontally, 0);
        }
        #endregion
    }
}
