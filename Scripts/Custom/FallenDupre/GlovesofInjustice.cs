using System;

namespace Server.Items
{
    [FlipableAttribute(0x1450, 0x1455)]
    public class GlovesofInjustice : PlateGloves
    {
		public override bool IsArtifact { get { return true; } }
        [Constructable]
        public GlovesofInjustice()
            : base()
        {
            this.Weight = 2.0;
            this.Name = "Gloves of Injustice";
            this.SetHue = 1109;
            this.Attributes.RegenHits = 1;
            this.Attributes.AttackChance = 5;
			
            this.SetAttributes.ReflectPhysical = 25;
            this.SetAttributes.NightSight = 1;
			
            this.SetSkillBonuses.SetValues(0, SkillName.Swords, 10);
			
            this.SetSelfRepair = 3;			
            this.SetPhysicalBonus = 2;
            this.SetFireBonus = 5;
            this.SetColdBonus = 5;
            this.SetPoisonBonus = 3;
            this.SetEnergyBonus = 5;
        }

        public GlovesofInjustice(Serial serial)
            : base(serial)
        {
        }
        public override SetItem SetID
        {
            get
            {
                return SetItem.ForsakenVirtues;
            }
        }
        public override int Pieces
        {
            get
            {
                return 6;
            }
        }
        public override int BasePhysicalResistance
        {
            get
            {
                return 8;
            }
        }
        public override int BaseFireResistance
        {
            get
            {
                return 5;
            }
        }
        public override int BaseColdResistance
        {
            get
            {
                return 5;
            }
        }
        public override int BasePoisonResistance
        {
            get
            {
                return 7;
            }
        }
        public override int BaseEnergyResistance
        {
            get
            {
                return 5;
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
    }
}