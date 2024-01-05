namespace HS_Save_Editor
{
    partial class mainForm
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
            this.tabBasicInfo = new System.Windows.Forms.TabPage();
            this.cBasicInfo = new HS_Save_Editor.CBasicInfo();
            this.tabStory = new System.Windows.Forms.TabPage();
            this.cStory = new HS_Save_Editor.CStory();
            this.tabEquipment = new System.Windows.Forms.TabPage();
            this.cEquipment = new HS_Save_Editor.CEquipment();
            this.tabItems = new System.Windows.Forms.TabPage();
            this.cItems = new HS_Save_Editor.Controls.CItems();
            this.tabEntities = new System.Windows.Forms.TabPage();
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
            this.tabDataBreakdown = new System.Windows.Forms.TabPage();
            this.label20 = new System.Windows.Forms.Label();
            this.list_missedPercent = new System.Windows.Forms.ListBox();
            this.list_xtraPercent = new System.Windows.Forms.ListBox();
            this.list_values = new System.Windows.Forms.ListBox();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_OpenMap = new System.Windows.Forms.Button();
            this.btn_config = new System.Windows.Forms.Button();
            this.cb_GameMode = new System.Windows.Forms.ComboBox();
            this.tab_saveData.SuspendLayout();
            this.tabBasicInfo.SuspendLayout();
            this.tabStory.SuspendLayout();
            this.tabEquipment.SuspendLayout();
            this.tabItems.SuspendLayout();
            this.tabEntities.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabDataBreakdown.SuspendLayout();
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
            this.tab_saveData.Controls.Add(this.tabBasicInfo);
            this.tab_saveData.Controls.Add(this.tabStory);
            this.tab_saveData.Controls.Add(this.tabEquipment);
            this.tab_saveData.Controls.Add(this.tabItems);
            this.tab_saveData.Controls.Add(this.tabEntities);
            this.tab_saveData.Controls.Add(this.tabDataBreakdown);
            this.tab_saveData.Location = new System.Drawing.Point(12, 40);
            this.tab_saveData.Name = "tab_saveData";
            this.tab_saveData.SelectedIndex = 0;
            this.tab_saveData.Size = new System.Drawing.Size(776, 398);
            this.tab_saveData.TabIndex = 1;
            this.tab_saveData.SelectedIndexChanged += new System.EventHandler(this.tab_saveData_SelectedIndexChanged);
            // 
            // tabBasicInfo
            // 
            this.tabBasicInfo.Controls.Add(this.cBasicInfo);
            this.tabBasicInfo.Location = new System.Drawing.Point(4, 24);
            this.tabBasicInfo.Name = "tabBasicInfo";
            this.tabBasicInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabBasicInfo.Size = new System.Drawing.Size(768, 370);
            this.tabBasicInfo.TabIndex = 0;
            this.tabBasicInfo.Text = "Basic Info";
            this.tabBasicInfo.UseVisualStyleBackColor = true;
            // 
            // cBasicInfo
            // 
            this.cBasicInfo.ImeMode = System.Windows.Forms.ImeMode.On;
            this.cBasicInfo.Location = new System.Drawing.Point(0, 0);
            this.cBasicInfo.Name = "cBasicInfo";
            this.cBasicInfo.Size = new System.Drawing.Size(768, 370);
            this.cBasicInfo.TabIndex = 0;
            // 
            // tabStory
            // 
            this.tabStory.Controls.Add(this.cStory);
            this.tabStory.Location = new System.Drawing.Point(4, 24);
            this.tabStory.Name = "tabStory";
            this.tabStory.Size = new System.Drawing.Size(768, 370);
            this.tabStory.TabIndex = 4;
            this.tabStory.Text = "Story";
            this.tabStory.UseVisualStyleBackColor = true;
            // 
            // cStory
            // 
            this.cStory.Location = new System.Drawing.Point(3, 0);
            this.cStory.Name = "cStory";
            this.cStory.Size = new System.Drawing.Size(415, 370);
            this.cStory.TabIndex = 42;
            // 
            // tabEquipment
            // 
            this.tabEquipment.Controls.Add(this.cEquipment);
            this.tabEquipment.Location = new System.Drawing.Point(4, 24);
            this.tabEquipment.Name = "tabEquipment";
            this.tabEquipment.Size = new System.Drawing.Size(768, 370);
            this.tabEquipment.TabIndex = 5;
            this.tabEquipment.Text = "Equipment";
            this.tabEquipment.UseVisualStyleBackColor = true;
            // 
            // cEquipment
            // 
            this.cEquipment.Location = new System.Drawing.Point(-4, 0);
            this.cEquipment.Name = "cEquipment";
            this.cEquipment.Size = new System.Drawing.Size(415, 370);
            this.cEquipment.TabIndex = 0;
            // 
            // tabItems
            // 
            this.tabItems.Controls.Add(this.cItems);
            this.tabItems.Location = new System.Drawing.Point(4, 24);
            this.tabItems.Name = "tabItems";
            this.tabItems.Padding = new System.Windows.Forms.Padding(3);
            this.tabItems.Size = new System.Drawing.Size(768, 370);
            this.tabItems.TabIndex = 1;
            this.tabItems.Text = "Items";
            this.tabItems.UseVisualStyleBackColor = true;
            // 
            // cItems
            // 
            this.cItems.Location = new System.Drawing.Point(0, 0);
            this.cItems.Name = "cItems";
            this.cItems.Size = new System.Drawing.Size(415, 370);
            this.cItems.TabIndex = 0;
            // 
            // tabEntities
            // 
            this.tabEntities.Controls.Add(this.lbl_uncollectedCount);
            this.tabEntities.Controls.Add(this.lbl_collectedCount);
            this.tabEntities.Controls.Add(this.label34);
            this.tabEntities.Controls.Add(this.label33);
            this.tabEntities.Controls.Add(this.groupBox2);
            this.tabEntities.Controls.Add(this.groupBox1);
            this.tabEntities.Controls.Add(this.label18);
            this.tabEntities.Controls.Add(this.label17);
            this.tabEntities.Controls.Add(this.btn_itemsRight);
            this.tabEntities.Controls.Add(this.btn_itemsLeft);
            this.tabEntities.Controls.Add(this.list_allitems);
            this.tabEntities.Controls.Add(this.list_flags);
            this.tabEntities.Location = new System.Drawing.Point(4, 24);
            this.tabEntities.Name = "tabEntities";
            this.tabEntities.Padding = new System.Windows.Forms.Padding(3);
            this.tabEntities.Size = new System.Drawing.Size(768, 370);
            this.tabEntities.TabIndex = 3;
            this.tabEntities.Text = "Entities";
            this.tabEntities.UseVisualStyleBackColor = true;
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
            // tabDataBreakdown
            // 
            this.tabDataBreakdown.Controls.Add(this.label20);
            this.tabDataBreakdown.Controls.Add(this.list_missedPercent);
            this.tabDataBreakdown.Controls.Add(this.list_xtraPercent);
            this.tabDataBreakdown.Controls.Add(this.list_values);
            this.tabDataBreakdown.Location = new System.Drawing.Point(4, 24);
            this.tabDataBreakdown.Name = "tabDataBreakdown";
            this.tabDataBreakdown.Size = new System.Drawing.Size(768, 370);
            this.tabDataBreakdown.TabIndex = 2;
            this.tabDataBreakdown.Text = "Data Breakdown";
            this.tabDataBreakdown.UseVisualStyleBackColor = true;
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
            // mainForm
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
            this.KeyPreview = true;
            this.Name = "mainForm";
            this.Text = "Hero\'s Spirit Save Editor";
            this.tab_saveData.ResumeLayout(false);
            this.tabBasicInfo.ResumeLayout(false);
            this.tabStory.ResumeLayout(false);
            this.tabEquipment.ResumeLayout(false);
            this.tabItems.ResumeLayout(false);
            this.tabEntities.ResumeLayout(false);
            this.tabEntities.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabDataBreakdown.ResumeLayout(false);
            this.tabDataBreakdown.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Button btn_loadSaveFile;
        private TabControl tab_saveData;
        private TabPage tabBasicInfo;
        private TabPage tabItems;
        private TabPage tabDataBreakdown;
        private CheckBox chk_bHeart;
        private Button btn_save;
        private ListBox list_values;
        private TabPage tabEntities;
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
        private ListBox list_xtraPercent;
        private Label label20;
        private ListBox list_missedPercent;
        private Button btn_OpenMap;
        private ComboBox combo_map;
        private CheckBox chk_feature_other;
        private CheckBox chk_feature_pcoin;
        private Label label34;
        private Label label33;
        private Label lbl_uncollectedCount;
        private Label lbl_collectedCount;
        private Label label36;
        private TextBox txt_bloodmoonCount;
        private CheckBox chk_bloodmoon;
        private Button btn_config;
        private ComboBox cb_GameMode;
        private CBasicInfo cBasicInfo;
        private TabPage tabStory;
        private TabPage tabEquipment;
        private CStory cStory;
        private CEquipment cEquipment;
        private Controls.CItems cItems;
    }
}