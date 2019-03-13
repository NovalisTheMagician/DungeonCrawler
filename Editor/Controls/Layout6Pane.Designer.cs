﻿namespace Editor.Controls
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
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer5 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.assetTabControl = new System.Windows.Forms.TabControl();
            this.materilasTabPage = new System.Windows.Forms.TabPage();
            this.modelsTabPage = new System.Windows.Forms.TabPage();
            this.entitiesTabPage = new System.Windows.Forms.TabPage();
            this.threeDView1 = new Editor.Controls.ThreeDView();
            this.twoDView2 = new Editor.Controls.TwoDView();
            this.twoDView1 = new Editor.Controls.TwoDView();
            this.twoDView3 = new Editor.Controls.TwoDView();
            this.textureView = new Editor.Controls.TextureView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
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
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.assetTabControl.SuspendLayout();
            this.materilasTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(872, 504);
            this.splitContainer1.SplitterDistance = 672;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.splitContainer4);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.splitContainer5);
            this.splitContainer3.Size = new System.Drawing.Size(672, 504);
            this.splitContainer3.SplitterDistance = 324;
            this.splitContainer3.SplitterWidth = 6;
            this.splitContainer3.TabIndex = 0;
            // 
            // splitContainer4
            // 
            this.splitContainer4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
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
            this.splitContainer4.Panel2.Controls.Add(this.label1);
            this.splitContainer4.Panel2.Controls.Add(this.twoDView2);
            this.splitContainer4.Size = new System.Drawing.Size(324, 504);
            this.splitContainer4.SplitterDistance = 236;
            this.splitContainer4.SplitterWidth = 6;
            this.splitContainer4.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // splitContainer5
            // 
            this.splitContainer5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer5.Location = new System.Drawing.Point(0, 0);
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
            this.splitContainer5.Size = new System.Drawing.Size(342, 504);
            this.splitContainer5.SplitterDistance = 236;
            this.splitContainer5.SplitterWidth = 6;
            this.splitContainer5.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.assetTabControl);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.BackColor = System.Drawing.Color.Fuchsia;
            this.splitContainer2.Size = new System.Drawing.Size(196, 504);
            this.splitContainer2.SplitterDistance = 242;
            this.splitContainer2.SplitterWidth = 6;
            this.splitContainer2.TabIndex = 0;
            // 
            // assetTabControl
            // 
            this.assetTabControl.Controls.Add(this.materilasTabPage);
            this.assetTabControl.Controls.Add(this.modelsTabPage);
            this.assetTabControl.Controls.Add(this.entitiesTabPage);
            this.assetTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.assetTabControl.Location = new System.Drawing.Point(0, 0);
            this.assetTabControl.Margin = new System.Windows.Forms.Padding(2);
            this.assetTabControl.Name = "assetTabControl";
            this.assetTabControl.SelectedIndex = 0;
            this.assetTabControl.Size = new System.Drawing.Size(192, 238);
            this.assetTabControl.TabIndex = 0;
            // 
            // materilasTabPage
            // 
            this.materilasTabPage.Controls.Add(this.textureView);
            this.materilasTabPage.Location = new System.Drawing.Point(4, 22);
            this.materilasTabPage.Margin = new System.Windows.Forms.Padding(2);
            this.materilasTabPage.Name = "materilasTabPage";
            this.materilasTabPage.Padding = new System.Windows.Forms.Padding(2);
            this.materilasTabPage.Size = new System.Drawing.Size(184, 212);
            this.materilasTabPage.TabIndex = 0;
            this.materilasTabPage.Text = "Materials";
            this.materilasTabPage.UseVisualStyleBackColor = true;
            // 
            // modelsTabPage
            // 
            this.modelsTabPage.Location = new System.Drawing.Point(4, 22);
            this.modelsTabPage.Margin = new System.Windows.Forms.Padding(2);
            this.modelsTabPage.Name = "modelsTabPage";
            this.modelsTabPage.Padding = new System.Windows.Forms.Padding(2);
            this.modelsTabPage.Size = new System.Drawing.Size(184, 212);
            this.modelsTabPage.TabIndex = 1;
            this.modelsTabPage.Text = "Models";
            this.modelsTabPage.UseVisualStyleBackColor = true;
            // 
            // entitiesTabPage
            // 
            this.entitiesTabPage.Location = new System.Drawing.Point(4, 22);
            this.entitiesTabPage.Margin = new System.Windows.Forms.Padding(2);
            this.entitiesTabPage.Name = "entitiesTabPage";
            this.entitiesTabPage.Size = new System.Drawing.Size(184, 212);
            this.entitiesTabPage.TabIndex = 2;
            this.entitiesTabPage.Text = "Entities";
            this.entitiesTabPage.UseVisualStyleBackColor = true;
            // 
            // threeDView1
            // 
            this.threeDView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.threeDView1.Location = new System.Drawing.Point(0, 0);
            this.threeDView1.Name = "threeDView1";
            this.threeDView1.Size = new System.Drawing.Size(320, 232);
            this.threeDView1.TabIndex = 0;
            this.threeDView1.Text = "threeDView1";
            // 
            // twoDView2
            // 
            this.twoDView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.twoDView2.Location = new System.Drawing.Point(0, 0);
            this.twoDView2.Name = "twoDView2";
            this.twoDView2.Orientation = Editor.Controls.Orientation.SIDE;
            this.twoDView2.Size = new System.Drawing.Size(320, 258);
            this.twoDView2.TabIndex = 0;
            this.twoDView2.Text = "twoDView2";
            // 
            // twoDView1
            // 
            this.twoDView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.twoDView1.Location = new System.Drawing.Point(0, 0);
            this.twoDView1.Name = "twoDView1";
            this.twoDView1.Orientation = Editor.Controls.Orientation.TOP;
            this.twoDView1.Size = new System.Drawing.Size(338, 232);
            this.twoDView1.TabIndex = 0;
            this.twoDView1.Text = "twoDView1";
            // 
            // twoDView3
            // 
            this.twoDView3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.twoDView3.Location = new System.Drawing.Point(0, 0);
            this.twoDView3.Name = "twoDView3";
            this.twoDView3.Orientation = Editor.Controls.Orientation.FRONT;
            this.twoDView3.Size = new System.Drawing.Size(338, 258);
            this.twoDView3.TabIndex = 0;
            this.twoDView3.Text = "twoDView3";
            // 
            // textureView
            // 
            this.textureView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textureView.Location = new System.Drawing.Point(2, 2);
            this.textureView.Margin = new System.Windows.Forms.Padding(1);
            this.textureView.Name = "textureView";
            this.textureView.Size = new System.Drawing.Size(180, 208);
            this.textureView.TabIndex = 0;
            this.textureView.TextureCache = null;
            // 
            // Layout6Pane
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "Layout6Pane";
            this.Size = new System.Drawing.Size(872, 504);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            this.splitContainer4.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            this.splitContainer5.Panel1.ResumeLayout(false);
            this.splitContainer5.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).EndInit();
            this.splitContainer5.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.assetTabControl.ResumeLayout(false);
            this.materilasTabPage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.SplitContainer splitContainer5;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private ThreeDView threeDView1;
        private TwoDView twoDView2;
        private TwoDView twoDView1;
        private TwoDView twoDView3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl assetTabControl;
        private System.Windows.Forms.TabPage materilasTabPage;
        private TextureView textureView;
        private System.Windows.Forms.TabPage modelsTabPage;
        private System.Windows.Forms.TabPage entitiesTabPage;
    }
}
