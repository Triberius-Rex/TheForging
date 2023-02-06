using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
	[FlipableAttribute( 0x13B9, 0x13Ba )]
	public class UnHolysword : BaseSword
	{
        public override WeaponAbility PrimaryAbility { get { return WeaponAbility.DoubleStrike; } }
        public override WeaponAbility SecondaryAbility { get { return WeaponAbility.ArmorIgnore; } }

		public override int DefHitSound{ get{ return 0x237; } }
		public override int DefMissSound{ get{ return 0x23A; } }

		public override int InitMinHits{ get{ return 200; } }
		public override int InitMaxHits{ get{ return 255; } }

		[Constructable]
		public UnHolysword() : base( 0x13B9 )
		{
			Weight = 6.0;
            Name = "an evil blade";
            Hue = 1109;
            LootType = LootType.Blessed;
            Slayer = SlayerName.Exorcism;
            Slayer2 = SlayerName.Repond;
            Attributes.WeaponDamage = 40;
            WeaponAttributes.HitDispel = 33;
                        
		}

		public UnHolysword( Serial serial ) : base( serial )
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
