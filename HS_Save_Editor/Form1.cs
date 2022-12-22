using System.Windows.Forms;
using System.Reflection;
using HS_Tools;

namespace HS_Save_Editor
{
    public partial class Form1 : Form
    {
		MapWindow? imageForm = null;
		FullMap? theMap = null;
		Collectibles theCollectibles = new Collectibles();
		List<string> collected = new();
		List<string> uncollected = new();

		public Form1()
        {
            InitializeComponent();
			combo_SaveLocation.DataSource = Enum.GetValues(typeof(Maps));
			Collectibles.Initialize();

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

		private void fillForm()
        {
			theCollectibles.addDoneCollectibles();


			box_hearts.Value = (decimal)DataUtils.Get(Vars.HEARTS);
			box_steps.Text = DataUtils.TotalSteps.ToString();
            box_swords.Value = (decimal)DataUtils.Get(Vars.SWORDS);
			chk_preventNight.Checked = DataUtils.GetBoolValue(Vars.PREVENTED_NIGHT);


			box_time.Text = DataUtils.GetPlaytime();
			box_deaths.Value = DataUtils.GetDeaths();
			box_kills.Value = DataUtils.GetKills();
			chk_bHeart.Checked = DataUtils.GetBoolValue(Vars.GEM_HEART);
            chk_bobs.Checked = DataUtils.GetBoolValue(Vars.GEM_BOOTS);
            chk_boots.Checked = DataUtils.GetBoolValue(Vars.BOOTS);
			chk_bShield.Checked = DataUtils.GetBoolValue(Vars.GEM_SHIELD);
			box_bShieldCharge.Value = DataUtils.Get(Vars.GEM_SHIELD);
			chk_bSword.Checked = DataUtils.GetBoolValue(Vars.GEM_SWORD);
            chk_hammer.Checked = DataUtils.GetBoolValue(Vars.HAMMERS);
            chk_lavaCharm.Checked = DataUtils.GetBoolValue(Vars.LAVA_CHARMS);
            chk_rShield.Checked = DataUtils.GetBoolValue(Vars.RED_SHIELD);
            chk_rSword.Checked = DataUtils.GetBoolValue(Vars.RED_SWORD);
			chk_windRing.Checked = DataUtils.GetBoolValue(Vars.WATER_RING);
			chk_compass.Checked = DataUtils.GetBoolValue(Vars.COMPASSES);
			chk_spectacles.Checked = DataUtils.GetBoolValue(Vars.SPECTACLES);
			chk_skeletonKey.Checked = DataUtils.GetBoolValue(Vars.SKELETON_KEY);
			chk_smugglersEye.Checked = DataUtils.GetBoolValue(Vars.COLLECTOR_EYE);
			chk_broom.Checked = DataUtils.GetBoolValue(Vars.BROOM);
			chk_carrot.Checked = DataUtils.GetBoolValue(Vars.CARROT);
			chk_mirror.Checked = DataUtils.GetBoolValue(Vars.MIRROR);
			chk_saveCrystals.Checked = DataUtils.GetBoolValue(Vars.SAVE_CRYSTAL);
			chk_greenSword.Checked = DataUtils.GetBoolValue(Vars.GREEN_SWORD);
			chk_greenShield.Checked = DataUtils.GetBoolValue(Vars.GREEN_SHIELD);
			chk_witchEnding.Checked = DataUtils.GetBoolValue(Vars.WITCH_GEM_SWORD_3) ||
									DataUtils.GetBoolValue(Vars.WITCH_HAMMER) || 
									DataUtils.GetBoolValue(Vars.WITCH_WATER_RING) ||
									DataUtils.GetBoolValue(Vars.WITCH_PHASE2);
			DataUtils.GetPosition(out Maps mapId, out string x, out string y, out string d);
			combo_SaveLocation.SelectedItem = mapId;
			txt_SaveLocationX.Text = x;
			txt_SaveLocationY.Text = y;
			txt_SaveLocationD.Text = d;
			txt_portalStones.Text = GetCollectibleValues(Vars.TOTAL_PORTAL_STONES, Vars.PORTAL_STONES);
			txt_Gems.Text = GetCollectibleValues(Vars.TOTAL_GEMS, Vars.GEMS);
			txt_goldKey.Text = GetCollectibleValues(Vars.TOTAL_GOLD_KEYS, Vars.GOLD_KEYS);
			txt_greenGem.Text = String.Format("{0}/{1}", DataUtils.Get(Vars.SECRET_TOKENS).ToString(), DataUtils.Get(Vars.SECRET_SOCKETS).ToString());
			txt_triangle.Text = GetCollectibleValues(Vars.TOTAL_NGP_TOKENS, Vars.NGP_TOKENS);
			txt_possum.Text = GetCollectibleValues(Vars.TOTAL_POSSUM_COINS, Vars.POSSUM_COINS);
			txt_silverKey.Text = GetCollectibleValues(Vars.TOTAL_SILVER_KEYS, Vars.SILVER_KEYS);
			txt_treasure.Text = GetCollectibleValues(Vars.TOTAL_TREASURES, Vars.TREASURES);


			fillAllValues();
			fillMissedPercent();
			fillExtraPercent();


			fillAllFlags();
			txt_percent.Text = CompletionCalculator.Calculate().ToString();
			txt_convergePercent.Text = CompletionCalculator.Calculate(true, false).ToString();
			txt_witchBasic.Text = CompletionCalculator.Calculate(false, false, false).ToString();
			txt_witchPerfect.Text = CompletionCalculator.Calculate(false, false, true).ToString();
        }

		private string GetCollectibleValues(Vars total, Vars current)
		{
			string collectible = "";
			if ( DataUtils.dataIsLoaded)
			{
				int col_total = DataUtils.Get(total);
				int col_current = DataUtils.Get(current);

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
			if (DataUtils.dataIsLoaded)
			{
				string[] collectible_split = collectible.Split('/');
				byte col_total = Convert.ToByte(collectible_split[2]);
				byte col_current = Convert.ToByte(collectible_split[0]);
				DataUtils.Set(total, col_total);
				DataUtils.Set(current, col_current);
			}
		}


		private void update_data()
		{
			DataUtils.TotalSteps = int.Parse(box_steps.Text);
			DataUtils.Set(Vars.SWORDS, (byte)box_swords.Value);
			DataUtils.Set(Vars.TOTAL_SWORDS, (byte)box_swords.Value);
			DataUtils.Set(Vars.PREVENTED_NIGHT, chk_preventNight.Checked ? (byte)1 : (byte)0);
			
			DataUtils.SetPlaytime(box_time.Text);
			DataUtils.SetDeaths((int)box_deaths.Value);
			DataUtils.SetKills((int)box_kills.Value);
			DataUtils.SetPosition((int)Enum.Parse(typeof(Maps), combo_SaveLocation.Text), txt_SaveLocationX.Text, txt_SaveLocationY.Text, txt_SaveLocationD.Text);
			DataUtils.Set(Vars.GEM_HEART, chk_bHeart.Checked ? (byte)1 : (byte)0);
			DataUtils.Set(Vars.GEM_BOOTS, chk_bobs.Checked ? (byte)1 : (byte)0);
			DataUtils.Set(Vars.BOOTS, chk_boots.Checked ? (byte)1 : (byte)0);
			DataUtils.Set(Vars.GEM_SHIELD, chk_bShield.Checked ? (byte)box_bShieldCharge.Value : (byte)0x00);
			DataUtils.Set(Vars.GEM_SWORD, chk_bSword.Checked ? (byte)1 : (byte)0);
			DataUtils.Set(Vars.HAMMERS, chk_hammer.Checked ? (byte)1 : (byte)0);
			DataUtils.Set(Vars.LAVA_CHARMS, chk_lavaCharm.Checked ? (byte)1 : (byte)0);
			DataUtils.Set(Vars.RED_SHIELD, chk_rShield.Checked ? (byte)1 : (byte)0);
			DataUtils.Set(Vars.RED_SWORD, chk_rSword.Checked ? (byte)1 : (byte)0);
			DataUtils.Set(Vars.WATER_RING, chk_windRing.Checked ? (byte)1 : (byte)0);
			DataUtils.Set(Vars.COMPASSES, chk_compass.Checked ? (byte)1 : (byte)0);
			DataUtils.Set(Vars.SPECTACLES, chk_spectacles.Checked ? (byte)1 : (byte)0);
			DataUtils.Set(Vars.SKELETON_KEY, chk_skeletonKey.Checked ? (byte)1 : (byte)0);
			DataUtils.Set(Vars.COLLECTOR_EYE, chk_smugglersEye.Checked ? (byte)1 : (byte)0);
			DataUtils.Set(Vars.BROOM, chk_broom.Checked ? (byte)1 : (byte)0);
			DataUtils.Set(Vars.CARROT, chk_carrot.Checked ? (byte)1 : (byte)0);
			DataUtils.Set(Vars.MIRROR, chk_mirror.Checked ? (byte)1 : (byte)0);
			DataUtils.Set(Vars.SAVE_CRYSTAL, chk_saveCrystals.Checked ? (byte)1 : (byte)0);
			DataUtils.Set(Vars.GREEN_SWORD, chk_greenSword.Checked ? (byte)1 : (byte)0);
			DataUtils.Set(Vars.GREEN_SHIELD, chk_greenSword.Checked ? (byte)1 : (byte)0);
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

			SetCollectibleValues(txt_portalStones.Text, Vars.TOTAL_PORTAL_STONES, Vars.PORTAL_STONES);
			SetCollectibleValues(txt_Gems.Text, Vars.TOTAL_GEMS, Vars.GEMS);
			SetCollectibleValues(txt_goldKey.Text, Vars.TOTAL_GOLD_KEYS, Vars.GOLD_KEYS);
			var got_used = txt_greenGem.Text.Split('/');
			DataUtils.Set(Vars.SECRET_TOKENS, (byte)Convert.ToInt16(got_used[0]));
			DataUtils.Set(Vars.SECRET_SOCKETS, (byte)Convert.ToInt16(got_used[1]));

			SetCollectibleValues(txt_triangle.Text, Vars.TOTAL_NGP_TOKENS, Vars.NGP_TOKENS);

			SetCollectibleValues(txt_possum.Text, Vars.TOTAL_POSSUM_COINS, Vars.POSSUM_COINS);
			SetCollectibleValues(txt_silverKey.Text, Vars.TOTAL_SILVER_KEYS, Vars.SILVER_KEYS);
			SetCollectibleValues(txt_treasure.Text, Vars.TOTAL_TREASURES, Vars.TREASURES);

			DataUtils.SetFlags(theCollectibles.getCollectedForSave());
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

				DataUtils.Load();
				try
				{
					if (DataUtils.GetBoolValue(Vars.NGPP))
					{
						Collectibles.gameMode = GameMode.NGPP;
					}
					else if (DataUtils.GetBoolValue(Vars.NGP))
					{
						Collectibles.gameMode = GameMode.NGP;
					}
					else
					{
						Collectibles.gameMode = GameMode.NG;
					}
					fillForm();
					if (imageForm == null)
					{
						imageForm = new MapWindow(getGameType());
					}
				}
				catch (Exception ex)
                {
					MessageBox.Show(ex.Message);
                }
			}
		}

		private void btn_save_Click(object sender, EventArgs e)
		{
			update_data();
			DataUtils.GetPosition(out int mapId, out int x, out int y, out int d );
			SaveFileDialog save = new SaveFileDialog();
			save.FileName = String.Format("{0}_new", DataUtils.filename);
			save.ShowDialog();
			string savefile = DataUtils.Save(mapId, x, y, d, save.FileName);
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