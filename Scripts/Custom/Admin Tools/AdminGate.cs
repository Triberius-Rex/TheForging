#region References
using System;

using Server.Factions;
using Server.Gumps;
using Server.Misc;
using Server.Mobiles;
using Server.Multis;
using Server.Network;
using Server.Regions;
using Server.Spells;
#endregion

namespace Server.Items
{
    public class AdminGate : Moongate
    {
	private bool m_StaffOnly = true;
	private AdminGate m_LinkedGate;
	private InternalTimer m_Timer;

	public override bool ShowFeluccaWarning { get { return false; } }
	public override bool TeleportPets { get { return true; } }

        [CommandProperty(AccessLevel.GameMaster)]
	public bool StaffOnly 
	{ 
	    get { return m_StaffOnly; } 
	    set { m_StaffOnly = value; }
	}

        [CommandProperty(AccessLevel.GameMaster)]
	public AdminGate LinkedGate 
	{ 
	    get { return m_LinkedGate; } 
	    set { m_LinkedGate = value; }
	}

	[Constructable]
	public AdminGate()
	    : base(Point3D.Zero, null)
	{
	    Name = "Golden Moongate";
	    Dispellable = false;
	    Hue = 2503;

	    if(m_Timer == null)
	    	m_Timer = new InternalTimer(this);

	    m_Timer.Start();
	}

	[Constructable]
	public AdminGate(Point3D target, Map targetMap)
	    : base(target, targetMap)
	{
	    Name = "Golden Moongate";
	    Dispellable = false;
	    Movable = false;
	    Light = LightType.Circle300;
	    Hue = 2503;

	    Target = target;
	    TargetMap = targetMap;

	    if(m_Timer == null)
	    	m_Timer = new InternalTimer(this);

	    m_Timer.Start();
	}

	public AdminGate(Serial serial)
	    : base(serial)
	{ }


	public override void OnDoubleClick(Mobile from)
	{
	    if (StaffOnly && !from.IsStaff())
	    	from.SendMessage("You cannot access this gate."); 
	    else
	    	base.OnDoubleClick(from);    
	}


	public override void UseGate(Mobile m)
	{

	    if (StaffOnly && !m.IsStaff())
	    	m.SendMessage("You cannot access this gate."); 
	    else
	    	base.UseGate(m);    
	}

	public override void Serialize(GenericWriter writer)
	{
	    base.Serialize(writer);
	    writer.Write(1); // version

	    writer.Write(m_StaffOnly);
	    writer.Write(m_LinkedGate);
	}

	public override void Deserialize(GenericReader reader)
	{
	    base.Deserialize(reader);

	    m_StaffOnly = reader.ReadBool();
	    m_LinkedGate = reader.ReadItem() as AdminGate;
	    m_Timer = new InternalTimer(this);
	}

	private class InternalTimer : Timer
	{
	    private readonly Item m_Item;

	    public InternalTimer(Item item)
		: base(TimeSpan.FromSeconds(30.0))
	    {
		Priority = TimerPriority.OneSecond;
		m_Item = item;
	    }

	    protected override void OnTick()
	    {
                    m_Item.Delete();
	    }
	}
    }
}