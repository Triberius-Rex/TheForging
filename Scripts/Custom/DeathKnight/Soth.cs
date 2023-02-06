////  D&D style Death Knight by Pappa Smurf                                               ////
////  Thanks to the Following                                                             ////
////  David from RunUO.com for giving me an interest in Timers                            ////
////  oO_Sithid_Oo from RunUO.com for proof reading and pointing out my mistakes          ////  
////  and helping with the timer                                                          ////  
////  TMSTKSBK for putting up with me complaining about my timers not working             ////
////  The RunUO Dev Team for creating RunUO without which this script would be pointless  ////
////  A_Li_N from RunUO for suggesting using a DateTime Method instead of a timer         ////  
////  Updated on 11/16/2008 to include new Abilities and Updates for RunUO 2.0 SVN 301    ////
////  Damage and Armor Rating calcuations,  Additional Loot Drops added.                  //// 
//////////////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////////////////////


using System;
using Server.Mobiles;
using Server.Spells.Necromancy;
using Server;
using System.Collections;
using Server.Items;
using Server.Misc;
using Server.Network;
using Server.Targeting;
using Server.Spells;
using Server.Engines.CannedEvil;


namespace Server.Mobiles
{

    [CorpseName("corpse of Lord Soth")]
	public class LordSoth : BaseChampion
	{
        public override ChampionSkullType SkullType { get { return ChampionSkullType.Lust; } }

        public override WeaponAbility GetWeaponAbility()
        {
            switch (Utility.Random(2))
            {
                default:
                case 1: return WeaponAbility.DoubleStrike;
                case 2: return WeaponAbility.ArmorIgnore;
            }
        }
        
        private DateTime m_NextPowerWordKillTime;
        [CommandProperty(AccessLevel.GameMaster)]
        public DateTime NextPowerWordKillTime
        {
            get
            {
                return m_NextPowerWordKillTime;
            }
            set
            {
                m_NextPowerWordKillTime = value;

            }
            
        }

        public override bool ClickTitle { get { return false; } }
		
        [Constructable]
        public LordSoth(): base(AIType.AI_Melee) 
 		{
            Name = "Soth";
			Title = "Knight of the Black Rose";
            Body = 744;
            Hue = 0x4001;
            SetStr(488, 620);
            SetDex(121, 170);
            SetInt(498, 657);

            SetHits(12000 , 15000);
            SetStam(102, 300);

            SetDamage(10, 20);

            SetDamageType(ResistanceType.Physical, 50);
            SetDamageType(ResistanceType.Energy, 50);
            SetResistance(ResistanceType.Physical, 60, 70);
            SetResistance(ResistanceType.Fire, 60, 70);
            SetResistance(ResistanceType.Cold, 60, 70);
            SetResistance(ResistanceType.Poison, 60, 70);
            SetResistance(ResistanceType.Energy, 60, 70);
            
			SetSkill( SkillName.Parry, 150.0 );
			SetSkill( SkillName.Swords, 150.0 );
			SetSkill( SkillName.Tactics, 150.0 );
            SetSkill( SkillName.Anatomy, 150.0 );
            SetSkill( SkillName.Magery, 150.0);
            SetSkill( SkillName.SpiritSpeak, 150.0);
            SetSkill( SkillName.Healing, 150.0);
            SetSkill(SkillName.EvalInt, 150.0);
            SetSkill(SkillName.MagicResist, 250.0);
            SetSkill(SkillName.Chivalry, 500.0);


            Fame = 25000;
            Karma = -25000;           

            AddItem(new HellishSightLenses());
            AddItem(new BlackRoseArms());           
            AddItem(new BlackRoseChest());
            AddItem(new BlackRoseGloves());
            AddItem(new BlackRoseLegs());           
            AddItem(new ThighBoots());             
            AddItem(new UnHolysword());
            AddItem(new BlackRoseHelm());
            AddItem(new BlackRoseShield());
            
			PackGold( 200, 250 );

            new Nightmare().Rider = this;

		}
        public override Type[] UniqueList
        {
            get
            {
                return new Type[] { typeof(FangOfRactus) };
            }
        }
        public override Type[] SharedList
        {
            get
            {
                return new Type[]
                {
                    typeof(EmbroideredOakLeafCloak),
                    typeof(DjinnisRing),
                    typeof(DetectiveBoots),
                    typeof(GauntletsOfAnger)
                };
            }
        }
        public override Type[] DecorativeList
        {
            get
            {
                return new Type[] { typeof(SwampTile), typeof(MonsterStatuette) };
            }
        }
        public override MonsterStatuetteType[] StatueTypes
        {
            get
            {
                return new MonsterStatuetteType[] { MonsterStatuetteType.Slime };
            }
        }
        public override bool OnBeforeDeath()
        {
            IMount mount = this.Mount;

            if (mount != null)
                mount.Rider = null;

            if (mount is Mobile)
                ((Mobile)mount).Delete();

            return base.OnBeforeDeath();
        }

