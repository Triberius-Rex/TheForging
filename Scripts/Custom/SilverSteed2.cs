using System;
using System.Collections.Generic;
using Server.Items;
using Server.Network;
using Server.Spells;

namespace Server.Mobiles
{
	[CorpseName("a Silver Steed corpse")]
    public sealed class SilverSteed2 : BaseMount
    {
        public static SilverSteed2 Steed { get; private set; }
        public static void Initialize()
		{
			EventSink.ServerStarted += HandleServerStarted;
			EventSink.CreatureDeath += HandleCreatureDeath;
		}

		private static void HandleServerStarted()
		{
			if (Steed?.Deleted != false)
			{
				SpawnSteed();
			}
			else if(Steed.Controlled !=false)
			{
				SpawnSteed();
			}
		}

	

        private static void HandleCreatureDeath(CreatureDeathEventArgs e)
		{
			if (e.Creature == Steed)
			{			

				Steed = null;

				SpawnSteed();
			}
		}

		private static void SpawnSteed()
		{
			if (GetSpawnLoc(out var loc, out var map))
			{
				Steed?.Delete();

				Steed = new SilverSteed2();

				Steed.MoveToWorld(loc, map);
			}
		}

		private static bool GetSpawnLoc(out Point3D loc, out Map map)
		{
			loc = Point3D.Zero;
			map = Utility.RandomList(Map.Felucca, Map.Trammel, Map.Ilshenar, Map.Malas, Map.Tokuno, Map.TerMur);

			if (map == null || map == Map.Internal)
			{
				return false;
			}

			Rectangle2D bounds;

			if (map.MapID == 0 || map.MapID == 1)
			{
				bounds = new Rectangle2D(16, 16, 5120 - 32, 4096 - 32);
			}
			else if (map.MapID == 2)
			{
				bounds = new Rectangle2D(16, 16, 2304 - 32, 1600 - 32);
			}
			else if (map.MapID == 4)
			{
				bounds = new Rectangle2D(16, 16, 1448 - 32, 1448 - 32);
			}
			else
			{
				bounds = new Rectangle2D(0, 0, map.Width, map.Height);
			}

			do
			{
				loc = map.GetRandomSpawnPoint(bounds);
			}
			while (Mobiles.Spawner.IsValidWater(map, loc.X, loc.Y, loc.Z) || !map.CanSpawnMobile(loc));

			return true;
		}

        private DateTime m_Delay;

		[Constructable]
        public SilverSteed2()
            : this("a silver steed")
        {
        }

        [Constructable]
        public SilverSteed2(string name)
            : base(name, 0x75, 0x3EA8, AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.4)
        {
            this.InitStats(Utility.Random(50, 30), Utility.Random(50, 30), 10);
            this.Skills[SkillName.MagicResist].Base = 25.0 + (Utility.RandomDouble() * 5.0);
            this.Skills[SkillName.Wrestling].Base = 35.0 + (Utility.RandomDouble() * 10.0);
            this.Skills[SkillName.Tactics].Base = 30.0 + (Utility.RandomDouble() * 15.0);

            this.ControlSlots = 1;
            this.Tamable = true;
            this.MinTameSkill = 103.1;
        }

        public SilverSteed2(Serial serial)
            : base(serial)
        {
        }

            public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)1);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
	}

}