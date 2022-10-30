using System.Windows.Forms;
using System.Reflection;
using HS_Tools;

namespace HS_Save_Editor
{
    public partial class Form1 : Form
    {
		HSJsonData? theData = null;
		List<string> allCollectibles = new List<string>();
		List<string> doneCollectibles = new List<string>();
		List<string> undoneCollectibles = new List<string>();
		MapWindow imageForm = null;
		FullMap theMap = null;

		public Form1()
        {
            InitializeComponent();
			combo_SaveLocation.DataSource = Enum.GetValues(typeof(Maps));
			load_allCollectibles();
			HSInit.InitializeDrawCode();
        }

		private void load_allCollectibles()
        {
			allCollectibles.Clear();
			allCollectibles = File.ReadAllLines("flags.txt").ToList<string>();

			foreach (string line in DataUtils.gdoor_coords)
            {
				DataUtils.mapFeatures.Add(line,"Gold Door");
			}
			foreach (string line in DataUtils.gem_coords)
			{
				DataUtils.mapFeatures.Add(line, "Gem");
			}
			foreach (string line in DataUtils.gkey_coords)
			{
				DataUtils.mapFeatures.Add(line, "Gold Key");
			}
			foreach (string line in DataUtils.heart_coords)
			{
				DataUtils.mapFeatures.Add(line, "Heart");
			}
			foreach (string line in DataUtils.portal_st_coords)
			{
				DataUtils.mapFeatures.Add(line, "Portal Stone");
			}
			foreach (string line in DataUtils.sdoor_coords)
			{
				DataUtils.mapFeatures.Add(line, "Silver Door");
			}
			foreach (string line in DataUtils.skey_coords)
			{
				DataUtils.mapFeatures.Add(line, "Silver Key");
			}
			foreach (string line in DataUtils.sword_coords)
			{
				DataUtils.mapFeatures.Add(line, "Sword");
			}
			foreach (string line in DataUtils.treasure_coords)
			{
				DataUtils.mapFeatures.Add(line, "Treasure");
			}

		}

