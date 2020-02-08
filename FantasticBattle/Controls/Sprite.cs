using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FantasticBattle.Controls
{
    public class Sprite : Component
    {
        private Texture2D _texture;

        public Vector2 Position { get; set; }
        public float WidthPercent { get; set; }
        public float HeightPercent { get; set; }
        public Color Color { get; set; }
        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle(
                    (int)Position.X, 
                    (int)Position.Y,
                    (int)( _texture.Width * (WidthPercent / 100f)),
                    (int)( _texture.Height * (HeightPercent / 100f))
                );
            }
        }

        public Sprite(Texture2D texture)
        {
            _texture = texture;
            WidthPercent = 100;
            HeightPercent = 100;
            Color = Color.White;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, Rectangle, Color);
        }

        public override void Update(GameTime gameTime)
        {

        }
    }
}
