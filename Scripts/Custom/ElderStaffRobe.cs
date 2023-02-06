// Script made by Delinquent. I wanted a better version of the StaffRobe.

using Server.ContextMenus;
using System.Collections.Generic;

namespace Server.Items
{
    public class ElderStaffRobe : BaseSuit
    {
        private static Mobile m_Owner;
        private AccessLevel m_GMLevel;
        private int myHue;
        private List<Item> _ItemsToDelete = new List<Item>();
        private List<Item> _ItemsToMove = new List<Item>();
        private List<Item> _StoredItems = new List<Item>();
        private List<Item> _WeaponSelect = new List<Item>();

        [Constructable]
        public ElderStaffRobe()
            : base(AccessLevel.Player, 1177, 0x2683)
        {
            LootType = LootType.Blessed;
            Weight = 0;
            Name = "Elder Robe";
        }
        [Constructable]
        public ElderStaffRobe(Mobile player)
            : base(player.AccessLevel, 1177, 0x2683)
        {
            LootType = LootType.Blessed;
            Weight = 0;
            Name = player.Name + "'s Elder Robe";
            m_Owner = player;
            m_GMLevel = player.AccessLevel;
        }
        public ElderStaffRobe(Serial serial)
            : base(serial)
        {
        }

        public override bool OnEquip(Mobile from)
        {
            if (from.IsStaff() && m_Owner == null)
            {
                ItemID = 0x204F;
                m_Owner = from;
                m_GMLevel = from.AccessLevel;
                
                switch (from.AccessLevel)
                {
                    case AccessLevel.Owner:
                        myHue = 0x497;
                        Hue = myHue;
                        break;
                    case AccessLevel.CoOwner:
                        myHue = 0x481;
                        Hue = myHue;
                        break;
                    case AccessLevel.Developer:
                        myHue = 0x498;
                        Hue = myHue;
                        break;
                    case AccessLevel.Administrator:
                        myHue = 0x47E;
                        Hue = myHue;
                        break;
                    case AccessLevel.Seer:
                        myHue = 0x494;
                        Hue = myHue;
                        break;
                    case AccessLevel.GameMaster:
                        myHue = 0x5B5;
                        Hue = myHue;
                        break;
                    case AccessLevel.Spawner:
                        myHue = 0x493;
                        Hue = myHue;
                        break;
                    case AccessLevel.Decorator:
                        myHue = 0x493;
                        Hue = myHue;
                        break;
                    case AccessLevel.Counselor:
                        myHue = 0x5B6;
                        Hue = myHue;
                        break;
                }
            }
            else if ((from.IsStaff() && m_Owner == from) || (from.IsPlayer() && m_Owner == from))
            {
                if (from.AccessLevel < AccessLevel.Counselor)
                {
                    ItemID = 0x1F03;
                    Hue = myHue;
                    from.SendMessage("The robe remembers you {0}. ({1})", from.Name, m_GMLevel);
                }
                else
                {
                    ItemID = 0x204F;
                    Hue = myHue;
                    from.SendMessage("The robe remembers you {0}. ({1})", from.Name, m_GMLevel);
                }
            }
            else
            {
                from.SendMessage("Not sure how you obtained this robe, but its going bye bye.");
                from.PlaySound(0x1FE);
                Delete();
            }
            return from == m_Owner;
        }

        public override void OnRemoved(object parent)
        {
            if (ItemID == 0x204F || ItemID == 0x1F03)
            {
                ItemID = 0x2683;
                Hue = 1177;
            }
        }

        public override void OnDoubleClick(Mobile from)
        {
            Item m_item = this;
            if(m_Owner == null && from.IsStaff())
            {
                m_Owner = from;
                m_GMLevel = from.AccessLevel;
                from.SendMessage("This robe has been assigned to your character.");
            }
            else if (m_Owner == null && from.IsPlayer())
            {
                from.SendMessage("You Must be in GM Form to assign this robe to yourself for the first time.");
            }
            else if (m_Owner == from)
            {
                if (ItemID == 0x204F && from.Items.Contains(m_item)) // Turn into a player.
                {
                    from.SendMessage("Your godly powers fade away... But not your strength!");
                    ItemID = 0x1F03;
                    Weight = 1.0;
                    from.AccessLevel = AccessLevel.Player;
                    from.Blessed = false;
                    StartEquipItem(from);
                                     
                }
                else if (ItemID == 0x1F03 && from.Items.Contains(m_item)) // Turn Back into your staff form.
                {
                    from.SendMessage("Your powers have returned!");
                    ItemID = 0x204F;
                    from.AccessLevel = m_GMLevel;
                    from.Blessed = true;
                    StartEquipItem(from);
                }
                else
                {
                    from.SendMessage("You must have this item equipped first.");
                }
            }
        }

        public static void GetContextMenuEntries(Mobile from, Item item, List<ContextMenuEntry> list)
        {
            list.Add(new SwordAndShield(item));
            list.Add(new MaceAndShield(item));
            list.Add(new PierceAndShield(item));
        }

        public override void GetContextMenuEntries(Mobile from, List<ContextMenuEntry> list)
        {
            if (m_Owner == null || m_Owner.AccessLevel == AccessLevel.Player)
            {
                return;
            }
            else
            {
                if (m_Owner != from)
                {
                    from.SendMessage("This is not yours to use.");
                    return;
                }
                else
                {
                    base.GetContextMenuEntries(from, list);
                    GetContextMenuEntries(from, this, list);
                }
            }
        }

