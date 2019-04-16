using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Editor.Forms
{
    public partial class InputBox : Form
    {
        public string Caption
        {
            get { return this.Text; }
            set { this.Text = value; }
        }

        public string InputLabel
        {
            get { return inputLabel.Text; }
            set { inputLabel.Text = value; }
        }

        public string Input
        {
            get { return textBox.Text; }
        }

        public InputBox()
        {
            InitializeComponent();
        }

        private void OnOKBtnClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void OnCancelBtnClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
