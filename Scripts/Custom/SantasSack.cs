using Server.Engines.Events;
using Server.Mobiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Items
{
	public class SantasSack : BaseContainer
	{
		public static DateTime StartChristmas => new DateTime(2022, 12, 24);
		public static DateTime FinishChristmas => new DateTime(2022, 12, 26);

		public override int DefaultGumpID => 0x11E;

		[Constructable]
		public SantasSack()
			: base(0x9DB5)
		{
			Name = "Santa's Gift Bag";
			Hue = GiftBoxHues.RandomGiftBoxHue;
		}

		public override void OnDoubleClick(Mobile from)
		{
			#region Drops Gifts Into Bag
			/*
			if (from.Karma <= 0)
			{
				this.DropItem(new Coal());
			}
			else if (from.Karma >= 1 && from.Karma <= 9999)
			{
				this.DropItem(new NightsKiss());
			}
			else if (from.Karma >= 10000 && from.Karma <= 14999)
			{
				this.DropItem(new ChestOfHeirlooms());
			}
            else if (from.Karma >= 15000)
            {
                this.DropItem(new ArmorOfFortune());
            }
			*/
			#endregion

			#region Drops Gifts Into Pack And Then Delete's Bag
			/*
			if (from.Karma <= 0)
			{
				from.AddToBackpack(new Coal());
			}
			else if (from.Karma >= 1 && from.Karma <= 9999)
			{
				from.AddToBackpack(new NightsKiss());
			}
			else if (from.Karma >= 10000 && from.Karma <= 14999)
			{
				from.AddToBackpack(new ChestOfHeirlooms());
			}
            else if (from.Karma >= 15000)
            {
				from.AddToBackpack(new ArmorOfFortune());
            }

			this.Delete();
			*/
			#endregion

			#region Drops Gifts Into Bag On Certain Dates > Deletes Bag On Use
			/*
			if (DateTime.UtcNow >= SantasSack.StartChristmas && DateTime.UtcNow <= SantasSack.FinishChristmas)
			{
				if (from.Karma <= 0)
				{
					this.DropItem(new Coal());
					this.Delete();
				}
				else if (from.Karma >= 1 && from.Karma <= 9999)
				{
					this.DropItem(new NightsKiss());
					this.Delete();
				}
				else if (from.Karma >= 10000 && from.Karma <= 14999)
				{
					this.DropItem(new ChestOfHeirlooms());
					this.Delete();
				}
				else if (from.Karma >= 15000)
				{
					this.DropItem(new ArmorOfFortune());
					this.Delete();
				}
			}
			else if (DateTime.UtcNow < SantasSack.StartChristmas)
			{
				from.SendAsciiMessage("Christmas has yet to begin and Santa's elves are working overtime!");
			}
			else
			{
				from.Emote("*you decide to save the bag for next year*");
				from.EmoteHue = 1123;
				from.SendAsciiMessage("Christmas has passed, all presents have been distributed!");
			}
			*/
			#endregion

			base.OnDoubleClick(from);
		}

		public SantasSack(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write(0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			var version = reader.ReadInt();
		}
	}
}
