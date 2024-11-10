using Server.Custom.ScriptVisitor.Utils.Logger;
using Server.Custom.ScriptVisitor.Utils.XML_Config.Core;
using Server.Engines.UOStore;
using Server.Gumps;
using Server.Mobiles;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;

namespace Server.Custom.ScriptVisitor.UltimaStoreItems
{
    internal class USItemsSetup
    {
        private static readonly string m_UltimaStoreItemsConfigPath = Path.Combine("Data", "UltimaStoreItems.xml");
        private static readonly Dictionary<int, int> m_StoreEntryIndexToXmlItemIndexMap = new Dictionary<int, int>();
        private static readonly List<UltimaStoreXmlItem> m_XmlItems = new List<UltimaStoreXmlItem>();

        public static void Initialize()
        {
            SVLogger.Info("UltimaStore XML Configurator - Initializing from configuration '{0}'", m_UltimaStoreItemsConfigPath);
            XmlTagDefinition[] tags = new XmlTagDefinition[]
            {
                // <iconItemId> / <iconGumpId> and <itemClassName> + [constructor] are given as mandatory from base
                new XmlTagDefinition("category", XmlValueConverters.ConverterToEnum, true),
                new XmlTagDefinition("tooltipLocalized", XmlValueConverters.ConverterToInt),
                new XmlTagDefinition("tooltipText"),
                new XmlTagDefinition("iconHue", XmlValueConverters.ConverterToInt),
                new XmlTagDefinition("cost", XmlValueConverters.ConverterToInt)
            };

            XmlItemsConfig<UltimaStoreXmlItem> storeItemsConfig = new XmlItemsConfig<UltimaStoreXmlItem>(m_UltimaStoreItemsConfigPath, "//ultimaStoreItem", tags);

            m_XmlItems.AddRange(storeItemsConfig.XmlItems);

            string wipeOsiItems = storeItemsConfig.GetXmlPropertyRawValue("//clearOsiUltimaStoreItems");
            if (wipeOsiItems != null && bool.Parse(wipeOsiItems))
            {
                SVLogger.Info("UltimaStore XML Configurator - Clearing existing items in Ultima Store");
                UltimaStore.Entries.Clear();
            }
            else
            {
                SVLogger.Info("UltimaStore XML Configurator - Keeping existing items in Ultima Store");
            }
            int successCount = RegisterItemsInUltimaStore();
            SVLogger.Info("UltimaStore XML Configurator - Done initializing, a total of {0}/{1} items was loaded successfully", successCount, storeItemsConfig.XmlItems.Count);

            Server.Commands.CommandSystem.Register("ReloadUOSItems", AccessLevel.Administrator, e =>
            {
                // reload config
                SVLogger.Info("UltimaStore XML Configurator - '{0}':'{1}' requested a hot reload for items in UO Store", e.Mobile.Account, e.Mobile.Name);
                XmlItemsConfig<UltimaStoreXmlItem> newStoreItemsConfig = new XmlItemsConfig<UltimaStoreXmlItem>(m_UltimaStoreItemsConfigPath, "//ultimaStoreItem", tags);

                // check some warning conditions
                bool isNowOsiItems = UltimaStore.Entries.Count - m_XmlItems.Count > 0;
                bool isThenClearOsiItems = false;
                wipeOsiItems = newStoreItemsConfig.GetXmlPropertyRawValue("//clearOsiUltimaStoreItems");
                isThenClearOsiItems = wipeOsiItems != null && bool.Parse(wipeOsiItems);

                string warnOsiItems = "";
                if (isNowOsiItems && isThenClearOsiItems)
                {
                    warnOsiItems = string.Format("New config will remove {0} OSI items!<BR />", UltimaStore.Entries.Count - m_XmlItems.Count);
                }
                if (!isNowOsiItems && !isThenClearOsiItems)
                {
                    warnOsiItems = "New config can't hot reload OSI items!<BR />";
                }
                string infoTxt = String.Format(
                    warnOsiItems +
                    "By selecting yes, the config reloads<BR />" +
                    "<DIV ALIGN=RIGHT>Drop current custom items:{0,5}</DIV>" +
                    "<DIV ALIGN=RIGHT>Add then custom items:{1,5}</DIV>", m_XmlItems.Count, newStoreItemsConfig.XmlItems.Count);

                // apply reload
                BaseGump.SendGump(new GenericConfirmCallbackGump<Object>((PlayerMobile)e.Mobile,
                    "Reload UO Store items?",
                                infoTxt,
                                null,
                                null,
                                (from, nil) =>
                                {
                                    SVLogger.Info("UltimaStore XML Configurator - Now applying hot reloaded items to Ultima Store");
                                    if (isThenClearOsiItems)
                                    {
                                        SVLogger.Info("UltimaStore XML Configurator - Clearing OSI items in Ultima Store");
                                        UltimaStore.Entries.Clear();
                                    }
                                    else
                                    {
                                        SVLogger.Info("UltimaStore XML Configurator - Try keeping OSI items in Ultima Store (if not removed in between)");

                                        // remove current custom registered items from store
                                        UltimaStore.Entries.RemoveAll(k => m_StoreEntryIndexToXmlItemIndexMap.ContainsKey(k.Index));
                                    }

                                    // reset state...
                                    m_StoreEntryIndexToXmlItemIndexMap.Clear();
                                    m_XmlItems.Clear();
                                    m_XmlItems.AddRange(newStoreItemsConfig.XmlItems);
                                    // ...and reload items from new configuration
                                    successCount = RegisterItemsInUltimaStore();
                                    SVLogger.Info("UltimaStore XML Configurator - Done reinitializing, a total of {0}/{1} items was loaded successfully", successCount, newStoreItemsConfig.XmlItems.Count);
                                    
                                    from.SendMessage("UO Store configuration reloaded, a total of {0}/{1} items was applied successfully", successCount, newStoreItemsConfig.XmlItems.Count);
                                }));

            });
        }

