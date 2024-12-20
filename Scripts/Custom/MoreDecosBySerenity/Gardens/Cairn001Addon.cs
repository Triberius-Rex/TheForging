
////////////////////////////////////////
//                                     //
//   Generated by CEO's YAAAG - Ver 2  //
// (Yet Another Arya Addon Generator)  //
//    Modified by Hammerhand for       //
//      SA & High Seas content         //
//                                     //
////////////////////////////////////////
using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class Cairn001Addon : BaseAddon
	{
        private static int[,] m_AddOnSimpleComponents = new int[,] {
			  {4972, 1, 1, 5}, {4973, 0, 1, 7}, {4970, 0, 1, 3}// 1	2	3	
			, {3270, 0, -1, 0}, {3247, 1, 0, 2}, {4973, 1, 0, 4}// 4	5	6	
			, {4971, 0, 0, 10}, {4965, 0, 0, 6}, {4964, 0, 0, 3}// 7	8	9	
			, {4963, 0, 0, 0}// 10	
		};

 
            
		public override BaseAddonDeed Deed
		{
			get
			{
				return new Cairn001AddonDeed();
			}
		}

		[ Constructable ]
		public Cairn001Addon()
		{

            for (int i = 0; i < m_AddOnSimpleComponents.Length / 4; i++)
                AddComponent( new AddonComponent( m_AddOnSimpleComponents[i,0] ), m_AddOnSimpleComponents[i,1], m_AddOnSimpleComponents[i,2], m_AddOnSimpleComponents[i,3] );


		}

		public Cairn001Addon( Serial serial ) : base( serial )
		{
		}


		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( 0 ); // Version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}

	public class Cairn001AddonDeed : BaseAddonDeed
	{
		public override BaseAddon Addon
		{
			get
			{
				return new Cairn001Addon();
			}
		}

		[Constructable]
		public Cairn001AddonDeed()
		{
			Name = "Cairn001";
		}

		public Cairn001AddonDeed( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( 0 ); // Version
		}

		public override void	Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}