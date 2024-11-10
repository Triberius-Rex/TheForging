
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
	public class IceFlow2Addon : BaseAddon
	{
         
            
		public override BaseAddonDeed Deed
		{
			get
			{
				return new IceFlow2AddonDeed();
			}
		}

		[ Constructable ]
		public IceFlow2Addon()
		{



			AddComplexComponent( (BaseAddon) this, 6087, 2, 3, 0, 0, -1, "Ice Flow", 1);// 1
			AddComplexComponent( (BaseAddon) this, 6087, 3, 2, 0, 0, -1, "Ice Flow", 1);// 2
			AddComplexComponent( (BaseAddon) this, 6088, -2, 3, 0, 0, -1, "Ice Flow", 1);// 3
			AddComplexComponent( (BaseAddon) this, 6090, -2, 2, 0, 0, -1, "Ice Flow", 1);// 4
			AddComplexComponent( (BaseAddon) this, 6089, 1, 3, 0, 0, -1, "Ice Flow", 1);// 5
			AddComplexComponent( (BaseAddon) this, 6089, 0, 3, 0, 0, -1, "Ice Flow", 1);// 6
			AddComplexComponent( (BaseAddon) this, 6089, -1, 3, 0, 0, -1, "Ice Flow", 1);// 7
			AddComplexComponent( (BaseAddon) this, 6081, 2, 2, 0, 0, -1, "Ice Flow", 1);// 8
			AddComplexComponent( (BaseAddon) this, 6078, -1, 2, 0, 0, -1, "Ice Flow", 1);// 9
			AddComplexComponent( (BaseAddon) this, 6078, 1, 2, 0, 0, -1, "Ice Flow", 1);// 10
			AddComplexComponent( (BaseAddon) this, 6077, 0, 2, 0, 0, -1, "Ice Flow", 1);// 11
			AddComplexComponent( (BaseAddon) this, 2275, 2, 1, 0, 1153, -1, "Ice Flow", 1);// 12
			AddComplexComponent( (BaseAddon) this, 2272, 0, -1, 0, 1153, -1, "Ice Flow", 1);// 13
			AddComplexComponent( (BaseAddon) this, 2276, 2, 0, 0, 1153, -1, "Ice Flow", 1);// 14
			AddComplexComponent( (BaseAddon) this, 2281, -1, 0, 0, 1153, -1, "Ice Flow", 1);// 15
			AddComplexComponent( (BaseAddon) this, 2278, -1, 1, 0, 1153, -1, "Ice Flow", 1);// 16
			AddComplexComponent( (BaseAddon) this, 6086, 3, -2, 0, 0, -1, "Ice Flow", 1);// 17
			AddComplexComponent( (BaseAddon) this, 6085, -1, -2, 0, 0, -1, "Ice Flow", 1);// 18
			AddComplexComponent( (BaseAddon) this, 6085, -2, -1, 0, 0, -1, "Ice Flow", 1);// 19
			AddComplexComponent( (BaseAddon) this, 6092, 3, 1, 0, 0, -1, "Ice Flow", 1);// 20
			AddComplexComponent( (BaseAddon) this, 6092, 3, 0, 0, 0, -1, "Ice Flow", 1);// 21
			AddComplexComponent( (BaseAddon) this, 6092, 3, -1, 0, 0, -1, "Ice Flow", 1);// 22
			AddComplexComponent( (BaseAddon) this, 6090, -2, 1, 0, 0, -1, "Ice Flow", 1);// 23
			AddComplexComponent( (BaseAddon) this, 6090, -2, 0, 0, 0, -1, "Ice Flow", 1);// 24
			AddComplexComponent( (BaseAddon) this, 6091, 2, -2, 0, 0, -1, "Ice Flow", 1);// 25
			AddComplexComponent( (BaseAddon) this, 6091, 1, -2, 0, 0, -1, "Ice Flow", 1);// 26
			AddComplexComponent( (BaseAddon) this, 6091, 0, -2, 0, 0, -1, "Ice Flow", 1);// 27
			AddComplexComponent( (BaseAddon) this, 6083, -1, -1, 0, 0, -1, "Ice Flow", 1);// 28
			AddComplexComponent( (BaseAddon) this, 6078, 2, -1, 0, 0, -1, "Ice Flow", 1);// 29
			AddComplexComponent( (BaseAddon) this, 6078, -1, 0, 0, 0, -1, "Ice Flow", 1);// 30
			AddComplexComponent( (BaseAddon) this, 6080, -1, 1, 0, 0, -1, "Ice Flow", 1);// 31
			AddComplexComponent( (BaseAddon) this, 6078, 0, 1, 0, 0, -1, "Ice Flow", 1);// 32
			AddComplexComponent( (BaseAddon) this, 6078, 2, 1, 0, 0, -1, "Ice Flow", 1);// 33
			AddComplexComponent( (BaseAddon) this, 6080, 1, 1, 0, 0, -1, "Ice Flow", 1);// 34
			AddComplexComponent( (BaseAddon) this, 6080, 2, 0, 0, 0, -1, "Ice Flow", 1);// 35
			AddComplexComponent( (BaseAddon) this, 6079, 1, 0, 0, 0, -1, "Ice Flow", 1);// 36
			AddComplexComponent( (BaseAddon) this, 6077, 1, -1, 0, 0, -1, "Ice Flow", 1);// 37
			AddComplexComponent( (BaseAddon) this, 6080, 0, 0, 0, 0, -1, "Ice Flow", 1);// 38
			AddComplexComponent( (BaseAddon) this, 6078, 0, -1, 0, 0, -1, "Ice Flow", 1);// 39

		}

		public IceFlow2Addon( Serial serial ) : base( serial )
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

	public class IceFlow2AddonDeed : BaseAddonDeed
	{
		public override BaseAddon Addon
		{
			get
			{
				return new IceFlow2Addon();
			}
		}

		[Constructable]
		public IceFlow2AddonDeed()
		{
			Name = "IceFlow2";
		}

		public IceFlow2AddonDeed( Serial serial ) : base( serial )
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