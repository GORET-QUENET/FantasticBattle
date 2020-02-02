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
        private SpriteBatch _spriteBatch;
        private static Texture2D _unitTexture;

        protected Vector2 _position;
        protected int _speed = 30;
        public Unit(ContentManager contentManager, SpriteBatch spriteBatch, Vector2 position, Texture2D unitTexture)
        {
            _contentManager = contentManager;
            _spriteBatch = spriteBatch;
            _position = position;
            _unitTexture = unitTexture;
            //base.Load(_unitTexture.Width, _unitTexture.Width / 2, _unitTexture.Height, 10);
        }

        #region MonoMethods
        public void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public void Draw(GameTime gameTime)
        {
            
        }
        #endregion
    }
}
