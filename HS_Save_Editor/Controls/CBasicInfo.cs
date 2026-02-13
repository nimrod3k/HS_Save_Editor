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
        bool holdMapUpdate = false;
        public CBasicInfo()
        {
            InitializeComponent();


            combo_SaveLocation.DataSource = HSGlobal.Maps.Keys.ToArray();
            combo_SaveLocationD.DataSource = Enum.GetValues(typeof(Direction));
        }

        internal void fillBasicTab()
        {
            box_steps.Text = DataUtils.TotalSteps.ToString();
            box_time.Text = DataUtils.GetPlaytime();
            box_deaths.Value = DataUtils.GetDeaths();
            box_kills.Value = DataUtils.GetKills();

            DataUtils.GetPosition(out int mapId, out int x, out int y, out Direction d);
            num_SaveLocationX.Value = x;
            num_SaveLocationY.Value = y;
            combo_SaveLocationD.SelectedItem = d;
            combo_SaveLocation.SelectedItem = HSGlobal.Maps.FirstOrDefault(x => x.Value == mapId).Key;
            calculatePercentages();
        }

        public void UpdateMap()
        {
            //if (mainForm.initialized)
            //{
            //    if (HSGlobal.map == null || Map.MapId != DataUtils.SaveData.PlayerLocation.MapId)
            //        HSGlobal.map = new Map(DataUtils.SaveData.PlayerLocation.MapId);
            //    HSGlobal.map.Update(21, 22);
            //}
        }

        public void DrawMap()
        {
            //if (mainForm.initialized)
            //{
            //    UpdateMap();
            //    Bitmap bmp = HSGlobal.map.DrawFocused(DataUtils.SaveData.PlayerLocation.X, DataUtils.SaveData.PlayerLocation.Y, DataUtils.SaveData.PlayerLocation.Direction, 21, 22, true);
            //    if (bmp != null)
            //    {
            //        Bitmap bmp2 = HSGlobal.ResizeImage(bmp, new Size(pictureBox1.Width, pictureBox1.Height));
            //        bmp2.Save(@"C:\Program Files (x86)\Steam\steamapps\common\Hero's Spirit Alpha (v5)\test\something.png");
            //        pictureBox1.Image = bmp2;
            //    }
            //}
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
            if (box_steps.Modified)
                DataUtils.TotalSteps = int.Parse(box_steps.Text);
        }

        private void box_time_TextChanged(object sender, EventArgs e)
        {
			if (box_time.Modified)
				DataUtils.SetPlaytime(box_time.Text);
		}

        private void box_deaths_ValueChanged(object sender, EventArgs e)
        {
            DataUtils.SetDeaths((int)box_deaths.Value);
        }

        private void box_kills_ValueChanged(object sender, EventArgs e)
        {
            DataUtils.SetKills((int)box_kills.Value);
        }

        private void SaveLocation_Changed(object sender, EventArgs e)
        {
            if (DataUtils.dataIsLoaded)
            {
                if (sender == combo_SaveLocation)
				DataUtils.SetPosition((int)Enum.Parse(typeof(Maps), combo_SaveLocation.Text), num_SaveLocationX.Text, num_SaveLocationY.Text, combo_SaveLocationD.Text);
                //DataUtils.SaveData.PlayerLocation.MapId = (int)HSGlobal.Maps[(string)combo_SaveLocation.SelectedItem];
                //if (!holdMapUpdate)
                //{
                //    //UpdateMap();
                //    //holdMapUpdate = true;
                //    //if (num_SaveLocationX.Value >= HSGlobal.map.Width)
                //    //    num_SaveLocationX.Value = HSGlobal.map.Width - 1;
                //    //if (num_SaveLocationY.Value >= HSGlobal.map.Height)
                //    //    num_SaveLocationY.Value = HSGlobal.map.Height - 1;
                //    //holdMapUpdate = false;
                //    //DrawMap();
                //}
            }
        }


        //internal void CBasicInfo_KeyDown(object sender, KeyEventArgs e)
        //{

        //    if (e.KeyValue == (int)Keys.Down)
        //    {
        //        num_SaveLocationY.Value = num_SaveLocationY.Value + 1;
        //        combo_SaveLocationD.SelectedItem = Direction.South;
        //    }
        //    if (e.KeyValue == (int)Keys.Up && num_SaveLocationY.Value > 0)
        //    {
        //        num_SaveLocationY.Value = num_SaveLocationY.Value - 1;
        //        combo_SaveLocationD.SelectedItem = Direction.North;
        //    }
        //    if (e.KeyValue == (int)Keys.Left && num_SaveLocationX.Value > 0)
        //    {
        //        num_SaveLocationX.Value = num_SaveLocationX.Value - 1;
        //        combo_SaveLocationD.SelectedItem = Direction.West;
        //    }
        //    if (e.KeyValue == (int)Keys.Right)
        //    {
        //        num_SaveLocationX.Value = num_SaveLocationX.Value + 1;
        //        combo_SaveLocationD.SelectedItem = Direction.East;
        //    }

        //}

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            num_SaveLocationX.Select();
        }
    }
}
