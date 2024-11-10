using System;
using System.Collections.Generic;
using Server;
using Server.Commands;
using Server.Items;
using Server.Mobiles;
using Server.Engines.XmlSpawner2;

namespace Server.Misc
{
    public class GenCrops
    {
        private static List<string> vegetableTypes = new List<string>
        {
            "FarmableCarrot", "FarmableCabbage", "FarmableLettuce", "FarmableOnion", "FarmablePumpkin", "FarmableCotton", "FarmableFlax", "FarmableTurnip", "FarmableWheat"
        };

        private const int NPCCount = 1;
        private static TimeSpan MinTime = TimeSpan.FromMinutes(2.5);
        private static TimeSpan MaxTime = TimeSpan.FromMinutes(10.0);
        private const int Team = 0;
        private const int HomeRange = 0;
        private const int SpawnRange = 0;
        private const bool TotalRespawn = true;

        public static void Initialize()
        {
            CommandSystem.Register("GenCrops", AccessLevel.Administrator, new CommandEventHandler(Generate_OnCommand));
        }

        [Usage("GenCrops")]
        [Description("Generates vegetable spawners on dirt tiles on all maps")]
        private static void Generate_OnCommand(CommandEventArgs e)
        {
            Parse(e.Mobile);
        }

        public static void Parse(Mobile from)
        {
            from.SendMessage("Generating vegetable spawners on dirt tiles on all maps...");

            List<Map> maps = new List<Map>
            {
                Map.Felucca,
                Map.Trammel,
                Map.Ilshenar,
                Map.Malas,
                Map.Tokuno,
                Map.TerMur
            };

            foreach (Map map in maps)
            {
                GenerateCropsOnMap(from, map);
            }

            from.SendMessage("Vegetable generation complete on all maps.");
            Console.WriteLine("Vegetable generation complete on all maps.");
        }

        public static void GenerateCropsOnMap(Mobile from, Map map)
        {
            int mapWidth = map.Width;
            int mapHeight = map.Height;
            Random random = new Random();
            int spawnerCount = 0;
            int cropIndex = 0;

            HashSet<Point2D> visited = new HashSet<Point2D>();

            for (int x = 0; x < mapWidth; x++)
            {
                for (int y = 0; y < mapHeight; y++)
                {
                    Point2D point = new Point2D(x, y);
                    if (!visited.Contains(point) && IsDirtTile(map, x, y))
                    {
                        List<Point2D> field = new List<Point2D>();
                        FindField(map, x, y, visited, field);

                        if (field.Count > 0)
                        {
                            string vegetableType = vegetableTypes[cropIndex];
                            cropIndex = (cropIndex + 1) % vegetableTypes.Count; // Move to the next crop type

                            foreach (var tile in field)
                            {
                                // 50% chance to place a spawner on this tile
                                if (random.NextDouble() < 0.5)
                                {
                                    MakeSpawner(new string[] { vegetableType }, tile.X, tile.Y, map.Tiles.GetLandTile(tile.X, tile.Y).Z, map);
                                    spawnerCount++;
                                }
                            }
                            //Display each spawned coordinate
                            /* from.SendMessage(String.Format("Field planted with {0} at starting point ({1}, {2}) on {3}", vegetableType, x, y, map.Name)); */
                        }
                    }
                }
            }

            from.SendMessage(String.Format("{0} vegetable spawners generated on {1}.", spawnerCount, map.Name));
            Console.WriteLine(String.Format("{0} vegetable spawners generated on {1}.", spawnerCount, map.Name));
        }

        private static bool IsDirtTile(Map map, int x, int y)
        {
            LandTile landTile = map.Tiles.GetLandTile(x, y);
            return landTile.ID == 0x9;
        }

        private static void FindField(Map map, int x, int y, HashSet<Point2D> visited, List<Point2D> field)
        {
            Stack<Point2D> stack = new Stack<Point2D>();
            stack.Push(new Point2D(x, y));

            while (stack.Count > 0)
            {
                Point2D point = stack.Pop();
                if (!visited.Contains(point) && IsDirtTile(map, point.X, point.Y))
                {
                    visited.Add(point);
                    field.Add(point);

                    foreach (var neighbor in GetNeighbors(point))
                    {
                        if (!visited.Contains(neighbor) && IsDirtTile(map, neighbor.X, neighbor.Y))
                        {
                            stack.Push(neighbor);
                        }
                    }
                }
            }
        }

        private static IEnumerable<Point2D> GetNeighbors(Point2D point)
        {
            yield return new Point2D(point.X + 1, point.Y);
            yield return new Point2D(point.X - 1, point.Y);
            yield return new Point2D(point.X, point.Y + 1);
            yield return new Point2D(point.X, point.Y - 1);
        }

        private static void MakeSpawner(string[] types, int x, int y, int z, Map map)
        {
            if (types.Length == 0)
                return;

            ClearSpawners(x, y, z, map);

            for (int i = 0; i < types.Length; ++i)
            {
                XmlSpawner xs = new XmlSpawner(types[i]);

                xs.MaxCount = NPCCount;
                xs.MinDelay = MinTime;
                xs.MaxDelay = MaxTime;
                xs.Team = Team;
                xs.HomeRange = HomeRange;
                xs.SpawnRange = SpawnRange;

                xs.MoveToWorld(new Point3D(x, y, z), map);

                if (TotalRespawn)
                {
                    xs.Respawn();
                    xs.BringToHome();
                }
            }
        }

        private static void ClearSpawners(int x, int y, int z, Map map)
        {
            foreach (Item item in map.GetItemsInRange(new Point3D(x, y, z), 0))
            {
                if (item is XmlSpawner)
                {
                    item.Delete();
                }
            }
        }
    }
}