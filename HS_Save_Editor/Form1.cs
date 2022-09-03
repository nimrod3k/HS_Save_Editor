using System.Windows.Forms;
using System.Reflection;
using HS_Tools;

namespace HS_Save_Editor
{
    public partial class Form1 : Form
    {
        HSJsonData? theData = null;
        public Form1()
        {
            InitializeComponent();
			combo_SaveLocation.DataSource = Enum.GetValues(typeof(Maps));
        }

        private void btn_loadSaveFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog picker = new OpenFileDialog();
            picker.InitialDirectory = @"C:\Users\nimro\source\repos\HS_Save_Editor\HS_Save_Editor"; // Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location),@"..\..\");

            if (picker.ShowDialog() == DialogResult.OK)
            {
                string file = picker.FileName;
                DataUtils.Initialize(file);

                HSJsonData theData = DataUtils.Load();

                fillForm(theData);
            }
        }

		private void fillAllValues()
        {
			foreach (Vars id in Enum.GetValues(typeof(Vars)))
            {
				string line = string.Format
					(
					"{0}({2}): {1}",id.ToString(),
					DataUtils.Get(theData.values[(int)id]),
					(int)id
					);
				list_values.Items.Add(line);
			}
		}

		private void fillAllFlags()
        {
			foreach (string key in theData.flags.Keys)
			{
				if (!chk_onlyFalse.Checked || !theData.flags[key])
				{
					string[] key_parts = key.Split('.');
					string key_modified = string.Format("{0}({1}).{2}.{3}", (Maps)Convert.ToInt64(key_parts[0]), key_parts[0], key_parts[1], key_parts[2]);
					string line = string.Format
						(
						"'{0}': {1}",
						key_modified,
						theData.flags[key]
						);
					list_flags.Items.Add(line);
				}
			}
		}

