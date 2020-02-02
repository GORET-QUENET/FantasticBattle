using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasticBattle
{
    public class AnimatedSprite
    {
        public int FrameWidth { get; set; }
        public int FrameHeight { get; set; }
        public int Duration { get; set; }
        public Rectangle SourceRect { get; set; }
        public int AmountFrames { get; set; }
        public int CurrentFrame { get; set; }
        private int _updateTick = 0;

        public AnimatedSprite() { }
        public AnimatedSprite(int textureWidth, int frameWidth, int frameHeight, int duration)
        {
            Load(textureWidth, frameWidth, frameHeight, duration);
        }
        public void Load(int textureWidth, int frameWidth, int frameHeight, int duration)
        {
            this.FrameWidth = frameWidth;
            this.FrameHeight = frameHeight;
            this.Duration = duration;

            AmountFrames = textureWidth / this.FrameWidth;
            SourceRect = new Rectangle(CurrentFrame * this.FrameWidth, 0, this.FrameWidth, this.FrameHeight);
        }

        public void Update(GameTime gameTime)
        {
            if (_updateTick < Duration)
            {
                _updateTick++;
            }
            else
            {
                if (CurrentFrame < AmountFrames - 1)
                {
                    CurrentFrame++;
                }
                else
                {
                    CurrentFrame = 0;
                }
                SourceRect = new Rectangle(CurrentFrame * this.FrameWidth, 0, this.FrameWidth, this.FrameHeight);
                _updateTick = 0;
            }
        }
    }
}
