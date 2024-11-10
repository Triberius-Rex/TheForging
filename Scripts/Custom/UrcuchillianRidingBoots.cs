using System;

namespace Server.Items
{
    public class UrcuchiallianRidingShoes : Sandals
	{
        public override bool IsArtifact { get { return true; } }
        [Constructable]
        public UrcuchiallianRidingShoes()
        {
            Hue = 1159;
            Name = "Urcuchillian Riding Shoes";            
        }

        public UrcuchiallianRidingShoes(Serial serial)
            : base(serial)
        {
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