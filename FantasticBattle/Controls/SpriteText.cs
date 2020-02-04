using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasticBattle.Controls
{
    public class SpriteText : Component
    {
        private SpriteFont _font;
        private Texture2D _texture;

        public Color PenColour { get; set; }
        public Vector2 Position { get; set; }
        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, _texture.Width, _texture.Height);
            }
        }
        public string Text { get; set; }

        public SpriteText(SpriteFont font, Texture2D texture = null)
        {
            _font = font;
            _texture = texture;
            PenColour = Color.Black;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            Color colour = Color.White;

            if(_texture != null)
            {
                spriteBatch.Draw(_texture, Rectangle, colour);

                float x = (Rectangle.X + (Rectangle.Width / 2)) - (_font.MeasureString(Text).X / 2);
                float y = (Rectangle.Y + (Rectangle.Height / 2)) - (_font.MeasureString(Text).Y / 2);

                spriteBatch.DrawString(_font, Text, new Vector2(x, y), PenColour);
            }
            else
            {
                spriteBatch.DrawString(_font, Text, Position, PenColour);
            }
                
        }

        public override void Update(GameTime gameTime)
        {

        }
    }
}
