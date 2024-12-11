//=================================================
//This script was created by Gizmo's Uo Quest Maker
//This script was created on 1/6/2020 7:14:32 PM
//=================================================
using System;
using Server;
using Server.Items;
using Server.Mobiles;
using System.Collections;
using System.Collections.Generic;

namespace Server.Engines.Quests
{
	public class Omerc : MondainQuester
	{
		private List<SBInfo> m_SBInfos = new List<SBInfo>();
		protected override List<SBInfo> SBInfos{ get { return m_SBInfos; } }
        public override bool DisallowAllMoves{ get{ return true; } }

		public override Type[] Quests
		{
			get{ return new Type[]
			{
				typeof( Kill100EElementals )
			};}
		}

		[Constructable]
		public Omerc() : base("Omerc", "The Elemental Slayer [?]")
		{
			new Horse().Rider = this;
			InitBody();
		}
		public Omerc(Serial serial) : base(serial)
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

		public override void InitBody()
		{
			InitStats(100, 100, 100);
			Female = false;
			Race = Race.Human;
			base.InitBody();
		}
		public override void InitOutfit()
		{
			AddItem( new DragonChest() );
			AddItem( new DragonArms() );
			AddItem( new DragonGloves() );
			AddItem( new DragonLegs() );
			AddItem( new Cloak() );
			AddItem( new ThighBoots() );
		}
	}
}