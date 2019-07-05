using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

namespace GetTableStracture
{
    public partial class Report : DevExpress.XtraReports.UI.XtraReport
    {
        public Report(DataSet ds)
        {
            InitializeComponent();
            xrTableCell1.Text = "TABLE NAME";
            xrTableCell2.Text = "COLUMN NAME";
            xrTableCell3.Text = "DATA LENGTH";
            xrTableCell4.Text = "NULL ABLE";

            xrTableT.BorderColor = Color.Black;
            xrTableT.BorderWidth = 1;
            xrTableT.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Dash;
            xrTableT.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            foreach (DataRow row in ds.Tables["columns"].Rows)
            {
                XRTableRow newRow = xrTableT.InsertRowBelow(xrTableT.Rows[xrTableT.Rows.Count - 1]);
                newRow.BackColor = Color.White;
                //if (xrTableT.Rows.Count > 1) newRow.Parent = xrTableT.Rows[xrTableT.Rows.Count - 2];
                newRow.Cells[0].Text = row["TABLE_NAME"] as String;
                newRow.Cells[1].Text = row["COLUMN_NAME"] as String;
                newRow.Cells[2].Text = row["DATA_LENGTH"] as String;
                newRow.Cells[3].Text = row["NULLABLE"] as String;
            }


        }

    }
}
