using System;
using Server.Items;
using Server.Network;
using Server.Mobiles;
using Server.Targets;
using Server.Targeting;
using System.Globalization;
using System.Collections.Generic;

namespace Server.Gumps
{
    public class AdminRunebookGump : BaseGump
    {
	private AdminRunebook m_Book;
	private List<AdminRunebookEntry> m_Entries;
	private PlayerMobile m_Admin;
	private int MaxEntries = 24;
	private int PageOneEntries;
	private int PageTwoEntries;
	private bool StaffOnly = false;
	private bool OptionsMenu = false;
	private int Page;

        public AdminRunebookGump(AdminRunebook book, PlayerMobile admin)
            : base(admin, 100, 100)
        {
	    m_Book = book;
	    m_Entries = book.Entries;
	    m_Admin = admin;
	    Page = 1;
	}

        public AdminRunebookGump(AdminRunebook book, PlayerMobile admin, int page)
            : base(admin, 100, 100)
        {
	    m_Book = book;
	    m_Entries = book.Entries;
	    m_Admin = admin;
	    Page = page;
	}

	public override void AddGumpLayout()
        {
	    AddPage(0);
	    AddImage(0, 0, 0x9BF3);

	    AddHtml(60, 10, 190, 16, FormatOptions("Admin Runebook", "#504107"), false, false);


	    AddHtml(80, 300, 400, 16, FormatOptions("Add Location", "#F0F8FF"), false, false);
	    AddButton(50, 300, 0x16CE, 0x16CD, 1, GumpButtonType.Reply, 0);

	    AddHtml(80, 330, 400, 16, FormatOptions("Options", "#F0F8FF"), false, false);
	    AddButton(50, 330, 0x16CE, 0x16CD, 2, GumpButtonType.Reply, 0);

	    /* Options menu */
	    if (OptionsMenu == true)
	    {
		AddHtml(275, 10, 400, 16, FormatOptions("Options", "#504107"), false, false);

		AddButton(250, 105, 0x868, 0x869, 6, GumpButtonType.Reply, 0); 
		AddHtml(285, 110, 400, 16, FormatOptions("Subtitle Book", "#F0F8FF"), false, false);

		AddButton(250, 155, 0x868, 0x869, 5, GumpButtonType.Reply, 0); 
		AddHtml(285, 160, 400, 16, FormatOptions("Clear Entries", "#F0F8FF"), false, false);

		AddButton(250, 205, 0x868, 0x869, 4, GumpButtonType.Reply, 0); 
		AddHtml(285, 210, 400, 16, FormatOptions("Copy Entries", "#F0F8FF"), false, false);

	    }

	    AddPage(1);
	    if (Page == 1)
	    {
	    	AddButton(374, 4, 0x89E, 0x89E, 1002, GumpButtonType.Reply, 0);

	    	if (m_Entries.Count < 12)
		    PageOneEntries = m_Entries.Count;
	    	else
		    PageOneEntries = 12;

	    	int y = 30;
	    	if(m_Entries != null )
	    	{

	    	    for(int i = 0; i < PageOneEntries; i++)
	    	    {

		    	if (m_Entries[i] == null)
		    	{
			    m_Entries.RemoveAt(i);
			    i--;
		    	}
		    	else
		    	{
			    AddButton(40, y+2, 0x4B9, 0x4BA, i + 100, GumpButtonType.Reply, 0);
			    AddHtml(65, y, 400, 16, FormatOptions(m_Entries[i].Description, m_Entries[i].Selected ? "#504107" : "#F0F8FF"), false, false);

			    if (m_Entries[i].Selected)
			    {

	    		    	AddImageTiled(270, 10, 100, 21, 0xBBC);
	    		    	AddTextEntry(275, 10, 140, 21, 0, 1, m_Entries[i].Description);
			    	AddButton(260, 52, 0x4B9, 0x4BA, i + 500, GumpButtonType.Reply, 0); //Remove Entry
			    	AddHtml(280, 50, 400, 16, FormatOptions("Remove Entry", "#504107"), false, false);

			    	AddButton(250, 85, 0x868, 0x869, i + 600, GumpButtonType.Reply, 0); 
			    	AddHtml(285, 90, 400, 16, FormatOptions("Create Rune", "#504107"), false, false);

			    	AddButton(250, 135, 0x868, 0x869, i + 400, GumpButtonType.Reply, 0); 
			    	AddHtml(285, 140, 400, 16, FormatOptions("Send Player", "#504107"), false, false);

			    	AddHtml(255, 255, 400, 16, FormatOptions("Travel", "#504107"), false, false);
			    	AddHtml(315, 255, 400, 16, FormatOptions( "Admin Gate", "#504107"), false, false);

			    	AddHtml(264, 185, 400, 16, FormatOptions("Gate Access: ", "#504107"), false, false);
			    	AddButton(250, 205, StaffOnly ? 0x86A : 0x868, StaffOnly ? 0x867 : 0x869, 3, GumpButtonType.Reply, 0); //Staff Only
			    	AddHtml(285, 210, 400, 16, FormatOptions("Staff Only", "#504107"), false, false);

			    	AddButton(245, 11, 0x4B9, 0x4BA, i + 150, GumpButtonType.Reply, 0); //Rename 
			    	AddButton(250, 290, 0x1B77, 0x1B77, i + 200, GumpButtonType.Reply, 0); // Travel
			    	AddButton(315, 290, 0x1B8B, 0x1B8B, i + 250, GumpButtonType.Reply, 0); // Admin Gate
			    }

		    	    y += 20;
		    	}
	    	    }

		    if( m_Entries.Count == 0)
		    	AddHtml(60, 30, 400, 16, FormatOptions("No entries", "#F0F8FF"), false, false);
	        }
	        else
		    AddHtml(60, 30, 400, 16, FormatOptions("No entries", "#F0F8FF"), false, false);
	    }



	    if ( Page == 2)
	    {
	    	AddButton(22, 4, 0x89D, 0x89D, 1001, GumpButtonType.Reply, 0);

	    	if (m_Entries.Count < 12)
		    PageTwoEntries = 0;
	    	else if (m_Entries.Count > 9 && m_Entries.Count < 24)
		    PageTwoEntries = m_Entries.Count;
	    	else
		    PageTwoEntries = 24;

	    	int y = 30;
	    	if(m_Entries != null )
	    	{

	    	    for(int i = 12; i < PageTwoEntries; i++)
	    	    {

		    	if (m_Entries[i] == null)
		    	{
			    m_Entries.RemoveAt(i);
			    i--;
		    	}
		    	else
		    	{
			    AddButton(40, y+2, 0x4B9, 0x4BA, i + 100, GumpButtonType.Reply, 0);
			    AddHtml(65, y, 400, 16, FormatOptions(m_Entries[i].Description, m_Entries[i].Selected ? "#504107" : "#F0F8FF"), false, false);

			    if (m_Entries[i].Selected)
			    {

	    		    	AddImageTiled(270, 10, 100, 21, 0xBBC);
	    		    	AddTextEntry(275, 10, 140, 21, 0, 1, m_Entries[i].Description);
			    	AddButton(260, 52, 0x4B9, 0x4BA, i + 500, GumpButtonType.Reply, 0); //Remove Entry
			    	AddHtml(280, 50, 400, 16, FormatOptions("Remove Entry", "#504107"), false, false);

			    	AddButton(250, 85, 0x868, 0x869, i + 600, GumpButtonType.Reply, 0); 
			    	AddHtml(285, 90, 400, 16, FormatOptions("Create Rune", "#504107"), false, false);

			    	AddButton(250, 135, 0x868, 0x869, i + 400, GumpButtonType.Reply, 0); 
			    	AddHtml(285, 140, 400, 16, FormatOptions("Send Player", "#504107"), false, false);

			    	AddHtml(255, 255, 400, 16, FormatOptions("Travel", "#504107"), false, false);
			    	AddHtml(315, 255, 400, 16, FormatOptions( "Admin Gate", "#504107"), false, false);

			    	AddHtml(264, 185, 400, 16, FormatOptions("Gate Access: ", "#504107"), false, false);
			    	AddButton(250, 205, StaffOnly ? 0x86A : 0x868, StaffOnly ? 0x867 : 0x869, 3, GumpButtonType.Reply, 0); //Staff Only
			    	AddHtml(285, 210, 400, 16, FormatOptions("Staff Only", "#504107"), false, false);

			    	AddButton(245, 11, 0x4B9, 0x4BA, i + 150, GumpButtonType.Reply, 0); //Rename 
			    	AddButton(250, 290, 0x1B77, 0x1B77, i + 200, GumpButtonType.Reply, 0); // Travel
			    	AddButton(315, 290, 0x1B8B, 0x1B8B, i + 250, GumpButtonType.Reply, 0); // Admin Gate
			    }

		    	    y += 20;
		    	}
	    	    }

		    if( m_Entries.Count == 0)
		    	AddHtml(60, 30, 400, 16, FormatOptions("No entries", "#F0F8FF"), false, false);
	        }
	        else
		    AddHtml(60, 30, 400, 16, FormatOptions("No entries", "#F0F8FF"), false, false);
	    }

	}

