using OceansFortune.Game.DataTypes;
using OceansFortune.Game.Menus;
using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace OceansFortune.Handlers
{
    public class MenuHandler
    {
        public MenusType currentMenuType = MenusType.Main;
        public Menu currentMenu;
        public MenuHandler()
        {

        }

        public void ChangeMenu(MenusType menu,[Optional] SoundHandler soundHandler, [Optional] TextureHandler textureHandler)
        {
            switch(menu)
            {
                case MenusType.Loading:
                    Raylib.BeginDrawing();
                    Raylib.ClearBackground(Color.BLACK);
                    var textLength = Raylib.MeasureText("Loading ...", 30);
                    Raylib.DrawText("Loading ...", (Raylib.GetRenderWidth() / 2) - (textLength / 2), (Raylib.GetRenderHeight() / 2) - 15, 30, Color.WHITE);
                    Raylib.EndDrawing();
                    break;
                case MenusType.Main:
                    currentMenu = new MainMenu();
                    break;
                case MenusType.Game:
                    currentMenu = new GameMenu(soundHandler, textureHandler);
                    break;
            }
        }

        public void ShowMenu(TextureHandler textureHandler, SoundHandler soundHandler)
        {
            Raylib.SetWindowTitle(currentMenu.Title);
            currentMenu.Update(textureHandler, soundHandler);
        }

        public void UpdateMenu(SoundHandler soundHandler, TextureHandler textureHandler)
        {
            var response = this.currentMenu.ChangeWindow();
            if(response != MenusType.None)
            {
                ChangeMenu(response, soundHandler, textureHandler);
            }
        }
    }
}
