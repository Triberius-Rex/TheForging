
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
	public class TavernWallSAddon : BaseAddon
	{
        private static int[,] m_AddOnSimpleComponents = new int[,] {
			  {2451, 2, 0, 16}, {6467, 2, 0, 3}, {6467, -2, 0, 14}// 1	2	8	
			, {6467, 2, 0, 9}, {6467, -2, 0, 8}, {2450, -2, 0, 5}// 10	11	12	
					};

 
            
		public override BaseAddonDeed Deed
		{
			get
			{
				return new TavernWallSAddonDeed();
			}
		}

		[ Constructable ]
		public TavernWallSAddon()
		{

            for (int i = 0; i < m_AddOnSimpleComponents.Length / 4; i++)
                AddComponent( new AddonComponent( m_AddOnSimpleComponents[i,0] ), m_AddOnSimpleComponents[i,1], m_AddOnSimpleComponents[i,2], m_AddOnSimpleComponents[i,3] );


			AddComplexComponent( (BaseAddon) this, 2879, 2, 0, 17, 2418, -1, "", 1);// 3
			AddComplexComponent( (BaseAddon) this, 2877, -2, 0, 0, 2418, -1, "", 1);// 4
			AddComplexComponent( (BaseAddon) this, 2877, 2, 0, 0, 2418, -1, "", 1);// 5
			AddComplexComponent( (BaseAddon) this, 2879, -2, 0, 17, 2418, -1, "", 1);// 6
			AddComplexComponent( (BaseAddon) this, 2879, 2, 0, 5, 2418, -1, "", 1);// 7
			AddComplexComponent( (BaseAddon) this, 2879, -2, 0, 5, 2418, -1, "", 1);// 9
			AddComplexComponent( (BaseAddon) this, 2879, 2, 0, 11, 2418, -1, "", 1);// 13
			AddComplexComponent( (BaseAddon) this, 2861, 1, 0, 21, 2418, -1, "", 1);// 14
			AddComplexComponent( (BaseAddon) this, 2861, 0, 0, 21, 2418, -1, "", 1);// 15
			AddComplexComponent( (BaseAddon) this, 2861, -1, 0, 21, 2418, -1, "", 1);// 16
			AddComplexComponent( (BaseAddon) this, 2861, 1, 0, 13, 2418, -1, "", 1);// 17
			AddComplexComponent( (BaseAddon) this, 2861, 0, 0, 13, 2418, -1, "", 1);// 18
			AddComplexComponent( (BaseAddon) this, 2861, -1, 0, 13, 2418, -1, "", 1);// 19
			AddComplexComponent( (BaseAddon) this, 2861, 1, 0, 5, 2418, -1, "", 1);// 20
			AddComplexComponent( (BaseAddon) this, 2861, 0, 0, 5, 2418, -1, "", 1);// 21
			AddComplexComponent( (BaseAddon) this, 2861, -1, 0, 5, 2418, -1, "", 1);// 22
			AddComplexComponent( (BaseAddon) this, 40502, 1, 0, 18, 0, -1, "Ale Keg", 1);// 23
			AddComplexComponent( (BaseAddon) this, 40502, 1, 0, 10, 0, -1, "Ale Keg", 1);// 24
			AddComplexComponent( (BaseAddon) this, 40502, 0, 0, 18, 0, -1, "Ale Keg", 1);// 25
			AddComplexComponent( (BaseAddon) this, 40502, 0, 0, 10, 0, -1, "Ale Keg", 1);// 26
			AddComplexComponent( (BaseAddon) this, 40502, -1, 0, 18, 0, -1, "Ale Keg", 1);// 27
			AddComplexComponent( (BaseAddon) this, 40502, -1, 0, 10, 0, -1, "Ale Keg", 1);// 28
			AddComplexComponent( (BaseAddon) this, 40502, 1, 0, 2, 0, -1, "Ale Keg", 1);// 29
			AddComplexComponent( (BaseAddon) this, 40502, 0, 0, 2, 0, -1, "Ale Keg", 1);// 30
			AddComplexComponent( (BaseAddon) this, 40502, -1, 0, 2, 0, -1, "Ale Keg", 1);// 31
			AddComplexComponent( (BaseAddon) this, 2879, -2, 0, 11, 2418, -1, "", 1);// 32

		}

		public TavernWallSAddon( Serial serial ) : base( serial )
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

	public class TavernWallSAddonDeed : BaseAddonDeed
	{
		public override BaseAddon Addon
		{
			get
			{
				return new TavernWallSAddon();
			}
		}

		[Constructable]
		public TavernWallSAddonDeed()
		{
			Name = "TavernWallS";
		}

		public TavernWallSAddonDeed( Serial serial ) : base( serial )
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