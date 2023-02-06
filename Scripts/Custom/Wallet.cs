using System;
using System.Xml;
using System.Text;
using System.Security.Cryptography;
using System.Net;
using System.Linq;
using System.Collections.Generic;
using Server;
using Server.Network;
using Server.Mobiles;
using Server.Misc;
using Server.Items;
using Server.Gumps;
using Server.Engines.UOStore;
using Server.Engines.Points;
using Server.ContextMenus;
using Server.Commands;
using Server.Commands.Generic;
using Server.Accounting;


namespace Server.Gumps
{
	public class WalletGump : Gump
	{
		public static void Initialize()
		{
				CommandSystem.Register("Wallet", AccessLevel.Player, new CommandEventHandler(WalletGump_OnCommand));
		}

		private static void WalletGump_OnCommand(CommandEventArgs e)
        {
	        Mobile from = e.Mobile;
	        from.CloseGump(typeof(WalletGump));
            from.SendGump(new WalletGump(from));
        }


		public Mobile User { get; }

		private WalletGump(Mobile user) 
			: base(0, 0)
		{
			int balance = Banker.GetBalance(user);
			User = user;

			Dragable = true;
			Closable = true;
			Resizable = false;
			Disposable = false;

			AddBackground(160, 20, 352, 207, 9390);
			AddImageTiled(190, 160, 290, 3, 30002); 
			AddImageTiled(300, 85, 2, 76, 30000); 
			AddImageTiled(395, 85, 2, 42, 30000); 
			AddImageTiled(190, 85, 290, 3, 30002); 
			AddImageTiled(190, 125, 290, 3, 30002); 
            AddHtml(240, 55, 200, 20, "<basefont size=5><center>Currency Balances", false, false);
			AddHtml(185, 95, 114, 20, "<basefont size=5><center>Sovereign", false, false);
            AddLabel(310, 95, 0, UltimaStore.GetCurrency(User).ToString("N0"));
            AddHtml(400, 95, 46, 20, "<basefont size=5><center>Store", false, false);
            AddButton(450, 90, 2152, 2151, 1, GumpButtonType.Reply, 0);
			AddHtml(185, 130, 114, 20, "<basefont size=5><center>Gold", false, false);
            AddLabel(310, 135, 0, balance.ToString());
			AddHtml(397, 165, 49, 20, "<basefont size=5><center>Close", false, false);
            AddButton(450, 165, 2474, 2473, 0, GumpButtonType.Reply, 0);
		}
		
		public override void OnResponse(NetState sender, RelayInfo info)
        {
            Mobile from = sender.Mobile;
            string prefix = Server.Commands.CommandSystem.Prefix;

            switch(info.ButtonID)
            {
                case 0:
				{
                    from.CloseGump( typeof( WalletGump ) );
                    break;
				}
				case 1:
				{
                    CommandSystem.Handle(from, String.Format("{0}Store", prefix));
                    from.SendGump(new WalletGump(from));
                    break;
				}

            }
        }
    }
}