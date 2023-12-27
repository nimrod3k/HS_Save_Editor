using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HS_Save_Editor
{
    public partial class CStory : UserControl
    {
        public CStory()
        {
            InitializeComponent();
        }


        internal void fillStoryTab()
        {
            foreach (var item in DataUtils.SaveData.Story)
            {
                if ((item.Value is int) || (item.Value is Int64) || (item.Value is bool))
                    box_story.Items.Add(string.Format("{0}: {1}", item.Key, item.Value));
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
