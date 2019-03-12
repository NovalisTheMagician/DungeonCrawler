namespace Editor.Controls
{
    partial class TextureItem
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
            this.textureLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textureLabel
            // 
            this.textureLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textureLabel.AutoSize = true;
            this.textureLabel.BackColor = System.Drawing.SystemColors.Control;
            this.textureLabel.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textureLabel.Location = new System.Drawing.Point(70, 203);
            this.textureLabel.Name = "textureLabel";
            this.textureLabel.Size = new System.Drawing.Size(103, 28);
            this.textureLabel.TabIndex = 0;
            this.textureLabel.Text = "Texture";
            this.textureLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TextureItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.textureLabel);
            this.MaximumSize = new System.Drawing.Size(512, 512);
            this.MinimumSize = new System.Drawing.Size(64, 64);
            this.Name = "TextureItem";
            this.Size = new System.Drawing.Size(252, 252);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.OnPaint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label textureLabel;
    }
}
