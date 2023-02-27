using OceansFortune.Game.DataTypes;
using OceansFortune.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceansFortune.Game.Menus
{
    public abstract class Menu
    {
        public abstract string Title { get; }
        public abstract void Show (Handlers.TextureHandler textureHandler, SoundHandler soundHandler);
        public abstract MenusType Update();
    }
}
