using System.Windows.Forms;
using System.Reflection;
using HS_Tools;
using System.ComponentModel.Design.Serialization;

namespace HS_Save_Editor
{
    public partial class Form1 : Form
    {
		MapWindow? imageForm = null;
		FullMap? theMap = null;
		Collectibles theCollectibles = new Collectibles();
		List<string>? collected = new();
		List<string> uncollected = new();

		public Form1()
        {
            InitializeComponent();
			combo_SaveLocation.DataSource = Enum.GetValues(typeof(Maps));
			Collectibles.Initialize();

			HSGlobal.Init();
			if (!File.Exists(HSGlobal.CONFIG.rompath))
			{
				MessageBox.Show("ROM file not found, either Hero's Spirit is not installed or it is not installed in the default location please update the location of your Hero's Spirit Rom file");
				ConfigWindow config = new ConfigWindow();
				config.ShowDialog();
			}

			HSInit.InitializeDrawCode();
			combo_map.Items.Add("All");
			combo_map.Items.AddRange(Enum.GetNames(typeof(Maps)));
			combo_map.SelectedIndex = 0;
		}

		private GameType getGameType()
        {
			if (DataUtils.GetBoolValue(Vars.NGPPP))
            {
				return GameType.NGPPP;
			}
			if (DataUtils.GetBoolValue(Vars.NGPP))
			{
				return GameType.NGPP;
			}
			if (DataUtils.GetBoolValue(Vars.NGP))
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
				if ((int)id < DataUtils.GetValueCount())
				{
					var percent = CompletionCalculator.calculateIndividualpercent(id);

					string line = string.Format
						(
						"{0}({2}): {1}  impact%: {3}", id.ToString(),
						DataUtils.Get(id),
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
			List<Percent> percents = CompletionCalculator.calculateMissedpercent(DataUtils.GetValues());
			foreach (var percent in percents)
			{
				if (percent.vars == Vars.NGPPP || percent.vars == Vars.NGP || percent.vars == Vars.NGPP)
                {
					continue;
                }
				else if (percent.vars == Vars.TOTAL_NGP_TOKENS && DataUtils.Get(Vars.NGP) <= 0)
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
			if (!(DataUtils.Get(89) > 0 || DataUtils.Get(127) > 0))
				list_missedPercent.Items.Add(string.Format("{0}({2}) or {1}({3}): {4}%", (Vars)89, (Vars)127, DataUtils.Get(89), DataUtils.Get(127), 25f * CompletionCalculator.scale));
			if (!(DataUtils.Get(25) > 0 && DataUtils.Get(26) <= 0))
				list_missedPercent.Items.Add(string.Format("Bloodmoon Finished: {0}%", 25f * CompletionCalculator.scale));
			if (DataUtils.Get(144) != 0 && DataUtils.Get(149) != 0 && !(DataUtils.Get(54) > 0))
				list_missedPercent.Items.Add(
					string.Format("{0}({1}) (not NGP or NGPP): {2}%",
					(Vars)54,
					DataUtils.Get(54),
					CompletionCalculator.num2 * CompletionCalculator.scale)
					);
		}

		private void fillExtraPercent()
		{
			List<String> percents = CompletionCalculator.calculateExtraPercent(DataUtils.GetValues());
			list_xtraPercent.DataSource = percents;
		}

		private void calculatePercentages()
        {
			txt_percent.Text = CompletionCalculator.Calculate().ToString();
			txt_convergePercent.Text = CompletionCalculator.Calculate(true, false).ToString();
			txt_witchBasic.Text = CompletionCalculator.Calculate(false, false, false).ToString();
			txt_witchPerfect.Text = CompletionCalculator.Calculate(false, false, true).ToString();
		}

		private void fillTabEntities()
		{
			if (DataUtils.dataIsLoaded)
			{
				list_flags.Items.Clear();
				list_allitems.Items.Clear();
				collected = theCollectibles.getCollected();
				uncollected = theCollectibles.getUncollected();
				list_flags.Items.AddRange(collected.ToArray());
				list_allitems.Items.AddRange(uncollected.ToArray());

				// Get Count
				lbl_uncollectedCount.Text = list_allitems.Items.Count.ToString();
				lbl_collectedCount.Text = list_flags.Items.Count.ToString();
			}
		}

		private void fillTabItemsAndStories()
        {
            foreach (var item in DataUtils.SaveData.Equipment)
            {
                Type what = item.Value.GetType();

                if ((item.Value is not int) && (item.Value is not Int64))
                    chk_Equipment.Items.Add(item.Key, (bool)(item.Value));
                else
                {
                    // todo
                }
            }
            foreach (var item in DataUtils.SaveData.Items)
            {
                box_item.Items.Add(string.Format("{0}: {1}", item.Key, item.Value));
            }
            foreach (var item in DataUtils.SaveData.Story)
            {
                if ((item.Value is int) || (item.Value is Int64) || (item.Value is bool))
                    box_story.Items.Add(string.Format("{0}: {1}", item.Key, item.Value));
            }

        }

        private void fillTabValues()
        {
			fillAllValues();
			fillMissedPercent();
			fillExtraPercent();
		}

		private void fillTabBasic()
        {
			box_steps.Text = DataUtils.SaveData.Steps.ToString();
			box_time.Text = DataUtils.SaveData.Playtime.ToString();
			box_deaths.Value = DataUtils.SaveData.Deaths;
			box_kills.Value = DataUtils.SaveData.Kills;
			//chk_bHeart.Checked = DataUtils.GetBoolValue(Vars.GEM_HEART);
			//chk_bShield.Checked = DataUtils.GetBoolValue(Vars.GEM_SHIELD);
			//box_bShieldCharge.Value = DataUtils.Get(Vars.GEM_SHIELD);
			//chk_bSword.Checked = DataUtils.GetBoolValue(Vars.GEM_SWORD);
			//chk_rShield.Checked = DataUtils.GetBoolValue(Vars.RED_SHIELD);
			//chk_rSword.Checked = DataUtils.GetBoolValue(Vars.RED_SWORD);
			//chk_greenSword.Checked = DataUtils.GetBoolValue(Vars.GREEN_SWORD);
			//chk_greenShield.Checked = DataUtils.GetBoolValue(Vars.GREEN_SHIELD);
			//chk_witchEnding.Checked = DataUtils.GetBoolValue(Vars.WITCH_GEM_SWORD_3) ||
			//						DataUtils.GetBoolValue(Vars.WITCH_HAMMER) ||
			//						DataUtils.GetBoolValue(Vars.WITCH_WATER_RING) ||
			//						DataUtils.GetBoolValue(Vars.WITCH_PHASE2);
			//DataUtils.GetPosition(out Maps mapId, out string x, out string y, out string d);
			//txt_SaveLocationX.Text = x;
			//txt_SaveLocationY.Text = y;
			//txt_SaveLocationD.Text = d;
   //         combo_SaveLocation.SelectedItem = mapId;
   //         chk_bloodmoon.Checked = DataUtils.GetBoolValue(Vars.BLOODMOON_EFFECT);
			//txt_bloodmoonCount.Text = DataUtils.Get(Vars.BLOODMOON_COUNT).ToString();
			//calculatePercentages();
		}

		private void fillForm()
        {
			fillTabItemsAndStories();
			fillTabValues();
			fillTabEntities();
			fillTabBasic();
        }




		/****     General Events     ****/
		private void btn_loadSaveFile_Click(object sender, EventArgs e)
		{
			OpenFileDialog picker = new OpenFileDialog();
			picker.InitialDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Hero's Spirit\\Saves");

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

				DataUtils.Load();
				try
				{
					cb_GameMode.Items.Clear();
                    cb_GameMode.Items.AddRange(DataUtils.GetGameModes());
                    cb_GameMode.SelectedIndex = 0;
                    //Collectibles.gameMode = Enum.TryParse(typeof(Save), cb_GameMode.SelectedItem, out );

                    //fillTabCollectibles();
                    //fillTabValues();
                    //fillTabEntities();
                    //theCollectibles.addDoneCollectibles();
                    //fillForm();
                    //if (imageForm == null)
                    //{
                    //	imageForm = new MapWindow(getGameType());
                    //}
                }
                catch (Exception ex)
                {
					MessageBox.Show(ex.Message);
                }
			}
		}

		private void btn_save_Click(object sender, EventArgs e)
		{
			DataUtils.GetPosition(out int mapId, out int x, out int y, out int d );
			SaveFileDialog save = new SaveFileDialog();
			save.FileName = String.Format("{0}_new", DataUtils.filename);
			var result = save.ShowDialog();
			if (result == DialogResult.OK)
				DataUtils.Save(mapId, x, y, d, save.FileName);
		}
		
		private void btn_OpenMap_Click(object sender, EventArgs e)
		{
			if (theMap == null)
			{
				theMap = new FullMap();
			}
			theMap.Show();
		}


		/****     Entities Events  ****/
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
			fillTabEntities();
        }

		private void list_flags_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (list_flags.SelectedItem != null)
			{
				string flag = (string)list_flags.SelectedItem;
				string key = flag.Split("\'")[1];
				imageForm.UpdateMap(key, Collectibles.getCollectibleType(key));
				imageForm.Show();
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
			fillTabEntities();
		}

		private void btn_itemsLeft_Click(object sender, EventArgs e)
		{
			if (list_allitems.SelectedItem != null)
			{
				theCollectibles.collect((string)list_allitems.SelectedItem);
				list_flags.Items.Add((string)list_allitems.SelectedItem);
				list_allitems.Items.Remove(list_allitems.SelectedItem);
				fillTabItemsAndStories();
				fillTabValues();
				fillTabBasic();
			}

		}

		private void btn_itemsRight_Click(object sender, EventArgs e)
		{
			if (list_flags.SelectedItem != null)
			{
				theCollectibles.uncollect((string)list_flags.SelectedItem);
				list_allitems.Items.Add((string)list_flags.SelectedItem);
				list_flags.Items.Remove(list_flags.SelectedItem);
				//fillTabCollectibles();
				fillTabValues();
				fillTabBasic();
			}

		}

		/****     Basic Info Tab    ****/
		private void chk_bloodmoon_CheckedChanged(object sender, EventArgs e)
		{
			DataUtils.Set(Vars.BLOODMOON_EFFECT, chk_bloodmoon.Checked ? (byte)1 : (byte)0);
			fillAllValues();
		}
		private void txt_bloodmoonCount_TextChanged(object sender, EventArgs e)
		{
			if (txt_bloodmoonCount.Modified)
			{
				DataUtils.Set(Vars.BLOODMOON_COUNT, Convert.ToByte(txt_bloodmoonCount.Text));
				fillAllValues();
			}
		}

		private void chk_bHeart_CheckedChanged(object sender, EventArgs e)
        {
			DataUtils.Set(Vars.GEM_HEART, chk_bHeart.Checked ? (byte)1 : (byte)0);
			fillAllValues();
		}

		private void box_steps_TextChanged(object sender, EventArgs e)
        {
            int.TryParse(box_steps.Text, out int steps);
            DataUtils.SaveData.Steps = steps;
		}

		private void box_time_TextChanged(object sender, EventArgs e)
        {
			int.TryParse(box_time.Text, out int time);
			DataUtils.SaveData.Playtime = time;
		}

        private void box_deaths_ValueChanged(object sender, EventArgs e)
        {
			DataUtils.SaveData.Deaths = (int)box_deaths.Value;
		}

        private void box_kills_ValueChanged(object sender, EventArgs e)
        {
			DataUtils.SaveData.Kills = (int)box_kills.Value;
		}

        private void combo_SaveLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
			if (DataUtils.dataIsLoaded && (sender == combo_SaveLocation || txt_SaveLocationX.Modified || txt_SaveLocationY.Modified || txt_SaveLocationD.Modified))
				DataUtils.SetPosition((int)Enum.Parse(typeof(Maps), combo_SaveLocation.Text), txt_SaveLocationX.Text, txt_SaveLocationY.Text, txt_SaveLocationD.Text);
		}

