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
    public partial class MapWindow : Form
    {
        ViewMap viewMap;
        GameType type;
        Map? theMap = null;
        CollectName theCollectible = CollectName.unknown;
        string key = "";
        public MapWindow(GameType type)
        {
            HSGlobal.gameType = type;
            viewMap = new ViewMap(type, 5);
            InitializeComponent();
            box_itemtype.DataSource = Enum.GetNames(typeof(CollectName));
        }


        public void UpdateMap(string flag, CollectName collectType)
        {
            theCollectible = collectType;
            key = flag;
            box_itemtype.SelectedItem = collectType.ToString();
            viewMap.updateMap(flag);
            if (theMap != null && viewMap.mapID != Map.MapId)
            {
                theMap.Dispose();
                theMap = new Map(viewMap.mapID);
                theMap.Update();
            }
            if (theMap == null)
            {
                theMap = new Map(viewMap.mapID);
                theMap.Update();
            }
            viewMap.adjustEP(theMap.Width, theMap.Height);
            theMap.Render(ref viewMap);


            pictureBox1.Image = ViewMap.ResizeImage(viewMap.bitmap, new Size(pictureBox1.Width,pictureBox1.Height));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            theCollectible = (CollectName)Enum.Parse(typeof(CollectName), (string)box_itemtype.SelectedItem);
            Collectibles.setCollectibleType(key, theCollectible);
            MessageBox.Show("Change Saved");
        }
    }
}
