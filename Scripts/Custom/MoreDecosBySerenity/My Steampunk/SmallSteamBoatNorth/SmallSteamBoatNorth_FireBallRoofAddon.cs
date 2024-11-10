
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
	public class SmallSteamBoatNorth_FireBallRoofAddon : BaseAddon
	{
        private static int[,] m_AddOnSimpleComponents = new int[,] {
			  {2592, -1, 1, 11}, {2592, 2, 1, 11}, {2592, -1, -3, 11}// 33	34	35	
			, {2592, 2, -3, 11}// 36	
		};

 
            
		public override BaseAddonDeed Deed
		{
			get
			{
				return new SmallSteamBoatNorth_FireBallRoofAddonDeed();
			}
		}

		[ Constructable ]
		public SmallSteamBoatNorth_FireBallRoofAddon()
		{

            for (int i = 0; i < m_AddOnSimpleComponents.Length / 4; i++)
                AddComponent( new AddonComponent( m_AddOnSimpleComponents[i,0] ), m_AddOnSimpleComponents[i,1], m_AddOnSimpleComponents[i,2], m_AddOnSimpleComponents[i,3] );


			AddComplexComponent( (BaseAddon) this, 4834, 3, 2, 9, 1161, -1, "", 1);// 1
			AddComplexComponent( (BaseAddon) this, 4834, -2, 1, 0, 1161, -1, "", 1);// 2
			AddComplexComponent( (BaseAddon) this, 4834, -2, -2, 0, 1161, -1, "", 1);// 3
			AddComplexComponent( (BaseAddon) this, 4834, 3, -1, 9, 1161, -1, "", 1);// 4
			AddComplexComponent( (BaseAddon) this, 1543, 1, 2, 38, 1161, -1, "", 1);// 5
			AddComplexComponent( (BaseAddon) this, 1588, 1, 1, 38, 1161, -1, "", 1);// 6
			AddComplexComponent( (BaseAddon) this, 1535, 0, 2, 35, 1161, -1, "", 1);// 7
			AddComplexComponent( (BaseAddon) this, 1535, 0, 1, 35, 1161, -1, "", 1);// 8
			AddComplexComponent( (BaseAddon) this, 1540, 2, 2, 38, 1161, -1, "", 1);// 9
			AddComplexComponent( (BaseAddon) this, 1538, 2, 1, 38, 1161, -1, "", 1);// 10
			AddComplexComponent( (BaseAddon) this, 1538, 3, 2, 35, 1161, -1, "", 1);// 11
			AddComplexComponent( (BaseAddon) this, 1538, 3, 1, 35, 1161, -1, "", 1);// 12
			AddComplexComponent( (BaseAddon) this, 1537, 2, 3, 35, 1161, -1, "", 1);// 13
			AddComplexComponent( (BaseAddon) this, 1538, 2, 0, 38, 1161, -1, "", 1);// 14
			AddComplexComponent( (BaseAddon) this, 1538, 2, -1, 38, 1161, -1, "", 1);// 15
			AddComplexComponent( (BaseAddon) this, 1541, 2, -2, 38, 1161, -1, "", 1);// 16
			AddComplexComponent( (BaseAddon) this, 1536, 2, -3, 35, 1161, -1, "", 1);// 17
			AddComplexComponent( (BaseAddon) this, 1537, 1, 3, 35, 1161, -1, "", 1);// 18
			AddComplexComponent( (BaseAddon) this, 1588, 1, 0, 38, 1161, -1, "", 1);// 19
			AddComplexComponent( (BaseAddon) this, 1588, 1, -1, 38, 1161, -1, "", 1);// 20
			AddComplexComponent( (BaseAddon) this, 1542, 1, -2, 38, 1161, -1, "", 1);// 21
			AddComplexComponent( (BaseAddon) this, 1536, 1, -3, 35, 1161, -1, "", 1);// 22
			AddComplexComponent( (BaseAddon) this, 1543, 0, 3, 35, 1161, -1, "", 1);// 23
			AddComplexComponent( (BaseAddon) this, 1535, 0, 0, 35, 1161, -1, "", 1);// 24
			AddComplexComponent( (BaseAddon) this, 1535, 0, -1, 35, 1161, -1, "", 1);// 25
			AddComplexComponent( (BaseAddon) this, 1535, 0, -2, 35, 1161, -1, "", 1);// 26
			AddComplexComponent( (BaseAddon) this, 1542, 0, -3, 35, 1161, -1, "", 1);// 27
			AddComplexComponent( (BaseAddon) this, 1540, 3, 3, 35, 1161, -1, "", 1);// 28
			AddComplexComponent( (BaseAddon) this, 1538, 3, 0, 35, 1161, -1, "", 1);// 29
			AddComplexComponent( (BaseAddon) this, 1538, 3, -1, 35, 1161, -1, "", 1);// 30
			AddComplexComponent( (BaseAddon) this, 1538, 3, -2, 35, 1161, -1, "", 1);// 31
			AddComplexComponent( (BaseAddon) this, 1541, 3, -3, 35, 1161, -1, "", 1);// 32

		}

		public SmallSteamBoatNorth_FireBallRoofAddon( Serial serial ) : base( serial )
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

	public class SmallSteamBoatNorth_FireBallRoofAddonDeed : BaseAddonDeed
	{
		public override BaseAddon Addon
		{
			get
			{
				return new SmallSteamBoatNorth_FireBallRoofAddon();
			}
		}

		[Constructable]
		public SmallSteamBoatNorth_FireBallRoofAddonDeed()
		{
			Name = "SmallSteamBoatNorth_FireBallRoof";
		}

		public SmallSteamBoatNorth_FireBallRoofAddonDeed( Serial serial ) : base( serial )
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