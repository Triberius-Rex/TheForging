using System;
using Server;

namespace Server.Items
{
	public class RangShimBomboHead : Item
	{
		[Constructable]
		public RangShimBomboHead() : this( 1 )
		{
		}

		[Constructable]
		public RangShimBomboHead( int amount ) : base( 0x1545 )
		{
            Name = "the head of the Rang Shim Bombo Yeti [Quest Relic 3 of 3]";
			//Stackable = true;
			//Amount = amount;
			Weight = 0;
            Hue = 142;
		}

		public override void OnDoubleClick( Mobile m )
		{
			m.SendMessage( "The head of the Rang Shim Bombo Yeti, Tom Biscardi at the Winterhome Inn will be very interested in this!" );
			m.PlaySound( 0x0A0 );
		}

		public RangShimBomboHead( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}