using System;
using System.Collections.Generic;
using HS_Tools;

namespace HS_Save_Editor
{
	public static class CompletionCalculator
	{
		static byte[] _values = new byte[0];
		internal const float num2 = 36.89f;
		const float num3 = num2 / 100f;
		internal const float scale = 0.027107617f;
		internal static byte getValue(Vars key)
        {
			return getValue((int)key);
        }
		internal static byte getValue(int key)
		{
			return DataUtils.Get(_values[key]);
		}
		internal static List<Percent> alwaysPercents = new List<Percent>()
		{
			new Percent { vars=Vars.TOTAL_TEAL_KEYS, multiplier =4f },
			new Percent { vars=Vars.TOTAL_PURPLE_KEYS, multiplier =4f },
			new Percent { vars=Vars.TOTAL_TEAL_DOORS, multiplier =4f },
			new Percent { vars=Vars.TOTAL_PURPLE_DOORS, multiplier =4f },
			new Percent { vars=Vars.TOTAL_TEAL_KEYS, multiplier =2f, condition=Condition.SUBVAR, conditionVal=(int)Vars.TEAL_KEYS },
			new Percent { vars=Vars.TOTAL_PURPLE_KEYS, multiplier =2f, condition=Condition.SUBVAR, conditionVal=(int)Vars.PURPLE_KEYS },
			new Percent { vars=Vars.TOTAL_SILVER_DOORS, multiplier =2f },
			new Percent { vars=Vars.TOTAL_GOLD_DOORS, multiplier =3f },
			new Percent { vars=Vars.DRAGON_TREASURE, multiplier =2f },
			new Percent { vars=Vars.FAIRYLAND_LOCKS, multiplier =15f },
			new Percent { vars=Vars.SNAKE_BOSS_DEFEATED, multiplier =25f, condition=Condition.GT, conditionVal=1 },
			new Percent { vars=Vars.BOSS_REACHED, multiplier =25f, condition=Condition.GT },
			new Percent { vars=Vars.DRAGON_KILLED, multiplier =25f, condition=Condition.GT },
			new Percent { vars=Vars.BUNNY_CRIME_SCENE, multiplier =5f, condition=Condition.GT },
			new Percent { vars=Vars.TOTAL_RED_KEYS, multiplier =10f, condition=Condition.GT },
			new Percent { vars=Vars.TOTAL_BLUE_KEYS, multiplier =10f, condition=Condition.GT },
			new Percent { vars=Vars.TOTAL_GREEN_KEYS, multiplier =25f, condition=Condition.GT },
			new Percent { vars=Vars.TOTAL_RED_DOORS, multiplier =20f, condition=Condition.GT },
			new Percent { vars=Vars.TOTAL_BLUE_DOORS, multiplier =20f, condition=Condition.GT },
			new Percent { vars=Vars.TOTAL_GREEN_DOORS, multiplier =50f, condition=Condition.GT },
			new Percent { vars=Vars.GEM_HEART, multiplier =50f, condition=Condition.GT },
			new Percent { vars=Vars.GREENFIGHT_LOCK_1, multiplier =25f, condition=Condition.GT },
			new Percent { vars=Vars.GREENFIGHT_LOCK_2, multiplier =25f, condition=Condition.GT },
			new Percent { vars=Vars.GREENFIGHT_LOCK_3, multiplier =25f, condition=Condition.GT },
			new Percent { vars=Vars.GREENFIGHT_LOCK_4, multiplier =25f, condition=Condition.GT },
			new Percent { vars=Vars.GREENFIGHT_LOCK_5, multiplier =25f, condition=Condition.GT },
			new Percent { vars=Vars.GREENFIGHT_LOCK_6, multiplier =25f, condition=Condition.GT },
			new Percent { vars=Vars.GREENFIGHT_LOCK_7, multiplier =25f, condition=Condition.GT },
			new Percent { vars=Vars.GREENFIGHT_LOCK_8, multiplier =25f, condition=Condition.GT },
			new Percent { vars=Vars.GREEN_KEY, multiplier =25f, condition=Condition.GT },
			new Percent { vars=Vars.BACK_DOOR_LOCK_1, multiplier =15f, condition=Condition.GT },
			new Percent { vars=Vars.BACK_DOOR_LOCK_2, multiplier =15f, condition=Condition.GT },
			new Percent { vars=Vars.COMPLETION_SWAMP, multiplier =35f, condition=Condition.GT },
			new Percent { vars=Vars.COMPLETION_MAZE, multiplier =30f, condition=Condition.GT },
			new Percent { vars=Vars.COMPLETION_BOOTS, multiplier =10f, condition=Condition.GT },
			new Percent { vars=Vars.COMPLETION_CLOAK, multiplier =10f, condition=Condition.GT },
			new Percent { vars=Vars.RED_SWORD, multiplier =100f, condition=Condition.GT },
			new Percent { vars=Vars.RED_SHIELD, multiplier =100f, condition=Condition.GT },
			new Percent { vars=Vars.RDRAGON_KILLED, multiplier =25f, condition=Condition.GT },
			new Percent { vars=Vars.NGP, multiplier =61f, condition=Condition.GT },
			new Percent { vars=Vars.NGPP, multiplier =911f, condition=Condition.GT },
			new Percent { vars=Vars.CARROT, multiplier =num2 * -1f, condition=Condition.GT },
			new Percent { vars=Vars.DRAGON_EGG, multiplier =num2 * 4f, condition=Condition.GT },
			new Percent { vars=Vars.GREEN_SWORD, multiplier =num2 * 2f, condition=Condition.GT },
			new Percent { vars=Vars.GREEN_SHIELD, multiplier =num2 * 2f, condition=Condition.GT },
			new Percent { vars=Vars.NGPPP, multiplier =num2, condition=Condition.GT },
			new Percent { vars=Vars.BLOODMOON_EFFECT, multiplier =100f, condition=Condition.GT },
			new Percent { vars=Vars.BUNNY_LOVE, multiplier =(num2 * 3f) + 5f, condition=Condition.GT },
			new Percent { vars=Vars.BUNNY_LEVEL, multiplier =num3 * 4f, max=100 },
		};
		internal static List<Percent> witchPercents = new List<Percent>()
		{
            new Percent { vars=Vars.WITCH_HAMMER, multiplier =5f, condition=Condition.GT },
            new Percent { vars=Vars.WITCH_WATER_RING, multiplier =5f, condition=Condition.GT },
            new Percent { vars=Vars.WITCH_LAVA_CHARM, multiplier =5f, condition=Condition.GT },
            new Percent { vars=Vars.WITCH_SKELETON_KEY, multiplier =5f, condition=Condition.GT },
            new Percent { vars=Vars.WITCH_COMPASS, multiplier =5f, condition=Condition.GT },
            new Percent { vars=Vars.WITCH_BOOTS, multiplier =5f, condition=Condition.GT },
            new Percent { vars=Vars.WITCH_GEM_SWORD_1, multiplier =10f, condition=Condition.GT },
            new Percent { vars=Vars.WITCH_GEM_SWORD_2, multiplier =10f, condition=Condition.GT },
            new Percent { vars=Vars.WITCH_GEM_SWORD_3, multiplier =10f, condition=Condition.GT },
            new Percent { vars=Vars.WITCH_PHASE1, multiplier =15f, condition=Condition.GT },
            new Percent { vars=Vars.WITCH_PHASE2, multiplier =25f, condition=Condition.GT },
            new Percent { vars=Vars.WITCH_PHASE3, multiplier =35f, condition=Condition.GT },

        };
		internal static List<Percent> notGreenlist = new List<Percent>()
		{
			new Percent { vars=(Vars)111, multiplier =2f }, // BACKUP_T_SILVER_KEYS
			new Percent { vars=(Vars)112, multiplier =3f },
			new Percent { vars=(Vars)108, multiplier =2f },
			new Percent { vars=(Vars)110, multiplier =2f },
			new Percent { vars=(Vars)109, multiplier =2f },
			new Percent { vars=(Vars)110, multiplier =1f, condition=Condition.SUBVAR, conditionVal=105 },
			new Percent { vars=(Vars)109, multiplier =2f, condition=Condition.SUBVAR, conditionVal=104 },
			new Percent { vars=(Vars)90, multiplier =15f, condition=Condition.GT },
			new Percent { vars=(Vars)88, multiplier =15f, condition=Condition.GT },
			new Percent { vars=(Vars)79, multiplier =15f, condition=Condition.GT },
			new Percent { vars=(Vars)77, multiplier =25f, condition=Condition.GT },
			new Percent { vars=(Vars)78, multiplier =15f, condition=Condition.GT },
			new Percent { vars=(Vars)82, multiplier =15f, condition=Condition.GT },
			new Percent { vars=(Vars)80, multiplier =20f, condition=Condition.GT },
			new Percent { vars=(Vars)81, multiplier =20f, condition=Condition.GT },
			new Percent { vars=(Vars)111, multiplier =1f, condition=Condition.SUBVAR, conditionVal=106 },
			new Percent { vars=(Vars)112, multiplier =1f, condition=Condition.SUBVAR, conditionVal=107 },
			new Percent { vars=(Vars)182, multiplier =25f },
			new Percent { vars=(Vars)182, multiplier =25f, condition=Condition.SUBVAR, conditionVal=180 },
			new Percent { vars=(Vars)183, multiplier =100f },
			new Percent { vars=(Vars)183, multiplier =25f, condition=Condition.SUBVAR, conditionVal=181 },
			new Percent { vars=(Vars)156, multiplier =num2 * 3f, condition=Condition.GTE, conditionVal=127 },
			new Percent { vars=(Vars)156, multiplier =num2 * 3f, condition=Condition.GTE, conditionVal=byte.MaxValue },
			new Percent { vars=(Vars)163, multiplier =num2 * 2f, condition=Condition.GT },
			new Percent { vars=(Vars)159, multiplier =num2, condition=Condition.GT },
			new Percent { vars=(Vars)167, multiplier =num2, condition=Condition.GT },
			new Percent { vars=(Vars)161, multiplier =num2 * 3f, condition=Condition.GT },

		};
		internal static List<Percent> greenlist = new List<Percent>()
		{
			new Percent { vars=Vars.TOTAL_SILVER_KEYS, multiplier =2f },
			new Percent { vars=Vars.TOTAL_GOLD_KEYS, multiplier =3f },
			new Percent { vars=Vars.TOTAL_TREASURES, multiplier =2f },
			new Percent { vars=Vars.TOTAL_PORTAL_STONES, multiplier =2f },
			new Percent { vars=Vars.TOTAL_GEMS, multiplier =2f },
			new Percent { vars=Vars.TOTAL_PORTAL_STONES, multiplier =1f, condition=Condition.SUBVAR, conditionVal=(int)Vars.PORTAL_STONES },
			new Percent { vars=Vars.TOTAL_GEMS, multiplier =2f, condition=Condition.SUBVAR, conditionVal=(int)Vars.GEMS },
			new Percent { vars=Vars.COMPASSES, multiplier =15f, condition=Condition.GT },
			new Percent { vars=Vars.HAMMERS, multiplier =15f, condition=Condition.GT },
			new Percent { vars=Vars.SKELETON_KEY, multiplier =15f, condition=Condition.GT },
			new Percent { vars=Vars.GEM_SWORD, multiplier =25f, condition=Condition.GT },
			new Percent { vars=Vars.GEM_SHIELD, multiplier =25f, condition=Condition.GT },
			new Percent { vars=Vars.BOOTS, multiplier =15f, condition=Condition.GT },
			new Percent { vars=Vars.LAVA_CHARMS, multiplier =20f, condition=Condition.GT },
			new Percent { vars=Vars.WATER_RING, multiplier =20f, condition=Condition.GT },
			new Percent { vars=Vars.TOTAL_SILVER_KEYS, multiplier =1f, condition=Condition.SUBVAR, conditionVal=(int)Vars.SILVER_KEYS },
			new Percent { vars=Vars.TOTAL_GOLD_KEYS, multiplier =1f, condition=Condition.SUBVAR, conditionVal=(int)Vars.GOLD_KEYS },
			new Percent { vars=Vars.TOTAL_NGP_TOKENS, multiplier =25f },
			new Percent { vars=Vars.TOTAL_NGP_TOKENS, multiplier =25f, condition=Condition.SUBVAR, conditionVal=(int)Vars.NGP_TOKENS },
			new Percent { vars=Vars.TOTAL_TOKENS, multiplier =100f },
			new Percent { vars=Vars.TOTAL_TOKENS, multiplier =25f, condition=Condition.SUBVAR, conditionVal=(int)Vars.SECRET_TOKENS },
			new Percent { vars=Vars.TOTAL_POSSUM_COINS, multiplier =num2, condition=Condition.GTE, conditionVal=127 },
			new Percent { vars=Vars.TOTAL_POSSUM_COINS, multiplier =num2, condition=Condition.GTE, conditionVal=byte.MaxValue },
			new Percent { vars=Vars.MIRROR, multiplier =num2 * 2f, condition=Condition.GT },
			new Percent { vars=Vars.BROOM, multiplier =num2 * 3f, condition=Condition.GT },
			new Percent { vars=Vars.SAVE_CRYSTAL, multiplier =num2 * 2f, condition=Condition.GT },
			new Percent { vars=Vars.COLLECTOR_EYE, multiplier =num2 * 3f, condition=Condition.GT },
		};
		
