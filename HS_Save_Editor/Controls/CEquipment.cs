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
    public partial class CEquipment : UserControl
    {
        public CEquipment()
        {
            InitializeComponent();
        }

        internal void fillEquipmentTab()
        {
            foreach (var item in DataUtils.SaveData.Equipment)
            {
                Type what = item.Value.GetType();

                if ((item.Value is not int) && (item.Value is not Int64))
                    chk_Equipment.Items.Add(item.Key, (bool)(item.Value));
                else
                {
                    // todo
                }
            }

        }

        private void chk_Equipment_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            string item = (string)chk_Equipment.Items[e.Index];
            DataUtils.SaveData.Equipment[item] = e.NewValue;
        }
    }
}
