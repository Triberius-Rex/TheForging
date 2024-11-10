using System;
using Server.Engines.Craft;
using Server.Mobiles;

namespace Server.Items
{
    public class AdminToken : Item
    {
	private Timer m_Timer;
	private DateTime m_EndTime;

	public DateTime EndTime
	{
	    get { return m_EndTime; }
	    set { m_EndTime = value; }
	}

	public Timer Timer
	{
	    get { return m_Timer; }
	    set { m_Timer = value; }
	}

	public enum Level
	{
	    Player = 0,
	    VIP = 1,
	    Counselor = 2,
	    Decorator = 3,
	    Spawner = 4,
	    GameMaster = 5,
	    Seer = 6,
	    Administrator = 7,
	    Developer = 8,
	    CoOwner = 9,
	    Owner = 10,
	    None = 11
	}

	private Level m_Level = Level.None;
	public Level StaffLevel
	{
	    get { return m_Level; }
	    set { m_Level = value; InvalidateProperties(); }
	}

        [Constructable]
        public AdminToken()
            : base(0x23C) //0xF8B)
        {
	    Name = "admin token";
            Weight = 1.0;
	    LootType = LootType.Blessed;
        }

        public AdminToken(Serial serial)
            : base(serial)
        {
        }

	public override void OnDoubleClick(Mobile m)
	{
	    if (m_Level == Level.None && m.AccessLevel != AccessLevel.Player)
	    {
		
		switch(m.AccessLevel)
		{
		    case AccessLevel.Owner:
			m_Level = Level.Owner;
			break;

		    case AccessLevel.CoOwner:
			m_Level = Level.CoOwner;
			break;

		    case AccessLevel.Developer:
			m_Level = Level.Developer;
			break;

		    case AccessLevel.Administrator:
			m_Level = Level.Administrator;
			break;

		    case AccessLevel.Seer:
			m_Level = Level.Seer;
			break;

		    case AccessLevel.GameMaster:
			m_Level = Level.GameMaster;
			break;

		    case AccessLevel.Spawner:
			m_Level = Level.Spawner;
			break;

		    case AccessLevel.Counselor:
			m_Level = Level.Counselor;
			break;

		    case AccessLevel.VIP:
			m_Level = Level.VIP;
			break;
		}
	    }

	    if (m.AccessLevel != AccessLevel.Player && m_Level != Level.None)
	    {
		AdminToken token = FindToken(m);
		int IntLevel = (int)token.StaffLevel;
		Server.AccessLevel tokenLevel = (AccessLevel)Enum.ToObject(typeof(AccessLevel), IntLevel);
		m.AccessLevel = AccessLevel.Player;
		m_EndTime = DateTime.UtcNow + TimeSpan.FromMinutes(5);
		if (m is PlayerMobile)
		{
		    PlayerMobile pm = m as PlayerMobile;
		    DoTimer(pm);
		}
		m.SendMessage( "You are now in Player Mode.");
	    }
	    else if (m.AccessLevel == AccessLevel.Player && m_Level != Level.None)
	    {
		AdminToken token = FindToken(m);
		int IntLevel = (int)token.StaffLevel;
		Server.AccessLevel tokenLevel = (AccessLevel)Enum.ToObject(typeof(AccessLevel), IntLevel);
		m.AccessLevel = tokenLevel;
		m.SendMessage( "You are now in Admin Mode.");
		if (m_Timer != null)
		{
		    m_Timer.Stop();
		    m_Timer = null;
		}
	    }
	}

	public void SetLevel(Level level)
	{
	    m_Level = level;
	}

	private static AdminToken FindToken(Mobile from)
	{
	    if ((from == null) || from.Backpack == null)
		return null;

	    if (from.Holding is AdminToken)
	    {
		return (AdminToken)from.Holding;
	    }

	    return from.Backpack.FindItemByType<AdminToken>();
	}

	public void DoTimer(PlayerMobile pm)
	{
	    if(pm.AccessLevel == AccessLevel.Player)
	    {
		if (m_Timer != null)
		{
		    m_Timer.Stop();
		    m_Timer = null;
		}

		m_Timer = new InternalTimer(this, pm, TimeSpan.FromSeconds(1), m_EndTime);
		m_Timer.Start();
	    }
	}

	public override void OnDelete()
	{
	    base.OnDelete();

	    if(m_Timer != null)
		m_Timer.Stop();
	}

        public override void AddNameProperties(ObjectPropertyList list)
        {
            base.AddNameProperties(list);

	    list.Add( "Acess Level: " + m_Level.ToString());
	}

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }

	private class InternalTimer : Timer
	{
	    private readonly AdminToken Token;
	    private readonly PlayerMobile Owner;
	    private DateTime EndTime;
	    private readonly TimeSpan Delay;
	    public InternalTimer(AdminToken token, PlayerMobile owner, TimeSpan delay, DateTime end)
	 	: base(delay)
	    {

		Token = token;
		Owner = owner;
		Delay = delay;
		EndTime = end;
	    }

	    protected override void OnTick()
	    {
		if (Token == null && !Token.Deleted)
		{
		    Stop();
		}

		if (Owner.Hits < (Owner.HitsMax/3) && !Owner.Blessed)
		{
		    Owner.Blessed = true;
		    EndTime = DateTime.UtcNow + TimeSpan.FromSeconds(5);
		    Owner.SendMessage("You have been blessed.");

		    if (Token.Timer != null)
		    {
			Token.Timer.Stop();
			Token.Timer = null;
		    }

		    Token.Timer = new InternalTimer(Token, Owner, Delay, EndTime);
		    Token.Timer.Start();
		}

		if (DateTime.UtcNow > EndTime)
		{
		    if (Owner.Blessed)
		    {
			if (!Owner.Alive)
			    Owner.Resurrect();

                	Owner.FixedParticles(0x376A, 9, 32, 5005, EffectLayer.Waist);
                	Owner.PlaySound(0x1F2);
			Owner.Hits = Owner.HitsMax;
			Owner.Blessed = false;
		    }

		    int IntLevel = (int)Token.StaffLevel;
		    Server.AccessLevel tokenLevel = (AccessLevel)Enum.ToObject(typeof(AccessLevel), IntLevel);
		    Owner.AccessLevel = tokenLevel;
		}
		else
		{
		    if (Token.Timer != null)
		    {
			Token.Timer.Stop();
			Token.Timer = null;
		    }

		    Token.Timer = new InternalTimer(Token, Owner, Delay, EndTime);
		    Token.Timer.Start();
		}
	    }
	}
    }
}