namespace VaccineManagement.UserViewControl
{
    partial class StaffPage
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
            this.colStaffId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUsername = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPasswordHash = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFullName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPhone = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmail = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRole = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsActive = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVaccinationRecords = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreatedChildren = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreatedAt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUpdatedAt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.bar1 = new DevExpress.XtraBars.Bar();
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
            this.entityInstantFeedbackSource1.DefaultSorting = "StaffId DESC";
            this.entityInstantFeedbackSource1.DesignTimeElementType = typeof(VaccineManagement.Model.Staff);
            this.entityInstantFeedbackSource1.KeyExpression = "StaffId";
            // 
            // gridView
            // 
            this.gridView.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colStaffId,
            this.colUsername,
            this.colPasswordHash,
            this.colFullName,
            this.colPhone,
            this.colEmail,
            this.colRole,
            this.colIsActive,
            this.colVaccinationRecords,
            this.colCreatedChildren,
            this.colCreatedAt,
            this.colUpdatedAt});
            this.gridView.DetailHeight = 619;
            this.gridView.GridControl = this.gridControl;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.Editable = false;
            this.gridView.OptionsBehavior.ReadOnly = true;
            this.gridView.OptionsView.ShowGroupPanel = false;
            // 
            // colStaffId
            // 
            this.colStaffId.FieldName = "StaffId";
            this.colStaffId.MinWidth = 33;
            this.colStaffId.Name = "colStaffId";
            this.colStaffId.Visible = true;
            this.colStaffId.VisibleIndex = 0;
            this.colStaffId.Width = 125;
            // 
            // colUsername
            // 
            this.colUsername.FieldName = "Username";
            this.colUsername.MinWidth = 33;
            this.colUsername.Name = "colUsername";
            this.colUsername.Visible = true;
            this.colUsername.VisibleIndex = 1;
            this.colUsername.Width = 125;
            // 
            // colPasswordHash
            // 
            this.colPasswordHash.FieldName = "PasswordHash";
            this.colPasswordHash.MinWidth = 33;
            this.colPasswordHash.Name = "colPasswordHash";
            this.colPasswordHash.Visible = true;
            this.colPasswordHash.VisibleIndex = 2;
            this.colPasswordHash.Width = 125;
            // 
            // colFullName
            // 
            this.colFullName.FieldName = "FullName";
            this.colFullName.MinWidth = 33;
            this.colFullName.Name = "colFullName";
            this.colFullName.Visible = true;
            this.colFullName.VisibleIndex = 3;
            this.colFullName.Width = 125;
            // 
            // colPhone
            // 
            this.colPhone.FieldName = "Phone";
            this.colPhone.MinWidth = 33;
            this.colPhone.Name = "colPhone";
            this.colPhone.Visible = true;
            this.colPhone.VisibleIndex = 4;
            this.colPhone.Width = 125;
            // 
            // colEmail
            // 
            this.colEmail.FieldName = "Email";
            this.colEmail.MinWidth = 33;
            this.colEmail.Name = "colEmail";
            this.colEmail.Visible = true;
            this.colEmail.VisibleIndex = 5;
            this.colEmail.Width = 125;
            // 
            // colRole
            // 
            this.colRole.FieldName = "Role";
            this.colRole.MinWidth = 33;
            this.colRole.Name = "colRole";
            this.colRole.Visible = true;
            this.colRole.VisibleIndex = 6;
            this.colRole.Width = 125;
            // 
            // colIsActive
            // 
            this.colIsActive.FieldName = "IsActive";
            this.colIsActive.MinWidth = 33;
            this.colIsActive.Name = "colIsActive";
            this.colIsActive.Visible = true;
            this.colIsActive.VisibleIndex = 7;
            this.colIsActive.Width = 125;
            // 
            // colVaccinationRecords
            // 
            this.colVaccinationRecords.FieldName = "VaccinationRecords";
            this.colVaccinationRecords.MinWidth = 33;
            this.colVaccinationRecords.Name = "colVaccinationRecords";
            this.colVaccinationRecords.Visible = true;
            this.colVaccinationRecords.VisibleIndex = 8;
            this.colVaccinationRecords.Width = 125;
            // 
            // colCreatedChildren
            // 
            this.colCreatedChildren.FieldName = "CreatedChildren";
            this.colCreatedChildren.MinWidth = 33;
            this.colCreatedChildren.Name = "colCreatedChildren";
            this.colCreatedChildren.Visible = true;
            this.colCreatedChildren.VisibleIndex = 9;
            this.colCreatedChildren.Width = 125;
            // 
            // colCreatedAt
            // 
            this.colCreatedAt.FieldName = "CreatedAt";
            this.colCreatedAt.MinWidth = 33;
            this.colCreatedAt.Name = "colCreatedAt";
            this.colCreatedAt.Visible = true;
            this.colCreatedAt.VisibleIndex = 10;
            this.colCreatedAt.Width = 125;
            // 
            // colUpdatedAt
            // 
            this.colUpdatedAt.FieldName = "UpdatedAt";
            this.colUpdatedAt.MinWidth = 33;
            this.colUpdatedAt.Name = "colUpdatedAt";
            this.colUpdatedAt.Visible = true;
            this.colUpdatedAt.VisibleIndex = 11;
            this.colUpdatedAt.Width = 125;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 1;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.Text = "Tools";
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
            this.bar3.FloatLocation = new System.Drawing.Point(303, 102);
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
            // StaffPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "StaffPage";
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
        private DevExpress.Data.Linq.EntityInstantFeedbackSource entityInstantFeedbackSource1;
        private DevExpress.XtraGrid.Columns.GridColumn colStaffId;
        private DevExpress.XtraGrid.Columns.GridColumn colUsername;
        private DevExpress.XtraGrid.Columns.GridColumn colPasswordHash;
        private DevExpress.XtraGrid.Columns.GridColumn colFullName;
        private DevExpress.XtraGrid.Columns.GridColumn colPhone;
        private DevExpress.XtraGrid.Columns.GridColumn colEmail;
        private DevExpress.XtraGrid.Columns.GridColumn colRole;
        private DevExpress.XtraGrid.Columns.GridColumn colIsActive;
        private DevExpress.XtraGrid.Columns.GridColumn colVaccinationRecords;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedChildren;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedAt;
        private DevExpress.XtraGrid.Columns.GridColumn colUpdatedAt;
        private DevExpress.XtraBars.Bar bar1;
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
