using OceansFortune.Game.DataTypes;
using OceansFortune.Handlers;
using Raylib_cs;

namespace OceansFortune.Game.Entities
{
    public class Seagull : Entity
    {
        private Movement movement;
        private Position position;
        private Animation animation;

        public Seagull(Position position, Movement movement, Animation animation)
        {
            this.position = position;
            this.movement = movement;
            this.Lifetime = new Lifetime
            {
                lifetime = 50,
                spawntime = DateTimeOffset.UtcNow.ToUnixTimeSeconds(),
            };
            this.animation = animation;
        }
        public override void Draw(Player player, Animation animation)
        {
            throw new NotImplementedException();
        }
        public override void Draw(Player player)
        {
            switch (this.movement.direction)
            {
                case Direction.North:
                    this.position.y -= this.movement.speed * Raylib.GetFrameTime();
                    break;
                case Direction.South:
                    this.position.y += this.movement.speed * Raylib.GetFrameTime();
                    break;
                case Direction.East:
                    this.position.x += this.movement.speed * Raylib.GetFrameTime();
                    break;
                case Direction.West:
                    this.position.x -= this.movement.speed * Raylib.GetFrameTime();
                    break;
            }
            this.animation.Draw((int)(this.position.x - player.position.x), (int)(this.position.y - player.position.y), 1);
            this.Move();
        }

        public void Move()
        {
            switch(this.movement.direction)
            {
                case Direction.North:
                    this.position.y -= this.movement.speed * Raylib.GetFrameTime();
                    break;
                case Direction.South:
                    this.position.y += this.movement.speed * Raylib.GetFrameTime();
                    break;
                case Direction.East:
                    this.position.x += this.movement.speed * Raylib.GetFrameTime();
                    break;
                case Direction.West:
                    this.position.x -= this.movement.speed * Raylib.GetFrameTime();
                    break;
            }
            this.animation.update();
        }
    }
}
