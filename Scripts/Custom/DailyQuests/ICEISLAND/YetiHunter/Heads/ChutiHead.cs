using System;
using Server;

namespace Server.Items
{
	public class ChutiHead : Item
	{
		[Constructable]
		public ChutiHead() : this( 1 )
		{
		}

		[Constructable]
		public ChutiHead( int amount ) : base( 0x1545 )
		{
            Name = "the head of the Chuti Yeti [Quest Relic 1 of 3]";
			//Stackable = false;
			//Amount = amount;
			Weight = 0;
            Hue = 1153;
		}

		public override void OnDoubleClick( Mobile m )
		{
			m.SendMessage( "The head of the Chuti Yeti, Tom Biscardi at the Winterhome Inn will be very interested in this!" );
			m.PlaySound( 0x0A0 );
		}

		public ChutiHead( Serial serial ) : base( serial )
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