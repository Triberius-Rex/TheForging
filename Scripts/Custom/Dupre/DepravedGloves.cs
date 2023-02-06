using System;
using Server.Items;

namespace Server.Items
{
	[FlipableAttribute( 0x2643, 0x2644 )]
	public class DepravedGloves : BaseArmor
	{
		public override bool IsArtifact => true;

		public override SetItem SetID => SetItem.Depraved;
		public override int Pieces => 5;

		public override int BasePhysicalResistance{ get{ return 3; } }
		public override int BaseFireResistance{ get{ return 3; } }
		public override int BaseColdResistance{ get{ return 3; } }
		public override int BasePoisonResistance{ get{ return 3; } }
		public override int BaseEnergyResistance{ get{ return 3; } }

		public override int InitMinHits{ get{ return 55; } }
		public override int InitMaxHits{ get{ return 75; } }

		

		public override ArmorMaterialType MaterialType{ get{ return ArmorMaterialType.Plate; } }
		
		[Constructable]
		public DepravedGloves() : base( 0x2643 )
        {
            Name = "Gloves of the Depraved";
            Hue = 1109;
			Weight = 2.0;

			Attributes.BonusStr = 2;
			Attributes.WeaponSpeed = 3;

			SetAttributes.BonusStr = 10;
			SetAttributes.WeaponSpeed = 25;
			SetAttributes.DefendChance = 15;
			SetAttributes.BonusDex = 10;
			SetAttributes.RegenHits = 5;

			SetHue = 2075;

			SetPhysicalBonus = 28;
            SetFireBonus = 28;
            SetColdBonus = 28;
            SetPoisonBonus = 28;
            SetEnergyBonus = 28;
		}

		public DepravedGloves( Serial serial ) : base( serial )
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

			if ( Weight == 1.0 )
				Weight = 2.0;
		}
	}
}