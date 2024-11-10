
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
	public class LargeOakWoodTreeAddon : BaseAddon
	{
        private static int[,] m_AddOnSimpleComponents = new int[,] {
			  {3481, 1, 1, 54}, {3278, 3, 0, 38}, {3303, 1, 0, 54}// 1	2	4	
			, {3284, 2, -1, 60}, {3477, -1, 2, 32}, {3303, 0, 1, 64}// 5	8	10	
			, {3297, 0, 0, 65}, {3284, -1, 2, 56}// 11	12	
		};

 
            
		public override BaseAddonDeed Deed
		{
			get
			{
				return new LargeOakWoodTreeAddonDeed();
			}
		}

		[ Constructable ]
		public LargeOakWoodTreeAddon()
		{

            for (int i = 0; i < m_AddOnSimpleComponents.Length / 4; i++)
                AddComponent( new AddonComponent( m_AddOnSimpleComponents[i,0] ), m_AddOnSimpleComponents[i,1], m_AddOnSimpleComponents[i,2], m_AddOnSimpleComponents[i,3] );


			AddComplexComponent( (BaseAddon) this, 3387, 1, 0, 27, 2418, -1, "", 1);// 3
			AddComplexComponent( (BaseAddon) this, 3419, 2, -2, 1, 2418, -1, "", 1);// 6
			AddComplexComponent( (BaseAddon) this, 3418, 1, -1, 0, 2418, -1, "", 1);// 7
			AddComplexComponent( (BaseAddon) this, 3388, -1, 1, 30, 2418, -1, "", 1);// 9
			AddComplexComponent( (BaseAddon) this, 3415, -2, 2, 0, 2418, -1, "", 1);// 13
			AddComplexComponent( (BaseAddon) this, 3416, -1, 1, 0, 2418, -1, "", 1);// 14
			AddComplexComponent( (BaseAddon) this, 3417, 0, 0, 0, 2418, -1, "", 1);// 15

		}

		public LargeOakWoodTreeAddon( Serial serial ) : base( serial )
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

	public class LargeOakWoodTreeAddonDeed : BaseAddonDeed
	{
		public override BaseAddon Addon
		{
			get
			{
				return new LargeOakWoodTreeAddon();
			}
		}

		[Constructable]
		public LargeOakWoodTreeAddonDeed()
		{
			Name = "LargeOakWoodTree";
		}

		public LargeOakWoodTreeAddonDeed( Serial serial ) : base( serial )
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