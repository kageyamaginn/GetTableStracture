namespace GetTableStracture.Properties
{
    partial class LikeTableForm
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
            this.textEditLikeName = new DevExpress.XtraEditors.TextEdit();
            this.simpleButtonLike = new DevExpress.XtraEditors.SimpleButton();
            this.checkedListBoxControlResults = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.simpleButtonConfirm = new DevExpress.XtraEditors.SimpleButton();
            this.popupMenu1 = new DevExpress.XtraBars.PopupMenu(this.components);
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barEditItemTableNameLike = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemButtonEditTableINameLike = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.barEditItem1 = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.checkButtonSearchCondition = new DevExpress.XtraEditors.CheckButton();
            ((System.ComponentModel.ISupportInitialize)(this.textEditLikeName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkedListBoxControlResults)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEditTableINameLike)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // textEditLikeName
            // 
            this.textEditLikeName.Location = new System.Drawing.Point(12, 55);
            this.textEditLikeName.Name = "textEditLikeName";
            this.textEditLikeName.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textEditLikeName.Size = new System.Drawing.Size(467, 20);
            this.textEditLikeName.TabIndex = 0;
            this.textEditLikeName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textEditLikeName_KeyDown);
            // 
            // simpleButtonLike
            // 
            this.simpleButtonLike.Location = new System.Drawing.Point(486, 54);
            this.simpleButtonLike.Name = "simpleButtonLike";
            this.simpleButtonLike.Size = new System.Drawing.Size(75, 23);
            this.simpleButtonLike.TabIndex = 1;
            this.simpleButtonLike.Text = "Like";
            this.simpleButtonLike.Click += new System.EventHandler(this.simpleButtonLike_Click);
            // 
            // checkedListBoxControlResults
            // 
            this.checkedListBoxControlResults.Location = new System.Drawing.Point(16, 90);
            this.checkedListBoxControlResults.Name = "checkedListBoxControlResults";
            this.barManager1.SetPopupContextMenu(this.checkedListBoxControlResults, this.popupMenu1);
            this.checkedListBoxControlResults.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.checkedListBoxControlResults.Size = new System.Drawing.Size(548, 315);
            this.checkedListBoxControlResults.TabIndex = 2;
            // 
            // simpleButtonConfirm
            // 
            this.simpleButtonConfirm.Location = new System.Drawing.Point(16, 411);
            this.simpleButtonConfirm.Name = "simpleButtonConfirm";
            this.simpleButtonConfirm.Size = new System.Drawing.Size(75, 23);
            this.simpleButtonConfirm.TabIndex = 3;
            this.simpleButtonConfirm.Text = "Confirm";
            this.simpleButtonConfirm.Click += new System.EventHandler(this.simpleButtonConfirm_Click);
            // 
            // popupMenu1
            // 
            this.popupMenu1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem2),
            new DevExpress.XtraBars.LinkPersistInfo(this.barEditItemTableNameLike)});
            this.popupMenu1.Manager = this.barManager1;
            this.popupMenu1.Name = "popupMenu1";
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Selecte";
            this.barButtonItem1.Id = 0;
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "UnSelect";
            this.barButtonItem2.Id = 1;
            this.barButtonItem2.Name = "barButtonItem2";
            this.barButtonItem2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem2_ItemClick);
            // 
            // barEditItemTableNameLike
            // 
            this.barEditItemTableNameLike.Caption = "Table Name Like";
            this.barEditItemTableNameLike.Edit = this.repositoryItemButtonEditTableINameLike;
            this.barEditItemTableNameLike.Id = 4;
            this.barEditItemTableNameLike.Name = "barEditItemTableNameLike";
            this.barEditItemTableNameLike.Width = 169;
            // 
            // repositoryItemButtonEditTableINameLike
            // 
            this.repositoryItemButtonEditTableINameLike.AutoHeight = false;
            this.repositoryItemButtonEditTableINameLike.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryItemButtonEditTableINameLike.Name = "repositoryItemButtonEditTableINameLike";
            this.repositoryItemButtonEditTableINameLike.ButtonPressed += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.repositoryItemButtonEditTableINameLike_ButtonPressed);
            // 
            // barManager1
            // 
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barButtonItem1,
            this.barButtonItem2,
            this.barButtonItem3,
            this.barEditItem1,
            this.barEditItemTableNameLike});
            this.barManager1.MaxItemId = 5;
            this.barManager1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit1,
            this.repositoryItemButtonEditTableINameLike});
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(576, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 454);
            this.barDockControlBottom.Size = new System.Drawing.Size(576, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 454);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(576, 0);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 454);
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "barButtonItem3";
            this.barButtonItem3.Id = 2;
            this.barButtonItem3.Name = "barButtonItem3";
            // 
            // barEditItem1
            // 
            this.barEditItem1.Caption = "barEditItem1";
            this.barEditItem1.Edit = this.repositoryItemTextEdit1;
            this.barEditItem1.Id = 3;
            this.barEditItem1.Name = "barEditItem1";
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // checkButtonSearchCondition
            // 
            this.checkButtonSearchCondition.Location = new System.Drawing.Point(12, 12);
            this.checkButtonSearchCondition.Name = "checkButtonSearchCondition";
            this.checkButtonSearchCondition.Size = new System.Drawing.Size(167, 37);
            this.checkButtonSearchCondition.TabIndex = 8;
            this.checkButtonSearchCondition.Text = "Table";
            this.checkButtonSearchCondition.CheckedChanged += new System.EventHandler(this.checkButtonSearchCondition_CheckedChanged);
            // 
            // LikeTableForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 454);
            this.Controls.Add(this.checkButtonSearchCondition);
            this.Controls.Add(this.simpleButtonConfirm);
            this.Controls.Add(this.checkedListBoxControlResults);
            this.Controls.Add(this.simpleButtonLike);
            this.Controls.Add(this.textEditLikeName);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "LikeTableForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LikeTableForm";
            ((System.ComponentModel.ISupportInitialize)(this.textEditLikeName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkedListBoxControlResults)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEditTableINameLike)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit textEditLikeName;
        private DevExpress.XtraEditors.SimpleButton simpleButtonLike;
        private DevExpress.XtraEditors.CheckedListBoxControl checkedListBoxControlResults;
        private DevExpress.XtraEditors.SimpleButton simpleButtonConfirm;
        private DevExpress.XtraBars.PopupMenu popupMenu1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.CheckButton checkButtonSearchCondition;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.BarEditItem barEditItem1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraBars.BarEditItem barEditItemTableNameLike;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEditTableINameLike;
    }
}