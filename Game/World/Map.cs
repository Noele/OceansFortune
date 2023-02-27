using OceansFortune.Game.DataTypes;
using OceansFortune.Game.Entities;
using OceansFortune.Handlers;
using Raylib_cs;
using System.Numerics;
using static System.Net.Mime.MediaTypeNames;
using Image = Raylib_cs.Image;

namespace OceansFortune.Game.World
{
    public class Map
    {
        private Dimensions textureAtlasDimensions;
        private Dimensions spriteDimensions;

        private Animation seaAnimation;
        private Animation seaRockAnimation;

        private Texture2D islandTexture;
        private Image islandImage;

        private const int TILE_SCALE = 2;
        private readonly int VIEWPORT_WIDTH = Raylib.GetRenderWidth();
        private readonly int VIEWPORT_HEIGHT = Raylib.GetRenderHeight();
        public Map()
        {
            this.textureAtlasDimensions = new Dimensions { width = 112, height = 16 };
            this.spriteDimensions = new Dimensions { width = 16, height = 16 };

            this.seaAnimation = new Animation("res/sea.png", textureAtlasDimensions, 4, 7);
            this.seaRockAnimation = new Animation("res/seawithrock.png", textureAtlasDimensions, 4, 7);

            this.islandImage = Raylib.LoadImage("res/island.png");
            this.islandTexture = Raylib.LoadTextureFromImage(this.islandImage);
        }

        public Vector2 GetMouseTile(Player player)
        {
            var mousePos = Raylib.GetMousePosition();

            var spriteWidth = this.spriteDimensions.width * TILE_SCALE;
            var spriteHeight = this.spriteDimensions.height * TILE_SCALE;

            var startX = (int)Math.Floor((player.position.x) / spriteWidth);
            var startY = (int)Math.Floor((player.position.y) / spriteHeight);

            var mouseTileX = startX + (int)Math.Floor(mousePos.X / spriteWidth);
            var mouseTileY = startY + (int)Math.Floor(mousePos.Y / spriteHeight);

            return new Vector2(mouseTileX, mouseTileY); 
        }

        public void Draw(Player player, int screenWidth, int screenHeight, List<List<int>> map)
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
                    if (y >= 0 && y < map.Count && x >= 0 && x < map[y].Count)
                    {
                        var tileX = x * spriteWidth - (int)player.position.x + halfScreenWidth;
                        var tileY = y * spriteHeight - (int)player.position.y + halfScreenHeight;

                        if (tileX + spriteWidth >= player.destRect.x - VIEWPORT_WIDTH && tileX <= player.destRect.x + VIEWPORT_WIDTH &&
                            tileY + spriteHeight >= player.destRect.y - VIEWPORT_HEIGHT && tileY <= player.destRect.y + VIEWPORT_HEIGHT)
                        {
                            switch ((Tiles)map[y][x])
                            {
                                case Tiles.SEA:
                                    if(x == GetMouseTile(player).X && y == GetMouseTile(player).Y)
                                    {
                                        this.seaRockAnimation.Draw(tileX, tileY, TILE_SCALE);
                                        break; 
                                    }
                                    this.seaAnimation.Draw(tileX, tileY, TILE_SCALE); 
                                    break;

                                case Tiles.ROCK: this.seaRockAnimation.Draw(tileX, tileY, TILE_SCALE); break;

                                case Tiles.ISLANDTOPLEFT:
                                    this.seaAnimation.Draw(tileX, tileY, TILE_SCALE);
                                    Raylib.DrawTexturePro(this.islandTexture, new Rectangle(0, 0, 32, 32), new Rectangle(tileX, tileY, 32, 32), new System.Numerics.Vector2(0, 0), 0, Color.WHITE); 
                                    break;

                                case Tiles.ISLANDTOPMIDDLE:
                                     this.seaAnimation.Draw(tileX, tileY, TILE_SCALE);
                                    Raylib.DrawTexturePro(this.islandTexture, new Rectangle(32, 0, 32, 32), new Rectangle(tileX, tileY, 32, 32), new System.Numerics.Vector2(0, 0), 0, Color.WHITE); 
                                    break;

                                case Tiles.ISLANDTOPRIGHT:
                                    this.seaAnimation.Draw(tileX, tileY, TILE_SCALE);
                                    Raylib.DrawTexturePro(this.islandTexture, new Rectangle(64, 0, 32, 32), new Rectangle(tileX, tileY, 32, 32), new System.Numerics.Vector2(0, 0), 0, Color.WHITE); 
                                    break;

                                case Tiles.ISLANDMIDDLELEFT:
                                    this.seaAnimation.Draw(tileX, tileY, TILE_SCALE);
                                    Raylib.DrawTexturePro(this.islandTexture, new Rectangle(0, 32, 32, 32), new Rectangle(tileX, tileY, 32, 32), new System.Numerics.Vector2(0, 0), 0, Color.WHITE); 
                                    break;

                                case Tiles.ISLANDMIDDLE:
                                 this.seaAnimation.Draw(tileX, tileY, TILE_SCALE);
                                    Raylib.DrawTexturePro(this.islandTexture, new Rectangle(32, 32, 32, 32), new Rectangle(tileX, tileY, 32, 32), new System.Numerics.Vector2(0, 0), 0, Color.WHITE);
                                    break;

                                case Tiles.ISLANDMIDDLERIGHT:
                              this.seaAnimation.Draw(tileX, tileY, TILE_SCALE);
                                    Raylib.DrawTexturePro(this.islandTexture, new Rectangle(64, 32, 32, 32), new Rectangle(tileX, tileY, 32, 32), new System.Numerics.Vector2(0, 0), 0, Color.WHITE); 
                                    break;

                                case Tiles.ISLANDBOTTOMLEFT:
                               this.seaAnimation.Draw(tileX, tileY, TILE_SCALE);
                                    Raylib.DrawTexturePro(this.islandTexture, new Rectangle(0, 64, 32, 32), new Rectangle(tileX, tileY, 32, 32), new System.Numerics.Vector2(0, 0), 0, Color.WHITE); 
                                    break;
                                case Tiles.ISLANDBOTTOMMIDDLE:
                            this.seaAnimation.Draw(tileX, tileY, TILE_SCALE);
                                    Raylib.DrawTexturePro(this.islandTexture, new Rectangle(32, 64, 32, 32), new Rectangle(tileX, tileY, 32, 32), new System.Numerics.Vector2(0, 0), 0, Color.WHITE); 
                                    break;

                                case Tiles.ISLANDBOTTOMRIGHT:
                          this.seaAnimation.Draw(tileX, tileY, TILE_SCALE);
                                    Raylib.DrawTexturePro(this.islandTexture, new Rectangle(64, 64, 32, 32), new Rectangle(tileX, tileY, 32, 32), new System.Numerics.Vector2(0, 0), 0, Color.WHITE); 
                                    break;
                            }
                        }
                    }
                }
            }

            this.seaAnimation.update();
            this.seaRockAnimation.update();
        }


    }
}