		private void chk_witchEnding_CheckedChanged(object sender, EventArgs e)
        {
			if (chk_witchEnding.Checked)
			{
				DataUtils.Set(Vars.WITCH_GEM_SWORD_3, 1);
				DataUtils.Set(Vars.WITCH_HAMMER, 1);
				DataUtils.Set(Vars.WITCH_WATER_RING, 1);
				DataUtils.Set(Vars.WITCH_PHASE2, 1);
			}
			else
			{
				DataUtils.Set(Vars.WITCH_GEM_SWORD_3, 0);
				DataUtils.Set(Vars.WITCH_HAMMER, 0);
				DataUtils.Set(Vars.WITCH_WATER_RING, 0);
				DataUtils.Set(Vars.WITCH_PHASE2, 0);
			}
			fillAllValues();
		}

        private void btn_config_Click(object sender, EventArgs e)
        {
			ConfigWindow config = new ConfigWindow();
			config.Show();

        }

		private void cb_GameMode_SelectedIndexChanged(object sender, EventArgs e)
		{
			DataUtils.SetGameMode((string)cb_GameMode.SelectedItem);
			fillTabBasic();
            fillTabItemsAndStories();
        }

        private void box_item_DoubleClick(object sender, EventArgs e)
        {
            var item = ((string)(box_item.SelectedItem)).Split(':');
			var item_value = DataUtils.SaveData.Items[item[0]];

            itemEdit ie = new itemEdit(item[0], item_value.GetType(), item_value);
			ie.ShowDialog();
			if (ie.DialogResult== DialogResult.OK)
			{
				DataUtils.SaveData.Items[item[0]] = Convert.ToInt32(ie.ItemValue);
				box_item.Items[box_item.SelectedIndex] = string.Format("{0}: {1}", item[0],ie.ItemValue);
			}

        }

        private void box_story_DoubleClick(object sender, EventArgs e)
        {
            var item = ((string)(box_story.SelectedItem)).Split(':');
            var item_value = DataUtils.SaveData.Story[item[0]];

            itemEdit ie = new itemEdit(item[0], item_value.GetType(), item_value);
            ie.ShowDialog();
            if (ie.DialogResult == DialogResult.OK)
            {
				if (item_value.GetType() == typeof(bool))
				{
					DataUtils.SaveData.Story[item[0]] = Convert.ToBoolean(ie.ItemValue);
				}
				if (item_value.GetType() == typeof(int) || item_value.GetType() == typeof(long))
				{
					DataUtils.SaveData.Story[item[0]] = Convert.ToInt64(ie.ItemValue);
				}
                box_story.Items[box_story.SelectedIndex] = string.Format("{0}: {1}", item[0], ie.ItemValue);
            }
        }
    }
}