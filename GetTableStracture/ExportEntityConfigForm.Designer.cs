namespace GetTableStracture
{
    partial class ExportEntityConfigForm
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
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.txtNamespace = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExport = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.cbUserField = new System.Windows.Forms.CheckBox();
            this.exportEntityConfigFormBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.exportEntityConfigFormBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.chbUserAnnotation = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.exportEntityConfigFormBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exportEntityConfigFormBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // txtNamespace
            // 
            this.txtNamespace.Location = new System.Drawing.Point(80, 6);
            this.txtNamespace.Name = "txtNamespace";
            this.txtNamespace.Size = new System.Drawing.Size(338, 20);
            this.txtNamespace.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "namespace";
            // 
            // btnExport
            // 
            this.btnExport.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnExport.Location = new System.Drawing.Point(80, 66);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 5;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.BtnExport_Click);
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(343, 66);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "Cancle";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // cbUserField
            // 
            this.cbUserField.AutoSize = true;
            this.cbUserField.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.exportEntityConfigFormBindingSource, "Fields", true));
            this.cbUserField.Location = new System.Drawing.Point(80, 32);
            this.cbUserField.Name = "cbUserField";
            this.cbUserField.Size = new System.Drawing.Size(70, 17);
            this.cbUserField.TabIndex = 7;
            this.cbUserField.Text = "Use Field";
            this.cbUserField.UseVisualStyleBackColor = true;
            // 
            // exportEntityConfigFormBindingSource
            // 
            this.exportEntityConfigFormBindingSource.DataSource = typeof(GetTableStracture.ExportEntityConfigForm);
            // 
            // exportEntityConfigFormBindingSource1
            // 
            this.exportEntityConfigFormBindingSource1.DataSource = typeof(GetTableStracture.ExportEntityConfigForm);
            // 
            // chbUserAnnotation
            // 
            this.chbUserAnnotation.AutoSize = true;
            this.chbUserAnnotation.Location = new System.Drawing.Point(165, 32);
            this.chbUserAnnotation.Name = "chbUserAnnotation";
            this.chbUserAnnotation.Size = new System.Drawing.Size(99, 17);
            this.chbUserAnnotation.TabIndex = 8;
            this.chbUserAnnotation.Text = "Use Annotation";
            this.chbUserAnnotation.UseVisualStyleBackColor = true;
            // 
            // ExportEntityConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 107);
            this.Controls.Add(this.chbUserAnnotation);
            this.Controls.Add(this.cbUserField);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNamespace);
            this.Name = "ExportEntityConfigForm";
            this.Text = "ExportEntityConfigForm";
            ((System.ComponentModel.ISupportInitialize)(this.exportEntityConfigFormBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exportEntityConfigFormBindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TextBox txtNamespace;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox cbUserField;
        private System.Windows.Forms.BindingSource exportEntityConfigFormBindingSource;
        private System.Windows.Forms.BindingSource exportEntityConfigFormBindingSource1;
        private System.Windows.Forms.CheckBox chbUserAnnotation;
    }
}