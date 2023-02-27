using OceansFortune.Game.DataTypes;
using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceansFortune.Handlers
{
    public class TextureHandler
    {
        private Dimensions textureAtlasDimensionsSeagull;
        private Texture2D textureSeagull;
        private Image imageSeagull;

        private Dimensions textureDimensionsMainMenuBackground;
        private Texture2D textureMainMenuBackground;
        private Image imageMainMenuBackground;
        private Rectangle mainMenuBackgroundSourceRectangle;
        private Rectangle mainMenuBackgroundDestinationRectangle;

        public TextureHandler()
        {
            this.textureAtlasDimensionsSeagull = new Dimensions { width = 128, height = 46 };
            this.imageSeagull = Raylib.LoadImage("res/seagull.png");
            this.textureSeagull = Raylib.LoadTextureFromImage(imageSeagull);

            this.textureDimensionsMainMenuBackground = new Dimensions { width = 480, height = 216 };
            this.imageMainMenuBackground = Raylib.LoadImage("res/mainmenubackground.png");
            this.textureMainMenuBackground = Raylib.LoadTextureFromImage(imageMainMenuBackground);
            this.mainMenuBackgroundSourceRectangle = new Rectangle(0, 0, this.textureDimensionsMainMenuBackground.width, this.textureDimensionsMainMenuBackground.height);
            this.mainMenuBackgroundDestinationRectangle = new Rectangle(0, 0, Raylib.GetRenderWidth(), Raylib.GetRenderHeight());
        }

        public (Texture2D, Dimensions, Rectangle) GetSeagullRenderingObjects(Direction direction)
        {
            Rectangle textureAtlasLocation = new Rectangle(0, 0, 32, 23);
            switch(direction)
            {
                case Direction.North:
                    textureAtlasLocation.y = 0;
                    break;
                case Direction.South:
                    textureAtlasLocation.y = 23;
                    break;
                case Direction.East:
                    textureAtlasLocation.y = 46;
                    break;
                case Direction.West:
                    textureAtlasLocation.y = 69;
                    break;
            }

            return(this.textureSeagull, this.textureAtlasDimensionsSeagull, textureAtlasLocation);
        }

        public (Texture2D, Rectangle, Rectangle) GetMainMenuBackgroundRenderingObjects()
        {
            return (this.textureMainMenuBackground, this.mainMenuBackgroundSourceRectangle, mainMenuBackgroundDestinationRectangle);
        }

        public void CleanUp()
        {
            Raylib.UnloadTexture(this.textureMainMenuBackground);
            Raylib.UnloadTexture(this.textureSeagull);
            Raylib.UnloadImage(this.imageMainMenuBackground);
            Raylib.UnloadImage(this.imageSeagull);
        }
    }
}
