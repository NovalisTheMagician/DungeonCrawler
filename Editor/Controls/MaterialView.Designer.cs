namespace Editor.Controls
{
    partial class MaterialView
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
            this.materialFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // materialFlowPanel
            // 
            this.materialFlowPanel.AutoScroll = true;
            this.materialFlowPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialFlowPanel.Location = new System.Drawing.Point(0, 0);
            this.materialFlowPanel.Name = "materialFlowPanel";
            this.materialFlowPanel.Size = new System.Drawing.Size(489, 402);
            this.materialFlowPanel.TabIndex = 0;
            // 
            // MaterialView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.materialFlowPanel);
            this.Name = "MaterialView";
            this.Size = new System.Drawing.Size(489, 402);
            this.VisibleChanged += new System.EventHandler(this.OnVisibleChanged);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel materialFlowPanel;
    }
}
