#region Header
/*~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
~~~~~~~    Ultimate Hue Room Generation System
~~~~~~~~~~          designed by MightyHythloth
~~~~~~~~~~~~~~~~
                with credits to the following:
~~~~~~~~~~~~~~~~~~~~
               Lord_GreyWolf - Equation Coding
          tangentzero - Precursor for dye tubs
Cottonballs (Revision of [hue, author unknown)
~~~~~~~~~~~~~~~~~~~~~~~~
Feel free to modify for your use... but please 
leave all credits if you distribute it further
~~~~~~~~~~~~~~~~~~~~~~~~~~~~
~~~  UltimateDyeTub.cs and HueRoomGen.cs  ~~~~
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/

//MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMWXXNWMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM
//MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMWXOOXWMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM
//MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMW0od0WMMMMMMMMMMMMWWMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM
//MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMWOc:xXWMMMMMMMMMN00XWMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM
//MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMW0l,cONWMMMMMMMXd:oXMMMMMMMMMMMMMMMMMMMMMMMWXXWMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM
//MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMWXd'.cONWMMMMMNk,.lKWMMMMMMMMMMMMMMMMMMMMMN0dxXWMMMMMMMMMWWWMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM
//MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMNk;..:xKWMMMWXl..;xXWMMMMMMMMMMMMMMMMMMMMNx:ckXWMMMMMMMN0KNMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM
//MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMWKd'..'lkKNMW0l. .:kXWMMMMMMMMMMMMMMMMMMWNk;.:kXWMMMMMKoo0WMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM
//MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMW0o'  .'cx0XKx:. .;d0NWMMMMMMMMMMMMMMMMMWOc..:xXWWMMKc,lKMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM
//MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMN0o,.   .,cooc;....:xKNWMMMMMMMMMMMMMMMWXd' .,lOXWXo..oKWMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM
//MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMWKx:.     .....    .:oOKNWMMMMMMMMMMMMMNOc.  .,okd, .c0WMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM
//MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMWWN0d;.              .':oxkKNWWMMMMMMMMWNkc.   ...   ,dXWMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM
//MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMWN0xc'.               .';lxOKXNWWMMMMWNOl'.       .;xXWMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM
//MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMWNX0dc;..               ..,coxO0XNWMMWKkl,.      .;d0NWMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM
//MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMWWNKOdl:'.                ..,;coxk0KKKOoc,..    .cxKNWMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM
//MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMWWWWNNNNNNNNXXNWWMMMMMMMMWNX0koc,'..                ...,;:lool:,..    .:dKNMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM
//MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMWWNXXK00Okxxdollc::;;;;,;:d0NMMMMMMMMMMMMMWNXXKOxl:,..                  .....        'o0WMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM
//MMMMMMMMMMMMMMMMMMMMMMWWNX0Oxdoc:;,....             .,lkKWMMMMMMMMMMMMMMWWWNNK0kxo:,.                                ,xXMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM
//MMMMMMMMMMMMMMMWWNX0Odl:,'..                      .cxKWMMMMMMMMMMMWWNX0kdl:;,'...                                     .oXWMMMMMMMMMMMMMMMMMMMMMMMMMMMM
//MMMMMMMMMMMWNKOxl:'..                           ,o0NWMMMMMMMMMWNKOxl;'..                                               .dNMMMMMMMMMMMMMMMMMMMMMMMMMMMM
//MMMMMMMWNKko:'.                              .,dKWWMMMMMMMMWXOd:'.                                                      ,kNMMMMMMMMMMMMMMMMMMMMMMMMMMM
//MMMWNKko;..                    .           .;xXWMMMMMMMMWXkl,.                                              ..           ,kNMMMMMMMMMMMMMMMMMMMMMMMMMM
//WNKxc'.                    .,::'.         ,dKWMMMMMMMWXkl'.                                                .cd:.          'xNMMMMMMMMMMMMMMMMMMMMMMMMM
//kc'.      .             .,lkkl'         'oKWMMMMMMMN0o,.                                                    'd0Ol'         .oKWWMMMMMMMMMMMMMMMMMMMMMM
//.     .',,.          .,oOX0d,         .cONWMMMMMMWKd:;;;;.                                                   .;dOkl'         ':okKNMMMMMMMMMMMMMMMMMMM
//   .'col,.         .ckXWNk;.         ,xXWMMMMMMMWNK000Ox:.                                                      .',,.           .'oKWMMMMMMMMMMMMMMMMM
//.'cxkd;.         'o0NWWKo.         .;OWMMMMMMMMMMMWN0o,.                                                                          .:oxOKWMMMMMMMMMMMMM
//O00x;.        .,dKWMMNk;.         .c0WMMMMMMMMMMMNOl'                                                                                 .;dO00KXWMMMMMMM
//WO:.         'dKWMMWXd'          .c0WMMMMMMMMMMNOl.                           ...                                                        ....,lONWMMMM
//x,         .oKWMMMWKl.           ;0WMMMMMMMMMN0l.                             ,o:.                ...                                          .c0WMMM
//.        .:ONMMMMW0:.           ,kNMMMMMMMMWKd'                               c0x,                .:ll;..                                       .:0WMM
//.       ,dXWMMMMWO;            .oXMMMMMMMMNO:.            .''.                cXNx'                .,ok0Oxl:,'.........                          .oXWM
//.     .cONMMMMMNk;             ;OWMMMMMMWXd'            .,l:.                 :KWNOc.                .:0WWWNNXK0OO000Okd:. ...                   .c0WM
//'    'oXWMMMMMWO,             .dXWMMMMMW0c.            .lx:.                  ,kNMWXOc'.              ,kNMMMMWWWWWWWMMMWNOco0Ol.. .              .lKWM
//:.  ,kNMMMMMMWO;              'OWMMMMMNk;             'dkc.                   .lKMMMWWKkl;.           .lKMMWWX0OkkkOKXNWMWNNMWXkddc.     .      .;kNMM
//l..:OWMMMMMMW0c              .:KMMMMMNx'             ,x0l.    ..               'xNMMMMMWWN0d:'.        'xNWMWNXKOdl:cldOXWMMMMWWWKl.  .:dl'   'lkXWMMM
//d,cKWMMMMMMMKl.              .lXMMMMXd'             'xKd.    .;;.               ,kWMMMMMMMMWNKxc.       'xNMMMMMWWXOo:;:oONWMMMMWk;..:xKNKd:cd0NMMMMMM
//0k0WMMMMMMMNx.               .dXMMWXd.             .dKO,     .od.              .,xNMMMMMMMMMMMWN0d;.     .l0NMMMMMMWNOo:;cxKWWWMW0kOKNWMMWNNNWMMMMMMMM
//WWWMMMMMMMWO;                'xNMMNx'             .cK0c.     .o0o.           .;xKWWMMMMMMMMMMMMMMWNOl.     'lONWMMMMMWXxc;:o0NWWWWWWMMMMMMMMWNNWMMMMMM
//MMMMMMMMMWXl.                'xNMNk,              ;0Nx.       ;OKd.       ..;xXWMMMMMMMMMMMMMMMMMMMMNOl.     .;d0NWMMMWNkc;;cxKWWMMMMMMMMMMWNOd0NWMMMM
//MMMMMMMMMNk,                 'xNWO;              .dNKc        .:0XOc.    .lkKWMMMMMMMMMMMMMMMMMMMMMMMMNO:.      .cONWMMWNkc;;:lkKNWMMMMMMWNKxc:xXWMMMM
//MMMMMMMMMKc.                 .dX0c.              ;OXx'         .;kNN0o:';dKWWMMMMMMMMMMMMMMMMMMMMMMMMMMWKl.       .l0WMMMXxc;;;:cdk0KXKKOkoc;;;lx0XWMM
//MMMMMMMMWk'                  .o0d.              .dXKl.           .cOXNNXXNWMMMMMMMMMMMMMMMMMMMMMMMMMMMMMW0c.       .:0WMMWXxc;;;;;;:ccc::;;;;;;;;:lxKW
//MMMMMMMWXo.                  .:d;               'OW0;              .,lkKWMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMNd.        .oKXXNWN0dl:;;;;;,;;;;;;;;;;;;;;oO
//MMMMMMMWO:.                   .'.               :KWO'                 .:0WMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMNk;.         .',l0WMWNX0kdollcccccccclooddoc:l
//MMMMMMMWk,                                     .lKNx.                  .oXMMMMMMMMMMMMMMMMMMMMMMMMMMMMWKx:,,'         .:kNWMMMMMWWNXXKKKKKKXXXNNWWN0xo
//MMMMMMMWKl.         ..                         .dXXd.    .''..          'kNWMMMMMMMMMMMMMMMMMMMMMMMMMMWNKK0x;   .,:cok0XWWMMMMMMMMMMMMMMMMMMMMMMMMMMN0
//MMMMMMMMWKo.        ,:.                        'xNXd.     .:ool;,...    .c0NWMMMMMMMMMMMMMMMMMMMMMMMMMMWXOl'  .:xKNWWMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMWW
//MMMMMMMMMMNd'      .ld.                        ,kNXd.       .;ldxkxxdddxk0NWMMMMMMMMMMMMMMMMMMMMMMMMMMWKkl:clxOXWMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM
//MMMMMMMMMMMNO;     ,xk'                        ,ONXd.          ..',:lodxkOOO0KNWMMMMMMMMMMMMMMMMMMMMMMWNNXNWWMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM
//MMMMMMMMMMMMW0c.   :OO,                        ,ONNx.                     ....cONMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM
//MMMMMMMMMMMMMWKl. .cK0c.                       ,ONWk.                          .ckKNWMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM
//MMMMMMMMMMMMMMWXd'.lKXd.                       ,kNMO,                            .':dOKNWWMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMWNXNMMMMM
//MMMMMMMMMMMMMMMMNxcdXW0:                       'xNMKc.                               .';lxKWMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMWNKkdx0NMMMMM
//MMMMMMMMMMMMMMMMMNXXNMNd.                      .dXMXo.                               ..,cxKWMWXOxxk0KKXNNWWWWWWWWWWWMMMMMMMMMMMMWWWWWNKOxo:,;o0NMMMMMM
//MMMMMMMMMMMMMMMMMMMMMMWKo.                     .lXMWO;            .............',;cldk0XNWNX0d:.  ....',,;:ccloodxxkk0XWMMWX0Okkxdoc:,.....cONWMMMMMMM
//MMMMMMMMMMMMMMMMMMMMMMMMKl.                     :KMMXl.         ..';:lodxxkOO00KKKKKKK0Okdc,.                       .c0WMNk;...         .cONWMMMMMMMMM
//MMMMMMMMMMMMMMMMMMMMMMMMWXo'                    ,OMMWk'              ..'',;;;::::;;,,'..                           .;OWWXd'           .cONWMMMMMMMMMMM
//MMMMMMMMMMMMMMMMMMMMMMMMMMNOo,.                 .xNMWKl.                                                          .l0NXk:.          'lONWMMMMMMMMMMMMM
//MMMMMMMMMMMMMMMMMMMMMMMMMMMMNKx:.               .oKWMWO,                                                        .cOXXk:.         .,o0NWMMMMMMMMMMMMMMM
//MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMWN0o,.            .:OWMMXo.                                                     'ckKOo;.         .:xKWMMMMMMMMMMMMMMMMMM
//MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMWXkc..          .xNMMWKc.                                                 .,codl,.         .,o0NWMMMMMMMMMMMMMMMMMMMM
//MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMWNKxc'         lXMMMWO;             .''.                                ....          .,lkXWMMMMMMMMMMMMMMMMMMMMMMM
//MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMWNKxc'.     ,kNMMMNk'             'cool;..                                      .,lkXWMMMMMMMMMMMMMMMMMMMMMMMMMM
//MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMWNKkl,.  .lKMMMMXd.             .,:lkOko:'..                             .':dOXWMMMMMMMMMMMMMMMMMMMMMMMMMMMMM
//MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMWX0xocdKMMMMWXo.                .:dOKX0kdl;,...                 .';cdOXNWMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM
//MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMWWWWWMMMMMWKo.                  .cx0XWWNNK0kxdolc::::::::cldxOKNWMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM
//MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMN0xol:;'.....         ..:oOXWMMMMMMWWWNNNNNNWWMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM
//MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMWWNXXK0Oxol:;,,'..... ..:xXWMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM
//
//   Iomega0318
//   Help and Support
//   https://www.uofreeshards.net/
//   Free Shard
//   https://www.atareborn.com/
//   GNU General Public License v3.0
#endregion

#region References
using System;
using System.Collections;
using Server;
using Server.Commands;
using Server.Items;
using Server.Mobiles;
using Server.Targeting;
using Server.Accounting;
#endregion

namespace Server.Items
{
    public class UltimateTubTarget : Target
    {
        private UltimateDyeTub m_Item;

        public UltimateTubTarget(UltimateDyeTub item) : base(12, false, TargetFlags.None)
        {
            m_Item = item;
        }

        protected override void OnTarget(Mobile from, object target)
        {
            if (target is EtherealMount)
            {
                EtherealMount EtherealMount = target as EtherealMount;

                if (EtherealMount.RootParent == from) // Make sure its in their pack
                {
                    EtherealMount.TransparentMountedHue = m_Item.Hue;
                    EtherealMount.Hue = m_Item.Hue;
                }
                else
                    from.SendMessage("You can only dye objects that are in your backpack!");
            }

            else if (target is BaseJewel || target is BaseArmor || target is BaseClothing || target is BaseShield || target is BaseWeapon || target is BaseSuit || target is BaseContainer || target is Item)
            {
                Item item = (Item)target;

                if (item.RootParent == from) // Make sure its in their pack or they are wearing it
                    item.Hue = m_Item.Hue;
                else
                    from.SendMessage("You can only dye objects that are in your backpack or on your person!");
            }

            else if (target is BaseCreature)
            {
                int totalGold = 0;

                if (from.Backpack != null)
                    totalGold += from.Backpack.GetAmount(typeof(Gold));

                totalGold += Banker.GetBalance(from);

                if (totalGold < m_Item.Cost)
                {
                    from.SendMessage("You cannot afford to dye your pet.");
                }
                else
                {
                    int leftPrice = m_Item.Cost;

                    if (from.Backpack != null)
                        leftPrice -= from.Backpack.ConsumeUpTo(typeof(Gold), leftPrice);

                    if (leftPrice > 0)
                        Banker.Withdraw(from, leftPrice);

                    BaseCreature c = target as BaseCreature;

                    if (c.Controlled && c.ControlMaster == from)
                    {
                        c.Hue = m_Item.Hue;
                        from.SendMessage("Removed " + m_Item.Cost.ToString("#,0") + " gold and hued your pet.");
                    }
                    else
                        from.SendMessage("You can only dye animals whom you control!");
                }
            }
        }
    }

    public class UltimateDyeTub : Item
    {
        private bool m_Redyable;
        private int i_Cost;

        [CommandProperty(AccessLevel.GameMaster)]
        public int Cost
        {
            get { return i_Cost; }
            set { i_Cost = value; }
        }

        [Constructable]
        public UltimateDyeTub() : base(0xFAB)
        {
            Weight = 0.0;
            Hue = 0;
            Name = "Ultimate Dye Tub";
            m_Redyable = false;
            Movable = false;
            i_Cost = 50000;
        }

        public UltimateDyeTub(Serial serial) : base(serial)
        {
        }

        public override void OnDoubleClick(Mobile from)
        {
            {
                from.Target = new UltimateTubTarget(this);
                from.SendMessage("You may now hue your backpack and worn equipment, " +
                    "you may also hue your pets for " + i_Cost.ToString("#,0") + " gold each.");
            }
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0); // version

            writer.Write(i_Cost);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();

            i_Cost = reader.ReadInt();

            if (Name == "Ultimate Dye Tub")
            {
                int intNumber = this.Hue;
                string strNumber = intNumber.ToString("#");
                Name = strNumber;
            }
        }
    }
}