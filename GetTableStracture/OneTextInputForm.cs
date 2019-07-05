using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GetTableStracture
{
    public partial class OneTextInputForm : Form
    {
        public OneTextInputForm(String formName)
        {
            InitializeComponent();
            this.Text = formName;
        }

        public String Result { get { return textBox1.Text; } }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode== Keys.Enter)
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}
