using Server.Items;

namespace Server.Mobiles
{
    public class MerchantCrew : BaseCreature
    {
        public override bool InitialInnocent => true;
        public override WeaponAbility GetWeaponAbility()
        {
            Item weapon = FindItemOnLayer(Layer.TwoHanded);

            if (weapon == null)
                return null;

            if (weapon is BaseWeapon)
            {
                if (Utility.RandomBool())
                    return ((BaseWeapon)weapon).PrimaryAbility;
                else
                    return ((BaseWeapon)weapon).SecondaryAbility;
            }
            return null;
        }

        [Constructable]
        public MerchantCrew()
            : base(AIType.AI_Paladin, FightMode.Aggressor, 10, 1, .2, .4)
        {
            Title = "the merchant";
            Hue = Race.RandomSkinHue();

            if (Female = Utility.RandomBool())
            {
                Body = 0x191;
                Name = NameList.RandomName("female");
				SetWearable(new Skirt(), Utility.RandomNeutralHue(), 1);
            }
            else
            {
                Body = 0x190;
                Name = NameList.RandomName("male");
                SetWearable(new ShortPants(), Utility.RandomNeutralHue(), 1);
            }

            bool magery = 0.33 > Utility.RandomDouble();

            SetStr(100, 125);
            SetDex(125, 150);
            SetInt(250, 400);
            SetHits(250, 400);
            SetDamage(15, 25);

            if (magery)
            {
                ChangeAIType(AIType.AI_Mage);
                SetSkill(SkillName.Magery, 100.0, 120.0);
                SetSkill(SkillName.EvalInt, 100.0, 120.0);
                SetSkill(SkillName.Meditation, 100.0, 120.0);
                SetSkill(SkillName.MagicResist, 100.0, 120.0);
            }

            SetSkill(SkillName.Archery, 100.0, 120.0);
            SetSkill(SkillName.Chivalry, 100.0, 120.0);
            SetSkill(SkillName.Focus, 100.0, 120.0);
            SetSkill(SkillName.Tactics, 100.0, 120.0);
            SetSkill(SkillName.Wrestling, 100.0, 120.0);
            SetSkill(SkillName.Anatomy, 100.0, 120.0);

            SetDamageType(ResistanceType.Physical, 70);
            SetResistance(ResistanceType.Physical, 45, 55);
            SetResistance(ResistanceType.Fire, 45, 55);
            SetResistance(ResistanceType.Cold, 45, 55);
            SetResistance(ResistanceType.Poison, 45, 55);
            SetResistance(ResistanceType.Energy, 45, 55);

            Item bow;

            switch (Utility.Random(4))
            {
                default:
                case 0: bow = new CompositeBow(); break;
                case 1: bow = new Crossbow(); break;
                case 2: bow = new Bow(); break;
                case 3: bow = new HeavyCrossbow(); break;
            }

			SetWearable(bow, dropChance: 1);

            SetWearable(new TricorneHat(), dropChance: 1);
            SetWearable(new FancyShirt(), dropChance: 1);
            SetWearable(new Boots(), Utility.RandomNeutralHue(), 1);
			SetWearable(new GoldEarrings(), dropChance: 1);

            Fame = 8000;
            Karma = 8000;
        }

        public override void GenerateLoot()
        {
            AddLoot(LootPack.UltraRich, 2);
            AddLoot(LootPack.LootItem<Arrow>(25, true));
            AddLoot(LootPack.LootItem<Bolt>(25, true));
        }

        public MerchantCrew(Serial serial)
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
