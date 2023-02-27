using OceansFortune.Game.DataTypes;
using OceansFortune.Game.Entities;
using Raylib_cs;


namespace OceansFortune.Handlers
{
    public class EntityHandler
    {
        private long lastSeagullTime = 0;
        private long seagullSpawnRate = 15;
        private int seagullSpeed = 80;
        private SoundHandler soundHandler;
        private List<Entity> entities;
        public EntityHandler(SoundHandler soundHandler)
        {
            this.entities = new List<Entity>();
            this.soundHandler = soundHandler;
        }

        public void AddEntity(Entity entity)
        {
            this.entities.Add(entity);
        }

        public void UpdateEntites(Player player, TextureHandler textureHandler)
        {
            var time = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            entities.RemoveAll(entity => entity.Lifetime.spawntime != -1 && entity.Lifetime.spawntime + entity.Lifetime.lifetime < time);

            foreach(Entity entity in entities)
            {
                entity.Draw(player);
            }

            SpawnSeagull(player, textureHandler);
        }

        public void SpawnSeagull(Player player, TextureHandler textureHandler)
        {
            Random random = new Random();
            var time = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

            if (lastSeagullTime + seagullSpawnRate < time)
            {
                if (random.Next(10) == 0)
                {
                    var position = new Position();
                    var direction = Direction.North;

                    switch(direction = (Direction)random.Next(4))
                    {
                        case Direction.North:
                            position.x = random.Next(Raylib.GetRenderWidth()) + player.position.x;
                            position.y = Raylib.GetScreenHeight() + player.position.y;
                            break;

                        case Direction.South:
                            position.x = random.Next(Raylib.GetRenderWidth()) + player.position.x;
                            position.y = -100 + player.position.y;
                            break;

                        case Direction.East:
                            position.x = -100 + player.position.x;
                            position.y = random.Next(Raylib.GetRenderHeight()) + player.position.y;
                            break;

                        case Direction.West:
                            position.x = Raylib.GetRenderWidth() + 100 + player.position.x;
                            position.y = random.Next(Raylib.GetRenderHeight()) + player.position.y;
                            break;
                    }
                    var (texture, dimensions, textureatlaslocation) = textureHandler.GetSeagullRenderingObjects(direction);

                    AddEntity(new Seagull(position, new Movement()
                    {
                        speed = seagullSpeed,
                        direction = direction
                    },
                    new Animation(texture, dimensions, textureatlaslocation, 5, 4)));
                    soundHandler.PlaySound(Sounds.Seagull);

                }
                lastSeagullTime = time;
            }
        }
    }
}
