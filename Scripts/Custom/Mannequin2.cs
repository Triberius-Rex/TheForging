using System;
using Server.Items;
using Server.Multis;
using Server.Network;
using Server.ContextMenus;
using System.Collections.Generic;
using System.Linq;
using Server.Gumps;
using Server.Targeting;

namespace Server.Mobiles
{
    public class Mannequin2 : BaseCreature
    {
        public override bool IsInvulnerable { get { return true; } }
        [Constructable]
        public Mannequin2(): base(AIType.AI_Use_Default, FightMode.None, 1, 1, 0.2, 0.2)
        {
            InitStats(100, 100, 25);

            SetDamageType(ResistanceType.Physical, 0);
            SetDamageType(ResistanceType.Fire, 0);
            SetDamageType(ResistanceType.Cold, 0);
            SetDamageType(ResistanceType.Poison, 0);
            SetDamageType(ResistanceType.Energy, 0);

            Hits = HitsMax;
                        
            Body = 0x190;
            Race = Race.Human;
            Name = "a Mannequin";
            Hue = 1828;
            Direction = Direction.South;
            
        }

        public override bool CanBeDamaged()
        {
            return false;
        }
        public Mannequin2( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
    }
}
