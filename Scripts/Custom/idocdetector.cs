/* Dan and Dexter of the Heritage Shard (https://trueuo.com) */
using Server.Multis;
using Server.Network;
using System;
using System.Collections.Generic;
using Server.Regions;

namespace Server.Items
{
    public class IDOCDetector : Item
    {
        private const int _Red = 0x26;
        private const int _Yellow = 0x35;
        private const int _Green = 0x55B;

        public override bool ForceShowProperties => true;

        private static Timer Timer { get; set; }
        private static List<IDOCDetector> Detectors { get; set; }

        [Constructable]
        public IDOCDetector()
            : base(8928)
        {
            Name = "Housing Assessor";
            Movable = false;
            Weight = 0;

            if (Detectors == null)
            {
                Detectors = new List<IDOCDetector>();
            }

            Detectors.Add(this);

            if (Timer == null)
            {
                Timer = Timer.DelayCall(TimeSpan.FromMinutes(5), TimeSpan.FromMinutes(5), OnTick);
                Timer.Start();
            }
        }

        public override void OnDoubleClick(Mobile m)
        {
            if (Cooldown == null || !Cooldown.ContainsKey(m) || Cooldown[m] < DateTime.UtcNow)
            {
                if (m.InRange(Location, 3))
                {
                    var count = GetHouseCount();
                    var iCount = GetIDOCCount();
                    var gCount = GetGreatlyCount();

                    PrivateOverheadMessage(MessageType.Regular, 453, false, $"There are currently {count} placed houses with {iCount} in danger of collapsing and {gCount} that are greatly worn.", m.NetState);

                    if (Cooldown == null)
                    {
                        Cooldown = new Dictionary<Mobile, DateTime>();
                    }

                    Cooldown[m] = DateTime.UtcNow + TimeSpan.FromSeconds(10);

                    Defrag();
                }
                else
                {
                    m.SendLocalizedMessage(500446); // That is too far away.
                }
            }
            else
            {
                m.SendMessage("You must wait a moment before using this again."); 
            }
        }

        private static Dictionary<Mobile, DateTime> Cooldown { get; set; }

        private static void Defrag()
        {
            if (Cooldown == null)
            {
                return;
            }

            var remove = new List<Mobile>();

            foreach (var kvp in Cooldown)
            {
                if (kvp.Value < DateTime.UtcNow)
                {
                    remove.Add(kvp.Key);
                }
            }

            for (var index = 0; index < remove.Count; index++)
            {
                var m = remove[index];

                Cooldown.Remove(m);
            }

            ColUtility.Free(remove);
        }

        private static int GetHouseCount()
        {
            int count = 0;

            for (var index = 0; index < BaseHouse.AllHouses.Count; index++)
            {
                var h = BaseHouse.AllHouses[index];

                if (h.Map != null && h.Map != Map.Internal && !h.Region.IsPartOf<GreenAcres>())
                {
                    count++;
                }
            }

            return count;
        }

        private static int GetIDOCCount()
        {
            int count = 0;

            for (var index = 0; index < BaseHouse.AllHouses.Count; index++)
            {
                var h = BaseHouse.AllHouses[index];

                if (h.DecayLevel == DecayLevel.IDOC && h.Map != null && h.Map != Map.Internal && !h.Region.IsPartOf<GreenAcres>())
                {
                    count++;
                }
            }

            return count;
        }

        private static int GetGreatlyCount()
        {
            int count = 0;

            for (var index = 0; index < BaseHouse.AllHouses.Count; index++)
            {
                var h = BaseHouse.AllHouses[index];

                if (h.DecayLevel == DecayLevel.Greatly && h.Map != null && h.Map != Map.Internal && !h.Region.IsPartOf<GreenAcres>())
                {
                    count++;
                }
            }

            return count;
        }

        public override void GetProperties(ObjectPropertyList list)
        {
            base.GetProperties(list);

            list.Add("Double Click: Assesses the state of house decay");
        }

        public override void Delete()
        {
            base.Delete();

            if (Detectors != null)
            {
                Detectors.Remove(this);

                if (Detectors.Count == 0)
                {
                    if (Timer != null)
                    {
                        Timer.Stop();
                        Timer = null;
                    }

                    Detectors = null;
                }
            }
        }

        public IDOCDetector(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0);

            Defrag();
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            reader.ReadInt();

            if (Detectors == null)
            {
                Detectors = new List<IDOCDetector>();
            }

            Detectors.Add(this);

            if (Timer == null)
            {
                Timer = Timer.DelayCall(TimeSpan.FromMinutes(5), TimeSpan.FromMinutes(5), OnTick);
                Timer.Start();
            }
        }

        private static void OnTick()
        {
            if (Detectors == null)
            {
                if (Timer != null)
                {
                    Timer.Stop();
                    Timer = null;
                }
            }
            else
            {
                for (var index = 0; index < Detectors.Count; index++)
                {
                    var d = Detectors[index];

                    if (GetIDOCCount() > 0 && d.Hue != _Red)
                    {
                        d.Hue = _Red;
                    }
                    else if (GetGreatlyCount() > 0 && GetIDOCCount() == 0 && d.Hue != _Yellow)
                    {
                        d.Hue = _Yellow;
                    }
                    else if (GetGreatlyCount() == 0 && GetIDOCCount() == 0 && d.Hue != _Green)
                    {
                        d.Hue = _Green;
                    }
                }
            }
        }
    }
}