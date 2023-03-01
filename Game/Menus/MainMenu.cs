using OceansFortune.Game.DataTypes;
using OceansFortune.Handlers;
using Raylib_cs;

namespace OceansFortune.Game.Menus
{
    public class MainMenu : Menu
    {
        public override string Title => "Main menu";

        public MainMenu()
        {

        }
        
        public override void Update(TextureHandler textureHandler, SoundHandler soundHandler)
        {
            Raylib.BeginDrawing();
            var (texture, src, dest) = textureHandler.GetMainMenuBackgroundRenderingObjects();
            Raylib.DrawTexturePro(texture, src, dest, new System.Numerics.Vector2(0, 0), 0, Color.WHITE);
            var fontsize = 30;
            var x = Raylib.MeasureText("Click to start", fontsize);
            Raylib.DrawText("Click to start", Raylib.GetRenderWidth() / 2 - (x / 2), Raylib.GetRenderHeight() / 2 - (fontsize/2), fontsize, Color.BLACK);
            Raylib.EndDrawing();
        }

        public override MenusType ChangeWindow()
        {
           if(Raylib.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT))
            {
                return MenusType.Game;
            }
            return MenusType.None;
        }
    }
}
