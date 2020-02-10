using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasticBattle.Controls
{
    public class HealthBar :Component
    {
        private readonly ContentManager _contentManager;
        private Sprite _healthBar;
        private Sprite _healthGauge;
        private float _maxHealth;

        public float Health { get; set; }
        public Vector2 Position { get; set; }
        public float ScalePercent { get; set; }

        public HealthBar(ContentManager contentManager, int health, Vector2 position, float scalePercent = 100)
        {
            _contentManager = contentManager;
            Health = health;
            _maxHealth = Health;
            Position = position;
            ScalePercent = scalePercent;

            _healthBar = new Sprite(_contentManager.Load<Texture2D>("UI/healthBar"))
            {
                Position = Position,
                HeightPercent = ScalePercent,
                WidthPercent = ScalePercent
            };
            _healthGauge = new Sprite(_contentManager.Load<Texture2D>("UI/healthBarGauge"))
            {
                Position = Position,
                HeightPercent = ScalePercent,
                WidthPercent = ScalePercent
            };
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            _healthBar.Draw(gameTime, spriteBatch);
            _healthGauge.Draw(gameTime, spriteBatch);
        }

        public override void Update(GameTime gameTime)
        {
            _healthGauge.WidthPercent = (Health / _maxHealth) * ScalePercent;

            if ((Health / _maxHealth) > 0.75)
                _healthGauge.Color = Color.Green;
            else if ((Health / _maxHealth) > 0.40)
                _healthGauge.Color = Color.Orange;
            else
                _healthGauge.Color = Color.Red;

            _healthBar.Position = Position;
            _healthGauge.Position = Position;

            _healthBar.Update(gameTime);
            _healthGauge.Update(gameTime);
        }
    }
}
