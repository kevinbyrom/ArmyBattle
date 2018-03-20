using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace ArmyBattle.Framework.Graphics
{
    public class Sprite : DrawableGameComponent
    {
        
        private Texture2D texture;

        public Texture2D Texture
        {
            get
            {
                return this.texture;
            }
            set
            {
                this.texture = value;
                calculateFrameRects();
            }
        }

        private int width;

        public int Width
        {
            get
            {
                return this.width;
            }
            set
            {
                this.width = value;
                calculateFrameRects();
            }
        }

        private int height;

        public int Height
        {
            get
            {
                return this.height;
            }
            set
            {
                this.height = value;
                calculateFrameRects();
            }
        }

        public Vector2 ScreenPos;
        public Rectangle SourceRect;
        public Color Color;
        public float Rotation;
        public Vector2 Origin;
        public float Scale;
        public SpriteEffects SpriteEffect;
        public float Layer;
        public int Frame;

        private Rectangle[] frameRects;


        public Sprite(Game game) : base(game)
        {
            this.Color = Color.White;
            this.Scale = 1.0f;
            this.Layer = 0.0f;
        }


        public Sprite(Game game, int width, int height) : this(game)
        {
            this.width = width;
            this.height = height;
        }



        public override void Draw(GameTime gameTime)
        {
            SpriteBatch spriteBatch = this.Game.Services.GetService<SpriteBatch>();

            spriteBatch.Draw(this.Texture, this.ScreenPos, this.frameRects[this.Frame], this.Color, this.Rotation, this.Origin, this.Scale, this.SpriteEffect, this.Layer);
        }


        private void calculateFrameRects()
        {
            if (this.texture == null || this.Width == 0 || this.Height == 0)
                return;
            
            var numX = this.texture.Width / this.Width;
            var numY = this.texture.Height / this.Height;

            this.frameRects = new Rectangle[numX * numY];

            for (int y = 0; y < numY; y++)
            {
                for (int x = 0; x < numX; x++)
                {
                    int idx = (y * numX) + x;

                    this.frameRects[idx] = new Rectangle(x * this.Width, y * this.Width, this.Width, this.Height);
                }
            }
        }
    }
}
