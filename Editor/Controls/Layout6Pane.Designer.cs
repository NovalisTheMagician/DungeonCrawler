namespace Editor.Controls
{
    partial class Layout6Pane
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
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.threeDView1 = new Editor.Controls.ThreeDView();
            this.twoDView2 = new Editor.Controls.TwoDView();
            this.splitContainer5 = new System.Windows.Forms.SplitContainer();
            this.twoDView1 = new Editor.Controls.TwoDView();
            this.twoDView3 = new Editor.Controls.TwoDView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).BeginInit();
            this.splitContainer5.Panel1.SuspendLayout();
            this.splitContainer5.Panel2.SuspendLayout();
            this.splitContainer5.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer3);
            this.splitContainer1.Size = new System.Drawing.Size(1308, 775);
            this.splitContainer1.SplitterDistance = 1066;
            this.splitContainer1.SplitterWidth = 6;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.splitContainer4);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.splitContainer5);
            this.splitContainer3.Size = new System.Drawing.Size(1066, 775);
            this.splitContainer3.SplitterDistance = 512;
            this.splitContainer3.SplitterWidth = 9;
            this.splitContainer3.TabIndex = 0;
            // 
            // splitContainer4
            // 
            this.splitContainer4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.splitContainer4.Name = "splitContainer4";
            this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.BackColor = System.Drawing.Color.Lime;
            this.splitContainer4.Panel1.Controls.Add(this.threeDView1);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.splitContainer4.Panel2.Controls.Add(this.twoDView2);
            this.splitContainer4.Size = new System.Drawing.Size(512, 775);
            this.splitContainer4.SplitterDistance = 347;
            this.splitContainer4.SplitterWidth = 9;
            this.splitContainer4.TabIndex = 0;
            // 
            // threeDView1
            // 
            this.threeDView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.threeDView1.Location = new System.Drawing.Point(0, 0);
            this.threeDView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.threeDView1.Name = "threeDView1";
            this.threeDView1.Size = new System.Drawing.Size(508, 343);
            this.threeDView1.TabIndex = 0;
            this.threeDView1.Text = "threeDView1";
            // 
            // twoDView2
            // 
            this.twoDView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.twoDView2.GridSize = 64;
            this.twoDView2.Location = new System.Drawing.Point(0, 0);
            this.twoDView2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.twoDView2.Name = "twoDView2";
            this.twoDView2.Orientation = Editor.Controls.Orientation.SIDE;
            this.twoDView2.ScaleFactor = 1F;
            this.twoDView2.Size = new System.Drawing.Size(508, 415);
            this.twoDView2.TabIndex = 0;
            this.twoDView2.Text = "twoDView2";
            this.twoDView2.Zoom = 100;
            // 
            // splitContainer5
            // 
            this.splitContainer5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer5.Location = new System.Drawing.Point(0, 0);
            this.splitContainer5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.splitContainer5.Name = "splitContainer5";
            this.splitContainer5.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer5.Panel1
            // 
            this.splitContainer5.Panel1.BackColor = System.Drawing.Color.Yellow;
            this.splitContainer5.Panel1.Controls.Add(this.twoDView1);
            // 
            // splitContainer5.Panel2
            // 
            this.splitContainer5.Panel2.BackColor = System.Drawing.Color.Aqua;
            this.splitContainer5.Panel2.Controls.Add(this.twoDView3);
            this.splitContainer5.Size = new System.Drawing.Size(545, 775);
            this.splitContainer5.SplitterDistance = 349;
            this.splitContainer5.SplitterWidth = 9;
            this.splitContainer5.TabIndex = 0;
            // 
            // twoDView1
            // 
            this.twoDView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.twoDView1.GridSize = 64;
            this.twoDView1.Location = new System.Drawing.Point(0, 0);
            this.twoDView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.twoDView1.Name = "twoDView1";
            this.twoDView1.Orientation = Editor.Controls.Orientation.TOP;
            this.twoDView1.ScaleFactor = 1F;
            this.twoDView1.Size = new System.Drawing.Size(541, 345);
            this.twoDView1.TabIndex = 0;
            this.twoDView1.Text = "twoDView1";
            this.twoDView1.Zoom = 100;
            // 
            // twoDView3
            // 
            this.twoDView3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.twoDView3.GridSize = 64;
            this.twoDView3.Location = new System.Drawing.Point(0, 0);
            this.twoDView3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.twoDView3.Name = "twoDView3";
            this.twoDView3.Orientation = Editor.Controls.Orientation.FRONT;
            this.twoDView3.ScaleFactor = 1F;
            this.twoDView3.Size = new System.Drawing.Size(541, 413);
            this.twoDView3.TabIndex = 0;
            this.twoDView3.Text = "twoDView3";
            this.twoDView3.Zoom = 100;
            // 
            // Layout6Pane
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Layout6Pane";
            this.Size = new System.Drawing.Size(1308, 775);
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            this.splitContainer5.Panel1.ResumeLayout(false);
            this.splitContainer5.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).EndInit();
            this.splitContainer5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.SplitContainer splitContainer5;
        private ThreeDView threeDView1;
        private TwoDView twoDView2;
        private TwoDView twoDView1;
        private TwoDView twoDView3;
    }
}
