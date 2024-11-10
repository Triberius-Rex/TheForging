using System;
using Server.Mobiles;
using Server.Targeting;

namespace Server.Targets
{
    public class AdminRunebookPlayerTarget : Target
    {
	Point3D TargetLocation;
	Map TargetMap;

	public AdminRunebookPlayerTarget(Point3D loc, Map map)
	    : base( 12, false, TargetFlags.None)
	{
	    TargetLocation = loc;
	    TargetMap = map;
	}

	protected override void OnTarget(Mobile from, object targeted)
	{
	    if (targeted is PlayerMobile && TargetLocation != Point3D.Zero && TargetMap != null)
	    {
		PlayerMobile pm = (PlayerMobile)targeted;

		pm.MoveToWorld(TargetLocation, TargetMap);
		pm.SendMessage("You have been sent to a new location though divine intervention!");
	    }
	}
    }
}