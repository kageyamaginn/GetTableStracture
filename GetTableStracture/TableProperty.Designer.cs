namespace GetTableStracture
{
    partial class TableProperty
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.xtraTabControlTableProperties = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPageKeys = new DevExpress.XtraTab.XtraTabPage();
            this.dataGridViewKeys = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControlTableProperties)).BeginInit();
            this.xtraTabControlTableProperties.SuspendLayout();
            this.xtraTabPageKeys.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewKeys)).BeginInit();
            this.SuspendLayout();
            // 
            // xtraTabControlTableProperties
            // 
            this.xtraTabControlTableProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControlTableProperties.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControlTableProperties.Name = "xtraTabControlTableProperties";
            this.xtraTabControlTableProperties.SelectedTabPage = this.xtraTabPageKeys;
            this.xtraTabControlTableProperties.Size = new System.Drawing.Size(821, 468);
            this.xtraTabControlTableProperties.TabIndex = 0;
            this.xtraTabControlTableProperties.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPageKeys});
            this.xtraTabControlTableProperties.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TableProperty_KeyDown);
            // 
            // xtraTabPageKeys
            // 
            this.xtraTabPageKeys.Controls.Add(this.dataGridViewKeys);
            this.xtraTabPageKeys.Name = "xtraTabPageKeys";
            this.xtraTabPageKeys.Size = new System.Drawing.Size(815, 440);
            this.xtraTabPageKeys.Text = "Keys";
            // 
            // dataGridViewKeys
            // 
            this.dataGridViewKeys.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewKeys.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewKeys.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewKeys.Name = "dataGridViewKeys";
            this.dataGridViewKeys.Size = new System.Drawing.Size(815, 440);
            this.dataGridViewKeys.TabIndex = 0;
            this.dataGridViewKeys.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TableProperty_KeyDown);
            // 
            // TableProperty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 468);
            this.Controls.Add(this.xtraTabControlTableProperties);
            this.Name = "TableProperty";
            this.Text = "TableProperty";
            this.Load += new System.EventHandler(this.TableProperty_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TableProperty_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControlTableProperties)).EndInit();
            this.xtraTabControlTableProperties.ResumeLayout(false);
            this.xtraTabPageKeys.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewKeys)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl xtraTabControlTableProperties;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageKeys;
        private System.Windows.Forms.DataGridView dataGridViewKeys;
    }
}