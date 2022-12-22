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
		internal static HSJsonData? data = null;
		internal static bool dataIsLoaded { get { return data != null; } }

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
		internal static void Load()
		{
			data = new HSJsonData();
			string text = File.ReadAllText(DataUtils.filename);
			DataUtils.TotalSteps = int.Parse(text.Substring(0, 10));
			string saveData = Unscramble(text);
			if (saveData != null)
			{

				data = (HSJsonData)JsonConvert.DeserializeObject(saveData, typeof(HSJsonData));
				if (data != null)
				{
					byte[] values = data.values;
					bool flag = values.Length < Enum.GetNames(typeof(Vars)).Length;
					if (flag)
					{
						int k = values.Length;
						Array.Resize<byte>(ref values, Enum.GetNames(typeof(Vars)).Length);
						while (k < values.Length)
						{
							DataUtils.Set((Vars)k, 0);
							k++;
						}
						data.values = values;
					}
					if (data.label == null)
					{
						data.label = "";
					}
				}
			}
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

		internal static string Save(int mapId, int x, int y, int d, string file = null)
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
			if (!string.IsNullOrEmpty(file))
				saveFile = file;
			File.WriteAllText(saveFile, text);
			return saveFile;
		}

		internal static byte Get(Vars var)
		{
			return Get((int)var);
		}

		internal static byte Get(int var)
		{
			return HS_Save_Tools.DeobfuscateValue(data.values[var]);
		}
		internal static bool GetBoolValue(Vars var)
		{
			return GetBoolValue((int)var);
		}

		internal static bool GetBoolValue(int var)
		{
			return DataUtils.Get(var) != 0 ? true : false;
		}

		internal static void Set(Vars item, byte val)
		{
			if ((int)item < data.values.Length)
				data.values[(int)item] = HS_Save_Tools.ObfuscateValue(val);
		}

		internal static void Set(int item, byte val)
		{
			Set((Vars)item, (byte)val);
		}

		internal static int TotalSteps = 0;

		internal static string filename { get; private set; }

		internal static int GetValueCount()
        {
			return data.values.Length;
        }

		internal static byte[] GetValues()
        {
			if (data.values != null)
				return data.values;
			else
				return new byte[0];
        }

		internal static string GetPlaytime()
        {
			return string.Format
				(
				"{0}:{1}:{2}",
				data.playtime / 3600,
				(data.playtime % 3600) / 60,
				(data.playtime % 3600) % 60
				);
		}

		internal static void SetPlaytime(string timeString)
		{
			var splitTime = timeString.Split(':');
			data.playtime = (Convert.ToInt64(splitTime[0]) * 3600) + (Convert.ToInt64(splitTime[1]) * 60) + Convert.ToInt64(splitTime[2]);
		}
		internal static int GetDeaths()
        {
			return data.deaths;
		}

		internal static void SetDeaths(int deaths)
		{
			data.deaths = deaths;
		}
		internal static int GetKills()
        {
			return data.kills;
        }

		internal static void SetKills(int kills)
		{
			data.kills = kills;
		}
		internal static Maps GetPositionMap()
		{
			return (Maps)Convert.ToInt64(data.position.Split('.')[0]);
		}
		internal static string GetPositionX()
		{
			return data.position.Split('.')[1];
		}
		internal static string GetPositionY()
		{
			return data.position.Split('.')[2];
		}

		internal static string GetPositionDirection()
		{
			return data.position.Split('.')[3];
		}

		internal static string GetPosition()
		{
			return data.position;
		}

		internal static void GetPosition(out Maps mapId, out string x, out string y, out string d)
		{
			string[] position = data.position.Split('.');
			mapId = (Maps)Convert.ToInt64(position[0]);
			x = position[1];
			y = position[2];
			d = position[3];
		}
		internal static void GetPosition(out int mapId, out int x, out int y, out int d)
		{
			GetPosition(out Maps map, out string xs, out string ys, out string ds);
			mapId = (int)map;
			x = Convert.ToInt32(xs);
			y = Convert.ToInt32(ys);
			d = Convert.ToInt32(ds);
		}
		internal static void SetPosition(int mapId, string x, string y, string d)
		{
			data.position = String.Format("{0}.{1}.{2}.{3}",
				mapId,
				x,
				y,
				d
			);
		}

		internal static Dictionary<string, bool> GetFlags()
        {
			return data.flags;
        }

		internal static void SetFlags(Dictionary<string,bool> collected)
        {
			data.flags.Clear();
			foreach (string key in collected.Keys)
			{
				bool val = collected[key];
				data.flags.Add(key, val);
			}

		}


	}
}
