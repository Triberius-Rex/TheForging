
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
	public class LargeTwoStoryScaffoldEastAddon : BaseAddon
	{
        private static int[,] m_AddOnSimpleComponents = new int[,] {
			  {4786, 0, 1, 20}, {4785, 0, 2, 20}, {4786, 0, -1, 20}// 1	2	3	
			, {4785, 0, 0, 20}, {4785, 0, 2, 0}, {4786, 0, 1, 0}// 4	5	6	
			, {4785, 0, 0, 0}, {4786, 0, -1, 0}// 7	8	
		};

 
            
		public override BaseAddonDeed Deed
		{
			get
			{
				return new LargeTwoStoryScaffoldEastAddonDeed();
			}
		}

		[ Constructable ]
		public LargeTwoStoryScaffoldEastAddon()
		{

            for (int i = 0; i < m_AddOnSimpleComponents.Length / 4; i++)
                AddComponent( new AddonComponent( m_AddOnSimpleComponents[i,0] ), m_AddOnSimpleComponents[i,1], m_AddOnSimpleComponents[i,2], m_AddOnSimpleComponents[i,3] );


		}

		public LargeTwoStoryScaffoldEastAddon( Serial serial ) : base( serial )
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

	public class LargeTwoStoryScaffoldEastAddonDeed : BaseAddonDeed
	{
		public override BaseAddon Addon
		{
			get
			{
				return new LargeTwoStoryScaffoldEastAddon();
			}
		}

		[Constructable]
		public LargeTwoStoryScaffoldEastAddonDeed()
		{
			Name = "LargeTwoStoryScaffoldEast";
		}

		public LargeTwoStoryScaffoldEastAddonDeed( Serial serial ) : base( serial )
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