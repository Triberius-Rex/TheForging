using Server;
using Server.Items;
using Server.Mobiles;

namespace Bittiez.CustomLoot
{
	public static class CustomLoot
	{
		public static void Initialize()
		{
			EventSink.CreatureDeath += EventSink_CreatureDeath;
		}

		private static void EventSink_CreatureDeath(CreatureDeathEventArgs e)
		{
			if (e.Creature == null) return;

			//Add 1 gold to all horses.
			if (e.Creature is Mongbat)
			{
				e.Corpse.AddItem(new Gold(1));
			}


			/*if (e.Creature.Str > 300) //Is it a strong creature? ¯\_(ツ)_/¯
			{
				if (Server.RandomImpl.NextDouble() > 0.2) //~ 80% chance
				{
					e.Corpse.AddItem(new BraceletOfHealth());
				}
			}*/

			if (e.Killer != null)
				if (e.Killer.LastKiller != e.Creature) //Did the player die to this creature? If not, lets give him a bonus
				{
					e.Corpse.AddItem(new Gold(100));
				}
		}
	}
}
