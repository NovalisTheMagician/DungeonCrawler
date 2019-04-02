namespace Editor.Controls
{
    partial class Layout2Pane
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.threeDView1 = new Editor.Controls.ThreeDView();
            this.textureView = new Editor.Controls.TextureView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.Lime;
            this.splitContainer1.Panel1.Controls.Add(this.threeDView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.textureView);
            this.splitContainer1.Size = new System.Drawing.Size(1064, 702);
            this.splitContainer1.SplitterDistance = 649;
            this.splitContainer1.SplitterWidth = 6;
            this.splitContainer1.TabIndex = 0;
            // 
            // threeDView1
            // 
            this.threeDView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.threeDView1.Location = new System.Drawing.Point(0, 0);
            this.threeDView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.threeDView1.Name = "threeDView1";
            this.threeDView1.Size = new System.Drawing.Size(645, 698);
            this.threeDView1.TabIndex = 0;
            this.threeDView1.Text = "threeDView1";
            // 
            // textureView
            // 
            this.textureView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textureView.Location = new System.Drawing.Point(0, 0);
            this.textureView.Name = "textureView";
            this.textureView.Size = new System.Drawing.Size(405, 698);
            this.textureView.TabIndex = 0;
            this.textureView.TextureCache = null;
            // 
            // Layout2Pane
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Layout2Pane";
            this.Size = new System.Drawing.Size(1064, 702);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private Controls.ThreeDView threeDView1;
        private TextureView textureView;
    }
}