		private void load_doneCollectibles()
		{
			doneCollectibles.Clear();
			foreach (string key in theData.flags.Keys)
			{

				string[] key_parts = key.Split('.');

				string line = string.Format
					(
					"({0})'{1}': {2}",
					(Maps)Convert.ToInt64(key_parts[0]),
					key,
					theData.flags[key]
					);
				doneCollectibles.Add(line);
			}
			bool update = false;
			foreach (string line in doneCollectibles)
			{
				if (!allCollectibles.Contains(line))
				{
					update = true;
					allCollectibles.Add(line);
				}
			}
			if (update)
				File.WriteAllLines("flags.txt", (List<string>)allCollectibles.Cast<string>().ToList());

		}
		private GameType getGameType()
        {
			if (DataUtils.GetBoolValue(theData.values[(int)Vars.NGPPP]))
            {
				return GameType.NGPPP;
			}
			if (DataUtils.GetBoolValue(theData.values[(int)Vars.NGPP]))
			{
				return GameType.NGPP;
			}
			if (DataUtils.GetBoolValue(theData.values[(int)Vars.NGP]))
			{
				return GameType.NGP;
			}

			return GameType.NG;
        }
		private void btn_loadSaveFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog picker = new OpenFileDialog();
			picker.InitialDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),"Hero's Spirit");// @"C:\Users\nimro\source\repos\HS_Save_Editor\HS_Save_Editor"; // Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location),@"..\..\");

            if (picker.ShowDialog() == DialogResult.OK)
            {
				if (imageForm != null)
				{
					imageForm.Close();
					imageForm.Dispose();
					imageForm = null;
				}

				string file = picker.FileName;
                DataUtils.Initialize(file);

                HSJsonData theData = DataUtils.Load();
                fillForm(theData);
				if (imageForm == null)
                {
					imageForm = new MapWindow(getGameType());
                }
            }
        }

		private void fillAllValues()
        {
			list_values.Items.Clear();
			foreach (Vars id in Enum.GetValues(typeof(Vars)))
			{
				if ((int)id < theData.values.Length)
				{
					var percent = CompletionCalculator.calculateIndividualpercent(theData.values, id);

					string line = string.Format
						(
						"{0}({2}): {1}  impact%: {3}", id.ToString(),
						DataUtils.Get(theData.values[(int)id]),
						(int)id,
						percent
						);
					list_values.Items.Add(line);
				}
			}
		}

		private void fillMissedPercent()
        {
			list_missedPercent.Items.Clear();
			List<Percent> percents = CompletionCalculator.calculateMissedpercent(theData.values);
			foreach (var percent in percents)
			{
				if (percent.vars == Vars.NGPPP || percent.vars == Vars.NGP || percent.vars == Vars.NGPP)
                {
					continue;
                }
				else if (percent.vars == Vars.TOTAL_NGP_TOKENS && DataUtils.Get(theData.values[(int)Vars.NGP]) <= 0)
                {
					continue;
				}
				if (percent.multiplier >= 0)
				{
					string mult = (percent.multiplier * CompletionCalculator.scale).ToString();
					if (percent.condition == Condition.None)
					{
						mult += " * number";

					}
					string line = string.Format
						(
						"{0}({1}): {2}%", percent.vars.ToString(),
						(int)percent.vars,
						mult
						);
					list_missedPercent.Items.Add(line);
				}
			}
			if (!(DataUtils.Get(theData.values[89]) > 0 || DataUtils.Get(theData.values[127]) > 0))
				list_missedPercent.Items.Add(string.Format("{0}({2}) or {1}({3}): {4}%", (Vars)89, (Vars)127, DataUtils.Get(theData.values[89]), DataUtils.Get(theData.values[127]), 25f * CompletionCalculator.scale));
			if (!(DataUtils.Get(theData.values[25]) > 0 && DataUtils.Get(theData.values[26]) <= 0))
				list_missedPercent.Items.Add(string.Format("Bloodmoon Finished: {0}%", 25f * CompletionCalculator.scale));
			if (DataUtils.Get(theData.values[144]) != 0 && DataUtils.Get(theData.values[149]) != 0 && !(DataUtils.Get(theData.values[54]) > 0))
				list_missedPercent.Items.Add(
					string.Format("{0}({1}) (not NGP or NGPP): {2}%",
					(Vars)54,
					DataUtils.Get(theData.values[54]),
					CompletionCalculator.num2 * CompletionCalculator.scale)
					);
		}

		private void fillExtraPercent()
		{
			List<String> percents = CompletionCalculator.calculateExtraPercent(theData.values);
			list_xtraPercent.DataSource = percents;
		}

		private void fillAllFlags()
        {
			undoneCollectibles.Clear();
			list_flags.Items.Clear();
			list_allitems.Items.Clear();

			foreach (string line in allCollectibles)
			{
				if (!doneCollectibles.Contains(line))
					undoneCollectibles.Add(line);
			}
			foreach (string line in undoneCollectibles)
            {
				if (checkFilter(line) && checkMap(line))
					list_allitems.Items.Add(line);
            }
			foreach (string line in doneCollectibles)
			{
				if (checkFilter(line) && checkMap(line))
					list_flags.Items.Add(line);
			}
		}

		private bool checkFilter(string coord)
        {
			string item = coord.Split(")")[1].Split(":")[0].Trim('\'');
			if (DataUtils.mapFeatures.ContainsKey(item))
			{
				if (
					(DataUtils.mapFeatures[item] == "Gold Door" && chk_feature_gdoor.Checked) ||
					(DataUtils.mapFeatures[item] == "Gem" && chk_feature_Gems.Checked) ||
					(DataUtils.mapFeatures[item] == "Gold Key" && chk_feature_gkey.Checked) ||
					(DataUtils.mapFeatures[item] == "Heart" && chk_feature_hearts.Checked) ||
					(DataUtils.mapFeatures[item] == "Portal Stone" && chk_feature_portals.Checked) ||
					(DataUtils.mapFeatures[item] == "Silver Door" && chk_feature_sdoor.Checked) ||
					(DataUtils.mapFeatures[item] == "Silver Key" && chk_feature_skey.Checked) ||
					(DataUtils.mapFeatures[item] == "Swords" && chk_feature_swords.Checked) ||
					(DataUtils.mapFeatures[item] == "Treasure" && chk_feature_treasures.Checked)
					)
				{
					return true;
				}
				else if (chk_feature_keyItems.Checked)
                {
					return true;
                }
			}
			else if (chk_feature_unknown.Checked)
				return true;
			return false;
		}
		private bool checkMap(string coord)
		{
			Maps mapID = (Maps)Convert.ToInt32(coord.Split(")")[1].Split(":")[0].Trim('\'').Split(".")[0]);
			if (
				(mapID == Maps.CASTLE_GROUNDS && chk_feature_CG.Checked) ||
				(mapID == Maps.THE_TUNDRA && chk_feature_Tun.Checked) ||
				(mapID == Maps.NORTH_MUNDEMAN && chk_feature_NM.Checked)
				)
			{
				return true;
			}
			else if (chk_feature_unknown.Checked &&
				(mapID != Maps.CASTLE_GROUNDS && mapID != Maps.THE_TUNDRA && mapID != Maps.NORTH_MUNDEMAN)
				)
				return true;
			return false;
		}
		private void fillForm(HSJsonData data)
        {
			list_flags.Items.Clear();
			list_values.Items.Clear();

            theData = data;

			load_doneCollectibles();


			box_hearts.Value = (decimal)DataUtils.Get(data.values[(int)Vars.HEARTS]);
			box_steps.Text = DataUtils.TotalSteps.ToString();
            box_swords.Value = (decimal)DataUtils.Get(data.values[(int)Vars.SWORDS]);
            string time =
            box_time.Text = string.Format
                (
                "{0}:{1}:{2}",
                data.playtime / 3600,
                (data.playtime % 3600) / 60,
                (data.playtime % 3600) % 60
                );
			box_deaths.Value = data.deaths;
			box_kills.Value = data.kills;
			chk_bHeart.Checked = DataUtils.GetBoolValue(data.values[(int)Vars.GEM_HEART]);
            chk_bobs.Checked = DataUtils.GetBoolValue(data.values[(int)Vars.GEM_BOOTS]);
            chk_boots.Checked = DataUtils.GetBoolValue(data.values[(int)Vars.BOOTS]);
			chk_bShield.Checked = DataUtils.GetBoolValue(data.values[(int)Vars.GEM_SHIELD]);
			box_bShieldCharge.Value = DataUtils.Get(data.values[(int)Vars.GEM_SHIELD]);
			chk_bSword.Checked = DataUtils.GetBoolValue(data.values[(int)Vars.GEM_SWORD]);
            chk_hammer.Checked = DataUtils.GetBoolValue(data.values[(int)Vars.HAMMERS]);
            chk_lavaCharm.Checked = DataUtils.GetBoolValue(data.values[(int)Vars.LAVA_CHARMS]);
            chk_rShield.Checked = DataUtils.GetBoolValue(data.values[(int)Vars.RED_SHIELD]);
            chk_rSword.Checked = DataUtils.GetBoolValue(data.values[(int)Vars.RED_SWORD]);
			chk_windRing.Checked = DataUtils.GetBoolValue(data.values[(int)Vars.WATER_RING]);
			chk_compass.Checked = DataUtils.GetBoolValue(data.values[(int)Vars.COMPASSES]);
			chk_spectacles.Checked = DataUtils.GetBoolValue(data.values[(int)Vars.SPECTACLES]);
			chk_skeletonKey.Checked = DataUtils.GetBoolValue(data.values[(int)Vars.SKELETON_KEY]);
			chk_smugglersEye.Checked = DataUtils.GetBoolValue(data.values[(int)Vars.COLLECTOR_EYE]);
			chk_broom.Checked = DataUtils.GetBoolValue(data.values[(int)Vars.BROOM]);
			chk_mirror.Checked = DataUtils.GetBoolValue(data.values[(int)Vars.MIRROR]);
			chk_saveCrystals.Checked = DataUtils.GetBoolValue(data.values[(int)Vars.SAVE_CRYSTAL]);
			chk_greenSword.Checked = DataUtils.GetBoolValue(data.values[(int)Vars.GREEN_SWORD]);
			chk_greenShield.Checked = DataUtils.GetBoolValue(data.values[(int)Vars.GREEN_SHIELD]);
			chk_witchEnding.Checked = DataUtils.GetBoolValue(data.values[(int)Vars.WITCH_GEM_SWORD_3]) ||
									DataUtils.GetBoolValue(data.values[(int)Vars.WITCH_HAMMER]) || 
									DataUtils.GetBoolValue(data.values[(int)Vars.WITCH_WATER_RING]) ||
									DataUtils.GetBoolValue(data.values[(int)Vars.WITCH_PHASE2]);
			string[] position = data.position.Split('.');
			combo_SaveLocation.SelectedItem = (Maps)Convert.ToInt64(position[0]);
			txt_SaveLocationX.Text = position[1];
			txt_SaveLocationY.Text = position[2];
			txt_SaveLocationD.Text = position[3];
			txt_portalStones.Text = GetCollectibleValues(Vars.TOTAL_PORTAL_STONES, Vars.PORTAL_STONES);
			txt_Gems.Text = GetCollectibleValues(Vars.TOTAL_GEMS, Vars.GEMS);
			txt_goldKey.Text = GetCollectibleValues(Vars.TOTAL_GOLD_KEYS, Vars.GOLD_KEYS);
			txt_possum.Text = GetCollectibleValues(Vars.TOTAL_POSSUM_COINS, Vars.POSSUM_COINS);
			txt_silverKey.Text = GetCollectibleValues(Vars.TOTAL_SILVER_KEYS, Vars.SILVER_KEYS);
			txt_treasure.Text = GetCollectibleValues(Vars.TOTAL_TREASURES, Vars.TREASURES);


			fillAllValues();
			fillMissedPercent();
			fillExtraPercent();


			fillAllFlags();
			txt_percent.Text = CompletionCalculator.Calculate(data.values).ToString();
			txt_convergePercent.Text = CompletionCalculator.Calculate(data.values, true, false).ToString();
			txt_witchBasic.Text = CompletionCalculator.Calculate(data.values, false, false, false).ToString();
			txt_witchPerfect.Text = CompletionCalculator.Calculate(data.values, false, false, true).ToString();

			var save_location = data.label;
            var savePosition = data.position;
        }

		private string GetCollectibleValues(Vars total, Vars current)
		{
			string collectible = "";
			if (theData != null)
			{
				int col_total = DataUtils.Get(theData.values[(int)total]);
				int col_current = DataUtils.Get(theData.values[(int)current]);

				collectible = string.Format
					(
					"{0}/{1}/{2}",
					col_current,
					col_total - col_current,
					col_total
					);

			}
			return collectible;
		}

		private void SetCollectibleValues(string collectible, Vars total, Vars current)
        {
			if (theData != null)
			{
				string[] collectible_split = collectible.Split('/');
				byte col_total = Convert.ToByte(collectible_split[2]);
				byte col_current = Convert.ToByte(collectible_split[0]);
				DataUtils.Set(ref theData, total, col_total);
				DataUtils.Set(ref theData, current, col_current);
			}
		}

		private void btn_save_Click(object sender, EventArgs e)
        {
			update_data();
			var positions = theData.position.Split('.');
			if (positions != null && positions.Length > 3)
				DataUtils.Save(theData, int.Parse(positions[0]), int.Parse(positions[1]), int.Parse(positions[2]), int.Parse(positions[3]));
		}

		private void update_data()
		{
			DataUtils.TotalSteps = int.Parse(box_steps.Text);
			DataUtils.Set(ref theData, Vars.SWORDS, (byte)box_swords.Value);
			var splitTime = box_time.Text.Split(':');
			theData.playtime = (Convert.ToInt64(splitTime[0]) * 3600) + (Convert.ToInt64(splitTime[1]) * 60) + Convert.ToInt64(splitTime[2]);
			theData.deaths = (int)box_deaths.Value;
			theData.kills = (int)box_kills.Value;
			theData.position = String.Format("{0}.{1}.{2}.{3}",
				(int)Enum.Parse(typeof(Maps), combo_SaveLocation.Text),
				txt_SaveLocationX.Text,
				txt_SaveLocationY.Text,
				txt_SaveLocationD.Text
			);
			DataUtils.Set(ref theData, Vars.GEM_HEART, chk_bHeart.Checked ? (byte)1 : (byte)0);
			DataUtils.Set(ref theData, Vars.GEM_BOOTS, chk_bobs.Checked ? (byte)1 : (byte)0);
			DataUtils.Set(ref theData, Vars.BOOTS, chk_boots.Checked ? (byte)1 : (byte)0);
			DataUtils.Set(ref theData, Vars.GEM_SHIELD, chk_bShield.Checked ? (byte)box_bShieldCharge.Value : (byte)0x00);
			DataUtils.Set(ref theData, Vars.GEM_SWORD, chk_bSword.Checked ? (byte)1 : (byte)0);
			DataUtils.Set(ref theData, Vars.HAMMERS, chk_hammer.Checked ? (byte)1 : (byte)0);
			DataUtils.Set(ref theData, Vars.LAVA_CHARMS, chk_lavaCharm.Checked ? (byte)1 : (byte)0);
			DataUtils.Set(ref theData, Vars.RED_SHIELD, chk_rShield.Checked ? (byte)1 : (byte)0);
			DataUtils.Set(ref theData, Vars.RED_SWORD, chk_rSword.Checked ? (byte)1 : (byte)0);
			DataUtils.Set(ref theData, Vars.WATER_RING, chk_windRing.Checked ? (byte)1 : (byte)0);
			DataUtils.Set(ref theData, Vars.COMPASSES, chk_compass.Checked ? (byte)1 : (byte)0);
			DataUtils.Set(ref theData, Vars.SPECTACLES, chk_spectacles.Checked ? (byte)1 : (byte)0);
			DataUtils.Set(ref theData, Vars.SKELETON_KEY, chk_skeletonKey.Checked ? (byte)1 : (byte)0);
			DataUtils.Set(ref theData, Vars.COLLECTOR_EYE, chk_smugglersEye.Checked ? (byte)1 : (byte)0);
			DataUtils.Set(ref theData, Vars.BROOM, chk_broom.Checked ? (byte)1 : (byte)0);
			DataUtils.Set(ref theData, Vars.MIRROR, chk_mirror.Checked ? (byte)1 : (byte)0);
			DataUtils.Set(ref theData, Vars.SAVE_CRYSTAL, chk_saveCrystals.Checked ? (byte)1 : (byte)0);
			DataUtils.Set(ref theData, Vars.GREEN_SWORD, chk_greenSword.Checked ? (byte)1 : (byte)0);
			DataUtils.Set(ref theData, Vars.GREEN_SHIELD, chk_greenSword.Checked ? (byte)1 : (byte)0);
			if (chk_witchEnding.Checked)
			{
				DataUtils.Set(ref theData, Vars.WITCH_GEM_SWORD_3, 1);
				DataUtils.Set(ref theData, Vars.WITCH_HAMMER, 1);
				DataUtils.Set(ref theData, Vars.WITCH_WATER_RING, 1);
				DataUtils.Set(ref theData, Vars.WITCH_PHASE2, 1);
			}
			else
            {
				DataUtils.Set(ref theData, Vars.WITCH_GEM_SWORD_3, 0);
				DataUtils.Set(ref theData, Vars.WITCH_HAMMER, 0);
				DataUtils.Set(ref theData, Vars.WITCH_WATER_RING, 0);
				DataUtils.Set(ref theData, Vars.WITCH_PHASE2, 0);
			}

			SetCollectibleValues(txt_portalStones.Text, Vars.TOTAL_PORTAL_STONES, Vars.PORTAL_STONES);
			SetCollectibleValues(txt_Gems.Text, Vars.TOTAL_GEMS, Vars.GEMS);
			SetCollectibleValues(txt_goldKey.Text, Vars.TOTAL_GOLD_KEYS, Vars.GOLD_KEYS);
			SetCollectibleValues(txt_possum.Text, Vars.TOTAL_POSSUM_COINS, Vars.POSSUM_COINS);
			SetCollectibleValues(txt_silverKey.Text, Vars.TOTAL_SILVER_KEYS, Vars.SILVER_KEYS);
			SetCollectibleValues(txt_treasure.Text, Vars.TOTAL_TREASURES, Vars.TREASURES);

			theData.flags.Clear();
			foreach (string item in doneCollectibles)
			{
				string[] temp = item.Split(')')[1].Replace("\'","").Split(':');
				string key = temp[0];
				bool val = Convert.ToBoolean(temp[1]);
				theData.flags.Add(key, val);
			}
		}

		private void btn_itemsLeft_Click(object sender, EventArgs e)
		{
			if (list_allitems.SelectedItem != null)
			{
				list_flags.Items.Add(list_allitems.SelectedItem);
				allCollectibles.RemoveAt(list_allitems.SelectedIndex);
			}
		}

        private void btn_itemsRight_Click(object sender, EventArgs e)
        {
			if (list_flags.SelectedItem != null)
			{
				allCollectibles.Add((string)list_flags.SelectedItem);
				list_flags.Items.RemoveAt(list_flags.SelectedIndex);
			}
		}


        private void button1_Click(object sender, EventArgs e)
        {
			string stuff = "";
			foreach (var heart in theData.hearts)
            {
				stuff += string.Format("\"{0}\"\n", heart);
            }
			MessageBox.Show(stuff);
        }

        private void chk_feature_filter_CheckedChanged(object sender, EventArgs e)
        {
			fillAllFlags();
        }

        private void list_allitems_SelectedIndexChanged(object sender, EventArgs e)
        {
			string flag = (string)list_allitems.SelectedItem;

			imageForm.UpdateMap(flag.Split("\'")[1]);
			imageForm.Show();
			imageForm.TopMost = true;
        }

        private void tab_saveData_SelectedIndexChanged(object sender, EventArgs e)
        {
			if (imageForm != null)
				imageForm.Hide();
        }

		private void btn_OpenMap_Click(object sender, EventArgs e)
		{
			if (theMap == null)
			{
				theMap = new FullMap();
			}
			theMap.Show();
		}
	}
}