﻿using Utils.Controls;
using Scene.Game.Enums;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace Scene.Game.Entities
{
    public class Unit : AnimatedSprite
    {
        private readonly ContentManager _contentManager;
        private SpriteText _dammageToRemove = null;

        protected List<SpriteText> _dammageTakenList = new List<SpriteText>();
        protected HealthBar _healthBar;
        protected const float TIMER = 1;
        protected double _timer = 0;
        protected GraphicsDevice _graphicsDevice;
        protected static Texture2D _unitTexture;
        protected int _speed;
        protected Unit _opponent = null;

        public event EventHandler Finish;
        public event EventHandler IsDead;
        public Vector2 Position;
        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, _unitTexture.Width / AmountFrames, _unitTexture.Height);
            }
        }
        public string Name;
        public int Dammage;
        public int ID;
        public EUnitState UnitState;

        public Unit(ContentManager contentManager, 
            GraphicsDevice graphicsDevice, 
            Vector2 position, 
            Texture2D unitTexture,
            int health)
        {
            _contentManager = contentManager;
            _graphicsDevice = graphicsDevice;

            Position = position;
            _unitTexture = unitTexture;
            _healthBar = new HealthBar(contentManager, health, position, 40);

            UnitState = EUnitState.Walk;
            _speed = 50;
            base.Load(_unitTexture.Width, 96, 96, 5);
        }

        protected void HaveFinish()
        {
            Finish.Invoke(this, new EventArgs());
        }

        public void Attack(Unit opponent)
        {
            if (opponent.IsDeadByDammage(Dammage) && _healthBar.Health > 0)
                UnitState = EUnitState.Walk;
        }

        public bool IsDeadByDammage(int dammage)
        {
            _healthBar.Health -= dammage;
            Color = Color.Red;
            SpriteText dmg = new SpriteText(_contentManager.Load<SpriteFont>("Fonts/Font"))
            {
                Position = new Vector2(Position.X + Rectangle.Width / 2 - 20, Position.Y -20 ),
                Text = dammage.ToString(),
                LifeTime = 50
            };
            _dammageTakenList.Add(dmg);

            if (_healthBar.Health < 0)
            {
                IsDead.Invoke(this, new EventArgs());
                return true;
            }
            else
                return false;
        }

        #region MonoMethods
        public void Update(GameTime gameTime)
        {
            _healthBar.Position = Position;
            _healthBar.Update(gameTime);

            foreach(var dammageTaken in _dammageTakenList)
            {
                dammageTaken.Position = new Vector2(Position.X + Rectangle.Width / 2 - 20, dammageTaken.Position.Y - 0.3f);
                if (dammageTaken.LifeTime == 0)
                    _dammageToRemove = dammageTaken;
                dammageTaken.Update(gameTime);
            }

            if (_dammageToRemove != null)
                _dammageTakenList.Remove(_dammageToRemove);

            base.Update(gameTime);
        }
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            _healthBar.Draw(gameTime, spriteBatch);
            _dammageTakenList.ForEach(x => x?.Draw(gameTime, spriteBatch));
            spriteBatch.Draw(_unitTexture, Position, base.SourceRect, Color);
        }
        #endregion
    }
}
