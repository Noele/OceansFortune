using OceansFortune.Game.DataTypes;
using OceansFortune.Game.Entities;
using OceansFortune.Game.World;
using OceansFortune.Handlers;
using Raylib_cs;

namespace OceansFortune.Game.Menus
{
    public class GameMenu : Menu
    {
        private EntityHandler entityHandler;
        private Player player;
        private Map map;
        private SoundHandler soundHandler;
        private MapEditor mapEditor;
        public GameMenu(SoundHandler soundHandler, TextureHandler textureHandler)
        {
            this.soundHandler = soundHandler;
            this.entityHandler = new EntityHandler(soundHandler);
            this.player = new Player(textureHandler);
            this.map = new Map(textureHandler);
            this.mapEditor = new MapEditor(this.map, this.player);
        }

        public override string Title => "Oceans Fortune";

        public override void Update(TextureHandler textureHandler, SoundHandler soundHandler)
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.BLACK);
            this.map.Draw(player, Raylib.GetRenderWidth(), Raylib.GetRenderHeight());
            this.player.Move();
            this.player.Draw();
            this.mapEditor.Update();
            this.entityHandler.UpdateEntites(player, textureHandler);
            Raylib.EndDrawing();

            soundHandler.PlaySound(Sounds.Ambience);
        }

        public override MenusType ChangeWindow()
        {
            if(Raylib.IsKeyPressed(KeyboardKey.KEY_ESCAPE))
            {
                this.soundHandler.Stop();
                return MenusType.Main;
            }
            return MenusType.None;
        }
    }
}