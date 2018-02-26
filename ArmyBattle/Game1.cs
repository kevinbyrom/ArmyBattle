using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ArmyBattle.Utilities;


namespace ArmyBattle
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D[] sprites;
        int currSprite;
        int animFrame;
        Vector2 pos;
        Vector2 vel;
        Vector2 acc;
        float rotation;
        
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 1920;
            graphics.PreferredBackBufferHeight = 1080;
            //graphics.IsFullScreen = true;
            graphics.ApplyChanges();

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

            this.sprites = new Texture2D[2];
            this.sprites[0] = Content.Load<Texture2D>("Copter1");
            this.sprites[1] = Content.Load<Texture2D>("Copter2");
            this.currSprite = 0;
            this.animFrame = 0;

            this.pos = Vector2.Zero;
            this.vel = Vector2.Zero;
            this.acc = Vector2.Zero;
            this.rotation = 0.0f;
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


            // Move the helicopter

            this.vel.X += GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.X;
            this.vel.Y -= GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.Y;

            this.vel.X = this.vel.X * 0.90f;
            this.vel.Y = this.vel.Y * 0.90f;

            this.pos += this.vel;


            // Wrap around the screen with this logic

            if (this.pos.X > 1920 + 8)
                this.pos.X = this.pos.X % 1920;
            
            if (this.pos.X < -8)
                this.pos.X = 1920 - this.pos.X;

            if (this.pos.Y > 1080 + 16)
                this.pos.Y = this.pos.Y % 1080;

            if (this.pos.Y < -8)
                this.pos.Y = 1080 - this.pos.Y;
            

            // Rotate

            this.rotation += GamePad.GetState(PlayerIndex.One).ThumbSticks.Right.X / 4;


            // Change animation frames

            this.animFrame += 1;
            if (this.animFrame > 4)
            {
                this.animFrame = 0;
                this.currSprite += 1;
                this.currSprite = this.currSprite % 2; 
            }


            // TODO: Add your update logic here

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

            this.spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp);
            this.spriteBatch.Draw(this.sprites[this.currSprite], pos, new Rectangle(0, 0, 16, 24), Color.White, rotation, new Vector2(8, 16), 4.0f, SpriteEffects.None, 1.0f);
            this.spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
