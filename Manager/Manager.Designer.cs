
namespace Manager
{
    partial class Manager
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.addButton = new System.Windows.Forms.Button();
            this.removeButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.refreshButton = new System.Windows.Forms.Button();
            this.updateButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textEmail = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textDescription = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.numericAge = new System.Windows.Forms.NumericUpDown();
            this.listViewUser = new System.Windows.Forms.ListView();
            this.colId = new System.Windows.Forms.ColumnHeader();
            this.colName = new System.Windows.Forms.ColumnHeader();
            this.colAge = new System.Windows.Forms.ColumnHeader();
            this.colEmail = new System.Windows.Forms.ColumnHeader();
            this.colDescription = new System.Windows.Forms.ColumnHeader();
            this.listViewAddress = new System.Windows.Forms.ListView();
            this.columnHeaderAddressId = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderAddressInformation = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderAddressIsCommercial = new System.Windows.Forms.ColumnHeader();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonEditAddress = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.listViewDepartment = new System.Windows.Forms.ListView();
            this.columnHeaderDepartmentId = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderDepartmentName = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderDepartmentDescription = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderDepartmentUserName = new System.Windows.Forms.ColumnHeader();
            this.buttonEditDepartment = new System.Windows.Forms.Button();
            this.errorProviderManager = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.numericAge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderManager)).BeginInit();
            this.SuspendLayout();
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(691, 198);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(200, 50);
            this.addButton.TabIndex = 5;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // removeButton
            // 
            this.removeButton.Location = new System.Drawing.Point(691, 254);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(200, 50);
            this.removeButton.TabIndex = 6;
            this.removeButton.Text = "Remove";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 54);
            this.label1.TabIndex = 8;
            this.label1.Text = "Users";
            // 
            // refreshButton
            // 
            this.refreshButton.Location = new System.Drawing.Point(691, 366);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(200, 50);
            this.refreshButton.TabIndex = 9;
            this.refreshButton.Text = "Refresh";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // updateButton
            // 
            this.updateButton.Location = new System.Drawing.Point(691, 310);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(200, 50);
            this.updateButton.TabIndex = 10;
            this.updateButton.Text = "Update";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 25);
            this.label2.TabIndex = 11;
            this.label2.Text = "Name:";
            // 
            // textName
            // 
            this.textName.Location = new System.Drawing.Point(93, 86);
            this.textName.Name = "textName";
            this.textName.Size = new System.Drawing.Size(150, 31);
            this.textName.TabIndex = 12;
            this.textName.Validating += new System.ComponentModel.CancelEventHandler(this.textName_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 25);
            this.label3.TabIndex = 13;
            this.label3.Text = "Age:";
            // 
            // textEmail
            // 
            this.textEmail.Location = new System.Drawing.Point(93, 161);
            this.textEmail.Name = "textEmail";
            this.textEmail.Size = new System.Drawing.Size(150, 31);
            this.textEmail.TabIndex = 16;
            this.textEmail.Validating += new System.ComponentModel.CancelEventHandler(this.textEmail_Validating);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 161);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 25);
            this.label4.TabIndex = 15;
            this.label4.Text = "Email:";
            // 
            // textDescription
            // 
            this.textDescription.AcceptsReturn = true;
            this.textDescription.AcceptsTab = true;
            this.textDescription.Location = new System.Drawing.Point(364, 86);
            this.textDescription.Multiline = true;
            this.textDescription.Name = "textDescription";
            this.textDescription.Size = new System.Drawing.Size(223, 106);
            this.textDescription.TabIndex = 18;
            this.textDescription.Validating += new System.ComponentModel.CancelEventHandler(this.textDescription_Validating);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(252, 86);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 25);
            this.label5.TabIndex = 17;
            this.label5.Text = "Description:";
            // 
            // numericAge
            // 
            this.numericAge.Location = new System.Drawing.Point(93, 124);
            this.numericAge.Name = "numericAge";
            this.numericAge.Size = new System.Drawing.Size(150, 31);
            this.numericAge.TabIndex = 19;
            this.numericAge.Validating += new System.ComponentModel.CancelEventHandler(this.numericAge_Validating);
            // 
            // listViewUser
            // 
            this.listViewUser.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colId,
            this.colName,
            this.colAge,
            this.colEmail,
            this.colDescription});
            this.listViewUser.FullRowSelect = true;
            this.listViewUser.GridLines = true;
            this.listViewUser.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewUser.HideSelection = false;
            this.listViewUser.Location = new System.Drawing.Point(29, 198);
            this.listViewUser.MultiSelect = false;
            this.listViewUser.Name = "listViewUser";
            this.listViewUser.Size = new System.Drawing.Size(656, 352);
            this.listViewUser.TabIndex = 20;
            this.listViewUser.UseCompatibleStateImageBehavior = false;
            this.listViewUser.View = System.Windows.Forms.View.Details;
            this.listViewUser.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.userList_ItemSelectionChanged);
            // 
            // colId
            // 
            this.colId.Text = "id";
            this.colId.Width = 30;
            // 
            // colName
            // 
            this.colName.Text = "Name";
            this.colName.Width = 200;
            // 
            // colAge
            // 
            this.colAge.Text = "Age";
            this.colAge.Width = 50;
            // 
            // colEmail
            // 
            this.colEmail.Text = "Email";
            this.colEmail.Width = 200;
            // 
            // colDescription
            // 
            this.colDescription.Text = "Description";
            this.colDescription.Width = 200;
            // 
            // listViewAddress
            // 
            this.listViewAddress.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderAddressId,
            this.columnHeaderAddressInformation,
            this.columnHeaderAddressIsCommercial});
            this.listViewAddress.HideSelection = false;
            this.listViewAddress.Location = new System.Drawing.Point(897, 86);
            this.listViewAddress.Name = "listViewAddress";
            this.listViewAddress.Size = new System.Drawing.Size(555, 218);
            this.listViewAddress.TabIndex = 21;
            this.listViewAddress.UseCompatibleStateImageBehavior = false;
            this.listViewAddress.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderAddressId
            // 
            this.columnHeaderAddressId.Text = "id";
            this.columnHeaderAddressId.Width = 30;
            // 
            // columnHeaderAddressInformation
            // 
            this.columnHeaderAddressInformation.Text = "information";
            this.columnHeaderAddressInformation.Width = 320;
            // 
            // columnHeaderAddressIsCommercial
            // 
            this.columnHeaderAddressIsCommercial.Text = "is commercial";
            this.columnHeaderAddressIsCommercial.Width = 200;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(897, 58);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 25);
            this.label6.TabIndex = 22;
            this.label6.Text = "Addresses";
            // 
            // buttonEditAddress
            // 
            this.buttonEditAddress.Location = new System.Drawing.Point(1458, 86);
            this.buttonEditAddress.Name = "buttonEditAddress";
            this.buttonEditAddress.Size = new System.Drawing.Size(112, 34);
            this.buttonEditAddress.TabIndex = 23;
            this.buttonEditAddress.Text = "Edit";
            this.buttonEditAddress.UseVisualStyleBackColor = true;
            this.buttonEditAddress.Click += new System.EventHandler(this.buttonEditAddress_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(897, 310);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(115, 25);
            this.label7.TabIndex = 24;
            this.label7.Text = "Departments";
            // 
            // listViewDepartment
            // 
            this.listViewDepartment.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderDepartmentId,
            this.columnHeaderDepartmentName,
            this.columnHeaderDepartmentDescription,
            this.columnHeaderDepartmentUserName});
            this.listViewDepartment.HideSelection = false;
            this.listViewDepartment.Location = new System.Drawing.Point(897, 338);
            this.listViewDepartment.Name = "listViewDepartment";
            this.listViewDepartment.Size = new System.Drawing.Size(555, 212);
            this.listViewDepartment.TabIndex = 25;
            this.listViewDepartment.UseCompatibleStateImageBehavior = false;
            this.listViewDepartment.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderDepartmentId
            // 
            this.columnHeaderDepartmentId.Text = "id";
            this.columnHeaderDepartmentId.Width = 30;
            // 
            // columnHeaderDepartmentName
            // 
            this.columnHeaderDepartmentName.Text = "name";
            this.columnHeaderDepartmentName.Width = 200;
            // 
            // columnHeaderDepartmentDescription
            // 
            this.columnHeaderDepartmentDescription.Text = "description";
            this.columnHeaderDepartmentDescription.Width = 170;
            // 
            // columnHeaderDepartmentUserName
            // 
            this.columnHeaderDepartmentUserName.Text = "owner";
            this.columnHeaderDepartmentUserName.Width = 150;
            // 
            // buttonEditDepartment
            // 
            this.buttonEditDepartment.Location = new System.Drawing.Point(1458, 338);
            this.buttonEditDepartment.Name = "buttonEditDepartment";
            this.buttonEditDepartment.Size = new System.Drawing.Size(112, 34);
            this.buttonEditDepartment.TabIndex = 26;
            this.buttonEditDepartment.Text = "Edit";
            this.buttonEditDepartment.UseVisualStyleBackColor = true;
            this.buttonEditDepartment.Click += new System.EventHandler(this.buttonEditDepartment_Click);
            // 
            // errorProviderManager
            // 
            this.errorProviderManager.BlinkRate = 200;
            this.errorProviderManager.ContainerControl = this;
            // 
            // Manager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.ClientSize = new System.Drawing.Size(1582, 581);
            this.Controls.Add(this.buttonEditDepartment);
            this.Controls.Add(this.listViewDepartment);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.buttonEditAddress);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.listViewAddress);
            this.Controls.Add(this.listViewUser);
            this.Controls.Add(this.numericAge);
            this.Controls.Add(this.textDescription);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textEmail);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.updateButton);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.removeButton);
            this.Controls.Add(this.addButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Manager";
            this.Text = "Manager";
            this.Load += new System.EventHandler(this.Manager_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericAge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderManager)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textEmail;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numericAge;
        private System.Windows.Forms.ListView listViewUser;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colAge;
        private System.Windows.Forms.ColumnHeader colEmail;
        private System.Windows.Forms.ColumnHeader colDescription;
        private System.Windows.Forms.ColumnHeader colId;
        private System.Windows.Forms.TextBox textDescription;
        private System.Windows.Forms.ListView listViewAddress;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonEditAddress;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListView listViewDepartment;
        private System.Windows.Forms.Button buttonEditDepartment;
        private System.Windows.Forms.ColumnHeader columnHeaderAddressId;
        private System.Windows.Forms.ColumnHeader columnHeaderAddressInformation;
        private System.Windows.Forms.ColumnHeader columnHeaderAddressIsCommercial;
        private System.Windows.Forms.ColumnHeader columnHeaderDepartmentId;
        private System.Windows.Forms.ColumnHeader columnHeaderDepartmentName;
        private System.Windows.Forms.ColumnHeader columnHeaderDepartmentDescription;
        private System.Windows.Forms.ColumnHeader columnHeaderDepartmentUserName;
        private System.Windows.Forms.ErrorProvider errorProviderManager;
    }
}

