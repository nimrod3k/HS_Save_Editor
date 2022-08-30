using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS_Tools
{
    public static class HS_Save_Tools
	{
		// Initialize the DataUtils Variables
		public static void Initialize()
		{
			Deobf = new byte[256];
			for (short num = 0; num <= 255; num += 1)
			{
				Deobf[(int)Obf[(int)num]] = (byte)num;
			}
		}

		public static string Encode(string s, int seed)
		{
			string text = s;
			bool flag = seed % 3 == 0;
			if (flag)
			{
				text = HS_Save_Tools.Flip(text);
			}
			bool flag2 = (seed + 1) % 3 == 0 && s.Length == 8;
			if (flag2)
			{
				text = HS_Save_Tools.Shift(text, seed % 7 + 1);
			}
			bool flag3 = (seed + 2) % 3 == 0;
			if (flag3)
			{
				text = HS_Save_Tools.Flip(text);
			}
			bool flag4 = (seed + 1) % 3 == 0;
			if (flag4)
			{
				text = HS_Save_Tools.Flip(text);
			}
			bool flag5 = (seed + 2) % 3 == 0 && s.Length == 8;
			if (flag5)
			{
				text = HS_Save_Tools.Shift(text, (seed + 3) % 7 + 1);
			}
			bool flag6 = seed % 3 == 0;
			if (flag6)
			{
				text = HS_Save_Tools.Flip(text);
			}
			bool flag7 = (seed + 2) % 3 == 0;
			if (flag7)
			{
				text = HS_Save_Tools.Flip(text);
			}
			bool flag8 = seed % 3 == 0 && s.Length == 8;
			if (flag8)
			{
				text = HS_Save_Tools.Shift(text, (seed + 5) % 7 + 1);
			}
			bool flag9 = (seed + 1) % 3 == 0;
			if (flag9)
			{
				text = HS_Save_Tools.Flip(text);
			}
			return text;
		}

		public static string Decode(string s, int seed)
		{
			string text = s;
			bool flag = (seed + 1) % 3 == 0;
			if (flag)
			{
				text = HS_Save_Tools.Flip(text);
			}
			bool flag2 = seed % 3 == 0 && s.Length == 8;
			if (flag2)
			{
				text = HS_Save_Tools.Unshift(text, (seed + 5) % 7 + 1);
			}
			bool flag3 = (seed + 2) % 3 == 0;
			if (flag3)
			{
				text = HS_Save_Tools.Flip(text);
			}
			bool flag4 = seed % 3 == 0;
			if (flag4)
			{
				text = HS_Save_Tools.Flip(text);
			}
			bool flag5 = (seed + 2) % 3 == 0 && s.Length == 8;
			if (flag5)
			{
				text = HS_Save_Tools.Unshift(text, (seed + 3) % 7 + 1);
			}
			bool flag6 = (seed + 1) % 3 == 0;
			if (flag6)
			{
				text = HS_Save_Tools.Flip(text);
			}
			bool flag7 = (seed + 2) % 3 == 0;
			if (flag7)
			{
				text = HS_Save_Tools.Flip(text);
			}
			bool flag8 = (seed + 1) % 3 == 0 && s.Length == 8;
			if (flag8)
			{
				text = HS_Save_Tools.Unshift(text, seed % 7 + 1);
			}
			bool flag9 = seed % 3 == 0;
			if (flag9)
			{
				text = HS_Save_Tools.Flip(text);
			}
			return text;
		}

		private static string Flip(string s)
		{
			string text = "";
			int num = Math.Min(8, s.Length);
			for (int i = num - 1; i >= 0; i--)
			{
				text += s[i].ToString();
			}
			return text;
		}

		private static string Shift(string s, int offset)
		{
			string text = "";
			int num = Math.Min(8, s.Length);
			offset = Math.Min(num - 1, offset);
			for (int i = offset; i < num; i++)
			{
				text += s[i].ToString();
			}
			for (int j = 0; j < offset; j++)
			{
				text += s[j].ToString();
			}
			return text;
		}

		private static string Unshift(string s, int offset)
		{
			string text = "";
			int num = Math.Min(8, s.Length);
			offset = Math.Min(num - 1, offset);
			for (int i = s.Length - offset; i < num; i++)
			{
				text += s[i].ToString();
			}
			for (int j = 0; j < s.Length - offset; j++)
			{
				text += s[j].ToString();
			}
			return text;
		}


		public static byte DeobfuscateValue(byte val)
		{
			return Deobf[(int)val];
		}

		public static byte ObfuscateValue(byte val)
		{
			return Obf[(int)val];
		}

		// Token: 0x040001CF RID: 463
		private static byte[] Deobf;

		// Token: 0x040001D0 RID: 464
		private static readonly byte[] Obf = new byte[]
		{
			11,
			232,
			4,
			13,
			199,
			22,
			40,
			7,
			114,
			175,
			20,
			99,
			170,
			248,
			221,
			5,
			109,
			18,
			227,
			127,
			239,
			200,
			1,
			34,
			120,
			151,
			234,
			129,
			198,
			88,
			12,
			196,
			77,
			100,
			148,
			82,
			240,
			208,
			186,
			39,
			173,
			155,
			168,
			43,
			126,
			241,
			47,
			37,
			201,
			185,
			134,
			252,
			230,
			218,
			167,
			6,
			237,
			165,
			68,
			209,
			174,
			176,
			41,
			188,
			70,
			56,
			187,
			142,
			107,
			207,
			136,
			49,
			8,
			211,
			105,
			93,
			228,
			210,
			183,
			54,
			104,
			28,
			144,
			106,
			193,
			214,
			242,
			59,
			131,
			3,
			29,
			133,
			57,
			55,
			141,
			250,
			115,
			45,
			158,
			128,
			75,
			97,
			194,
			24,
			27,
			85,
			184,
			181,
			205,
			78,
			153,
			190,
			146,
			121,
			235,
			95,
			46,
			2,
			87,
			246,
			81,
			233,
			182,
			66,
			180,
			73,
			215,
			202,
			212,
			63,
			23,
			53,
			223,
			226,
			65,
			122,
			19,
			79,
			159,
			123,
			172,
			245,
			83,
			102,
			220,
			243,
			36,
			51,
			86,
			191,
			96,
			52,
			0,
			58,
			61,
			118,
			169,
			90,
			31,
			147,
			222,
			163,
			224,
			42,
			103,
			219,
			69,
			16,
			251,
			76,
			195,
			206,
			64,
			177,
			138,
			60,
			225,
			111,
			32,
			157,
			92,
			10,
			236,
			143,
			238,
			50,
			91,
			110,
			25,
			154,
			119,
			140,
			145,
			124,
			150,
			48,
			213,
			161,
			67,
			164,
			156,
			204,
			84,
			247,
			80,
			14,
			130,
			98,
			62,
			94,
			152,
			160,
			149,
			253,
			15,
			192,
			33,
			179,
			178,
			30,
			229,
			203,
			249,
			137,
			166,
			byte.MaxValue,
			72,
			217,
			26,
			101,
			71,
			113,
			244,
			89,
			74,
			21,
			135,
			117,
			44,
			17,
			125,
			108,
			132,
			189,
			162,
			231,
			197,
			112,
			116,
			38,
			139,
			216,
			254,
			171,
			9,
			35
		};

	}
}
