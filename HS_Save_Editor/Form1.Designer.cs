namespace HS_Save_Editor
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_loadSaveFile = new System.Windows.Forms.Button();
            this.tab_saveData = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.chk_bloodmoon = new System.Windows.Forms.CheckBox();
            this.label36 = new System.Windows.Forms.Label();
            this.txt_bloodmoonCount = new System.Windows.Forms.TextBox();
            this.txt_witchBasic = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.txt_witchPerfect = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.txt_convergePercent = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.chk_witchEnding = new System.Windows.Forms.CheckBox();
            this.box_kills = new System.Windows.Forms.NumericUpDown();
            this.label21 = new System.Windows.Forms.Label();
            this.txt_percent = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_SaveLocationD = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_SaveLocationX = new System.Windows.Forms.TextBox();
            this.txt_SaveLocationY = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.combo_SaveLocation = new System.Windows.Forms.ComboBox();
            this.chk_bHeart = new System.Windows.Forms.CheckBox();
            this.box_deaths = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.box_time = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.box_steps = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.box_story = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.box_item = new System.Windows.Forms.ListBox();
            this.chk_Equipment = new System.Windows.Forms.CheckedListBox();
            this.label30 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.lbl_uncollectedCount = new System.Windows.Forms.Label();
            this.lbl_collectedCount = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.combo_map = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chk_feature_pcoin = new System.Windows.Forms.CheckBox();
            this.chk_feature_other = new System.Windows.Forms.CheckBox();
            this.chk_feature_keyItems = new System.Windows.Forms.CheckBox();
            this.chk_feature_swords = new System.Windows.Forms.CheckBox();
            this.chk_feature_portals = new System.Windows.Forms.CheckBox();
            this.chk_feature_hearts = new System.Windows.Forms.CheckBox();
            this.chk_feature_Gems = new System.Windows.Forms.CheckBox();
            this.chk_feature_unknown = new System.Windows.Forms.CheckBox();
            this.chk_feature_treasures = new System.Windows.Forms.CheckBox();
            this.chk_feature_gkey = new System.Windows.Forms.CheckBox();
            this.chk_feature_sdoor = new System.Windows.Forms.CheckBox();
            this.chk_feature_skey = new System.Windows.Forms.CheckBox();
            this.chk_feature_gdoor = new System.Windows.Forms.CheckBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.btn_itemsRight = new System.Windows.Forms.Button();
            this.btn_itemsLeft = new System.Windows.Forms.Button();
            this.list_allitems = new System.Windows.Forms.ListBox();
            this.list_flags = new System.Windows.Forms.ListBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label20 = new System.Windows.Forms.Label();
            this.list_missedPercent = new System.Windows.Forms.ListBox();
            this.list_xtraPercent = new System.Windows.Forms.ListBox();
            this.list_values = new System.Windows.Forms.ListBox();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_OpenMap = new System.Windows.Forms.Button();
            this.btn_config = new System.Windows.Forms.Button();
            this.cb_GameMode = new System.Windows.Forms.ComboBox();
            this.tab_saveData.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.box_kills)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.box_deaths)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_loadSaveFile
            // 
            this.btn_loadSaveFile.Location = new System.Drawing.Point(12, 11);
            this.btn_loadSaveFile.Name = "btn_loadSaveFile";
            this.btn_loadSaveFile.Size = new System.Drawing.Size(133, 23);
            this.btn_loadSaveFile.TabIndex = 0;
            this.btn_loadSaveFile.Text = "Import Save File";
            this.btn_loadSaveFile.UseVisualStyleBackColor = true;
            this.btn_loadSaveFile.Click += new System.EventHandler(this.btn_loadSaveFile_Click);
            // 
            // tab_saveData
            // 
            this.tab_saveData.Controls.Add(this.tabPage1);
            this.tab_saveData.Controls.Add(this.tabPage2);
            this.tab_saveData.Controls.Add(this.tabPage4);
            this.tab_saveData.Controls.Add(this.tabPage3);
            this.tab_saveData.Location = new System.Drawing.Point(12, 40);
            this.tab_saveData.Name = "tab_saveData";
            this.tab_saveData.SelectedIndex = 0;
            this.tab_saveData.Size = new System.Drawing.Size(776, 398);
            this.tab_saveData.TabIndex = 1;
            this.tab_saveData.SelectedIndexChanged += new System.EventHandler(this.tab_saveData_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.chk_bloodmoon);
            this.tabPage1.Controls.Add(this.label36);
            this.tabPage1.Controls.Add(this.txt_bloodmoonCount);
            this.tabPage1.Controls.Add(this.txt_witchBasic);
            this.tabPage1.Controls.Add(this.label25);
            this.tabPage1.Controls.Add(this.txt_witchPerfect);
            this.tabPage1.Controls.Add(this.label24);
            this.tabPage1.Controls.Add(this.txt_convergePercent);
            this.tabPage1.Controls.Add(this.label23);
            this.tabPage1.Controls.Add(this.label22);
            this.tabPage1.Controls.Add(this.chk_witchEnding);
            this.tabPage1.Controls.Add(this.box_kills);
            this.tabPage1.Controls.Add(this.label21);
            this.tabPage1.Controls.Add(this.txt_percent);
            this.tabPage1.Controls.Add(this.label19);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.txt_SaveLocationD);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.txt_SaveLocationX);
            this.tabPage1.Controls.Add(this.txt_SaveLocationY);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.combo_SaveLocation);
            this.tabPage1.Controls.Add(this.chk_bHeart);
            this.tabPage1.Controls.Add(this.box_deaths);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.box_time);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.box_steps);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(768, 370);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Basic Info";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // chk_bloodmoon
            // 
            this.chk_bloodmoon.AutoSize = true;
            this.chk_bloodmoon.Location = new System.Drawing.Point(12, 240);
            this.chk_bloodmoon.Name = "chk_bloodmoon";
            this.chk_bloodmoon.Size = new System.Drawing.Size(89, 19);
            this.chk_bloodmoon.TabIndex = 45;
            this.chk_bloodmoon.Text = "Bloodmoon";
            this.chk_bloodmoon.UseVisualStyleBackColor = true;
            this.chk_bloodmoon.CheckedChanged += new System.EventHandler(this.chk_bloodmoon_CheckedChanged);
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(104, 220);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(122, 15);
            this.label36.TabIndex = 44;
            this.label36.Text = "Bloodmoon Time Left";
            // 
            // txt_bloodmoonCount
            // 
            this.txt_bloodmoonCount.Location = new System.Drawing.Point(104, 238);
            this.txt_bloodmoonCount.Name = "txt_bloodmoonCount";
            this.txt_bloodmoonCount.Size = new System.Drawing.Size(120, 23);
            this.txt_bloodmoonCount.TabIndex = 42;
            this.txt_bloodmoonCount.TextChanged += new System.EventHandler(this.txt_bloodmoonCount_TextChanged);
            // 
            // txt_witchBasic
            // 
            this.txt_witchBasic.Location = new System.Drawing.Point(586, 332);
            this.txt_witchBasic.Name = "txt_witchBasic";
            this.txt_witchBasic.ReadOnly = true;
            this.txt_witchBasic.Size = new System.Drawing.Size(120, 23);
            this.txt_witchBasic.TabIndex = 40;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(586, 304);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(68, 15);
            this.label25.TabIndex = 39;
            this.label25.Text = "Witch Basic";
            // 
            // txt_witchPerfect
            // 
            this.txt_witchPerfect.Location = new System.Drawing.Point(455, 332);
            this.txt_witchPerfect.Name = "txt_witchPerfect";
            this.txt_witchPerfect.ReadOnly = true;
            this.txt_witchPerfect.Size = new System.Drawing.Size(120, 23);
            this.txt_witchPerfect.TabIndex = 38;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(455, 304);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(78, 15);
            this.label24.TabIndex = 37;
            this.label24.Text = "Witch Perfect";
            // 
            // txt_convergePercent
            // 
            this.txt_convergePercent.Location = new System.Drawing.Point(317, 332);
            this.txt_convergePercent.Name = "txt_convergePercent";
            this.txt_convergePercent.ReadOnly = true;
            this.txt_convergePercent.Size = new System.Drawing.Size(120, 23);
            this.txt_convergePercent.TabIndex = 36;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(317, 304);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(101, 15);
            this.label23.TabIndex = 35;
            this.label23.Text = "Convergence part";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(179, 304);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(67, 15);
            this.label22.TabIndex = 34;
            this.label22.Text = "Green/NPC";
            // 
            // chk_witchEnding
            // 
            this.chk_witchEnding.AutoSize = true;
            this.chk_witchEnding.Location = new System.Drawing.Point(435, 162);
            this.chk_witchEnding.Name = "chk_witchEnding";
            this.chk_witchEnding.Size = new System.Drawing.Size(97, 19);
            this.chk_witchEnding.TabIndex = 33;
            this.chk_witchEnding.Text = "Witch Ending";
            this.chk_witchEnding.UseVisualStyleBackColor = true;
            this.chk_witchEnding.CheckedChanged += new System.EventHandler(this.chk_witchEnding_CheckedChanged);
            // 
            // box_kills
            // 
            this.box_kills.Location = new System.Drawing.Point(288, 88);
            this.box_kills.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.box_kills.Name = "box_kills";
            this.box_kills.Size = new System.Drawing.Size(120, 23);
            this.box_kills.TabIndex = 30;
            this.box_kills.ValueChanged += new System.EventHandler(this.box_kills_ValueChanged);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(246, 90);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(28, 15);
            this.label21.TabIndex = 29;
            this.label21.Text = "Kills";
            // 
            // txt_percent
            // 
            this.txt_percent.Location = new System.Drawing.Point(179, 332);
            this.txt_percent.Name = "txt_percent";
            this.txt_percent.ReadOnly = true;
            this.txt_percent.Size = new System.Drawing.Size(120, 23);
            this.txt_percent.TabIndex = 28;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(33, 332);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(132, 15);
            this.label19.TabIndex = 3;
            this.label19.Text = "Completion Percentage";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(349, 138);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(14, 15);
            this.label9.TabIndex = 27;
            this.label9.Text = "d";
            // 
            // txt_SaveLocationD
            // 
            this.txt_SaveLocationD.Location = new System.Drawing.Point(368, 130);
            this.txt_SaveLocationD.Name = "txt_SaveLocationD";
            this.txt_SaveLocationD.Size = new System.Drawing.Size(40, 23);
            this.txt_SaveLocationD.TabIndex = 26;
            this.txt_SaveLocationD.TextChanged += new System.EventHandler(this.combo_SaveLocation_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(286, 138);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(13, 15);
            this.label8.TabIndex = 25;
            this.label8.Text = "y";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(230, 138);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(13, 15);
            this.label7.TabIndex = 24;
            this.label7.Text = "x";
            // 
            // txt_SaveLocationX
            // 
            this.txt_SaveLocationX.Location = new System.Drawing.Point(246, 130);
            this.txt_SaveLocationX.Name = "txt_SaveLocationX";
            this.txt_SaveLocationX.Size = new System.Drawing.Size(38, 23);
            this.txt_SaveLocationX.TabIndex = 23;
            this.txt_SaveLocationX.TextChanged += new System.EventHandler(this.combo_SaveLocation_SelectedIndexChanged);
            // 
            // txt_SaveLocationY
            // 
            this.txt_SaveLocationY.Location = new System.Drawing.Point(305, 130);
            this.txt_SaveLocationY.Name = "txt_SaveLocationY";
            this.txt_SaveLocationY.Size = new System.Drawing.Size(40, 23);
            this.txt_SaveLocationY.TabIndex = 22;
            this.txt_SaveLocationY.TextChanged += new System.EventHandler(this.combo_SaveLocation_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 133);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 15);
            this.label6.TabIndex = 21;
            this.label6.Text = "Save Location";
            // 
            // combo_SaveLocation
            // 
            this.combo_SaveLocation.FormattingEnabled = true;
            this.combo_SaveLocation.Location = new System.Drawing.Point(103, 130);
            this.combo_SaveLocation.Name = "combo_SaveLocation";
            this.combo_SaveLocation.Size = new System.Drawing.Size(121, 23);
            this.combo_SaveLocation.TabIndex = 3;
            this.combo_SaveLocation.SelectedIndexChanged += new System.EventHandler(this.combo_SaveLocation_SelectedIndexChanged);
            // 
            // chk_bHeart
            // 
            this.chk_bHeart.AutoSize = true;
            this.chk_bHeart.Location = new System.Drawing.Point(646, 50);
            this.chk_bHeart.Name = "chk_bHeart";
            this.chk_bHeart.Size = new System.Drawing.Size(81, 19);
            this.chk_bHeart.TabIndex = 17;
            this.chk_bHeart.Text = "Blue Heart";
            this.chk_bHeart.UseVisualStyleBackColor = true;
            this.chk_bHeart.CheckedChanged += new System.EventHandler(this.chk_bHeart_CheckedChanged);
            // 
            // box_deaths
            // 
            this.box_deaths.Location = new System.Drawing.Point(104, 88);
            this.box_deaths.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.box_deaths.Name = "box_deaths";
            this.box_deaths.Size = new System.Drawing.Size(120, 23);
            this.box_deaths.TabIndex = 10;
            this.box_deaths.ValueChanged += new System.EventHandler(this.box_deaths_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(33, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "Deaths";
            // 
            // box_time
            // 
            this.box_time.Location = new System.Drawing.Point(104, 54);
            this.box_time.Name = "box_time";
            this.box_time.Size = new System.Drawing.Size(120, 23);
            this.box_time.TabIndex = 8;
            this.box_time.TextChanged += new System.EventHandler(this.box_time_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Total Time";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Total Steps";
            // 
            // box_steps
            // 
            this.box_steps.Location = new System.Drawing.Point(104, 14);
            this.box_steps.Name = "box_steps";
            this.box_steps.Size = new System.Drawing.Size(120, 23);
            this.box_steps.TabIndex = 0;
            this.box_steps.TextChanged += new System.EventHandler(this.box_steps_TextChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.box_story);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.box_item);
            this.tabPage2.Controls.Add(this.chk_Equipment);
            this.tabPage2.Controls.Add(this.label30);
            this.tabPage2.Controls.Add(this.label16);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(768, 370);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Items and Story";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // box_story
            // 
            this.box_story.FormattingEnabled = true;
            this.box_story.ItemHeight = 15;
            this.box_story.Location = new System.Drawing.Point(507, 31);
            this.box_story.Name = "box_story";
            this.box_story.Size = new System.Drawing.Size(250, 319);
            this.box_story.TabIndex = 72;
            this.box_story.DoubleClick += new System.EventHandler(this.box_story_DoubleClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(515, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 25);
            this.label3.TabIndex = 71;
            this.label3.Text = "Story";
            // 
            // box_item
            // 
            this.box_item.FormattingEnabled = true;
            this.box_item.ItemHeight = 15;
            this.box_item.Location = new System.Drawing.Point(251, 31);
            this.box_item.Name = "box_item";
            this.box_item.Size = new System.Drawing.Size(250, 319);
            this.box_item.TabIndex = 70;
            this.box_item.DoubleClick += new System.EventHandler(this.box_item_DoubleClick);
            // 
            // chk_Equipment
            // 
            this.chk_Equipment.FormattingEnabled = true;
            this.chk_Equipment.Location = new System.Drawing.Point(3, 31);
            this.chk_Equipment.Name = "chk_Equipment";
            this.chk_Equipment.Size = new System.Drawing.Size(234, 328);
            this.chk_Equipment.TabIndex = 69;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label30.Location = new System.Drawing.Point(9, 3);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(109, 25);
            this.label30.TabIndex = 65;
            this.label30.Text = "Equipment";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label16.Location = new System.Drawing.Point(259, 3);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(60, 25);
            this.label16.TabIndex = 45;
            this.label16.Text = "Items";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.lbl_uncollectedCount);
            this.tabPage4.Controls.Add(this.lbl_collectedCount);
            this.tabPage4.Controls.Add(this.label34);
            this.tabPage4.Controls.Add(this.label33);
            this.tabPage4.Controls.Add(this.groupBox2);
            this.tabPage4.Controls.Add(this.groupBox1);
            this.tabPage4.Controls.Add(this.label18);
            this.tabPage4.Controls.Add(this.label17);
            this.tabPage4.Controls.Add(this.btn_itemsRight);
            this.tabPage4.Controls.Add(this.btn_itemsLeft);
            this.tabPage4.Controls.Add(this.list_allitems);
            this.tabPage4.Controls.Add(this.list_flags);
            this.tabPage4.Location = new System.Drawing.Point(4, 24);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(768, 370);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Entities";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // lbl_uncollectedCount
            // 
            this.lbl_uncollectedCount.AutoSize = true;
            this.lbl_uncollectedCount.Location = new System.Drawing.Point(488, 272);
            this.lbl_uncollectedCount.Name = "lbl_uncollectedCount";
            this.lbl_uncollectedCount.Size = new System.Drawing.Size(13, 15);
            this.lbl_uncollectedCount.TabIndex = 21;
            this.lbl_uncollectedCount.Text = "0";
            // 
            // lbl_collectedCount
            // 
            this.lbl_collectedCount.AutoSize = true;
            this.lbl_collectedCount.Location = new System.Drawing.Point(97, 272);
            this.lbl_collectedCount.Name = "lbl_collectedCount";
            this.lbl_collectedCount.Size = new System.Drawing.Size(13, 15);
            this.lbl_collectedCount.TabIndex = 20;
            this.lbl_collectedCount.Text = "0";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(409, 272);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(73, 15);
            this.label34.TabIndex = 19;
            this.label34.Text = "Items Listed:";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(25, 272);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(76, 15);
            this.label33.TabIndex = 18;
            this.label33.Text = "Items Listed: ";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.combo_map);
            this.groupBox2.Location = new System.Drawing.Point(3, 290);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(156, 74);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Areas";
            // 
            // combo_map
            // 
            this.combo_map.FormattingEnabled = true;
            this.combo_map.Location = new System.Drawing.Point(6, 22);
            this.combo_map.Name = "combo_map";
            this.combo_map.Size = new System.Drawing.Size(144, 23);
            this.combo_map.TabIndex = 18;
            this.combo_map.SelectedIndexChanged += new System.EventHandler(this.combo_map_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chk_feature_pcoin);
            this.groupBox1.Controls.Add(this.chk_feature_other);
            this.groupBox1.Controls.Add(this.chk_feature_keyItems);
            this.groupBox1.Controls.Add(this.chk_feature_swords);
            this.groupBox1.Controls.Add(this.chk_feature_portals);
            this.groupBox1.Controls.Add(this.chk_feature_hearts);
            this.groupBox1.Controls.Add(this.chk_feature_Gems);
            this.groupBox1.Controls.Add(this.chk_feature_unknown);
            this.groupBox1.Controls.Add(this.chk_feature_treasures);
            this.groupBox1.Controls.Add(this.chk_feature_gkey);
            this.groupBox1.Controls.Add(this.chk_feature_sdoor);
            this.groupBox1.Controls.Add(this.chk_feature_skey);
            this.groupBox1.Controls.Add(this.chk_feature_gdoor);
            this.groupBox1.Location = new System.Drawing.Point(165, 290);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(597, 74);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Collectables";
            // 
            // chk_feature_pcoin
            // 
            this.chk_feature_pcoin.AutoSize = true;
            this.chk_feature_pcoin.Checked = true;
            this.chk_feature_pcoin.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_feature_pcoin.Location = new System.Drawing.Point(432, 22);
            this.chk_feature_pcoin.Name = "chk_feature_pcoin";
            this.chk_feature_pcoin.Size = new System.Drawing.Size(68, 19);
            this.chk_feature_pcoin.TabIndex = 20;
            this.chk_feature_pcoin.Text = "P-Coins";
            this.chk_feature_pcoin.UseVisualStyleBackColor = true;
            this.chk_feature_pcoin.CheckedChanged += new System.EventHandler(this.chk_feature_filter_CheckedChanged);
            // 
            // chk_feature_other
            // 
            this.chk_feature_other.AutoSize = true;
            this.chk_feature_other.Checked = true;
            this.chk_feature_other.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_feature_other.Location = new System.Drawing.Point(514, 22);
            this.chk_feature_other.Name = "chk_feature_other";
            this.chk_feature_other.Size = new System.Drawing.Size(56, 19);
            this.chk_feature_other.TabIndex = 19;
            this.chk_feature_other.Text = "Other";
            this.chk_feature_other.UseVisualStyleBackColor = true;
            this.chk_feature_other.CheckedChanged += new System.EventHandler(this.chk_feature_filter_CheckedChanged);
            // 
            // chk_feature_keyItems
            // 
            this.chk_feature_keyItems.AutoSize = true;
            this.chk_feature_keyItems.Checked = true;
            this.chk_feature_keyItems.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_feature_keyItems.Location = new System.Drawing.Point(362, 47);
            this.chk_feature_keyItems.Name = "chk_feature_keyItems";
            this.chk_feature_keyItems.Size = new System.Drawing.Size(77, 19);
            this.chk_feature_keyItems.TabIndex = 18;
            this.chk_feature_keyItems.Text = "Key Items";
            this.chk_feature_keyItems.UseVisualStyleBackColor = true;
            this.chk_feature_keyItems.CheckedChanged += new System.EventHandler(this.chk_feature_filter_CheckedChanged);
            // 
            // chk_feature_swords
            // 
            this.chk_feature_swords.AutoSize = true;
            this.chk_feature_swords.Checked = true;
            this.chk_feature_swords.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_feature_swords.Location = new System.Drawing.Point(362, 22);
            this.chk_feature_swords.Name = "chk_feature_swords";
            this.chk_feature_swords.Size = new System.Drawing.Size(64, 19);
            this.chk_feature_swords.TabIndex = 17;
            this.chk_feature_swords.Text = "Swords";
            this.chk_feature_swords.UseVisualStyleBackColor = true;
            this.chk_feature_swords.CheckedChanged += new System.EventHandler(this.chk_feature_filter_CheckedChanged);
            // 
            // chk_feature_portals
            // 
            this.chk_feature_portals.AutoSize = true;
            this.chk_feature_portals.Checked = true;
            this.chk_feature_portals.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_feature_portals.Location = new System.Drawing.Point(6, 47);
            this.chk_feature_portals.Name = "chk_feature_portals";
            this.chk_feature_portals.Size = new System.Drawing.Size(95, 19);
            this.chk_feature_portals.TabIndex = 16;
            this.chk_feature_portals.Text = "Portal Stones";
            this.chk_feature_portals.UseVisualStyleBackColor = true;
            this.chk_feature_portals.CheckedChanged += new System.EventHandler(this.chk_feature_filter_CheckedChanged);
            // 
            // chk_feature_hearts
            // 
            this.chk_feature_hearts.AutoSize = true;
            this.chk_feature_hearts.Checked = true;
            this.chk_feature_hearts.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_feature_hearts.Location = new System.Drawing.Point(6, 22);
            this.chk_feature_hearts.Name = "chk_feature_hearts";
            this.chk_feature_hearts.Size = new System.Drawing.Size(60, 19);
            this.chk_feature_hearts.TabIndex = 8;
            this.chk_feature_hearts.Text = "Hearts";
            this.chk_feature_hearts.UseVisualStyleBackColor = true;
            this.chk_feature_hearts.CheckedChanged += new System.EventHandler(this.chk_feature_filter_CheckedChanged);
            // 
            // chk_feature_Gems
            // 
            this.chk_feature_Gems.AutoSize = true;
            this.chk_feature_Gems.Checked = true;
            this.chk_feature_Gems.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_feature_Gems.Location = new System.Drawing.Point(282, 47);
            this.chk_feature_Gems.Name = "chk_feature_Gems";
            this.chk_feature_Gems.Size = new System.Drawing.Size(56, 19);
            this.chk_feature_Gems.TabIndex = 15;
            this.chk_feature_Gems.Text = "Gems";
            this.chk_feature_Gems.UseVisualStyleBackColor = true;
            this.chk_feature_Gems.CheckedChanged += new System.EventHandler(this.chk_feature_filter_CheckedChanged);
            // 
            // chk_feature_unknown
            // 
            this.chk_feature_unknown.AutoSize = true;
            this.chk_feature_unknown.Checked = true;
            this.chk_feature_unknown.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_feature_unknown.Location = new System.Drawing.Point(514, 49);
            this.chk_feature_unknown.Name = "chk_feature_unknown";
            this.chk_feature_unknown.Size = new System.Drawing.Size(77, 19);
            this.chk_feature_unknown.TabIndex = 9;
            this.chk_feature_unknown.Text = "Unknown";
            this.chk_feature_unknown.UseVisualStyleBackColor = true;
            this.chk_feature_unknown.CheckedChanged += new System.EventHandler(this.chk_feature_filter_CheckedChanged);
            // 
            // chk_feature_treasures
            // 
            this.chk_feature_treasures.AutoSize = true;
            this.chk_feature_treasures.Checked = true;
            this.chk_feature_treasures.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_feature_treasures.Location = new System.Drawing.Point(282, 22);
            this.chk_feature_treasures.Name = "chk_feature_treasures";
            this.chk_feature_treasures.Size = new System.Drawing.Size(74, 19);
            this.chk_feature_treasures.TabIndex = 14;
            this.chk_feature_treasures.Text = "Treasures";
            this.chk_feature_treasures.UseVisualStyleBackColor = true;
            this.chk_feature_treasures.CheckedChanged += new System.EventHandler(this.chk_feature_filter_CheckedChanged);
            // 
            // chk_feature_gkey
            // 
            this.chk_feature_gkey.AutoSize = true;
            this.chk_feature_gkey.Checked = true;
            this.chk_feature_gkey.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_feature_gkey.Location = new System.Drawing.Point(101, 22);
            this.chk_feature_gkey.Name = "chk_feature_gkey";
            this.chk_feature_gkey.Size = new System.Drawing.Size(78, 19);
            this.chk_feature_gkey.TabIndex = 10;
            this.chk_feature_gkey.Text = "Gold Keys";
            this.chk_feature_gkey.UseVisualStyleBackColor = true;
            this.chk_feature_gkey.CheckedChanged += new System.EventHandler(this.chk_feature_filter_CheckedChanged);
            // 
            // chk_feature_sdoor
            // 
            this.chk_feature_sdoor.AutoSize = true;
            this.chk_feature_sdoor.Checked = true;
            this.chk_feature_sdoor.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_feature_sdoor.Location = new System.Drawing.Point(188, 47);
            this.chk_feature_sdoor.Name = "chk_feature_sdoor";
            this.chk_feature_sdoor.Size = new System.Drawing.Size(88, 19);
            this.chk_feature_sdoor.TabIndex = 13;
            this.chk_feature_sdoor.Text = "Silver Doors";
            this.chk_feature_sdoor.UseVisualStyleBackColor = true;
            this.chk_feature_sdoor.CheckedChanged += new System.EventHandler(this.chk_feature_filter_CheckedChanged);
            // 
            // chk_feature_skey
            // 
            this.chk_feature_skey.AutoSize = true;
            this.chk_feature_skey.Checked = true;
            this.chk_feature_skey.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_feature_skey.Location = new System.Drawing.Point(188, 22);
            this.chk_feature_skey.Name = "chk_feature_skey";
            this.chk_feature_skey.Size = new System.Drawing.Size(81, 19);
            this.chk_feature_skey.TabIndex = 11;
            this.chk_feature_skey.Text = "Silver Keys";
            this.chk_feature_skey.UseVisualStyleBackColor = true;
            this.chk_feature_skey.CheckedChanged += new System.EventHandler(this.chk_feature_filter_CheckedChanged);
            // 
            // chk_feature_gdoor
            // 
            this.chk_feature_gdoor.AutoSize = true;
            this.chk_feature_gdoor.Checked = true;
            this.chk_feature_gdoor.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_feature_gdoor.Location = new System.Drawing.Point(101, 47);
            this.chk_feature_gdoor.Name = "chk_feature_gdoor";
            this.chk_feature_gdoor.Size = new System.Drawing.Size(85, 19);
            this.chk_feature_gdoor.TabIndex = 12;
            this.chk_feature_gdoor.Text = "Gold Doors";
            this.chk_feature_gdoor.UseVisualStyleBackColor = true;
            this.chk_feature_gdoor.CheckedChanged += new System.EventHandler(this.chk_feature_filter_CheckedChanged);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(409, 20);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(101, 15);
            this.label18.TabIndex = 7;
            this.label18.Text = "Map Features Left";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(25, 20);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(107, 15);
            this.label17.TabIndex = 6;
            this.label17.Text = "Map Features Used";
            // 
            // btn_itemsRight
            // 
            this.btn_itemsRight.Location = new System.Drawing.Point(361, 185);
            this.btn_itemsRight.Name = "btn_itemsRight";
            this.btn_itemsRight.Size = new System.Drawing.Size(42, 23);
            this.btn_itemsRight.TabIndex = 5;
            this.btn_itemsRight.Text = ">>";
            this.btn_itemsRight.UseVisualStyleBackColor = true;
            this.btn_itemsRight.Click += new System.EventHandler(this.btn_itemsRight_Click);
            // 
            // btn_itemsLeft
            // 
            this.btn_itemsLeft.Location = new System.Drawing.Point(361, 147);
            this.btn_itemsLeft.Name = "btn_itemsLeft";
            this.btn_itemsLeft.Size = new System.Drawing.Size(42, 23);
            this.btn_itemsLeft.TabIndex = 4;
            this.btn_itemsLeft.Text = "<<";
            this.btn_itemsLeft.UseVisualStyleBackColor = true;
            this.btn_itemsLeft.Click += new System.EventHandler(this.btn_itemsLeft_Click);
            // 
            // list_allitems
            // 
            this.list_allitems.FormattingEnabled = true;
            this.list_allitems.ItemHeight = 15;
            this.list_allitems.Location = new System.Drawing.Point(409, 49);
            this.list_allitems.Name = "list_allitems";
            this.list_allitems.Size = new System.Drawing.Size(330, 214);
            this.list_allitems.TabIndex = 3;
            this.list_allitems.SelectedIndexChanged += new System.EventHandler(this.list_allitems_SelectedIndexChanged);
            // 
            // list_flags
            // 
            this.list_flags.FormattingEnabled = true;
            this.list_flags.ItemHeight = 15;
            this.list_flags.Location = new System.Drawing.Point(25, 49);
            this.list_flags.Name = "list_flags";
            this.list_flags.Size = new System.Drawing.Size(330, 214);
            this.list_flags.TabIndex = 2;
            this.list_flags.SelectedIndexChanged += new System.EventHandler(this.list_flags_SelectedIndexChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label20);
            this.tabPage3.Controls.Add(this.list_missedPercent);
            this.tabPage3.Controls.Add(this.list_xtraPercent);
            this.tabPage3.Controls.Add(this.list_values);
            this.tabPage3.Location = new System.Drawing.Point(4, 24);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(768, 370);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Data Breakdown";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(341, 11);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(95, 15);
            this.label20.TabIndex = 3;
            this.label20.Text = "Missed Percents:";
            // 
            // list_missedPercent
            // 
            this.list_missedPercent.FormattingEnabled = true;
            this.list_missedPercent.ItemHeight = 15;
            this.list_missedPercent.Location = new System.Drawing.Point(341, 29);
            this.list_missedPercent.Name = "list_missedPercent";
            this.list_missedPercent.Size = new System.Drawing.Size(406, 169);
            this.list_missedPercent.TabIndex = 2;
            // 
            // list_xtraPercent
            // 
            this.list_xtraPercent.FormattingEnabled = true;
            this.list_xtraPercent.ItemHeight = 15;
            this.list_xtraPercent.Location = new System.Drawing.Point(9, 213);
            this.list_xtraPercent.Name = "list_xtraPercent";
            this.list_xtraPercent.Size = new System.Drawing.Size(738, 154);
            this.list_xtraPercent.TabIndex = 1;
            // 
            // list_values
            // 
            this.list_values.FormattingEnabled = true;
            this.list_values.ItemHeight = 15;
            this.list_values.Location = new System.Drawing.Point(9, 14);
            this.list_values.Name = "list_values";
            this.list_values.Size = new System.Drawing.Size(326, 184);
            this.list_values.TabIndex = 0;
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(151, 11);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(133, 23);
            this.btn_save.TabIndex = 2;
            this.btn_save.Text = "Export Save File";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // btn_OpenMap
            // 
            this.btn_OpenMap.Location = new System.Drawing.Point(290, 11);
            this.btn_OpenMap.Name = "btn_OpenMap";
            this.btn_OpenMap.Size = new System.Drawing.Size(120, 23);
            this.btn_OpenMap.TabIndex = 3;
            this.btn_OpenMap.Text = "Open Map Viewer";
            this.btn_OpenMap.UseVisualStyleBackColor = true;
            this.btn_OpenMap.Click += new System.EventHandler(this.btn_OpenMap_Click);
            // 
            // btn_config
            // 
            this.btn_config.Location = new System.Drawing.Point(692, 11);
            this.btn_config.Name = "btn_config";
            this.btn_config.Size = new System.Drawing.Size(92, 23);
            this.btn_config.TabIndex = 4;
            this.btn_config.Text = "Configuration";
            this.btn_config.UseVisualStyleBackColor = true;
            this.btn_config.Click += new System.EventHandler(this.btn_config_Click);
            // 
            // cb_GameMode
            // 
            this.cb_GameMode.FormattingEnabled = true;
            this.cb_GameMode.Location = new System.Drawing.Point(416, 12);
            this.cb_GameMode.Name = "cb_GameMode";
            this.cb_GameMode.Size = new System.Drawing.Size(144, 23);
            this.cb_GameMode.TabIndex = 19;
            this.cb_GameMode.SelectedIndexChanged += new System.EventHandler(this.cb_GameMode_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cb_GameMode);
            this.Controls.Add(this.btn_config);
            this.Controls.Add(this.btn_OpenMap);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.tab_saveData);
            this.Controls.Add(this.btn_loadSaveFile);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tab_saveData.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.box_kills)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.box_deaths)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Button btn_loadSaveFile;
        private TabControl tab_saveData;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private Label label1;
        private TextBox box_steps;
        private Label label2;
        private TextBox box_time;
        private Label label5;
        private NumericUpDown box_deaths;
        private CheckBox chk_bHeart;
        private Button btn_save;
        private ListBox list_values;
        private ComboBox combo_SaveLocation;
        private Label label6;
        private Label label8;
        private Label label7;
        private TextBox txt_SaveLocationX;
        private TextBox txt_SaveLocationY;
        private Label label9;
        private TextBox txt_SaveLocationD;
        private Label label16;
        private TabPage tabPage4;
        private ListBox list_allitems;
        private ListBox list_flags;
        private Button btn_itemsRight;
        private Button btn_itemsLeft;
        private Label label18;
        private Label label17;
        private CheckBox chk_feature_unknown;
        private CheckBox chk_feature_hearts;
        private CheckBox chk_feature_sdoor;
        private CheckBox chk_feature_gdoor;
        private CheckBox chk_feature_skey;
        private CheckBox chk_feature_gkey;
        private CheckBox chk_feature_Gems;
        private CheckBox chk_feature_treasures;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private CheckBox chk_feature_portals;
        private CheckBox chk_feature_swords;
        private CheckBox chk_feature_keyItems;
        private Label label19;
        private TextBox txt_percent;
        private ListBox list_xtraPercent;
        private Label label20;
        private ListBox list_missedPercent;
        private NumericUpDown box_kills;
        private Label label21;
        private Button btn_OpenMap;
        private CheckBox chk_witchEnding;
        private Label label22;
        private TextBox txt_convergePercent;
        private Label label23;
        private TextBox txt_witchBasic;
        private Label label25;
        private TextBox txt_witchPerfect;
        private Label label24;
        private ComboBox combo_map;
        private CheckBox chk_feature_other;
        private CheckBox chk_feature_pcoin;
        private Label label30;
        private Label label34;
        private Label label33;
        private Label lbl_uncollectedCount;
        private Label lbl_collectedCount;
        private Label label36;
        private TextBox txt_bloodmoonCount;
        private CheckBox chk_bloodmoon;
        private Button btn_config;
        private ComboBox cb_GameMode;
        private CheckedListBox chk_Equipment;
        private ListBox box_item;
        private ListBox box_story;
        private Label label3;
    }
}