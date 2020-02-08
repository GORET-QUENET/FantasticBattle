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

        protected GraphicsDevice _graphicsDevice;
        protected static Texture2D _unitTexture;
        protected int _speed;
        public event EventHandler _finish;

        public Vector2 Position;
        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, _unitTexture.Width / AmountFrames, _unitTexture.Height);
            }
        }
        public string Name;
        public int ID;
        public Unit(ContentManager contentManager, 
            GraphicsDevice graphicsDevice, 
            Vector2 position, 
            Texture2D unitTexture, 
            string name, 
            EventHandler finish, 
            int id)
        {
            _contentManager = contentManager;
            _graphicsDevice = graphicsDevice;
            Position = position;
            _unitTexture = unitTexture;
            Name = name;
            _finish += finish;
            ID = id;

            _speed = 50;
            base.Load(_unitTexture.Width, 96, 96, 5);
        }

        protected void HaveFinish()
        {
            _finish.Invoke(this, new EventArgs());
        }

        #region MonoMethods
        public void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_unitTexture, Position, base.SourceRect, Color.White);
        }
        #endregion
    }
}
