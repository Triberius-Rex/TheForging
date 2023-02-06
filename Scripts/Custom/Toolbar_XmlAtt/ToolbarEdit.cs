#region References
using System;
using System.Collections.Generic;
using System.Linq;

using Server;
using Server.Gumps;
using Server.Network;
using System.Collections;
using System.Collections.Generic;

//using Services.Toolbar.Core;
using Server.Engines.XmlSpawner2;
#endregion

namespace Services.Toolbar.Gumps
{
	public class ToolbarEdit : Gump
	{
		 /* public static string HTML =
			String.Format(
				"<center><u>Command Toolbar v{0}</u><br>Made by Joeku AKA Demortris<br>{1}<br>- Customized for ServUO -</center><br>   This toolbar is extremely versatile. You can switch skins and increase or decrease columns or rows. The toolbar operates like a spreadsheet; you can use the navigation menu to scroll through different commands and bind them. Enjoy!<br><p>If you have questions, concerns, or bug reports, please <A HREF=\"mailto:demortris@adelphia.net\">e-mail me</A>.",
				ToolbarCore.SystemVersion,
				ToolbarCore.ReleaseDate); */

        public static string HTML =
			String.Format(
				"<center><u>Command Toolbar</u><br>Made by Joeku AKA Demortris<br><br>- Customized for ServUO -</center><br>   This toolbar is extremely versatile. You can switch skins and increase or decrease columns or rows. The toolbar operates like a spreadsheet; you can use the navigation menu to scroll through different commands and bind them. Enjoy!<br><p>If you have questions, concerns, or bug reports, please <A HREF=\"mailto:demortris@adelphia.net\">e-mail me</A>.");

		private readonly bool _Expanded;
		private readonly int _ExpandedInt;

		private readonly ToolbarInfo _Info;
		private List<TextRelay> _TextRelays;

		public ToolbarEdit(ToolbarInfo info)
			: this(info, false)
		{ }

		public ToolbarEdit(ToolbarInfo info, bool expanded)
			: base(0, 28)
		{
			_Info = info;

			_Expanded = expanded;
			_ExpandedInt = expanded ? 2 : 1;

			AddInit();
			AddControls();
			//AddNavigation();
			AddResponses();
			//AddEntries();

			const int buffer = 2;

			int entryX = _ExpandedInt * 149; 
			int entryY = _ExpandedInt * 20;
			int bgX = /* 20 + */ (entryX * _Info.Rows); 
			int bgY = 10 + (entryY * _Info.Collumns);
			int divX = bgX - 10; 
			int divY = bgY - 10;

			int offset = GumpIDs.Misc[(int)GumpIDs.MiscIDs.ButtonOffset].Content[_Info.Skin, 0];
			int bx = ((offset * 2) + (_Info.Rows * 110));
			int by = ((offset * 2) + (_Info.Collumns * 24));
			int byx = by;

			AddBackground(0, 120, bx, byx /* 33 + bgX, 32 + bgY */, 9200);

			/* // Add vertical dividers
			for (int m = 0; m <= (_Info.Collumns - 1); m++)
			{
				AddImageTiled(18 + (m * entryX) + buffer + ((m - 1) * 4), 157, 2, divY, 10004);
			}

			// Add horizontal dividers
			for (int n = 0; n <= (_Info.Rows - 1); n++)
			{
				AddImageTiled(0, 125 + (n * (entryY + 2)), divX, 2, 10001);
			} */

			int x = 0;
			int y = 0;
			int startingNewRow = 0;

			for (int i = 0; i < (_Info.Rows * _Info.Collumns); i++)
			{
				 

				if(x >= _Info.Rows)
				{	
					x = 0;
					startingNewRow++;
					y = (25 * startingNewRow);
				}

				/* AddHtml(
					5 + (x * 115),
					125 + y,
					115,
					25,
					"",
					true,
					false
				); */

				AddBackground(
					5 + (x * 115),
					125 + y,
					115,
					25, 
					9200
				);

				AddTextEntry(
					10 + (x * 115),
					130 + y,
					149 - 1,
					20,
					0,
					i,
					i < _Info.Entries.Count ? _Info.Entries[i] : "-*UNUSED*-"
				);

				x++;
			}

		}

