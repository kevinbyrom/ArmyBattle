using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace ArmyBattle.Components
{
    public class SpriteComponent : DrawableGameComponent
    {
        public Texture2D Texture;
        public Vector2 ScreenPos;
        public Rectangle SourceRect;
        public Color Color;
        public float Rotation;
        public Vector2 Origin;
        public float Scale;
        public SpriteEffects SpriteEffect;
        public float Layer;


        public SpriteComponent(Game game) : base(game)
        {
            this.Color = Color.White;
            this.Scale = 1.0f;
            this.Layer = 0.0f;
        }


        public override void Draw(GameTime gameTime)
        {
            SpriteBatch spriteBatch = this.Game.Services.GetService<SpriteBatch>();

            spriteBatch.Draw(this.Texture, this.ScreenPos, this.SourceRect, this.Color, this.Rotation, this.Origin, this.Scale, this.SpriteEffect, this.Layer);
        }

    }
}
