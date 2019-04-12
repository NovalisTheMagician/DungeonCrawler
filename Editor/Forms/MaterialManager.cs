﻿using Editor.Controls;
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
    public partial class MaterialManager : Form
    {
        public MaterialView MaterialView { get; set; }

        public MaterialManager()
        {
            InitializeComponent();
        }
    }
}
