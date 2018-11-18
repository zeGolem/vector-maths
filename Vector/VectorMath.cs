using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using MonoGame.Extended.Shapes;
using System;

namespace Vector
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class VectorMaths : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Grid defaultGrid = new Grid(0, 0, 1920, 1080);
        
        public VectorMaths()
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
            graphics.PreferredBackBufferHeight = 720;
            graphics.PreferredBackBufferWidth = 1280;
            graphics.SynchronizeWithVerticalRetrace = false;
            this.IsMouseVisible = true;
            Mouse.PlatformSetCursor(MouseCursor.Hand);
            

            graphics.ApplyChanges();

            Window.TextInput += EventHandler.InputEvent;

            Camera.displayedGrid = defaultGrid;
            Camera.defaultFont = Content.Load<SpriteFont>("textfont");
            

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

            //Run inputs
            InputHandler.CheckForInputs(Keyboard.GetState(), Mouse.GetState());
            
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);


            spriteBatch.Begin();
            Camera.SetSpriteBatch(spriteBatch);
            Camera.Draw(spriteBatch);
            /*spriteBatch.DrawPoint(
                Camera.ScaleFromGrid(
                    defaultGrid.SnapPointOnGrid(
                        Mouse.GetState().X, Mouse.GetState().Y))
                , Color.Blue, 5);*/

            //PointOnGrid pointerPosition = defaultGrid.CreatePoint(Mouse.GetState().X, Mouse.GetState().Y);

            //Camera.DrawPoint(pointerPosition.X, pointerPosition.Y, Color.Blue, 5);
            
            

            spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
