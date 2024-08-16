using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
//using HS.Utils;
using Microsoft.CSharp.RuntimeBinder;
using System.Text.Json;
using HS_Tools;

namespace HS_Save_Editor
{
	internal static class DataUtils
	{
		private static HSJsonData? data = null;
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
			string text = File.ReadAllText(filename);
			DataUtils.TotalSteps = int.Parse(text.Substring(0, 10));
			string saveData = Unscramble(text);
			if (saveData != null)
			{

				data = JsonSerializer.Deserialize<HSJsonData>(saveData);
				if (data != null && data.values != null)
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

		internal static string Save(int mapId, int x, int y, int d, string? file = null)
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
			text = text + "\"values\": " + JsonSerializer.Serialize(data.values);
			text = text + ", \"hearts\": " + JsonSerializer.Serialize(data.hearts);
			text = text + ", \"flags\": " + JsonSerializer.Serialize(data.flags);
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

		internal static string? filename { get; private set; }

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

		internal static string? GetPosition()
		{
			return data.position;
		}

		internal static void GetPosition(out Maps mapId, out string x, out string y, out string d)
		{
			string[] position = ((string)data.position.Clone()).Split('.');
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

		internal static Dictionary<string, bool>? GetFlags()
        {
			if (dataIsLoaded)
				return data.flags;
			return null;
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
		private static void incrementValue(Vars item, int incNum = 1)
		{
			int maxval = byte.MaxValue;
			if (item == Vars.HEARTS)
				maxval = 64;

			var count = Get(item);
			if (count + incNum < maxval)
			{
				count = Convert.ToByte(count + incNum);
				Set(item, count);
			}
		}

		private static void decrementValue(Vars item, int decNum = 1)
		{
			var count = Get(item);
			if ((count - decNum) >= 0)
			{
				count = Convert.ToByte(count - decNum);
				Set(item, count);
			}
		}

		internal static void Collect(CollectName item)
        {
			switch (item)
			{
				case CollectName.heart:
					incrementValue(Vars.HEARTS);
					break;
				case CollectName.gdoor:
					incrementValue(Vars.TOTAL_GOLD_DOORS);
					decrementValue(Vars.GOLD_KEYS);
					break;
				case CollectName.sdoor:
					incrementValue(Vars.TOTAL_SILVER_DOORS);
					decrementValue(Vars.SILVER_KEYS);
					break;
				case CollectName.gkey:
					incrementValue(Vars.TOTAL_GOLD_KEYS);
					incrementValue(Vars.GOLD_KEYS);
					break;
				case CollectName.skey:
					incrementValue(Vars.TOTAL_SILVER_KEYS);
					incrementValue(Vars.SILVER_KEYS);
					break;
				case CollectName.pstone:
					incrementValue(Vars.PORTAL_STONES);
					break;
				case CollectName.sword:
					incrementValue(Vars.TOTAL_SWORDS);
					incrementValue(Vars.SWORDS);
					break;
				case CollectName.gem:
					incrementValue(Vars.TOTAL_GEMS);
					incrementValue(Vars.GEMS);
					break;
				case CollectName.treasure:
					incrementValue(Vars.TOTAL_TREASURES);
					incrementValue(Vars.TREASURES);
					break;
				case CollectName.pcoin:
					incrementValue(Vars.TOTAL_POSSUM_COINS);
					incrementValue(Vars.POSSUM_COINS);
					break;
				case CollectName.goldsword:
					Set(Vars.GOLD_SWORD, 1);
					break;
				case CollectName.shield:
					Set(Vars.SHIELD, 1);
					break;
				case CollectName.greengem:
					incrementValue(Vars.SECRET_TOKENS);
					break;
				case CollectName.greengemlock:
					incrementValue(Vars.SECRET_SOCKETS);
					decrementValue(Vars.SECRET_TOKENS);
					break;
				case CollectName.trianglekey:
					incrementValue(Vars.NGP_TOKENS);
					incrementValue(Vars.TOTAL_NGP_TOKENS);
					break;
				case CollectName.trianglelock:
					decrementValue(Vars.NGP_TOKENS);
					break;
				case CollectName.triangledoor:
					break;
				case CollectName.tealkey:
					incrementValue(Vars.TOTAL_TEAL_KEYS);
					incrementValue(Vars.TEAL_KEYS);
					break;
				case CollectName.purplekey:
					incrementValue(Vars.TOTAL_PURPLE_KEYS);
					incrementValue(Vars.PURPLE_KEYS);
					break;
				case CollectName.tealdoor:
					incrementValue(Vars.TOTAL_TEAL_DOORS);
					decrementValue(Vars.TEAL_KEYS);
					break;
				case CollectName.purpledoor:
					incrementValue(Vars.TOTAL_PURPLE_DOORS);
					decrementValue(Vars.PURPLE_KEYS);
					break;
				case CollectName.bluekey:
					incrementValue(Vars.TOTAL_BLUE_KEYS);
					incrementValue(Vars.BLUE_KEYS);
					break;
				case CollectName.redkey:
					incrementValue(Vars.TOTAL_RED_KEYS);
					incrementValue(Vars.RED_KEYS);
					break;
				case CollectName.greenkey:
					incrementValue(Vars.TOTAL_GREEN_KEYS);
					incrementValue(Vars.GREEN_KEYS);
					break;
				case CollectName.bluedoor:
					incrementValue(Vars.TOTAL_BLUE_DOORS);
					decrementValue(Vars.BLUE_KEYS);
					break;
				case CollectName.reddoor:
					incrementValue(Vars.TOTAL_RED_DOORS);
					decrementValue(Vars.RED_KEYS);
					break;
				case CollectName.greendoor:
					incrementValue(Vars.TOTAL_GREEN_DOORS);
					decrementValue(Vars.GREEN_KEYS);
					break;
				case CollectName.smugglers_eye:
					Set(Vars.COLLECTOR_EYE, 1);
					break;
				case CollectName.skeleton_key:
					Set(Vars.SKELETON_KEY, 1);
					break;
				case CollectName.hammer:
					Set(Vars.HAMMERS, 1);
					break;
				case CollectName.wind_ring:
					Set(Vars.WATER_RING, 1);
					break;
				case CollectName.lava_charm:
					Set(Vars.LAVA_CHARMS, 1);
					break;
				case CollectName.compass:
					Set(Vars.COMPASSES, 1);
					break;
				case CollectName.boots:
					Set(Vars.BOOTS, 1);
					break;
				case CollectName.BoBS:
					Set(Vars.GEM_BOOTS, 1);
					break;
				case CollectName.spectacles:
					Set(Vars.SPECTACLES, 1);
					break;
				case CollectName.red_boots:
					Set(Vars.RED_BOOTS, 1);
					break;
				case CollectName.blue_sword:
					Set(Vars.GEM_SWORD, 1);
					break;
				case CollectName.blue_shield:
					Set(Vars.GEM_SHIELD, 3);
					break;
				case CollectName.blue_heart:
					Set(Vars.GEM_HEART, 1);
					break;
				case CollectName.red_sword:
					Set(Vars.RED_SHIELD, 1);
					break;
				case CollectName.red_shield:
					Set(Vars.RED_SHIELD, 1);
					break;
				case CollectName.green_sword:
					Set(Vars.GREEN_SWORD, 1);
					break;
				case CollectName.green_shield:
					Set(Vars.GREEN_SHIELD, 1);
					break;
				case CollectName.save_crystals:
					Set(Vars.SAVE_CRYSTAL, 1);
					break;
				case CollectName.carrot:
					Set(Vars.CARROT, 1);
					break;
				case CollectName.mirror:
					Set(Vars.MIRROR, 1);
					break;
				case CollectName.broom:
					Set(Vars.BROOM, 1);
					decrementValue(Vars.POSSUM_COINS,5);
					break;
				case CollectName.fishingrod:
					Set(Vars.FISHING_POLE, 1);
					break;
				case CollectName.fish:
					Set(Vars.FISH, 1);
					break;
				default:
					break;
			}
        }

        internal static void AddFlag(string key, bool value)
        {
			if (!data.flags.ContainsKey(key))
			{
				data.flags.Add(key, value);
			}
			else
            {
				throw new Exception("Key already exists on AddFlag");
            }
		}

        internal static void RemoveFlag(string key)
        {
            data.flags.Remove(key);
        }

        internal static void Uncollect(CollectName item)
		{
			switch (item)
			{
				case CollectName.heart:
					decrementValue(Vars.HEARTS);
					break;
				case CollectName.gdoor:
					decrementValue(Vars.TOTAL_GOLD_DOORS);
					incrementValue(Vars.GOLD_KEYS);
					break;
				case CollectName.sdoor:
					decrementValue(Vars.TOTAL_SILVER_DOORS);
					incrementValue(Vars.SILVER_KEYS);
					break;
				case CollectName.gkey:
					decrementValue(Vars.TOTAL_GOLD_KEYS);
					decrementValue(Vars.GOLD_KEYS);
					break;
				case CollectName.skey:
					decrementValue(Vars.TOTAL_SILVER_KEYS);
					decrementValue(Vars.SILVER_KEYS);
					break;
				case CollectName.pstone:
					decrementValue(Vars.PORTAL_STONES);
					break;
				case CollectName.sword:
					decrementValue(Vars.TOTAL_SWORDS);
					decrementValue(Vars.SWORDS);
					break;
				case CollectName.gem:
					decrementValue(Vars.TOTAL_GEMS);
					decrementValue(Vars.GEMS);
					break;
				case CollectName.treasure:
					decrementValue(Vars.TOTAL_TREASURES);
					decrementValue(Vars.TREASURES);
					break;
				case CollectName.pcoin:
					decrementValue(Vars.TOTAL_POSSUM_COINS);
					decrementValue(Vars.POSSUM_COINS);
					break;
				case CollectName.goldsword:
					Set(Vars.GOLD_SWORD, 0);
					break;
				case CollectName.shield:
					Set(Vars.SHIELD, 0);
					break;
				case CollectName.greengem:
					decrementValue(Vars.SECRET_TOKENS);
					break;
				case CollectName.greengemlock:
					decrementValue(Vars.SECRET_SOCKETS);
					incrementValue(Vars.SECRET_TOKENS);
					break;
				case CollectName.trianglekey:
					decrementValue(Vars.NGP_TOKENS);
					decrementValue(Vars.TOTAL_NGP_TOKENS);
					break;
				case CollectName.trianglelock:
					incrementValue(Vars.NGP_TOKENS);
					break;
				case CollectName.triangledoor:
					break;
				case CollectName.tealkey:
					decrementValue(Vars.TOTAL_TEAL_KEYS);
					decrementValue(Vars.TEAL_KEYS);
					break;
				case CollectName.purplekey:
					decrementValue(Vars.TOTAL_PURPLE_KEYS);
					decrementValue(Vars.PURPLE_KEYS);
					break;
				case CollectName.tealdoor:
					decrementValue(Vars.TOTAL_TEAL_DOORS);
					incrementValue(Vars.TEAL_KEYS);
					break;
				case CollectName.purpledoor:
					decrementValue(Vars.TOTAL_PURPLE_DOORS);
					incrementValue(Vars.PURPLE_KEYS);
					break;
				case CollectName.bluekey:
					decrementValue(Vars.TOTAL_BLUE_KEYS);
					decrementValue(Vars.BLUE_KEYS);
					break;
				case CollectName.redkey:
					decrementValue(Vars.TOTAL_RED_KEYS);
					decrementValue(Vars.RED_KEYS);
					break;
				case CollectName.greenkey:
					decrementValue(Vars.TOTAL_GREEN_KEYS);
					decrementValue(Vars.GREEN_KEYS);
					break;
				case CollectName.bluedoor:
					decrementValue(Vars.TOTAL_BLUE_DOORS);
					incrementValue(Vars.BLUE_KEYS);
					break;
				case CollectName.reddoor:
					decrementValue(Vars.TOTAL_RED_DOORS);
					incrementValue(Vars.RED_KEYS);
					break;
				case CollectName.greendoor:
					decrementValue(Vars.TOTAL_GREEN_DOORS);
					incrementValue(Vars.GREEN_KEYS);
					break;
				case CollectName.smugglers_eye:
					Set(Vars.COLLECTOR_EYE, 0);
					break;
				case CollectName.skeleton_key:
					Set(Vars.SKELETON_KEY, 0);
					break;
				case CollectName.hammer:
					Set(Vars.HAMMERS, 0);
					break;
				case CollectName.wind_ring:
					Set(Vars.WATER_RING, 0);
					break;
				case CollectName.lava_charm:
					Set(Vars.LAVA_CHARMS, 0);
					break;
				case CollectName.compass:
					Set(Vars.COMPASSES, 0);
					break;
				case CollectName.boots:
					Set(Vars.BOOTS, 0);
					break;
				case CollectName.BoBS:
					Set(Vars.GEM_BOOTS, 0);
					break;
				case CollectName.spectacles:
					Set(Vars.SPECTACLES, 0);
					break;
				case CollectName.red_boots:
					Set(Vars.RED_BOOTS, 0);
					break;
				case CollectName.blue_sword:
					Set(Vars.GEM_SWORD, 0);
					break;
				case CollectName.blue_shield:
					Set(Vars.GEM_SHIELD, 0);
					break;
				case CollectName.blue_heart:
					Set(Vars.GEM_HEART, 0);
					break;
				case CollectName.red_sword:
					Set(Vars.RED_SHIELD, 0);
					break;
				case CollectName.red_shield:
					Set(Vars.RED_SHIELD, 0);
					break;
				case CollectName.green_sword:
					Set(Vars.GREEN_SWORD, 0);
					break;
				case CollectName.green_shield:
					Set(Vars.GREEN_SHIELD, 0);
					break;
				case CollectName.save_crystals:
					Set(Vars.SAVE_CRYSTAL, 0);
					break;
				case CollectName.carrot:
					Set(Vars.CARROT, 0);
					break;
				case CollectName.mirror:
					Set(Vars.MIRROR, 0);
					break;
				case CollectName.broom:
					Set(Vars.BROOM, 0);
					incrementValue(Vars.POSSUM_COINS, 5);
					break;
				case CollectName.fishingrod:
					Set(Vars.FISHING_POLE, 0);
					break;
				case CollectName.fish:
					Set(Vars.FISH, 0);
					break;
				default:
					break;
			}
		}

	}
}
