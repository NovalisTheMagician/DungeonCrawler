namespace Editor
{
    partial class SettingsForm
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.generalTabPage = new System.Windows.Forms.TabPage();
            this.controlsTabPage = new System.Windows.Forms.TabPage();
            this.graphicsTabPage = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.generalTabPage);
            this.tabControl1.Controls.Add(this.graphicsTabPage);
            this.tabControl1.Controls.Add(this.controlsTabPage);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(800, 450);
            this.tabControl1.TabIndex = 0;
            // 
            // generalTabPage
            // 
            this.generalTabPage.Location = new System.Drawing.Point(4, 29);
            this.generalTabPage.Name = "generalTabPage";
            this.generalTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.generalTabPage.Size = new System.Drawing.Size(792, 417);
            this.generalTabPage.TabIndex = 0;
            this.generalTabPage.Text = "General";
            this.generalTabPage.UseVisualStyleBackColor = true;
            // 
            // controlsTabPage
            // 
            this.controlsTabPage.Location = new System.Drawing.Point(4, 29);
            this.controlsTabPage.Name = "controlsTabPage";
            this.controlsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.controlsTabPage.Size = new System.Drawing.Size(792, 417);
            this.controlsTabPage.TabIndex = 1;
            this.controlsTabPage.Text = "Keybinds";
            this.controlsTabPage.UseVisualStyleBackColor = true;
            // 
            // graphicsTabPage
            // 
            this.graphicsTabPage.Location = new System.Drawing.Point(4, 29);
            this.graphicsTabPage.Name = "graphicsTabPage";
            this.graphicsTabPage.Size = new System.Drawing.Size(792, 417);
            this.graphicsTabPage.TabIndex = 2;
            this.graphicsTabPage.Text = "Graphics";
            this.graphicsTabPage.UseVisualStyleBackColor = true;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Name = "SettingsForm";
            this.Text = "Settings";
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage generalTabPage;
        private System.Windows.Forms.TabPage graphicsTabPage;
        private System.Windows.Forms.TabPage controlsTabPage;
    }
}