using System;
using Server;

namespace Server.Items
{
	public class AlphaPolarFur : Item
	{
		[Constructable]
		public AlphaPolarFur() : this( 1 )
		{
		}

		[Constructable]
		public AlphaPolarFur( int amount ) : base( 0x1875 )
		{
            Name = "Pristine Polar Bear Hide";
			Weight = 0.0;
			Hue = 1153;
			Stackable = true;
			Amount = amount;
		}

		public override void OnDoubleClick( Mobile m )
		{
			m.SendMessage( "A Pristine Polar Bear Hide, Brijit Will Be Wanting These. You can find her at the Last Chance Inn, In the Town of Winterhome" );
			m.PlaySound( 367 );
		}

		public AlphaPolarFur( Serial serial ) : base( serial )
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