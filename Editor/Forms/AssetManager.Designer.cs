namespace Editor.Forms
{
    partial class AssetManager
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.materialToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.existingItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.totalAssetsLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.filteredAssetsLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel2 = new System.Windows.Forms.Panel();
            this.musicTglBtn = new System.Windows.Forms.CheckBox();
            this.soundsTglBtn = new System.Windows.Forms.CheckBox();
            this.modelsTglBtn = new System.Windows.Forms.CheckBox();
            this.materialsTglBtn = new System.Windows.Forms.CheckBox();
            this.texturesTglBtn = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tagsTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.filterTextBox = new System.Windows.Forms.TextBox();
            this.assetPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(912, 33);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.toolStripSeparator1,
            this.refreshToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(50, 29);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newItemToolStripMenuItem,
            this.existingItemToolStripMenuItem});
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(154, 30);
            this.addToolStripMenuItem.Text = "Add";
            // 
            // newItemToolStripMenuItem
            // 
            this.newItemToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.materialToolStripMenuItem});
            this.newItemToolStripMenuItem.Name = "newItemToolStripMenuItem";
            this.newItemToolStripMenuItem.Size = new System.Drawing.Size(204, 30);
            this.newItemToolStripMenuItem.Text = "New Asset";
            // 
            // materialToolStripMenuItem
            // 
            this.materialToolStripMenuItem.Name = "materialToolStripMenuItem";
            this.materialToolStripMenuItem.Size = new System.Drawing.Size(159, 30);
            this.materialToolStripMenuItem.Text = "Material";
            this.materialToolStripMenuItem.Click += new System.EventHandler(this.OnNewMaterialBtnClick);
            // 
            // existingItemToolStripMenuItem
            // 
            this.existingItemToolStripMenuItem.Name = "existingItemToolStripMenuItem";
            this.existingItemToolStripMenuItem.Size = new System.Drawing.Size(204, 30);
            this.existingItemToolStripMenuItem.Text = "Existing Asset";
            this.existingItemToolStripMenuItem.Click += new System.EventHandler(this.OnExistingAssetBtnClick);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(151, 6);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(154, 30);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.OnRefreshBtnClick);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(154, 30);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.OnCloseBtnClick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.totalAssetsLabel,
            this.toolStripStatusLabel3,
            this.filteredAssetsLabel});
            this.statusStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.statusStrip1.Location = new System.Drawing.Point(0, 552);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(2, 0, 14, 0);
            this.statusStrip1.Size = new System.Drawing.Size(912, 30);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(109, 25);
            this.toolStripStatusLabel1.Text = "Total Assets:";
            // 
            // totalAssetsLabel
            // 
            this.totalAssetsLabel.Name = "totalAssetsLabel";
            this.totalAssetsLabel.Size = new System.Drawing.Size(22, 25);
            this.totalAssetsLabel.Text = "0";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(130, 25);
            this.toolStripStatusLabel3.Text = "Filtered Assets:";
            // 
            // filteredAssetsLabel
            // 
            this.filteredAssetsLabel.Name = "filteredAssetsLabel";
            this.filteredAssetsLabel.Size = new System.Drawing.Size(22, 25);
            this.filteredAssetsLabel.Text = "0";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 33);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel2);
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Panel2.Controls.Add(this.assetPanel);
            this.splitContainer1.Size = new System.Drawing.Size(912, 519);
            this.splitContainer1.SplitterDistance = 150;
            this.splitContainer1.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.musicTglBtn);
            this.panel2.Controls.Add(this.soundsTglBtn);
            this.panel2.Controls.Add(this.modelsTglBtn);
            this.panel2.Controls.Add(this.materialsTglBtn);
            this.panel2.Controls.Add(this.texturesTglBtn);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 190);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(150, 329);
            this.panel2.TabIndex = 1;
            // 
            // musicTglBtn
            // 
            this.musicTglBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.musicTglBtn.Appearance = System.Windows.Forms.Appearance.Button;
            this.musicTglBtn.Checked = true;
            this.musicTglBtn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.musicTglBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.musicTglBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.musicTglBtn.Location = new System.Drawing.Point(3, 222);
            this.musicTglBtn.Name = "musicTglBtn";
            this.musicTglBtn.Size = new System.Drawing.Size(140, 48);
            this.musicTglBtn.TabIndex = 4;
            this.musicTglBtn.Text = "Music";
            this.musicTglBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.musicTglBtn.UseVisualStyleBackColor = true;
            this.musicTglBtn.CheckedChanged += new System.EventHandler(this.UpdateList);
            // 
            // soundsTglBtn
            // 
            this.soundsTglBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.soundsTglBtn.Appearance = System.Windows.Forms.Appearance.Button;
            this.soundsTglBtn.Checked = true;
            this.soundsTglBtn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.soundsTglBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.soundsTglBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.soundsTglBtn.Location = new System.Drawing.Point(3, 168);
            this.soundsTglBtn.Name = "soundsTglBtn";
            this.soundsTglBtn.Size = new System.Drawing.Size(140, 48);
            this.soundsTglBtn.TabIndex = 3;
            this.soundsTglBtn.Text = "Sounds";
            this.soundsTglBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.soundsTglBtn.UseVisualStyleBackColor = true;
            this.soundsTglBtn.CheckedChanged += new System.EventHandler(this.UpdateList);
            // 
            // modelsTglBtn
            // 
            this.modelsTglBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.modelsTglBtn.Appearance = System.Windows.Forms.Appearance.Button;
            this.modelsTglBtn.Checked = true;
            this.modelsTglBtn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.modelsTglBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modelsTglBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.modelsTglBtn.Location = new System.Drawing.Point(3, 114);
            this.modelsTglBtn.Name = "modelsTglBtn";
            this.modelsTglBtn.Size = new System.Drawing.Size(140, 48);
            this.modelsTglBtn.TabIndex = 2;
            this.modelsTglBtn.Text = "Models";
            this.modelsTglBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.modelsTglBtn.UseVisualStyleBackColor = true;
            this.modelsTglBtn.CheckedChanged += new System.EventHandler(this.UpdateList);
            // 
            // materialsTglBtn
            // 
            this.materialsTglBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.materialsTglBtn.Appearance = System.Windows.Forms.Appearance.Button;
            this.materialsTglBtn.Checked = true;
            this.materialsTglBtn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.materialsTglBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.materialsTglBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.materialsTglBtn.Location = new System.Drawing.Point(3, 60);
            this.materialsTglBtn.Name = "materialsTglBtn";
            this.materialsTglBtn.Size = new System.Drawing.Size(140, 48);
            this.materialsTglBtn.TabIndex = 1;
            this.materialsTglBtn.Text = "Materials";
            this.materialsTglBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.materialsTglBtn.UseVisualStyleBackColor = true;
            this.materialsTglBtn.CheckedChanged += new System.EventHandler(this.UpdateList);
            // 
            // texturesTglBtn
            // 
            this.texturesTglBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.texturesTglBtn.Appearance = System.Windows.Forms.Appearance.Button;
            this.texturesTglBtn.Checked = true;
            this.texturesTglBtn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.texturesTglBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.texturesTglBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.texturesTglBtn.Location = new System.Drawing.Point(3, 6);
            this.texturesTglBtn.Name = "texturesTglBtn";
            this.texturesTglBtn.Size = new System.Drawing.Size(140, 48);
            this.texturesTglBtn.TabIndex = 0;
            this.texturesTglBtn.Text = "Textures";
            this.texturesTglBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.texturesTglBtn.UseVisualStyleBackColor = true;
            this.texturesTglBtn.CheckedChanged += new System.EventHandler(this.UpdateList);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.tagsTextBox);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.filterTextBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(150, 190);
            this.panel1.TabIndex = 0;
            // 
            // tagsTextBox
            // 
            this.tagsTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tagsTextBox.Location = new System.Drawing.Point(57, 46);
            this.tagsTextBox.Multiline = true;
            this.tagsTextBox.Name = "tagsTextBox";
            this.tagsTextBox.Size = new System.Drawing.Size(85, 136);
            this.tagsTextBox.TabIndex = 3;
            this.tagsTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnTextboxEnterPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tags";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 40);
            this.label1.TabIndex = 1;
            this.label1.Text = "Filter";
            // 
            // filterTextBox
            // 
            this.filterTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filterTextBox.Location = new System.Drawing.Point(57, 6);
            this.filterTextBox.Name = "filterTextBox";
            this.filterTextBox.Size = new System.Drawing.Size(85, 26);
            this.filterTextBox.TabIndex = 0;
            this.filterTextBox.WordWrap = false;
            this.filterTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnTextboxEnterPress);
            // 
            // assetPanel
            // 
            this.assetPanel.AutoScroll = true;
            this.assetPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.assetPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.assetPanel.Location = new System.Drawing.Point(0, 0);
            this.assetPanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.assetPanel.Name = "assetPanel";
            this.assetPanel.Size = new System.Drawing.Size(758, 519);
            this.assetPanel.TabIndex = 0;
            // 
            // AssetManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(912, 582);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "AssetManager";
            this.Text = "AssetManager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnClosing);
            this.Load += new System.EventHandler(this.OnLoad);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox modelsTglBtn;
        private System.Windows.Forms.CheckBox materialsTglBtn;
        private System.Windows.Forms.CheckBox texturesTglBtn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox filterTextBox;
        private System.Windows.Forms.ToolStripStatusLabel totalAssetsLabel;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel filteredAssetsLabel;
        private System.Windows.Forms.CheckBox musicTglBtn;
        private System.Windows.Forms.CheckBox soundsTglBtn;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newItemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem existingItemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem materialToolStripMenuItem;
        private System.Windows.Forms.TextBox tagsTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.FlowLayoutPanel assetPanel;
    }
}