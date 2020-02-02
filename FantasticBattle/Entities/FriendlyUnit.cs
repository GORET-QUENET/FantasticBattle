using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace FantasticBattle.Entities
{
    public class FriendlyUnit : Unit
    {
        public FriendlyUnit(ContentManager contentManager,
                    SpriteBatch spriteBatch,
                    Vector2 position,
                    Texture2D unitTexture)
            : base(contentManager,
                  spriteBatch,
                  position,
                  unitTexture)
        {

        }

        #region MonoMethods
        public void Update(GameTime gameTime)
        {
            _position.X += (float)(_speed * gameTime.ElapsedGameTime.TotalSeconds);

            base.Update(gameTime);
        }
        #endregion
    }
}
