namespace Editor.Controls
{
    partial class TextureView
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
            this.components = new System.ComponentModel.Container();
            this.textureFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.refreshBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.reloadBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textureFlowPanel
            // 
            this.textureFlowPanel.AutoScroll = true;
            this.textureFlowPanel.ContextMenuStrip = this.contextMenuStrip1;
            this.textureFlowPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textureFlowPanel.Location = new System.Drawing.Point(0, 0);
            this.textureFlowPanel.Name = "textureFlowPanel";
            this.textureFlowPanel.Size = new System.Drawing.Size(539, 442);
            this.textureFlowPanel.TabIndex = 0;
            this.textureFlowPanel.VisibleChanged += new System.EventHandler(this.OnVisibleChanged);
            // 
            // refreshBtn
            // 
            this.refreshBtn.Name = "refreshBtn";
            this.refreshBtn.Size = new System.Drawing.Size(240, 30);
            this.refreshBtn.Text = "Refresh";
            this.refreshBtn.Click += new System.EventHandler(this.RefreshBtnClick);
            // 
            // reloadBtn
            // 
            this.reloadBtn.Name = "reloadBtn";
            this.reloadBtn.Size = new System.Drawing.Size(240, 30);
            this.reloadBtn.Text = "Reload";
            this.reloadBtn.Click += new System.EventHandler(this.ReloadBtnClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshBtn,
            this.reloadBtn});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(241, 97);
            // 
            // TextureView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textureFlowPanel);
            this.Name = "TextureView";
            this.Size = new System.Drawing.Size(539, 442);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel textureFlowPanel;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem refreshBtn;
        private System.Windows.Forms.ToolStripMenuItem reloadBtn;
    }
}
