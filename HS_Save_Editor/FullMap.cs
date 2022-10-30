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
        Maps _mapID;
        Map? theMap = null;

        public FullMap()
        {
            InitializeComponent();
            for (var i = 1; i < (int)Maps.MAX_VAL; ++i)
            {
                if (Enum.IsDefined(typeof(Maps), i))
                {
                    Maps value = (Maps)i;
                    comboBox1.Items.Add(value.ToString());
                }
            }
            comboBox1.SelectedIndex = 0;

        }

        private void FullMap_Resize(object sender, EventArgs e)
        {
            UpdateMap(_mapID);
        }

        public void UpdateMap(Maps MapID)
        {
            if (theMap == null)
            {
                theMap = new Map((int)MapID);
                theMap.Update();
            }
            Bitmap bmp = null;
            theMap.Render(out bmp);


            pictureBox1.Image = ViewMap.ResizeImage(bmp, new Size(pictureBox1.Width, pictureBox1.Height));
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Maps newID = (Maps)Enum.Parse(typeof(Maps), (string)comboBox1.SelectedItem);
            if (_mapID != newID)
            {
                if (theMap != null)
                {
                    theMap.Dispose();
                    theMap = null;
                }
                _mapID = newID;
                UpdateMap(_mapID);
            }
        }
    }
}