		public override void OnResponse(NetState sender, RelayInfo info)
		{
			Mobile m = sender.Mobile;
			_TextRelays = CreateList(info.TextEntries);

			switch (info.ButtonID)
			{
				case 0:
					break;
				case 1:
					{
						_Info.Skin++;
						m.SendGump(new ToolbarEdit(_Info, _Expanded));
						break;
					}
				case 2:
					{
						_Info.Skin--;
						m.SendGump(new ToolbarEdit(_Info, _Expanded));
						break;
					}
				case 3:
					{
						_Info.Rows++;
						m.SendGump(new ToolbarEdit(_Info, _Expanded));
						break;
					}
				case 4:
					{
						_Info.Rows--;
						m.SendGump(new ToolbarEdit(_Info, _Expanded));
						break;
					}
				case 5:
					{
						_Info.Collumns++;
						m.SendGump(new ToolbarEdit(_Info, _Expanded));
						break;
					}
				case 6:
					{
						_Info.Collumns--;
						m.SendGump(new ToolbarEdit(_Info, _Expanded));
						break;
					}
				case 9: // Default
					{
						var toolbarinfo = ToolbarInfo.DefaultEntries(m.AccessLevel);
						//CombineEntries(toolbarinfo);
						//toolbarinfo.AddRange(AnalyzeEntries(toolbarinfo.Count));
						_Info.Entries = toolbarinfo;
						m.CloseGump(typeof(ToolbarGump));
						m.SendGump(new ToolbarGump(_Info, m));
						//m.SendGump(new ToolbarEdit(_Info, _Expanded));
						break;
					}
				case 10: // Okay
					goto case 12;
				case 11: // Cancel
					goto case 0;
				case 12: // Apply
					{
						/* ToolbarModule module = m.GetModule(typeof(ToolbarModule)) as ToolbarModule ?? new ToolbarModule(m);

						module.ToolbarInfo.Entries = AnalyzeEntries();
						
						module.ToolbarInfo.Phantom = info.IsSwitched(21);
						module.ToolbarInfo.Stealth = info.IsSwitched(23);
						module.ToolbarInfo.Reverse = info.IsSwitched(25);
						module.ToolbarInfo.Lock = info.IsSwitched(27); */

						_Info.Entries = new List<string>();
						TextRelay nameRelay;
						string entry;

						for (int j = 0; j < _TextRelays.Count; j++)
						{
							nameRelay = info.GetTextEntry( j );

							if( nameRelay != null )
							{
								entry = nameRelay.Text.Trim();
							}
							else
								entry = "empty";

							_Info.Entries.Add( entry );
						}
						
						_Info.Phantom = info.IsSwitched(21);
						_Info.Stealth = info.IsSwitched(23);
						_Info.Reverse = info.IsSwitched(25);
						_Info.Lock = info.IsSwitched(27);

						if (info.ButtonID == 12)
						{
							m.SendGump(new ToolbarEdit(_Info, _Expanded));
						}

						m.CloseGump(typeof(ToolbarGump));
						m.SendGump(new ToolbarGump(_Info, m));

						break;
					}
				case 18:
					{
						_Info.Font++;
						m.SendGump(new ToolbarEdit(_Info, _Expanded));
						break;
					}
				case 19:
					{
						_Info.Font--;
						m.SendGump(new ToolbarEdit(_Info, _Expanded));
						break;
					}
				case 20:
					{
						m.SendGump(new ToolbarEdit(_Info, _Expanded));
						m.SendMessage(2101, "Phantom mode turns the toolbar semi-transparent.");
						break;
					}
				case 22:
					{
						m.SendGump(new ToolbarEdit(_Info, _Expanded));
						m.SendMessage(2101, "Stealth mode makes the toolbar automatically minimize when you click a button.");
						break;
					}
				case 24:
					{
						m.SendGump(new ToolbarEdit(_Info, _Expanded));
						m.SendMessage(2101, "Reverse mode puts the minimize bar above the toolbar instead of below.");
						break;
					}
				case 26:
					{
						m.SendGump(new ToolbarEdit(_Info, _Expanded));
						m.SendMessage(2101, "Lock mode disables closing the toolbar with right-click.");
						break;
					}
				case 28: // Expand
					{
						m.SendGump(new ToolbarEdit(_Info, !_Expanded));
						m.SendMessage(2101, "Expanded view {0}activated.", _Expanded ? "de" : "");
						break;
					}
			}
		}

