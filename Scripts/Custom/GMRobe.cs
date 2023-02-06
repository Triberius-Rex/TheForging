using System;

namespace Server.Items
{
    public class GMRobe : BaseSuit
	{
               
        [Constructable]
        public GMRobe()
            : base(AccessLevel.Counselor, 0x0, 0x204F)
        {
        }

        [Constructable]
        public GMRobe(int hue)
            : base(0x204F)
        {
            Weight = 0.0;
        }

        public GMRobe(Serial serial)
            : base(serial)
        {
        }

                public override void OnDoubleClick(Mobile from)
        {
            if (from.IsPlayer())
            {
                from.SendMessage("This item is to only be used by staff members."); 
                this.Delete();
            }
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }

        public override bool OnEquip(Mobile from)
        {
            if ((this.ItemID == 0x204F) && (from.IsStaff()))
                this.ItemID = 0x204F;

            switch (from.AccessLevel)
            {
                case AccessLevel.Owner:
                    this.Name = "Owner's Robe";
                    break;
                case AccessLevel.CoOwner:
                    this.Name = "Co-Owner's Robe";
                    break;
                case AccessLevel.Administrator:
                    this.Name = "Administrator's Robe";
                    break;
                case AccessLevel.Developer:
                    this.Name = "Developer's Robe";
                    break;
                case AccessLevel.Seer:
                    this.Name = "Seer's Robe";;
                    break;
                case AccessLevel.GameMaster:
                    this.Name = "GameMaster's Robe";
                    break;
                case AccessLevel.Counselor:
                    this.Name = "Counselor's Robe";
                    break;
            }

            return true;
        }
    }
}