        public override void GenerateLoot()
        {
            AddLoot(LootPack.UltraRich, 2);
            AddLoot(LootPack.FilthyRich, 2);
            AddLoot(LootPack.MedScrolls, 2);
            {
                switch (Utility.Random(25))
                {
                    case 0: PackItem(new UnHolysword()); break;
                }
            }

        }

        public override bool AlwaysMurderer { get { return true; } }
        public override bool AutoDispel { get { return true; } }
        public override double AutoDispelChance { get { return 1.0; } }
        public override bool BardImmune { get { return !Core.SE; } }
        public override bool Unprovokable { get { return Core.SE; } }
        public override bool Uncalmable { get { return Core.SE; } }
		public override Poison PoisonImmune{ get{ return Poison.Lethal; } }   

        public override void OnDamage(int amount, Mobile from, bool willKill)
        {
            if (from != null && !willKill && amount > 5 && from.Player && 5 > Utility.Random(10))
            {
                string[] toSay = new string[]
				{
					"I do not fear Death, For Death and I are old friends",
					"Fight me with Honor, Die like a Man!",
					"{0}, You should retreat your skills are no match for mine",
					"I've walked the world in undeath since the Cataclysm and you think you can defeat me?",    
                    "You know not who or what I am, if you did you wouldn't be fighting still, you'd be running." 
				};
                this.Say(true, String.Format(toSay[Utility.Random(toSay.Length)], from.Name));
            }

            base.OnDamage(amount, from, willKill);
        }
        
        public void PowerWordKill()
        {
            ArrayList list = new ArrayList();

            foreach (Mobile m in this.GetMobilesInRange(1))
            {
                if (m == this || !CanBeHarmful(m))
                    continue;

                if (m.Player)
                    list.Add(m);
            }

            foreach (Mobile m in list)
            {
                m.SendMessage("The Death Knight has a remarkable power over death, the ability to kill with a single word.....too bad you were listening!"); 
                DoHarmful(m);                
                m.FixedParticles(0x36CB, 1, 9, 9911, 67, 5, EffectLayer.Head);
                int toPowerWordKill = Utility.RandomMinMax(50000, 60000);
                m.Damage(toPowerWordKill, this);
            }
            NextPowerWordKillTime = DateTime.Now + TimeSpan.FromMinutes(15.0);
        }

        public void SpawnUndeadArmy(Mobile target)
        {
            

            Map map = this.Map;

            if (map == null)
                return;

            int knights = 0;

            foreach (Mobile m in this.GetMobilesInRange(10))
            {
                if (m is UndeadKnight || m is WailingBanshee)
                    ++knights;

                
            }

            if (knights < 1)
            {
                PlaySound(0x567);

                int newUndead = Utility.Random(13);

                for (int i = 0; i < newUndead; ++i)
                {
                    BaseCreature skeleton;

                    switch (Utility.Random(2))
                    {
                        default:
                        case 0: skeleton = new WailingBanshee(); break;
                        case 1: skeleton = new UndeadKnight(); break;
                                               
                       
                    }

                    skeleton.Team = this.Team;

                    bool validLocation = false;
                    Point3D loc = this.Location;

                    for (int j = 0; !validLocation && j < 10; ++j)
                    {
                        int x = X + Utility.Random(3) - 1;
                        int y = Y + Utility.Random(3) - 1;
                        int z = map.GetAverageZ(x, y);

                        if (validLocation = map.CanFit(x, y, this.Z, 16, false, false))
                            loc = new Point3D(x, y, Z);
                        else if (validLocation = map.CanFit(x, y, z, 16, false, false))
                            loc = new Point3D(x, y, z);
                    }

                    skeleton.MoveToWorld(loc, map);
                    skeleton.Combatant = target;
                }
            }
        }

        public override void OnThink()
        {
            if (Hits < 250 && DateTime.Now >= m_NextPowerWordKillTime)            
                PowerWordKill();
                
           
        }

        public void DoSpecialAbility(Mobile target)
        {
            if (Hits < 500 ) 
                SpawnUndeadArmy(target);
         
        }

        public override void OnGotMeleeAttack(Mobile attacker)
        {
            base.OnGotMeleeAttack(attacker);
            DoSpecialAbility(attacker);
        }

        public override void OnGaveMeleeAttack(Mobile defender)
        {
            base.OnGaveMeleeAttack(defender);
            DoSpecialAbility(defender);
        }

             
		public LordSoth( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}