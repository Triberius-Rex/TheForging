using Server.Custom.ScriptVisitor.Utils.Logger;
using Server.Engines.UOStore;
using Server.Items;
using System;

namespace Server.Custom.ScriptVisitor.Utils.XML_Config.Core
{
    public static class ItemInstanceUtil
    {
        public static bool IsConstructable(BasicItemFromXml xmlItem)
        {
            Type type = ScriptCompiler.FindTypeByFullName(xmlItem.ItemClassName, false);

            if (type == null)
            {
                SVLogger.Warn("Putting error indicator -> '{0}' could not be found.", xmlItem.ItemClassName);
                return false;
            }
            if (!type.IsSubclassOf(typeof(Item)))
            {
                SVLogger.Warn("Putting error indicator -> '{0}' is not a subclass of '{1}'.", xmlItem.ItemClassName, typeof(Item));
                return false;
            }

            try
            {
                Item item;
                if (xmlItem.ItemConstructorArgs.Count > 0)
                    item = Activator.CreateInstance(type, xmlItem.GetTypedConstructorArgValues()) as Item;
                else
                    item = Activator.CreateInstance(type) as Item;
                item.Delete();
            }
            catch (Exception e)
            {
                SVLogger.Warn(e, "Putting error indicator -> '{0}' instantiation failed:", xmlItem.ItemClassName);
                return false;
            }
            return true;
        }

        public static Item GetConstructedItem(BasicItemFromXml xmlItem)
        {
            if (xmlItem == null)
                return null;

            Type type = ScriptCompiler.FindTypeByFullName(xmlItem.ItemClassName, false);

            if (xmlItem.ItemConstructorArgs.Count > 0)
                return Activator.CreateInstance(type, xmlItem.GetTypedConstructorArgValues()) as Item;
            else
                return Activator.CreateInstance(type) as Item;
        }

        public static Item ErrorItemCallback(int _1)
        {
            return new Gold(1);
        }

        public static Item ErrorItemCallback(Mobile _1, StoreEntry _2)
        {
            return null;
        }
    }
}
