
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
	public class MediumFloatingIslandAddon : BaseAddon
	{
        private static int[,] m_AddOnSimpleComponents = new int[,] {
			  {3237, 3, 11, 7}, {3259, 5, 10, 7}, {3259, 6, 10, 6}// 1	2	3	
			, {3259, -2, 12, 6}, {3259, 2, 11, 6}, {3259, 1, 11, 6}// 4	5	6	
			, {3259, -1, 12, 7}, {3259, -3, 13, 6}, {6014, -3, 13, 5}// 7	8	9	
			, {6014, 0, 12, 5}, {6014, -1, 12, 5}, {6014, -2, 12, 6}// 10	11	12	
			, {6014, -3, 12, 5}, {6014, 3, 11, 5}, {6014, 2, 11, 5}// 13	14	15	
			, {6014, 1, 11, 5}, {6014, 0, 11, 5}, {6014, -1, 11, 5}// 16	17	18	
			, {6014, -2, 11, 5}, {6014, -3, 11, 5}, {6014, 6, 10, 5}// 19	20	21	
			, {6014, 5, 10, 5}, {6014, 4, 10, 5}, {6014, 3, 10, 5}// 22	23	24	
			, {6014, 2, 10, 5}, {6014, 1, 10, 5}, {6014, 0, 10, 5}// 25	26	27	
			, {6014, -1, 10, 5}, {6014, -2, 10, 5}, {6014, -3, 10, 5}// 28	29	30	
			, {3259, 11, -2, 5}, {3237, 12, 2, 5}, {3259, 12, 4, 5}// 41	42	43	
			, {3259, 11, 5, 5}, {3259, 11, 6, 5}, {3259, 8, 9, 5}// 44	45	46	
			, {3373, 7, 9, 7}, {3254, 7, 9, 8}, {3248, 8, 9, 8}// 47	48	49	
			, {3259, 9, 9, 5}, {3259, 10, 8, 7}, {3237, 11, 7, 6}// 50	51	52	
			, {3259, 12, 1, 7}, {3259, 12, 0, 6}, {3259, 11, -4, 6}// 53	54	55	
			, {3237, 11, -5, 7}, {40375, 7, 8, 5}, {3378, 8, 8, 9}// 56	58	59	
			, {3373, 10, -2, 7}, {40375, 10, -3, 5}, {3254, 10, -2, 8}// 61	62	63	
			, {3378, 11, -3, 9}, {3248, 11, -2, 8}, {6014, 12, 4, 5}// 64	65	66	
			, {6014, 12, 3, 5}, {6014, 12, 2, 5}, {6014, 12, 1, 5}// 67	68	69	
			, {6014, 12, 0, 5}, {6014, 11, 7, 5}, {6014, 11, 6, 5}// 70	71	72	
			, {6014, 11, 5, 5}, {6014, 11, 4, 5}, {6014, 11, 3, 5}// 73	74	75	
			, {6014, 11, 2, 5}, {6014, 11, 1, 5}, {6014, 11, 0, 5}// 76	77	78	
			, {6014, 11, -1, 5}, {6014, 11, -2, 5}, {6014, 11, -3, 5}// 79	80	81	
			, {6014, 11, -4, 5}, {6014, 11, -5, 5}, {6014, 9, 9, 5}// 82	83	84	
			, {6014, 8, 9, 5}, {6014, 7, 9, 5}, {6014, 6, 9, 5}// 85	86	87	
			, {6014, 5, 9, 5}, {6014, 4, 9, 5}, {6014, 3, 9, 5}// 88	89	90	
			, {6014, 2, 9, 5}, {6014, 1, 9, 5}, {6014, 0, 9, 5}// 91	92	93	
			, {6014, -1, 9, 5}, {6014, -2, 9, 5}, {6014, -3, 9, 5}// 94	95	96	
			, {6014, 10, 8, 5}, {6014, 10, 7, 5}, {6014, 10, 6, 5}// 97	98	99	
			, {6014, 10, 5, 5}, {6014, 10, 4, 5}, {6014, 10, 3, 5}// 100	101	102	
			, {6014, 10, 2, 5}, {6014, 10, 1, 5}, {6014, 10, 0, 5}// 103	104	105	
			, {6014, 10, -1, 5}, {6014, 10, -2, 5}, {6014, 10, -3, 5}// 106	107	108	
			, {6014, 10, -4, 5}, {6014, 10, -5, 5}, {6014, 10, -6, 5}// 109	110	111	
			, {6014, 9, 8, 5}, {6014, 9, 7, 5}, {6014, 9, 6, 5}// 112	113	114	
			, {6014, 9, 5, 5}, {6014, 9, 4, 5}, {6014, 9, 3, 5}// 115	116	117	
			, {6014, 9, 2, 5}, {6014, 9, 1, 5}, {6014, 9, 0, 5}// 118	119	120	
			, {6014, 9, -1, 5}, {6014, 9, -2, 5}, {6014, 9, -3, 5}// 121	122	123	
			, {6014, 9, -4, 5}, {6014, 9, -5, 5}, {6014, 9, -6, 5}// 124	125	126	
			, {6014, 8, 8, 5}, {6014, 8, 7, 5}, {6014, 8, 6, 5}// 127	128	129	
			, {6014, 8, 5, 5}, {6014, 8, 4, 5}, {6014, 8, 3, 5}// 130	131	132	
			, {6014, 8, 2, 5}, {6014, 8, 1, 5}, {6014, 8, 0, 5}// 133	134	135	
			, {6014, 8, -1, 5}, {6014, 8, -2, 5}, {6014, 8, -3, 5}// 136	137	138	
			, {6014, 8, -4, 5}, {6014, 8, -5, 5}, {6014, 8, -6, 5}// 139	140	141	
			, {6014, 7, 8, 5}, {6014, 7, 7, 5}, {6014, 7, 6, 5}// 142	143	144	
			, {6014, 7, 5, 5}, {6014, 7, 4, 5}, {6014, 7, 3, 5}// 145	146	147	
			, {6014, 7, 2, 5}, {6014, 7, 1, 5}, {6014, 7, 0, 5}// 148	149	150	
			, {6014, 7, -1, 5}, {6014, 7, -2, 5}, {6014, 7, -3, 5}// 151	152	153	
			, {6014, 7, -4, 5}, {6014, 7, -5, 5}, {6014, 7, -6, 5}// 154	155	156	
			, {6014, 6, 8, 5}, {6014, 6, 7, 5}, {6014, 6, 6, 5}// 157	158	159	
			, {6014, 6, 5, 5}, {6014, 6, 4, 5}, {6014, 6, 3, 5}// 160	161	162	
			, {6014, 6, 2, 5}, {6014, 6, 1, 5}, {6014, 6, 0, 5}// 163	164	165	
			, {6014, 6, -1, 5}, {6014, 6, -2, 5}, {6014, 6, -3, 5}// 166	167	168	
			, {6014, 6, -4, 5}, {6014, 6, -5, 5}, {6014, 6, -6, 5}// 169	170	171	
			, {6014, 5, 8, 5}, {6014, 5, 7, 5}, {6014, 5, 6, 5}// 172	173	174	
			, {6014, 5, 5, 5}, {6014, 5, 4, 5}, {6014, 5, 3, 5}// 175	176	177	
			, {6014, 5, 2, 5}, {6014, 5, 1, 5}, {6014, 5, 0, 5}// 178	179	180	
			, {6014, 5, -1, 5}, {6014, 5, -2, 5}, {6014, 5, -3, 5}// 181	182	183	
			, {6014, 5, -4, 5}, {6014, 5, -5, 5}, {6014, 5, -6, 5}// 184	185	186	
			, {6014, 4, 8, 5}, {6014, 4, 7, 5}, {6014, 4, 6, 5}// 187	188	189	
			, {6014, 4, 5, 5}, {6014, 4, 4, 5}, {6014, 4, 3, 5}// 190	191	192	
			, {6014, 4, 2, 5}, {6014, 4, 1, 5}, {6014, 4, 0, 5}// 193	194	195	
			, {6014, 4, -1, 5}, {6014, 4, -2, 5}, {6014, 4, -3, 5}// 196	197	198	
			, {6014, 4, -4, 5}, {6014, 4, -5, 5}, {6014, 4, -6, 5}// 199	200	201	
			, {6014, 3, 8, 5}, {6014, 3, 7, 5}, {6014, 3, 6, 5}// 202	203	204	
			, {6014, 3, 5, 5}, {6014, 3, 4, 5}, {6014, 3, 3, 5}// 205	206	207	
			, {6014, 3, 2, 5}, {6014, 3, 1, 5}, {6014, 3, 0, 5}// 208	209	210	
			, {6014, 3, -1, 5}, {6014, 3, -2, 5}, {6014, 3, -3, 5}// 211	212	213	
			, {6014, 3, -4, 5}, {6014, 3, -5, 5}, {6014, 3, -6, 5}// 214	215	216	
			, {6014, 2, 8, 5}, {6014, 2, 7, 5}, {6014, 2, 6, 5}// 217	218	219	
			, {6014, 2, 5, 5}, {6014, 2, 4, 5}, {6014, 2, 3, 5}// 220	221	222	
			, {6014, 2, 2, 5}, {6014, 2, 1, 5}, {6014, 2, 0, 5}// 223	224	225	
			, {6014, 2, -1, 5}, {6014, 2, -2, 5}, {6014, 2, -3, 5}// 226	227	228	
			, {6014, 2, -4, 5}, {6014, 2, -5, 5}, {6014, 2, -6, 5}// 229	230	231	
			, {6014, 1, 8, 5}, {6014, 1, 7, 5}, {6014, 1, 6, 5}// 232	233	234	
			, {6014, 1, 5, 5}, {6014, 1, 4, 5}, {6014, 1, 3, 5}// 235	236	237	
			, {6014, 1, 2, 5}, {6014, 1, 1, 5}, {6014, 1, 0, 5}// 238	239	240	
			, {6014, 1, -1, 5}, {6014, 1, -2, 5}, {6014, 1, -3, 5}// 241	242	243	
			, {6014, 1, -4, 5}, {6014, 1, -5, 5}, {6014, 1, -6, 5}// 244	245	246	
			, {6014, 0, 8, 5}, {6014, 0, 7, 5}, {6014, 0, 6, 5}// 247	248	249	
			, {6014, 0, 5, 5}, {6014, 0, 4, 5}, {6014, 0, 3, 5}// 250	251	252	
			, {6014, 0, 2, 5}, {6014, 0, 1, 5}, {6014, 0, 0, 5}// 253	254	255	
			, {6014, 0, -1, 5}, {6014, 0, -2, 5}, {6014, 0, -3, 5}// 256	257	258	
			, {6014, 0, -4, 5}, {6014, 0, -5, 5}, {6014, 0, -6, 5}// 259	260	261	
			, {6014, -1, 8, 5}, {6014, -1, 7, 5}, {6014, -1, 6, 5}// 262	263	264	
			, {6014, -1, 5, 5}, {6014, -1, 4, 5}, {6014, -1, 3, 5}// 265	266	267	
			, {6014, -1, 2, 5}, {6014, -1, 1, 5}, {6014, -1, 0, 5}// 268	269	270	
			, {6014, -1, -1, 5}, {6014, -1, -2, 5}, {6014, -1, -3, 5}// 271	272	273	
			, {6014, -1, -4, 5}, {6014, -1, -5, 5}, {6014, -1, -6, 5}// 274	275	276	
			, {6014, -2, 8, 5}, {6014, -2, 7, 5}, {6014, -2, 6, 5}// 277	278	279	
			, {6014, -2, 5, 5}, {6014, -2, 4, 5}, {6014, -2, 3, 5}// 280	281	282	
			, {6014, -2, 2, 5}, {6014, -2, 1, 5}, {6014, -2, 0, 5}// 283	284	285	
			, {6014, -2, -1, 5}, {6014, -2, -2, 5}, {6014, -2, -3, 5}// 286	287	288	
			, {6014, -2, -4, 5}, {6014, -2, -5, 5}, {6014, -2, -6, 5}// 289	290	291	
			, {6014, -3, 8, 5}, {6014, -3, 7, 5}, {6014, -3, 6, 5}// 292	293	294	
			, {6014, -3, 5, 5}, {6014, -3, 4, 5}, {6014, -3, 3, 5}// 295	296	297	
			, {6014, -3, 2, 5}, {6014, -3, 1, 5}, {6014, -3, 0, 5}// 298	299	300	
			, {6014, -3, -1, 5}, {6014, -3, -2, 5}, {6014, -3, -3, 5}// 301	302	303	
			, {6014, -3, -4, 5}, {6014, -3, -5, 5}, {6014, -3, -6, 5}// 304	305	306	
			, {1955, 10, -6, 0}, {1955, 11, -1, 0}, {3259, 10, -7, 5}// 307	312	325	
			, {3259, 10, -8, 5}, {3237, 9, -10, 5}, {3259, 9, -11, 5}// 326	327	328	
			, {3259, 8, -12, 5}, {3237, 7, -13, 5}, {3259, 6, -13, 5}// 329	330	331	
			, {3259, 4, -13, 5}, {3259, 3, -13, 5}, {3259, 2, -13, 5}// 332	333	334	
			, {3237, 2, -12, 5}, {3259, 1, -12, 5}, {3259, 0, -12, 5}// 335	336	337	
			, {3259, -2, -12, 5}, {3259, -3, -12, 5}, {3373, 5, -11, 7}// 338	339	341	
			, {40375, 5, -12, 5}, {3254, 5, -11, 8}, {3378, 6, -12, 9}// 342	343	344	
			, {3248, 6, -11, 8}, {6014, 2, -13, 5}, {6014, -3, -12, 5}// 345	346	347	
			, {6014, 9, -10, 5}, {6014, 9, -11, 5}, {6014, 8, -10, 5}// 348	349	350	
			, {6014, 8, -11, 5}, {6014, 8, -12, 5}, {6014, 7, -10, 5}// 351	352	353	
			, {6014, 7, -11, 5}, {6014, 7, -12, 5}, {6014, 7, -13, 5}// 354	355	356	
			, {6014, 6, -10, 5}, {6014, 6, -11, 5}, {6014, 6, -12, 5}// 357	358	359	
			, {6014, 6, -13, 5}, {6014, 5, -10, 5}, {6014, 5, -11, 5}// 360	361	362	
			, {6014, 5, -12, 5}, {6014, 5, -13, 5}, {6014, 4, -10, 5}// 363	364	365	
			, {6014, 4, -11, 5}, {6014, 4, -12, 5}, {6014, 4, -13, 5}// 366	367	368	
			, {6014, 3, -10, 5}, {6014, 3, -11, 5}, {6014, 3, -12, 5}// 369	370	371	
			, {6014, 3, -13, 5}, {6014, 2, -10, 5}, {6014, 2, -11, 5}// 372	373	374	
			, {6014, 2, -12, 5}, {6014, 1, -10, 5}, {6014, 1, -11, 5}// 375	376	377	
			, {6014, 1, -12, 5}, {6014, 0, -10, 5}, {6014, 0, -11, 5}// 378	379	380	
			, {6014, 0, -12, 5}, {6014, -1, -10, 5}, {6014, -1, -11, 5}// 381	382	383	
			, {6014, -1, -12, 5}, {6014, -2, -10, 5}, {6014, -2, -11, 5}// 384	385	386	
			, {6014, -2, -12, 5}, {6014, -3, -10, 5}, {6014, -3, -11, 5}// 387	388	389	
			, {6014, 10, -7, 5}, {6014, 10, -8, 5}, {6014, 9, -7, 5}// 390	391	392	
			, {6014, 9, -8, 5}, {6014, 9, -9, 5}, {6014, 8, -7, 5}// 393	394	395	
			, {6014, 8, -8, 5}, {6014, 8, -9, 5}, {6014, 7, -7, 5}// 396	397	398	
			, {6014, 7, -8, 5}, {6014, 7, -9, 5}, {6014, 6, -7, 5}// 399	400	401	
			, {6014, 6, -8, 5}, {6014, 6, -9, 5}, {6014, 5, -7, 5}// 402	403	404	
			, {6014, 5, -8, 5}, {6014, 5, -9, 5}, {6014, 4, -7, 5}// 405	406	407	
			, {6014, 4, -8, 5}, {6014, 4, -9, 5}, {6014, 3, -7, 5}// 408	409	410	
			, {6014, 3, -8, 5}, {6014, 3, -9, 5}, {6014, 2, -7, 5}// 411	412	413	
			, {6014, 2, -8, 5}, {6014, 2, -9, 5}, {6014, 1, -7, 5}// 414	415	416	
			, {6014, 1, -8, 5}, {6014, 1, -9, 5}, {6014, 0, -7, 5}// 417	418	419	
			, {6014, 0, -8, 5}, {6014, 0, -9, 5}, {6014, -1, -7, 5}// 420	421	422	
			, {6014, -1, -8, 5}, {6014, -1, -9, 5}, {6014, -2, -7, 5}// 423	424	425	
			, {6014, -2, -8, 5}, {6014, -2, -9, 5}, {6014, -3, -7, 5}// 426	427	428	
			, {6014, -3, -8, 5}, {6014, -3, -9, 5}, {1955, 0, -12, 0}// 429	430	431	
			, {1955, -1, -12, 0}, {1955, 1, -12, 0}, {1955, 2, -13, 0}// 432	433	434	
			, {1955, 3, -13, 0}, {1955, 5, -13, 0}, {1955, 4, -13, 0}// 435	436	437	
			, {1955, 6, -13, 0}, {1955, 7, -13, 0}, {1955, 8, -12, 0}// 438	439	440	
			, {1955, -2, -12, 0}, {1955, -3, -12, 0}, {1955, 9, -9, 0}// 441	442	445	
			, {3373, -7, 10, 7}, {3254, -7, 10, 8}, {3248, -6, 10, 8}// 448	449	450	
			, {3259, -4, 13, 5}, {3237, -5, 13, 7}, {3259, -7, 10, 6}// 451	452	453	
			, {3259, -6, 12, 6}, {6014, -4, 13, 5}, {6014, -5, 13, 5}// 454	455	456	
			, {6014, -4, 12, 5}, {6014, -5, 12, 5}, {6014, -6, 12, 5}// 457	458	459	
			, {6014, -4, 11, 5}, {6014, -5, 11, 5}, {6014, -6, 11, 5}// 460	461	462	
			, {6014, -4, 10, 5}, {6014, -5, 10, 5}, {6014, -6, 10, 5}// 463	464	465	
			, {6014, -7, 10, 5}, {1955, -6, 12, 0}, {1955, -6, 11, 0}// 466	469	470	
			, {40375, -9, -6, 5}, {3373, -9, -5, 7}, {3254, -9, -5, 8}// 472	474	475	
			, {3378, -8, -6, 9}, {3248, -8, -5, 8}, {3237, -8, 7, 5}// 476	477	478	
			, {3259, -8, 6, 5}, {3259, -9, 5, 5}, {3259, -9, 4, 5}// 479	480	481	
			, {3259, -10, 3, 5}, {3237, -10, 2, 5}, {3259, -11, 0, 5}// 482	483	484	
			, {3259, -11, -1, 5}, {3259, -11, -2, 5}, {3237, -11, -4, 5}// 485	486	487	
			, {3259, -10, -6, 5}, {3259, -11, -5, 5}, {3259, -8, 9, 6}// 488	489	490	
			, {40375, -7, 9, 5}, {3378, -6, 9, 9}, {3373, -9, -1, 7}// 492	493	495	
			, {40375, -9, -2, 5}, {3254, -9, -1, 8}, {3378, -8, -2, 9}// 496	497	498	
			, {3248, -8, -1, 8}, {6014, -4, 9, 5}, {6014, -5, 9, 5}// 499	500	501	
			, {6014, -6, 9, 5}, {6014, -7, 9, 5}, {6014, -8, 9, 5}// 502	503	504	
			, {6014, -11, 0, 5}, {6014, -11, -1, 5}, {6014, -11, -2, 5}// 505	506	507	
			, {6014, -11, -3, 5}, {6014, -11, -4, 5}, {6014, -11, -5, 5}// 508	509	510	
			, {6014, -10, 3, 5}, {6014, -10, 2, 5}, {6014, -10, 1, 5}// 511	512	513	
			, {6014, -10, 0, 5}, {6014, -10, -1, 5}, {6014, -10, -2, 5}// 514	515	516	
			, {6014, -10, -3, 5}, {6014, -10, -4, 5}, {6014, -10, -5, 5}// 517	518	519	
			, {6014, -10, -6, 5}, {6014, -9, 5, 5}, {6014, -9, 4, 5}// 520	521	522	
			, {6014, -9, 3, 5}, {6014, -9, 2, 5}, {6014, -9, 1, 5}// 523	524	525	
			, {6014, -9, 0, 5}, {6014, -9, -1, 5}, {6014, -9, -2, 5}// 526	527	528	
			, {6014, -9, -3, 5}, {6014, -9, -4, 5}, {6014, -9, -5, 5}// 529	530	531	
			, {6014, -9, -6, 5}, {6014, -4, 8, 5}, {6014, -4, 7, 5}// 532	533	534	
			, {6014, -4, 6, 5}, {6014, -4, 5, 5}, {6014, -4, 4, 5}// 535	536	537	
			, {6014, -4, 3, 5}, {6014, -4, 2, 5}, {6014, -4, 1, 5}// 538	539	540	
			, {6014, -4, 0, 5}, {6014, -4, -1, 5}, {6014, -4, -2, 5}// 541	542	543	
			, {6014, -4, -3, 5}, {6014, -4, -4, 5}, {6014, -4, -5, 5}// 544	545	546	
			, {6014, -4, -6, 5}, {6014, -5, 8, 5}, {6014, -5, 7, 5}// 547	548	549	
			, {6014, -5, 6, 5}, {6014, -5, 5, 5}, {6014, -5, 4, 5}// 550	551	552	
			, {6014, -5, 3, 5}, {6014, -5, 2, 5}, {6014, -5, 1, 5}// 553	554	555	
			, {6014, -5, 0, 5}, {6014, -5, -1, 5}, {6014, -5, -2, 5}// 556	557	558	
			, {6014, -5, -3, 5}, {6014, -5, -4, 5}, {6014, -5, -5, 5}// 559	560	561	
			, {6014, -5, -6, 5}, {6014, -6, 8, 5}, {6014, -6, 7, 5}// 562	563	564	
			, {6014, -6, 6, 5}, {6014, -6, 5, 5}, {6014, -6, 4, 5}// 565	566	567	
			, {6014, -6, 3, 5}, {6014, -6, 2, 5}, {6014, -6, 1, 5}// 568	569	570	
			, {6014, -6, 0, 5}, {6014, -6, -1, 5}, {6014, -6, -2, 5}// 571	572	573	
			, {6014, -6, -3, 5}, {6014, -6, -4, 5}, {6014, -6, -5, 5}// 574	575	576	
			, {6014, -6, -6, 5}, {6014, -7, 8, 5}, {6014, -7, 7, 5}// 577	578	579	
			, {6014, -7, 6, 5}, {6014, -7, 5, 5}, {6014, -7, 4, 5}// 580	581	582	
			, {6014, -7, 3, 5}, {6014, -7, 2, 5}, {6014, -7, 1, 5}// 583	584	585	
			, {6014, -7, 0, 5}, {6014, -7, -1, 5}, {6014, -7, -2, 5}// 586	587	588	
			, {6014, -7, -3, 5}, {6014, -7, -4, 5}, {6014, -7, -5, 5}// 589	590	591	
			, {6014, -7, -6, 5}, {6014, -8, 8, 5}, {6014, -8, 7, 5}// 592	593	594	
			, {6014, -8, 6, 5}, {6014, -8, 5, 5}, {6014, -8, 4, 5}// 595	596	597	
			, {6014, -8, 3, 5}, {6014, -8, 2, 5}, {6014, -8, 1, 5}// 598	599	600	
			, {6014, -8, 0, 5}, {6014, -8, -1, 5}, {6014, -8, -2, 5}// 601	602	603	
			, {6014, -8, -3, 5}, {6014, -8, -4, 5}, {6014, -8, -5, 5}// 604	605	606	
			, {6014, -8, -6, 5}, {1955, -8, 9, 0}, {1955, -8, 8, 0}// 607	608	609	
			, {1955, -8, 7, 0}, {1955, -8, 6, 0}, {1955, -9, 5, 0}// 610	611	612	
			, {1955, -9, 4, 0}, {1955, -10, 3, 0}, {1955, -10, 2, 0}// 613	614	615	
			, {1955, -10, 1, 0}, {1955, -11, 0, 0}, {1955, -11, -1, 0}// 616	617	618	
			, {1955, -11, -2, 0}, {1955, -11, -3, 0}, {1955, -11, -4, 0}// 619	620	621	
			, {1955, -11, -5, 0}, {1955, -10, -6, 0}, {40375, -5, -10, 5}// 622	623	624	
			, {3373, -5, -9, 7}, {3254, -5, -9, 8}, {3378, -4, -10, 9}// 626	627	628	
			, {3248, -4, -9, 8}, {3237, -4, -11, 5}, {3259, -5, -11, 5}// 629	630	631	
			, {3259, -6, -10, 5}, {3259, -7, -10, 5}, {3237, -8, -9, 5}// 632	633	634	
			, {3259, -9, -8, 5}, {3259, -9, -7, 5}, {6014, -9, -8, 5}// 635	636	637	
			, {6014, -5, -11, 5}, {6014, -7, -10, 5}, {6014, -8, -9, 5}// 638	639	640	
			, {6014, -9, -7, 5}, {6014, -4, -10, 5}, {6014, -4, -11, 5}// 641	642	643	
			, {6014, -5, -10, 5}, {6014, -6, -10, 5}, {6014, -4, -7, 5}// 644	645	646	
			, {6014, -4, -8, 5}, {6014, -4, -9, 5}, {6014, -5, -7, 5}// 647	648	649	
			, {6014, -5, -8, 5}, {6014, -5, -9, 5}, {6014, -6, -7, 5}// 650	651	652	
			, {6014, -6, -8, 5}, {6014, -6, -9, 5}, {6014, -7, -7, 5}// 653	654	655	
			, {6014, -7, -8, 5}, {6014, -7, -9, 5}, {6014, -8, -7, 5}// 656	657	658	
			, {6014, -8, -8, 5}, {1955, -4, -11, 0}, {1955, -5, -11, 0}// 659	660	661	
			, {1955, -6, -10, 0}, {1955, -7, -10, 0}, {1955, -9, -7, 0}// 662	663	664	
			, {1955, -9, -8, 0}, {1955, -8, -9, 0}// 665	666	
		};

 
            
		public override BaseAddonDeed Deed
		{
			get
			{
				return new MediumFloatingIslandAddonDeed();
			}
		}

		[ Constructable ]
		public MediumFloatingIslandAddon()
		{

            for (int i = 0; i < m_AddOnSimpleComponents.Length / 4; i++)
                AddComponent( new AddonComponent( m_AddOnSimpleComponents[i,0] ), m_AddOnSimpleComponents[i,1], m_AddOnSimpleComponents[i,2], m_AddOnSimpleComponents[i,3] );


			AddComplexComponent( (BaseAddon) this, 1955, 6, 10, 0, 2418, -1, "", 1);// 31
			AddComplexComponent( (BaseAddon) this, 1955, 5, 10, 0, 2418, -1, "", 1);// 32
			AddComplexComponent( (BaseAddon) this, 1955, 4, 10, 0, 2418, -1, "", 1);// 33
			AddComplexComponent( (BaseAddon) this, 1955, 3, 11, 0, 2418, -1, "", 1);// 34
			AddComplexComponent( (BaseAddon) this, 1955, 1, 11, 0, 2418, -1, "", 1);// 35
			AddComplexComponent( (BaseAddon) this, 1955, 2, 11, 0, 2418, -1, "", 1);// 36
			AddComplexComponent( (BaseAddon) this, 1955, 0, 12, 0, 2418, -1, "", 1);// 37
			AddComplexComponent( (BaseAddon) this, 1955, -1, 12, 0, 2418, -1, "", 1);// 38
			AddComplexComponent( (BaseAddon) this, 1955, -2, 12, 0, 2418, -1, "", 1);// 39
			AddComplexComponent( (BaseAddon) this, 1955, -3, 13, 0, 2418, -1, "", 1);// 40
			AddComplexComponent( (BaseAddon) this, 12590, 8, 8, 6, 0, -1, "Pine Cone", 1);// 57
			AddComplexComponent( (BaseAddon) this, 12590, 11, -3, 6, 0, -1, "Pine Cone", 1);// 60
			AddComplexComponent( (BaseAddon) this, 1955, 11, -5, 0, 2418, -1, "", 1);// 308
			AddComplexComponent( (BaseAddon) this, 1955, 11, -3, 0, 2418, -1, "", 1);// 309
			AddComplexComponent( (BaseAddon) this, 1955, 11, -4, 0, 2418, -1, "", 1);// 310
			AddComplexComponent( (BaseAddon) this, 1955, 11, -2, 0, 2418, -1, "", 1);// 311
			AddComplexComponent( (BaseAddon) this, 1955, 12, 0, 0, 2418, -1, "", 1);// 313
			AddComplexComponent( (BaseAddon) this, 1955, 12, 1, 0, 2418, -1, "", 1);// 314
			AddComplexComponent( (BaseAddon) this, 1955, 12, 2, 0, 2418, -1, "", 1);// 315
			AddComplexComponent( (BaseAddon) this, 1955, 12, 3, 0, 2418, -1, "", 1);// 316
			AddComplexComponent( (BaseAddon) this, 1955, 12, 4, 0, 2418, -1, "", 1);// 317
			AddComplexComponent( (BaseAddon) this, 1955, 11, 5, 0, 2418, -1, "", 1);// 318
			AddComplexComponent( (BaseAddon) this, 1955, 11, 6, 0, 2418, -1, "", 1);// 319
			AddComplexComponent( (BaseAddon) this, 1955, 11, 7, 0, 2418, -1, "", 1);// 320
			AddComplexComponent( (BaseAddon) this, 1955, 10, 8, 0, 2418, -1, "", 1);// 321
			AddComplexComponent( (BaseAddon) this, 1955, 9, 9, 0, 2418, -1, "", 1);// 322
			AddComplexComponent( (BaseAddon) this, 1955, 8, 9, 0, 2418, -1, "", 1);// 323
			AddComplexComponent( (BaseAddon) this, 1955, 7, 9, 0, 2418, -1, "", 1);// 324
			AddComplexComponent( (BaseAddon) this, 12590, 6, -12, 6, 2418, -1, "Pine Cone", 1);// 340
			AddComplexComponent( (BaseAddon) this, 1955, 9, -11, 0, 2418, -1, "", 1);// 443
			AddComplexComponent( (BaseAddon) this, 1955, 9, -10, 0, 2418, -1, "", 1);// 444
			AddComplexComponent( (BaseAddon) this, 1955, 10, -7, 0, 2418, -1, "", 1);// 446
			AddComplexComponent( (BaseAddon) this, 1955, 10, -8, 0, 2418, -1, "", 1);// 447
			AddComplexComponent( (BaseAddon) this, 1955, -4, 13, 0, 2418, -1, "", 1);// 467
			AddComplexComponent( (BaseAddon) this, 1955, -5, 13, 0, 2418, -1, "", 1);// 468
			AddComplexComponent( (BaseAddon) this, 1955, -7, 10, 0, 2418, -1, "", 1);// 471
			AddComplexComponent( (BaseAddon) this, 12590, -8, -6, 6, 2418, -1, "Pine Cone", 1);// 473
			AddComplexComponent( (BaseAddon) this, 12590, -6, 9, 6, 2418, -1, "Pine Cone", 1);// 491
			AddComplexComponent( (BaseAddon) this, 12590, -8, -2, 6, 2418, -1, "Pine Cone", 1);// 494
			AddComplexComponent( (BaseAddon) this, 12590, -4, -10, 6, 2418, -1, "Pine Cone", 1);// 625

		}

		public MediumFloatingIslandAddon( Serial serial ) : base( serial )
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

	public class MediumFloatingIslandAddonDeed : BaseAddonDeed
	{
		public override BaseAddon Addon
		{
			get
			{
				return new MediumFloatingIslandAddon();
			}
		}

		[Constructable]
		public MediumFloatingIslandAddonDeed()
		{
			Name = "MediumFloatingIsland";
		}

		public MediumFloatingIslandAddonDeed( Serial serial ) : base( serial )
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