		/// <summary>
		///     Takes the gump relay entries and converts them from an Array into a List.
		/// </summary>
		public static List<TextRelay> CreateList(TextRelay[] entries)
		{
			return entries.ToList();
		}

		public void CombineEntries(List<string> list)
		{
			string temp;
			
			for (int i = 0; i < list.Count; i++)
			{
				if (list[i] == "-*UNUSED*-" && (temp = GetEntry(i + 13, this).Text) != "")
				{
					list[i] = temp;
				}
			}
		}

		public List<string> AnalyzeEntries()
		{
			return AnalyzeEntries(0);
		}

		/// <summary>
		///     Organizes the gump relay entries into a usable collection.
		/// </summary>
		public List<string> AnalyzeEntries(int i)
		{
			var list = new List<string>();

			string temp;
			
			for (int j = i; j < _TextRelays.Count; j++)
			{
				list.Add( (temp = GetEntry(j, this).Text) );
			}

			return list;
		}

		/// <summary>
		///     Gets entry # in the gump relay.
		/// </summary>
		public static TextRelay GetEntry(int entryID, ToolbarEdit gump)
		{
			int temp = 0;
			TextRelay relay = null;

			for (int i = 0; i < gump._TextRelays.Count; i++)
			{
				if (gump._TextRelays[i].EntryID != entryID)
				{
					continue;
				}

				temp = i;
				relay = gump._TextRelays[i];
			}

			gump._TextRelays.RemoveAt(temp);

			return relay;
		}

		/// <summary>
		///     Adds the skeleton gump.
		/// </summary>
		public void AddInit()
		{
			AddPage(0);
			AddBackground(0, 0, 620, 120, 9200);
			AddHtml(10, 10, 240, 100, HTML, true, true);
		}

