using OceansFortune.Game.DataTypes;
using OceansFortune.Game.Entities;
using OceansFortune.Game.World;
using OceansFortune.Handlers;
using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace OceansFortune.Game.Menus
{
    public class GameMenu : Menu
    {
        private EntityHandler entityHandler;
        private Player player;
        private Map map;
        private List<List<int>> mapArray;
        public GameMenu(SoundHandler soundHandler)
        {
            this.mapArray = ReadCsvFile("res/map.csv");


            this.entityHandler = new EntityHandler(soundHandler);
            this.player = new Player();
            this.map = new Map();
        }

        private List<List<int>> ReadCsvFile(string filePath)
        {
            List<List<int>> result = new List<List<int>>();

            // Read the CSV file
            string[] lines = File.ReadAllLines(filePath);

            // Parse each line of the CSV file
            foreach (string line in lines)
            {
                List<int> row = new List<int>();

                // Split the line into comma-separated values
                string[] values = line.Split(',');

                // Parse each value and add it to the row
                foreach (string value in values)
                {
                    row.Add(int.Parse(value));
                }

                // Add the row to the result
                result.Add(row);
            }

            return result;
        }

        public override string Title => "Oceans Fortune";

        public override void Show(TextureHandler textureHandler, SoundHandler soundHandler)
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.BLACK);
            this.map.Draw(player, Raylib.GetScreenWidth(), Raylib.GetScreenHeight(), this.mapArray);
            this.player.Move();
            this.player.Draw();
            this.entityHandler.UpdateEntites(player, textureHandler);
            Raylib.EndDrawing();

            soundHandler.PlaySound(Sounds.Ambience);
        }

        public override MenusType Update()
        {
            return MenusType.None;
        }
    }
}