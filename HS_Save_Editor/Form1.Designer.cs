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
            this.label9 = new System.Windows.Forms.Label();
            this.txt_SaveLocationD = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_SaveLocationX = new System.Windows.Forms.TextBox();
            this.txt_SaveLocationY = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.combo_SaveLocation = new System.Windows.Forms.ComboBox();
            this.chk_greenSword = new System.Windows.Forms.CheckBox();
            this.chk_rShield = new System.Windows.Forms.CheckBox();
            this.chk_rSword = new System.Windows.Forms.CheckBox();
            this.chk_bHeart = new System.Windows.Forms.CheckBox();
            this.chk_bShield = new System.Windows.Forms.CheckBox();
            this.chk_bSword = new System.Windows.Forms.CheckBox();
            this.box_deaths = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.box_time = new System.Windows.Forms.TextBox();
            this.box_swords = new System.Windows.Forms.NumericUpDown();
            this.box_hearts = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.box_steps = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txt_silverKey = new System.Windows.Forms.TextBox();
            this.txt_treasure = new System.Windows.Forms.TextBox();
            this.txt_possum = new System.Windows.Forms.TextBox();
            this.txt_goldKey = new System.Windows.Forms.TextBox();
            this.txt_Gems = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txt_portalStones = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.chk_broom = new System.Windows.Forms.CheckBox();
            this.chk_spectacles = new System.Windows.Forms.CheckBox();
            this.chk_compass = new System.Windows.Forms.CheckBox();
            this.chk_mirror = new System.Windows.Forms.CheckBox();
            this.chk_saveCrystals = new System.Windows.Forms.CheckBox();
            this.chk_smugglersEye = new System.Windows.Forms.CheckBox();
            this.chk_bobs = new System.Windows.Forms.CheckBox();
            this.chk_skeletonKey = new System.Windows.Forms.CheckBox();
            this.chk_windRing = new System.Windows.Forms.CheckBox();
            this.chk_boots = new System.Windows.Forms.CheckBox();
            this.chk_lavaCharm = new System.Windows.Forms.CheckBox();
            this.chk_hammer = new System.Windows.Forms.CheckBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.chk_onlyFalse = new System.Windows.Forms.CheckBox();
            this.list_flags = new System.Windows.Forms.ListBox();
            this.list_values = new System.Windows.Forms.ListBox();
            this.btn_save = new System.Windows.Forms.Button();
            this.tab_saveData.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.box_deaths)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.box_swords)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.box_hearts)).BeginInit();
            this.tabPage2.SuspendLayout();
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
            this.tab_saveData.Controls.Add(this.tabPage3);
            this.tab_saveData.Location = new System.Drawing.Point(12, 40);
            this.tab_saveData.Name = "tab_saveData";
            this.tab_saveData.SelectedIndex = 0;
            this.tab_saveData.Size = new System.Drawing.Size(776, 398);
            this.tab_saveData.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.txt_SaveLocationD);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.txt_SaveLocationX);
            this.tabPage1.Controls.Add(this.txt_SaveLocationY);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.combo_SaveLocation);
            this.tabPage1.Controls.Add(this.chk_greenSword);
            this.tabPage1.Controls.Add(this.chk_rShield);
            this.tabPage1.Controls.Add(this.chk_rSword);
            this.tabPage1.Controls.Add(this.chk_bHeart);
            this.tabPage1.Controls.Add(this.chk_bShield);
            this.tabPage1.Controls.Add(this.chk_bSword);
            this.tabPage1.Controls.Add(this.box_deaths);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.box_time);
            this.tabPage1.Controls.Add(this.box_swords);
            this.tabPage1.Controls.Add(this.box_hearts);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
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
            // 
            // txt_SaveLocationY
            // 
            this.txt_SaveLocationY.Location = new System.Drawing.Point(305, 130);
            this.txt_SaveLocationY.Name = "txt_SaveLocationY";
            this.txt_SaveLocationY.Size = new System.Drawing.Size(40, 23);
            this.txt_SaveLocationY.TabIndex = 22;
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
            // 
            // chk_greenSword
            // 
            this.chk_greenSword.AutoSize = true;
            this.chk_greenSword.Location = new System.Drawing.Point(506, 190);
            this.chk_greenSword.Name = "chk_greenSword";
            this.chk_greenSword.Size = new System.Drawing.Size(93, 19);
            this.chk_greenSword.TabIndex = 20;
            this.chk_greenSword.Text = "Green Sword";
            this.chk_greenSword.UseVisualStyleBackColor = true;
            // 
            // chk_rShield
            // 
            this.chk_rShield.AutoSize = true;
            this.chk_rShield.Location = new System.Drawing.Point(622, 118);
            this.chk_rShield.Name = "chk_rShield";
            this.chk_rShield.Size = new System.Drawing.Size(81, 19);
            this.chk_rShield.TabIndex = 19;
            this.chk_rShield.Text = "Red Shield";
            this.chk_rShield.UseVisualStyleBackColor = true;
            // 
            // chk_rSword
            // 
            this.chk_rSword.AutoSize = true;
            this.chk_rSword.Location = new System.Drawing.Point(622, 82);
            this.chk_rSword.Name = "chk_rSword";
            this.chk_rSword.Size = new System.Drawing.Size(82, 19);
            this.chk_rSword.TabIndex = 18;
            this.chk_rSword.Text = "Red Sword";
            this.chk_rSword.UseVisualStyleBackColor = true;
            // 
            // chk_bHeart
            // 
            this.chk_bHeart.AutoSize = true;
            this.chk_bHeart.Location = new System.Drawing.Point(506, 156);
            this.chk_bHeart.Name = "chk_bHeart";
            this.chk_bHeart.Size = new System.Drawing.Size(81, 19);
            this.chk_bHeart.TabIndex = 17;
            this.chk_bHeart.Text = "Blue Heart";
            this.chk_bHeart.UseVisualStyleBackColor = true;
            // 
            // chk_bShield
            // 
            this.chk_bShield.AutoSize = true;
            this.chk_bShield.Location = new System.Drawing.Point(506, 118);
            this.chk_bShield.Name = "chk_bShield";
            this.chk_bShield.Size = new System.Drawing.Size(84, 19);
            this.chk_bShield.TabIndex = 16;
            this.chk_bShield.Text = "Blue Shield";
            this.chk_bShield.UseVisualStyleBackColor = true;
            // 
            // chk_bSword
            // 
            this.chk_bSword.AutoSize = true;
            this.chk_bSword.Location = new System.Drawing.Point(506, 82);
            this.chk_bSword.Name = "chk_bSword";
            this.chk_bSword.Size = new System.Drawing.Size(85, 19);
            this.chk_bSword.TabIndex = 15;
            this.chk_bSword.Text = "Blue Sword";
            this.chk_bSword.UseVisualStyleBackColor = true;
            // 
            // box_deaths
            // 
            this.box_deaths.Location = new System.Drawing.Point(104, 88);
            this.box_deaths.Name = "box_deaths";
            this.box_deaths.Size = new System.Drawing.Size(120, 23);
            this.box_deaths.TabIndex = 10;
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
            this.box_time.Location = new System.Drawing.Point(104, 46);
            this.box_time.Name = "box_time";
            this.box_time.Size = new System.Drawing.Size(120, 23);
            this.box_time.TabIndex = 8;
            // 
            // box_swords
            // 
            this.box_swords.Location = new System.Drawing.Point(573, 9);
            this.box_swords.Name = "box_swords";
            this.box_swords.Size = new System.Drawing.Size(120, 23);
            this.box_swords.TabIndex = 7;
            // 
            // box_hearts
            // 
            this.box_hearts.Location = new System.Drawing.Point(573, 44);
            this.box_hearts.Name = "box_hearts";
            this.box_hearts.Size = new System.Drawing.Size(120, 23);
            this.box_hearts.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(502, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 15);
            this.label4.TabIndex = 4;
            this.label4.Text = "Swords";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(506, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Hearts";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Total Time";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Total Steps";
            // 
            // box_steps
            // 
            this.box_steps.Location = new System.Drawing.Point(104, 6);
            this.box_steps.Name = "box_steps";
            this.box_steps.Size = new System.Drawing.Size(120, 23);
            this.box_steps.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txt_silverKey);
            this.tabPage2.Controls.Add(this.txt_treasure);
            this.tabPage2.Controls.Add(this.txt_possum);
            this.tabPage2.Controls.Add(this.txt_goldKey);
            this.tabPage2.Controls.Add(this.txt_Gems);
            this.tabPage2.Controls.Add(this.label16);
            this.tabPage2.Controls.Add(this.txt_portalStones);
            this.tabPage2.Controls.Add(this.label15);
            this.tabPage2.Controls.Add(this.label14);
            this.tabPage2.Controls.Add(this.label13);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.chk_broom);
            this.tabPage2.Controls.Add(this.chk_spectacles);
            this.tabPage2.Controls.Add(this.chk_compass);
            this.tabPage2.Controls.Add(this.chk_mirror);
            this.tabPage2.Controls.Add(this.chk_saveCrystals);
            this.tabPage2.Controls.Add(this.chk_smugglersEye);
            this.tabPage2.Controls.Add(this.chk_bobs);
            this.tabPage2.Controls.Add(this.chk_skeletonKey);
            this.tabPage2.Controls.Add(this.chk_windRing);
            this.tabPage2.Controls.Add(this.chk_boots);
            this.tabPage2.Controls.Add(this.chk_lavaCharm);
            this.tabPage2.Controls.Add(this.chk_hammer);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(768, 370);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Collectibles";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // txt_silverKey
            // 
            this.txt_silverKey.Location = new System.Drawing.Point(589, 124);
            this.txt_silverKey.Name = "txt_silverKey";
            this.txt_silverKey.Size = new System.Drawing.Size(60, 23);
            this.txt_silverKey.TabIndex = 50;
            // 
            // txt_treasure
            // 
            this.txt_treasure.Location = new System.Drawing.Point(589, 55);
            this.txt_treasure.Name = "txt_treasure";
            this.txt_treasure.Size = new System.Drawing.Size(60, 23);
            this.txt_treasure.TabIndex = 49;
            // 
            // txt_possum
            // 
            this.txt_possum.Location = new System.Drawing.Point(421, 91);
            this.txt_possum.Name = "txt_possum";
            this.txt_possum.Size = new System.Drawing.Size(60, 23);
            this.txt_possum.TabIndex = 48;
            // 
            // txt_goldKey
            // 
            this.txt_goldKey.Location = new System.Drawing.Point(589, 91);
            this.txt_goldKey.Name = "txt_goldKey";
            this.txt_goldKey.Size = new System.Drawing.Size(60, 23);
            this.txt_goldKey.TabIndex = 47;
            // 
            // txt_Gems
            // 
            this.txt_Gems.Location = new System.Drawing.Point(421, 124);
            this.txt_Gems.Name = "txt_Gems";
            this.txt_Gems.Size = new System.Drawing.Size(60, 23);
            this.txt_Gems.TabIndex = 46;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label16.Location = new System.Drawing.Point(327, 7);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(246, 20);
            this.label16.TabIndex = 45;
            this.label16.Text = "Collectibles (Current/Spent/Total)";
            // 
            // txt_portalStones
            // 
            this.txt_portalStones.Location = new System.Drawing.Point(421, 55);
            this.txt_portalStones.Name = "txt_portalStones";
            this.txt_portalStones.Size = new System.Drawing.Size(60, 23);
            this.txt_portalStones.TabIndex = 44;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(329, 94);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(82, 15);
            this.label15.TabIndex = 43;
            this.label15.Text = "Possum Coins";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(374, 127);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(37, 15);
            this.label14.TabIndex = 42;
            this.label14.Text = "Gems";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(533, 58);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(50, 15);
            this.label13.TabIndex = 41;
            this.label13.Text = "Treasure";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(524, 94);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(59, 15);
            this.label12.TabIndex = 40;
            this.label12.Text = "Gold Keys";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(521, 127);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(62, 15);
            this.label11.TabIndex = 39;
            this.label11.Text = "Silver Keys";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(335, 58);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(76, 15);
            this.label10.TabIndex = 38;
            this.label10.Text = "Portal Stones";
            // 
            // chk_broom
            // 
            this.chk_broom.AutoSize = true;
            this.chk_broom.Location = new System.Drawing.Point(122, 151);
            this.chk_broom.Name = "chk_broom";
            this.chk_broom.Size = new System.Drawing.Size(62, 19);
            this.chk_broom.TabIndex = 32;
            this.chk_broom.Text = "Broom";
            this.chk_broom.UseVisualStyleBackColor = true;
            // 
            // chk_spectacles
            // 
            this.chk_spectacles.AutoSize = true;
            this.chk_spectacles.Location = new System.Drawing.Point(6, 151);
            this.chk_spectacles.Name = "chk_spectacles";
            this.chk_spectacles.Size = new System.Drawing.Size(81, 19);
            this.chk_spectacles.TabIndex = 31;
            this.chk_spectacles.Text = "Spectacles";
            this.chk_spectacles.UseVisualStyleBackColor = true;
            // 
            // chk_compass
            // 
            this.chk_compass.AutoSize = true;
            this.chk_compass.Location = new System.Drawing.Point(122, 117);
            this.chk_compass.Name = "chk_compass";
            this.chk_compass.Size = new System.Drawing.Size(75, 19);
            this.chk_compass.TabIndex = 30;
            this.chk_compass.Text = "Compass";
            this.chk_compass.UseVisualStyleBackColor = true;
            // 
            // chk_mirror
            // 
            this.chk_mirror.AutoSize = true;
            this.chk_mirror.Location = new System.Drawing.Point(6, 184);
            this.chk_mirror.Name = "chk_mirror";
            this.chk_mirror.Size = new System.Drawing.Size(59, 19);
            this.chk_mirror.TabIndex = 29;
            this.chk_mirror.Text = "Mirror";
            this.chk_mirror.UseVisualStyleBackColor = true;
            // 
            // chk_saveCrystals
            // 
            this.chk_saveCrystals.AutoSize = true;
            this.chk_saveCrystals.Location = new System.Drawing.Point(122, 184);
            this.chk_saveCrystals.Name = "chk_saveCrystals";
            this.chk_saveCrystals.Size = new System.Drawing.Size(94, 19);
            this.chk_saveCrystals.TabIndex = 28;
            this.chk_saveCrystals.Text = "Save Crystals";
            this.chk_saveCrystals.UseVisualStyleBackColor = true;
            // 
            // chk_smugglersEye
            // 
            this.chk_smugglersEye.AutoSize = true;
            this.chk_smugglersEye.Location = new System.Drawing.Point(6, 117);
            this.chk_smugglersEye.Name = "chk_smugglersEye";
            this.chk_smugglersEye.Size = new System.Drawing.Size(106, 19);
            this.chk_smugglersEye.TabIndex = 26;
            this.chk_smugglersEye.Text = "Smuggler\'s Eye";
            this.chk_smugglersEye.UseVisualStyleBackColor = true;
            // 
            // chk_bobs
            // 
            this.chk_bobs.AutoSize = true;
            this.chk_bobs.Location = new System.Drawing.Point(122, 80);
            this.chk_bobs.Name = "chk_bobs";
            this.chk_bobs.Size = new System.Drawing.Size(55, 19);
            this.chk_bobs.TabIndex = 25;
            this.chk_bobs.Text = "BOBS";
            this.chk_bobs.UseVisualStyleBackColor = true;
            // 
            // chk_skeletonKey
            // 
            this.chk_skeletonKey.AutoSize = true;
            this.chk_skeletonKey.Location = new System.Drawing.Point(122, 42);
            this.chk_skeletonKey.Name = "chk_skeletonKey";
            this.chk_skeletonKey.Size = new System.Drawing.Size(93, 19);
            this.chk_skeletonKey.TabIndex = 24;
            this.chk_skeletonKey.Text = "Skeleton Key";
            this.chk_skeletonKey.UseVisualStyleBackColor = true;
            // 
            // chk_windRing
            // 
            this.chk_windRing.AutoSize = true;
            this.chk_windRing.Location = new System.Drawing.Point(122, 6);
            this.chk_windRing.Name = "chk_windRing";
            this.chk_windRing.Size = new System.Drawing.Size(81, 19);
            this.chk_windRing.TabIndex = 23;
            this.chk_windRing.Text = "Wind Ring";
            this.chk_windRing.UseVisualStyleBackColor = true;
            // 
            // chk_boots
            // 
            this.chk_boots.AutoSize = true;
            this.chk_boots.Location = new System.Drawing.Point(6, 80);
            this.chk_boots.Name = "chk_boots";
            this.chk_boots.Size = new System.Drawing.Size(56, 19);
            this.chk_boots.TabIndex = 22;
            this.chk_boots.Text = "Boots";
            this.chk_boots.UseVisualStyleBackColor = true;
            // 
            // chk_lavaCharm
            // 
            this.chk_lavaCharm.AutoSize = true;
            this.chk_lavaCharm.Location = new System.Drawing.Point(6, 42);
            this.chk_lavaCharm.Name = "chk_lavaCharm";
            this.chk_lavaCharm.Size = new System.Drawing.Size(89, 19);
            this.chk_lavaCharm.TabIndex = 21;
            this.chk_lavaCharm.Text = "Lava Charm";
            this.chk_lavaCharm.UseVisualStyleBackColor = true;
            // 
            // chk_hammer
            // 
            this.chk_hammer.AutoSize = true;
            this.chk_hammer.Location = new System.Drawing.Point(6, 6);
            this.chk_hammer.Name = "chk_hammer";
            this.chk_hammer.Size = new System.Drawing.Size(73, 19);
            this.chk_hammer.TabIndex = 20;
            this.chk_hammer.Text = "Hammer";
            this.chk_hammer.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.chk_onlyFalse);
            this.tabPage3.Controls.Add(this.list_flags);
            this.tabPage3.Controls.Add(this.list_values);
            this.tabPage3.Location = new System.Drawing.Point(4, 24);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(768, 370);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "All Values";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // chk_onlyFalse
            // 
            this.chk_onlyFalse.AutoSize = true;
            this.chk_onlyFalse.Checked = true;
            this.chk_onlyFalse.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_onlyFalse.Location = new System.Drawing.Point(421, 14);
            this.chk_onlyFalse.Name = "chk_onlyFalse";
            this.chk_onlyFalse.Size = new System.Drawing.Size(112, 19);
            this.chk_onlyFalse.TabIndex = 2;
            this.chk_onlyFalse.Text = "Show Only False";
            this.chk_onlyFalse.UseVisualStyleBackColor = true;
            this.chk_onlyFalse.CheckedChanged += new System.EventHandler(this.chk_onlyFalse_CheckedChanged);
            // 
            // list_flags
            // 
            this.list_flags.FormattingEnabled = true;
            this.list_flags.ItemHeight = 15;
            this.list_flags.Location = new System.Drawing.Point(421, 44);
            this.list_flags.Name = "list_flags";
            this.list_flags.Size = new System.Drawing.Size(315, 304);
            this.list_flags.TabIndex = 1;
            // 
            // list_values
            // 
            this.list_values.FormattingEnabled = true;
            this.list_values.ItemHeight = 15;
            this.list_values.Location = new System.Drawing.Point(9, 14);
            this.list_values.Name = "list_values";
            this.list_values.Size = new System.Drawing.Size(361, 334);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.tab_saveData);
            this.Controls.Add(this.btn_loadSaveFile);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tab_saveData.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.box_deaths)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.box_swords)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.box_hearts)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
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
        private Label label4;
        private Label label3;
        private Label label2;
        private NumericUpDown box_swords;
        private NumericUpDown box_hearts;
        private TextBox box_time;
        private Label label5;
        private NumericUpDown box_deaths;
        private CheckBox chk_bHeart;
        private CheckBox chk_bShield;
        private CheckBox chk_bSword;
        private CheckBox chk_rShield;
        private CheckBox chk_rSword;
        private CheckBox chk_bobs;
        private CheckBox chk_skeletonKey;
        private CheckBox chk_windRing;
        private CheckBox chk_boots;
        private CheckBox chk_lavaCharm;
        private CheckBox chk_hammer;
        private CheckBox chk_broom;
        private CheckBox chk_spectacles;
        private CheckBox chk_compass;
        private CheckBox chk_mirror;
        private CheckBox chk_saveCrystals;
        private CheckBox chk_smugglersEye;
        private Button btn_save;
        private CheckBox chk_greenSword;
        private ListBox list_values;
        private ListBox list_flags;
        private ComboBox combo_SaveLocation;
        private Label label6;
        private Label label8;
        private Label label7;
        private TextBox txt_SaveLocationX;
        private TextBox txt_SaveLocationY;
        private Label label9;
        private TextBox txt_SaveLocationD;
        private Label label15;
        private Label label14;
        private Label label13;
        private Label label12;
        private Label label11;
        private Label label10;
        private TextBox txt_portalStones;
        private Label label16;
        private TextBox txt_treasure;
        private TextBox txt_possum;
        private TextBox txt_goldKey;
        private TextBox txt_Gems;
        private TextBox txt_silverKey;
        private CheckBox chk_onlyFalse;
    }
}