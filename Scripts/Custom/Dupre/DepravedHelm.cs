using System;
using Server;

namespace Server.Items
{
	public class DepravedHelm : BaseArmor
	{
		public override bool IsArtifact => true;

		public override SetItem SetID => SetItem.Depraved;
        public override int Pieces => 5;
    
		public override int BasePhysicalResistance{ get{ return 7; } }
		public override int BaseFireResistance{ get{ return 7; } }
		public override int BaseColdResistance{ get{ return 7; } }
		public override int BasePoisonResistance{ get{ return 7; } }
		public override int BaseEnergyResistance{ get{ return 7; } }

		public override int InitMinHits{ get{ return 255; } }
		public override int InitMaxHits{ get{ return 255; } }

		

		public override ArmorMaterialType MaterialType{ get{ return ArmorMaterialType.Plate; } }

		[Constructable]
		public DepravedHelm() : base( 0x140E )
		{
            Name = "Helm of the Depraved";
            Hue = 1109;
			Weight = 5.0;

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

		public DepravedHelm( Serial serial ) : base( serial )
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
				Weight = 5.0;
		}
	}
}