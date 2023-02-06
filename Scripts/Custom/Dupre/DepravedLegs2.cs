using System;
using Server.Items;

namespace Server.Items
{
	[FlipableAttribute( 0x2647, 0x2648 )]
	public class DepravedLegs2 : BaseArmor
	{
		    
		public override int BasePhysicalResistance{ get{ return 7; } }
		public override int BaseFireResistance{ get{ return 7; } }
		public override int BaseColdResistance{ get{ return 7; } }
		public override int BasePoisonResistance{ get{ return 7; } }
		public override int BaseEnergyResistance{ get{ return 7; } }

		public override int InitMinHits{ get{ return 255; } }
		public override int InitMaxHits{ get{ return 255; } }

		public override ArmorMaterialType MaterialType{ get{ return ArmorMaterialType.Plate; } }


		[Constructable]
		public DepravedLegs2() : base( 0x2647 )
        {
            Name = "Legs of the Depraved";
            Hue = 1109;
			Weight = 6.0;

			Attributes.BonusStr = 2;
			Attributes.WeaponSpeed = 3;

			Hue = 1109;
			Weight = 5.0;

			Attributes.BonusStr = 2;
			Attributes.WeaponSpeed = 5;

			LootType = LootType.Blessed;
		}

		public DepravedLegs2( Serial serial ) : base( serial )
		{
		}
		
		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}
		
		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}