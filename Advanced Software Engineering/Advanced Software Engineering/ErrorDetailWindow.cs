﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Advanced_Software_Engineering {
    public partial class ErrorDetailWindow : Form {
        public ErrorDetailWindow() {
            InitializeComponent();
        }

        public ErrorDetailWindow(string errorText) {
            InitializeComponent();
            textBox1.Text = errorText;
        }
    }
}