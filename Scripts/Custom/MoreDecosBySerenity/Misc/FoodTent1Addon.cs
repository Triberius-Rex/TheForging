
////////////////////////////////////////
//                                     //
//   Generated by CEO's YAAAG - Ver 2  //
// (Yet Another Arya Addon Generator)  //
//    Modified by Hammerhand for       //
//      SA & High Seas content         //
//                                     //
////////////////////////////////////////
using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class FoodTent1Addon : BaseAddon
	{
        private static int[,] m_AddOnSimpleComponents = new int[,] {
			  {1313, 2, 1, 1}, {1402, 2, 0, 1}, {1313, 2, -1, 1}// 2	3	4	
			, {1402, 2, -2, 1}, {1313, 2, -3, 1}, {1402, 1, 1, 1}// 5	6	7	
			, {1313, 1, 0, 1}, {1402, 1, -1, 1}, {1313, 1, -2, 1}// 8	9	10	
			, {1402, 1, -3, 1}, {1313, 0, 1, 1}, {1402, 0, 0, 1}// 11	12	13	
			, {1313, 0, -1, 1}, {1402, 0, -2, 1}, {1313, 0, -3, 1}// 14	15	16	
			, {1402, -1, 1, 1}, {1313, -1, 0, 1}, {1402, -1, -1, 1}// 17	18	19	
			, {1313, -1, -2, 1}, {1402, -1, -3, 1}, {1313, -2, 1, 1}// 20	21	22	
			, {1402, -2, 0, 1}, {1313, -2, -1, 1}, {1402, -2, -2, 1}// 23	24	25	
			, {1313, -2, -3, 1}, {505, -1, -5, 2}, {1561, 1, 2, 30}// 26	36	57	
			, {1561, 0, 2, 30}, {1561, 2, 3, 27}, {1561, 1, 3, 27}// 58	59	60	
			, {1561, 0, 3, 27}, {1561, -1, 3, 27}, {1561, 3, 4, 24}// 61	62	63	
			, {1561, 2, 4, 24}, {1561, 1, 4, 24}, {1561, 0, 4, 24}// 64	65	66	
			, {1561, -1, 4, 24}, {1561, -2, 4, 24}, {1562, 2, 0, 30}// 67	68	69	
			, {1562, 4, 0, 24}, {1562, 4, -1, 24}, {1562, 2, 1, 30}// 70	71	72	
			, {1562, 3, 2, 27}, {1562, 4, 1, 24}, {1559, -1, 1, 30}// 73	74	75	
			, {1559, -1, 0, 30}, {1562, 4, -2, 24}, {1560, 0, -1, 30}// 76	77	78	
			, {1560, 1, -2, 27}, {1560, -1, -2, 27}, {1560, 1, -1, 30}// 79	81	82	
			, {1560, 2, -2, 27}, {1402, -3, 1, 1}, {1566, -1, -1, 30}// 83	84	85	
			, {2542, -1, 1, 7}, {1562, 3, 1, 27}, {1565, 1, 0, 33}// 86	87	88	
			, {1564, 4, 4, 24}, {1573, 5, 4, 21}, {1567, 0, 1, 33}// 89	92	93	
			, {2519, 2, -3, 7}, {2519, 2, -3, 8}, {2542, 2, -1, 7}// 94	95	97	
			, {1578, -4, 5, 21}, {2519, 2, -3, 9}, {2519, 2, -3, 10}// 98	99	100	
			, {1572, 0, -4, 21}, {1574, -3, 5, 21}, {39317, 0, -3, 3}// 102	103	104	
			, {1560, 0, -2, 27}, {1571, -4, -3, 21}, {1571, -4, -2, 21}// 105	106	107	
			, {1571, -4, -1, 21}, {2268, -1, -4, 27}, {1571, -4, 0, 21}// 108	109	110	
			, {1559, -3, 0, 24}, {2543, 0, 1, 7}, {2879, 1, -4, 1}// 111	112	113	
			, {2879, -2, -4, 1}, {2612, 3, -4, 0}, {2612, 3, -3, 0}// 115	118	119	
			, {1571, -4, 1, 21}, {1559, -3, 3, 24}, {2543, 2, 1, 7}// 120	121	122	
			, {1571, -4, 2, 21}, {147, -4, -4, 1}, {2516, -3, 1, 7}// 123	124	125	
			, {1564, 3, 3, 27}, {1564, 2, 2, 30}, {1565, 3, -2, 27}// 126	127	128	
			, {1566, 0, 0, 33}, {1566, -2, -2, 27}, {1574, 0, 5, 21}// 129	130	131	
			, {1572, 4, -4, 21}, {1574, 4, 5, 21}, {1564, 1, 1, 33}// 133	135	137	
			, {6465, -3, -4, 5}, {1573, 5, 2, 21}, {1565, 2, -1, 30}// 139	140	148	
			, {1571, -4, 3, 21}, {1560, -2, -3, 24}, {1313, -3, 0, 1}// 151	152	154	
			, {43095, -3, -3, 8}, {1560, -1, -3, 24}, {1560, 0, -3, 24}// 155	156	157	
			, {1566, -3, -3, 24}, {1571, -4, 4, 21}, {1559, -3, -1, 24}// 158	159	160	
			, {1576, -4, -4, 21}, {1575, 5, 5, 21}, {1560, 1, -3, 24}// 162	163	164	
			, {2492, -3, 0, 8}, {1567, -2, 3, 27}, {1574, 1, 5, 21}// 166	168	169	
			, {1560, 2, -3, 24}, {1560, 3, -3, 24}, {2517, 2, 0, 8}// 170	171	172	
			, {1559, -3, -2, 24}, {1559, -2, -1, 27}, {1565, 4, -3, 24}// 173	174	175	
			, {40502, 1, -4, 11}, {1567, -3, 4, 24}, {1559, -2, 0, 27}// 176	177	178	
			, {1559, -3, 1, 24}, {1559, -2, 2, 27}, {1572, -3, -4, 21}// 179	180	181	
			, {1574, -1, 5, 21}, {1573, 5, 3, 21}, {1562, 4, 2, 24}// 182	183	185	
			, {1567, -1, 2, 30}, {1559, -3, 2, 24}, {1572, -2, -4, 21}// 186	188	189	
			, {1574, -2, 5, 21}, {1572, 3, -4, 21}, {499, -5, -5, 1}// 190	193	194	
			, {1573, 5, -3, 21}, {1402, -3, -1, 1}, {147, -4, 4, 1}// 195	196	199	
			, {2353, -1, -4, 1}, {1572, 2, -4, 21}, {1562, 3, -1, 27}// 202	203	204	
			, {1562, 3, 0, 27}, {147, 4, 4, 1}, {147, 4, -4, 1}// 205	207	208	
			, {2269, 0, -4, 27}, {40502, -2, -4, 11}, {1573, 5, 1, 21}// 209	210	211	
			, {1559, -2, 1, 27}, {1573, 5, 0, 21}, {1573, 5, -1, 21}// 213	214	215	
			, {1573, 5, -2, 21}, {1577, 5, -4, 21}, {1572, -1, -4, 21}// 220	224	226	
			, {1572, 1, -4, 21}, {5354, 2, -4, 7}, {1562, 4, 3, 24}// 227	228	231	
			, {1402, -3, -3, 1}, {1313, -3, -2, 1}, {1574, 2, 5, 21}// 233	234	235	
			, {1574, 3, 5, 21}// 236	
		};

 
            
		public override BaseAddonDeed Deed
		{
			get
			{
				return new FoodTent1AddonDeed();
			}
		}

		[ Constructable ]
		public FoodTent1Addon()
		{

            for (int i = 0; i < m_AddOnSimpleComponents.Length / 4; i++)
                AddComponent( new AddonComponent( m_AddOnSimpleComponents[i,0] ), m_AddOnSimpleComponents[i,1], m_AddOnSimpleComponents[i,2], m_AddOnSimpleComponents[i,3] );


			AddComplexComponent( (BaseAddon) this, 2594, -2, 1, 12, 0, 29, "", 1);// 1
			AddComplexComponent( (BaseAddon) this, 2602, -4, 1, 1, 2418, -1, "", 1);// 27
			AddComplexComponent( (BaseAddon) this, 2602, -4, -1, 1, 2418, -1, "", 1);// 28
			AddComplexComponent( (BaseAddon) this, 2602, -4, 0, 1, 2418, -1, "", 1);// 29
			AddComplexComponent( (BaseAddon) this, 40364, 0, -4, 43, 0, -1, "Smoke Puff", 1);// 30
			AddComplexComponent( (BaseAddon) this, 2594, 1, 1, 12, 0, 29, "", 1);// 31
			AddComplexComponent( (BaseAddon) this, 2590, 2, -4, 9, 0, -1, "Bowl of Pizza Dough", 1);// 32
			AddComplexComponent( (BaseAddon) this, 505, -3, -5, 2, 2418, -1, "", 1);// 33
			AddComplexComponent( (BaseAddon) this, 505, -2, -5, 2, 2418, -1, "", 1);// 34
			AddComplexComponent( (BaseAddon) this, 505, 0, -5, 2, 2418, -1, "", 1);// 35
			AddComplexComponent( (BaseAddon) this, 505, 2, -5, 2, 2418, -1, "", 1);// 37
			AddComplexComponent( (BaseAddon) this, 505, 1, -5, 2, 2418, -1, "", 1);// 38
			AddComplexComponent( (BaseAddon) this, 505, 3, -5, 2, 2418, -1, "", 1);// 39
			AddComplexComponent( (BaseAddon) this, 504, -5, -2, 2, 2418, -1, "", 1);// 40
			AddComplexComponent( (BaseAddon) this, 504, -5, -3, 2, 2418, -1, "", 1);// 41
			AddComplexComponent( (BaseAddon) this, 504, -5, 0, 2, 2418, -1, "", 1);// 42
			AddComplexComponent( (BaseAddon) this, 504, -5, -1, 2, 2418, -1, "", 1);// 43
			AddComplexComponent( (BaseAddon) this, 504, -5, 1, 2, 2418, -1, "", 1);// 44
			AddComplexComponent( (BaseAddon) this, 2879, -3, 0, 1, 2418, -1, "", 1);// 45
			AddComplexComponent( (BaseAddon) this, 504, -5, 2, 2, 2418, -1, "", 1);// 46
			AddComplexComponent( (BaseAddon) this, 2879, -3, -1, 1, 2418, -1, "", 1);// 47
			AddComplexComponent( (BaseAddon) this, 504, -5, 3, 2, 2418, -1, "", 1);// 48
			AddComplexComponent( (BaseAddon) this, 2879, -3, 1, 1, 2418, -1, "", 1);// 49
			AddComplexComponent( (BaseAddon) this, 2879, -3, -3, 1, 2418, -1, "", 1);// 50
			AddComplexComponent( (BaseAddon) this, 500, -5, 5, 2, 2418, -1, "", 1);// 51
			AddComplexComponent( (BaseAddon) this, 566, 4, -5, 2, 2418, -1, "", 1);// 52
			AddComplexComponent( (BaseAddon) this, 502, -4, -5, 2, 2418, -1, "", 1);// 53
			AddComplexComponent( (BaseAddon) this, 503, -5, -4, 2, 2418, -1, "", 1);// 54
			AddComplexComponent( (BaseAddon) this, 567, -5, 4, 2, 2418, -1, "", 1);// 55
			AddComplexComponent( (BaseAddon) this, 498, 5, -4, 2, 2418, -1, "", 1);// 56
			AddComplexComponent( (BaseAddon) this, 1981, 1, -4, 9, 2418, -1, "", 1);// 80
			AddComplexComponent( (BaseAddon) this, 39327, -3, 1, 7, 0, -1, "Porkchops & Taters", 1);// 90
			AddComplexComponent( (BaseAddon) this, 39327, 2, 0, 8, 0, -1, "Porkchops & Taters", 1);// 91
			AddComplexComponent( (BaseAddon) this, 1981, 1, -4, 7, 2418, -1, "", 1);// 96
			AddComplexComponent( (BaseAddon) this, 498, 5, -2, 2, 2418, -1, "", 1);// 101
			AddComplexComponent( (BaseAddon) this, 2879, 2, -4, 1, 2418, -1, "", 1);// 114
			AddComplexComponent( (BaseAddon) this, 1981, -2, -4, 7, 2418, -1, "", 1);// 116
			AddComplexComponent( (BaseAddon) this, 1981, -2, -4, 9, 2418, -1, "", 1);// 117
			AddComplexComponent( (BaseAddon) this, 2879, -3, -4, 1, 2418, -1, "", 1);// 132
			AddComplexComponent( (BaseAddon) this, 2602, 3, -1, 1, 2418, -1, "", 1);// 134
			AddComplexComponent( (BaseAddon) this, 5635, -2, -3, 8, 0, -1, "Pork Pulling Bowl", 1);// 136
			AddComplexComponent( (BaseAddon) this, 498, 5, 3, 2, 2418, -1, "", 1);// 138
			AddComplexComponent( (BaseAddon) this, 2602, 1, 2, 1, 2418, -1, "", 1);// 141
			AddComplexComponent( (BaseAddon) this, 2602, 0, 2, 1, 2418, -1, "", 1);// 142
			AddComplexComponent( (BaseAddon) this, 498, 5, 2, 2, 2418, -1, "", 1);// 143
			AddComplexComponent( (BaseAddon) this, 2879, -1, 1, 1, 2418, -1, "", 1);// 144
			AddComplexComponent( (BaseAddon) this, 496, 5, 5, 2, 2418, -1, "", 1);// 145
			AddComplexComponent( (BaseAddon) this, 501, 5, -5, 2, 2418, -1, "", 1);// 146
			AddComplexComponent( (BaseAddon) this, 498, 5, -3, 2, 2418, -1, "", 1);// 147
			AddComplexComponent( (BaseAddon) this, 2879, 1, 1, 1, 2418, -1, "", 1);// 149
			AddComplexComponent( (BaseAddon) this, 2602, 2, 2, 1, 2418, -1, "", 1);// 150
			AddComplexComponent( (BaseAddon) this, 2602, -1, 2, 1, 2418, -1, "", 1);// 153
			AddComplexComponent( (BaseAddon) this, 2879, 2, 1, 1, 2418, -1, "", 1);// 161
			AddComplexComponent( (BaseAddon) this, 497, -3, 5, 2, 2418, -1, "", 1);// 165
			AddComplexComponent( (BaseAddon) this, 2879, -2, 1, 1, 2418, -1, "", 1);// 167
			AddComplexComponent( (BaseAddon) this, 2602, -3, 2, 1, 2418, -1, "", 1);// 184
			AddComplexComponent( (BaseAddon) this, 2602, 3, 1, 1, 2418, -1, "", 1);// 187
			AddComplexComponent( (BaseAddon) this, 497, -2, 5, 2, 2418, -1, "", 1);// 191
			AddComplexComponent( (BaseAddon) this, 2879, -2, -3, 1, 2418, -1, "", 1);// 192
			AddComplexComponent( (BaseAddon) this, 497, 4, 5, 2, 2418, -1, "", 1);// 197
			AddComplexComponent( (BaseAddon) this, 497, 2, 5, 2, 2418, -1, "", 1);// 198
			AddComplexComponent( (BaseAddon) this, 2352, 0, -4, 1, 0, 47, "", 1);// 200
			AddComplexComponent( (BaseAddon) this, 2602, -2, 2, 1, 2418, -1, "", 1);// 201
			AddComplexComponent( (BaseAddon) this, 2879, 1, -3, 1, 2418, -1, "", 1);// 206
			AddComplexComponent( (BaseAddon) this, 2879, 2, -3, 1, 2418, -1, "", 1);// 212
			AddComplexComponent( (BaseAddon) this, 2879, 2, -1, 1, 2418, -1, "", 1);// 216
			AddComplexComponent( (BaseAddon) this, 2879, 2, 0, 1, 2418, -1, "", 1);// 217
			AddComplexComponent( (BaseAddon) this, 497, -4, 5, 2, 2418, -1, "", 1);// 218
			AddComplexComponent( (BaseAddon) this, 4160, 1, -3, 8, 0, -1, "Pulled Pork Pizza", 1);// 219
			AddComplexComponent( (BaseAddon) this, 497, 3, 5, 2, 2418, -1, "", 1);// 221
			AddComplexComponent( (BaseAddon) this, 44152, 1, -3, 7, 0, -1, "Pizza Pan", 1);// 222
			AddComplexComponent( (BaseAddon) this, 39328, 1, 1, 7, 0, -1, "Pulled Pork Sandwich", 1);// 223
			AddComplexComponent( (BaseAddon) this, 498, 5, 4, 2, 2418, -1, "", 1);// 225
			AddComplexComponent( (BaseAddon) this, 39328, -2, 1, 7, 0, -1, "Pulled Pork Sandwich", 1);// 229
			AddComplexComponent( (BaseAddon) this, 2602, 3, 0, 1, 2418, -1, "", 1);// 230
			AddComplexComponent( (BaseAddon) this, 2879, 0, 1, 1, 2418, -1, "", 1);// 232

		}

		public FoodTent1Addon( Serial serial ) : base( serial )
		{
		}

        private static void AddComplexComponent(BaseAddon addon, int item, int xoffset, int yoffset, int zoffset, int hue, int lightsource)
        {
            AddComplexComponent(addon, item, xoffset, yoffset, zoffset, hue, lightsource, null, 1);
        }

        private static void AddComplexComponent(BaseAddon addon, int item, int xoffset, int yoffset, int zoffset, int hue, int lightsource, string name, int amount)
        {
            AddonComponent ac;
            ac = new AddonComponent(item);
            if (name != null && name.Length > 0)
                ac.Name = name;
            if (hue != 0)
                ac.Hue = hue;
            if (amount > 1)
            {
                ac.Stackable = true;
                ac.Amount = amount;
            }
            if (lightsource != -1)
                ac.Light = (LightType) lightsource;
            addon.AddComponent(ac, xoffset, yoffset, zoffset);
        }

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( 0 ); // Version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}

	public class FoodTent1AddonDeed : BaseAddonDeed
	{
		public override BaseAddon Addon
		{
			get
			{
				return new FoodTent1Addon();
			}
		}

		[Constructable]
		public FoodTent1AddonDeed()
		{
			Name = "FoodTent1";
		}

		public FoodTent1AddonDeed( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( 0 ); // Version
		}

		public override void	Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}