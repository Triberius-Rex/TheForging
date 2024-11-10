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
	public class KillPolarBear : BaseQuest
	{
		//The player will have a delay before they can redo quest again
		public override TimeSpan RestartDelay { get { return TimeSpan.FromMinutes(1440); } }

		//This is the Quest Title the player sees at the top of the Gump
		public override object Title{ get{ return "Hunting The Alpine's"; } }
		//This tells the story of the quest
		public override object Description { get { return "Uhmm.. Hello! Excuse Me! But...<BR><BR>  I have been tasked to crafting fur boots for my shop, and I like to use the pristine hides that you get from skinning Alpine Polar Bears! <BR><BR> My old supplier seems to have gone off on a new route! I have not seen him in months! Would you help me gather some?<BR><BR>  Gather 50 Pristine Polar Bear Hide and Bring Them To Brijit!<BR><BR>(This is a repeatable quest, it can be done again 24 hours after completion.)"; } }
		//This decides how the npc reacts in text the player refusing the quest
		public override object Refuse{ get{ return "Very Well, I will be here if you change your mind"; } }
		//This is what the npc says when the player returns without completing the objective(s)
		public override object Uncomplete{ get{ return "You need to kill more alpha!"; } }
		//This is what the Quest Giver says when the player completes the quest.
		public override object Complete{ get{ return "Good Job Adventurer! Heres Your Reward!"; } }

		public KillPolarBear() : base()
		{
			//Slay Objective #1
			AddObjective(new ObtainObjective(typeof(AlphaPolarFur), "Pristine Polar Bear Hide", 50, 0x1875));
			
			//AddReward( new BaseReward(typeof(GoldenQuestTicket), 50, "Daily Golden Quest Tickets" ) );
			AddReward(new BaseReward(typeof(HeritageSovereign), 15, "Sovereigns"));
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
