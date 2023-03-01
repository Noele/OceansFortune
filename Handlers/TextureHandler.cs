using OceansFortune.Game.DataTypes;
using Raylib_cs;

namespace OceansFortune.Handlers
{
    public class TextureHandler
    {
        //Seagull
        private Dimensions textureAtlasDimensionsSeagull;
        private Texture2D textureSeagull;
        private Image imageSeagull;

        //Main Menu
        private Dimensions textureDimensionsMainMenuBackground;
        private Texture2D textureMainMenuBackground;
        private Image imageMainMenuBackground;
        private Rectangle mainMenuBackgroundSourceRectangle;
        private Rectangle mainMenuBackgroundDestinationRectangle;

        //Map
        private Image playerImage;
        public Texture2D playerTexture;

        private Dimensions textureAtlasDimensionsSeaRipples;
        private Texture2D textureSeaRipples;
        private Image imageSeaRipples;

        private Dimensions textureAtlasDimensionsSea;
        private Image imageSea;
        public Texture2D textureSea;

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

            this.playerImage = Raylib.LoadImage("res/ship.png");
            this.playerTexture = Raylib.LoadTextureFromImage(this.playerImage);

            this.textureAtlasDimensionsSeaRipples = new Dimensions { width = 96, height = 32 };
            this.imageSeaRipples = Raylib.LoadImage("res/searipples.png");
            this.textureSeaRipples = Raylib.LoadTextureFromImage(this.imageSeaRipples);

            this.textureAtlasDimensionsSea = new Dimensions { width = 32, height = 32 };
            this.imageSea = Raylib.LoadImage("res/sea.png");
            this.textureSea = Raylib.LoadTextureFromImage(this.imageSea);
        }

        public Tuple<Texture2D, Dimensions, Rectangle> GetSeaRipplesRenderingObjects()
        {

            return Tuple.Create(this.textureSeaRipples, this.textureAtlasDimensionsSeaRipples, new Rectangle(0, 0, 32, 32));
        }

        public Tuple<Texture2D, Dimensions, Rectangle> GetSeagullRenderingObjects(Direction direction)
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

            return Tuple.Create(this.textureSeagull, this.textureAtlasDimensionsSeagull, textureAtlasLocation);
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
