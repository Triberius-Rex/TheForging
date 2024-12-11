
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
	public class BankWallSAddon : BaseAddon
	{
        private static int[,] m_AddOnSimpleComponents = new int[,] {
			  {40936, -2, 0, 12}, {40936, -2, 0, 8}, {40936, -2, 0, 4}// 1	2	3	
			, {40936, -2, 0, 0}, {4115, 0, 0, 18}, {39960, 1, 0, 8}// 4	5	6	
			, {40936, 2, 0, 0}, {40936, 2, 0, 4}, {40936, 2, 0, 8}// 7	8	9	
			, {40936, 2, 0, 12}, {39737, -2, 0, 16}, {39737, -1, 0, 16}// 10	11	12	
			, {39737, 0, 0, 16}, {39737, 1, 0, 16}, {39737, 2, 0, 16}// 13	14	15	
			, {39960, 1, 0, 0}, {39960, -1, 0, 0}, {39960, -1, 0, 8}// 16	17	18	
			, {39960, 0, 0, 0}, {39960, 0, 0, 8}// 19	20	
		};

 
            
		public override BaseAddonDeed Deed
		{
			get
			{
				return new BankWallSAddonDeed();
			}
		}

		[ Constructable ]
		public BankWallSAddon()
		{

            for (int i = 0; i < m_AddOnSimpleComponents.Length / 4; i++)
                AddComponent( new AddonComponent( m_AddOnSimpleComponents[i,0] ), m_AddOnSimpleComponents[i,1], m_AddOnSimpleComponents[i,2], m_AddOnSimpleComponents[i,3] );


		}

		public BankWallSAddon( Serial serial ) : base( serial )
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

	public class BankWallSAddonDeed : BaseAddonDeed
	{
		public override BaseAddon Addon
		{
			get
			{
				return new BankWallSAddon();
			}
		}

		[Constructable]
		public BankWallSAddonDeed()
		{
			Name = "BankWallS";
		}

		public BankWallSAddonDeed( Serial serial ) : base( serial )
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