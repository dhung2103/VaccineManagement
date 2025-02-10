namespace VaccineManagement.UserViewControl
{
    partial class ChildrenPage
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
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.entityInstantFeedbackSource1 = new DevExpress.Data.Linq.EntityInstantFeedbackSource();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colChildId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFullName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDateOfBirth = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGender = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBloodType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colParentName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colParentPhone = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHealthNotes = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreatedBy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreatedByStaff = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVaccinationRecords = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreatedAt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUpdatedAt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar4 = new DevExpress.XtraBars.Bar();
            this.btnAdd = new DevExpress.XtraBars.BarButtonItem();
            this.btnEdit = new DevExpress.XtraBars.BarButtonItem();
            this.btnDelete = new DevExpress.XtraBars.BarButtonItem();
            this.btnView = new DevExpress.XtraBars.BarButtonItem();
            this.btnRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.btnInject = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.bar1 = new DevExpress.XtraBars.Bar();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl
            // 
            this.gridControl.DataSource = this.entityInstantFeedbackSource1;
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.gridControl.Location = new System.Drawing.Point(0, 40);
            this.gridControl.MainView = this.gridView;
            this.gridControl.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.gridControl.Name = "gridControl";
            this.gridControl.Size = new System.Drawing.Size(1333, 1022);
            this.gridControl.TabIndex = 2;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            // 
            // entityInstantFeedbackSource1
            // 
            this.entityInstantFeedbackSource1.DefaultSorting = "ChildId DESC";
            this.entityInstantFeedbackSource1.DesignTimeElementType = typeof(VaccineManagement.Model.Children);
            this.entityInstantFeedbackSource1.KeyExpression = "ChildId";
            // 
            // gridView
            // 
            this.gridView.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colChildId,
            this.colFullName,
            this.colDateOfBirth,
            this.colGender,
            this.colBloodType,
            this.colParentName,
            this.colParentPhone,
            this.colAddress,
            this.colHealthNotes,
            this.colCreatedBy,
            this.colCreatedByStaff,
            this.colVaccinationRecords,
            this.colCreatedAt,
            this.colUpdatedAt});
            this.gridView.DetailHeight = 619;
            this.gridView.GridControl = this.gridControl;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.Editable = false;
            this.gridView.OptionsBehavior.ReadOnly = true;
            this.gridView.OptionsView.ShowGroupPanel = false;
            // 
            // colChildId
            // 
            this.colChildId.FieldName = "ChildId";
            this.colChildId.MinWidth = 33;
            this.colChildId.Name = "colChildId";
            this.colChildId.Visible = true;
            this.colChildId.VisibleIndex = 0;
            this.colChildId.Width = 125;
            // 
            // colFullName
            // 
            this.colFullName.FieldName = "FullName";
            this.colFullName.MinWidth = 33;
            this.colFullName.Name = "colFullName";
            this.colFullName.Visible = true;
            this.colFullName.VisibleIndex = 1;
            this.colFullName.Width = 125;
            // 
            // colDateOfBirth
            // 
            this.colDateOfBirth.FieldName = "DateOfBirth";
            this.colDateOfBirth.MinWidth = 33;
            this.colDateOfBirth.Name = "colDateOfBirth";
            this.colDateOfBirth.Visible = true;
            this.colDateOfBirth.VisibleIndex = 2;
            this.colDateOfBirth.Width = 125;
            // 
            // colGender
            // 
            this.colGender.FieldName = "Gender";
            this.colGender.MinWidth = 33;
            this.colGender.Name = "colGender";
            this.colGender.Visible = true;
            this.colGender.VisibleIndex = 3;
            this.colGender.Width = 125;
            // 
            // colBloodType
            // 
            this.colBloodType.FieldName = "BloodType";
            this.colBloodType.MinWidth = 33;
            this.colBloodType.Name = "colBloodType";
            this.colBloodType.Visible = true;
            this.colBloodType.VisibleIndex = 4;
            this.colBloodType.Width = 125;
            // 
            // colParentName
            // 
            this.colParentName.FieldName = "ParentName";
            this.colParentName.MinWidth = 33;
            this.colParentName.Name = "colParentName";
            this.colParentName.Visible = true;
            this.colParentName.VisibleIndex = 5;
            this.colParentName.Width = 125;
            // 
            // colParentPhone
            // 
            this.colParentPhone.FieldName = "ParentPhone";
            this.colParentPhone.MinWidth = 33;
            this.colParentPhone.Name = "colParentPhone";
            this.colParentPhone.Visible = true;
            this.colParentPhone.VisibleIndex = 6;
            this.colParentPhone.Width = 125;
            // 
            // colAddress
            // 
            this.colAddress.FieldName = "Address";
            this.colAddress.MinWidth = 33;
            this.colAddress.Name = "colAddress";
            this.colAddress.Visible = true;
            this.colAddress.VisibleIndex = 7;
            this.colAddress.Width = 125;
            // 
            // colHealthNotes
            // 
            this.colHealthNotes.FieldName = "HealthNotes";
            this.colHealthNotes.MinWidth = 33;
            this.colHealthNotes.Name = "colHealthNotes";
            this.colHealthNotes.Visible = true;
            this.colHealthNotes.VisibleIndex = 8;
            this.colHealthNotes.Width = 125;
            // 
            // colCreatedBy
            // 
            this.colCreatedBy.FieldName = "CreatedBy";
            this.colCreatedBy.MinWidth = 33;
            this.colCreatedBy.Name = "colCreatedBy";
            this.colCreatedBy.Visible = true;
            this.colCreatedBy.VisibleIndex = 9;
            this.colCreatedBy.Width = 125;
            // 
            // colCreatedByStaff
            // 
            this.colCreatedByStaff.FieldName = "CreatedByStaff";
            this.colCreatedByStaff.MinWidth = 33;
            this.colCreatedByStaff.Name = "colCreatedByStaff";
            this.colCreatedByStaff.Visible = true;
            this.colCreatedByStaff.VisibleIndex = 10;
            this.colCreatedByStaff.Width = 125;
            // 
            // colVaccinationRecords
            // 
            this.colVaccinationRecords.FieldName = "VaccinationRecords";
            this.colVaccinationRecords.MinWidth = 33;
            this.colVaccinationRecords.Name = "colVaccinationRecords";
            this.colVaccinationRecords.Visible = true;
            this.colVaccinationRecords.VisibleIndex = 11;
            this.colVaccinationRecords.Width = 125;
            // 
            // colCreatedAt
            // 
            this.colCreatedAt.FieldName = "CreatedAt";
            this.colCreatedAt.MinWidth = 33;
            this.colCreatedAt.Name = "colCreatedAt";
            this.colCreatedAt.Visible = true;
            this.colCreatedAt.VisibleIndex = 12;
            this.colCreatedAt.Width = 125;
            // 
            // colUpdatedAt
            // 
            this.colUpdatedAt.FieldName = "UpdatedAt";
            this.colUpdatedAt.MinWidth = 33;
            this.colUpdatedAt.Name = "colUpdatedAt";
            this.colUpdatedAt.Visible = true;
            this.colUpdatedAt.VisibleIndex = 13;
            this.colUpdatedAt.Width = 125;
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar4});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnAdd,
            this.btnEdit,
            this.btnDelete,
            this.btnRefresh,
            this.btnView,
            this.btnInject});
            this.barManager1.MaxItemId = 8;
            // 
            // bar4
            // 
            this.bar4.BarName = "Custom 2";
            this.bar4.DockCol = 0;
            this.bar4.DockRow = 0;
            this.bar4.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar4.FloatLocation = new System.Drawing.Point(252, 100);
            this.bar4.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnAdd),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnEdit),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnDelete),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnView),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnRefresh),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnInject)});
            this.bar4.Text = "Custom 2";
            // 
            // btnAdd
            // 
            this.btnAdd.Caption = "Thêm";
            this.btnAdd.ContentHorizontalAlignment = DevExpress.XtraBars.BarItemContentAlignment.Center;
            this.btnAdd.Id = 0;
            this.btnAdd.ImageOptions.Image = global::VaccineManagement.Properties.Resources.addfile_16x16;
            this.btnAdd.ImageOptions.LargeImage = global::VaccineManagement.Properties.Resources.addfile_32x32;
            this.btnAdd.Name = "btnAdd";
            // 
            // btnEdit
            // 
            this.btnEdit.Caption = "Sửa";
            this.btnEdit.ContentHorizontalAlignment = DevExpress.XtraBars.BarItemContentAlignment.Center;
            this.btnEdit.Id = 1;
            this.btnEdit.ImageOptions.Image = global::VaccineManagement.Properties.Resources.edit_16x16;
            this.btnEdit.ImageOptions.LargeImage = global::VaccineManagement.Properties.Resources.edit_32x32;
            this.btnEdit.Name = "btnEdit";
            // 
            // btnDelete
            // 
            this.btnDelete.Caption = "Xóa";
            this.btnDelete.ContentHorizontalAlignment = DevExpress.XtraBars.BarItemContentAlignment.Center;
            this.btnDelete.Id = 2;
            this.btnDelete.ImageOptions.Image = global::VaccineManagement.Properties.Resources.removeitem_16x16;
            this.btnDelete.ImageOptions.LargeImage = global::VaccineManagement.Properties.Resources.removeitem_32x32;
            this.btnDelete.Name = "btnDelete";
            // 
            // btnView
            // 
            this.btnView.Caption = "Xem chi tiết";
            this.btnView.Id = 5;
            this.btnView.ImageOptions.Image = global::VaccineManagement.Properties.Resources.preview_16x16;
            this.btnView.ImageOptions.LargeImage = global::VaccineManagement.Properties.Resources.preview_32x32;
            this.btnView.Name = "btnView";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Caption = "Làm mới";
            this.btnRefresh.Id = 4;
            this.btnRefresh.ImageOptions.Image = global::VaccineManagement.Properties.Resources.refresh_16x161;
            this.btnRefresh.ImageOptions.LargeImage = global::VaccineManagement.Properties.Resources.refresh_32x321;
            this.btnRefresh.Name = "btnRefresh";
            // 
            // btnInject
            // 
            this.btnInject.Caption = "Thêm mới mũi tiêm";
            this.btnInject.Id = 6;
            this.btnInject.ImageOptions.Image = global::VaccineManagement.Properties.Resources.snaptogglefieldhighlighting_16x16;
            this.btnInject.ImageOptions.LargeImage = global::VaccineManagement.Properties.Resources.snaptogglefieldhighlighting_32x32;
            this.btnInject.Name = "btnInject";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.barDockControlTop.Size = new System.Drawing.Size(1333, 40);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 1062);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.barDockControlBottom.Size = new System.Drawing.Size(1333, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 40);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 1022);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1333, 40);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 1022);
            // 
            // bar3
            // 
            this.bar3.BarName = "Custom 2";
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar3.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnAdd),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnEdit),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnDelete),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnView),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnRefresh),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnInject)});
            this.bar3.Text = "Custom 2";
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnAdd),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnEdit),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnDelete)});
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // bar1
            // 
            this.bar1.BarName = "Custom 2";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.Text = "Custom 2";
            // 
            // ChildrenPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "ChildrenPage";
            this.Size = new System.Drawing.Size(1333, 1062);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraGrid.Columns.GridColumn colChildId;
        private DevExpress.XtraGrid.Columns.GridColumn colFullName;
        private DevExpress.XtraGrid.Columns.GridColumn colDateOfBirth;
        private DevExpress.XtraGrid.Columns.GridColumn colGender;
        private DevExpress.XtraGrid.Columns.GridColumn colBloodType;
        private DevExpress.XtraGrid.Columns.GridColumn colParentName;
        private DevExpress.XtraGrid.Columns.GridColumn colParentPhone;
        private DevExpress.XtraGrid.Columns.GridColumn colAddress;
        private DevExpress.XtraGrid.Columns.GridColumn colHealthNotes;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedBy;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedByStaff;
        private DevExpress.XtraGrid.Columns.GridColumn colVaccinationRecords;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedAt;
        private DevExpress.XtraGrid.Columns.GridColumn colUpdatedAt;
        private DevExpress.Data.Linq.EntityInstantFeedbackSource entityInstantFeedbackSource1;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarButtonItem btnAdd;
        private DevExpress.XtraBars.BarButtonItem btnEdit;
        private DevExpress.XtraBars.BarButtonItem btnDelete;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem btnRefresh;
        private DevExpress.XtraBars.BarButtonItem btnView;
        private DevExpress.XtraBars.BarButtonItem btnInject;
        private DevExpress.XtraBars.Bar bar4;
    }
}
