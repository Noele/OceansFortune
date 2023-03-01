using OceansFortune.Game.DataTypes;
using OceansFortune.Game.Entities;
using OceansFortune.Handlers;
using Raylib_cs;
using System.Numerics;
using Image = Raylib_cs.Image;

namespace OceansFortune.Game.World
{
    public class Map
    {
        private List<List<int>> mapArray;
        private Animation seaRipplesAnimation;

        private TextureHandler textureHandler;

        private readonly int TILE_SCALE = 1;
        private Dimensions spriteDimensions;
        private readonly int VIEWPORT_WIDTH = Raylib.GetRenderWidth();
        private readonly int VIEWPORT_HEIGHT = Raylib.GetRenderHeight();
        public Map(TextureHandler textureHandler)
        {
            this.textureHandler = textureHandler;
            this.seaRipplesAnimation = new Animation(this.textureHandler.GetSeaRipplesRenderingObjects(), 4, 3);
            this.spriteDimensions = new Dimensions { height = 32, width = 32 };
            this.mapArray = ReadCsvFile("res/map.csv");
        }

        public void SetTile(Vector2 pos, Tiles tile)
        {
            try
            {
                this.mapArray[(int)pos.Y][(int)pos.X] = (int)tile;
            }
            catch (ArgumentOutOfRangeException ignored) { }
        }

        public Dimensions GetMapSize()
        {
            return new Dimensions() { width = this.mapArray[0].Count, height = this.mapArray.Count };
        }

        public Tiles GetTile(Vector2 pos)
        {
            return (Tiles)this.mapArray[(int)pos.Y][(int)pos.X];
        }

        public Vector2 GetMouseTile(Player player)
        {
            var mousePos = Raylib.GetMousePosition();

            var spriteWidth = this.spriteDimensions.width * this.TILE_SCALE;
            var spriteHeight = this.spriteDimensions.height * this.TILE_SCALE;

            var screenLeft = (int)Math.Floor(player.position.x - (Raylib.GetRenderWidth() / 2));
            var screenLeftTileX = (int)Math.Floor((Decimal)(screenLeft / spriteWidth));

            var screenBottom = (int)Math.Floor(player.position.y - (Raylib.GetRenderHeight() / 2));
            var screenBottomTileY = (int)Math.Floor((Decimal)(screenBottom / spriteHeight));

            var mouseTileX = screenLeftTileX + (int)Math.Floor(mousePos.X / spriteWidth);
            var mouseTileY = screenBottomTileY + (int)Math.Floor(mousePos.Y / spriteHeight);

            return new Vector2(mouseTileX, mouseTileY);
        }

        public void Draw(Player player, int screenWidth, int screenHeight)
        {
            var spriteWidth = this.spriteDimensions.width * TILE_SCALE;
            var spriteHeight = this.spriteDimensions.height * TILE_SCALE;
            var halfScreenWidth = screenWidth / 2;
            var halfScreenHeight = screenHeight / 2;

            var startX = (int)(player.position.x - halfScreenWidth) / spriteWidth;
            var startY = (int)(player.position.y - halfScreenHeight) / spriteHeight;
            var endX = (int)(player.position.x + halfScreenWidth) / spriteWidth + 1;
            var endY = (int)(player.position.y + halfScreenHeight) / spriteHeight + 1;

            for (var y = startY; y < endY; y++)
            {
                for (var x = startX; x < endX; x++)
                {
                    if (y >= 0 && y <this.mapArray.Count && x >= 0 && x <this.mapArray[y].Count)
                    {
                        var tileX = x * spriteWidth - (int)player.position.x + halfScreenWidth;
                        var tileY = y * spriteHeight - (int)player.position.y + halfScreenHeight;

                        if (tileX + spriteWidth >= player.destRect.x - VIEWPORT_WIDTH && tileX <= player.destRect.x + VIEWPORT_WIDTH &&
                            tileY + spriteHeight >= player.destRect.y - VIEWPORT_HEIGHT && tileY <= player.destRect.y + VIEWPORT_HEIGHT)
                        {
                            switch ((Tiles)this.mapArray[y][x])
                            {
                                case Tiles.SEA:
                                    Raylib.DrawTexture(this.textureHandler.textureSea, tileX, tileY, Color.WHITE);
                                    break;

                                case Tiles.SEARIPPLES: 
                                    this.seaRipplesAnimation.Draw(tileX, tileY, TILE_SCALE); 
                                    break;
                            }
                        }
                    }
                }
            }

            this.seaRipplesAnimation.update();
        }
        private List<List<int>> ReadCsvFile(string filePath)
        {
            var result = new List<List<int>>();

            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                var row = new List<int>();

                string[] values = line.Split(',');

                foreach (string value in values)
                {
                    row.Add(int.Parse(value));
                }

                result.Add(row);
            }

            return result;
        }
    }
}
