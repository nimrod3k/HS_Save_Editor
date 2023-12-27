namespace HS_Save_Editor
{
    partial class CStory
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
            this.box_story = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // box_story
            // 
            this.box_story.FormattingEnabled = true;
            this.box_story.ItemHeight = 15;
            this.box_story.Location = new System.Drawing.Point(12, 12);
            this.box_story.Name = "box_story";
            this.box_story.Size = new System.Drawing.Size(323, 334);
            this.box_story.TabIndex = 72;
            this.box_story.DoubleClick += new System.EventHandler(this.box_story_DoubleClick);
            // 
            // Story
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.box_story);
            this.Name = "Story";
            this.Size = new System.Drawing.Size(415, 370);
            this.ResumeLayout(false);

        }

        #endregion

        private ListBox box_story;
    }
}
