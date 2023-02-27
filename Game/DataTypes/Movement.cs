using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceansFortune.Game.DataTypes
{
    public class Movement
    {
        public int X_Velocity { get; set; }
        public int Y_Velocity { get; set; }
        public int speed { get; set; }
        public Direction direction { get; set; }
    }
}
