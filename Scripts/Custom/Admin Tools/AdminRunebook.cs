using System;
using System.Collections.Generic;
using Server.ContextMenus;
using Server.Engines.Craft;
using Server.Gumps;
using Server.Mobiles;
using Server.Multis;
using Server.Network;
using Server.Prompts;

namespace Server.Items
{
    public class AdminRunebook : Item, ISecurable
    {
	private List <AdminRunebookEntry> m_Entries;
	private string m_Description;

        [CommandProperty(AccessLevel.GameMaster)]
        public SecureLevel Level { get; set; }

       [CommandProperty(AccessLevel.GameMaster)]
        public string Description
        {
            get
            {
                return m_Description;
            }
            set
            {
                m_Description = value;
                InvalidateProperties();
            }
        }

        public virtual int MaxEntries { get { return 9; } }

        [Constructable]
        public AdminRunebook()
            : base(0x9C16) //0x22C5 OG runebook itemID, 0x2259 BOD book ID
        {
	    Name = "admin runebook";
            Weight = 0.0;
	    Hue = 2503;
            m_Entries = new List<AdminRunebookEntry>();
        }

        public List<AdminRunebookEntry> Entries { get { return m_Entries; } }

	public void AddEntry(PlayerMobile pm)
	{
	    if(m_Entries == null)
	    {
                m_Entries = new List<AdminRunebookEntry>();	
		pm.SendMessage("New list added.");
	    }
	    else
	    {	
		AdminRunebookEntry entry = new AdminRunebookEntry(pm.Location, pm.Map, "a new location");
		m_Entries.Add(entry);
		pm.SendMessage(entry.Description + " added to list");
		pm.SendMessage(m_Entries.Count + " entries total");
	    }
	}

	public override void OnDoubleClick(Mobile from)
	{
	    if(from is PlayerMobile)
	    {
		PlayerMobile pm = (PlayerMobile)from;
		if (!pm.IsStaff())
		    pm.SendMessage("You do not have the power to access this book.");
		else
		{
            	    BaseGump.SendGump(new AdminRunebookGump(this, pm));
		    pm.SendMessage("You open the admin runebook.");
		}
	    }
	}

	public AdminRunebook(Serial serial)
	    : base(serial)
	{
	}

	public void GetDescriptionPrompt(PlayerMobile admin)
	{
	    admin.Prompt = new DescriptionPrompt(this);
	}

        public override void GetContextMenuEntries(Mobile from, List<ContextMenuEntry> list)
        {
            base.GetContextMenuEntries(from, list);
            SetSecureLevelEntry.AddTo(from, this, list);
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0); // version

            writer.Write(m_Entries.Count);

            for (int i = 0; i < m_Entries.Count; ++i)
                m_Entries[i].Serialize(writer);

            writer.Write(m_Description);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();

            int count = reader.ReadInt();
            m_Entries = new List<AdminRunebookEntry>(count);

            for (int i = 0; i < count; ++i)
		m_Entries.Add(new AdminRunebookEntry(reader));

	    m_Description = reader.ReadString();
        }

	public override void GetProperties(ObjectPropertyList list)
	{
            base.GetProperties(list);

            if (m_Description != null && m_Description.Length > 0)
                list.Add(m_Description);

	}

        private class DescriptionPrompt : Prompt
        {
            //public override int MessageCliloc { get { return 501804; } }
            private readonly AdminRunebook m_Book;

            public DescriptionPrompt(AdminRunebook book)
            {
                m_Book = book;
            }

            public override void OnResponse(Mobile from, string text)
            {
                if (m_Book != null)
                {
                    m_Book.Description = text;
                    from.SendMessage("You add a description to your book");
                }
            }
        }
    }

    public class AdminRunebookEntry
    {
	private Map m_TargetMap;
        private string m_Description;
	private bool m_Selected = false;

	public bool Selected
	{
	    get { return m_Selected; }
	    set { m_Selected = value; }
	}
	
	[CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
        public Point3D Target { get; set; }

        [CommandProperty(AccessLevel.Counselor, AccessLevel.GameMaster)]
        public Map TargetMap
        {
            get { return m_TargetMap; }
            set
            {
                if (m_TargetMap != value)
                {
                    m_TargetMap = value;
                    //InvalidateProperties();
                }
            }
        }
        public string Description
        {
            get { return m_Description; }
	    set { m_Description = value; }
        }

        public BaseGalleon Galleon { get; }

	public AdminRunebookEntry(Point3D loc, Map map, string desc)
	{
            Target = loc;
            m_TargetMap = map;
            m_Description = desc;
	}

        public AdminRunebookEntry(GenericReader reader)
        {
            int version = reader.ReadByte();

            //int version = reader.ReadInt();
	    Target = reader.ReadPoint3D();
	    m_TargetMap = reader.ReadMap();
	    m_Description = reader.ReadString();
        }

        public void Serialize(GenericWriter writer)
        {
            writer.Write((byte)3);

	    writer.Write(Target);
	    writer.Write(m_TargetMap);
	    writer.Write(m_Description);
        }
    }
}
