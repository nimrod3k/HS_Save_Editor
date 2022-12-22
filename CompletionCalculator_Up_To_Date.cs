using System;
using HS.Maps;
using HS.Objects;

namespace HS.Utils
{
	// Token: 0x02000013 RID: 19
	public static class CompletionCalculator
	{
		// Token: 0x0600007D RID: 125 RVA: 0x00008088 File Offset: 0x00006288
		public static int Calculate(bool convergence, bool greenfight, bool skip)
		{
			int result;
			if (convergence)
			{
				result = CompletionCalculator.GetConvergenceCompletion();
			}
			else
			{
				float num = 0f;
				if (greenfight)
				{
					num += (float)(skip ? 0 : 50);
					num += (float)(GameData.Get(9) * 2);
					num += (float)(GameData.Get(8) * 3);
					num += (float)(GameData.Get(18) * 2);
					num += (float)(GameData.Get(16) * 2);
					num += (float)(GameData.Get(17) * 2);
					num += (float)(GameData.Get(16) - GameData.Get(13));
					num += (float)((GameData.Get(17) - GameData.Get(14)) * 2);
					bool flag = GameData.Get(21) > 0;
					if (flag)
					{
						num += 15f;
					}
					bool flag2 = GameData.Get(19) > 0;
					if (flag2)
					{
						num += 15f;
					}
					bool flag3 = GameData.Get(58) > 0;
					if (flag3)
					{
						num += 15f;
					}
					bool flag4 = GameData.Get(51) > 0;
					if (flag4)
					{
						num += 25f;
					}
					bool flag5 = GameData.Get(61) > 0;
					if (flag5)
					{
						num += 25f;
					}
					bool flag6 = GameData.Get(20) > 0;
					if (flag6)
					{
						num += 15f;
					}
					bool flag7 = GameData.Get(55) > 0;
					if (flag7)
					{
						num += 20f;
					}
					bool flag8 = GameData.Get(59) > 0;
					if (flag8)
					{
						num += 20f;
					}
					num += (float)(GameData.Get(9) - GameData.Get(3));
					num += (float)(GameData.Get(8) - GameData.Get(2));
				}
				else
				{
					num += (float)(GameData.Get(111) * 2);
					num += (float)(GameData.Get(112) * 3);
					num += (float)(GameData.Get(108) * 2);
					num += (float)(GameData.Get(110) * 2);
					num += (float)(GameData.Get(109) * 2);
					num += (float)(GameData.Get(110) - GameData.Get(105));
					num += (float)((GameData.Get(109) - GameData.Get(104)) * 2);
					bool flag9 = GameData.Get(90) > 0;
					if (flag9)
					{
						num += 15f;
					}
					bool flag10 = GameData.Get(88) > 0;
					if (flag10)
					{
						num += 15f;
					}
					bool flag11 = GameData.Get(79) > 0;
					if (flag11)
					{
						num += 15f;
					}
					bool flag12 = GameData.Get(77) > 0;
					if (flag12)
					{
						num += 25f;
					}
					bool flag13 = GameData.Get(78) > 0;
					if (flag13)
					{
						num += 25f;
					}
					bool flag14 = GameData.Get(82) > 0;
					if (flag14)
					{
						num += 15f;
					}
					bool flag15 = GameData.Get(80) > 0;
					if (flag15)
					{
						num += 20f;
					}
					bool flag16 = GameData.Get(81) > 0;
					if (flag16)
					{
						num += 20f;
					}
					num += (float)(GameData.Get(111) - GameData.Get(106));
					num += (float)(GameData.Get(112) - GameData.Get(107));
				}
				num += (float)(GameData.Get(121) * 4);
				num += (float)(GameData.Get(122) * 4);
				num += (float)(GameData.Get(114) * 2);
				num += (float)(GameData.Get(113) * 3);
				num += (float)(GameData.Get(115) * 4);
				num += (float)(GameData.Get(116) * 4);
				num += (float)(GameData.Get(34) * 2);
				bool flag17 = GameData.Get(131) > 0;
				if (flag17)
				{
					num += 5f;
				}
				bool flag18 = GameData.Get(132) > 0;
				if (flag18)
				{
					num += 5f;
				}
				bool flag19 = GameData.Get(133) > 0;
				if (flag19)
				{
					num += 5f;
				}
				bool flag20 = GameData.Get(134) > 0;
				if (flag20)
				{
					num += 5f;
				}
				bool flag21 = GameData.Get(135) > 0;
				if (flag21)
				{
					num += 5f;
				}
				bool flag22 = GameData.Get(136) > 0;
				if (flag22)
				{
					num += 5f;
				}
				bool flag23 = GameData.Get(137) > 0;
				if (flag23)
				{
					num += 10f;
				}
				bool flag24 = GameData.Get(138) > 0;
				if (flag24)
				{
					num += 10f;
				}
				bool flag25 = GameData.Get(139) > 0;
				if (flag25)
				{
					num += 10f;
				}
				bool flag26 = GameData.Get(123) > 0;
				if (flag26)
				{
					num += 15f;
				}
				bool flag27 = GameData.Get(124) > 0;
				if (flag27)
				{
					num += 25f;
				}
				bool flag28 = GameData.Get(125) > 0;
				if (flag28)
				{
					num += 35f;
				}
				bool flag29 = GameData.Get(63) > 1;
				if (flag29)
				{
					num += 25f;
				}
				bool flag30 = GameData.Get(28) > 0;
				if (flag30)
				{
					num += 25f;
				}
				bool flag31 = GameData.Get(75) > 0;
				if (flag31)
				{
					num += 25f;
				}
				bool flag32 = GameData.Get(126) > 0;
				if (flag32)
				{
					num += 5f;
				}
				bool flag33 = GameData.Get(10) > 0;
				if (flag33)
				{
					num += 10f;
				}
				bool flag34 = GameData.Get(11) > 0;
				if (flag34)
				{
					num += 10f;
				}
				bool flag35 = GameData.Get(12) > 0;
				if (flag35)
				{
					num += 25f;
				}
				bool flag36 = GameData.Get(117) > 0;
				if (flag36)
				{
					num += 20f;
				}
				bool flag37 = GameData.Get(118) > 0;
				if (flag37)
				{
					num += 20f;
				}
				bool flag38 = GameData.Get(119) > 0;
				if (flag38)
				{
					num += 50f;
				}
				bool flag39 = GameData.Get(73) > 0;
				if (flag39)
				{
					num += 50f;
				}
				bool flag40 = GameData.Get(89) > 0 || GameData.Get(127) > 0;
				if (flag40)
				{
					num += 25f;
				}
				num += (float)((GameData.Get(121) - GameData.Get(86)) * 2);
				num += (float)((GameData.Get(122) - GameData.Get(85)) * 2);
				num += (float)(GameData.Get(72) * 15);
				bool flag41 = GameData.Get(91) > 0;
				if (flag41)
				{
					num += 25f;
				}
				bool flag42 = GameData.Get(92) > 0;
				if (flag42)
				{
					num += 25f;
				}
				bool flag43 = GameData.Get(93) > 0;
				if (flag43)
				{
					num += 25f;
				}
				bool flag44 = GameData.Get(94) > 0;
				if (flag44)
				{
					num += 25f;
				}
				bool flag45 = GameData.Get(95) > 0;
				if (flag45)
				{
					num += 25f;
				}
				bool flag46 = GameData.Get(96) > 0;
				if (flag46)
				{
					num += 25f;
				}
				bool flag47 = GameData.Get(97) > 0;
				if (flag47)
				{
					num += 25f;
				}
				bool flag48 = GameData.Get(98) > 0;
				if (flag48)
				{
					num += 25f;
				}
				bool flag49 = GameData.Get(24) > 0;
				if (flag49)
				{
					num += 25f;
				}
				bool flag50 = GameData.Get(31) > 0;
				if (flag50)
				{
					num += 15f;
				}
				bool flag51 = GameData.Get(32) > 0;
				if (flag51)
				{
					num += 15f;
				}
				bool flag52 = GameData.Get(140) > 0;
				if (flag52)
				{
					num += 35f;
				}
				bool flag53 = GameData.Get(141) > 0;
				if (flag53)
				{
					num += 30f;
				}
				bool flag54 = GameData.Get(142) > 0;
				if (flag54)
				{
					num += 10f;
				}
				bool flag55 = GameData.Get(143) > 0;
				if (flag55)
				{
					num += 10f;
				}
				bool flag56 = GameData.Get(25) > 0;
				if (flag56)
				{
					num += 100f;
					bool flag57 = GameData.Get(26) <= 0;
					if (flag57)
					{
						num += 25f;
					}
				}
				bool flag58 = GameData.Get(146) > 0;
				if (flag58)
				{
					num += 100f;
				}
				bool flag59 = GameData.Get(147) > 0;
				if (flag59)
				{
					num += 100f;
				}
				bool flag60 = GameData.Get(150) > 0;
				if (flag60)
				{
					num += 25f;
				}
				bool flag61 = GameData.Get(144) > 0;
				if (flag61)
				{
					num += 61f;
				}
				bool flag62 = GameData.Get(149) > 0;
				if (flag62)
				{
					num += 911f;
				}
				bool flag63 = CompletionCalculator.AllIcons(greenfight);
				if (flag63)
				{
					num += 32f;
				}
				if (greenfight)
				{
					num += (float)(GameData.Get(151) * 25);
					num += (float)((GameData.Get(151) - GameData.Get(145)) * 25);
					num += (float)(GameData.Get(120) * 100);
					num += (float)((GameData.Get(120) - GameData.Get(36)) * 25);
				}
				else
				{
					num += (float)(GameData.Get(182) * 25);
					num += (float)((GameData.Get(182) - GameData.Get(180)) * 25);
					num += (float)(GameData.Get(183) * 100);
					num += (float)((GameData.Get(183) - GameData.Get(181)) * 25);
				}
				float num2 = 36.89f;
				float num3 = num2 / 100f;
				if (greenfight)
				{
					bool flag64 = GameData.Get(155) >= 127;
					if (flag64)
					{
						num += num2;
					}
					bool flag65 = GameData.Get(155) >= byte.MaxValue;
					if (flag65)
					{
						num += num2;
					}
					bool flag66 = GameData.Get(162) > 0;
					if (flag66)
					{
						num += num2 * 2f;
					}
					bool flag67 = GameData.Get(158) > 0;
					if (flag67)
					{
						num += num2 * 3f;
					}
					bool flag68 = GameData.Get(166) > 0;
					if (flag68)
					{
						num += num2 * 2f;
					}
					bool flag69 = GameData.Get(160) > 0;
					if (flag69)
					{
						num += num2 * 3f;
					}
				}
				else
				{
					bool flag70 = GameData.Get(156) >= 127;
					if (flag70)
					{
						num += num2 * 3f;
					}
					bool flag71 = GameData.Get(156) >= byte.MaxValue;
					if (flag71)
					{
						num += num2 * 3f;
					}
					bool flag72 = GameData.Get(163) > 0;
					if (flag72)
					{
						num += num2 * 2f;
					}
					bool flag73 = GameData.Get(159) > 0;
					if (flag73)
					{
						num += num2;
					}
					bool flag74 = GameData.Get(167) > 0;
					if (flag74)
					{
						num += num2;
					}
					bool flag75 = GameData.Get(161) > 0;
					if (flag75)
					{
						num += num2 * 3f;
					}
				}
				bool flag76 = GameData.Get(168) > 0;
				if (flag76)
				{
					num -= num2;
				}
				bool flag77 = GameData.Get(164) > 0;
				if (flag77)
				{
					num += num2 * 4f;
				}
				bool flag78 = GameData.Get(174) > 0;
				if (flag78)
				{
					num += num2 * 3f;
					num += (float)Math.Min(100, GameData.Get(175)) * (num3 * 4f);
					num += 5f;
				}
				bool flag79 = GameData.Get(144) == 0 && GameData.Get(149) == 0 && GameData.Get(54) > 0;
				if (flag79)
				{
					num += num2;
				}
				bool flag80 = GameData.Get(170) > 0;
				if (flag80)
				{
					num += num2 * 2f;
				}
				bool flag81 = GameData.Get(171) > 0;
				if (flag81)
				{
					num += num2 * 2f;
				}
				bool flag82 = GameData.Get(186) > 0;
				if (flag82)
				{
					num += num2;
				}
				result = (int)Math.Floor((double)(0.027107617f * num));
			}
			return result;
		}

