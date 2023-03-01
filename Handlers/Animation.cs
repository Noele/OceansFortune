using OceansFortune.Game.DataTypes;
using Raylib_cs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceansFortune.Handlers
{
    public class Animation
    {
        private int framesSpeed;
        private int frameCounter;
        private int animationFrames;
        private int currentFrame = 0;
        private bool flip;

        private Dimensions dimentions;

        private Rectangle sourceRect;
        private Rectangle destRect;
        private Texture2D texture;

        public Animation(Tuple<Texture2D, Dimensions, Rectangle> textureHandlerOutput, int framesSpeed, int animationFrames)
        {
            (this.texture, this.dimentions, this.sourceRect) = textureHandlerOutput;
            Console.WriteLine(this.texture.width);
            this.framesSpeed = framesSpeed;
            this.animationFrames = animationFrames;
            this.destRect = new Rectangle();
        }

        public Animation(Texture2D texture, Dimensions dimentions, Rectangle sourceRect, int framesSpeed, int animationFrames)
        {
            this.texture = texture;
            this.framesSpeed = framesSpeed;
            this.animationFrames = animationFrames;
            this.sourceRect = sourceRect;
            this.destRect = new Rectangle();
            this.dimentions = dimentions;
        }
        public Animation(Texture2D texture, Dimensions dimentions, Rectangle sourceRect, int framesSpeed, int animationFrames, bool flip)
        {
            this.texture = texture;
            this.framesSpeed = framesSpeed;
            this.animationFrames = animationFrames;
            this.sourceRect = sourceRect;
            this.destRect = new Rectangle();
            this.dimentions = dimentions;
            this.flip = flip;
        }

        public void Draw(int x, int y, int scale)
        {
            this.destRect.x = x;
            this.destRect.y = y;
            this.destRect.width = sourceRect.width * scale;
            this.destRect.height = sourceRect.height * scale;
            Raylib.DrawTexturePro(this.texture, sourceRect, destRect, new System.Numerics.Vector2(0, 0), 0, Color.WHITE);
        }

        public void update()
        {
            this.frameCounter++;
            if (this.frameCounter >= (60 / this.framesSpeed))
            {
                this.frameCounter = 0;
                this.currentFrame++;

                if (currentFrame >= this.animationFrames) this.currentFrame = 0;
                sourceRect.x = currentFrame * dimentions.width / animationFrames;
            }
        }
    }
}
