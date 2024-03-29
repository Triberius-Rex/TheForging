using Server.Items;
using Server.Multis;

namespace Server.Mobiles
{
    public class MerchantCaptain : BaseShipCaptain
    {
        public override bool Aggressive => false;
        public override bool InitialInnocent => true;

        [Constructable]
        public MerchantCaptain(BaseGalleon galleon)
            : base(galleon, AIType.AI_Melee, FightMode.Aggressor, 1, 10, .2, .4)
        {
            Title = "the merchant captain";
            Hue = Race.RandomSkinHue();

            Item hat;

            if (Utility.RandomBool())
                hat = new WideBrimHat();
            else
                hat = new TricorneHat();

            SetWearable(new Sandals(), dropChance: 1);
            SetWearable(new FancyShirt(), Utility.RandomNeutralHue(), 1);
            SetWearable(hat, Utility.RandomNeutralHue(), 1);
            SetWearable(new Cloak(), Utility.RandomNeutralHue(), 1);
			SetWearable(new Dagger(), dropChance: 1);

            Utility.AssignRandomHair(this);

            Fame = 22000;
            Karma = -22000;
        }

        public override void GenerateLoot()
        {
            AddLoot(LootPack.SuperBoss, 2);
        }

        public MerchantCaptain(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }
}
