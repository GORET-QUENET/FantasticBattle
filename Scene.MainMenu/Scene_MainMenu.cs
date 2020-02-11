using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Scene.MainMenu
{
    public class Scene_MainMenu
    {
        private event EventHandler _changeState;
        public Scene_MainMenu(EventHandler changeState)
        {
            _changeState += changeState;
        }

        public void Initialize(ContentManager Content, GraphicsDevice GraphicsDevice)
        {
            _changeState.Invoke(1, null);
        }

        public void LoadContent()
        {

        }

        public void UnloadContent()
        {

        }

        public void Update(GameTime gameTime)
        {
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
        }
    }
}
