using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
//using HS.Utils;
using Microsoft.CSharp.RuntimeBinder;
using Newtonsoft.Json;
using HS_Tools;

namespace HS_Save_Editor
{
	internal static class DataUtils
	{
		// Initialize the DataUtils Variables
		internal static void Initialize(string filename)
		{
			DataUtils.filename = filename;
			DataUtils.TotalSteps = 0;
			HS_Save_Tools.Initialize();
		}

		/// <summary>
		/// Loads Save File
		/// </summary>
		/// <returns></returns>
		internal static HSJsonData Load()
		{
			HSJsonData jsonData = new HSJsonData();
			string text = File.ReadAllText(DataUtils.filename);
			DataUtils.TotalSteps = int.Parse(text.Substring(0, 10));
			string saveData = Unscramble(text);
			if (saveData != null)
			{

				jsonData = (HSJsonData)JsonConvert.DeserializeObject(saveData, typeof(HSJsonData));
				if (jsonData != null)
				{
					byte[] values = jsonData.values;
					bool flag = values.Length < Enum.GetNames(typeof(Vars)).Length;
					if (flag)
					{
						int k = values.Length;
						Array.Resize<byte>(ref values, Enum.GetNames(typeof(Vars)).Length);
						while (k < values.Length)
						{
							DataUtils.Set(ref jsonData, (Vars)k, 0);
							k++;
						}
						jsonData.values = values;
					}
					if (jsonData.label == null)
					{
						jsonData.label = "";
					}

					return jsonData;

				}
			}
			return new HSJsonData();
		}

		internal static string Unscramble(string text)
		{
			string text2 = text.Substring(10);
			string text3 = text2.Substring(0, 4);
			for (int i = 0; i <= (text2.Length - 4) / 8; i++)
			{
				string s = text2.Substring(Math.Min(text2.Length - 1, i * 8 + 4), Math.Min(8, text2.Length - (i * 8 + 4)));
				text3 += HS_Save_Tools.Decode(s, DataUtils.TotalSteps + i);
			}
			text2 = text3;
			text3 = "";
			for (int j = 0; j <= text2.Length / 8; j++)
			{
				string s2 = text2.Substring(j * 8, Math.Min(8, text2.Length - j * 8));
				text3 += HS_Save_Tools.Decode(s2, DataUtils.TotalSteps + j);
			}
			return text3;
		}

		internal static void Save(HSJsonData data, int mapId, int x, int y, int d)
		{
			string text = "";
			string text2 = "";

			text = string.Concat(new string[]
			{
				text,
				"{\"position\": \"",
				mapId.ToString(),
				".",
				x.ToString(),
				".",
				y.ToString(),
				".",
				d.ToString(),
				"\", "
			});
			text = text + "\"values\": " + JsonConvert.SerializeObject(data.values);
			text = text + ", \"hearts\": " + JsonConvert.SerializeObject(data.hearts);
			text = text + ", \"flags\": " + JsonConvert.SerializeObject(data.flags);
			text = text + ", \"playtime\": " + data.playtime.ToString();
			text = text + ", \"deaths\": " + data.deaths.ToString();
			text = text + ", \"label\": \"" + data.label + "\"}";
			for (int i = 0; i <= text.Length / 8; i++)
			{
				string s = text.Substring(i * 8, Math.Min(8, text.Length - i * 8));
				text2 += HS_Save_Tools.Encode(s, DataUtils.TotalSteps + i);
			}

			text = DataUtils.TotalSteps.ToString("D10") + text2.Substring(0, 4);
			for (int j = 0; j <= (text2.Length - 4) / 8; j++)
			{
				string s2 = text2.Substring(Math.Min(text2.Length - 1, j * 8 + 4), Math.Min(8, text2.Length - (j * 8 + 4)));
				text += HS_Save_Tools.Encode(s2, DataUtils.TotalSteps + j);
			}

			string saveFile = filename + "_new";
			File.WriteAllText(saveFile, text);

		}

		internal static byte Get(byte value)
		{
			return HS_Save_Tools.DeobfuscateValue(value);
		}

		internal static bool GetBoolValue(byte value)
		{
			return DataUtils.Get(value) != 0 ? true : false;
		}

		internal static void Set(ref HSJsonData data, Vars item, byte val)
		{
			if ((int)item < data.values.Length)
				data.values[(int)item] = HS_Save_Tools.ObfuscateValue(val);
		}

		internal static void Set(ref HSJsonData data, int item, byte val)
		{
			Set(ref data, (Vars)item, (byte)val);
		}

		internal static int TotalSteps = 0;
		internal static string filename = "";

		internal static List<string> heart_coords = new List<string>()
		{
			"4.31.54","4.60.65","4.61.10","4.22.5","4.15.75","10.73.44","10.41.59","10.17.65","10.51.70","10.42.112","10.78.115","10.95.92","10.114.101","10.97.79","10.82.26","10.89.13","10.79.1","10.103.2","14.12.87","14.38.102"
		};
		internal static List<string> gdoor_coords = new List<string>()
		{
			"10.2.19","10.9.18","10.50.12","10.40.115","10.38.59","10.45.56"
		};
		internal static List<string> sdoor_coords = new List<string>()
		{
			"10.43.56"
		};
		internal static List<string> gkey_coords = new List<string>()
		{
			"10.1.1", "10.44.11", "10.39.57"
		};
		internal static List<string> skey_coords = new List<string>()
		{
			"10.2.6","10.1.27"
		};
		internal static List<string> portal_st_coords = new List<string>()
		{
			"10.10.1", "10.1.17", "10.4.23", "10.40.12", "10.42.9",
			"6.10.15"
		};
		internal static List<string> sword_coords = new List<string>()
		{
			"10.28.1", "10.6.2", "10.1.16"
		};
		internal static List<string> gem_coords = new List<string>()
		{
			"10.9.3","10.1.5","10.2.22","10.2.24","10.40.67"
		};
		internal static List<string> treasure_coords = new List<string>()
		{
			"6.11.16"
		};

		internal static Dictionary<string, string> mapFeatures = new Dictionary<string, string>()
		{
			{ "6.11.7", "Blue Key"}
		};
	}
}
