using OceansFortune.Game;

namespace OceansFortune
{
    internal class Program
    {
        public static void Main(string[] args) => new Game.OceansFortune().Start().GetAwaiter().GetResult();
    }
}