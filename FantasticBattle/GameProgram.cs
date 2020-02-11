using FantasticBattle.Enums;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Scene.Game;
using Scene.MainMenu;
using System;

namespace FantasticBattle
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class GameProgram : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        private EGameState _State;
        private Scene_Game _scene_Game;
        private Scene_MainMenu _scene_MainMenu;

        public GameProgram()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            _scene_MainMenu = new Scene_MainMenu(ChangeState);
            _scene_Game = new Scene_Game(ChangeState);
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // Add your initialization logic here
            IsMouseVisible = true;
            _State = EGameState.MainMenu;
            _scene_MainMenu.Initialize(Content, GraphicsDevice);
            _scene_Game.Initialize(Content, GraphicsDevice);
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            _scene_MainMenu.LoadContent();
            _scene_Game.LoadContent();
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
            _scene_MainMenu.UnloadContent();
            _scene_Game.UnloadContent();
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // Add your update logic here
            if (_State == EGameState.MainMenu)
                _scene_MainMenu.Update(gameTime);
            else if (_State == EGameState.Game)
                _scene_Game.Update(gameTime);
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // Add your drawing code here
            spriteBatch.Begin();
            if(_State == EGameState.MainMenu)
                _scene_MainMenu.Draw(gameTime, spriteBatch);
            else if(_State == EGameState.Game)
                _scene_Game.Draw(gameTime, spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }

        public void ChangeState(object sender, EventArgs e)
        {
            int move = (int)sender;
            _State += move;
        }
    }
}
