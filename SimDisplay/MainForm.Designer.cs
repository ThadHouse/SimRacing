namespace SimDisplay
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.threadTimer = new System.Windows.Forms.Timer(this.components);
            this.simSelectorBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // threadTimer
            // 
            this.threadTimer.Interval = 20;
            this.threadTimer.Tick += new System.EventHandler(this.threadTimer_Tick);
            // 
            // simSelectorBox
            // 
            this.simSelectorBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.simSelectorBox.FormattingEnabled = true;
            this.simSelectorBox.Items.AddRange(new object[] {
            "SimBin",
            "AssettoCorsa"});
            this.simSelectorBox.Location = new System.Drawing.Point(40, 39);
            this.simSelectorBox.Name = "simSelectorBox";
            this.simSelectorBox.Size = new System.Drawing.Size(121, 21);
            this.simSelectorBox.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.simSelectorBox);
            this.Name = "MainForm";
            this.Text = "Main Form";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer threadTimer;
        private System.Windows.Forms.ComboBox simSelectorBox;
    }
}

