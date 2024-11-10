using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("an training elemental corpse")]
    public class TrainingElemental : BaseCreature
    {
        [Constructable]
        public TrainingElemental()
            : base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            Name = "a training elemental";
            Body = 111;
            BaseSoundID = 268;

            SetStr(226, 255);
            SetDex(126, 145);
            SetInt(71, 92);

            SetHits(136, 153);

            SetDamage(1, 1);

            SetDamageType(ResistanceType.Physical, 100);

            SetResistance(ResistanceType.Physical, 30, 40);
            SetResistance(ResistanceType.Fire, 30, 40);
            SetResistance(ResistanceType.Cold, 20, 30);
            SetResistance(ResistanceType.Poison, 10, 20);
            SetResistance(ResistanceType.Energy, 30, 40);

            SetSkill(SkillName.MagicResist, 50.1, 95.0);
            SetSkill(SkillName.Tactics, 60.1, 100.0);
            SetSkill(SkillName.Wrestling, 60.1, 100.0);

            Fame = 4500;
            Karma = -4500;
            CantWalk = true;
            Hue = 1910;
            GuardImmune = true;
        }

        public TrainingElemental(Serial serial)
            : base(serial)
        {
        }

        public override bool AutoDispel => true;
        public override bool BleedImmune => true;
        public override int TreasureMapLevel => 1;
        public override Poison PoisonImmune => Poison.Deadly;
        public override bool BreathImmune => true;

        public override void AlterMeleeDamageFrom(Mobile from, ref int damage)
        {
            if (from is BaseCreature bc && (bc.Controlled || bc.BardTarget == this))
            {
                damage = 0; // Immune to pets and provoked creatures
            }
            else if (from is PlayerMobile)
            {
                damage = 0; //Immune to Players
            }
        }

        public override void AlterDamageScalarFrom(Mobile caster, ref double scalar)
        {
            if (caster is BaseCreature creature && creature.GetMaster() is PlayerMobile)
            {
                scalar = 0.0; // Immune to magic
            }
            else if (caster is PlayerMobile)
            {
                scalar = 0.0; //Immune to Players
            }
        }

        public override void AlterSpellDamageFrom(Mobile from, ref int damage)
        {
            if (from is BaseCreature creature && creature.GetMaster() is PlayerMobile)
            {
                damage = 0;
            }
            else if (from is PlayerMobile)
            {   
                damage = 0;            
            }
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            reader.ReadInt();
        }
    }
}
