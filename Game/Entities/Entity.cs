using OceansFortune.Game.DataTypes;
using OceansFortune.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceansFortune.Game.Entities
{
    public abstract class Entity
    {
        public Lifetime Lifetime { get; set; }
        public Entity()
        {
            this.Lifetime = new Lifetime
            {
                lifetime = -1,
                spawntime = DateTimeOffset.UtcNow.ToUnixTimeSeconds(),
            };
        }
        public abstract void Draw(Player player, Animation animation);
        public abstract void Draw(Player player);
    }
}
