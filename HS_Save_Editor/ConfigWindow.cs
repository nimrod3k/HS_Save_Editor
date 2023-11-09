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
    public partial class ConfigWindow : Form
    {
        public ConfigWindow()
        {
            InitializeComponent();

            txt_rompath.Text = HSGlobal.CONFIG.rompath;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HSGlobal.CONFIG.rompath = txt_rompath.Text;
            HSGlobal.WriteConfig();

            Close();
        }
    }
}