		internal static float calculateIndividualpercent(byte[] values, Vars id)
        {
			var total = Calculate(values);
			float num = 0f;
			var greenfight = true;

			if (greenfight)
			{
				foreach (var percent in greenlist)
				{
					if (percent.vars == id && percent.condition != Condition.SUBVAR)
					{
						var val = getValue(percent.vars);
						switch (percent.condition)
						{
							case Condition.GT:
								num += (float)(Convert.ToInt32(val > percent.conditionVal)) * percent.multiplier;
								break;
							case Condition.GTE:
								num += (float)(Convert.ToInt32(val >= percent.conditionVal)) * percent.multiplier;
								break;
							case Condition.None:
								var maxNum = (float)val;
								if (percent.max != -1)
									maxNum = (float)Math.Min(100, (int)val);
								num += maxNum * percent.multiplier;
								break;
							default:
								break;
						}
					}
				}
			}
			foreach (var percent in alwaysPercents)
            {
				if (percent.vars == id && percent.condition != Condition.SUBVAR)
				{
					var val = getValue(percent.vars);
					switch (percent.condition)
					{
						case Condition.GT:
							num += (float)(Convert.ToInt32(val > percent.conditionVal)) * percent.multiplier;
							break;
						case Condition.GTE:
							num += (float)(Convert.ToInt32(val >= percent.conditionVal)) * percent.multiplier;
							break;
						case Condition.None:
							var maxNum = (float)val;
							if (percent.max != -1)
								maxNum = (float)Math.Min(100, (int)val);
							num += maxNum * percent.multiplier;
							break;
						default:
							break;
					}
				}

			}
			return num * scale;
			

		}

