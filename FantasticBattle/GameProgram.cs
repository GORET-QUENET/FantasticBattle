using FantasticBattle.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FantasticBattle
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class GameProgram : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        UIManager uiManager;
        EnemyManager enemyManager;
        UnitsManager unitsManager;

        public GameProgram()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

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

            // TODO: use this.Content to load your game content here
            unitsManager = new UnitsManager(Content, GraphicsDevice, spriteBatch);
            unitsManager.Load();
            uiManager = new UIManager(Content, GraphicsDevice, spriteBatch, unitsManager);
            uiManager.Load();
            enemyManager = new EnemyManager(Content, GraphicsDevice, spriteBatch, unitsManager);
            enemyManager.Load();
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
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

            // TODO: Add your update logic here
            enemyManager.Update(gameTime);
            uiManager.Update(gameTime);
            unitsManager.Update(gameTime);
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            enemyManager.Draw(gameTime);
            uiManager.Draw(gameTime);
            unitsManager.Draw(gameTime);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