        private void fillForm(HSJsonData data)
        {
            theData = data;
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
            chk_bHeart.Checked = DataUtils.GetBoolValue(data.values[(int)Vars.GEM_HEART]);
            chk_bobs.Checked = DataUtils.GetBoolValue(data.values[(int)Vars.GEM_BOOTS]);
            chk_boots.Checked = DataUtils.GetBoolValue(data.values[(int)Vars.BOOTS]);
            chk_bShield.Checked = DataUtils.GetBoolValue(data.values[(int)Vars.GEM_SHIELD]);
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
			fillAllFlags();
			

			/*
		SECRET_TOKENS = 36,
		NGP_TOKENS = 145,
		RED_KEYS,
		BLUE_KEYS,
		GREEN_KEYS,
		PURPLE_KEYS = 85,
		TEAL_KEYS,
		TOTAL_SWORDS = 7,
		TOTAL_RED_KEYS,
		TOTAL_BLUE_KEYS,
		TOTAL_GREEN_KEYS,
		TOTAL_GOLD_DOORS = 113,
		TOTAL_SILVER_DOORS,
		TOTAL_TEAL_DOORS,
		TOTAL_PURPLE_DOORS,
		TOTAL_RED_DOORS,
		TOTAL_BLUE_DOORS,
		TOTAL_GREEN_DOORS,
		TOTAL_TOKENS,
		TOTAL_TEAL_KEYS,
		TOTAL_PURPLE_KEYS,
		TOTAL_NGP_TOKENS = 151,
		COMPLETION_SWAMP,
		COMPLETION_MAZE,
		COMPLETION_BOOTS,
		COMPLETION_CLOAK,
		BLOODMOON_EFFECT = 25,
		BLOODMOON_COUNT,
		BLOODMOON_ORB_HIDE,
		CASTLE_PUZZLE = 22,
		CASTLE_ENTERED,
		GREEN_KEY,
		DRAGON_TREASURE = 34,
		CASTLE_SKIP_PRIMED = 37,
		CASTLE_PUZZLE_SOLVED,
		GHOST_SHIP_ENTERED = 49,
		HERMIT_SWORD_ACQUIRED,
		TOTAL_STEPS = 53,
		SAVE_COUNT = 74,
		DRAGON_KILLED,
		BUNNY_CRIME_SCENE,
		NGP = 144,
		RED_GEAR_SKIP = 148,
		NGPP,
		RDRAGON_KILLED,
		PREVENTED_NIGHT = 152,
		BOSS_REACHED = 28,
		CASTLE_LABYRINTH_OPEN,
		SWAMP_SECRET,
		BACK_DOOR_LOCK_1,
		BACK_DOOR_LOCK_2,
		VICTORY_ROAD_SOLVED,
		SECRET_SOCKETS = 35,
		GOLD_SWORD_DOOR = 56,
		SNAKE_BOSS_DEFEATED = 63,
		WARP_PORTAL_01 = 39,
		WARP_PORTAL_02,
		WARP_PORTAL_03,
		WARP_PORTAL_04,
		WARP_PORTAL_05,
		WARP_PORTAL_06,
		WARP_PORTAL_07,
		WARP_PORTAL_08,
		WARP_PORTAL_09,
		WARP_PORTAL_10,
		FAIRYLAND_LOCK_1 = 64,
		FAIRYLAND_LOCK_2,
		FAIRYLAND_LOCK_3,
		FAIRYLAND_LOCK_4,
		FAIRYLAND_LOCK_5,
		FAIRYLAND_LOCK_6,
		FAIRYLAND_LOCK_7,
		FAIRYLAND_LOCK_8,
		FAIRYLAND_LOCKS,
		GREENFIGHT_LOCK_1 = 91,
		GREENFIGHT_LOCK_2,
		GREENFIGHT_LOCK_3,
		GREENFIGHT_LOCK_4,
		GREENFIGHT_LOCK_5,
		GREENFIGHT_LOCK_6,
		GREENFIGHT_LOCK_7,
		GREENFIGHT_LOCK_8,
		OVERKILL = 128,
		BACKDOOR_BANDITRY,
		DRAGONSLAIN,
		CONVERGENCE_KEY = 153,
		DRAGON_EGG,
		CARROT,
		GREEN_SWORD,
		GREEN_SHIELD,
		BUNNY_LOVE,
		BUNNY_LEVEL,
		HERO_FORM_OVERRIDE,
		HERO_COLOR_OVERRIDE,
		BUNNY_COLOR_OVERRIDE,
		EVIL_BUNNY_TAMED,
		BACKUP_NGP_TOKENS,
		BACKUP_SECRET_TOKENS,
		BACKUP_T_NGP_TOKENS,
		BACKUP_T_SECRET_TOKENS,
		FISHING_POLE,
		FISH,
		NGPPP,
		RAWR1_MAP,
		RAWR1_X,
		RAWR1_Y,
		RAWR2_MAP,
		RAWR2_X,
		RAWR2_Y,
		RAWR3_MAP,
		RAWR3_X,
		RAWR3_Y,
		RAWR
			*/
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
			theData.playtime =(Convert.ToInt64(splitTime[0]) * 3600) + (Convert.ToInt64(splitTime[1]) * 60) + Convert.ToInt64(splitTime[2]);
			theData.deaths = (int)box_deaths.Value;
			DataUtils.Set(ref theData, Vars.GEM_HEART, chk_bHeart.Checked ? (byte)1:(byte)0);
			DataUtils.Set(ref theData, Vars.GEM_BOOTS, chk_bobs.Checked ? (byte)1:(byte)0);
			DataUtils.Set(ref theData, Vars.BOOTS, chk_boots.Checked ? (byte)1:(byte)0);
			DataUtils.Set(ref theData, Vars.GEM_SHIELD, chk_bShield.Checked ? (byte)0x01:(byte)0x00);
			DataUtils.Set(ref theData, Vars.GEM_SWORD, chk_bSword.Checked ? (byte)1:(byte)0);
			DataUtils.Set(ref theData, Vars.HAMMERS, chk_hammer.Checked ? (byte)1:(byte)0);
			DataUtils.Set(ref theData, Vars.LAVA_CHARMS, chk_lavaCharm.Checked ? (byte)1:(byte)0);
			DataUtils.Set(ref theData, Vars.RED_SHIELD, chk_rShield.Checked ? (byte)1:(byte)0);
			DataUtils.Set(ref theData, Vars.RED_SWORD, chk_rSword.Checked ? (byte)1:(byte)0);
			DataUtils.Set(ref theData, Vars.WATER_RING, chk_windRing.Checked ? (byte)1:(byte)0);
			DataUtils.Set(ref theData, Vars.COMPASSES, chk_compass.Checked ? (byte)1:(byte)0);
			DataUtils.Set(ref theData, Vars.SPECTACLES, chk_spectacles.Checked ? (byte)1:(byte)0);
			DataUtils.Set(ref theData, Vars.SKELETON_KEY, chk_skeletonKey.Checked ? (byte)1:(byte)0);
			DataUtils.Set(ref theData, Vars.COLLECTOR_EYE, chk_smugglersEye.Checked ? (byte)1:(byte)0);
			DataUtils.Set(ref theData, Vars.BROOM, chk_broom.Checked ? (byte)1:(byte)0);
			DataUtils.Set(ref theData, Vars.MIRROR, chk_mirror.Checked ? (byte)1:(byte)0);
			DataUtils.Set(ref theData, Vars.SAVE_CRYSTAL, chk_saveCrystals.Checked ? (byte)1:(byte)0);
			DataUtils.Set(ref theData, Vars.GREEN_SWORD, chk_greenSword.Checked ? (byte)1 : (byte)0);

		}

        private void chk_onlyFalse_CheckedChanged(object sender, EventArgs e)
        {
			list_flags.Items.Clear();
			list_values.Items.Clear();
			fillAllFlags();
        }
    }
}