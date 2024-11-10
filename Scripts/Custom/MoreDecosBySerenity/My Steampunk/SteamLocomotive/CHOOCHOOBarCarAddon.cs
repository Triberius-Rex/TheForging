
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
	public class CHOOCHOOBarCarAddon : BaseAddon
	{
        private static int[,] m_AddOnSimpleComponents = new int[,] {
			  {16449, 2, 3, 25}, {16818, 3, 3, 25}, {16818, 1, 7, 25}// 22	46	52	
			, {16815, 1, 6, 25}, {16818, 0, 6, 25}, {16745, 0, -2, 46}// 53	54	100	
			, {16745, 2, -6, 44}, {16449, 1, -4, 25}, {16449, 2, 0, 25}// 101	112	113	
			, {16818, 3, 0, 25}, {16818, 2, -1, 25}, {16735, -2, -6, 44}// 138	173	237	
			, {16449, -1, -4, 25}// 252	
		};

 
            
		public override BaseAddonDeed Deed
		{
			get
			{
				return new CHOOCHOOBarCarAddonDeed();
			}
		}

		[ Constructable ]
		public CHOOCHOOBarCarAddon()
		{

            for (int i = 0; i < m_AddOnSimpleComponents.Length / 4; i++)
                AddComponent( new AddonComponent( m_AddOnSimpleComponents[i,0] ), m_AddOnSimpleComponents[i,1], m_AddOnSimpleComponents[i,2], m_AddOnSimpleComponents[i,3] );


			AddComplexComponent( (BaseAddon) this, 16815, 2, 4, 56, 1175, -1, "", 1);// 1
			AddComplexComponent( (BaseAddon) this, 16815, 2, 3, 56, 1175, -1, "", 1);// 2
			AddComplexComponent( (BaseAddon) this, 16815, 2, 2, 56, 1175, -1, "", 1);// 3
			AddComplexComponent( (BaseAddon) this, 16815, 1, 4, 56, 1175, -1, "", 1);// 4
			AddComplexComponent( (BaseAddon) this, 16815, 0, 3, 56, 1175, -1, "", 1);// 5
			AddComplexComponent( (BaseAddon) this, 16815, 0, 2, 56, 1175, -1, "", 1);// 6
			AddComplexComponent( (BaseAddon) this, 16815, 1, 2, 56, 1175, -1, "", 1);// 7
			AddComplexComponent( (BaseAddon) this, 16815, 0, 4, 56, 1175, -1, "", 1);// 8
			AddComplexComponent( (BaseAddon) this, 16815, 1, 3, 56, 1175, -1, "", 1);// 9
			AddComplexComponent( (BaseAddon) this, 18602, 2, 6, 46, 1175, -1, "", 1);// 10
			AddComplexComponent( (BaseAddon) this, 18603, 2, 7, 46, 1175, -1, "", 1);// 11
			AddComplexComponent( (BaseAddon) this, 17160, 1, 5, 46, 1175, -1, "", 1);// 12
			AddComplexComponent( (BaseAddon) this, 17160, 0, 5, 46, 1175, -1, "", 1);// 13
			AddComplexComponent( (BaseAddon) this, 17218, 3, 4, 46, 1175, -1, "", 1);// 14
			AddComplexComponent( (BaseAddon) this, 17218, 3, 3, 46, 1175, -1, "", 1);// 15
			AddComplexComponent( (BaseAddon) this, 17218, 3, 2, 46, 1175, -1, "", 1);// 16
			AddComplexComponent( (BaseAddon) this, 2602, 0, 2, 25, 1646, -1, "", 1);// 17
			AddComplexComponent( (BaseAddon) this, 2602, 0, 3, 25, 1646, -1, "", 1);// 18
			AddComplexComponent( (BaseAddon) this, 2602, 0, 4, 25, 1646, -1, "", 1);// 19
			AddComplexComponent( (BaseAddon) this, 4634, 2, 4, 25, 1646, -1, "", 1);// 20
			AddComplexComponent( (BaseAddon) this, 4632, 2, 2, 25, 1646, -1, "", 1);// 21
			AddComplexComponent( (BaseAddon) this, 17160, 2, 5, 46, 1175, -1, "", 1);// 23
			AddComplexComponent( (BaseAddon) this, 16815, 2, 4, 46, 1175, -1, "", 1);// 24
			AddComplexComponent( (BaseAddon) this, 16815, 2, 7, 46, 1646, -1, "", 1);// 25
			AddComplexComponent( (BaseAddon) this, 16815, 2, 6, 46, 1646, -1, "", 1);// 26
			AddComplexComponent( (BaseAddon) this, 16815, 1, 7, 46, 1646, -1, "", 1);// 27
			AddComplexComponent( (BaseAddon) this, 16815, 1, 6, 46, 1646, -1, "", 1);// 28
			AddComplexComponent( (BaseAddon) this, 16815, 0, 7, 46, 1646, -1, "", 1);// 29
			AddComplexComponent( (BaseAddon) this, 16815, 3, 4, 47, 1175, -1, "", 1);// 30
			AddComplexComponent( (BaseAddon) this, 16815, 3, 3, 46, 1175, -1, "", 1);// 31
			AddComplexComponent( (BaseAddon) this, 16815, 3, 2, 46, 1175, -1, "", 1);// 32
			AddComplexComponent( (BaseAddon) this, 16815, 2, 5, 46, 1175, -1, "", 1);// 33
			AddComplexComponent( (BaseAddon) this, 16815, 2, 3, 46, 1175, -1, "", 1);// 34
			AddComplexComponent( (BaseAddon) this, 16815, 2, 2, 46, 1175, -1, "", 1);// 35
			AddComplexComponent( (BaseAddon) this, 16815, 1, 5, 46, 1646, -1, "", 1);// 36
			AddComplexComponent( (BaseAddon) this, 16815, 1, 3, 46, 1175, -1, "", 1);// 37
			AddComplexComponent( (BaseAddon) this, 16815, 1, 2, 46, 1175, -1, "", 1);// 38
			AddComplexComponent( (BaseAddon) this, 16815, 0, 5, 46, 1646, -1, "", 1);// 39
			AddComplexComponent( (BaseAddon) this, 16815, 0, 3, 46, 1175, -1, "", 1);// 40
			AddComplexComponent( (BaseAddon) this, 16815, 0, 2, 46, 1175, -1, "", 1);// 41
			AddComplexComponent( (BaseAddon) this, 16815, 0, 6, 46, 1646, -1, "", 1);// 42
			AddComplexComponent( (BaseAddon) this, 16815, 0, 4, 46, 1175, -1, "", 1);// 43
			AddComplexComponent( (BaseAddon) this, 16815, 1, 4, 25, 1646, -1, "", 1);// 44
			AddComplexComponent( (BaseAddon) this, 16818, 3, 4, 25, 1646, -1, "", 1);// 45
			AddComplexComponent( (BaseAddon) this, 16818, 3, 2, 25, 1646, -1, "", 1);// 47
			AddComplexComponent( (BaseAddon) this, 16815, 1, 5, 25, 1646, -1, "", 1);// 48
			AddComplexComponent( (BaseAddon) this, 16815, 1, 4, 25, 2724, -1, "", 1);// 49
			AddComplexComponent( (BaseAddon) this, 16818, 2, 3, 25, 1646, -1, "", 1);// 50
			AddComplexComponent( (BaseAddon) this, 16815, 2, 2, 25, 1646, -1, "", 1);// 51
			AddComplexComponent( (BaseAddon) this, 16815, 2, 5, 25, 1646, -1, "", 1);// 55
			AddComplexComponent( (BaseAddon) this, 16815, 0, 5, 25, 1646, -1, "", 1);// 56
			AddComplexComponent( (BaseAddon) this, 16815, 2, 4, 25, 1646, -1, "", 1);// 57
			AddComplexComponent( (BaseAddon) this, 16815, 0, 4, 25, 1646, -1, "", 1);// 58
			AddComplexComponent( (BaseAddon) this, 16815, 1, 3, 25, 1646, -1, "", 1);// 59
			AddComplexComponent( (BaseAddon) this, 16815, 1, 2, 25, 1646, -1, "", 1);// 60
			AddComplexComponent( (BaseAddon) this, 16818, 0, 2, 25, 1646, -1, "", 1);// 61
			AddComplexComponent( (BaseAddon) this, 16815, 0, 3, 25, 1646, -1, "", 1);// 62
			AddComplexComponent( (BaseAddon) this, 17190, 2, 5, 24, 1175, -1, "", 1);// 63
			AddComplexComponent( (BaseAddon) this, 17238, 3, 2, 24, 1175, 255, "", 1);// 64
			AddComplexComponent( (BaseAddon) this, 17236, 3, 3, 24, 1175, 255, "", 1);// 65
			AddComplexComponent( (BaseAddon) this, 17226, 3, 4, 24, 1175, -1, "", 1);// 66
			AddComplexComponent( (BaseAddon) this, 9541, 3, 5, 24, 1175, -1, "", 1);// 67
			AddComplexComponent( (BaseAddon) this, 3693, 1, 5, 4, 1175, -1, "", 1);// 68
			AddComplexComponent( (BaseAddon) this, 25490, 2, 5, 0, 1175, -1, "", 1);// 69
			AddComplexComponent( (BaseAddon) this, 1978, 0, 3, 19, 1175, -1, "", 1);// 70
			AddComplexComponent( (BaseAddon) this, 1978, 0, 2, 19, 1175, -1, "", 1);// 71
			AddComplexComponent( (BaseAddon) this, 1978, 0, 5, 19, 1175, -1, "", 1);// 72
			AddComplexComponent( (BaseAddon) this, 1978, 0, 4, 19, 1175, -1, "", 1);// 73
			AddComplexComponent( (BaseAddon) this, 1978, 0, 6, 19, 1175, -1, "", 1);// 74
			AddComplexComponent( (BaseAddon) this, 1978, 0, 7, 19, 1175, -1, "", 1);// 75
			AddComplexComponent( (BaseAddon) this, 17227, 1, 7, 24, 1175, -1, "", 1);// 76
			AddComplexComponent( (BaseAddon) this, 1978, 1, 3, 19, 1175, -1, "", 1);// 77
			AddComplexComponent( (BaseAddon) this, 1978, 1, 4, 19, 1175, -1, "", 1);// 78
			AddComplexComponent( (BaseAddon) this, 1978, 1, 5, 19, 1175, -1, "", 1);// 79
			AddComplexComponent( (BaseAddon) this, 1978, 1, 6, 19, 1175, -1, "", 1);// 80
			AddComplexComponent( (BaseAddon) this, 18603, 3, 5, 44, 1175, -1, "", 1);// 81
			AddComplexComponent( (BaseAddon) this, 17354, 2, 7, 24, 1175, -1, "", 1);// 82
			AddComplexComponent( (BaseAddon) this, 17226, 2, 6, 24, 1175, -1, "", 1);// 83
			AddComplexComponent( (BaseAddon) this, 1978, 1, 7, 19, 1175, -1, "", 1);// 84
			AddComplexComponent( (BaseAddon) this, 16815, 1, 4, 46, 1175, -1, "", 1);// 85
			AddComplexComponent( (BaseAddon) this, 1978, 1, 2, 19, 1175, -1, "", 1);// 86
			AddComplexComponent( (BaseAddon) this, 16815, 2, 1, 56, 1175, -1, "", 1);// 87
			AddComplexComponent( (BaseAddon) this, 16815, 2, 0, 56, 1175, -1, "", 1);// 88
			AddComplexComponent( (BaseAddon) this, 16815, 0, 1, 56, 1175, -1, "", 1);// 89
			AddComplexComponent( (BaseAddon) this, 16815, 0, 0, 56, 1175, -1, "", 1);// 90
			AddComplexComponent( (BaseAddon) this, 16815, 1, 0, 56, 1175, -1, "", 1);// 91
			AddComplexComponent( (BaseAddon) this, 16815, 0, -2, 25, 1646, -1, "", 1);// 92
			AddComplexComponent( (BaseAddon) this, 16744, 2, -2, 46, 1175, -1, "", 1);// 93
			AddComplexComponent( (BaseAddon) this, 16744, 2, -3, 46, 1175, -1, "", 1);// 94
			AddComplexComponent( (BaseAddon) this, 16744, 2, -4, 46, 1175, -1, "", 1);// 95
			AddComplexComponent( (BaseAddon) this, 16744, 2, -5, 46, 1175, -1, "", 1);// 96
			AddComplexComponent( (BaseAddon) this, 16745, 1, -6, 44, 1175, -1, "", 1);// 97
			AddComplexComponent( (BaseAddon) this, 16745, 2, -2, 46, 1175, -1, "", 1);// 98
			AddComplexComponent( (BaseAddon) this, 16745, 1, -2, 46, 1175, -1, "", 1);// 99
			AddComplexComponent( (BaseAddon) this, 16745, 0, -6, 44, 1175, -1, "", 1);// 102
			AddComplexComponent( (BaseAddon) this, 17218, 3, 1, 46, 1175, -1, "", 1);// 103
			AddComplexComponent( (BaseAddon) this, 17218, 3, 0, 46, 1175, -1, "", 1);// 104
			AddComplexComponent( (BaseAddon) this, 17359, 2, -1, 46, 1175, -1, "", 1);// 105
			AddComplexComponent( (BaseAddon) this, 17359, 1, -1, 46, 1175, -1, "", 1);// 106
			AddComplexComponent( (BaseAddon) this, 17359, 0, -1, 46, 1175, -1, "", 1);// 107
			AddComplexComponent( (BaseAddon) this, 2602, 0, 0, 25, 1646, -1, "", 1);// 108
			AddComplexComponent( (BaseAddon) this, 2602, 0, 1, 25, 1646, -1, "", 1);// 109
			AddComplexComponent( (BaseAddon) this, 4634, 2, 1, 25, 1646, -1, "", 1);// 110
			AddComplexComponent( (BaseAddon) this, 4632, 2, -1, 25, 1646, -1, "", 1);// 111
			AddComplexComponent( (BaseAddon) this, 16815, 2, -2, 46, 1646, -1, "", 1);// 114
			AddComplexComponent( (BaseAddon) this, 16815, 2, -3, 46, 1646, -1, "", 1);// 115
			AddComplexComponent( (BaseAddon) this, 16815, 2, -4, 46, 1646, -1, "", 1);// 116
			AddComplexComponent( (BaseAddon) this, 16815, 2, -5, 46, 1646, -1, "", 1);// 117
			AddComplexComponent( (BaseAddon) this, 16815, 1, -2, 46, 1646, -1, "", 1);// 118
			AddComplexComponent( (BaseAddon) this, 16815, 1, -3, 46, 1646, -1, "", 1);// 119
			AddComplexComponent( (BaseAddon) this, 16815, 1, -4, 46, 1646, -1, "", 1);// 120
			AddComplexComponent( (BaseAddon) this, 16815, 1, -5, 46, 1646, -1, "", 1);// 121
			AddComplexComponent( (BaseAddon) this, 16815, 0, -2, 46, 1646, -1, "", 1);// 122
			AddComplexComponent( (BaseAddon) this, 16815, 0, -3, 46, 1646, -1, "", 1);// 123
			AddComplexComponent( (BaseAddon) this, 16815, 0, -4, 46, 1646, -1, "", 1);// 124
			AddComplexComponent( (BaseAddon) this, 16815, 0, -5, 46, 1646, -1, "", 1);// 125
			AddComplexComponent( (BaseAddon) this, 16815, 3, 1, 46, 1175, -1, "", 1);// 126
			AddComplexComponent( (BaseAddon) this, 16815, 3, 0, 46, 1175, -1, "", 1);// 127
			AddComplexComponent( (BaseAddon) this, 16815, 2, 1, 46, 1175, -1, "", 1);// 128
			AddComplexComponent( (BaseAddon) this, 16815, 2, -1, 46, 1646, -1, "", 1);// 129
			AddComplexComponent( (BaseAddon) this, 16815, 1, 1, 46, 1175, -1, "", 1);// 130
			AddComplexComponent( (BaseAddon) this, 16815, 1, -1, 46, 1646, -1, "", 1);// 131
			AddComplexComponent( (BaseAddon) this, 16815, 0, 1, 46, 1175, -1, "", 1);// 132
			AddComplexComponent( (BaseAddon) this, 16815, 0, -1, 46, 1646, -1, "", 1);// 133
			AddComplexComponent( (BaseAddon) this, 16818, 1, -5, 25, 1646, -1, "", 1);// 134
			AddComplexComponent( (BaseAddon) this, 16818, 0, -5, 25, 1646, -1, "", 1);// 135
			AddComplexComponent( (BaseAddon) this, 17238, 2, -3, 24, 1175, 255, "", 1);// 136
			AddComplexComponent( (BaseAddon) this, 16815, 2, 1, 25, 1646, -1, "", 1);// 137
			AddComplexComponent( (BaseAddon) this, 16815, 1, -1, 25, 1646, -1, "", 1);// 139
			AddComplexComponent( (BaseAddon) this, 16818, 3, 1, 25, 1646, -1, "", 1);// 140
			AddComplexComponent( (BaseAddon) this, 16815, 2, 0, 25, 1646, -1, "", 1);// 141
			AddComplexComponent( (BaseAddon) this, 16818, 1, -4, 25, 1646, -1, "", 1);// 142
			AddComplexComponent( (BaseAddon) this, 16815, 0, -4, 25, 1646, -1, "", 1);// 143
			AddComplexComponent( (BaseAddon) this, 16815, 1, -3, 25, 1646, -1, "", 1);// 144
			AddComplexComponent( (BaseAddon) this, 16818, 0, -3, 25, 1646, -1, "", 1);// 145
			AddComplexComponent( (BaseAddon) this, 16818, 1, -2, 25, 1646, -1, "", 1);// 146
			AddComplexComponent( (BaseAddon) this, 16815, 0, -2, 24, 1175, -1, "", 1);// 147
			AddComplexComponent( (BaseAddon) this, 16818, 1, 1, 25, 1646, -1, "", 1);// 148
			AddComplexComponent( (BaseAddon) this, 16815, 1, 0, 25, 1646, -1, "", 1);// 149
			AddComplexComponent( (BaseAddon) this, 16815, 0, 0, 25, 1646, -1, "", 1);// 150
			AddComplexComponent( (BaseAddon) this, 16815, 0, 1, 25, 1646, -1, "", 1);// 151
			AddComplexComponent( (BaseAddon) this, 17226, 2, -5, 24, 1175, -1, "", 1);// 152
			AddComplexComponent( (BaseAddon) this, 17238, 2, -4, 24, 1175, 255, "", 1);// 153
			AddComplexComponent( (BaseAddon) this, 17226, 2, -2, 24, 1175, -1, "", 1);// 154
			AddComplexComponent( (BaseAddon) this, 9555, 3, -1, 24, 1175, -1, "", 1);// 155
			AddComplexComponent( (BaseAddon) this, 17226, 3, 0, 24, 1175, -1, "", 1);// 156
			AddComplexComponent( (BaseAddon) this, 17240, 3, 1, 24, 1175, 255, "", 1);// 157
			AddComplexComponent( (BaseAddon) this, 3693, 1, -5, 4, 1175, -1, "", 1);// 158
			AddComplexComponent( (BaseAddon) this, 3693, 1, -3, 4, 1175, -1, "", 1);// 159
			AddComplexComponent( (BaseAddon) this, 25490, 2, -5, 0, 1175, -1, "", 1);// 160
			AddComplexComponent( (BaseAddon) this, 25490, 2, -3, 0, 1175, -1, "", 1);// 161
			AddComplexComponent( (BaseAddon) this, 1978, 0, -4, 19, 1175, -1, "", 1);// 162
			AddComplexComponent( (BaseAddon) this, 1978, 0, -3, 19, 1175, -1, "", 1);// 163
			AddComplexComponent( (BaseAddon) this, 1978, 0, -2, 19, 1175, -1, "", 1);// 164
			AddComplexComponent( (BaseAddon) this, 1978, 0, 0, 19, 1175, -1, "", 1);// 165
			AddComplexComponent( (BaseAddon) this, 1978, 0, -1, 19, 1175, -1, "", 1);// 166
			AddComplexComponent( (BaseAddon) this, 1978, 0, 1, 19, 1175, -1, "", 1);// 167
			AddComplexComponent( (BaseAddon) this, 16815, 0, 0, 46, 1175, -1, "", 1);// 168
			AddComplexComponent( (BaseAddon) this, 16818, 0, -1, 25, 1646, -1, "", 1);// 169
			AddComplexComponent( (BaseAddon) this, 1978, 1, -3, 19, 1175, -1, "", 1);// 170
			AddComplexComponent( (BaseAddon) this, 1978, 1, -2, 19, 1175, -1, "", 1);// 171
			AddComplexComponent( (BaseAddon) this, 1978, 1, -1, 19, 1175, -1, "", 1);// 172
			AddComplexComponent( (BaseAddon) this, 17227, 2, -6, 24, 1175, -1, "", 1);// 174
			AddComplexComponent( (BaseAddon) this, 16815, 1, 0, 46, 1175, -1, "", 1);// 175
			AddComplexComponent( (BaseAddon) this, 17227, 1, -6, 24, 1175, -1, "", 1);// 176
			AddComplexComponent( (BaseAddon) this, 16815, 2, 0, 46, 1175, -1, "", 1);// 177
			AddComplexComponent( (BaseAddon) this, 1978, 1, -5, 19, 1175, -1, "", 1);// 178
			AddComplexComponent( (BaseAddon) this, 1978, 0, -5, 19, 1175, -1, "", 1);// 179
			AddComplexComponent( (BaseAddon) this, 1978, 1, 0, 19, 1175, -1, "", 1);// 180
			AddComplexComponent( (BaseAddon) this, 1978, 1, -4, 19, 1175, -1, "", 1);// 181
			AddComplexComponent( (BaseAddon) this, 16815, 1, 1, 56, 1175, -1, "", 1);// 182
			AddComplexComponent( (BaseAddon) this, 4634, 1, -3, 25, 1646, -1, "", 1);// 183
			AddComplexComponent( (BaseAddon) this, 4632, 1, -5, 25, 1646, -1, "", 1);// 184
			AddComplexComponent( (BaseAddon) this, 1978, 1, 1, 19, 1175, -1, "", 1);// 185
			AddComplexComponent( (BaseAddon) this, 16815, -1, 3, 56, 1175, -1, "", 1);// 186
			AddComplexComponent( (BaseAddon) this, 16815, -1, 2, 56, 1175, -1, "", 1);// 187
			AddComplexComponent( (BaseAddon) this, 16815, -1, 4, 56, 1175, -1, "", 1);// 188
			AddComplexComponent( (BaseAddon) this, 18602, -1, 6, 46, 1175, -1, "", 1);// 189
			AddComplexComponent( (BaseAddon) this, 18603, -1, 7, 46, 1175, -1, "", 1);// 190
			AddComplexComponent( (BaseAddon) this, 17160, -1, 5, 46, 1175, -1, "", 1);// 191
			AddComplexComponent( (BaseAddon) this, 17360, -2, 2, 46, 1175, -1, "", 1);// 192
			AddComplexComponent( (BaseAddon) this, 17360, -2, 3, 46, 1175, -1, "", 1);// 193
			AddComplexComponent( (BaseAddon) this, 17360, -2, 4, 46, 1175, -1, "", 1);// 194
			AddComplexComponent( (BaseAddon) this, 18881, -1, 4, 34, 0, 2, "", 1);// 195
			AddComplexComponent( (BaseAddon) this, 41690, -1, 4, 25, 1646, -1, "", 1);// 196
			AddComplexComponent( (BaseAddon) this, 41690, -2, 4, 25, 1646, -1, "", 1);// 197
			AddComplexComponent( (BaseAddon) this, 41690, -1, 3, 25, 1646, -1, "", 1);// 198
			AddComplexComponent( (BaseAddon) this, 41690, -1, 2, 25, 1646, -1, "", 1);// 199
			AddComplexComponent( (BaseAddon) this, 2602, -1, 5, 25, 1646, -1, "", 1);// 200
			AddComplexComponent( (BaseAddon) this, 16815, -1, 5, 46, 1646, -1, "", 1);// 201
			AddComplexComponent( (BaseAddon) this, 16815, -1, 3, 46, 1175, -1, "", 1);// 202
			AddComplexComponent( (BaseAddon) this, 16815, -1, 2, 46, 1175, -1, "", 1);// 203
			AddComplexComponent( (BaseAddon) this, 16815, -2, 4, 46, 1646, -1, "", 1);// 204
			AddComplexComponent( (BaseAddon) this, 16815, -2, 3, 46, 1646, -1, "", 1);// 205
			AddComplexComponent( (BaseAddon) this, 16815, -2, 2, 46, 1646, -1, "", 1);// 206
			AddComplexComponent( (BaseAddon) this, 16815, -1, 7, 46, 1646, -1, "", 1);// 207
			AddComplexComponent( (BaseAddon) this, 16815, -1, 6, 46, 1646, -1, "", 1);// 208
			AddComplexComponent( (BaseAddon) this, 16815, -1, 4, 25, 1646, -1, "", 1);// 209
			AddComplexComponent( (BaseAddon) this, 16818, -1, 5, 25, 1646, -1, "", 1);// 210
			AddComplexComponent( (BaseAddon) this, 16818, -2, 2, 25, 1646, -1, "", 1);// 211
			AddComplexComponent( (BaseAddon) this, 16815, -2, 3, 25, 1646, -1, "", 1);// 212
			AddComplexComponent( (BaseAddon) this, 16818, -1, 7, 25, 1646, -1, "", 1);// 213
			AddComplexComponent( (BaseAddon) this, 16815, -1, 6, 25, 1646, -1, "", 1);// 214
			AddComplexComponent( (BaseAddon) this, 16815, -2, 5, 25, 1646, -1, "", 1);// 215
			AddComplexComponent( (BaseAddon) this, 16818, -1, 3, 25, 1646, -1, "", 1);// 216
			AddComplexComponent( (BaseAddon) this, 17226, -3, 4, 24, 1175, -1, "", 1);// 217
			AddComplexComponent( (BaseAddon) this, 17236, -3, 3, 24, 1175, 255, "", 1);// 218
			AddComplexComponent( (BaseAddon) this, 17238, -3, 2, 24, 1175, 255, "", 1);// 219
			AddComplexComponent( (BaseAddon) this, 1978, -1, 7, 19, 1175, -1, "", 1);// 220
			AddComplexComponent( (BaseAddon) this, 1978, -1, 6, 19, 1175, -1, "", 1);// 221
			AddComplexComponent( (BaseAddon) this, 1978, -1, 5, 19, 1175, -1, "", 1);// 222
			AddComplexComponent( (BaseAddon) this, 1978, -1, 4, 19, 1175, -1, "", 1);// 223
			AddComplexComponent( (BaseAddon) this, 1978, -1, 3, 19, 1175, -1, "", 1);// 224
			AddComplexComponent( (BaseAddon) this, 1978, -1, 2, 19, 1175, -1, "", 1);// 225
			AddComplexComponent( (BaseAddon) this, 17227, -1, 7, 24, 1175, -1, "", 1);// 226
			AddComplexComponent( (BaseAddon) this, 18603, -2, 5, 44, 1175, -1, "", 1);// 227
			AddComplexComponent( (BaseAddon) this, 16815, -1, 2, 25, 1646, -1, "", 1);// 228
			AddComplexComponent( (BaseAddon) this, 16818, -2, 4, 25, 1646, -1, "", 1);// 229
			AddComplexComponent( (BaseAddon) this, 5534, -2, 3, 27, 1646, -1, "", 1);// 230
			AddComplexComponent( (BaseAddon) this, 16815, -1, 4, 46, 1175, -1, "", 1);// 231
			AddComplexComponent( (BaseAddon) this, 17226, -2, 7, 24, 1175, -1, "", 1);// 232
			AddComplexComponent( (BaseAddon) this, 17226, -2, 6, 24, 1175, -1, "", 1);// 233
			AddComplexComponent( (BaseAddon) this, 9555, -2, 5, 24, 1175, -1, "", 1);// 234
			AddComplexComponent( (BaseAddon) this, 16815, -1, 1, 56, 1175, -1, "", 1);// 235
			AddComplexComponent( (BaseAddon) this, 16815, -1, 0, 56, 1175, -1, "", 1);// 236
			AddComplexComponent( (BaseAddon) this, 16744, -2, -3, 44, 1175, -1, "", 1);// 238
			AddComplexComponent( (BaseAddon) this, 16744, -2, -2, 44, 1175, -1, "", 1);// 239
			AddComplexComponent( (BaseAddon) this, 16744, -2, -4, 44, 1175, -1, "", 1);// 240
			AddComplexComponent( (BaseAddon) this, 16744, -2, -5, 44, 1175, -1, "", 1);// 241
			AddComplexComponent( (BaseAddon) this, 16745, -1, -2, 46, 1175, -1, "", 1);// 242
			AddComplexComponent( (BaseAddon) this, 16745, -1, -6, 44, 1175, -1, "", 1);// 243
			AddComplexComponent( (BaseAddon) this, 17359, -1, -1, 46, 1175, -1, "", 1);// 244
			AddComplexComponent( (BaseAddon) this, 17360, -2, 0, 46, 1175, -1, "", 1);// 245
			AddComplexComponent( (BaseAddon) this, 17360, -2, 1, 46, 1175, -1, "", 1);// 246
			AddComplexComponent( (BaseAddon) this, 18881, -1, 0, 34, 0, 2, "", 1);// 247
			AddComplexComponent( (BaseAddon) this, 2602, -1, -1, 25, 1646, -1, "", 1);// 248
			AddComplexComponent( (BaseAddon) this, 41690, -1, 1, 25, 1646, -1, "", 1);// 249
			AddComplexComponent( (BaseAddon) this, 41690, -1, 0, 25, 1646, -1, "", 1);// 250
			AddComplexComponent( (BaseAddon) this, 41690, -2, 0, 25, 1646, -1, "", 1);// 251
			AddComplexComponent( (BaseAddon) this, 5534, -2, 1, 27, 1646, -1, "", 1);// 253
			AddComplexComponent( (BaseAddon) this, 16815, -1, -2, 46, 1646, -1, "", 1);// 254
			AddComplexComponent( (BaseAddon) this, 16815, -1, -3, 46, 1646, -1, "", 1);// 255
			AddComplexComponent( (BaseAddon) this, 16815, -1, -4, 46, 1646, -1, "", 1);// 256
			AddComplexComponent( (BaseAddon) this, 16815, -1, -5, 46, 1646, -1, "", 1);// 257
			AddComplexComponent( (BaseAddon) this, 16815, -1, 1, 46, 1175, -1, "", 1);// 258
			AddComplexComponent( (BaseAddon) this, 16815, -1, -1, 46, 1646, -1, "", 1);// 259
			AddComplexComponent( (BaseAddon) this, 16815, -2, 1, 46, 1646, -1, "", 1);// 260
			AddComplexComponent( (BaseAddon) this, 16815, -2, 0, 46, 1646, -1, "", 1);// 261
			AddComplexComponent( (BaseAddon) this, 16818, -1, -5, 25, 1646, -1, "", 1);// 262
			AddComplexComponent( (BaseAddon) this, 17238, -2, -3, 24, 1175, 255, "", 1);// 263
			AddComplexComponent( (BaseAddon) this, 16815, -1, -1, 25, 1646, -1, "", 1);// 264
			AddComplexComponent( (BaseAddon) this, 16818, -2, 0, 25, 1646, -1, "", 1);// 265
			AddComplexComponent( (BaseAddon) this, 16818, -2, 1, 25, 1646, -1, "", 1);// 266
			AddComplexComponent( (BaseAddon) this, 16818, -1, -4, 25, 1646, -1, "", 1);// 267
			AddComplexComponent( (BaseAddon) this, 16815, -1, -3, 25, 1646, -1, "", 1);// 268
			AddComplexComponent( (BaseAddon) this, 16818, -1, -2, 25, 1646, -1, "", 1);// 269
			AddComplexComponent( (BaseAddon) this, 17190, -2, -6, 24, 1175, -1, "", 1);// 270
			AddComplexComponent( (BaseAddon) this, 17226, -3, 0, 24, 1175, -1, "", 1);// 271
			AddComplexComponent( (BaseAddon) this, 17240, -3, 1, 24, 1175, 255, "", 1);// 272
			AddComplexComponent( (BaseAddon) this, 9541, -2, -1, 24, 1175, -1, "", 1);// 273
			AddComplexComponent( (BaseAddon) this, 17226, -2, -2, 24, 1175, -1, "", 1);// 274
			AddComplexComponent( (BaseAddon) this, 17238, -2, -4, 24, 1175, 255, "", 1);// 275
			AddComplexComponent( (BaseAddon) this, 17227, -1, -6, 24, 1175, -1, "", 1);// 276
			AddComplexComponent( (BaseAddon) this, 17226, -2, -5, 24, 1175, -1, "", 1);// 277
			AddComplexComponent( (BaseAddon) this, 1978, -1, 1, 19, 1175, -1, "", 1);// 278
			AddComplexComponent( (BaseAddon) this, 1978, -1, 0, 19, 1175, -1, "", 1);// 279
			AddComplexComponent( (BaseAddon) this, 17190, -3, -1, 24, 1175, -1, "", 1);// 280
			AddComplexComponent( (BaseAddon) this, 16815, -1, 0, 46, 1175, -1, "", 1);// 281
			AddComplexComponent( (BaseAddon) this, 16815, -2, -1, 25, 1646, -1, "", 1);// 282
			AddComplexComponent( (BaseAddon) this, 16818, -1, 0, 25, 1646, -1, "", 1);// 283
			AddComplexComponent( (BaseAddon) this, 4632, -1, -5, 25, 1646, -1, "", 1);// 284
			AddComplexComponent( (BaseAddon) this, 16815, -1, 1, 25, 1646, -1, "", 1);// 285
			AddComplexComponent( (BaseAddon) this, 1978, -1, -4, 19, 1175, -1, "", 1);// 286
			AddComplexComponent( (BaseAddon) this, 4634, -1, -3, 25, 1646, -1, "", 1);// 287
			AddComplexComponent( (BaseAddon) this, 1978, -1, -3, 19, 1175, -1, "", 1);// 288
			AddComplexComponent( (BaseAddon) this, 1978, -1, -2, 19, 1175, -1, "", 1);// 289
			AddComplexComponent( (BaseAddon) this, 1978, -1, -5, 19, 1175, -1, "", 1);// 290
			AddComplexComponent( (BaseAddon) this, 1978, -1, -1, 19, 1175, -1, "", 1);// 291

		}

		public CHOOCHOOBarCarAddon( Serial serial ) : base( serial )
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

	public class CHOOCHOOBarCarAddonDeed : BaseAddonDeed
	{
		public override BaseAddon Addon
		{
			get
			{
				return new CHOOCHOOBarCarAddon();
			}
		}

		[Constructable]
		public CHOOCHOOBarCarAddonDeed()
		{
			Name = "CHOOCHOOBarCar";
		}

		public CHOOCHOOBarCarAddonDeed( Serial serial ) : base( serial )
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