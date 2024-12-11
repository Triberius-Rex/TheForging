
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
	public class SmithyTownhouseAddon : BaseAddon
	{
        private static int[,] m_AddOnSimpleComponents = new int[,] {
			  {4612, 3, 3, 22}, {5501, 5, 3, 22}, {4550, 3, 3, 3}// 1	2	4	
			, {1250, 3, -5, 22}, {1250, 4, -5, 22}, {1250, 4, -4, 22}// 6	7	8	
			, {1250, 3, -4, 22}, {18175, 5, 1, 22}, {18175, 5, 0, 25}// 9	10	11	
			, {1250, 4, -3, 42}, {1250, 4, -4, 42}, {1250, 4, -5, 42}// 12	13	14	
			, {1250, 3, -3, 42}, {1250, 3, -4, 42}, {1250, 3, -5, 42}// 15	16	17	
			, {490, 4, -1, 42}, {490, 4, -2, 42}, {490, 6, -5, 22}// 18	19	20	
			, {490, 6, -4, 22}, {10081, 3, -6, 22}, {489, 3, 3, 42}// 21	22	23	
			, {1955, 4, -4, 17}, {1955, 6, -4, 17}, {1955, 5, -4, 17}// 24	25	26	
			, {1955, 5, -5, 17}, {1955, 6, -5, 17}, {1955, 4, -5, 17}// 27	28	29	
			, {1955, 3, -5, 17}, {489, 4, 3, 42}, {489, 4, -6, 42}// 30	31	32	
			, {311, 4, 1, 22}, {311, 4, 0, 22}, {490, 4, -4, 42}// 33	34	35	
			, {490, 4, -3, 42}, {490, 4, 0, 42}, {490, 4, 1, 42}// 36	37	38	
			, {490, 4, 3, 42}, {490, 4, 2, 42}, {1250, 4, 3, 42}// 39	40	41	
			, {1250, 4, 2, 42}, {1250, 4, 1, 42}, {1250, 4, 0, 42}// 42	43	44	
			, {1250, 4, -1, 42}, {1250, 4, -2, 42}, {1250, 4, -3, 42}// 45	46	47	
			, {1250, 3, 3, 42}, {1250, 3, 2, 42}, {1250, 3, 1, 42}// 48	49	50	
			, {1250, 3, 0, 42}, {1250, 3, -1, 42}, {1250, 3, -2, 42}// 51	52	53	
			, {1250, 3, -3, 42}, {4161, 3, 3, 27}, {490, 4, -5, 42}// 54	55	56	
			, {1316, 4, 6, 2}, {1316, 6, 6, 2}, {1404, 5, 6, 2}// 57	58	59	
			, {1404, 3, 6, 2}, {9173, 3, 4, 22}, {9179, 3, 6, 18}// 60	61	62	
			, {9179, 4, 6, 18}, {9178, 4, 5, 21}, {9178, 3, 5, 21}// 63	64	65	
			, {10079, 4, -5, 22}, {9555, 4, -3, 2}, {489, 6, -6, 22}// 66	67	68	
			, {9173, 4, 4, 22}, {489, 5, -6, 22}, {147, 6, -5, 2}// 69	70	71	
			, {490, 6, -2, 22}, {147, 4, 6, 2}, {1404, 3, 4, 2}// 72	73	74	
			, {1316, 4, 4, 2}, {1404, 5, 4, 2}, {1316, 5, 3, 2}// 75	76	77	
			, {1404, 6, 3, 2}, {1316, 6, 4, 2}, {1404, 6, 5, 2}// 78	79	80	
			, {1316, 5, 5, 2}, {1404, 4, 5, 2}, {1316, 3, 5, 2}// 81	82	83	
			, {1316, 3, -3, 2}, {9555, 4, -3, 2}, {1956, 6, -1, 17}// 84	85	86	
			, {1956, 5, -1, 17}, {1956, 6, 0, 12}, {1956, 5, 0, 12}// 87	88	89	
			, {1956, 6, 1, 7}, {1956, 5, 1, 7}, {1956, 6, 2, 2}// 90	91	92	
			, {1956, 5, 2, 2}, {1955, 6, 1, 2}, {1955, 5, 1, 2}// 93	94	95	
			, {1955, 5, 0, 7}, {1955, 5, 0, 2}, {1955, 6, 0, 7}// 96	97	98	
			, {1955, 6, 0, 2}, {1955, 5, -1, 12}, {1955, 5, -1, 7}// 99	100	101	
			, {1955, 5, -1, 2}, {1955, 6, -1, 12}, {1955, 6, -1, 7}// 102	103	104	
			, {1955, 6, -1, 2}, {1955, 6, -2, 17}, {1955, 6, -2, 12}// 105	106	107	
			, {1955, 6, -2, 7}, {1955, 6, -2, 2}, {1955, 5, -2, 17}// 108	109	110	
			, {1955, 5, -2, 12}, {1955, 5, -2, 7}, {1955, 5, -2, 2}// 111	112	113	
			, {1955, 6, -3, 17}, {1955, 6, -3, 12}, {1955, 6, -3, 7}// 114	115	116	
			, {1955, 6, -3, 2}, {1955, 5, -3, 17}, {1955, 5, -3, 12}// 117	118	119	
			, {1955, 5, -3, 7}, {1955, 5, -3, 2}, {4161, 3, 3, 31}// 120	121	122	
			, {307, 4, -6, 22}, {1955, 3, -4, 17}, {311, 4, 2, 22}// 123	124	125	
			, {313, 4, -1, 22}, {10079, 4, -2, 22}, {489, 3, -6, 42}// 126	127	128	
			, {490, 6, -3, 22}, {309, 4, 3, 22}, {1250, 4, 3, 22}// 129	130	131	
			, {1250, 4, 2, 22}, {1250, 4, 1, 22}, {1250, 4, 0, 23}// 132	133	134	
			, {1250, 4, -1, 22}, {1250, 4, -2, 22}, {1250, 4, -3, 22}// 135	136	137	
			, {1250, 3, 3, 22}, {1250, 3, 2, 22}, {1250, 3, 1, 22}// 138	139	140	
			, {1250, 3, 0, 22}, {1250, 3, -1, 22}, {1250, 3, -2, 22}// 141	142	143	
			, {1250, 3, -3, 22}, {1404, 4, 3, 2}, {1316, 4, 2, 2}// 144	145	146	
			, {1316, 4, 1, 2}, {1316, 4, 0, 2}, {1316, 4, -1, 2}// 147	148	149	
			, {1316, 4, -2, 2}, {1316, 3, 3, 2}, {1316, 3, 2, 2}// 150	151	152	
			, {1316, 3, 1, 2}, {1316, 3, 0, 2}, {1316, 3, -1, 2}// 153	154	155	
			, {1316, 3, -2, 2}, {1316, 3, -3, 2}, {1316, 3, 0, 2}// 156	157	158	
			, {472, 4, 3, 2}, {463, 4, 2, 2}, {464, 3, 2, 2}// 159	160	161	
			, {465, 4, 1, 2}, {465, 4, 0, 2}, {465, 4, -1, 2}// 162	163	164	
			, {465, 4, -2, 2}, {464, 3, -4, 2}, {4161, 2, 3, 27}// 165	166	171	
			, {4161, 2, 3, 31}, {1250, 2, 2, 22}, {4613, 2, 3, 22}// 172	173	174	
			, {2974, -5, 7, 2}, {3016, -5, 7, 2}, {4626, -1, 1, 62}// 175	176	177	
			, {4627, -2, 1, 62}, {4628, -3, 1, 62}, {4625, -1, 0, 62}// 178	179	180	
			, {4630, -2, 0, 62}, {5509, -5, 4, 23}, {4623, -2, -1, 62}// 181	182	183	
			, {4629, -3, 0, 62}, {4624, -1, -1, 62}, {147, -4, -4, 2}// 184	185	186	
			, {5491, -4, 0, 5}, {5496, 1, 4, 23}, {5453, 0, 3, 3}// 187	188	189	
			, {16449, 0, -3, 2}, {470, -3, 2, 2}, {147, -4, -5, 2}// 191	193	196	
			, {4133, -3, -3, 2}, {41725, -4, 2, 31}, {4550, -4, 3, 3}// 197	200	201	
			, {4550, -1, 3, 3}, {4015, -3, -1, 2}, {4622, -3, -1, 62}// 202	205	206	
			, {12517, -2, 2, 42}, {12518, -1, 2, 42}, {1955, -4, 1, 42}// 210	211	212	
			, {2778, -1, 0, 43}, {2778, -1, -1, 43}, {2778, -1, -2, 43}// 213	214	215	
			, {2778, -2, -2, 43}, {2778, -2, -1, 43}, {2778, -2, 0, 43}// 216	217	218	
			, {2778, -3, 0, 43}, {2778, -3, -1, 43}, {2778, -3, -2, 43}// 219	220	221	
			, {2780, -4, -3, 43}, {2785, 0, -2, 43}, {2784, -3, -3, 43}// 222	223	224	
			, {2784, -2, -3, 43}, {2784, -1, -3, 43}, {2783, -4, -2, 43}// 225	226	227	
			, {2783, -4, -1, 43}, {2783, -4, 0, 43}, {2782, 0, -3, 43}// 228	229	230	
			, {2786, -3, 1, 43}, {2781, -4, 1, 43}, {2786, -2, 1, 43}// 231	232	233	
			, {2786, -1, 1, 43}, {2785, 0, -1, 43}, {2785, 0, 0, 43}// 234	235	236	
			, {2779, 0, 1, 43}, {12377, -1, -3, 43}, {12375, -2, -1, 43}// 237	238	239	
			, {12374, -1, -1, 43}, {12376, -1, -2, 43}, {4086, 1, 0, 35}// 240	241	243	
			, {2519, 1, -1, 29}, {2519, 1, 0, 29}, {2519, 0, 0, 29}// 244	245	246	
			, {2519, -1, 0, 29}, {2519, -1, -1, 29}, {2519, 0, -1, 29}// 247	248	249	
			, {4632, 0, -2, 23}, {4634, 0, 1, 23}, {4612, 1, 0, 23}// 250	251	252	
			, {4613, -1, 0, 23}, {4614, 0, 0, 23}, {4612, 1, -1, 23}// 253	254	255	
			, {4613, -1, -1, 23}, {4614, 0, -1, 23}, {4635, 2, -1, 23}// 256	257	258	
			, {4633, -2, -1, 23}, {4633, -2, 0, 23}, {4635, 2, 0, 23}// 259	260	261	
			, {2778, 1, 0, 23}, {2778, 1, -1, 23}, {2778, 1, -2, 23}// 262	263	264	
			, {2778, 0, -2, 23}, {2778, 0, -1, 23}, {2778, 0, 0, 23}// 265	266	267	
			, {2778, -1, 0, 23}, {2778, -1, -1, 23}, {2778, -1, -2, 23}// 268	269	270	
			, {2780, -2, -3, 23}, {2785, 2, -2, 23}, {2784, -1, -3, 23}// 271	272	273	
			, {2784, 0, -3, 23}, {2784, 1, -3, 23}, {2783, -2, -2, 23}// 274	275	276	
			, {2783, -2, -1, 23}, {2783, -2, 0, 23}, {2782, 2, -3, 23}// 277	278	279	
			, {2786, -1, 1, 23}, {2781, -2, 1, 23}, {2786, 0, 1, 23}// 280	281	282	
			, {2786, 1, 1, 23}, {2785, 2, -1, 23}, {2785, 2, 0, 23}// 283	284	285	
			, {2779, 2, 1, 23}, {5091, 2, -1, 6}, {7153, 2, -3, 2}// 286	287	290	
			, {7152, -1, -3, 2}, {4015, 2, -1, 2}, {4017, 1, -1, 2}// 291	292	293	
			, {2883, -1, -1, 2}, {2884, 0, -1, 2}, {1250, 1, -4, 22}// 294	295	296	
			, {1250, 2, -4, 22}, {1250, 2, -5, 22}, {1250, 1, -5, 22}// 297	299	300	
			, {489, 0, -4, 2}, {106, -3, -4, 82}, {105, -3, -5, 82}// 302	304	305	
			, {105, -4, -3, 82}, {106, -5, -3, 82}, {106, -1, -4, 82}// 306	307	308	
			, {106, -5, -4, 102}, {106, -5, 0, 82}, {106, -6, 1, 82}// 309	310	311	
			, {106, -6, 0, 82}, {105, 0, -5, 82}, {105, -4, -5, 102}// 312	313	314	
			, {105, -5, -1, 82}, {108, -1, -5, 82}, {108, -5, -5, 102}// 315	316	317	
			, {1316, -3, -3, 82}, {1316, -3, -4, 82}, {463, -4, -4, 82}// 318	319	320	
			, {1316, -4, -3, 82}, {1316, -4, -4, 82}, {464, -4, -5, 82}// 321	322	323	
			, {108, -6, -1, 82}, {107, 0, -4, 82}, {466, -5, -5, 82}// 324	325	326	
			, {466, -1, -5, 62}, {464, 0, -5, 62}, {466, -5, -5, 62}// 327	328	329	
			, {466, -6, -4, 42}, {464, -4, -3, 62}, {464, -3, -5, 62}// 330	331	332	
			, {464, -4, -5, 62}, {465, -1, -4, 62}, {465, -5, -3, 62}// 333	334	335	
			, {465, -5, -4, 82}, {465, -3, -4, 62}, {465, -5, -4, 62}// 336	337	338	
			, {463, -3, -3, 62}, {463, 0, -4, 62}, {491, -6, -6, 62}// 339	340	341	
			, {489, 1, 3, 62}, {489, 0, 3, 62}, {489, -1, 3, 62}// 342	343	344	
			, {489, -3, 3, 62}, {489, -2, 3, 62}, {489, -4, 3, 62}// 345	346	347	
			, {489, -5, 3, 62}, {489, 1, -6, 62}, {489, 0, -6, 62}// 348	349	350	
			, {489, -1, -6, 62}, {489, -2, -6, 62}, {489, -3, -6, 62}// 351	352	353	
			, {489, -4, -6, 62}, {489, -5, -6, 62}, {490, 1, -5, 62}// 354	355	356	
			, {490, 1, -4, 62}, {490, 1, -3, 62}, {490, 1, -2, 62}// 357	358	359	
			, {490, 1, -1, 62}, {490, 1, 0, 62}, {490, 1, 1, 62}// 360	361	362	
			, {490, 1, 2, 62}, {490, 1, 3, 62}, {490, -6, 3, 62}// 363	364	365	
			, {490, -6, 2, 62}, {490, -6, -2, 62}, {490, -6, -5, 62}// 366	367	368	
			, {490, -6, -4, 62}, {490, -6, -3, 62}, {10079, 1, 0, 42}// 369	370	371	
			, {298, -6, -6, 42}, {1250, 2, -3, 42}, {307, 1, -6, 42}// 372	373	374	
			, {489, -1, -4, 2}, {1404, 2, -1, 2}, {1250, 1, 3, 62}// 379	380	381	
			, {1250, 1, 2, 62}, {1250, 1, 1, 62}, {1250, 1, 0, 62}// 382	383	384	
			, {1250, 1, -1, 62}, {1250, 1, -2, 62}, {1250, 1, -3, 62}// 385	386	387	
			, {1250, 1, -4, 62}, {1250, 1, -5, 62}, {1250, 0, 3, 62}// 388	389	390	
			, {1250, 0, 2, 62}, {1250, 0, 1, 62}, {1250, 0, 0, 62}// 391	392	393	
			, {1250, 0, -1, 62}, {1250, 0, -2, 62}, {1250, 0, -3, 62}// 394	395	396	
			, {1250, 0, -4, 62}, {1250, 0, -5, 62}, {489, 2, -4, 2}// 397	398	399	
			, {1250, -1, 3, 62}, {1250, -1, 2, 62}, {1250, -1, 1, 62}// 400	401	402	
			, {1250, -1, 0, 62}, {1250, -1, -1, 62}, {1250, -1, -2, 62}// 403	404	405	
			, {1250, -1, -3, 62}, {1250, -1, -4, 62}, {1250, -1, -5, 62}// 406	407	408	
			, {1250, -2, 3, 62}, {1250, -2, 2, 62}, {1250, -2, 1, 62}// 410	411	412	
			, {1250, -2, 0, 62}, {1250, -2, -1, 62}, {1250, -2, -2, 62}// 413	414	415	
			, {1250, -2, -3, 62}, {1250, -2, -4, 62}, {1250, -2, -5, 62}// 416	417	418	
			, {489, -2, -4, 2}, {1250, -3, 3, 62}, {1250, -3, 2, 62}// 419	420	421	
			, {1250, -3, 1, 62}, {1250, -3, 0, 62}, {1250, -3, -1, 62}// 422	423	424	
			, {1250, -3, -2, 62}, {1250, -3, -3, 62}, {1250, -3, -4, 62}// 425	426	427	
			, {1250, -3, -5, 62}, {1250, -4, 3, 62}, {1250, -4, 2, 62}// 428	430	431	
			, {1250, -4, 1, 62}, {1250, -4, 0, 62}, {1250, -4, -1, 62}// 432	433	434	
			, {1250, -4, -2, 62}, {1250, -4, -3, 62}, {1250, -4, -4, 62}// 435	436	437	
			, {1250, -4, -5, 62}, {1250, -5, 3, 62}, {1250, -5, 2, 62}// 438	440	441	
			, {1250, -5, 1, 62}, {1250, -5, 0, 62}, {1250, -5, -1, 62}// 442	443	444	
			, {1250, -5, -2, 62}, {1250, -5, -3, 62}, {1250, -5, -4, 62}// 445	446	447	
			, {1250, -5, -5, 62}, {489, 1, -4, 2}, {465, -5, 0, 62}// 448	449	450	
			, {466, -6, -1, 62}, {465, -6, 0, 62}, {464, -5, -1, 62}// 451	452	453	
			, {465, -6, 1, 62}, {463, -5, 1, 62}, {1316, -5, 0, 2}// 454	455	456	
			, {1316, -5, -1, 2}, {1316, -5, -2, 42}, {1316, -3, -4, 22}// 457	460	464	
			, {1316, 2, -4, 2}, {312, 0, -6, 42}, {1250, 2, -3, 42}// 465	467	468	
			, {1250, 2, -4, 42}, {1250, 2, -5, 42}, {1250, 1, -3, 42}// 469	470	471	
			, {1250, 1, -4, 42}, {1250, 1, -5, 42}, {1250, 0, -3, 42}// 472	473	474	
			, {10081, -4, -6, 52}, {1250, -1, -3, 42}, {342, -3, -6, 42}// 475	476	477	
			, {342, -2, -6, 42}, {1250, -2, -3, 42}, {10081, -4, -6, 42}// 478	479	480	
			, {10081, -1, -6, 42}, {1250, -3, -3, 42}, {311, 1, -4, 42}// 481	482	483	
			, {307, -5, -6, 42}, {1250, -5, -3, 42}, {1250, -4, -4, 42}// 484	485	486	
			, {1250, -4, -5, 42}, {472, -5, -1, 42}, {1250, -5, -4, 42}// 487	488	489	
			, {1250, -5, -5, 42}, {465, -6, -1, 42}, {311, 1, -5, 42}// 490	491	492	
			, {1316, -5, -1, 42}, {307, 1, -6, 22}, {310, 0, -6, 22}// 493	494	495	
			, {10081, 2, -6, 22}, {10081, -4, 3, 52}, {1955, -3, -4, 22}// 496	497	498	
			, {1955, -4, -4, 17}, {1957, -3, -4, 37}, {1957, -3, -5, 37}// 499	500	501	
			, {1957, -2, -5, 32}, {1957, -2, -4, 32}, {2420, -4, -2, 22}// 502	503	504	
			, {310, -3, -6, 22}, {489, 2, 3, 42}, {10081, -1, 3, 42}// 506	507	508	
			, {10081, -1, 3, 52}, {10081, -4, 3, 42}, {312, 0, 3, 42}// 509	510	511	
			, {10081, -4, 3, 32}, {10081, -4, 3, 22}, {1955, 1, -5, 17}// 513	514	515	
			, {1955, -3, -5, 17}, {1955, -3, -4, 17}, {1955, -1, -4, 17}// 516	517	518	
			, {1955, -4, -4, 32}, {1955, -4, -4, 27}, {1955, -3, -5, 27}// 519	520	521	
			, {1955, -2, -4, 27}, {1955, -3, -5, 32}, {1955, -2, -4, 22}// 522	523	524	
			, {1955, -2, -5, 22}, {1957, -1, -4, 27}, {1957, -1, -5, 27}// 525	526	527	
			, {1957, 0, -4, 22}, {1955, 1, -4, 17}, {1955, -4, -5, 17}// 528	529	530	
			, {1955, -1, -5, 22}, {1955, -1, -4, 22}, {1955, -5, -4, 37}// 531	532	533	
			, {310, -1, -6, 22}, {1955, -2, -5, 27}, {1955, -2, -4, 17}// 534	535	536	
			, {1955, -5, -5, 37}, {1957, 0, -5, 22}, {1955, -4, -4, 37}// 537	539	540	
			, {1955, -3, -5, 22}, {1955, -4, -5, 37}, {310, -2, -6, 22}// 541	542	543	
			, {310, -4, -6, 22}, {1955, -4, -3, 22}, {465, -5, -2, 22}// 544	545	546	
			, {466, -6, -4, 22}, {464, -5, -3, 22}, {465, -6, 3, 22}// 547	548	549	
			, {465, -6, -2, 22}, {465, -6, -3, 22}, {1955, -4, 2, 22}// 550	551	552	
			, {473, -5, 0, 22}, {466, -6, -2, 2}, {463, -5, -2, 2}// 553	554	555	
			, {463, -5, 1, 2}, {107, -4, -4, 102}, {311, -6, 3, 42}// 556	557	558	
			, {465, -6, 2, 42}, {465, -6, -2, 42}, {465, -6, 1, 42}// 559	560	561	
			, {465, -6, 0, 42}, {311, -6, -4, 42}, {311, -6, -5, 42}// 562	563	564	
			, {107, -5, 1, 82}, {311, 1, -3, 42}, {307, -5, 3, 42}// 565	566	567	
			, {342, -3, 3, 42}, {1250, 2, 3, 42}, {1250, 2, 2, 42}// 568	569	570	
			, {1250, 2, 1, 42}, {1250, 2, 0, 42}, {1250, 2, -1, 42}// 571	572	573	
			, {1250, 2, -2, 42}, {342, -2, 3, 42}, {1250, 1, 3, 42}// 574	575	576	
			, {1250, 1, 2, 42}, {1250, 1, 1, 42}, {1250, 1, 0, 42}// 577	578	579	
			, {1250, 1, -1, 42}, {1250, 1, -2, 42}, {1250, 1, -3, 42}// 580	581	582	
			, {1955, 0, -4, 17}, {1250, 0, 3, 42}, {1250, 0, 2, 42}// 583	584	585	
			, {1250, 0, 1, 42}, {1250, 0, 0, 42}, {1250, 0, -1, 42}// 586	587	588	
			, {1250, 0, -2, 42}, {1250, 0, -3, 42}, {1250, -1, 3, 42}// 589	590	591	
			, {1250, -1, 2, 42}, {1250, -1, 1, 42}, {1250, -1, 0, 42}// 592	593	594	
			, {1250, -1, -1, 42}, {1250, -1, -2, 42}, {1250, -1, -3, 42}// 595	596	597	
			, {10079, 1, 2, 42}, {1250, -2, 3, 42}, {1250, -2, 2, 42}// 598	599	600	
			, {1250, -2, 1, 42}, {1250, -2, 0, 42}, {1250, -2, -1, 42}// 601	602	603	
			, {1250, -2, -2, 42}, {1250, -2, -3, 42}, {311, 1, -1, 42}// 604	605	606	
			, {1250, -3, 3, 42}, {1250, -3, 2, 42}, {1250, -3, 1, 42}// 607	608	609	
			, {1250, -3, 0, 42}, {1250, -3, -1, 42}, {1250, -3, -2, 42}// 610	611	612	
			, {1250, -3, -3, 42}, {489, 2, -6, 42}, {1250, -4, 3, 42}// 613	614	615	
			, {1250, -4, 2, 42}, {1250, -4, 1, 42}, {1250, -4, 0, 42}// 616	617	618	
			, {1250, -4, -1, 42}, {1250, -4, -2, 42}, {1250, -4, -3, 42}// 619	620	621	
			, {1316, -1, -4, 2}, {1250, -5, 3, 42}, {1250, -5, 2, 42}// 622	623	624	
			, {465, -6, -3, 42}, {464, -5, -3, 42}, {463, -5, 1, 42}// 625	626	627	
			, {465, -5, -2, 42}, {473, -5, 0, 42}, {4015, 0, 5, 2}// 628	629	630	
			, {4015, -1, 5, 2}, {4017, 1, 5, 2}, {4017, -2, 5, 2}// 631	632	633	
			, {1316, 2, 6, 2}, {1404, 1, 6, 2}, {1316, 0, 6, 2}// 634	635	636	
			, {1404, -1, 6, 2}, {1316, -2, 6, 2}, {1316, -4, 6, 2}// 637	638	639	
			, {9179, -5, 6, 18}, {9179, -4, 6, 18}, {10509, -3, 6, 18}// 640	641	642	
			, {10509, -2, 6, 18}, {9179, -1, 6, 18}, {9179, 0, 6, 18}// 643	644	645	
			, {10509, 1, 6, 18}, {10509, 2, 6, 18}, {10508, 2, 5, 21}// 646	647	648	
			, {10508, 1, 5, 21}, {9178, 0, 5, 21}, {9178, -1, 5, 21}// 649	650	651	
			, {10508, -2, 5, 21}, {10508, -3, 5, 21}, {9178, -4, 5, 21}// 652	653	654	
			, {9178, -5, 5, 21}, {10503, 2, 4, 22}, {10503, 1, 4, 22}// 655	656	657	
			, {9173, 0, 4, 22}, {9173, -1, 4, 22}, {10503, -2, 4, 22}// 658	659	660	
			, {10503, -3, 4, 22}, {9173, -4, 4, 22}, {1404, -3, 6, 2}// 661	662	663	
			, {9173, -5, 4, 22}, {472, -5, -1, 2}, {10081, -1, -6, 52}// 664	665	666	
			, {147, -5, 6, 2}, {1404, -3, 4, 2}, {1316, -2, 4, 2}// 668	669	670	
			, {1404, -1, 4, 2}, {1316, 0, 4, 2}, {1404, 1, 4, 2}// 671	672	673	
			, {1316, 2, 4, 2}, {1404, 2, 5, 2}, {1316, 1, 5, 2}// 674	675	676	
			, {1404, 0, 5, 2}, {1316, -1, 5, 2}, {1404, -2, 5, 2}// 677	678	679	
			, {1316, -3, 5, 2}, {1404, -4, 5, 2}, {1316, -4, 4, 2}// 680	681	682	
			, {1404, -4, -3, 2}, {466, -4, -4, 0}, {1404, 2, -3, 2}// 683	684	685	
			, {1316, 1, -3, 2}, {1404, 0, -3, 2}, {1316, -1, -3, 2}// 686	687	688	
			, {1404, -2, -3, 2}, {9541, -4, -3, 2}, {307, 1, 3, 22}// 689	690	692	
			, {1316, -5, 0, 42}, {312, 0, 3, 22}, {10081, -1, 3, 22}// 693	694	695	
			, {342, -2, 3, 22}, {342, -3, 3, 22}, {307, -5, 3, 22}// 696	697	698	
			, {1955, -1, -5, 17}, {1955, -2, -5, 17}, {10081, -1, 3, 32}// 699	700	701	
			, {1955, -3, -4, 32}, {1955, 0, -5, 17}, {1955, 2, -5, 17}// 702	703	704	
			, {1955, 2, -4, 17}, {1955, -3, -4, 27}, {147, -5, -4, 2}// 705	706	707	
			, {465, -6, 1, 22}, {465, -6, 1, 22}, {465, -6, 0, 22}// 708	709	710	
			, {465, -6, -1, 22}, {472, -5, -1, 22}, {465, -6, 2, 22}// 711	712	713	
			, {463, -5, 1, 22}, {1250, 2, 3, 22}, {1250, 2, 1, 22}// 714	716	717	
			, {1250, 2, 0, 22}, {1250, 2, -1, 22}, {1250, 2, -2, 22}// 718	719	720	
			, {1250, 2, -3, 22}, {1250, 1, 3, 22}, {1250, 1, 2, 22}// 721	722	723	
			, {1250, 1, 1, 22}, {1250, 1, 0, 22}, {1250, 1, -1, 22}// 724	725	726	
			, {1250, 1, -2, 22}, {1250, 1, -3, 22}, {1250, 0, 3, 22}// 727	728	729	
			, {1250, 0, 2, 22}, {1250, 0, 1, 22}, {1250, 0, 0, 22}// 730	731	732	
			, {1250, 0, -1, 22}, {1250, 0, -2, 22}, {1250, 0, -3, 22}// 733	734	735	
			, {1250, -1, 3, 22}, {1250, -1, 2, 22}, {1250, -1, 1, 22}// 736	737	738	
			, {1250, -1, 0, 22}, {1250, -1, -1, 22}, {1250, -1, -2, 22}// 739	740	741	
			, {1250, -1, -3, 22}, {1250, -2, 3, 22}, {1250, -2, 2, 22}// 742	743	744	
			, {1250, -2, 1, 22}, {1250, -2, 0, 22}, {1250, -2, -1, 22}// 745	746	747	
			, {1250, -2, -2, 22}, {1250, -2, -3, 22}, {1250, -3, 3, 22}// 748	749	750	
			, {1250, -3, 2, 22}, {1250, -3, 1, 22}, {1250, -3, 0, 22}// 751	752	753	
			, {1250, -3, -1, 22}, {1250, -3, -2, 22}, {1250, -3, -3, 22}// 754	755	756	
			, {1250, -4, 3, 22}, {1250, -4, 2, 22}, {1316, -4, 1, 22}// 757	758	759	
			, {1316, -4, 0, 22}, {1316, -4, -1, 22}, {1316, -4, -2, 22}// 760	761	762	
			, {1250, -4, -3, 22}, {1250, -5, 3, 22}, {1250, -5, 2, 22}// 763	764	765	
			, {472, -5, 3, 2}, {1404, 2, 3, 2}, {1316, 2, 2, 2}// 766	767	768	
			, {1316, 2, 1, 2}, {1316, 2, 0, 2}, {1316, 2, -2, 2}// 769	770	771	
			, {472, 0, 3, 2}, {1316, 1, 3, 2}, {1404, 1, 2, 2}// 772	773	774	
			, {1316, 1, 1, 2}, {1404, 1, 0, 2}, {1316, 1, -1, 1}// 775	776	777	
			, {1404, 1, -2, 2}, {1404, 0, 3, 2}, {1316, 0, 2, 2}// 778	779	780	
			, {1404, 0, 1, 2}, {1316, 0, 0, 2}, {1404, 0, -1, 2}// 781	782	783	
			, {1316, 0, -2, 2}, {1250, -5, -3, 22}, {1316, -1, 3, 2}// 784	785	786	
			, {1316, -1, 2, 2}, {1316, -1, 1, 2}, {1404, -1, 0, 2}// 787	788	789	
			, {1316, -1, -1, 2}, {1404, -1, -2, 2}, {1316, -5, -2, 22}// 790	791	792	
			, {1404, -2, 3, 2}, {1316, -2, 2, 2}, {1316, -2, 1, 2}// 793	794	795	
			, {1316, -2, 0, 2}, {1404, -2, -1, 2}, {1316, -2, -2, 2}// 796	797	798	
			, {1316, -5, -1, 22}, {1316, -3, 3, 2}, {1404, -3, 2, 2}// 799	800	801	
			, {1316, -3, 1, 2}, {1404, -3, 0, 2}, {1316, -3, -1, 2}// 802	803	804	
			, {1404, -3, -2, 2}, {1316, -5, 0, 22}, {1404, -4, 3, 2}// 805	806	807	
			, {1316, -4, 2, 2}, {1404, -4, 1, 2}, {470, 1, 2, 2}// 808	809	810	
			, {4017, -2, -1, 2}, {1316, -4, 0, 2}, {464, 0, 2, 2}// 811	812	813	
			, {1404, -4, -1, 2}, {464, -1, 2, 2}, {1250, -5, 1, 22}// 814	815	816	
			, {1316, -4, -2, 3}, {466, -5, -3, 0}, {471, 2, -4, 2}// 817	818	819	
			, {470, 1, -4, 2}, {464, 0, -4, 2}, {471, -1, -4, 2}// 820	821	822	
			, {466, -3, -4, 2}, {470, -2, -4, 2}, {464, -3, -4, 2}// 823	824	825	
			, {1316, -3, -3, 2}, {471, -2, 2, 2}, {464, -4, 2, 2}// 826	827	828	
			, {465, -6, 0, 2}, {465, -6, -1, 2}, {473, -5, 0, 2}// 829	830	831	
			, {465, -6, 1, 2}, {465, -5, 2, 2}, {471, 2, 2, 2}// 832	833	834	
			, {1955, -5, -4, 32}, {1955, -4, -5, 27}, {1955, -4, -4, 22}// 835	836	837	
			, {1955, -5, -4, 27}, {1955, -4, -5, 32}, {1955, -4, -5, 22}// 838	839	840	
			, {309, 1, 3, 42}, {311, 1, -2, 42}// 841	842	
		};

 
            
		public override BaseAddonDeed Deed
		{
			get
			{
				return new SmithyTownhouseAddonDeed();
			}
		}

		[ Constructable ]
		public SmithyTownhouseAddon()
		{

            for (int i = 0; i < m_AddOnSimpleComponents.Length / 4; i++)
                AddComponent( new AddonComponent( m_AddOnSimpleComponents[i,0] ), m_AddOnSimpleComponents[i,1], m_AddOnSimpleComponents[i,2], m_AddOnSimpleComponents[i,3] );


			AddComplexComponent( (BaseAddon) this, 41188, 3, 3, 6, 1153, -1, "", 1);// 3
			AddComplexComponent( (BaseAddon) this, 41183, 3, 3, 2, 1153, -1, "", 1);// 5
			AddComplexComponent( (BaseAddon) this, 41631, 0, -3, 23, 448, -1, "", 1);// 167
			AddComplexComponent( (BaseAddon) this, 41627, -2, -3, 23, 448, -1, "", 1);// 168
			AddComplexComponent( (BaseAddon) this, 5480, 1, -3, 2, 1, -1, "Bars", 1);// 169
			AddComplexComponent( (BaseAddon) this, 5481, 2, -3, 2, 1, -1, "Bars", 1);// 170
			AddComplexComponent( (BaseAddon) this, 4027, 0, -3, 7, 1153, -1, "", 1);// 190
			AddComplexComponent( (BaseAddon) this, 5092, -1, -1, 10, 1153, -1, "", 1);// 192
			AddComplexComponent( (BaseAddon) this, 5481, -1, -3, 3, 1, -1, "Bars", 1);// 194
			AddComplexComponent( (BaseAddon) this, 5480, -2, -3, 3, 1, -1, "Bars", 1);// 195
			AddComplexComponent( (BaseAddon) this, 41188, -1, 3, 6, 1153, -1, "", 1);// 198
			AddComplexComponent( (BaseAddon) this, 41188, -4, 3, 6, 1153, -1, "", 1);// 199
			AddComplexComponent( (BaseAddon) this, 41183, -1, 3, 2, 1153, -1, "", 1);// 203
			AddComplexComponent( (BaseAddon) this, 41183, -4, 3, 3, 1153, -1, "", 1);// 204
			AddComplexComponent( (BaseAddon) this, 8792, -1, -1, 9, 1102, -1, "", 1);// 207
			AddComplexComponent( (BaseAddon) this, 41588, -4, 1, 47, 0, -1, "Log Satchel", 1);// 208
			AddComplexComponent( (BaseAddon) this, 2842, -1, 2, 51, 0, 2, "", 1);// 209
			AddComplexComponent( (BaseAddon) this, 2842, 0, 0, 35, 0, 2, "", 1);// 242
			AddComplexComponent( (BaseAddon) this, 42289, 1, -3, 2, 0, 2, "", 1);// 288
			AddComplexComponent( (BaseAddon) this, 42289, -2, -3, 2, 0, 2, "", 1);// 289
			AddComplexComponent( (BaseAddon) this, 14736, -3, -4, 2, 0, 2, "", 1);// 298
			AddComplexComponent( (BaseAddon) this, 14736, -2, -4, 2, 0, 2, "", 1);// 301
			AddComplexComponent( (BaseAddon) this, 4862, -1, -5, 2, 0, 1, "", 1);// 303
			AddComplexComponent( (BaseAddon) this, 4862, 1, -5, 2, 0, 1, "", 1);// 375
			AddComplexComponent( (BaseAddon) this, 4862, 0, -4, 2, 0, 1, "", 1);// 376
			AddComplexComponent( (BaseAddon) this, 4862, -2, -5, 2, 0, 1, "", 1);// 377
			AddComplexComponent( (BaseAddon) this, 4862, -3, -4, 2, 0, 1, "", 1);// 378
			AddComplexComponent( (BaseAddon) this, 14736, -1, -4, 2, 0, 2, "", 1);// 409
			AddComplexComponent( (BaseAddon) this, 14736, 0, -4, 2, 0, 2, "", 1);// 429
			AddComplexComponent( (BaseAddon) this, 14736, 1, -4, 2, 0, 2, "", 1);// 439
			AddComplexComponent( (BaseAddon) this, 4012, -5, -1, 43, 0, 2, "", 1);// 458
			AddComplexComponent( (BaseAddon) this, 3555, -5, -1, 5, 0, 29, "", 1);// 459
			AddComplexComponent( (BaseAddon) this, 4850, -3, -5, 2, 0, 1, "", 1);// 461
			AddComplexComponent( (BaseAddon) this, 4850, -2, -4, 2, 0, 1, "", 1);// 462
			AddComplexComponent( (BaseAddon) this, 4850, 0, -5, 2, 0, 1, "", 1);// 463
			AddComplexComponent( (BaseAddon) this, 4012, -5, -1, 3, 0, 2, "", 1);// 466
			AddComplexComponent( (BaseAddon) this, 4012, -5, -1, 23, 0, 2, "", 1);// 505
			AddComplexComponent( (BaseAddon) this, 3555, -5, -1, 26, 0, 29, "", 1);// 512
			AddComplexComponent( (BaseAddon) this, 3555, -5, -1, 46, 0, 29, "", 1);// 538
			AddComplexComponent( (BaseAddon) this, 4850, 1, -4, 2, 0, 1, "", 1);// 667
			AddComplexComponent( (BaseAddon) this, 298, -6, -4, 22, 647, -1, "", 1);// 691
			AddComplexComponent( (BaseAddon) this, 41588, -4, -3, 28, 0, -1, "Log Satchel", 1);// 715

		}

		public SmithyTownhouseAddon( Serial serial ) : base( serial )
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

	public class SmithyTownhouseAddonDeed : BaseAddonDeed
	{
		public override BaseAddon Addon
		{
			get
			{
				return new SmithyTownhouseAddon();
			}
		}

		[Constructable]
		public SmithyTownhouseAddonDeed()
		{
			Name = "SmithyTownhouse";
		}

		public SmithyTownhouseAddonDeed( Serial serial ) : base( serial )
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