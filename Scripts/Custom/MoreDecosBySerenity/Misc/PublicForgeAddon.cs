
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
	public class PublicForgeAddon : BaseAddon
	{
        private static int[,] m_AddOnSimpleComponents = new int[,] {
			  {7152, 1, 4, 0}, {6584, 1, -3, 2}, {6584, -1, 3, 0}// 1	2	3	
			, {6583, 1, -3, 0}, {6583, 1, 3, 0}, {3707, 1, -4, 1}// 4	5	6	
			, {3707, -1, 4, 1}, {1304, -1, 2, 0}, {1304, -1, 1, 0}// 7	8	9	
			, {1304, -2, 1, 0}, {1304, 0, 3, 0}, {1304, -1, -4, 0}// 10	11	12	
			, {1304, 0, -3, 0}, {1313, -2, -4, 0}, {1304, -1, 0, 0}// 13	14	15	
			, {1304, -1, -1, 0}, {1304, -1, -2, 0}, {1304, -1, -3, 0}// 16	17	18	
			, {1304, -2, -3, 0}, {1304, -2, -2, 0}, {1304, -2, -1, 0}// 19	20	21	
			, {1304, -2, 0, 0}, {1313, -2, 2, 0}, {1313, -2, 3, 0}// 22	23	24	
			, {1313, 2, 3, 0}, {1313, 2, 2, 0}, {1313, 2, 1, 0}// 25	26	27	
			, {1313, 2, 0, 0}, {1313, 2, -1, 0}, {1313, 2, -2, 0}// 28	29	30	
			, {1313, 2, -3, 0}, {1313, -2, 4, 0}, {1313, 2, 4, 0}// 31	32	33	
			, {1313, 2, -4, 0}, {1304, 1, 3, 0}, {1313, 0, -4, 0}// 34	35	36	
			, {1313, 1, -4, 0}, {1304, -1, 3, 0}, {1313, -1, 4, 0}// 37	38	39	
			, {1313, 0, 4, 0}, {1313, 1, 4, 0}, {1304, 1, 2, 0}// 40	41	42	
			, {1304, 1, 1, 0}, {1304, 1, 0, 0}, {1304, 1, -1, 0}// 43	44	45	
			, {1304, 1, -2, 0}, {1304, 1, -3, 0}, {12793, 0, 1, 0}// 46	47	48	
			, {12795, 0, 2, 0}, {12793, 0, -2, 0}, {5478, 1, 3, 0}// 49	50	51	
			, {5478, 1, -3, 0}, {40683, 0, 4, 3}, {40681, 0, 4, 12}// 52	53	54	
			, {4015, -2, 4, 2}, {4015, 2, 4, 2}, {4015, 2, -4, 2}// 55	56	57	
			, {2326, 0, -3, 24}, {2326, 0, 0, 22}, {2325, 0, 1, 24}// 58	59	60	
			, {2325, 0, 3, 24}, {2326, 0, -1, 24}, {2326, 0, 3, 22}// 61	62	63	
			, {2325, 0, 2, 22}, {2325, 0, 1, 22}, {2326, 0, -1, 22}// 64	65	66	
			, {2325, 0, -2, 22}, {2326, 0, -3, 22}, {137, 0, 0, 0}// 67	68	69	
			, {137, 0, -1, 0}, {137, 0, 1, 0}, {127, 0, 2, 0}// 70	71	72	
			, {123, 0, -2, 0}, {140, 0, -3, 0}, {142, 0, 3, 0}// 73	74	75	
			, {6546, 0, 1, 0}, {6550, 0, 0, 0}, {6534, 0, -2, 0}// 76	77	79	
					};

 
            
		public override BaseAddonDeed Deed
		{
			get
			{
				return new PublicForgeAddonDeed();
			}
		}

		[ Constructable ]
		public PublicForgeAddon()
		{

            for (int i = 0; i < m_AddOnSimpleComponents.Length / 4; i++)
                AddComponent( new AddonComponent( m_AddOnSimpleComponents[i,0] ), m_AddOnSimpleComponents[i,1], m_AddOnSimpleComponents[i,2], m_AddOnSimpleComponents[i,3] );


			AddComplexComponent( (BaseAddon) this, 6538, 0, -1, 0, 0, 29, "", 1);// 78

		}

		public PublicForgeAddon( Serial serial ) : base( serial )
		{
		}

        private static void AddComplexComponent(BaseAddon addon, int item, int xoffset, int yoffset, int zoffset, int hue, int lightsource)
        {
            AddComplexComponent(addon, item, xoffset, yoffset, zoffset, hue, lightsource, null, 1);
        }

        private static void AddComplexComponent(BaseAddon addon, int item, int xoffset, int yoffset, int zoffset, int hue, int lightsource, string name, int amount)
        {
            AddonComponent ac;
            ac = new AddonComponent(item);
            if (name != null && name.Length > 0)
                ac.Name = name;
            if (hue != 0)
                ac.Hue = hue;
            if (amount > 1)
            {
                ac.Stackable = true;
                ac.Amount = amount;
            }
            if (lightsource != -1)
                ac.Light = (LightType) lightsource;
            addon.AddComponent(ac, xoffset, yoffset, zoffset);
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

	public class PublicForgeAddonDeed : BaseAddonDeed
	{
		public override BaseAddon Addon
		{
			get
			{
				return new PublicForgeAddon();
			}
		}

		[Constructable]
		public PublicForgeAddonDeed()
		{
			Name = "PublicForge";
		}

		public PublicForgeAddonDeed( Serial serial ) : base( serial )
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