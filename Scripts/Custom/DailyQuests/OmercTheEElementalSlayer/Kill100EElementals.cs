//=================================================
//This script was created by Gizmo's Uo Quest Maker
//This script was created on 1/6/2020 7:12:32 PM
//=================================================

using System;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.Engines.Quests
{
	public class Kill100EElementals : BaseQuest
	{
		//The player will have a delay before they can redo quest again
		public override TimeSpan RestartDelay { get { return TimeSpan.FromMinutes(1440); } }

		//This is the Quest Title the player sees at the top of the Gump
		public override object Title{ get{ return "Kill 100 Earth Elementals Daily Quest"; } }
		//This tells the story of the quest
		public override object Description { get { return "Hail Adventurer!<BR><BR>Kill 100 Earth Elementals and return to me for your reward!<BR>"; } }
		//This decides how the npc reacts in text the player refusing the quest
		public override object Refuse{ get{ return "Awe! scared of few Earth Elementals? Then off with you!"; } }
		//This is what the npc says when the player returns without completing the objective(s)
		public override object Uncomplete{ get{ return "You need to kill more elementals!"; } }
		//This is what the Quest Giver says when the player completes the quest.
		public override object Complete{ get{ return "Good Job Adventurer! Heres Your Reward!"; } }

		public Kill100EElementals() : base()
		{
			//Slay Objective #1
			AddObjective(new SlayObjective(typeof(EarthElemental),"Earth Elemental",100));
			
			//AddReward( new BaseReward( typeof( GoldenQuestTicket ), 25, "Daily Golden Quest Ticket" ) );
			AddReward(new BaseReward(typeof(HeritageSovereign), 100, "Sovereigns"));
		}

		public override void GiveRewards()
		{
			base.GiveRewards();
		}

		public override bool CanOffer()
		{
			return true;
		}
	}
}