        private void StartEquipItem(Mobile player)
        {
            Container pack = player.Backpack;

            if (player.IsPlayer())
            {
                foreach (Item items in player.Items)
                {
                    if (items.Layer == Layer.OuterTorso || items.Layer == Layer.Backpack || items.Layer == Layer.Mount || items.Layer == Layer.Hair || items.Layer == Layer.FacialHair || items.Layer == Layer.Ring || items.Layer == Layer.MiddleTorso || items.Layer == Layer.Cloak)
                    {
                        continue;
                    }
                    else
                        _ItemsToMove.Add(items);
                }
                foreach (Item items in _ItemsToMove)
                {
                    pack.AddItem(items);
                }
                foreach (Item items in _WeaponSelect)
                {
                    player.EquipItem(items);
                }
            }
            else if(player.IsStaff())
            {
                foreach (Item items in player.Items)
                {
                    if (items.Layer == Layer.OuterTorso || items.Layer == Layer.Backpack || items.Layer == Layer.Mount || items.Layer == Layer.Hair || items.Layer == Layer.FacialHair || items.Layer == Layer.Ring || items.Layer == Layer.MiddleTorso || items.Layer == Layer.Cloak)
                    {
                        continue;
                    }
                    else
                        _ItemsToDelete.Add(items);
                }
                foreach (Item items in _ItemsToDelete)
                {
                    items.Delete();
                }
                if (_StoredItems != _ItemsToMove)
                {
                    _StoredItems.Clear();

                    foreach(Item items in _ItemsToMove)
                    {
                        _StoredItems.Add(items);
                    }
                }
                foreach (Item items in _StoredItems)
                {
                    player.EquipItem(items);
                }
                _ItemsToMove.Clear();
            }
        }

        private class SwordAndShield : ContextMenuEntry //Sword and Board
        {
            private readonly ElderStaffRobe m_Item;

            public SwordAndShield(Item item)
                : base(1002151, -1) //Swordsmanship
            {
                m_Item = (ElderStaffRobe)item;
            }

            public override void OnClick()
            {
                m_Item._WeaponSelect.Clear();
                m_Item._WeaponSelect.Add(new JocklesQuicksword());
                m_Item._WeaponSelect.Add(new OrderShield());
                m_Item._WeaponSelect.Add(new PlateHelm());
                m_Item._WeaponSelect.Add(new PlateGorget());
                m_Item._WeaponSelect.Add(new PlateChest());
                m_Item._WeaponSelect.Add(new PlateArms());
                m_Item._WeaponSelect.Add(new PlateGloves());
                m_Item._WeaponSelect.Add(new PlateLegs());
            }
        }

        private class MaceAndShield : ContextMenuEntry //Mace and Board
        {
            private readonly ElderStaffRobe m_Item;

            public MaceAndShield(Item item)
                : base(1044101, -1) // Mace Fighting
            {
                m_Item = (ElderStaffRobe)item;
            }

            public override void OnClick()
            {
                m_Item._WeaponSelect.Clear();
                m_Item._WeaponSelect.Add(new ChurchillsWarMace());
                m_Item._WeaponSelect.Add(new ChaosShield());
                m_Item._WeaponSelect.Add(new ChainCoif());
                m_Item._WeaponSelect.Add(new StuddedGorget());
                m_Item._WeaponSelect.Add(new ChainChest());
                m_Item._WeaponSelect.Add(new RingmailArms());
                m_Item._WeaponSelect.Add(new RingmailGloves());
                m_Item._WeaponSelect.Add(new ChainLegs());
                m_Item._WeaponSelect.Add(new Boots());
            }
        }

        private class PierceAndShield : ContextMenuEntry
        {
            private readonly ElderStaffRobe m_Item;

            public PierceAndShield(Item item)
                : base(1002073, -1)
            {
                m_Item = (ElderStaffRobe)item;
            }

            public override void OnClick()
            {
                m_Item._WeaponSelect.Clear();
                m_Item._WeaponSelect.Add(new TheTaskmaster());
                m_Item._WeaponSelect.Add(new MetalShield());
                m_Item._WeaponSelect.Add(new LeatherCap());
                m_Item._WeaponSelect.Add(new LeatherGorget());
                m_Item._WeaponSelect.Add(new LeatherChest());
                m_Item._WeaponSelect.Add(new LeatherArms());
                m_Item._WeaponSelect.Add(new LeatherGloves());
                m_Item._WeaponSelect.Add(new LeatherLegs());
                m_Item._WeaponSelect.Add(new Boots());

            }
        }

        private static void EquipItem(Item item)
        {
            EquipItem(item, false);
        }

        private static void EquipItem(Item item, bool mustEquip)
        {
            if (!Core.AOS)
                item.LootType = LootType.Newbied;

            if (m_Owner != null && m_Owner.EquipItem(item))
                return;

            var pack = m_Owner.Backpack;

            if (!mustEquip && pack != null)
                pack.DropItem(item);
            else
                item.Delete();
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0); // version
            writer.Write(Name);
            writer.Write(m_Owner);
            writer.WriteEncodedInt((int)m_GMLevel);
            writer.Write(myHue);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
            
            switch (version)
            {
                case 0:
                    Name = reader.ReadString();
                    m_Owner = reader.ReadMobile();
                    m_GMLevel = (AccessLevel)reader.ReadEncodedInt();
                    myHue = reader.ReadInt();
                    break;                    
            }
        }
    }
}
