using System;
using System.Xml;

namespace Server.Custom.ScriptVisitor.Utils.XML_Config.Core
{
    public class XmlTagDefinition
    {
        public virtual string XmlTagName { get; set; }
        public virtual Func<string, object> ForcedValueConverter { get; set; }
        public virtual bool IsMandatory { get; set; }

        public XmlTagDefinition(string xmlTagName, Func<string, object> forcedValueConverter, bool isMandatory = false)
        {
            XmlTagName = xmlTagName;
            ForcedValueConverter = forcedValueConverter;
            IsMandatory = isMandatory;
        }

        public XmlTagDefinition(string xmlTagName, bool isMandatory = false)
            : this(xmlTagName, null, isMandatory)
        {
        }

        public virtual object GetContentValue(XmlNode node)
        {
            if (node == null || string.IsNullOrWhiteSpace(node.InnerText))
                return null;

            XmlAttribute nodeType = node.Attributes["type"];
            string rawValue = node.InnerText.Trim();

            if (ForcedValueConverter != null)
                return ForcedValueConverter.Invoke(rawValue); // forced converter is used

            if (nodeType == null || string.IsNullOrWhiteSpace(nodeType.InnerText) || "string".Equals(nodeType.InnerText.Trim()))
                return rawValue; // default type of value is "string"

            switch (nodeType.InnerText.Trim())
            { // resolve type of value
                case "int":
                case "hex":
                    return XmlValueConverters.ConverterToInt(rawValue);
                case "double":
                    return XmlValueConverters.ConverterToDouble(rawValue);
                case "enum":
                    return XmlValueConverters.ConverterToEnum(rawValue);
                default:
                    // could not map type, maybe override method and implement mapping there
                    return node;
            }
        }
    }
}
