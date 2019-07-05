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
    public partial class TableProperty : Form
    {
        DataTable keys = null;

        public TableProperty(DataTable keys)
        {
            InitializeComponent();
            this.keys = keys;
        }

        private void TableProperty_Load(object sender, EventArgs e)
        {
            dataGridViewKeys.DataSource = keys;
            dataGridViewKeys.AutoResizeColumns();
        }

        private void TableProperty_KeyDown(object sender, KeyEventArgs e)
        {
            this.Close();
        }
    }
}
