using Server.Custom.ScriptVisitor.Utils.Logger;
using System;
using System.Collections.Generic;
using System.Xml;

namespace Server.Custom.ScriptVisitor.Utils.XML_Config.Core
{
    public class XmlItemsConfig<T> where T : BasicItemFromXml
    {
        protected readonly Dictionary<string, XmlTagDefinition> m_NameToTagDefinitionMap;
        protected readonly XmlDocument m_Document = new XmlDocument();

        public List<T> XmlItems { get; private set; }

        public XmlItemsConfig(string configFilePath, string itemsXpath, XmlTagDefinition[] xmlTagDefinitions)
        {
            SVLogger.Debug("XmlItemsConfig - Start initializing configuration '{0}'", configFilePath);
            m_NameToTagDefinitionMap = new Dictionary<string, XmlTagDefinition>();

            foreach (XmlTagDefinition definition in xmlTagDefinitions)
            {
                m_NameToTagDefinitionMap.Add(definition.XmlTagName, definition);
            }

            // basic xml elements to define an item
            m_NameToTagDefinitionMap.Add("iconItemId", new XmlTagDefinition("iconItemId", XmlValueConverters.ConverterToInt));
            m_NameToTagDefinitionMap.Add("iconGumpId", new XmlTagDefinition("iconGumpId", XmlValueConverters.ConverterToInt));
            m_NameToTagDefinitionMap.Add("itemClassName", new XmlTagDefinition("itemClassName", true));

            XmlItems = ReadConfig(configFilePath, itemsXpath);
            SVLogger.Debug("XmlItemsConfig - Done initializing configuration '{0}'", configFilePath);
        }

        #region XML handling

        public XmlDocument GetXmlDocument()
        {
            return m_Document;
        }

        public string GetXmlPropertyRawValue(string xpath)
        {
            XmlNodeList propertyNodes = m_Document.SelectNodes(xpath);
            if (propertyNodes.Count == 0)
                return null;

            return propertyNodes[0].InnerText;
        }

        private void LoadDocument(string configFilePath)
        {
            XmlReaderSettings xmlReaderSettings = new XmlReaderSettings();
            xmlReaderSettings.IgnoreComments = true;

            XmlReader xmlReader = XmlReader.Create(configFilePath, xmlReaderSettings);

            m_Document.Load(xmlReader);
        }

        private List<T> ReadConfig(string configFilePath, string itemsXpath)
        {
            List<T> results = new List<T>();

            try
            {
                LoadDocument(configFilePath);

                foreach (XmlNode xmlDefinedItem in m_Document.SelectNodes(itemsXpath))
                {
                    T parsedRawItem = (T)Activator.CreateInstance(typeof(T));
                    parsedRawItem.ItemConstructorArgs = new List<ConstructorArg>();

                    InternParseItem(xmlDefinedItem.ChildNodes, parsedRawItem);

                    results.Add(parsedRawItem);
                }
                return results;

                void InternParseItem(XmlNodeList fromXmlNodes, BasicItemFromXml toRawItem)
                {
                    foreach (XmlNode itemPropertyXmlNode in fromXmlNodes)
                    {
                        string tagName = itemPropertyXmlNode.Name;

                        if (tagName.Equals("itemConstructorArgs"))
                        { // parse item constructor args (if exists)
                            foreach (XmlNode itemConstructorArg in itemPropertyXmlNode.ChildNodes)
                            {
                                if (!itemConstructorArg.Name.Equals("arg"))
                                    continue;

                                toRawItem.ItemConstructorArgs.Add(new ConstructorArg(new XmlTagDefinition("arg"), itemConstructorArg));
                            }
                        }
                        else
                        { // callback mapping the tag
                            m_NameToTagDefinitionMap.TryGetValue(tagName, out XmlTagDefinition itemPropertyDefinition);

                            toRawItem.ApplyXmlMapping(itemPropertyXmlNode, itemPropertyDefinition);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                SVLogger.Error(e, "Error parsing config file '{0}'", configFilePath);
            }
            return results;
        }

        #endregion
    }

    #region XML DTOs

    public class BasicItemFromXml
    {
        #region mandatory fields

        public int IconItemId { get; private set; }
        public int IconGumpId { get; private set; }
        public string ItemClassName { get; private set; }

        #endregion

        #region optional fields

        public List<ConstructorArg> ItemConstructorArgs { get; set; }

        #endregion

        public BasicItemFromXml() { }

        public virtual bool IsMandatoryFieldsSet()
        {
            if (string.IsNullOrWhiteSpace(ItemClassName))
            {
                SVLogger.Warn("Putting error indicator -> The item has no '<itemClassName>' value set.");
                return false;
            }
            if (IconItemId == 0 && IconGumpId == 0)
            {
                SVLogger.Warn("Putting error indicator -> '{0}' must have at least an <iconItemId> OR an <iconGumpId> value set.", ItemClassName);
                return false;
            }
            return true;
        }

        public virtual object[] GetTypedConstructorArgValues()
        {
            if (ItemConstructorArgs == null || ItemConstructorArgs.Count == 0)
                return new object[0];

            List<object> results = new List<object>();
            foreach (ConstructorArg constructorArg in ItemConstructorArgs)
                results.Add(constructorArg.GetTypedValue());

            return results.ToArray();
        }

        public virtual void ApplyXmlMapping(XmlNode itemPropertyXmlNode, XmlTagDefinition itemPropertyDefinition)
        {
            switch (itemPropertyXmlNode.Name)
            {
                case "iconItemId": IconItemId = (int) itemPropertyDefinition.GetContentValue(itemPropertyXmlNode); break;
                case "iconGumpId": IconGumpId = (int) itemPropertyDefinition.GetContentValue(itemPropertyXmlNode); break;
                case "itemClassName": ItemClassName = (string) itemPropertyDefinition.GetContentValue(itemPropertyXmlNode); break;
                default:
                    throw new NotImplementedException(string.Format("Tag '{0}' in item '{1}' is not implemented yet.", itemPropertyXmlNode.Name, this.GetType()));
            }
        }
    }

    public class ConstructorArg
    {
        protected readonly XmlTagDefinition m_ArgTagDefinition;
        protected readonly XmlNode m_ArgNode;

        public ConstructorArg(XmlTagDefinition argTagDefinition, XmlNode argNode)
        {
            m_ArgTagDefinition = argTagDefinition;
            m_ArgNode = argNode;
        }

        public virtual object GetTypedValue()
        {
            return m_ArgTagDefinition.GetContentValue(m_ArgNode);
        }
    }

    #endregion
}
