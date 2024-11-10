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
	public class KillYetiQuest : BaseQuest
	{
		//The player will have a delay before they can redo quest again
		public override TimeSpan RestartDelay { get { return TimeSpan.FromMinutes(1440); } }

		//This is the Quest Title the player sees at the top of the Gump
		public override object Title{ get{ return "The Hunt For Bigfoot!"; } }
		//This tells the story of the quest
		public override object Description { get { return "(This is a repeatable quest, you can accept the quest again, 24 hours after completion!)<BR><BR>  Pardon me friend..<BR><BR>  My name is Tom, I am the head investigator from the Moonglow Cryptozoology Dept.<BR><BR> I have been hunting down the elusive Bigfoot! In my adventures I have found that there are many different species of Bigfoot! I am ivestigating the reports of the Northern Yeti!!<BR><BR> *Tom picks up a book and fumbles through the pages*<BR><BR>  Ah yes, here it is, The Yeti or as some call it, the 'Abominable Snowman' is often described as being a large, bipedal ape-like creature that is covered with brown, grey, or white hair, and it is sometimes depicted as having large, sharp teeth & are found mostly in the Northern Regions Of Sosaria.<BR><BR>  Lore describes three main varieties of Yetis. The Nyalmo, which has black fur and is the largest and fiercest, the Chuti Yeti that has a pure white fur, and the Rang Shim Bombo, which has reddish-brown fur.<BR><BR> If you are up for it, I will reward any adventurer who can bring me proof of these 3 variants! "; } }
		//This decides how the npc reacts in text the player refusing the quest
		public override object Refuse{ get{ return "Very well then, I will leave you be."; } }
		//This is what the npc says when the player returns without completing the objective(s)
		public override object Uncomplete{ get{ return "Keep searching friend, I will be here at the Inn if you find anything!"; } }
		//This is what the Quest Giver says when the player completes the quest.
		public override object Complete{ get{ return "Oh my! These are perfect! I cannot wait to show the other memebers at the Cryptozoology Dept! Here is your reward!"; } }

		public KillYetiQuest() : base()
		{
			//Slay Objective #1
			AddObjective(new ObtainObjective(typeof(ChutiHead), "Chuti Yeti Head", 1, 0x1545));
			AddObjective(new ObtainObjective(typeof(NyalmoHead), "Nyalmo Yeti Head", 1, 0x1545));
			AddObjective(new ObtainObjective(typeof(RangShimBomboHead), "Rang Shim Bombo Yeti Head", 1, 0x1545));
			
			
			//AddReward(new BaseReward(typeof(GoldenQuestTicket), 100, "Golden Quest Ticket"));
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
