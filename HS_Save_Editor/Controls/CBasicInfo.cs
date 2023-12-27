using HS_Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HS_Save_Editor
{
    public partial class CBasicInfo : UserControl
    {
        public CBasicInfo()
        {
            InitializeComponent();
            

            combo_SaveLocation.DataSource = HSGlobal.Maps.Keys.ToArray();
            combo_SaveLocationD.DataSource = Enum.GetValues(typeof(Direction));
        }

        internal void fillBasicTab()
        {
            box_steps.Text = DataUtils.SaveData.Steps.ToString();
            box_time.Text = DataUtils.SaveData.Playtime.ToString();
            box_deaths.Value = DataUtils.SaveData.Deaths;
            box_kills.Value = DataUtils.SaveData.Kills;
            //chk_witchEnding.Checked = DataUtils.GetBoolValue(Vars.WITCH_GEM_SWORD_3) ||
            //						DataUtils.GetBoolValue(Vars.WITCH_HAMMER) ||
            //						DataUtils.GetBoolValue(Vars.WITCH_WATER_RING) ||
            //						DataUtils.GetBoolValue(Vars.WITCH_PHASE2);
            DataUtils.GetPosition(out int mapId, out int x, out int y, out Direction d);
            num_SaveLocationX.Value = x;
            num_SaveLocationY.Value = y;
            combo_SaveLocationD.SelectedItem = d;
            combo_SaveLocation.SelectedItem = HSGlobal.Maps.FirstOrDefault(x => x.Value == mapId).Key;
            //calculatePercentages();
        }

        private void calculatePercentages()
        {
            txt_percent.Text = CompletionCalculator.Calculate().ToString();
            txt_convergePercent.Text = CompletionCalculator.Calculate(true, false).ToString();
            txt_witchBasic.Text = CompletionCalculator.Calculate(false, false, false).ToString();
            txt_witchPerfect.Text = CompletionCalculator.Calculate(false, false, true).ToString();
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
            if (DataUtils.SaveData is not null)
                DataUtils.SaveData.PlayerLocation.MapId = (int)HSGlobal.Maps[(string)combo_SaveLocation.SelectedItem];
        }

        private void num_SaveLocationX_ValueChanged(object sender, EventArgs e)
        {
            if (DataUtils.SaveData is not null)
                DataUtils.SaveData.PlayerLocation.X = (int)num_SaveLocationX.Value;
        }

        private void num_SaveLocationY_ValueChanged(object sender, EventArgs e)
        {
            if (DataUtils.SaveData is not null)
                DataUtils.SaveData.PlayerLocation.Y = (int)num_SaveLocationY.Value;
        }

        private void combo_SaveLocationD_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DataUtils.SaveData is not null)
                DataUtils.SaveData.PlayerLocation.Direction = (Direction)combo_SaveLocationD.SelectedItem;
                    //Enum.Parse<Direction>((string)combo_SaveLocationD.SelectedItem);

        }
    }
}
