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
    public partial class GroupColumnForm : Form
    {
        public GroupColumnForm(DataTable table)
        {
            InitializeComponent();
            dataGridView1.DataSource = table;
        }
    }
}
