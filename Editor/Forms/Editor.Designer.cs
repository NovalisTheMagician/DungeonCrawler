namespace Editor.Forms
{
    partial class EditorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditorForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.openBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.saveBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.quitBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buildToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buildAndRunToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textureManagerBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.modelManagerBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.materialManagerBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.entitiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.standardViewBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.texturingViewBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.layout6Pane1 = new Editor.Layout6Pane();
            this.gitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pullBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.viewChangesBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.commitBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.pushBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.setupBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.gitToolStripMenuItem,
            this.exportToolStripMenuItem,
            this.importToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1224, 33);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newBtn,
            this.openBtn,
            this.toolStripSeparator1,
            this.saveBtn,
            this.saveAsBtn,
            this.toolStripSeparator2,
            this.quitBtn});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(50, 29);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newBtn
            // 
            this.newBtn.Name = "newBtn";
            this.newBtn.Size = new System.Drawing.Size(252, 30);
            this.newBtn.Text = "New";
            this.newBtn.Click += new System.EventHandler(this.newBtnClick);
            // 
            // openBtn
            // 
            this.openBtn.Name = "openBtn";
            this.openBtn.Size = new System.Drawing.Size(252, 30);
            this.openBtn.Text = "Open";
            this.openBtn.Click += new System.EventHandler(this.openBtnClick);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(249, 6);
            // 
            // saveBtn
            // 
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(252, 30);
            this.saveBtn.Text = "Save";
            this.saveBtn.Click += new System.EventHandler(this.saveBtnClick);
            // 
            // saveAsBtn
            // 
            this.saveAsBtn.Name = "saveAsBtn";
            this.saveAsBtn.Size = new System.Drawing.Size(252, 30);
            this.saveAsBtn.Text = "Save As";
            this.saveAsBtn.Click += new System.EventHandler(this.saveAsBtnClick);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(249, 6);
            // 
            // quitBtn
            // 
            this.quitBtn.Name = "quitBtn";
            this.quitBtn.Size = new System.Drawing.Size(252, 30);
            this.quitBtn.Text = "Quit";
            this.quitBtn.Click += new System.EventHandler(this.quitBtnClick);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buildToolStripMenuItem,
            this.buildAndRunToolStripMenuItem});
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(75, 29);
            this.exportToolStripMenuItem.Text = "Export";
            // 
            // buildToolStripMenuItem
            // 
            this.buildToolStripMenuItem.Name = "buildToolStripMenuItem";
            this.buildToolStripMenuItem.Size = new System.Drawing.Size(206, 30);
            this.buildToolStripMenuItem.Text = "Build";
            // 
            // buildAndRunToolStripMenuItem
            // 
            this.buildAndRunToolStripMenuItem.Name = "buildAndRunToolStripMenuItem";
            this.buildAndRunToolStripMenuItem.Size = new System.Drawing.Size(206, 30);
            this.buildAndRunToolStripMenuItem.Text = "Build and Run";
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.textureManagerBtn,
            this.modelManagerBtn,
            this.materialManagerBtn,
            this.entitiesToolStripMenuItem});
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(75, 29);
            this.importToolStripMenuItem.Text = "Assets";
            // 
            // textureManagerBtn
            // 
            this.textureManagerBtn.Name = "textureManagerBtn";
            this.textureManagerBtn.Size = new System.Drawing.Size(234, 30);
            this.textureManagerBtn.Text = "Texture Manager";
            this.textureManagerBtn.Click += new System.EventHandler(this.textureManagerBtnClick);
            // 
            // modelManagerBtn
            // 
            this.modelManagerBtn.Name = "modelManagerBtn";
            this.modelManagerBtn.Size = new System.Drawing.Size(234, 30);
            this.modelManagerBtn.Text = "Model Manager";
            this.modelManagerBtn.Click += new System.EventHandler(this.modelManagerBtnClick);
            // 
            // materialManagerBtn
            // 
            this.materialManagerBtn.Name = "materialManagerBtn";
            this.materialManagerBtn.Size = new System.Drawing.Size(234, 30);
            this.materialManagerBtn.Text = "Material Manager";
            this.materialManagerBtn.Click += new System.EventHandler(this.materialManagerBtnClick);
            // 
            // entitiesToolStripMenuItem
            // 
            this.entitiesToolStripMenuItem.Name = "entitiesToolStripMenuItem";
            this.entitiesToolStripMenuItem.Size = new System.Drawing.Size(234, 30);
            this.entitiesToolStripMenuItem.Text = "Entities";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(65, 29);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.standardViewBtn,
            this.texturingViewBtn});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(61, 29);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // standardViewBtn
            // 
            this.standardViewBtn.Name = "standardViewBtn";
            this.standardViewBtn.Size = new System.Drawing.Size(167, 30);
            this.standardViewBtn.Text = "Standard";
            this.standardViewBtn.Click += new System.EventHandler(this.standardViewBtnClick);
            // 
            // texturingViewBtn
            // 
            this.texturingViewBtn.Name = "texturingViewBtn";
            this.texturingViewBtn.Size = new System.Drawing.Size(167, 30);
            this.texturingViewBtn.Text = "Texturing";
            this.texturingViewBtn.Click += new System.EventHandler(this.texturingViewBtnClick);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsBtn,
            this.aboutBtn});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(61, 29);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // settingsBtn
            // 
            this.settingsBtn.Name = "settingsBtn";
            this.settingsBtn.Size = new System.Drawing.Size(252, 30);
            this.settingsBtn.Text = "Settings";
            this.settingsBtn.Click += new System.EventHandler(this.settingsBtnClick);
            // 
            // aboutBtn
            // 
            this.aboutBtn.Name = "aboutBtn";
            this.aboutBtn.Size = new System.Drawing.Size(252, 30);
            this.aboutBtn.Text = "About";
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripComboBox1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 33);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStrip1.Size = new System.Drawing.Size(1224, 33);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(28, 30);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(28, 30);
            this.toolStripButton2.Text = "toolStripButton2";
            // 
            // toolStripComboBox1
            // 
            this.toolStripComboBox1.DropDownWidth = 64;
            this.toolStripComboBox1.Items.AddRange(new object[] {
            "1",
            "2",
            "4",
            "8",
            "16",
            "32",
            "64",
            "128",
            "256",
            "512"});
            this.toolStripComboBox1.Name = "toolStripComboBox1";
            this.toolStripComboBox1.Size = new System.Drawing.Size(110, 33);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 776);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(2, 0, 21, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1224, 30);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(85, 25);
            this.toolStripStatusLabel1.Text = "Grid Size:";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(32, 25);
            this.toolStripStatusLabel2.Text = "64";
            // 
            // layout6Pane1
            // 
            this.layout6Pane1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layout6Pane1.Location = new System.Drawing.Point(0, 66);
            this.layout6Pane1.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.layout6Pane1.Name = "layout6Pane1";
            this.layout6Pane1.Size = new System.Drawing.Size(1224, 710);
            this.layout6Pane1.TabIndex = 4;
            // 
            // gitToolStripMenuItem
            // 
            this.gitToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pullBtn,
            this.viewChangesBtn,
            this.commitBtn,
            this.pushBtn,
            this.setupBtn});
            this.gitToolStripMenuItem.Name = "gitToolStripMenuItem";
            this.gitToolStripMenuItem.Size = new System.Drawing.Size(46, 29);
            this.gitToolStripMenuItem.Text = "Git";
            // 
            // pullBtn
            // 
            this.pullBtn.Name = "pullBtn";
            this.pullBtn.Size = new System.Drawing.Size(252, 30);
            this.pullBtn.Text = "Pull";
            this.pullBtn.Click += new System.EventHandler(this.pullBtnClick);
            // 
            // viewChangesBtn
            // 
            this.viewChangesBtn.Name = "viewChangesBtn";
            this.viewChangesBtn.Size = new System.Drawing.Size(252, 30);
            this.viewChangesBtn.Text = "View Changes";
            this.viewChangesBtn.Click += new System.EventHandler(this.viewChangesBtnClick);
            // 
            // commitBtn
            // 
            this.commitBtn.Name = "commitBtn";
            this.commitBtn.Size = new System.Drawing.Size(252, 30);
            this.commitBtn.Text = "Commit";
            this.commitBtn.Click += new System.EventHandler(this.commitBtnClick);
            // 
            // pushBtn
            // 
            this.pushBtn.Name = "pushBtn";
            this.pushBtn.Size = new System.Drawing.Size(252, 30);
            this.pushBtn.Text = "Push";
            this.pushBtn.Click += new System.EventHandler(this.pushBtnClick);
            // 
            // setupBtn
            // 
            this.setupBtn.Name = "setupBtn";
            this.setupBtn.Size = new System.Drawing.Size(252, 30);
            this.setupBtn.Text = "Setup";
            this.setupBtn.Click += new System.EventHandler(this.setupBtnClick);
            // 
            // EditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1224, 806);
            this.Controls.Add(this.layout6Pane1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "EditorForm";
            this.Text = "Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.editorClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newBtn;
        private System.Windows.Forms.ToolStripMenuItem openBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem saveBtn;
        private System.Windows.Forms.ToolStripMenuItem saveAsBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem quitBtn;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutBtn;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsBtn;
        private System.Windows.Forms.ToolStripMenuItem buildToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buildAndRunToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem textureManagerBtn;
        private System.Windows.Forms.ToolStripMenuItem entitiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem standardViewBtn;
        private System.Windows.Forms.ToolStripMenuItem texturingViewBtn;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox1;
        private Layout6Pane layout6Pane1;
        private System.Windows.Forms.ToolStripMenuItem modelManagerBtn;
        private System.Windows.Forms.ToolStripMenuItem materialManagerBtn;
        private System.Windows.Forms.ToolStripMenuItem gitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pullBtn;
        private System.Windows.Forms.ToolStripMenuItem viewChangesBtn;
        private System.Windows.Forms.ToolStripMenuItem commitBtn;
        private System.Windows.Forms.ToolStripMenuItem pushBtn;
        private System.Windows.Forms.ToolStripMenuItem setupBtn;
    }
}