        private static int RegisterItemsInUltimaStore()
        {
            int successCount = 0;
            for (int i = 0; i < m_XmlItems.Count; i++)
            {
                UltimaStoreXmlItem xmlItem = m_XmlItems[i];

                if (!xmlItem.IsMandatoryFieldsSet() || !ItemInstanceUtil.IsConstructable(xmlItem))
                {
                    UltimaStore.Register<Item>("ERROR", "ERROR SETTING THE ITEM, PLEASE INFORM STAFF", 0x1B7A, 0, 0x6F3, 50001 + i, StoreCategory.Featured, ItemInstanceUtil.ErrorItemCallback);
                    continue;
                }
                if (xmlItem.TooltipLocalized > 0)
                    UltimaStore.Register<Item>(xmlItem.Names.ToArray(), xmlItem.TooltipLocalized, xmlItem.IconItemId, xmlItem.IconGumpId, xmlItem.IconHue, xmlItem.Cost, xmlItem.Category, GenericBodRewardItemCallback);
                else
                    UltimaStore.Register<Item>(xmlItem.Names.ToArray(), xmlItem.TooltipText, xmlItem.IconItemId, xmlItem.IconGumpId, xmlItem.IconHue, xmlItem.Cost, xmlItem.Category, GenericBodRewardItemCallback);

                int lastRecentlyAddedStoreEntryIndex = UltimaStore.Entries.Last().Index;
                m_StoreEntryIndexToXmlItemIndexMap[lastRecentlyAddedStoreEntryIndex] = i;
                successCount++;
            }
            return successCount;
        }

        private static Item GenericBodRewardItemCallback(Mobile m, StoreEntry entry)
        {
            if (!m_StoreEntryIndexToXmlItemIndexMap.TryGetValue(entry.Index, out int xmlItemIndex))
                return null;

            return ItemInstanceUtil.GetConstructedItem(m_XmlItems[xmlItemIndex]);
        }

        private class UltimaStoreXmlItem : BasicItemFromXml
        {
            public StoreCategory Category { get; set; }
            #region optional fields
            public string TooltipText { get; set; }
            public List<TextDefinition> Names { get; set; }
            public int TooltipLocalized { get; set; }
            public int IconHue { get; set; }
            public int Cost { get; set; }
            #endregion

            public UltimaStoreXmlItem()
            {
                Names = new List<TextDefinition>();
                Category = StoreCategory.None;
            }

            public override void ApplyXmlMapping(XmlNode itemSettingNode, XmlTagDefinition attributeDef)
            {
                switch (itemSettingNode.Name)
                {
                    case "category": Category = (StoreCategory) attributeDef.GetContentValue(itemSettingNode); break;
                    case "tooltipText": TooltipText = (string) attributeDef.GetContentValue(itemSettingNode); break;
                    case "tooltipLocalized": TooltipLocalized = (int) attributeDef.GetContentValue(itemSettingNode); break;
                    case "iconHue": IconHue = (int) attributeDef.GetContentValue(itemSettingNode); break;
                    case "cost": Cost = (int) attributeDef.GetContentValue(itemSettingNode); break;
                    case "multiLineTextName":
                        { // parse names (if exists)
                            foreach (XmlNode namesNode in itemSettingNode.ChildNodes)
                            {
                                if (!namesNode.Name.Equals("textName"))
                                    continue;

                                Names.Add(namesNode.InnerText);
                            }
                        }
                        break;
                    case "multiLineLocalizedName":
                        { // parse localized names - ID (if exists)
                            foreach (XmlNode namesNode in itemSettingNode.ChildNodes)
                            {
                                if (!namesNode.Name.Equals("localizedName"))
                                    continue;

                                Names.Add(Utility.ToInt32(namesNode.InnerText));
                            }
                        }
                        break;
                    default:
                        base.ApplyXmlMapping(itemSettingNode, attributeDef); break;
                }
            }
        }
    }
}
