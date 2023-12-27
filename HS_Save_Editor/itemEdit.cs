using Newtonsoft.Json.Linq;
using System;
using System.CodeDom;
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
    public partial class itemEdit : Form
    {
        private Type _itemtype;
        public string ItemValue;
        public itemEdit(string itemName, Type type, object value)
        {
            InitializeComponent();
            label2.Text = itemName;
            _itemtype = type;
            ItemValue = value.ToString();
            txt_value.Text = ItemValue;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (_itemtype == typeof(int) || _itemtype == typeof(long))
                    long.Parse(txt_value.Text);
                if (_itemtype == typeof(bool))
                    bool.Parse(txt_value.Text);

                ItemValue = txt_value.Text;
            }
            catch
            {
                MessageBox.Show(String.Format("Value must be of type: {0}", _itemtype.ToString()));
            }
        }
    }
}
