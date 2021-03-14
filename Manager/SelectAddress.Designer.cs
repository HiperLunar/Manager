
namespace Manager
{
    partial class SelectAddress
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
            this.labelTitle = new System.Windows.Forms.Label();
            this.listViewUserAddress = new System.Windows.Forms.ListView();
            this.columnId2 = new System.Windows.Forms.ColumnHeader();
            this.columnInfo2 = new System.Windows.Forms.ColumnHeader();
            this.columnIsCommercial2 = new System.Windows.Forms.ColumnHeader();
            this.updateButton = new System.Windows.Forms.Button();
            this.refreshButton = new System.Windows.Forms.Button();
            this.removeButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.listViewAddress = new System.Windows.Forms.ListView();
            this.columnId = new System.Windows.Forms.ColumnHeader();
            this.columnInformation = new System.Windows.Forms.ColumnHeader();
            this.columnIsCommercial = new System.Windows.Forms.ColumnHeader();
            this.buttonMove = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonOk = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxInformation = new System.Windows.Forms.TextBox();
            this.checkBoxIsCommercial = new System.Windows.Forms.CheckBox();
            this.comboBoxUser = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelTitle.Location = new System.Drawing.Point(12, 9);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(289, 32);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Select address for user {0}";
            // 
            // listViewUserAddress
            // 
            this.listViewUserAddress.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnId2,
            this.columnInfo2,
            this.columnIsCommercial2});
            this.listViewUserAddress.FullRowSelect = true;
            this.listViewUserAddress.HideSelection = false;
            this.listViewUserAddress.Location = new System.Drawing.Point(12, 155);
            this.listViewUserAddress.MultiSelect = false;
            this.listViewUserAddress.Name = "listViewUserAddress";
            this.listViewUserAddress.Size = new System.Drawing.Size(320, 400);
            this.listViewUserAddress.TabIndex = 1;
            this.listViewUserAddress.UseCompatibleStateImageBehavior = false;
            this.listViewUserAddress.View = System.Windows.Forms.View.Details;
            this.listViewUserAddress.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listViewUserAddress_ItemSelectionChanged);
            // 
            // columnId2
            // 
            this.columnId2.Text = "id";
            this.columnId2.Width = 30;
            // 
            // columnInfo2
            // 
            this.columnInfo2.Text = "information";
            this.columnInfo2.Width = 200;
            // 
            // columnIsCommercial2
            // 
            this.columnIsCommercial2.Text = "is commercial";
            // 
            // updateButton
            // 
            this.updateButton.Location = new System.Drawing.Point(702, 267);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(200, 50);
            this.updateButton.TabIndex = 14;
            this.updateButton.Text = "Update";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // refreshButton
            // 
            this.refreshButton.Location = new System.Drawing.Point(702, 323);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(200, 50);
            this.refreshButton.TabIndex = 13;
            this.refreshButton.Text = "Refresh";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // removeButton
            // 
            this.removeButton.Location = new System.Drawing.Point(702, 211);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(200, 50);
            this.removeButton.TabIndex = 12;
            this.removeButton.Text = "Remove";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(702, 155);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(200, 50);
            this.addButton.TabIndex = 11;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // listViewAddress
            // 
            this.listViewAddress.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnId,
            this.columnInformation,
            this.columnIsCommercial});
            this.listViewAddress.FullRowSelect = true;
            this.listViewAddress.HideSelection = false;
            this.listViewAddress.Location = new System.Drawing.Point(376, 155);
            this.listViewAddress.MultiSelect = false;
            this.listViewAddress.Name = "listViewAddress";
            this.listViewAddress.Size = new System.Drawing.Size(320, 400);
            this.listViewAddress.TabIndex = 15;
            this.listViewAddress.UseCompatibleStateImageBehavior = false;
            this.listViewAddress.View = System.Windows.Forms.View.Details;
            this.listViewAddress.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listViewAddress_ItemSelectionChanged);
            // 
            // columnId
            // 
            this.columnId.Text = "id";
            this.columnId.Width = 30;
            // 
            // columnInformation
            // 
            this.columnInformation.Text = "Information";
            this.columnInformation.Width = 200;
            // 
            // columnIsCommercial
            // 
            this.columnIsCommercial.Text = "is commercial";
            // 
            // buttonMove
            // 
            this.buttonMove.BackgroundImage = global::Manager.Properties.Resources.arrow_icon_32;
            this.buttonMove.Location = new System.Drawing.Point(338, 294);
            this.buttonMove.Name = "buttonMove";
            this.buttonMove.Size = new System.Drawing.Size(32, 32);
            this.buttonMove.TabIndex = 16;
            this.buttonMove.UseVisualStyleBackColor = true;
            this.buttonMove.Click += new System.EventHandler(this.buttonMove_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Image = global::Manager.Properties.Resources.block_icon;
            this.buttonDelete.Location = new System.Drawing.Point(338, 332);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(32, 32);
            this.buttonDelete.TabIndex = 17;
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(824, 513);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(78, 42);
            this.buttonOk.TabIndex = 18;
            this.buttonOk.Text = "Ok";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 25);
            this.label1.TabIndex = 19;
            this.label1.Text = "Information:";
            // 
            // textBoxInformation
            // 
            this.textBoxInformation.Location = new System.Drawing.Point(128, 83);
            this.textBoxInformation.Name = "textBoxInformation";
            this.textBoxInformation.Size = new System.Drawing.Size(204, 31);
            this.textBoxInformation.TabIndex = 20;
            // 
            // checkBoxIsCommercial
            // 
            this.checkBoxIsCommercial.AutoSize = true;
            this.checkBoxIsCommercial.Location = new System.Drawing.Point(128, 120);
            this.checkBoxIsCommercial.Name = "checkBoxIsCommercial";
            this.checkBoxIsCommercial.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBoxIsCommercial.Size = new System.Drawing.Size(146, 29);
            this.checkBoxIsCommercial.TabIndex = 21;
            this.checkBoxIsCommercial.Text = "is commercial";
            this.checkBoxIsCommercial.UseVisualStyleBackColor = true;
            // 
            // comboBoxUser
            // 
            this.comboBoxUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxUser.FormattingEnabled = true;
            this.comboBoxUser.Location = new System.Drawing.Point(128, 44);
            this.comboBoxUser.Name = "comboBoxUser";
            this.comboBoxUser.Size = new System.Drawing.Size(182, 33);
            this.comboBoxUser.TabIndex = 22;
            this.comboBoxUser.SelectionChangeCommitted += new System.EventHandler(this.comboBoxUser_SelectionChangeCommitted);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 25);
            this.label2.TabIndex = 23;
            this.label2.Text = "User:";
            // 
            // SelectAddress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(917, 573);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxUser);
            this.Controls.Add(this.checkBoxIsCommercial);
            this.Controls.Add(this.textBoxInformation);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonMove);
            this.Controls.Add(this.listViewAddress);
            this.Controls.Add(this.updateButton);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.removeButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.listViewUserAddress);
            this.Controls.Add(this.labelTitle);
            this.Name = "SelectAddress";
            this.Text = "Select address";
            this.Load += new System.EventHandler(this.SelectAddress_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.ListView listViewUserAddress;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.ListView listViewAddress;
        private System.Windows.Forms.Button buttonMove;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.ColumnHeader columnId;
        private System.Windows.Forms.ColumnHeader columnInformation;
        private System.Windows.Forms.ColumnHeader columnIsCommercial;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.ColumnHeader columnId2;
        private System.Windows.Forms.ColumnHeader columnInfo2;
        private System.Windows.Forms.ColumnHeader columnIsCommercial2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxInformation;
        private System.Windows.Forms.CheckBox checkBoxIsCommercial;
        private System.Windows.Forms.ComboBox comboBoxUser;
        private System.Windows.Forms.Label label2;
    }
}