using System.Windows.Forms;
using System.Reflection;
using HS_Tools;
using System.ComponentModel.Design.Serialization;

namespace HS_Save_Editor
{
    public partial class mainForm : Form
    {
		public static bool initialized = false;
		MapWindow? imageForm = null;
		FullMap? theMap = null;
		Collectibles theCollectibles = new Collectibles();
		List<string>? collected = new();
		List<string> uncollected = new();

		public mainForm()
        {
            HSGlobal.Init();
            if (!Directory.Exists(HSGlobal.CONFIG.appPath))
            {
                MessageBox.Show("ROM file not found, either Hero's Spirit is not installed or it is not installed in the default location please update the location of your Hero's Spirit Rom file");
                ConfigWindow config = new ConfigWindow();
                config.ShowDialog();
            }

            HSGlobal.Initialize();

            InitializeComponent();
            Collectibles.Initialize();


			combo_map.Items.Add("All");
			combo_map.Items.AddRange(HSGlobal.Maps.Keys.ToArray());
			combo_map.SelectedIndex = 0;
			initialized = true;
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


        private void fillTabValues()
        {
			fillAllValues();
			fillMissedPercent();
			fillExtraPercent();
		}

		private void fillForm()
        {
			cBasicInfo.fillBasicTab();
			cStory.fillStoryTab();
			cEquipment.fillEquipmentTab();
			cItems.fillItemTab();
			//fillTabValues();
			//fillTabEntities();
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
			SaveFileDialog save = new SaveFileDialog();
			save.FileName = String.Format("{0}_new", DataUtils.filename);
			var result = save.ShowDialog();
			if (result == DialogResult.OK)
				DataUtils.Save(save.FileName, (string)cb_GameMode.SelectedItem);
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
				theCollectibles.mapFilter = HSGlobal.Maps[(string)combo_map.SelectedItem];
			fillTabEntities();
		}

		private void btn_itemsLeft_Click(object sender, EventArgs e)
		{
			// todo
			//if (list_allitems.SelectedItem != null)
			//{
			//	theCollectibles.collect((string)list_allitems.SelectedItem);
			//	list_flags.Items.Add((string)list_allitems.SelectedItem);
			//	list_allitems.Items.Remove(list_allitems.SelectedItem);
			//	fillTabItemsAndStories();
			//	fillTabValues();
			//	fillTabBasic();
			//}

		}

		private void btn_itemsRight_Click(object sender, EventArgs e)
		{
			//todo
			//if (list_flags.SelectedItem != null)
			//{
			//	theCollectibles.uncollect((string)list_flags.SelectedItem);
			//	list_allitems.Items.Add((string)list_flags.SelectedItem);
			//	list_flags.Items.Remove(list_flags.SelectedItem);
			//	//fillTabCollectibles();
			//	fillTabValues();
			//	fillTabBasic();
			//}

		}


		//private void chk_witchEnding_CheckedChanged(object sender, EventArgs e)
  //      {
		//	if (chk_witchEnding.Checked)
		//	{
		//		DataUtils.Set(Vars.WITCH_GEM_SWORD_3, 1);
		//		DataUtils.Set(Vars.WITCH_HAMMER, 1);
		//		DataUtils.Set(Vars.WITCH_WATER_RING, 1);
		//		DataUtils.Set(Vars.WITCH_PHASE2, 1);
		//	}
		//	else
		//	{
		//		DataUtils.Set(Vars.WITCH_GEM_SWORD_3, 0);
		//		DataUtils.Set(Vars.WITCH_HAMMER, 0);
		//		DataUtils.Set(Vars.WITCH_WATER_RING, 0);
		//		DataUtils.Set(Vars.WITCH_PHASE2, 0);
		//	}
		//	fillAllValues();
		//}

        private void btn_config_Click(object sender, EventArgs e)
        {
			ConfigWindow config = new ConfigWindow();
			config.Show();

        }

		private void cb_GameMode_SelectedIndexChanged(object sender, EventArgs e)
		{
			DataUtils.SetGameMode((string)cb_GameMode.SelectedItem);
			fillForm();
        }

    }
}