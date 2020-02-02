using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace FantasticBattle.Entities
{
    public class EnemyUnit : Unit
    {
        public EnemyUnit(ContentManager contentManager, 
                    Vector2 position, 
                    Texture2D unitTexture) 
            : base(contentManager, 
                  position, 
                  unitTexture)
        {

        }

        #region MonoMethods
        public void Update(GameTime gameTime)
        {
            _position.X -= (float)(_speed * gameTime.ElapsedGameTime.TotalSeconds);

            base.Update(gameTime);
        }
        #endregion
    }
}
