using System;
using Server;
using Server.Commands;
using Server.Items;
using Server.Network;

namespace Server.Gumps
{
	public class AddSecretDoorGump : Gump
	{
		private int m_Type;

		public AddSecretDoorGump()
			: this( -1 )
		{
		}

		public void AddBlueBack( int width, int height )
		{
			AddBackground( 0, 0, width - 00, height - 00, 0xE10 );
			AddBackground( 8, 5, width - 16, height - 11, 0x053 );
			AddImageTiled( 15, 14, width - 29, height - 29, 0xE14 );
			AddAlphaRegion( 15, 14, width - 29, height - 29 );
		}

		public AddSecretDoorGump( int type )
			: base( 50, 40 )
		{
			m_Type = type;

			AddPage( 0 );

			if( m_Type >= 0 && m_Type < m_Types.Length )
			{
				AddBlueBack( 155, 174 );

				int baseID = m_Types[m_Type].m_BaseID;

				AddItem( 25, 24, baseID );
				AddButton( 26, 37, 0x5782, 0x5782, 1, GumpButtonType.Reply, 0 );

				AddItem( 47, 45, baseID + 2 );
				AddButton( 43, 57, 0x5783, 0x5783, 2, GumpButtonType.Reply, 0 );

				AddItem( 87, 22, baseID + 10 );
				AddButton( 116, 35, 0x5785, 0x5785, 6, GumpButtonType.Reply, 0 );

				AddItem( 65, 45, baseID + 8 );
				AddButton( 96, 55, 0x5784, 0x5784, 5, GumpButtonType.Reply, 0 );

				AddButton( 73, 36, 0x2716, 0x2716, 9, GumpButtonType.Reply, 0 );
			}
			else
			{
				AddBlueBack( 265, 145 );

				for( int i = 0; i < m_Types.Length; ++i )
				{
					AddButton( 30 + (i * 49), 13, 0x2624, 0x2625, i + 1, GumpButtonType.Reply, 0 );
					AddItem( 22 + (i * 49), 20, m_Types[i].m_BaseID );
				}
			}
		}

		public override void OnResponse( NetState sender, RelayInfo info )
		{
			Mobile from = sender.Mobile;
			int button = info.ButtonID - 1;

			if( m_Type == -1 )
			{
				if( button >= 0 && button < m_Types.Length )
					from.SendGump( new AddSecretDoorGump( button ) );
			}
			else
			{
				if( button >= 0 && button < 8 )
				{
					from.SendGump( new AddSecretDoorGump( m_Type ) );
					CommandSystem.Handle( from, String.Format( "{0}Add {1} {2}", CommandSystem.Prefix, m_Types[m_Type].m_Type.Name, (DoorFacing)button ) );
				}
				else if( button == 8 )
				{
					from.SendGump( new AddSecretDoorGump( m_Type ) );
					CommandSystem.Handle( from, String.Format( "{0}Link", CommandSystem.Prefix ) );
				}
				else
				{
					from.SendGump( new AddSecretDoorGump() );
				}
			}
		}

		public static void Initialize()
		{
			CommandSystem.Register( "AddSecretDoor", AccessLevel.GameMaster, new CommandEventHandler( AddDoor_OnCommand ) );
		}

		[Usage( "AddSecretDoor" )]
		[Description( "Displays a menu from which you can interactively add secret doors." )]
		public static void AddDoor_OnCommand( CommandEventArgs e )
		{
			e.Mobile.SendGump( new AddSecretDoorGump() );
		}

		public static DoorInfo[] m_Types = new DoorInfo[]
		{
			new DoorInfo( typeof( SecretStoneDoor1 ), 0xE9 ),
			new DoorInfo( typeof( SecretDungeonDoor ), 0x315 ),
			new DoorInfo( typeof( SecretStoneDoor2 ), 0x325 ),
			new DoorInfo( typeof( SecretWoodenDoor ), 0x335 ),
			new DoorInfo( typeof( SecretLightWoodDoor ), 0x345 ),
			new DoorInfo( typeof( SecretStoneDoor3 ), 0x355 )
		};
	}

	/*   public class DoorInfo
   {
	  public Type m_Type;
	  public int m_BaseID;

	  public DoorInfo( Type type, int baseID )
	  {
		 m_Type = type;
		 m_BaseID = baseID;
	  }
   }
	 */
}
