namespace HS_Save_Editor
{
    partial class CEquipment
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.chk_Equipment = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // chk_Equipment
            // 
            this.chk_Equipment.FormattingEnabled = true;
            this.chk_Equipment.Location = new System.Drawing.Point(10, 22);
            this.chk_Equipment.Name = "chk_Equipment";
            this.chk_Equipment.Size = new System.Drawing.Size(282, 328);
            this.chk_Equipment.TabIndex = 73;
            this.chk_Equipment.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chk_Equipment_ItemCheck);
            // 
            // CEquipment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chk_Equipment);
            this.Name = "CEquipment";
            this.Size = new System.Drawing.Size(415, 370);
            this.ResumeLayout(false);

        }

        #endregion

        private CheckedListBox chk_Equipment;
    }
}