	public string Rename(RelayInfo info, Mobile from)
	{
	    TextRelay tn = info.GetTextEntry(1); //Text Name

	    string name = tn.Text;

	    return name;
	}
	public string FormatOptions(string val, string color)
	{
	    if( color == null)
		return String.Format("<div align=left>{0}</div>", val);
	    else
	    	return String.Format("<BASEFONT COLOR={1}><dic align=left>{0}</div>", val, color);
	}

        public override void OnResponse(RelayInfo info)
        {
	    if(info.ButtonID == 0)
		return;

	    if(info.ButtonID == 1)
	    {
		if( m_Entries.Count < MaxEntries)
		    m_Book.AddEntry(m_Admin);
		else
		{
		    m_Admin.SendMessage("Your entry list is full.");
		    Refresh();
		}

	    }
	    if(info.ButtonID == 2)
	    {

		if (m_Entries != null)
		{
		    for(int n = 0; n < m_Entries.Count; n++)
			m_Entries[n].Selected = false;
		}

		OptionsMenu = true;

		Refresh();
	    }

	    if (info.ButtonID == 3)
	    {
		if(!StaffOnly)
		    StaffOnly = true;
		else
		    StaffOnly = false;

		Refresh();
	    }

	    if(info.ButtonID == 4)
	    {
		m_Admin.Target = new CopyEntriesTarget(m_Book);
	    }

	    if(info.ButtonID == 5)
	    {
		if(m_Entries != null)
		    m_Entries.Clear();
	    }
	    if(info.ButtonID == 6)
	    {
		m_Book.GetDescriptionPrompt(m_Admin);
	    }

	    if (info.ButtonID >= 400 && info.ButtonID < 425) // send player
	    {
		m_Admin.Target = new AdminRunebookPlayerTarget(m_Entries[info.ButtonID - 400].Target, m_Entries[info.ButtonID - 400].TargetMap);

		Refresh();
	    }

	    if (info.ButtonID >= 100 && info.ButtonID < 125) // select entry
	    {
		OptionsMenu = false;
		for(int e = 0; e < m_Entries.Count; e++)
		    m_Entries[e].Selected = false;

		m_Entries[info.ButtonID - 100].Selected = true;

		if (info.ButtonID > 112)
		    Page = 2;

		Refresh();
	    }

	    if (info.ButtonID >= 150 && info.ButtonID < 175)
	    {
		string newName = Rename(info, m_Admin);
		m_Entries[info.ButtonID - 150].Description = newName;
		Refresh();
	    }

	    if (info.ButtonID >= 200 && info.ButtonID < 225) // admin gate
	    {
		m_Admin.MoveToWorld(m_Entries[info.ButtonID - 200].Target, m_Entries[info.ButtonID - 200].TargetMap);
	    }
	    if (info.ButtonID >= 250 && info.ButtonID < 275)
	    {
		AdminGate gateOne = new AdminGate(m_Entries[info.ButtonID - 250].Target, m_Entries[info.ButtonID - 250].TargetMap); 
		gateOne.MoveToWorld(m_Admin.Location, m_Admin.Map);
		AdminGate gateTwo = new AdminGate(m_Admin.Location, m_Admin.Map); 
		gateTwo.MoveToWorld(m_Entries[info.ButtonID - 250].Target, m_Entries[info.ButtonID - 250].TargetMap);
	
		if(!StaffOnly)
		{
		    gateOne.StaffOnly = false;
		    gateTwo.StaffOnly = false;
		}
		else
		{
		    gateOne.StaffOnly = true;
		    gateTwo.StaffOnly = true;
		}

		gateOne.LinkedGate = gateTwo;
		gateTwo.LinkedGate = gateOne;
	    }

	    if (info.ButtonID >= 500 && info.ButtonID < 525)
	    {
		m_Entries.RemoveAt(info.ButtonID - 500);
	    }

	    if (info.ButtonID >= 600 && info.ButtonID < 625)
	    {
		RecallRune rune = new RecallRune();
		rune.Marked = true;
		rune.TargetMap = m_Entries[info.ButtonID - 600].TargetMap;
		rune.Target = m_Entries[info.ButtonID - 600].Target;
		rune.Description = m_Entries[info.ButtonID - 600].Description;
		m_Admin.Backpack.DropItem(rune);
	    }

	    if (info.ButtonID == 1001)
	    {
		BaseGump.SendGump(new AdminRunebookGump(m_Book, m_Admin, 1));
	    }

	    if (info.ButtonID == 1002)
	    {
		BaseGump.SendGump(new AdminRunebookGump(m_Book, m_Admin, 2));
	    }
	}
	private class CopyEntriesTarget : Target
	{
	    private AdminRunebook m_Original;
	    public CopyEntriesTarget(AdminRunebook book)
		: base( -1, true, TargetFlags.None)
	    {
		m_Original = book;
	    }

	    protected override void OnTarget(Mobile from, object o)
	    {
		if (from is PlayerMobile && o is AdminRunebook)
		{
		    PlayerMobile pm = from as PlayerMobile;
		    AdminRunebook book = o as AdminRunebook;
		    book.Entries.Clear();
		    for( int i = 0; i < m_Original.Entries.Count; i++)
		    {
			book.AddEntry(pm);
			book.Entries[i] = m_Original.Entries[i];
		    }
		    
		}
	    }
	}
    }
}