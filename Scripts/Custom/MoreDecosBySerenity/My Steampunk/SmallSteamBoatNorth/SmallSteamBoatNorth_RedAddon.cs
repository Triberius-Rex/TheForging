
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
	public class SmallSteamBoatNorth_RedAddon : BaseAddon
	{
        private static int[,] m_AddOnSimpleComponents = new int[,] {
			  {41198, 2, 3, 10}, {40364, 1, 0, 13}, {2839, 0, 2, 16}// 1	2	8	
			, {2832, -1, 2, 16}, {2838, -1, 3, 16}, {2831, 0, 3, 16}// 9	10	13	
			, {4604, 0, 1, 15}, {40142, 1, 0, 12}, {4604, 0, -1, 14}// 17	21	26	
			, {3649, 0, 3, 23}, {3647, 0, 4, 27}, {3644, 0, 4, 24}// 27	28	29	
			, {37654, 0, -2, 0}// 30	
		};

 
            
		public override BaseAddonDeed Deed
		{
			get
			{
				return new SmallSteamBoatNorth_RedAddonDeed();
			}
		}

		[ Constructable ]
		public SmallSteamBoatNorth_RedAddon()
		{

            for (int i = 0; i < m_AddOnSimpleComponents.Length / 4; i++)
                AddComponent( new AddonComponent( m_AddOnSimpleComponents[i,0] ), m_AddOnSimpleComponents[i,1], m_AddOnSimpleComponents[i,2], m_AddOnSimpleComponents[i,3] );


			AddComplexComponent( (BaseAddon) this, 4245, -1, -2, 16, 0, -1, "Throttle", 1);// 3
			AddComplexComponent( (BaseAddon) this, 1898, 1, 4, 13, 2118, -1, "", 1);// 4
			AddComplexComponent( (BaseAddon) this, 16031, -1, -1, 11, 2118, -1, "", 1);// 5
			AddComplexComponent( (BaseAddon) this, 2835, 1, -3, 14, 2118, -1, "console", 1);// 6
			AddComplexComponent( (BaseAddon) this, 2832, -1, -3, 14, 2118, -1, "console", 1);// 7
			AddComplexComponent( (BaseAddon) this, 2834, -1, 4, 16, 2118, -1, "", 1);// 11
			AddComplexComponent( (BaseAddon) this, 2837, 0, 4, 16, 2118, -1, "", 1);// 12
			AddComplexComponent( (BaseAddon) this, 16044, -1, 3, 11, 2418, -1, "", 1);// 14
			AddComplexComponent( (BaseAddon) this, 16044, 1, 4, 19, 2118, -1, "", 1);// 15
			AddComplexComponent( (BaseAddon) this, 16044, -1, 2, 11, 2418, -1, "", 1);// 16
			AddComplexComponent( (BaseAddon) this, 194, 1, 0, 11, 2112, -1, "", 1);// 18
			AddComplexComponent( (BaseAddon) this, 40147, 1, 4, 20, 0, -1, "Moonstone Powered Engine", 1);// 19
			AddComplexComponent( (BaseAddon) this, 20392, 1, 3, 21, 0, -1, "Diagnostics", 1);// 20
			AddComplexComponent( (BaseAddon) this, 16044, 0, 0, 11, 2118, -1, "", 1);// 22
			AddComplexComponent( (BaseAddon) this, 16044, 1, 0, 11, 2418, -1, "", 1);// 23
			AddComplexComponent( (BaseAddon) this, 16044, 0, 1, 11, 2112, -1, "", 1);// 24
			AddComplexComponent( (BaseAddon) this, 40158, -1, -3, 15, 2118, -1, "Forward, Reverse Controls", 1);// 25
			AddComplexComponent( (BaseAddon) this, 17359, 0, -3, 9, 2118, -1, "", 1);// 31
			AddComplexComponent( (BaseAddon) this, 16042, 0, 4, 11, 2112, -1, "", 1);// 32
			AddComplexComponent( (BaseAddon) this, 16060, 0, 5, 10, 2118, -1, "", 1);// 33
			AddComplexComponent( (BaseAddon) this, 16054, -1, 4, 9, 2118, -1, "", 1);// 34
			AddComplexComponent( (BaseAddon) this, 16053, 1, 4, 11, 2418, -1, "", 1);// 35
			AddComplexComponent( (BaseAddon) this, 16044, 0, 3, 11, 2418, -1, "", 1);// 36
			AddComplexComponent( (BaseAddon) this, 16044, 0, 2, 11, 2418, -1, "", 1);// 37
			AddComplexComponent( (BaseAddon) this, 16044, -1, 0, 11, 2118, -1, "", 1);// 38
			AddComplexComponent( (BaseAddon) this, 16044, 0, -1, 11, 2118, -1, "", 1);// 39
			AddComplexComponent( (BaseAddon) this, 16044, 0, -2, 11, 2118, -1, "", 1);// 40
			AddComplexComponent( (BaseAddon) this, 16039, -1, 3, 11, 2418, -1, "", 1);// 41
			AddComplexComponent( (BaseAddon) this, 16037, -1, 2, 11, 2418, -1, "", 1);// 42
			AddComplexComponent( (BaseAddon) this, 16033, -1, 1, 11, 2118, -1, "", 1);// 43
			AddComplexComponent( (BaseAddon) this, 16032, 1, -1, 11, 2118, -1, "", 1);// 44
			AddComplexComponent( (BaseAddon) this, 16030, 1, -2, 11, 2118, -1, "", 1);// 45
			AddComplexComponent( (BaseAddon) this, 16029, -1, -2, 11, 2118, -1, "", 1);// 46
			AddComplexComponent( (BaseAddon) this, 16028, 1, -3, 11, 2118, -1, "", 1);// 47
			AddComplexComponent( (BaseAddon) this, 16027, -1, -3, 11, 2118, -1, "", 1);// 48
			AddComplexComponent( (BaseAddon) this, 2586, 0, -4, 14, 0, 1, "", 1);// 49
			AddComplexComponent( (BaseAddon) this, 16026, 0, -4, 11, 2118, -1, "", 1);// 50

		}

		public SmallSteamBoatNorth_RedAddon( Serial serial ) : base( serial )
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

	public class SmallSteamBoatNorth_RedAddonDeed : BaseAddonDeed
	{
		public override BaseAddon Addon
		{
			get
			{
				return new SmallSteamBoatNorth_RedAddon();
			}
		}

		[Constructable]
		public SmallSteamBoatNorth_RedAddonDeed()
		{
			Name = "SmallSteamBoatNorth_Red";
		}

		public SmallSteamBoatNorth_RedAddonDeed( Serial serial ) : base( serial )
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