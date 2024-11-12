/***************************************************************************
 *                               GumpTooltip.cs
 *                            -------------------
 *   begin                : May 1, 2002
 *   copyright            : (C) The RunUO Software Team
 *   email                : info@runuo.com
 *
 *   $Id$
 *
 ***************************************************************************/

/***************************************************************************
 *
 *   This program is free software; you can redistribute it and/or modify
 *   it under the terms of the GNU General Public License as published by
 *   the Free Software Foundation; either version 2 of the License, or
 *   (at your option) any later version.
 *
 ***************************************************************************/

using System;
using Server.Network;

namespace Server.Gumps
{
    public class GumpTooltip : GumpEntry
    {
        private int m_Number;
        private string m_Text;
        public GumpTooltip(int number)
        {
            m_Number = number;
        }

        public GumpTooltip(string text)
        {
            m_Text = text;
        }

        public int Number
        {
            get
            {
                return m_Number;
            }
            set
            {
                Delta(ref m_Number, value);
            }
        }

        public string Text
        {
            get
            {
                return m_Text;
            }
            set
            {
                Delta(ref m_Text, value);
            }
        }

        public override string Compile()
        {
            if (m_Number == 0 && !string.IsNullOrEmpty(m_Text))
            { // if given: use custom text # TODO UNCHECKED -> AppendTo( IGumpWriter disp ) was used!
                return String.Format("{{ tooltip {0} @{1}@ }}", 1042971, m_Text);
            }
            else
            { // default use cliloc localized text
                return string.Format("{{ tooltip {0} }}", m_Number);
            }
        }

        private static byte[] m_LayoutName = Gump.StringToBuffer("tooltip");

        public override void AppendTo(IGumpWriter disp)
        {
            if (m_Number == 0 && !string.IsNullOrEmpty(m_Text))
            { // if given: use custom text replacing placeholder "~1_NOTHING~"
                disp.AppendLayout(Gump.StringToBuffer(String.Format("tooltip {0}@{1}@", 1042971, m_Text)));
            }
            else
            { // default use given cliloc localized text
                disp.AppendLayout(m_LayoutName);
                disp.AppendLayout(m_Number);
            }
        }
	}
}