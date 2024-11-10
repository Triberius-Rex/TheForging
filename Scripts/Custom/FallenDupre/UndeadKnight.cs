using System;
using System.Collections;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "an Undead Knights corpse" )]
	public class UndeadKnight : BaseCreature
	{
		[Constructable]
		public UndeadKnight() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = NameList.RandomName ("Undead Knights");
			Body = 744;
			BaseSoundID = 451;
            Hue = 1;

			SetStr( 500, 750 );
			SetDex( 76, 95 );
			SetInt( 36, 60 );

			SetHits( 400, 600 );

			SetDamage( 8, 18 );

			SetDamageType( ResistanceType.Physical, 75, 85 );
			SetDamageType( ResistanceType.Cold, 60 );
            SetResistance( ResistanceType.Physical, 35, 45 );
			SetResistance( ResistanceType.Fire, 20, 30 );
			SetResistance( ResistanceType.Cold, 50, 60 );
			SetResistance( ResistanceType.Poison, 20, 30 );
			SetResistance( ResistanceType.Energy, 30, 40 );

			SetSkill( SkillName.MagicResist, 65.1, 80.0 );
			SetSkill( SkillName.Tactics, 85.1, 100.0 );
			SetSkill( SkillName.Wrestling, 85.1, 95.0 );

			Fame = 3000;
			Karma = -3000;

			VirtualArmor = 40;

            AddItem(new BoneHelm());            
            AddItem(new BoneGloves());
            AddItem(new MetalKiteShield());            
            AddItem(new VikingSword());
            AddItem(new BoneChest());
            AddItem(new HoodedShroudOfShadows());
           

            new Nightmare().Rider = this;

			switch ( Utility.Random( 6 ) )
			{
				case 0: PackItem( new PlateArms() ); break;
				case 1: PackItem( new PlateChest() ); break;
				case 2: PackItem( new PlateGloves() ); break;
				case 3: PackItem( new PlateGorget() ); break;
				case 4: PackItem( new PlateLegs() ); break;
				case 5: PackItem( new PlateHelm() ); break;
			}

			PackItem( new Scimitar() );
			PackItem( new WoodenShield() );
		}

        public override bool AlwaysMurderer { get { return true; } }
        public override bool BardImmune { get { return true; } }
        public override Poison PoisonImmune { get { return Poison.Lethal; } }
        public override int TreasureMapLevel { get { return 3; } }

        public override bool OnBeforeDeath()
        {
            Body = 57;
            Hue = 0;

            IMount mount = this.Mount;

            if (mount != null)
                mount.Rider = null;

            if (mount is Mobile)
                ((Mobile)mount).Delete();

            return base.OnBeforeDeath();
        }

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Rich,2 );
			AddLoot( LootPack.Meager );
		}

		public UndeadKnight( Serial serial ) : base( serial )
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