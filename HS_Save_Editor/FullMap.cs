using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HS_Tools;


namespace HS_Save_Editor
{
    public partial class FullMap : Form
    {
        int _mapID;

        public FullMap()
        {
            InitializeComponent();
            foreach (var key in HSGlobal.Maps.Keys)
            {
                comboBox1.Items.Add(key);
            }
            comboBox1.SelectedIndex = 0;

        }

        private void FullMap_Resize(object sender, EventArgs e)
        {
            UpdateMap(_mapID);
        }

        public void UpdateMap(int MapID)
        {
            if (MapID == 0)
                MapID = HSGlobal.Maps["Dust Shelf"];
            if (HSGlobal.map == null)
            {
                HSGlobal.map = new Map((int)MapID);
                HSGlobal.map.Update(1,1);
            }
            Bitmap bmp = HSGlobal.map.Draw();
            //theMap.Render(out bmp);

            if (bmp != null)
                pictureBox1.Image = HSGlobal.ResizeImage(bmp, new Size(pictureBox1.Width, pictureBox1.Height));
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int newID = HSGlobal.Maps[(string)comboBox1.SelectedItem];
            if (_mapID != newID)
            {
                if (HSGlobal.map != null)
                {
                    HSGlobal.map.Dispose();
                    HSGlobal.map = null;
                }
                _mapID = newID;
                UpdateMap(_mapID);
            }
        }

        private void FullMap_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
    }
}
