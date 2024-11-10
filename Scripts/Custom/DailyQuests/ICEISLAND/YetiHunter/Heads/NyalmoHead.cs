using System;
using Server;

namespace Server.Items
{
	public class NyalmoHead : Item
	{
		[Constructable]
		public NyalmoHead() : this( 1 )
		{
		}

		[Constructable]
		public NyalmoHead( int amount ) : base( 0x1545 )
		{
            Name = "the head of the Nyalmo Yeti [Quest Relic 2 of 3]";
			//Stackable = true;
			//Amount = amount;
			Weight = 0;
            Hue = 1175;
		}

		public override void OnDoubleClick( Mobile m )
		{
			m.SendMessage( "The head of the Nyalmo Yeti, Tom Biscardi at the Winterhome Inn will be very interested in this!" );
			m.PlaySound( 0x0A0 );
		}

		public NyalmoHead( Serial serial ) : base( serial )
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