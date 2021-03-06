﻿using Scene.Game.Enums;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Scene.Game.Entities
{
    public class FriendlyUnit : Unit
    {
        public FriendlyUnit(ContentManager contentManager,
                    GraphicsDevice graphicsDevice,
                    Vector2 position,
                    UnitInformation information)
            : base(contentManager,
                  graphicsDevice,
                  position,
                  information)
        {

        }

        #region MonoMethods
        public void Update(GameTime gameTime, EnemyUnit enemy, FriendlyUnit friendly)
        {
            if (enemy != null && Rectangle.Intersects(enemy.Rectangle))
            {
                UnitState = EUnitState.Fight;
                _opponent = enemy;
            }

            else if (friendly != null && Rectangle.Intersects(friendly.Rectangle))
                UnitState = EUnitState.Idle;

            else if (UnitState == EUnitState.Idle)
                UnitState = EUnitState.Walk;

            if (UnitState == EUnitState.Walk)
                Position.X += (float)(Speed * gameTime.ElapsedGameTime.TotalSeconds);

            if (Position.X > _graphicsDevice.Viewport.Bounds.Width)
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
        #endregion
    }
}
