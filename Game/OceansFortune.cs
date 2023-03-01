using OceansFortune.Game.DataTypes;
using OceansFortune.Handlers;
using Raylib_cs;

namespace OceansFortune.Game
{
    public class OceansFortune
    {
        public async Task Start()
        {
            Raylib.SetConfigFlags(ConfigFlags.FLAG_VSYNC_HINT);
            Raylib.SetWindowState(ConfigFlags.FLAG_WINDOW_MAXIMIZED | ConfigFlags.FLAG_WINDOW_UNDECORATED);
            Raylib.InitWindow(Raylib.GetMonitorWidth(Raylib.GetCurrentMonitor()), Raylib.GetMonitorHeight(Raylib.GetCurrentMonitor()), "OceansFortune");
            Raylib.SetExitKey(KeyboardKey.KEY_BACKSPACE);

            var menuHandler = new MenuHandler();
            menuHandler.ChangeMenu(MenusType.Loading);

            var textureHandler = new TextureHandler();
            var soundHandler = new SoundHandler();

            menuHandler.ChangeMenu(MenusType.Main);

            while (!Raylib.WindowShouldClose())
            {
                menuHandler.ShowMenu(textureHandler, soundHandler);
                menuHandler.UpdateMenu(soundHandler, textureHandler);

            }
            Raylib.CloseWindow();

        }
    }
}
