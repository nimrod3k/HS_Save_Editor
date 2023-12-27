using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
//using HS.Utils;
using Microsoft.CSharp.RuntimeBinder;
using Newtonsoft.Json;
using HS_Tools;
using System.Security.Cryptography;
using ICSharpCode.SharpZipLib.GZip;
using Microsoft.VisualBasic.Logging;
using System.Reflection;

namespace HS_Save_Editor
{
	internal static class DataUtils
	{
		private static SaveBundle? _SaveBundle = null;

		public static Save? SaveData = null;
        private static HSJsonData? hsdata = null;
		internal static bool dataIsLoaded { get { return hsdata != null; } }

		// Initialize the DataUtils Variables
		internal static void Initialize(string filename)
		{
			DataUtils.filename = filename;
			DataUtils.TotalSteps = 0;
			HS_Save_Tools.Initialize();
		}

		internal static string[] GetGameModes()
		{
            List<string> strings = new List<string>();
            if (_SaveBundle.OG != null)
                strings.Add("NG");
            if (_SaveBundle.Plus != null)
                strings.Add("NG+");
            if (_SaveBundle.Plus2 != null)
                strings.Add("NG++");
            if (_SaveBundle.Minus != null)
                strings.Add("NG-");
            if (_SaveBundle.Bunny != null)
                strings.Add("Bunny");


			return strings.ToArray();
        }

		internal static void SetGameMode(string gameMode)
		{
			if (gameMode == "NG")
				SaveData = _SaveBundle.OG;
			if (gameMode == "NG+")
				SaveData = _SaveBundle.Plus;
			if (gameMode == "NG++")
				SaveData = _SaveBundle.Plus2;
			if (gameMode == "NG-")
				SaveData = _SaveBundle.Minus;
			if (gameMode == "Bunny")
				SaveData = _SaveBundle.Bunny;
		}


		internal static void SaveGameMode(string gameMode)
		{
			if (SaveData is not null)
			{
				if (gameMode == "NG")
					_SaveBundle.OG = SaveData;
				if (gameMode == "NG+")
					_SaveBundle.Plus = SaveData;
				if (gameMode == "NG++")
					_SaveBundle.Plus2 = SaveData;
				if (gameMode == "NG-")
					_SaveBundle.Minus = SaveData;
				if (gameMode == "Bunny")
					_SaveBundle.Bunny = SaveData;
			}
		}

        /// <summary>
        /// Loads Save File
        /// </summary>
        /// <returns></returns>
        internal static void Load()
		{
			if (filename != null)
			{
				byte[] data = File.ReadAllBytes(filename);
                string value = HS_Save_Tools.DecompressJson(data);
                _SaveBundle = JsonConvert.DeserializeObject<SaveBundle>(value);

                //DataUtils.TotalSteps = int.Parse(text.Substring(0, 10));
				if (_SaveBundle != null)
				{

					/*hsdata = (HSJsonData?)JsonConvert.DeserializeObject(saveData, typeof(HSJsonData));
					if (hsdata != null && hsdata.values != null)
					{
						byte[] values = hsdata.values;
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
							hsdata.values = values;
						}
						if (hsdata.label == null)
						{
							hsdata.label = "";
						}
					}*/
				}
			}
		}

		internal static string Save(string? file, string gameMode)
		{
            string saveFile = filename + "_new";
            if (!string.IsNullOrEmpty(file))
                saveFile = file;

            string json = JsonConvert.SerializeObject(_SaveBundle);
			byte[] bytes = HS_Save_Tools.CompressJson(json);
			File.WriteAllBytes(saveFile, bytes);
		
			return saveFile;
		}

		internal static byte Get(Vars var)
		{
			return Get((int)var);
		}

		internal static byte Get(int var)
		{
			return HS_Save_Tools.DeobfuscateValue(hsdata.values[var]);
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
			if ((int)item < hsdata.values.Length)
				hsdata.values[(int)item] = HS_Save_Tools.ObfuscateValue(val);
		}

		internal static void Set(int item, byte val)
		{
			Set((Vars)item, (byte)val);
		}

		internal static int TotalSteps = 0;

		internal static string? filename { get; private set; }

		internal static int GetValueCount()
        {
			return hsdata.values.Length;
        }

		internal static byte[] GetValues()
        {
			if (hsdata.values != null)
				return hsdata.values;
			else
				return new byte[0];
        }

		internal static string GetPlaytime()
        {
			return string.Format
				(
				"{0}:{1}:{2}",
				hsdata.playtime / 3600,
				(hsdata.playtime % 3600) / 60,
				(hsdata.playtime % 3600) % 60
				);
		}

		internal static void SetPlaytime(string timeString)
		{
			var splitTime = timeString.Split(':');
			hsdata.playtime = (Convert.ToInt64(splitTime[0]) * 3600) + (Convert.ToInt64(splitTime[1]) * 60) + Convert.ToInt64(splitTime[2]);
		}
		internal static int GetDeaths()
        {
			return hsdata.deaths;
		}

		internal static void SetDeaths(int deaths)
		{
			hsdata.deaths = deaths;
		}
		internal static int GetKills()
        {
			return hsdata.kills;
        }

		internal static void SetKills(int kills)
		{
			hsdata.kills = kills;
		}
		internal static int GetPositionMap()
		{
			return Convert.ToInt32(hsdata.position.Split('.')[0]);
		}
		internal static string GetPositionX()
		{
			return hsdata.position.Split('.')[1];
		}
		internal static string GetPositionY()
		{
			return hsdata.position.Split('.')[2];
		}

		internal static string GetPositionDirection()
		{
			return hsdata.position.Split('.')[3];
		}

		internal static string? GetPosition()
		{
			return hsdata.position;
		}

		internal static void GetPosition(out int mapId, out int x, out int y, out Direction d)
		{
            mapId = SaveData.PlayerLocation.MapId;
            x = SaveData.PlayerLocation.X;
			y = SaveData.PlayerLocation.X;
            d = SaveData.PlayerLocation.Direction;
        }

		internal static void SetPosition(int mapId, string x, string y, string d)
		{
			hsdata.position = String.Format("{0}.{1}.{2}.{3}",
				mapId,
				x,
				y,
				d
			);
		}

		internal static Dictionary<string, bool>? GetFlags()
        {
			if (dataIsLoaded)
				return hsdata.flags;
			return null;
        }

		internal static void SetFlags(Dictionary<string,bool> collected)
        {
			hsdata.flags.Clear();
			foreach (string key in collected.Keys)
			{
				bool val = collected[key];
				hsdata.flags.Add(key, val);
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
			if (!hsdata.flags.ContainsKey(key))
			{
				hsdata.flags.Add(key, value);
			}
			else
            {
				throw new Exception("Key already exists on AddFlag");
            }
		}

        internal static void RemoveFlag(string key)
        {
            hsdata.flags.Remove(key);
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