		/// <summary>
		///     Adds other dynamic options.
		/// </summary>
		public void AddControls()
		{
			AddBackground(260, 0, 240, 120, 9200);
			AddLabel(274, 11, 0, String.Format("Skin - {0}", _Info.Skin + 1));

			if (_Info.Skin < GumpIDs.Skins - 1)
			{
				AddButton(359, 10, 2435, 2436, 1, GumpButtonType.Reply, 0);
			}

			if (_Info.Skin > 0)
			{
				AddButton(359, 21, 2437, 2438, 2, GumpButtonType.Reply, 0);
			}

			AddLabel(274, 36, 0, String.Format("Rows - {0}", _Info.Rows));

			if (_Info.Rows < 15)
			{
				AddButton(359, 35, 2435, 2436, 3, GumpButtonType.Reply, 0);
			}

			if (_Info.Rows > 1)
			{
				AddButton(359, 46, 2437, 2438, 4, GumpButtonType.Reply, 0);
			}

			AddLabel(274, 61, 0, String.Format("Columns - {0}", _Info.Collumns));

			if (_Info.Collumns < 9)
			{
				AddButton(359, 60, 2435, 2436, 5, GumpButtonType.Reply, 0);
			}

			if (_Info.Collumns > 1)
			{
				AddButton(359, 71, 2437, 2438, 6, GumpButtonType.Reply, 0);
			}

			AddHtml(276, 87, 100, 20, String.Format("{0}Font - {1}", GumpIDs.Fonts[_Info.Font], _Info.Font + 1), false, false);

			if (_Info.Font < GumpIDs.Fonts.Length - 1)
			{
				AddButton(359, 85, 2435, 2436, 18, GumpButtonType.Reply, 0);
			}

			if (_Info.Font > 0)
			{
				AddButton(359, 96, 2437, 2438, 19, GumpButtonType.Reply, 0);
			}

			AddLabel(389, 11, 0, "Phantom");
			AddButton(446, 13, 22153, 22155, 20, GumpButtonType.Reply, 0);
			AddCheck(469, 11, 210, 211, _Info.Phantom, 21);
			AddLabel(389, 36, 0, "Stealth");
			AddButton(446, 38, 22153, 22155, 22, GumpButtonType.Reply, 0);
			AddCheck(469, 36, 210, 211, _Info.Stealth, 23);
			AddLabel(389, 61, 0, "Reverse");
			AddButton(446, 63, 22153, 22155, 24, GumpButtonType.Reply, 0);
			AddCheck(469, 61, 210, 211, _Info.Reverse, 25);
			AddLabel(389, 86, 0, "Lock");
			AddButton(446, 88, 22153, 22155, 26, GumpButtonType.Reply, 0);
			AddCheck(469, 86, 210, 211, _Info.Lock, 27);
		}

		/// <summary>
		///     Adds the skeleton navigation section.
		/// </summary>
		public void AddNavigation()
		{
			AddBackground(500, 0, 120, 120, 9200);
			AddHtml(500, 10, 120, 20, @"<center><u>Navigation</u></center>", false, false);
			AddLabel(508, 92, 0, "Expanded View");
			AddButton(595, 95, _Expanded ? 5603 : 5601, _Expanded ? 5607 : 5605, 28, GumpButtonType.Reply, 0);
		}

		/// <summary>
		///     Adds response buttons.
		/// </summary>
		public void AddResponses()
		{
			int temp = 250 + (_ExpandedInt * 100);

			AddBackground(0, temp, 500, 33, 9200);
			AddButton(50, temp + 5, 246, 244, 9, GumpButtonType.Reply, 0); // Default
			AddButton(162, temp + 5, 249, 248, 10, GumpButtonType.Reply, 0); // Okay
			AddButton(275, temp + 5, 243, 241, 11, GumpButtonType.Reply, 0); // Cancel
			AddButton(387, temp + 5, 239, 240, 12, GumpButtonType.Reply, 0); // Apply
		}

