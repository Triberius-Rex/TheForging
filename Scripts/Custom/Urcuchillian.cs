//Created By Serenity: 08-26-23 Enjoy!! Hope you have as much fun using this script as I did making it, this is a learning process for me, so please excuse any noobish coding..
//Free to use and modify Just please dont remove this header! Thanks!
//You must add the line blow this one to "PetTrainingHelper.cs" so he can be trained: I add this line around 689 in a custom pets catagory to keep them seperate from the others.
// "new TrainingDefinition(typeof(Urcuchillay), Class.MagicalClawedAndTailed, MagicalAbility.Cusidhe, SpecialAbilityClawedTailedAndMagical2, WepAbility5, AreaEffectArea1, 3, 5),"


using System;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("a Urcuchillay corpse")]
    public class Urcuchillay : BaseMount
    {
        public override double HealChance { get { return 1.0; } }

        [Constructable]
        public Urcuchillay()
            : this("a Urcuchillian")
        {
        }

        [Constructable]
        public Urcuchillay(string name)
            : base(name, 277, 0x3E91, AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.4)
        {
            double chance = Utility.RandomDouble() * 23301;

            if (chance <= 1)
                Hue = 0x489;
            else if (chance < 50)
                Hue = Utility.RandomList(0x657, 0x515, 0x4B1, 0x481, 0x482, 0x455);
            else if (chance < 500)
                Hue = Utility.RandomList(0x97A, 0x978, 0x901, 0x8AC, 0x5A7, 0x527);
			
			BodyValue = 220;
			ItemID = 16038;
			BaseSoundID = 1011;

            SetStr(1200, 1225);
            SetDex(150, 170);
            SetInt(250, 285);
		

            SetHits(1010, 1275);

            SetDamage(21, 28);

            SetDamageType(ResistanceType.Physical, 0);
            SetDamageType(ResistanceType.Cold, 50);
            SetDamageType(ResistanceType.Energy, 50);

            SetResistance(ResistanceType.Physical, 50, 65);
            SetResistance(ResistanceType.Fire, 25, 45);
            SetResistance(ResistanceType.Cold, 70, 85);
            SetResistance(ResistanceType.Poison, 30, 50);
            SetResistance(ResistanceType.Energy, 70, 85);

            SetSkill(SkillName.Wrestling, 90.1, 96.8);
            SetSkill(SkillName.Tactics, 90.3, 99.3);
            SetSkill(SkillName.MagicResist, 75.3, 90.0);
            SetSkill(SkillName.Anatomy, 65.5, 69.4);
            SetSkill(SkillName.Healing, 72.2, 98.9);

            Fame = 5000;  //Guessing here
            Karma = 5000;  //Guessing here

            Tamable = true;
			ControlSlotsMax = 5;
            ControlSlots = 3;
            MinTameSkill = 101.1;

            PackGold(500, 800);

            SetWeaponAbility(WeaponAbility.BleedAttack);
        }

        public Urcuchillay(Serial serial)
            : base(serial)
        {
        }

        public static TrainingDefinition _UrcuchillayDefinition; //can add pet training definitions this way instead of adding it directly to the file

        public override TrainingDefinition TrainingDefinition
        {
            get
            {
				if (_UrcuchillayDefinition == null)
				{
					_UrcuchillayDefinition = new TrainingDefinition(GetType(), Class.MagicalClawedAndTailed, MagicalAbility.Cusidhe, PetTrainingHelper.SpecialAbilityClawedTailedAndMagical2, PetTrainingHelper.WepAbility5, PetTrainingHelper.AreaEffectArea1, 3, 5);
				}

				return _UrcuchillayDefinition;
            }
        } //end of training definition

        public override int TreasureMapLevel
        {
            get { return 5; }
        }

        public override FoodType FavoriteFood
        {
            get
            {
                return FoodType.FruitsAndVegies;
            }
        }
        public override bool CanAngerOnTame
        {
            get
            {
                return true;
            }
        }
        public override bool StatLossAfterTame
        {
            get
            {
                return true;
            }
        }
        public override int Hides
        {
            get
            {
                return 10;
            }
        }
        public override int Meat
        {
            get
            {
                return 3;
            }
        }
        public override void GenerateLoot()
        {
            AddLoot(LootPack.AosFilthyRich, 5);
        }

        public override void OnAfterTame(Mobile tamer)
        {
            if (Owners.Count == 0 && PetTrainingHelper.Enabled)
            {
                if (RawStr > 0)
                    RawStr = (int)Math.Max(1, RawStr * 0.5);

                if (RawDex > 0)
                    RawDex = (int)Math.Max(1, RawDex * 0.5);

                if (HitsMaxSeed > 0)
                    HitsMaxSeed = (int)Math.Max(1, HitsMaxSeed * 0.5);

                Hits = Math.Min(HitsMaxSeed, Hits);
                Stam = Math.Min(RawDex, Stam);
            }
            else
            {
                base.OnAfterTame(tamer);
            }
        }

        public override void OnDoubleClick(Mobile from)
        {
            if (from.Race != Race.Human && from == ControlMaster && from.IsPlayer())
            {
                Item pads = from.FindItemOnLayer(Layer.Shoes);

                if (pads is UrcuchiallianRidingShoes)
                    from.SendMessage("Your shoes allow you to mount the Urcuchillian"); 
                else
                {
                    from.SendMessage("Only Humans may use this!"); // Only Elves may use 
                    return;
                }
            }

            base.OnDoubleClick(from);
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)3); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

            if (version < 3 && Controlled && RawStr >= 1200 && ControlSlots == ControlSlotsMin)
            {
                Server.SkillHandlers.AnimalTaming.ScaleStats(this, 0.5);
            }

            if (version < 1 && Name == "a Cu Sidhe")
                Name = "a cu sidhe";

            if (version == 1)
            {
                SetWeaponAbility(WeaponAbility.BleedAttack);
            }
        }
    }
}
