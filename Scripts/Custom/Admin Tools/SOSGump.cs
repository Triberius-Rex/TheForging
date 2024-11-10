using System;
using Server;
using Server.Commands;
using Server.Mobiles;

namespace Server.Gumps
{
    public class SOSGump : BaseGump
    {
        public static void Initialize()
        {
            CommandSystem.Register("SOSGump",AccessLevel.Administrator, new CommandEventHandler(SOSGump_OnCommand));
        }

	[Usage("SOSGump")]
	[Description("Can full heal, cure, and bless yourself")]
	public static void SOSGump_OnCommand(CommandEventArgs e)
	{
	    if(e.Mobile is PlayerMobile)
	    {
		PlayerMobile pm = (PlayerMobile)e.Mobile;
            	pm.SendGump(new SOSGump(pm));
		//pm.SendMessage("Is the Gump sending?");
	    }
	}

	PlayerMobile User;
	public SOSGump(PlayerMobile pm)
	    : base(pm, 50, 50)
	{
	    User = pm;
	    AddGumpLayout();
	}
	public override void AddGumpLayout()
	{
	    AddBackground(0, 0, 100, 100, 0x1400);

	    AddButton(10, 15, 0x16CE, 0x16CD, 1, GumpButtonType.Reply, 0);
	    AddHtml(35, 15, 250, 20, FormatGump( "Full Heal", "#F0F8FF"), false, false);
	    AddButton(10, 35, 0x16CE, 0x16CD, 2, GumpButtonType.Reply, 0);
	    AddHtml(35, 35, 250, 20, FormatGump( "Cure", "#F0F8FF"), false, false);
	    AddButton(10, 55, 0x16CE, 0x16CD, 3, GumpButtonType.Reply, 0);
	    AddHtml(35, 55, 250, 20, FormatGump( "Bless", "#F0F8FF"), false, false);
	}

	public string FormatGump(string str, string color)
	{
	    if( color == null)
		return String.Format("<div align=left>{0}</div>", str);
	    else
	    	return String.Format("<BASEFONT COLOR={1}><dic align=left>{0}</div>", str, color);

	}

	public override void OnResponse(RelayInfo info)
	{
	    int button = info.ButtonID;

	    if (button == 1)
	    {
		if (User.Hits < User.HitsMax)
	 	{
		    User.Hits = User.HitsMax;
                    User.FixedParticles(0x376A, 9, 32, 5030, EffectLayer.Waist);
                    User.PlaySound(0x202);
		}
		Refresh();
	    }

	    if (button == 2)
	    {
		if (User.Poison != null)
		    User.Poison = null;

                User.FixedParticles(0x373A, 10, 15, 5012, EffectLayer.Waist);
                User.PlaySound(0x1E0);

		Refresh();
	    }

	    if (button == 3)
	    {
		if (!User.Blessed)
		    User.Blessed = true;
		else
		    User.Blessed = false;

		Refresh();
	    }
	}

    }
}