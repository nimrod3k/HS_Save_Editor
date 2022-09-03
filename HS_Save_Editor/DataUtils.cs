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
			data.values[(int)item] = HS_Save_Tools.ObfuscateValue(val);
		}

		internal static int TotalSteps = 0;
		internal static string filename = "";

	}
}
