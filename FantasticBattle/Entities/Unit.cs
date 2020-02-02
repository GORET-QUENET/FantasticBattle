using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasticBattle.Entities
{
    public class Unit : AnimatedSprite
    {
        private readonly ContentManager _contentManager;
        private static Texture2D _unitTexture;

        protected Vector2 _position;
        protected int _speed = 30;
        public Unit(ContentManager contentManager, Vector2 position, Texture2D unitTexture)
        {
            _contentManager = contentManager;
            _position = position;
            _unitTexture = unitTexture;
            //TODO : Appeller le base.Load avec les bonnes hauteurs et largeurs pour animer le sprite
            base.Load(_unitTexture.Width, 32, 32, 3);
        }

        #region MonoMethods
        public void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_unitTexture, _position, Color.White);
        }
        #endregion
    }
}