		// Token: 0x0600007E RID: 126 RVA: 0x00008BE8 File Offset: 0x00006DE8
		public static bool AllIcons(bool greenfight)
		{
			bool flag = GameData.Get(147) == 0 && GameData.Get(61) == 0 && GameData.Get(60) == 0;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				bool flag2 = GameData.Get(89) == 0 && GameData.Get(20) == 0;
				if (flag2)
				{
					result = false;
				}
				else
				{
					bool flag3 = GameData.Get(57) == 0;
					if (flag3)
					{
						result = false;
					}
					else
					{
						bool flag4 = GameData.Get(59) == 0;
						if (flag4)
						{
							result = false;
						}
						else
						{
							bool flag5 = GameData.Get(55) == 0;
							if (flag5)
							{
								result = false;
							}
							else
							{
								bool flag6 = GameData.Get(21) == 0;
								if (flag6)
								{
									result = false;
								}
								else
								{
									bool flag7 = GameData.Get(19) == 0;
									if (flag7)
									{
										result = false;
									}
									else
									{
										bool flag8 = GameData.Get(58) == 0;
										if (flag8)
										{
											result = false;
										}
										else
										{
											if (greenfight)
											{
												bool flag9 = GameData.Get(16) - GameData.Get(13) <= 99;
												if (flag9)
												{
													return false;
												}
												bool flag10 = GameData.Get(17) - GameData.Get(14) <= 98;
												if (flag10)
												{
													return false;
												}
												bool flag11 = GameData.Get(18) <= 250;
												if (flag11)
												{
													return false;
												}
											}
											else
											{
												bool flag12 = GameData.Get(110) - GameData.Get(105) <= 99;
												if (flag12)
												{
													return false;
												}
												bool flag13 = GameData.Get(109) - GameData.Get(104) <= 98;
												if (flag13)
												{
													return false;
												}
												bool flag14 = GameData.Get(108) <= 250;
												if (flag14)
												{
													return false;
												}
											}
											bool flag15 = GameData.Get(114) <= 98;
											if (flag15)
											{
												result = false;
											}
											else
											{
												bool flag16 = GameData.Get(113) <= 98;
												if (flag16)
												{
													result = false;
												}
												else
												{
													bool flag17 = GameData.Get(115) <= 12;
													if (flag17)
													{
														result = false;
													}
													else
													{
														bool flag18 = GameData.Get(116) <= 12;
														if (flag18)
														{
															result = false;
														}
														else
														{
															bool flag19 = GameData.Get(0) <= 49;
															if (flag19)
															{
																result = false;
															}
															else
															{
																bool flag20 = GameData.Get(117) == 0;
																if (flag20)
																{
																	result = false;
																}
																else
																{
																	bool flag21 = GameData.Get(118) == 0;
																	if (flag21)
																	{
																		result = false;
																	}
																	else
																	{
																		bool flag22 = GameData.Get(119) == 0;
																		if (flag22)
																		{
																			result = false;
																		}
																		else
																		{
																			bool flag23 = greenfight && GameData.Get(120) == 0;
																			if (flag23)
																			{
																				result = false;
																			}
																			else
																			{
																				bool flag24 = GameData.Get(183) == 0;
																				if (flag24)
																				{
																					result = false;
																				}
																				else
																				{
																					bool flag25 = GameData.Get(25) == 0;
																					if (flag25)
																					{
																						result = false;
																					}
																					else
																					{
																						bool flag26 = GameData.Get(54) == 0;
																						result = !flag26;
																					}
																				}
																			}
																		}
																	}
																}
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
			return result;
		}

		// Token: 0x0600007F RID: 127 RVA: 0x00008EC4 File Offset: 0x000070C4
		internal static int GetConvergenceCompletion()
		{
			float num = 1590f;
			num += (float)CompletionCalculator.GetPoints(Map.ConvergenceManager.Save1);
			num += (float)CompletionCalculator.GetPoints(Map.ConvergenceManager.Save2);
			num += (float)CompletionCalculator.GetPoints(Map.ConvergenceManager.Save3);
			return (int)Math.Floor((double)(0.027107617f * num));
		}

		// Token: 0x06000080 RID: 128 RVA: 0x00008F24 File Offset: 0x00007124
		internal static int GetPoints(CMSaveData cmd)
		{
			float num = 0f;
			num += (float)(cmd.GetVar(Vars.TOTAL_SILVER_KEYS) * 2);
			num += (float)(cmd.GetVar(Vars.TOTAL_GOLD_KEYS) * 3);
			num += (float)(cmd.GetVar(Vars.TOTAL_TREASURES) * 2);
			num += (float)(cmd.GetVar(Vars.TOTAL_PORTAL_STONES) * 2);
			num += (float)(cmd.GetVar(Vars.TOTAL_GEMS) * 2);
			num += (float)(cmd.GetVar(Vars.TOTAL_PORTAL_STONES) - cmd.GetVar(Vars.PORTAL_STONES));
			num += (float)((cmd.GetVar(Vars.TOTAL_GEMS) - cmd.GetVar(Vars.GEMS)) * 2);
			bool flag = cmd.GetVar(Vars.COMPASSES) > 0;
			if (flag)
			{
				num += 15f;
			}
			bool flag2 = cmd.GetVar(Vars.HAMMERS) > 0;
			if (flag2)
			{
				num += 15f;
			}
			bool flag3 = cmd.GetVar(Vars.SKELETON_KEY) > 0;
			if (flag3)
			{
				num += 15f;
			}
			bool flag4 = cmd.GetVar(Vars.GEM_SWORD) > 0;
			if (flag4)
			{
				num += 25f;
			}
			bool flag5 = cmd.GetVar(Vars.GEM_SHIELD) > 0;
			if (flag5)
			{
				num += 25f;
			}
			bool flag6 = cmd.GetVar(Vars.BOOTS) > 0;
			if (flag6)
			{
				num += 15f;
			}
			bool flag7 = cmd.GetVar(Vars.LAVA_CHARMS) > 0;
			if (flag7)
			{
				num += 20f;
			}
			bool flag8 = cmd.GetVar(Vars.WATER_RING) > 0;
			if (flag8)
			{
				num += 20f;
			}
			num += (float)(cmd.GetVar(Vars.TOTAL_SILVER_KEYS) - cmd.GetVar(Vars.SILVER_KEYS));
			num += (float)(cmd.GetVar(Vars.TOTAL_GOLD_KEYS) - cmd.GetVar(Vars.GOLD_KEYS));
			num += (float)((cmd.GetVar(Vars.TOTAL_TEAL_KEYS) + 8) * 4);
			num += (float)((cmd.GetVar(Vars.TOTAL_PURPLE_KEYS) + 8) * 4);
			num += (float)(cmd.GetVar(Vars.TOTAL_SILVER_DOORS) * 2);
			num += (float)(cmd.GetVar(Vars.TOTAL_GOLD_DOORS) * 3);
			num += (float)((cmd.GetVar(Vars.TOTAL_TEAL_DOORS) + 8) * 4);
			num += (float)((cmd.GetVar(Vars.TOTAL_PURPLE_DOORS) + 8) * 4);
			num += (float)(cmd.GetVar(Vars.DRAGON_TREASURE) * 2);
			num += 60f;
			num += 75f;
			bool flag9 = cmd.GetVar(Vars.SNAKE_BOSS_DEFEATED) > 1;
			if (flag9)
			{
				num += 25f;
			}
			bool flag10 = cmd.GetVar(Vars.BOSS_REACHED) > 0;
			if (flag10)
			{
				num += 25f;
			}
			bool flag11 = cmd.GetVar(Vars.DRAGON_KILLED) > 0;
			if (flag11)
			{
				num += 25f;
			}
			bool flag12 = cmd.GetVar(Vars.BUNNY_CRIME_SCENE) > 0;
			if (flag12)
			{
				num += 5f;
			}
			bool flag13 = cmd.GetVar(Vars.TOTAL_RED_KEYS) > 0;
			if (flag13)
			{
				num += 10f;
			}
			bool flag14 = cmd.GetVar(Vars.TOTAL_BLUE_KEYS) > 0;
			if (flag14)
			{
				num += 10f;
			}
			bool flag15 = cmd.GetVar(Vars.TOTAL_GREEN_KEYS) > 0;
			if (flag15)
			{
				num += 25f;
			}
			bool flag16 = cmd.GetVar(Vars.TOTAL_RED_DOORS) > 0;
			if (flag16)
			{
				num += 20f;
			}
			bool flag17 = cmd.GetVar(Vars.TOTAL_BLUE_DOORS) > 0;
			if (flag17)
			{
				num += 20f;
			}
			bool flag18 = cmd.GetVar(Vars.TOTAL_GREEN_DOORS) > 0;
			if (flag18)
			{
				num += 50f;
			}
			bool flag19 = cmd.GetVar(Vars.GEM_HEART) > 0;
			if (flag19)
			{
				num += 50f;
			}
			bool flag20 = cmd.GetVar(Vars.GEM_BOOTS) > 0 || cmd.GetVar(Vars.BACKUP_GEM_BOOTS) > 0;
			if (flag20)
			{
				num += 25f;
			}
			num += (float)(cmd.GetVar(Vars.TOTAL_TOKENS) * 100);
			num += (float)((cmd.GetVar(Vars.TOTAL_TOKENS) - cmd.GetVar(Vars.SECRET_TOKENS)) * 25);
			num += (float)((cmd.GetVar(Vars.TOTAL_TEAL_KEYS) - cmd.GetVar(Vars.TEAL_KEYS) + 8) * 2);
			num += (float)((cmd.GetVar(Vars.TOTAL_PURPLE_KEYS) - cmd.GetVar(Vars.PURPLE_KEYS) + 8) * 2);
			num += (float)(cmd.GetVar(Vars.FAIRYLAND_LOCKS) * 15);
			bool flag21 = cmd.GetVar(Vars.GREENFIGHT_LOCK_1) > 0;
			if (flag21)
			{
				num += 25f;
			}
			bool flag22 = cmd.GetVar(Vars.GREENFIGHT_LOCK_2) > 0;
			if (flag22)
			{
				num += 25f;
			}
			bool flag23 = cmd.GetVar(Vars.GREENFIGHT_LOCK_3) > 0;
			if (flag23)
			{
				num += 25f;
			}
			bool flag24 = cmd.GetVar(Vars.GREENFIGHT_LOCK_4) > 0;
			if (flag24)
			{
				num += 25f;
			}
			bool flag25 = cmd.GetVar(Vars.GREENFIGHT_LOCK_5) > 0;
			if (flag25)
			{
				num += 25f;
			}
			bool flag26 = cmd.GetVar(Vars.GREENFIGHT_LOCK_6) > 0;
			if (flag26)
			{
				num += 25f;
			}
			bool flag27 = cmd.GetVar(Vars.GREENFIGHT_LOCK_7) > 0;
			if (flag27)
			{
				num += 25f;
			}
			bool flag28 = cmd.GetVar(Vars.GREENFIGHT_LOCK_8) > 0;
			if (flag28)
			{
				num += 25f;
			}
			bool flag29 = cmd.GetVar(Vars.GREEN_KEY) > 0;
			if (flag29)
			{
				num += 25f;
			}
			bool flag30 = cmd.GetVar(Vars.BACK_DOOR_LOCK_1) > 0;
			if (flag30)
			{
				num += 15f;
			}
			bool flag31 = cmd.GetVar(Vars.BACK_DOOR_LOCK_2) > 0;
			if (flag31)
			{
				num += 15f;
			}
			bool flag32 = cmd.GetVar(Vars.COMPLETION_SWAMP) > 0;
			if (flag32)
			{
				num += 35f;
			}
			bool flag33 = cmd.GetVar(Vars.COMPLETION_MAZE) > 0;
			if (flag33)
			{
				num += 30f;
			}
			bool flag34 = cmd.GetVar(Vars.COMPLETION_BOOTS) > 0;
			if (flag34)
			{
				num += 10f;
			}
			bool flag35 = cmd.GetVar(Vars.COMPLETION_CLOAK) > 0;
			if (flag35)
			{
				num += 10f;
			}
			bool flag36 = cmd.GetVar(Vars.BLOODMOON_EFFECT) > 0;
			if (flag36)
			{
				num += 100f;
				bool flag37 = cmd.GetVar(Vars.BLOODMOON_COUNT) <= 0;
				if (flag37)
				{
					num += 25f;
				}
			}
			bool flag38 = cmd.GetVar(Vars.RED_SWORD) > 0;
			if (flag38)
			{
				num += 100f;
			}
			bool flag39 = cmd.GetVar(Vars.RED_SHIELD) > 0;
			if (flag39)
			{
				num += 100f;
			}
			bool flag40 = cmd.GetVar(Vars.RDRAGON_KILLED) > 0;
			if (flag40)
			{
				num += 25f;
			}
			bool flag41 = cmd.GetVar(Vars.NGP) > 0;
			if (flag41)
			{
				num += 61f;
			}
			bool flag42 = cmd.GetVar(Vars.NGPP) > 0;
			if (flag42)
			{
				num += 911f;
			}
			num += (float)(cmd.GetVar(Vars.TOTAL_NGP_TOKENS) * 25);
			num += (float)((cmd.GetVar(Vars.TOTAL_NGP_TOKENS) - cmd.GetVar(Vars.NGP_TOKENS)) * 25);
			bool flag43 = CompletionCalculator.CMAllIcons(cmd);
			if (flag43)
			{
				num += 32f;
			}
			float num2 = 36.89f;
			float num3 = num2 / 100f;
			bool flag44 = cmd.GetVar(155) >= 127;
			if (flag44)
			{
				num += num2;
			}
			bool flag45 = cmd.GetVar(155) >= byte.MaxValue;
			if (flag45)
			{
				num += num2;
			}
			bool flag46 = cmd.GetVar(168) > 0;
			if (flag46)
			{
				num -= num2;
			}
			bool flag47 = cmd.GetVar(162) > 0;
			if (flag47)
			{
				num += num2 * 2f;
			}
			bool flag48 = cmd.GetVar(158) > 0;
			if (flag48)
			{
				num += num2 * 3f;
			}
			bool flag49 = cmd.GetVar(166) > 0;
			if (flag49)
			{
				num += num2 * 2f;
			}
			bool flag50 = cmd.GetVar(164) > 0;
			if (flag50)
			{
				num += num2 * 4f;
			}
			bool flag51 = cmd.GetVar(160) > 0;
			if (flag51)
			{
				num += num2 * 3f;
			}
			bool flag52 = cmd.GetVar(174) > 0;
			if (flag52)
			{
				num += num2 * 3f;
				num += (float)Math.Min(100, cmd.GetVar(175)) * (num3 * 4f);
			}
			bool flag53 = cmd.GetVar(144) == 0 && cmd.GetVar(149) == 0 && cmd.GetVar(54) > 0;
			if (flag53)
			{
				num += num2;
			}
			bool flag54 = cmd.GetVar(170) > 0;
			if (flag54)
			{
				num += num2 * 2f;
			}
			bool flag55 = cmd.GetVar(171) > 0;
			if (flag55)
			{
				num += num2 * 2f;
			}
			bool flag56 = cmd.GetVar(186) > 0;
			if (flag56)
			{
				num += num2;
			}
			return (int)num;
		}

		// Token: 0x06000081 RID: 129 RVA: 0x00009700 File Offset: 0x00007900
		internal static bool CMAllIcons(CMSaveData cmd)
		{
			bool flag = cmd.GetVar(Vars.RED_SHIELD) == 0 && cmd.GetVar(Vars.GEM_SHIELD) == 0 && cmd.GetVar(Vars.SHIELD) == 0;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				bool flag2 = cmd.GetVar(Vars.GEM_BOOTS) == 0 && cmd.GetVar(Vars.BOOTS) == 0;
				if (flag2)
				{
					result = false;
				}
				else
				{
					bool flag3 = cmd.GetVar(Vars.SPECTACLES) == 0;
					if (flag3)
					{
						result = false;
					}
					else
					{
						bool flag4 = cmd.GetVar(Vars.WATER_RING) == 0;
						if (flag4)
						{
							result = false;
						}
						else
						{
							bool flag5 = cmd.GetVar(Vars.LAVA_CHARMS) == 0;
							if (flag5)
							{
								result = false;
							}
							else
							{
								bool flag6 = cmd.GetVar(Vars.COMPASSES) == 0;
								if (flag6)
								{
									result = false;
								}
								else
								{
									bool flag7 = cmd.GetVar(Vars.HAMMERS) == 0;
									if (flag7)
									{
										result = false;
									}
									else
									{
										bool flag8 = cmd.GetVar(Vars.SKELETON_KEY) == 0;
										if (flag8)
										{
											result = false;
										}
										else
										{
											bool flag9 = cmd.GetVar(Vars.BACKUP_T_PORTAL_STONES) - cmd.GetVar(Vars.BACKUP_PORTAL_STONES) <= 99;
											if (flag9)
											{
												result = false;
											}
											else
											{
												bool flag10 = cmd.GetVar(Vars.BACKUP_T_GEMS) - cmd.GetVar(Vars.BACKUP_GEMS) <= 98;
												if (flag10)
												{
													result = false;
												}
												else
												{
													bool flag11 = cmd.GetVar(Vars.BACKUP_T_TREASURES) <= 250;
													if (flag11)
													{
														result = false;
													}
													else
													{
														bool flag12 = cmd.GetVar(Vars.TOTAL_SILVER_DOORS) <= 98;
														if (flag12)
														{
															result = false;
														}
														else
														{
															bool flag13 = cmd.GetVar(Vars.TOTAL_GOLD_DOORS) <= 98;
															if (flag13)
															{
																result = false;
															}
															else
															{
																bool flag14 = cmd.GetVar(Vars.TOTAL_TEAL_DOORS) <= 12;
																if (flag14)
																{
																	result = false;
																}
																else
																{
																	bool flag15 = cmd.GetVar(Vars.TOTAL_PURPLE_DOORS) <= 12;
																	if (flag15)
																	{
																		result = false;
																	}
																	else
																	{
																		bool flag16 = cmd.GetVar(Vars.HEARTS) <= 49;
																		if (flag16)
																		{
																			result = false;
																		}
																		else
																		{
																			bool flag17 = cmd.GetVar(Vars.TOTAL_RED_DOORS) == 0;
																			if (flag17)
																			{
																				result = false;
																			}
																			else
																			{
																				bool flag18 = cmd.GetVar(Vars.TOTAL_BLUE_DOORS) == 0;
																				if (flag18)
																				{
																					result = false;
																				}
																				else
																				{
																					bool flag19 = cmd.GetVar(Vars.TOTAL_GREEN_DOORS) == 0;
																					if (flag19)
																					{
																						result = false;
																					}
																					else
																					{
																						bool flag20 = cmd.GetVar(Vars.TOTAL_TOKENS) == 0;
																						if (flag20)
																						{
																							result = false;
																						}
																						else
																						{
																							bool flag21 = cmd.GetVar(Vars.BLOODMOON_EFFECT) == 0;
																							if (flag21)
																							{
																								result = false;
																							}
																							else
																							{
																								bool flag22 = cmd.GetVar(Vars.WITCH_CLOAK) == 0;
																								result = !flag22;
																							}
																						}
																					}
																				}
																			}
																		}
																	}
																}
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
			return result;
		}
	}
}