		internal static List<Percent> calculateMissedpercent(byte[] values)
		{
			_values = values;
			//var total = Calculate(values);
			List <Percent> res = new List < Percent >();
			var greenfight = true;

			if (greenfight)
			{
				foreach (var percent in greenlist)
				{
					if (percent.condition != Condition.SUBVAR)
					{
						var val = getValue(percent.vars);
						switch (percent.condition)
						{
							case Condition.GT:
								if (!(val > percent.conditionVal))
									res.Add(percent);
								break;
							case Condition.GTE:
								if (!(val >= percent.conditionVal))
									res.Add(percent);
								break;
							case Condition.None:
								var maxNum = (float)val;
								if (percent.max != -1)
									maxNum = (float)Math.Min(100, (int)val);
								if (maxNum * percent.multiplier <= 0)
									res.Add(percent);
								break;
							default:
								break;
						}
					}
				}
			}
			foreach (var percent in alwaysPercents)
			{
				if (percent.condition != Condition.SUBVAR)
				{
					var val = getValue(percent.vars);
					switch (percent.condition)
					{
						case Condition.GT:
							if (!(val > percent.conditionVal))
								res.Add(percent);
							break;
						case Condition.GTE:
							if (!(val >= percent.conditionVal))
								res.Add(percent);
							break;
						case Condition.None:
							var maxNum = (float)val;
							if (percent.max != -1)
								maxNum = (float)Math.Min(100, (int)val);
							if (maxNum * percent.multiplier <= 0)
								res.Add(percent);
							break;
						default:
							break;
					}
				}

			}
			return res;


		}

