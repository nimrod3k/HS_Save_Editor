using Microsoft.VisualBasic.ApplicationServices;
using HS_Tools;
using System.Text.Json;

namespace Door_Locator
{
    public partial class Door_Finder : Form
    {
        string _SavePath;
        List<string>? MissingDoors = null;
        public Door_Finder()
        {
            string appData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            _SavePath = Path.Combine(appData, @"Hero's Spirit");
            InitializeComponent();
            if (Directory.Exists(_SavePath))
            {
                foreach (var file in Directory.GetFiles(_SavePath, "savedat?"))
                {
                    combo_saveFile.Items.Add(Path.GetFileNameWithoutExtension(file));
                }
            }
            HS_Save_Tools.Initialize();
        }

        internal static string Unscramble(string text, int TotalSteps)
        {
            string text2 = text.Substring(10);
            string text3 = text2.Substring(0, 4);
            for (int i = 0; i <= (text2.Length - 4) / 8; i++)
            {
                string s = text2.Substring(Math.Min(text2.Length - 1, i * 8 + 4), Math.Min(8, text2.Length - (i * 8 + 4)));
                text3 += HS_Save_Tools.Decode(s, TotalSteps + i);
            }
            text2 = text3;
            text3 = "";
            for (int j = 0; j <= text2.Length / 8; j++)
            {
                string s2 = text2.Substring(j * 8, Math.Min(8, text2.Length - j * 8));
                text3 += HS_Save_Tools.Decode(s2, TotalSteps + j);
            }
            return text3;
        }
        internal static void Set(ref HSJsonData data, Vars item, byte val)
        {
            if ((int)item < data.values.Length)
                data.values[(int)item] = HS_Save_Tools.ObfuscateValue(val);
        }

        internal static void getFile()
        {
            var lines = File.ReadLines(@"C:\Users\nimro\source\repos\HS_Old\HS_Save_Editor\Door_Locator\Door Locator\flags.txt");
            List<String> writelines = new List<String>();
            foreach (var line in lines)
            {
                string longvalue = line.Split(':')[1];
                string[] values = line.Split('-');
                string doortype = "";
                if (values[0] == "sdoor" || values[1] == "sdoor" || values[2] == "sdoor")
                    doortype = "s";
                if (values[0] == "gdoor" || values[1] == "gdoor" || values[2] == "gdoor")
                    doortype = "g";
                if (doortype != "")
                {
                    writelines.Add(line.Split(':')[0] + ":" + doortype);
                }
            }
            File.WriteAllLines(@"C:\Users\nimro\source\repos\HS_Old\HS_Save_Editor\Door_Locator\Door Locator\doors.txt", writelines);
        }

        private void combo_saveFile_SelectedIndexChanged(object sender, EventArgs e)
        {
            string savefile = Path.Combine(_SavePath, (string)combo_saveFile.SelectedItem);
            HSJsonData data = new HSJsonData();
            string text = File.ReadAllText(savefile);
            int TotalSteps = int.Parse(text.Substring(0, 10));
            string saveData = Unscramble(text, TotalSteps);
            if (saveData != null)
            {
                data = JsonSerializer.Deserialize<HSJsonData>(saveData);
                if (data != null && data.values != null)
                {
                    var lines = File.ReadLines(@"C:\Users\nimro\source\repos\HS_Old\HS_Save_Editor\Door_Locator\Door Locator\doors.txt");

                    MissingDoors = new List<string>();

                    foreach (var line in lines)
                    {
                        string[] split_line = line.Split(':');
                        if (!data.flags.ContainsKey(split_line[0])) 
                        {
                            MissingDoors.Add(line);
                        }
                    }

                    rand_lookup();
                }
            }
        }

        private void rand_lookup()
        {
            if (MissingDoors != null)
            {
                if (MissingDoors.Count > 0)
                {
                    Random rnd = new Random();

                    var rand_door = MissingDoors[rnd.Next(0, MissingDoors.Count() - 1)];
                    var split_rand_door = rand_door.Split(":");

                    var doorColor = "Gold";

                    if (split_rand_door[1] == "s")
                        doorColor = "Silver";

                    var doorText = Utils.hintDict[Enum.Parse<Maps>(split_rand_door[0].Split('.')[0])];

                    textBox1.Text = String.Format("A {0} Door is {1}", doorColor, doorText);
                }
                else
                {
                    textBox1.Text = "You seem to have opened all Gold and Silver Doors";
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            rand_lookup();
        }
    }
}