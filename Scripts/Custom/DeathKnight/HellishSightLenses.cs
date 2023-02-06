using System;

namespace Server.Items
{
public class HellishSightLenses : BaseHat
	{
//		public override int ArtifactRarity{ get{ return 11; } }

		
		
//		public override int AosStrReq{ get{ return 10; } }
//		public override int OldStrReq{ get{ return 10; } }
//		public override int InitMinHits{ get{ return 00255; } }
//		public override int InitMaxHits{ get{ return 00255; } }

		[Constructable]
		public HellishSightLenses() : base( 0x2FB8 )
		{
			Weight = 3.0;
			Name = "Hell Fire Sight Lenses";
			Hue = 1152;
			
			Attributes.DefendChance = 20;
			SkillBonuses.SetValues( 0, SkillName.MagicResist, 120.0 );
			Hue = 1161;
            LootType = LootType.Blessed;
            Layer = Layer.Earrings;
            Resistances.Fire = 40;
            Resistances.Cold = 20;
		}

        public HellishSightLenses(Serial serial)
        : base(serial)
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}