		internal static List<string> calculateExtraPercent(byte[] values)
		{
			_values = values;
			List<string> res = new List<string>();
			var greenfight = true;

			if (greenfight)
			{
				res.Add(string.Format("Skip (Not sure what this is): {0}", 50f * scale));

				foreach (var percent in greenlist)
				{
					if (percent.condition == Condition.SUBVAR)
					{
						Vars secondVar = (Vars)percent.conditionVal;
						var val = getValue(percent.vars);
						var val2 = getValue(percent.conditionVal);
						string calc = string.Format("({0} - {1}) * {2}: ({3} - {4}) * {2} = {5}",
							percent.vars.ToString(),
							secondVar.ToString(),
							percent.multiplier * scale,
							val,
							val2,
							(val - val2) * percent.multiplier * scale
							);
						res.Add(calc);

					}
				}
			}
			foreach (var percent in alwaysPercents)
			{
				if (percent.condition == Condition.SUBVAR)
				{
					Vars secondVar = (Vars)percent.conditionVal;
					var val = getValue(percent.vars);
					var val2 = getValue(percent.conditionVal);
					string calc = string.Format("({0} - {1}) * {2}: ({3} - {4}) * {2} = {5}",
						percent.vars.ToString(),
						secondVar.ToString(),
						percent.multiplier * scale,
						val,
						val2,
						(val - val2) * percent.multiplier * scale
						);
					res.Add(calc);

				}

			}



			res.Add(string.Format("{0} or {1}: {2}", (Vars)89, (Vars)127, Convert.ToInt32(getValue(89) > 0 || getValue(127) > 0) * 25f * scale));
			res.Add(string.Format("{0} and {1} < 0: {2}", (Vars)25, (Vars)26, Convert.ToInt32(getValue(25) > 0 && getValue(26) <= 0) * 25f * scale));
			res.Add(
				string.Format("not {0} and not {1} and {2}: {3}",
				(Vars)144,
				(Vars)149,
				(Vars)54,
				Convert.ToInt32(getValue(144) == 0 && getValue(149) == 0 && getValue(54) > 0) * num2 * scale)
				);



			return res;
		}

