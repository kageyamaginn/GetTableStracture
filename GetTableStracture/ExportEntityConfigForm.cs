using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GetTableStracture
{
    public partial class ExportEntityConfigForm : Form
    {
        public ExportEntityConfigForm()
        {
            InitializeComponent();
        }

        public String Ns { get; set; }
        public bool Fields { get; set; }
        public bool UseAnnotation { get; set; }

        private void BtnExport_Click(object sender, EventArgs e)
        {
            Ns = txtNamespace.Text;
            Fields = cbUserField.Checked;
            UseAnnotation = chbUserAnnotation.Checked;
        }
    }
}
