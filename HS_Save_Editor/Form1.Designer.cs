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
            this.list_values = new System.Windows.Forms.ListBox();
            this.btn_save = new System.Windows.Forms.Button();
            this.list_flags = new System.Windows.Forms.ListBox();
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
            // chk_greenSword
            // 
            this.chk_greenSword.AutoSize = true;
            this.chk_greenSword.Location = new System.Drawing.Point(416, 178);
            this.chk_greenSword.Name = "chk_greenSword";
            this.chk_greenSword.Size = new System.Drawing.Size(93, 19);
            this.chk_greenSword.TabIndex = 20;
            this.chk_greenSword.Text = "Green Sword";
            this.chk_greenSword.UseVisualStyleBackColor = true;
            // 
            // chk_rShield
            // 
            this.chk_rShield.AutoSize = true;
            this.chk_rShield.Location = new System.Drawing.Point(532, 115);
            this.chk_rShield.Name = "chk_rShield";
            this.chk_rShield.Size = new System.Drawing.Size(81, 19);
            this.chk_rShield.TabIndex = 19;
            this.chk_rShield.Text = "Red Shield";
            this.chk_rShield.UseVisualStyleBackColor = true;
            // 
            // chk_rSword
            // 
            this.chk_rSword.AutoSize = true;
            this.chk_rSword.Location = new System.Drawing.Point(532, 79);
            this.chk_rSword.Name = "chk_rSword";
            this.chk_rSword.Size = new System.Drawing.Size(82, 19);
            this.chk_rSword.TabIndex = 18;
            this.chk_rSword.Text = "Red Sword";
            this.chk_rSword.UseVisualStyleBackColor = true;
            // 
            // chk_bHeart
            // 
            this.chk_bHeart.AutoSize = true;
            this.chk_bHeart.Location = new System.Drawing.Point(416, 153);
            this.chk_bHeart.Name = "chk_bHeart";
            this.chk_bHeart.Size = new System.Drawing.Size(81, 19);
            this.chk_bHeart.TabIndex = 17;
            this.chk_bHeart.Text = "Blue Heart";
            this.chk_bHeart.UseVisualStyleBackColor = true;
            // 
            // chk_bShield
            // 
            this.chk_bShield.AutoSize = true;
            this.chk_bShield.Location = new System.Drawing.Point(416, 115);
            this.chk_bShield.Name = "chk_bShield";
            this.chk_bShield.Size = new System.Drawing.Size(84, 19);
            this.chk_bShield.TabIndex = 16;
            this.chk_bShield.Text = "Blue Shield";
            this.chk_bShield.UseVisualStyleBackColor = true;
            // 
            // chk_bSword
            // 
            this.chk_bSword.AutoSize = true;
            this.chk_bSword.Location = new System.Drawing.Point(416, 79);
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
            this.box_swords.Location = new System.Drawing.Point(483, 6);
            this.box_swords.Name = "box_swords";
            this.box_swords.Size = new System.Drawing.Size(120, 23);
            this.box_swords.TabIndex = 7;
            // 
            // box_hearts
            // 
            this.box_hearts.Location = new System.Drawing.Point(483, 41);
            this.box_hearts.Name = "box_hearts";
            this.box_hearts.Size = new System.Drawing.Size(120, 23);
            this.box_hearts.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(412, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 15);
            this.label4.TabIndex = 4;
            this.label4.Text = "Swords";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(416, 49);
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
            this.tabPage3.Controls.Add(this.list_flags);
            this.tabPage3.Controls.Add(this.list_values);
            this.tabPage3.Location = new System.Drawing.Point(4, 24);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(768, 370);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "All Values";
            this.tabPage3.UseVisualStyleBackColor = true;
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
            // list_flags
            // 
            this.list_flags.FormattingEnabled = true;
            this.list_flags.ItemHeight = 15;
            this.list_flags.Location = new System.Drawing.Point(421, 14);
            this.list_flags.Name = "list_flags";
            this.list_flags.Size = new System.Drawing.Size(315, 334);
            this.list_flags.TabIndex = 1;
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
    }
}