		public static float calculateFromList(List<Percent> list, bool greenfight, bool convergence = false, bool perfectWitch = false)
		{
			float num = 0f;
			foreach (var percent in list)
            {
				var val = getValue(percent.vars);
				var mult = percent.multiplier;
				if (convergence)
				{
					if (percent.vars == Vars.TOTAL_TEAL_DOORS || percent.vars == Vars.TOTAL_TEAL_KEYS ||
									percent.vars == Vars.TOTAL_PURPLE_DOORS || percent.vars == Vars.TOTAL_PURPLE_KEYS)
						val += 8;
					else if (percent.vars == Vars.BUNNY_LOVE)
						mult -= 5;
				}
				if (!convergence && perfectWitch)
                {
					if (percent.vars == Vars.WITCH_HAMMER || percent.vars == Vars.WITCH_WATER_RING ||
						percent.vars == Vars.WITCH_LAVA_CHARM || percent.vars == Vars.WITCH_COMPASS ||
						percent.vars == Vars.WITCH_BOOTS || percent.vars == Vars.WITCH_GEM_SWORD_1 ||
						percent.vars == Vars.WITCH_GEM_SWORD_2 || percent.vars == Vars.WITCH_GEM_SWORD_3)
						val = 1;
					if (percent.vars == Vars.WITCH_SKELETON_KEY)
						val = 0;
					if (percent.vars == Vars.TOTAL_TEAL_DOORS || percent.vars == Vars.TOTAL_PURPLE_DOORS ||
						percent.vars == Vars.TOTAL_TEAL_KEYS || percent.vars == Vars.TOTAL_PURPLE_KEYS)
					{
						val = 13;
					}

                }
				if (!convergence && !greenfight)
                {
					if (percent.vars == Vars.WITCH_PHASE3 || percent.vars == Vars.WITCH_PHASE1 || percent.vars == Vars.WITCH_PHASE2)
                    {
						val = 1;
                    }
				}
				switch (percent.condition)
				{
					case Condition.GT:
						num += (float)(Convert.ToInt32(val > percent.conditionVal)) * mult;
						break;
					case Condition.GTE:
						num += (float)(Convert.ToInt32(val >= percent.conditionVal)) * mult;
						break;
					case Condition.None:
						var maxNum = (float)val;
						if (percent.max != -1)
							maxNum = (float)Math.Min(percent.max, (int)val);
						num += maxNum * mult;
						break;
					case Condition.SUBVAR:
						Vars secondVar = (Vars)percent.conditionVal;
						var val2 = getValue(percent.conditionVal);
						if (!convergence && perfectWitch)
						{

							if (percent.vars == Vars.TOTAL_TEAL_KEYS || percent.vars == Vars.TOTAL_PURPLE_KEYS)
							{
								if (secondVar == Vars.TEAL_KEYS || secondVar == Vars.PURPLE_KEYS)
									val2 = 0;
							}
						}
				
						num += (val - val2) * mult;
						break;
					default:
						Console.WriteLine("Invalid percent condition");
						break;
				}
			}

			return num;
		}

