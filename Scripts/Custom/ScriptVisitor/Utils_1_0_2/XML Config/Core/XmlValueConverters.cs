using System;
using System.Linq;

namespace Server.Custom.ScriptVisitor.Utils.XML_Config.Core
{
    public sealed class XmlValueConverters
    {
        public static object ConverterToInt(string value)
        {
            return Utility.ToInt32(value);
        }

        public static object ConverterToDouble(string value)
        {
            return Utility.ToDouble(value);
        }

        public static object ConverterToEnum(string value)
        {
            string enumTypeString = value.Remove(value.LastIndexOf('.')); // [Server.SkillName].AnimalLore
            string literal = value.Split('.').Last(); // Server.SkillName.[AnimalLore]
            Type type = ScriptCompiler.FindTypeByFullName(enumTypeString, false);
            return Enum.Parse(type, literal);
        }
    }
}