		/// <summary>
		///     Adds the actual command/phrase entries.
		/// </summary>
		public void AddEntries()
		{
			const int buffer = 2;

			// CALC
			int entryX = _ExpandedInt * 149, entryY = _ExpandedInt * 20;
			int bgX = 10 + 4 + (buffer * 3) + (entryX * 3), bgY = 10 + 8 + (entryY * 5);
			int divX = bgX - 10, divY = bgY - 10;
			// ENDCALC

			AddBackground(0, 120, 33 + bgX, 32 + bgY, 9200);

			AddBackground(33, 152, bgX, bgY, 9200);

			// Add vertical dividers
			for (int m = 1; m <= 2; m++)
			{
				AddImageTiled(38 + (m * entryX) + buffer + ((m - 1) * 4), 157, 2, divY, 10004);
			}

			// Add horizontal dividers
			for (int n = 1; n <= 4; n++)
			{
				AddImageTiled(38, 155 + (n * (entryY + 2)), divX, 2, 10001);
			}

			int start = -3, temp;

			for (int i = 1; i <= 9; i++)
			{
				start += 3;
				
				switch (i)
				{
					case 4:
						start = 45;
						break;
					case 7:
						start = 90;
						break;
				}

				temp = start;

				/********
				* PAGES *
				*-------*
				* 1 2 3 *
				* 4 5 6 *
				* 7 8 9 *
				********/

				AddPage(i);
				CalculatePages(i);

				// Add column identifiers
				for (int j = 0; j < 3; j++)
				{
					AddHtml(
						38 + buffer + ((j % 3) * (buffer + entryX + 2)),
						128,
						entryX,
						20,
						String.Format("<center>Column {0}</center>", (j + 1) + CalculateColumns(i)),
						false,
						false);
				}

				AddHtml(2, 128, 30, 20, "<center>Row</center>", false, false);

				int tempInt = 0;
				
				if (_Expanded)
				{
					tempInt = 11;
				}

				// Add row identifiers
				for (int k = 0; k < 5; k++)
				{
					AddHtml(
						0,
						157 + (k * (entryY + 2)) + tempInt,
						32,
						20,
						String.Format("<center>{0}</center>", (k + 1) + CalculateRows(i)),
						false,
						false);
				}

				// Add command entries
				for (int l = 0; l < _TextRelays.Count; l++)
				{
					AddTextEntry(
						38 + buffer + ((l % 3) * ((buffer * 2) + entryX)) /* + buffer + ((l % 3) * ((buffer * 2) + entryX)) */,
						157 + ((int)Math.Floor((double)l / 3)  * (entryY + 2)) /* + ((int)Math.Floor((double)l / 3) * (entryY + 2)) */,
						entryX - 1,
						entryY,
						2101,
						temp + 13,
						_Info.Entries[l]);

					if (l % 3 == 2)
					{
						temp += 6;
					}

					++temp;
				}
			}
		}

		/// <summary>
		///     Calculates what navigation button takes you to what page.
		/// </summary>
		public void CalculatePages(int i)
		{
			int up = 0, down = 0, left = 0, right = 0;
			
			switch (i)
			{
				case 1:
					down = 4;
					right = 2;
					break;
				case 2:
					down = 5;
					left = 1;
					right = 3;
					break;
				case 3:
					down = 6;
					left = 2;
					break;
				case 4:
					up = 1;
					down = 7;
					right = 5;
					break;
				case 5:
					up = 2;
					down = 8;
					left = 4;
					right = 6;
					break;
				case 6:
					up = 3;
					down = 9;
					left = 5;
					break;
				case 7:
					up = 4;
					right = 8;
					break;
				case 8:
					up = 5;
					left = 7;
					right = 9;
					break;
				case 9:
					up = 6;
					left = 8;
					break;
			}

			AddNavigation(up, down, left, right);
		}

		/// <summary>
		///     Adds navigation buttons for each page.
		/// </summary>
		public void AddNavigation(int up, int down, int left, int right)
		{
			if (up > 0)
			{
				AddButton(549, 34, 9900, 9902, 0, GumpButtonType.Page, up);
			}

			if (down > 0)
			{
				AddButton(549, 65, 9906, 9908, 0, GumpButtonType.Page, down);
			}

			if (left > 0)
			{
				AddButton(523, 50, 9909, 9911, 0, GumpButtonType.Page, left);
			}

			if (right > 0)
			{
				AddButton(575, 50, 9903, 9905, 0, GumpButtonType.Page, right);
			}
		}

		/// <summary>
		///     Damn I've forgotten...
		/// </summary>
		public static int CalculateColumns(int i)
		{
			switch (i)
			{
				case 7:
				case 4:
				case 1:
					return 0;
				case 8:
				case 5:
				case 2:
					return 3;
				default:
					return 6;
			}
		}

		/// <summary>
		///     Same as above! =(
		/// </summary>
		public static int CalculateRows(int i)
		{
			if (i >= 1 && i <= 3)
			{
				return 0;
			}
			
			if (i >= 4 && i <= 6)
			{
				return 5;
			}
			
			return 10;
		}
	}
}