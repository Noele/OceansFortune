using OceansFortune.Game.DataTypes;
using OceansFortune.Game.Entities;
using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace OceansFortune.Game.World
{
    public class MapEditor
    {
        private Map map;
        private Player player;
        private Vector2 lastMousedOverTileCoords;
        private Tiles lastMousedOverTile;
        private Tiles currentTile = Tiles.SEARIPPLES;
        private Dimensions mapSize;
        public MapEditor(Map map, Player player)
        {
            this.map = map;
            this.player = player;
            this.lastMousedOverTileCoords = new Vector2(-1, -1);
            this.lastMousedOverTile = Tiles.SEA;
            this.mapSize = this.map.GetMapSize();
        }

        public void Update()
        {
            var mouseTile = this.map.GetMouseTile(player);
            if (!(mouseTile.X > this.mapSize.width || mouseTile.Y > this.mapSize.height || mouseTile.X < 0 || mouseTile.Y < 0))
            {
                this.map.SetTile(lastMousedOverTileCoords, lastMousedOverTile);

                lastMousedOverTile = this.map.GetTile(mouseTile);
                lastMousedOverTileCoords = mouseTile;

                this.map.SetTile(this.map.GetMouseTile(player), currentTile);
            }
            this.Draw();
        }

        private void Draw()
        {
            
        }
    }
}
