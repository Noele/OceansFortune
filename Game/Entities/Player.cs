using OceansFortune.Game.DataTypes;
using OceansFortune.Handlers;
using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace OceansFortune.Game.Entities
{
    public class Player
    {
        private Dimensions dimentions;
        public Position position;
        public Rectangle destRect;
        private Rectangle sourceRect;
        private Vector2 direction;
        private TextureHandler textureHandler;
        private Vector2 origin;
        public Player(TextureHandler textureHandler) {
            this.dimentions = new Dimensions { width = 29, height = 49 };
            this.position = new Position { x = 100, y = 100, rotation = 180 };
            this.destRect = new Rectangle((Raylib.GetRenderWidth() / 2) - this.dimentions.width / 2, (Raylib.GetRenderHeight() / 2) - this.dimentions.width / 2, this.dimentions.width + (this.dimentions.width / 2), this.dimentions.height + (this.dimentions.width / 2));
            this.sourceRect = new Rectangle(0, 0, 66, 113);
            this.origin = new Vector2(0, 0);
            this.direction = new Vector2(0, 0);
            this.textureHandler = textureHandler;
        }
        private double ConvertToRadians(double angle)
        {
            return (Math.PI / 180) * angle;
        }
        public void Move()
        {
            var delta = Raylib.GetFrameTime();

            if (Raylib.IsKeyDown(KeyboardKey.KEY_W))
            {
                this.direction.X = (float)Math.Sin(ConvertToRadians(this.position.rotation));
                this.direction.Y = (float)Math.Cos(ConvertToRadians(this.position.rotation));
                this.position.x += this.direction.X;
                this.position.y += this.direction.Y;
            }
            if (Raylib.IsKeyDown(KeyboardKey.KEY_S))
            {
                this.direction.X = (float)Math.Sin(ConvertToRadians(this.position.rotation));
                this.direction.Y = (float)Math.Cos(ConvertToRadians(this.position.rotation));
                this.position.x -= this.direction.X;
                this.position.y -= this.direction.Y;
            }
            if (Raylib.IsKeyDown(KeyboardKey.KEY_A))
            {
                this.position.rotation += 1;
            }
            if (Raylib.IsKeyDown(KeyboardKey.KEY_D))
            {
                this.position.rotation -= 1;
            }
            if(this.position.rotation > 360) { this.position.rotation = 0; }
            if (this.position.rotation < 0) { this.position.rotation = 360; }
        }

        public void Draw()
        {
            Raylib.DrawTexturePro(this.textureHandler.playerTexture, sourceRect, destRect, origin, -this.position.rotation, Color.WHITE);
        }
    }
}
