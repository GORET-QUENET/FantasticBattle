using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using Utils.Controls;

namespace Scene.MainMenu
{
    public class Scene_MainMenu
    {
        private ContentManager _contentManager;
        private GraphicsDevice _graphicsDevice;

        private event EventHandler _changeState;

        private Button _startButton;
        private Button _optionsButton;
        private Button _exitButton;

        public Scene_MainMenu(EventHandler changeState)
        {
            _changeState += changeState;
        }

        public void Initialize(ContentManager contentManager, GraphicsDevice graphicsDevice)
        {
            _contentManager = contentManager;
            _graphicsDevice = graphicsDevice;
        }

        public void LoadContent()
        {
            _startButton = new Button(_contentManager.Load<Texture2D>("Controls/Button"), _contentManager.Load<SpriteFont>("Fonts/Font"))
            {
                Position = new Vector2(350, 150),
                Text = "Start"
            };
            _startButton.Click += StartClicked;

            _optionsButton = new Button(_contentManager.Load<Texture2D>("Controls/Button"), _contentManager.Load<SpriteFont>("Fonts/Font"))
            {
                Position = new Vector2(350, 220),
                Text = "Options"
            };
            _optionsButton.Click += OptionsClicked;

            _exitButton = new Button(_contentManager.Load<Texture2D>("Controls/Button"), _contentManager.Load<SpriteFont>("Fonts/Font"))
            {
                Position = new Vector2(350, 290),
                Text = "Exit"
            };
            _exitButton.Click += ExitClicked;
        }

        public void UnloadContent()
        {

        }

        public void Update(GameTime gameTime)
        {
            _startButton.Update(gameTime);
            _optionsButton.Update(gameTime);
            _exitButton.Update(gameTime);
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            _startButton.Draw(gameTime, spriteBatch);
            _optionsButton.Draw(gameTime, spriteBatch);
            _exitButton.Draw(gameTime, spriteBatch);
        }

        private void StartClicked(object sender, EventArgs e)
        {
            _changeState.Invoke(1, null);
        }

        private void OptionsClicked(object sender, EventArgs e)
        {
        }

        private void ExitClicked(object sender, EventArgs e)
        {
            _changeState.Invoke(-1, null);
        }
    }
}
