namespace HS_Save_Editor.Controls
{
    partial class CItems
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
            this.box_item = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // box_item
            // 
            this.box_item.FormattingEnabled = true;
            this.box_item.ItemHeight = 15;
            this.box_item.Location = new System.Drawing.Point(26, 21);
            this.box_item.Name = "box_item";
            this.box_item.Size = new System.Drawing.Size(250, 319);
            this.box_item.TabIndex = 71;
            this.box_item.DoubleClick += new System.EventHandler(this.box_item_DoubleClick);
            // 
            // CItems
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.box_item);
            this.Name = "CItems";
            this.Size = new System.Drawing.Size(415, 370);
            this.ResumeLayout(false);

        }

        #endregion

        private ListBox box_item;
    }
}
