using System;
using Server;
using Server.Gumps;
using Server.Items;
using Server.SkillHandlers;
using System.Collections.Generic;
using System.Linq;
using Server.Misc;
using Server.Commands;
using Server.Mobiles;
using Server.Targeting;
using Server.Targets;

namespace Server.Gumps
{
    public class CommandGump : BaseGump
    {

        public static void Initialize()
        {
            CommandSystem.Register("CommandGump",AccessLevel.Administrator, new CommandEventHandler(CommandGump_OnCommand));
        }

	[Usage("CommandGump")]
	[Description("Displays a gump of various admin commands")]
	public static void CommandGump_OnCommand(CommandEventArgs e)
	{
	    if(e.Mobile is PlayerMobile)
	    {
		PlayerMobile pm = (PlayerMobile)e.Mobile;
            	pm.SendGump(new CommandGump(pm));
		//pm.SendMessage("Is the Gump sending?");
	    }
	}

	private bool Vertical = false;
	private PlayerMobile Admin;

	public CommandGump(PlayerMobile pm)
	    : base(pm, 50, 50)
	{
	    Admin = pm;
	    AddGumpLayout();
	}

	public override void AddGumpLayout()
	{
	    int TotalCommands = 7;
	    int width;
	    int height;


	    if (!Vertical)
	    {
	    	width = 650;
		height = 50;
	    }
	    else
	    {
	    	width = 100;
		height = 400;
	    }

	    AddBackground(0, 0, width, height, 0x6DB);

	    string[] commands = { "teleport", "hide", "bless", "kill", "remove", "props"};

	    if (!Vertical)
	    {
		for( int j = 0; j < commands.Length; j++)
		{
		    int x = width / TotalCommands;
		    AddHtml( 35 + (j * x), 15, 250, 20, FormatGump( commands[j].ToString(), "#F0F8FF"), false, false);
		}

		for( int i = 0; i < (TotalCommands - 1); i++)
		{
		    int space = width / TotalCommands;
		    AddButton(10 + (i * space), 15, 0x4B9, 0x4BA, i + 1, GumpButtonType.Reply, 0);
		}
		AddButton(width - 25, 15, 0x15E2, 0x15E6, 10, GumpButtonType.Reply, 0);
	    }
	    else
	    {

		for( int j = 0; j < commands.Length; j++)
		{
		    int y = height / TotalCommands;
		    AddHtml(35, 5 + (y * j), 250, 20, FormatGump( commands[j].ToString(), "#F0F8FF"), false, false);
		}

		for( int i = 0; i < (TotalCommands -1); i++)
		{
		    int space = height / TotalCommands;
		    AddButton(10, 10 + (i * space), 0x4B9, 0x4BA, i + 1, GumpButtonType.Reply, 0);
		}
		AddButton(5, height - 25, 0x15E0, 0x15E4, 10, GumpButtonType.Reply, 0);
	    }
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
		//Admin.Target = new MoveTarget(Admin);
		Admin.Target = new TeleTarget(Admin);
		Refresh();
	    }


	    if (button == 2)
	    {
		if (!Admin.Hidden)
		    Admin.Hidden = true;
		else
		    Admin.Hidden = false;
		Refresh();
	    }

	    if (button == 3)
	    {
		if (!Admin.Blessed)
		{
		    Admin.Blessed = true;
		    Admin.SendMessage("You are invulnerable.");
		}
		else
		{
		    Admin.Blessed = false;
		    Admin.SendMessage("You are vulnerable.");
		}

		Refresh();
	    }

	    if (button == 4)
	    {
		Admin.Target = new KillTarget();

		Refresh();
	    }

	    if (button == 5)
	    {
		Admin.Target = new RemoveTarget();

		Refresh();
	    }

	    if (button == 6)
	    {
		Admin.Target = new PropsTarget();

		Refresh();
	    }
		
	    if (button == 10)
	    {
		if (!Vertical)
		    Vertical = true;
		else
		    Vertical = false;

		Refresh();
	    }
	}

	private class TeleTarget : Target
	{
	    private readonly object m_Object;
	    public TeleTarget(object o)
	    	: base (-1, true, TargetFlags.None)
	    {
	    	this.m_Object = o;
	    }

	    protected override void OnTarget(Mobile from, object o)
	    {
	    	IPoint3D p = o as IPoint3D;

	    	if( p != null)
	    	{
		     if (p is Item)
		    	((Item)p).GetWorldTop();

		    if (this.m_Object is Mobile)
		    {
		    	Mobile m = (Mobile)this.m_Object;

		    	if (!m.Deleted)
		    	{

			    m.MoveToWorld(new Point3D(p), from.Map);
			    from.Target = new TeleTarget(from);

			    var fromLoc = from.Location;
			    var toLoc = new Point3D(p);

			    from.Location = toLoc;
			    from.ProcessDelta();

			    if (!from.Hidden)
			    {
				Effects.SendLocationParticles( EffectItem.Create(fromLoc, from.Map, EffectItem.DefaultDuration), 0x3728, 10, 10, 2023);
				Effects.SendLocationParticles(EffectItem.Create(toLoc, from.Map, EffectItem.DefaultDuration), 0x3728, 10, 10, 5023);
				from.PlaySound(0x1FE);
			    }
		    	}
		    	else
			    from.SendMessage("Invalid Mobile.");
		    }
	    	}
	    }
	}
	private class KillTarget : Target
	{
	    public KillTarget()
		: base( -1, true, TargetFlags.None)
	    {
	    }

	    protected override void OnTarget(Mobile from, object o)
	    {
		if ( from != null && o != null)
		{
		    if (o is Mobile)
		    {
			Mobile m = o as Mobile;
			if (!m.Blessed)
			{
			    m.Kill();
			    from.SendMessage( m.Name + " has been killed.");
			}
			else
			    from.SendMessage( m.Name + " is invulnerable.");
		    }
		    else
		    	from.SendMessage( "That is an invalid target.");
		}
	    }
	}
	private class PropsTarget : Target
	{
	    public PropsTarget()
	   	: base ( -1, true, TargetFlags.None)
	    {
	    }

	    protected override void OnTarget(Mobile from, object o)
	    {
		if (from != null && o != null)
		{
		    from.SendGump( new PropertiesGump(from, o));
		}
	    }
	}

	private class RemoveTarget : Target
	{
	    public RemoveTarget()
		: base( -1, true, TargetFlags.None)
	    {
	    }

	    protected override void OnTarget(Mobile from, object o)
	    {
		if ( from != null && o != null)
		{
		    if (o is Mobile)
		    {
			Mobile m = o as Mobile;
			m.Delete();
			from.SendMessage( "The Mobile has been deleted.");

		    }
		    else if (o is Item)
		    {
			Item i = o as Item;
			i.Delete();
			from.SendMessage( "The item has been deleted.");
		    }
		    else
		    	from.SendMessage( "That is an invalid target.");
		}
	    }
	}
    }
}