namespace VaccineManagement.UserViewControl
{
    partial class VaccinePackagePage
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
            this.colPackageId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsActive = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPackageVaccines = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVaccinationRecords = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreatedAt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUpdatedAt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.btnAdd = new DevExpress.XtraBars.BarButtonItem();
            this.btnEdit = new DevExpress.XtraBars.BarButtonItem();
            this.btnDelete = new DevExpress.XtraBars.BarButtonItem();
            this.btnRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl
            // 
            this.gridControl.DataSource = this.entityInstantFeedbackSource1;
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.Location = new System.Drawing.Point(0, 24);
            this.gridControl.MainView = this.gridView;
            this.gridControl.Name = "gridControl";
            this.gridControl.Size = new System.Drawing.Size(800, 576);
            this.gridControl.TabIndex = 2;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            // 
            // entityInstantFeedbackSource1
            // 
            this.entityInstantFeedbackSource1.DefaultSorting = "PackageId ASC";
            this.entityInstantFeedbackSource1.DesignTimeElementType = typeof(VaccineManagement.Model.VaccinationPackage);
            this.entityInstantFeedbackSource1.KeyExpression = "PackageId";
            // 
            // gridView
            // 
            this.gridView.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colPackageId,
            this.colName,
            this.colDescription,
            this.colPrice,
            this.colIsActive,
            this.colPackageVaccines,
            this.colVaccinationRecords,
            this.colCreatedAt,
            this.colUpdatedAt});
            this.gridView.GridControl = this.gridControl;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.Editable = false;
            this.gridView.OptionsBehavior.ReadOnly = true;
            this.gridView.OptionsView.ShowGroupPanel = false;
            // 
            // colPackageId
            // 
            this.colPackageId.FieldName = "PackageId";
            this.colPackageId.Name = "colPackageId";
            this.colPackageId.Visible = true;
            this.colPackageId.VisibleIndex = 0;
            // 
            // colName
            // 
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 1;
            // 
            // colDescription
            // 
            this.colDescription.FieldName = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 2;
            
            // 
            // colPrice
            // 
            this.colPrice.FieldName = "Price";
            this.colPrice.Name = "colPrice";
            this.colPrice.Visible = true;
            this.colPrice.VisibleIndex = 4;
            // 
            // colIsActive
            // 
            this.colIsActive.FieldName = "IsActive";
            this.colIsActive.Name = "colIsActive";
            this.colIsActive.Visible = true;
            this.colIsActive.VisibleIndex = 5;
            // 
            // colPackageVaccines
            // 
            this.colPackageVaccines.FieldName = "PackageVaccines";
            this.colPackageVaccines.Name = "colPackageVaccines";
            this.colPackageVaccines.Visible = true;
            this.colPackageVaccines.VisibleIndex = 6;
            // 
            // colVaccinationRecords
            // 
            this.colVaccinationRecords.FieldName = "VaccinationRecords";
            this.colVaccinationRecords.Name = "colVaccinationRecords";
            this.colVaccinationRecords.Visible = true;
            this.colVaccinationRecords.VisibleIndex = 7;
            // 
            // colCreatedAt
            // 
            this.colCreatedAt.FieldName = "CreatedAt";
            this.colCreatedAt.Name = "colCreatedAt";
            this.colCreatedAt.Visible = true;
            this.colCreatedAt.VisibleIndex = 8;
            // 
            // colUpdatedAt
            // 
            this.colUpdatedAt.FieldName = "UpdatedAt";
            this.colUpdatedAt.Name = "colUpdatedAt";
            this.colUpdatedAt.Visible = true;
            this.colUpdatedAt.VisibleIndex = 9;
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar3});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnAdd,
            this.btnEdit,
            this.btnDelete,
            this.btnRefresh});
            this.barManager1.MaxItemId = 5;
            // 
            // bar3
            // 
            this.bar3.BarName = "Custom 2";
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar3.FloatLocation = new System.Drawing.Point(270, 87);
            this.bar3.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnAdd),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnEdit),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnDelete),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnRefresh)});
            this.bar3.Text = "Custom 2";
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
            // btnRefresh
            // 
            this.btnRefresh.Caption = "Làm mới";
            this.btnRefresh.Id = 4;
            this.btnRefresh.ImageOptions.Image = global::VaccineManagement.Properties.Resources.refresh_16x161;
            this.btnRefresh.ImageOptions.LargeImage = global::VaccineManagement.Properties.Resources.refresh_32x321;
            this.btnRefresh.Name = "btnRefresh";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(800, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 600);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(800, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 576);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(800, 24);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 576);
            // 
            // VaccinePackagePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "VaccinePackagePage";
            this.Size = new System.Drawing.Size(800, 600);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.Data.Linq.EntityInstantFeedbackSource entityInstantFeedbackSource1;
        private DevExpress.XtraGrid.Columns.GridColumn colPackageId;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colIsActive;
        private DevExpress.XtraGrid.Columns.GridColumn colPackageVaccines;
        private DevExpress.XtraGrid.Columns.GridColumn colVaccinationRecords;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedAt;
        private DevExpress.XtraGrid.Columns.GridColumn colUpdatedAt;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarButtonItem btnAdd;
        private DevExpress.XtraBars.BarButtonItem btnEdit;
        private DevExpress.XtraBars.BarButtonItem btnDelete;
        private DevExpress.XtraBars.BarButtonItem btnRefresh;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
    }
}
