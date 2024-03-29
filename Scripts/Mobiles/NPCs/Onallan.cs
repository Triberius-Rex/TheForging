using Server.Items;
using System;

namespace Server.Engines.Quests
{
    public class ProofOfTheDeedQuest : BaseQuest
    {
        public ProofOfTheDeedQuest()
            : base()
        {
            AddObjective(new ObtainObjective(typeof(SeveredHumanEars), "severed human ears", 20, 0x312F));

            AddReward(new BaseReward(typeof(TrinketBag), 1072341));
        }

        /* Proof of the Deed */
        public override object Title => 1072339;
        /* These human vermin must be erradicated!  They despoil fair Sosaria with their every footfall upon her soil, 
        every exhalation of breath upon her pristine air.  Prove yourself an ally of Sosaria and bring me 20 human ears 
        as proof of your devotion to our cause. */
        public override object Description => 1072340;
        /* Do you find the task distasteful?  Are you too weak to shoulder the duty of cleansing Sosaria?  So be it. */
        public override object Refuse => 1072342;
        /* Well, where is the proof of your deed?  I will honor your actions when you have brought me the ears of the human scum. */
        public override object Uncomplete => 1072343;
        /* Ah, well done.  You have chosen the path of duty and fulfilled your task with honor. */
        public override object Complete => 1072344;
        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }

    public class Onallan : MondainQuester
    {
        [Constructable]
        public Onallan()
            : base("Elder Onallan", "the wise")
        {
        }

        public Onallan(Serial serial)
            : base(serial)
        {
        }

        public override Type[] Quests => new Type[]
                {
                    typeof(MaraudersQuest),
                    typeof(ProofOfTheDeedQuest)
                };
        public override void InitBody()
        {
            InitStats(100, 100, 25);

            Race = Race.Elf;
            Female = false;
            CantWalk = true;

            Hue = Race.RandomSkinHue();
            HairItemID = 0x2FD0;
            HairHue = 0x322;
        }

        public override void InitOutfit()
        {
            SetWearable(new Shoes(), 0x70A, 1);
            SetWearable(new Cloak(), 0x651, 1);
			SetWearable(new WildStaff(), dropChance: 1);
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }
}