namespace Editor.Forms
{
    partial class TextureEdit
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.tagList = new System.Windows.Forms.CheckedListBox();
            this.okBtn = new System.Windows.Forms.Button();
            this.imageContainer = new System.Windows.Forms.Panel();
            this.imagePanel = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.imageContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tagList);
            this.panel1.Controls.Add(this.okBtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(134, 528);
            this.panel1.TabIndex = 0;
            // 
            // tagList
            // 
            this.tagList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tagList.CheckOnClick = true;
            this.tagList.FormattingEnabled = true;
            this.tagList.Items.AddRange(new object[] {
            "Test",
            "Blah",
            "Grrrr"});
            this.tagList.Location = new System.Drawing.Point(12, 46);
            this.tagList.Name = "tagList";
            this.tagList.Size = new System.Drawing.Size(109, 466);
            this.tagList.TabIndex = 2;
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(12, 12);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(109, 28);
            this.okBtn.TabIndex = 0;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.OnOKBtnClick);
            // 
            // imageContainer
            // 
            this.imageContainer.AutoScroll = true;
            this.imageContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageContainer.Controls.Add(this.imagePanel);
            this.imageContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageContainer.Location = new System.Drawing.Point(134, 0);
            this.imageContainer.Name = "imageContainer";
            this.imageContainer.Size = new System.Drawing.Size(459, 528);
            this.imageContainer.TabIndex = 1;
            // 
            // imagePanel
            // 
            this.imagePanel.Location = new System.Drawing.Point(0, 0);
            this.imagePanel.Name = "imagePanel";
            this.imagePanel.Size = new System.Drawing.Size(200, 100);
            this.imagePanel.TabIndex = 0;
            this.imagePanel.Paint += new System.Windows.Forms.PaintEventHandler(this.OnPaint);
            // 
            // TextureEdit
            // 
            this.AcceptButton = this.okBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 528);
            this.Controls.Add(this.imageContainer);
            this.Controls.Add(this.panel1);
            this.Name = "TextureEdit";
            this.Text = "TextureEdit";
            this.Load += new System.EventHandler(this.OnLoad);
            this.panel1.ResumeLayout(false);
            this.imageContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.CheckedListBox tagList;
        private System.Windows.Forms.Panel imageContainer;
        private System.Windows.Forms.Panel imagePanel;
    }
}