using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HS_Save_Editor.Controls
{
    public partial class CItems : UserControl
    {
        public CItems()
        {
            InitializeComponent();
        }


        internal void fillItemTab()
        {
            foreach (var item in DataUtils.SaveData.Items)
            {
                box_item.Items.Add(string.Format("{0}: {1}", item.Key, item.Value));
            }
        }

        private void box_item_DoubleClick(object sender, EventArgs e)
        {
            var item = ((string)(box_item.SelectedItem)).Split(':');
            var item_value = DataUtils.SaveData.Items[item[0]];

            itemEdit ie = new itemEdit(item[0], item_value.GetType(), item_value);
            ie.ShowDialog();
            if (ie.DialogResult == DialogResult.OK)
            {
                DataUtils.SaveData.Items[item[0]] = Convert.ToInt32(ie.ItemValue);
                box_item.Items[box_item.SelectedIndex] = string.Format("{0}: {1}", item[0], ie.ItemValue);
            }
        }
    }
}
