namespace Editor.Forms
{
    partial class MaterialEdit
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
            this.okBtn = new System.Windows.Forms.Button();
            this.tagList = new System.Windows.Forms.CheckedListBox();
            this.diffusePanel = new System.Windows.Forms.Panel();
            this.normalPanel = new System.Windows.Forms.Panel();
            this.specularPanel = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tagList);
            this.panel1.Controls.Add(this.okBtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(171, 282);
            this.panel1.TabIndex = 0;
            // 
            // okBtn
            // 
            this.okBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.okBtn.Location = new System.Drawing.Point(12, 12);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(144, 32);
            this.okBtn.TabIndex = 0;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.OnOKBtnClick);
            // 
            // tagList
            // 
            this.tagList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tagList.FormattingEnabled = true;
            this.tagList.Location = new System.Drawing.Point(12, 50);
            this.tagList.Name = "tagList";
            this.tagList.Size = new System.Drawing.Size(144, 214);
            this.tagList.TabIndex = 1;
            // 
            // diffusePanel
            // 
            this.diffusePanel.AllowDrop = true;
            this.diffusePanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.diffusePanel.Location = new System.Drawing.Point(177, 12);
            this.diffusePanel.Name = "diffusePanel";
            this.diffusePanel.Size = new System.Drawing.Size(256, 256);
            this.diffusePanel.TabIndex = 1;
            this.diffusePanel.DragDrop += new System.Windows.Forms.DragEventHandler(this.OnTextureDragDrop);
            this.diffusePanel.DragEnter += new System.Windows.Forms.DragEventHandler(this.OnTextureDragEnter);
            this.diffusePanel.Paint += new System.Windows.Forms.PaintEventHandler(this.OnMaterialPanelPaint);
            // 
            // normalPanel
            // 
            this.normalPanel.AllowDrop = true;
            this.normalPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.normalPanel.Location = new System.Drawing.Point(439, 12);
            this.normalPanel.Name = "normalPanel";
            this.normalPanel.Size = new System.Drawing.Size(256, 256);
            this.normalPanel.TabIndex = 2;
            this.normalPanel.DragDrop += new System.Windows.Forms.DragEventHandler(this.OnTextureDragDrop);
            this.normalPanel.DragEnter += new System.Windows.Forms.DragEventHandler(this.OnTextureDragEnter);
            this.normalPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.OnMaterialPanelPaint);
            // 
            // specularPanel
            // 
            this.specularPanel.AllowDrop = true;
            this.specularPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.specularPanel.Location = new System.Drawing.Point(701, 12);
            this.specularPanel.Name = "specularPanel";
            this.specularPanel.Size = new System.Drawing.Size(256, 256);
            this.specularPanel.TabIndex = 3;
            this.specularPanel.DragDrop += new System.Windows.Forms.DragEventHandler(this.OnTextureDragDrop);
            this.specularPanel.DragEnter += new System.Windows.Forms.DragEventHandler(this.OnTextureDragEnter);
            this.specularPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.OnMaterialPanelPaint);
            // 
            // MaterialEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(973, 282);
            this.Controls.Add(this.specularPanel);
            this.Controls.Add(this.normalPanel);
            this.Controls.Add(this.diffusePanel);
            this.Controls.Add(this.panel1);
            this.Name = "MaterialEdit";
            this.Text = "MaterialEdit";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckedListBox tagList;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.Panel diffusePanel;
        private System.Windows.Forms.Panel normalPanel;
        private System.Windows.Forms.Panel specularPanel;
    }
}