using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class allPowerScroll : Bag
	{
		[Constructable]
		public allPowerScroll(double value)
		{
			for (int i = 0; i < PowerScroll.Skills.Count; ++i)
			{
				DropItem(new PowerScroll(PowerScroll.Skills[i], value));
			}
			Name = "All Powerscrolls";
			Hue = 0x097E;
		}
		public allPowerScroll(Serial serial) : base(serial)
		{ }
		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.WriteEncodedInt((int)0); // version
		}
		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadEncodedInt();
		}
	}
}