		public static float remainingPercents()
		{
			float num = 0f;

			if (getValue(Vars.GEM_BOOTS) > 0 || getValue(Vars.BACKUP_GEM_BOOTS) > 0)
			{
				num += 25f;
			}
			if (getValue(Vars.BLOODMOON_EFFECT) > 0 && getValue(Vars.BLOODMOON_COUNT) <= 0)
			{
				num += 25f;
			}

			if (getValue(Vars.NGP) == 0 && getValue(Vars.NGPP) == 0 && getValue(Vars.WITCH_CLOAK) > 0)
			{
				num += num2;
			}

			return num;
		}

		public static int Calculate(byte[] values,  bool convergence = false, bool greenfight = true, bool perfectWitch = false)
		{
			_values = (byte[])values.Clone();

			float num = 0f;

			if (greenfight)
			{
				num += 50f;
				num += calculateFromList(greenlist, greenfight,convergence);
				num += calculateFromList(witchPercents, false);
			}
			else if (convergence)
            {
				num += (1590f/3f);
				num += 60f;
				num += 75f;
				num += calculateFromList(greenlist, greenfight, convergence);
			}
            else
            {
				num += calculateFromList(notGreenlist, greenfight, convergence, perfectWitch);
				num += calculateFromList(witchPercents, greenfight, convergence, perfectWitch);

			}

			num += calculateFromList(alwaysPercents, greenfight, convergence,perfectWitch);
			num += remainingPercents();
			if (AllIcons(greenfight,convergence, perfectWitch))
			{
				num += 32f;
			}

			var result = (int)Math.Floor((double)(scale * num));
			return result;
		}

		public static bool AllIcons(bool greenfight = true, bool convergence = false, bool perfectWitch = false)
		{
			bool result = true;
			if (
				(getValue(Vars.RED_SHIELD) == 0 && getValue(Vars.GEM_SHIELD) == 0 && getValue(Vars.SHIELD) == 0) ||
				(getValue(Vars.GEM_BOOTS) == 0 && getValue(Vars.BOOTS) == 0) || (getValue(Vars.SPECTACLES) == 0) ||
				getValue(Vars.WATER_RING) == 0 || getValue(Vars.LAVA_CHARMS) == 0 || getValue(Vars.COMPASSES) == 0 ||
				getValue(Vars.HAMMERS) == 0 || getValue(Vars.SKELETON_KEY) == 0
				)
				result = false;
			else
            {
				if (greenfight && ((getValue(16) - getValue(13) <= 99) || (getValue(17) - getValue(14) <= 98) || (getValue(18) <= 250)))
					return false;
				else if ((getValue(Vars.BACKUP_T_PORTAL_STONES) - getValue(Vars.BACKUP_PORTAL_STONES) <= 99) ||
						(getValue(Vars.BACKUP_T_GEMS) - getValue(Vars.BACKUP_GEMS) <= 98) ||
						(getValue(Vars.BACKUP_T_TREASURES) <= 250))
					return false;
				if  (getValue(Vars.TOTAL_SILVER_DOORS) <= 98 || getValue(Vars.TOTAL_GOLD_DOORS) <= 98 ||
					(!perfectWitch && getValue(Vars.TOTAL_TEAL_DOORS) <= 12) ||
					(!perfectWitch && getValue(Vars.TOTAL_PURPLE_DOORS) <= 12) ||
					getValue(Vars.HEARTS) <= 49 || getValue(Vars.TOTAL_RED_DOORS) == 0 ||
					getValue(Vars.TOTAL_BLUE_DOORS) == 0 || getValue(Vars.TOTAL_GREEN_DOORS) == 0 ||
					(greenfight && getValue(Vars.TOTAL_TOKENS) == 0) || (convergence && getValue(Vars.TOTAL_TOKENS) == 0) ||
					(!convergence && getValue(Vars.BACKUP_T_SECRET_TOKENS) == 0) || getValue(Vars.BLOODMOON_EFFECT) == 0 || getValue(Vars.WITCH_CLOAK) == 0
					)
				{
					result = false;
				}
				else
					result = true;
			}

			return result;
		}

	}
}
