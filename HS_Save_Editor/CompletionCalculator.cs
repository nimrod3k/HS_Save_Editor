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
			new Percent { vars=(Vars)121, multiplier =4f },
			new Percent { vars=(Vars)122, multiplier =4f },
			new Percent { vars=(Vars)114, multiplier =2f },
			new Percent { vars=(Vars)113, multiplier =3f },
			new Percent { vars=(Vars)115, multiplier =4f },
			new Percent { vars=(Vars)116, multiplier =4f },
			new Percent { vars=(Vars)34, multiplier =2f },
			new Percent { vars=(Vars)72, multiplier =15f },
			new Percent { vars=(Vars)131, multiplier =5f, condition=Condition.GT },
			new Percent { vars=(Vars)132, multiplier =5f, condition=Condition.GT },
			new Percent { vars=(Vars)133, multiplier =5f, condition=Condition.GT },
			new Percent { vars=(Vars)134, multiplier =5f, condition=Condition.GT },
			new Percent { vars=(Vars)135, multiplier =5f, condition=Condition.GT },
			new Percent { vars=(Vars)136, multiplier =5f, condition=Condition.GT },
			new Percent { vars=(Vars)137, multiplier =10f, condition=Condition.GT },
			new Percent { vars=(Vars)138, multiplier =10f, condition=Condition.GT },
			new Percent { vars=(Vars)139, multiplier =10f, condition=Condition.GT },
			new Percent { vars=(Vars)123, multiplier =15f, condition=Condition.GT },
			new Percent { vars=(Vars)124, multiplier =25f, condition=Condition.GT },
			new Percent { vars=(Vars)125, multiplier =35f, condition=Condition.GT },
			new Percent { vars=(Vars)63, multiplier =25f, condition=Condition.GT, conditionVal=1 },
			new Percent { vars=(Vars)28, multiplier =25f, condition=Condition.GT },
			new Percent { vars=(Vars)75, multiplier =25f, condition=Condition.GT },
			new Percent { vars=(Vars)126, multiplier =5f, condition=Condition.GT },
			new Percent { vars=(Vars)10, multiplier =10f, condition=Condition.GT },
			new Percent { vars=(Vars)11, multiplier =10f, condition=Condition.GT },
			new Percent { vars=(Vars)12, multiplier =25f, condition=Condition.GT },
			new Percent { vars=(Vars)117, multiplier =20f, condition=Condition.GT },
			new Percent { vars=(Vars)118, multiplier =20f, condition=Condition.GT },
			new Percent { vars=(Vars)119, multiplier =50f, condition=Condition.GT },
			new Percent { vars=(Vars)73, multiplier =50f, condition=Condition.GT },
			new Percent { vars=(Vars)91, multiplier =25f, condition=Condition.GT },
			new Percent { vars=(Vars)92, multiplier =25f, condition=Condition.GT },
			new Percent { vars=(Vars)93, multiplier =25f, condition=Condition.GT },
			new Percent { vars=(Vars)94, multiplier =25f, condition=Condition.GT },
			new Percent { vars=(Vars)95, multiplier =25f, condition=Condition.GT },
			new Percent { vars=(Vars)96, multiplier =25f, condition=Condition.GT },
			new Percent { vars=(Vars)97, multiplier =25f, condition=Condition.GT },
			new Percent { vars=(Vars)98, multiplier =25f, condition=Condition.GT },
			new Percent { vars=(Vars)24, multiplier =25f, condition=Condition.GT },
			new Percent { vars=(Vars)31, multiplier =15f, condition=Condition.GT },
			new Percent { vars=(Vars)32, multiplier =15f, condition=Condition.GT },
			new Percent { vars=(Vars)140, multiplier =35f, condition=Condition.GT },
			new Percent { vars=(Vars)141, multiplier =30f, condition=Condition.GT },
			new Percent { vars=(Vars)142, multiplier =10f, condition=Condition.GT },
			new Percent { vars=(Vars)143, multiplier =10f, condition=Condition.GT },
			new Percent { vars=(Vars)146, multiplier =100f, condition=Condition.GT },
			new Percent { vars=(Vars)147, multiplier =100f, condition=Condition.GT },
			new Percent { vars=(Vars)150, multiplier =25f, condition=Condition.GT },
			new Percent { vars=(Vars)144, multiplier =61f, condition=Condition.GT },
			new Percent { vars=(Vars)149, multiplier =911f, condition=Condition.GT },
			new Percent { vars=(Vars)168, multiplier =num2 * -1f, condition=Condition.GT },
			new Percent { vars=(Vars)164, multiplier =num2 * 4f, condition=Condition.GT },
			new Percent { vars=(Vars)170, multiplier =num2 * 2f, condition=Condition.GT },
			new Percent { vars=(Vars)171, multiplier =num2 * 2f, condition=Condition.GT },
			new Percent { vars=(Vars)186, multiplier =num2, condition=Condition.GT },
			new Percent { vars=(Vars)121, multiplier =2f, condition=Condition.SUBVAR, conditionVal=86 },
			new Percent { vars=(Vars)122, multiplier =2f, condition=Condition.SUBVAR, conditionVal=85 },
			new Percent { vars=(Vars)25, multiplier =100f, condition=Condition.GT },
			new Percent { vars=(Vars)174, multiplier =(num2 * 3f) + 5f, condition=Condition.GT },
			new Percent { vars=(Vars)175, multiplier =num3 * 4f, max=100 },

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
			new Percent { vars=(Vars)9, multiplier =2f },
			new Percent { vars=(Vars)8, multiplier =3f },
			new Percent { vars=(Vars)18, multiplier =2f },
			new Percent { vars=(Vars)16, multiplier =2f },
			new Percent { vars=(Vars)17, multiplier =2f },
			new Percent { vars=(Vars)16, multiplier =1f, condition=Condition.SUBVAR, conditionVal=13 },
			new Percent { vars=(Vars)17, multiplier =2f, condition=Condition.SUBVAR, conditionVal=14 },
			new Percent { vars=(Vars)21, multiplier =15f, condition=Condition.GT },
			new Percent { vars=(Vars)19, multiplier =15f, condition=Condition.GT },
			new Percent { vars=(Vars)58, multiplier =15f, condition=Condition.GT },
			new Percent { vars=(Vars)51, multiplier =25f, condition=Condition.GT },
			new Percent { vars=(Vars)61, multiplier =25f, condition=Condition.GT },
			new Percent { vars=(Vars)20, multiplier =15f, condition=Condition.GT },
			new Percent { vars=(Vars)55, multiplier =20f, condition=Condition.GT },
			new Percent { vars=(Vars)59, multiplier =20f, condition=Condition.GT },
			new Percent { vars=(Vars)9, multiplier =1f, condition=Condition.SUBVAR, conditionVal=3 },
			new Percent { vars=(Vars)8, multiplier =1f, condition=Condition.SUBVAR, conditionVal=2 },
			new Percent { vars=(Vars)151, multiplier =25f },
			new Percent { vars=(Vars)151, multiplier =25f, condition=Condition.SUBVAR, conditionVal=145 },
			new Percent { vars=(Vars)120, multiplier =100f },
			new Percent { vars=(Vars)120, multiplier =25f, condition=Condition.SUBVAR, conditionVal=36 },
			new Percent { vars=(Vars)155, multiplier =num2, condition=Condition.GTE, conditionVal=127 },
			new Percent { vars=(Vars)155, multiplier =num2, condition=Condition.GTE, conditionVal=byte.MaxValue },
			new Percent { vars=(Vars)162, multiplier =num2 * 2f, condition=Condition.GT },
			new Percent { vars=(Vars)158, multiplier =num2 * 3f, condition=Condition.GT },
			new Percent { vars=(Vars)166, multiplier =num2 * 2f, condition=Condition.GT },
			new Percent { vars=(Vars)160, multiplier =num2 * 3f, condition=Condition.GT },

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

		public static float calculateFromList(List<Percent> list)
		{
			float num = 0f;
			foreach (var percent in list)
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
					case Condition.SUBVAR:
						Vars secondVar = (Vars)percent.conditionVal;
						var val2 = getValue(percent.conditionVal);
						num += (val - val2) * percent.multiplier;
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

			if (getValue(89) > 0 || getValue(127) > 0)
			{
				num += 25f;
			}
			if (getValue(25) > 0 && getValue(26) <= 0)
			{
				num += 25f;
			}

			if (getValue(144) == 0 && getValue(149) == 0 && getValue(54) > 0)
			{
				num += num2;
			}

			return num;
		}

		public static int Calculate(byte[] values)
		{
			_values = (byte[])values.Clone();

			float num = 0f;
			var greenfight = true;

			if (greenfight)
			{
				num += (50f);
				num += calculateFromList(greenlist);
			}
			

			num += calculateFromList(alwaysPercents);
			num += remainingPercents();
			if (AllIcons())
			{
				num += 32f;
			}

			var result = (int)Math.Floor((double)(scale * num));
			return result;
		}

		public static bool AllIcons(bool greenfight = true)
		{
			bool result = true;
			if (
				(getValue(147) == 0 && getValue(61) == 0 && getValue(60) == 0) || (getValue(89) == 0 && getValue(20) == 0) ||
				(getValue(57) == 0) || getValue(59) == 0 || getValue(55) == 0 || getValue(21) == 0 || getValue(19) == 0 ||
				getValue(58) == 0
				)
				result = false;
			else
            {
				if (greenfight && ((getValue(16) - getValue(13) <= 99) || (getValue(17) - getValue(14) <= 98) || (getValue(18) <= 250)))
					return false;
				else if ((getValue(110) - getValue(105) <= 99) || (getValue(109) - getValue(104) <= 98) || (getValue(108) <= 250))
					return false;
				if  (
					getValue(114) <= 98 || getValue(113) <= 98 || getValue(115) <= 12 || getValue(116) <= 12 ||
					getValue(0) <= 49 || getValue(117) == 0 || getValue(118) == 0 || getValue(119) == 0 || (greenfight && getValue(120) == 0) ||
					getValue(183) == 0 || getValue(25) == 0 || getValue(54) == 0
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
