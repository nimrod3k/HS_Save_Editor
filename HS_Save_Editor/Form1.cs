using System.Windows.Forms;
using System.Reflection;
using HS_Tools;

namespace HS_Save_Editor
{
    public partial class Form1 : Form
    {
		HSJsonData? theData = null;
		MapWindow? imageForm = null;
		FullMap? theMap = null;
		Collectibles theCollectibles;
		List<string> collected = new();
		List<string> uncollected = new();

		public Form1()
        {
            InitializeComponent();
			combo_SaveLocation.DataSource = Enum.GetValues(typeof(Maps));
			Collectibles.Initialize();

			theCollectibles = new Collectibles();
			HSInit.InitializeDrawCode();
			combo_map.Items.Add("All");
			combo_map.Items.AddRange(Enum.GetNames(typeof(Maps)));
			combo_map.SelectedIndex = 0;
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
			list_flags.Items.Clear();
			list_allitems.Items.Clear();
			collected = theCollectibles.getCollected();
			uncollected = theCollectibles.getUncollected();
			list_flags.Items.AddRange(collected.ToArray());
			list_allitems.Items.AddRange(uncollected.ToArray());
			//foreach (string line in allCollectibles)
			//{
			//	if (!doneCollectibles.Contains(line))
			//		undoneCollectibles.Add(line);
			//}
			//foreach (string line in undoneCollectibles)
   //         {
			//	if (checkFilter(line) && checkMap(line))
			//		list_allitems.Items.Add(line);
   //         }
			//foreach (string line in doneCollectibles)
			//{
			//	if (checkFilter(line) && checkMap(line))
			//		list_flags.Items.Add(line);
			//}
		}

		private void fillForm(HSJsonData data)
        {
            theData = data;

			theCollectibles.addDoneCollectibles(theData.flags);


			box_hearts.Value = (decimal)DataUtils.Get(data.values[(int)Vars.HEARTS]);
			box_steps.Text = DataUtils.TotalSteps.ToString();
            box_swords.Value = (decimal)DataUtils.Get(data.values[(int)Vars.SWORDS]);
			chk_preventNight.Checked = DataUtils.GetBoolValue(data.values[(int)Vars.PREVENTED_NIGHT]);
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


		private void update_data()
		{
			DataUtils.TotalSteps = int.Parse(box_steps.Text);
			DataUtils.Set(ref theData, Vars.SWORDS, (byte)box_swords.Value);
			DataUtils.Set(ref theData, Vars.TOTAL_SWORDS, (byte)box_swords.Value);
			DataUtils.Set(ref theData, Vars.PREVENTED_NIGHT, chk_preventNight.Checked ? (byte)1 : (byte)0);
			
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
			var collected = theCollectibles.getCollectedForSave();
			foreach (string key in collected.Keys)
			{
				bool val = collected[key];
				theData.flags.Add(key, val);
			}
		}





		/****     General Events     ****/
		private void btn_loadSaveFile_Click(object sender, EventArgs e)
		{
			OpenFileDialog picker = new OpenFileDialog();
			picker.InitialDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Hero's Spirit");// @"C:\Users\nimro\source\repos\HS_Save_Editor\HS_Save_Editor"; // Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location),@"..\..\");

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

		private void btn_save_Click(object sender, EventArgs e)
		{
			update_data();
			var positions = theData.position.Split('.');
			if (positions != null && positions.Length > 3)
			{
				SaveFileDialog save = new SaveFileDialog();
				save.FileName = String.Format("{0}_new", DataUtils.filename);
				save.ShowDialog();
				string savefile = DataUtils.Save(theData, int.Parse(positions[0]), int.Parse(positions[1]), int.Parse(positions[2]), int.Parse(positions[3]), save.FileName);
			}
			else
				MessageBox.Show("Failed to export due to bad position");

		}
		
		private void btn_OpenMap_Click(object sender, EventArgs e)
		{
			if (theMap == null)
			{
				theMap = new FullMap();
			}
			theMap.Show();
		}


		/****     Item Flag Events  ****/
		private void chk_feature_filter_CheckedChanged(object sender, EventArgs e)
        {
			theCollectibles.filters[CollectName.gdoor] = chk_feature_gdoor.Checked;
			theCollectibles.filters[CollectName.unknown] = chk_feature_unknown.Checked;
			theCollectibles.filters[CollectName.heart] = chk_feature_hearts.Checked;
			theCollectibles.filters[CollectName.sdoor] = chk_feature_sdoor.Checked;
			theCollectibles.filters[CollectName.gkey] = chk_feature_gkey.Checked;
			theCollectibles.filters[CollectName.skey] = chk_feature_skey.Checked;
			theCollectibles.filters[CollectName.pstone] = chk_feature_portals.Checked;
			theCollectibles.filters[CollectName.sword] = chk_feature_swords.Checked;
			theCollectibles.filters[CollectName.gem] = chk_feature_Gems.Checked;
			theCollectibles.filters[CollectName.treasure] = chk_feature_treasures.Checked;
			theCollectibles.filters[CollectName.pcoin] = chk_feature_pcoin.Checked;
			theCollectibles.otherFilter = chk_feature_other.Checked;
			theCollectibles.keyItemsFilter = chk_feature_keyItems.Checked;
			fillAllFlags();
        }

		private void list_flags_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (list_flags.SelectedItem != null)
			{
				string flag = (string)list_flags.SelectedItem;
				string key = flag.Split("\'")[1];
				imageForm.UpdateMap(key, Collectibles.getCollectibleType(key));
				imageForm.Show();
				imageForm.TopMost = true;
			}
		}

		private void list_allitems_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (list_allitems.SelectedItem != null)
			{
				string flag = (string)list_allitems.SelectedItem;
				string key = flag.Split("\'")[1];
				imageForm.UpdateMap(key, Collectibles.getCollectibleType(key));
				imageForm.Show();
				imageForm.TopMost = true;
			}
		}

		private void tab_saveData_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (imageForm != null)
				imageForm.Hide();
		}

		private void combo_map_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (combo_map.SelectedIndex == 0)
				theCollectibles.mapFilter = 0;
			else
				theCollectibles.mapFilter = (int)Enum.Parse(typeof(Maps), (string)combo_map.SelectedItem);
			fillAllFlags();
		}

		private void btn_itemsLeft_Click(object sender, EventArgs e)
		{
			if (list_allitems.SelectedItem != null)
			{
				theCollectibles.collect((string)list_allitems.SelectedItem);
				list_flags.Items.Add((string)list_allitems.SelectedItem);
				list_allitems.Items.Remove(list_allitems.SelectedItem);
			}
		}

		private void btn_itemsRight_Click(object sender, EventArgs e)
		{
			if (list_flags.SelectedItem != null)
			{
				theCollectibles.uncollect((string)list_flags.SelectedItem);
				list_allitems.Items.Add((string)list_flags.SelectedItem);
				list_flags.Items.Remove(list_flags.SelectedItem);
			}
		}

	}
}