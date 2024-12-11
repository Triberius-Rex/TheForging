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
	public class Kill100Daemon : BaseQuest
	{
		//The player will have a delay before they can redo quest again
		public override TimeSpan RestartDelay { get { return TimeSpan.FromMinutes(1440); } }

		//This is the Quest Title the player sees at the top of the Gump
		public override object Title{ get{ return "Kill 100 Daemons Daily Quest"; } }
		//This tells the story of the quest
		public override object Description { get { return "Hail Adventurer!<BR>To combat the ever growing presence of this new evil that is beginning to plague our world. Lord Blackthorn has decreed that bounties shall be set on these foul beasts! Hey! You!, in the smelly tunic! Do you have what it takes to become a hero!?<BR><BR>Kill 100 daemon and return to me for your reward!<BR>"; } }
		//This decides how the npc reacts in text the player refusing the quest
		public override object Refuse{ get{ return "Awe! scared of a few daemons? The off with you!"; } }
		//This is what the npc says when the player returns without completing the objective(s)
		public override object Uncomplete{ get{ return "You need to kill more daemons!"; } }
		//This is what the Quest Giver says when the player completes the quest.
		public override object Complete{ get{ return "Good Job Adventurer! Heres Your Reward!"; } }

		public Kill100Daemon() : base()
		{
			//Slay Objective #1
			AddObjective(new SlayObjective(typeof(Daemon),"Daemon",100));
			
			//AddReward( new BaseReward( typeof( GoldenQuestTicket ), 50, "Daily Golden Quest Ticket" ) );
			AddReward(new BaseReward(typeof(HeritageSovereign), 125, "Sovereigns"));
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
