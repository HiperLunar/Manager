using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Id = System.Guid;

namespace Manager
{
    public partial class SelectDepartment : Form
    {

        DBConnection db = new DBConnection();

        public SelectDepartment()
        {
            InitializeComponent();
        }

        private void SelectDepartment_Load(object sender, EventArgs e)
        {
            db.connect();
            refreshList();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren(ValidationConstraints.Enabled)) { return; }
            Id? id;
            if (comboBoxOwner.SelectedItem == null) { id = null; }
            else { id = ((User)comboBoxOwner.SelectedItem).id; }
            DBResult result = db.AddDepartment(new Department(null, textBoxName.Text, textBoxDescription.Text, id));
            if (!(bool) result.result)
            {
                MessageBox.Show(result.reason, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            refreshList();
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listViewDepartment.SelectedItems)
            {
                Department department = (Department) item.Tag;
                DBResult result = db.DeleteDepartmentById(department.id);
                if (!(bool) result.result)
                {
                    MessageBox.Show(result.reason, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            refreshList();
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren(ValidationConstraints.Enabled)) { return; }
            foreach (ListViewItem item in listViewDepartment.SelectedItems) {
                Department department = (Department) item.Tag;
                department.name = textBoxName.Text;
                department.description = textBoxDescription.Text;
                department.userId = ((User)comboBoxOwner.SelectedItem).id;
                DBResult result = db.UpdateDepartment(department);
                if (!(bool) result.result)
                {
                    MessageBox.Show(result.reason, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                refreshList();
            }
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            refreshList();
        }

        private void refreshList()
        {
            Department[] departmentData = db.GetDepartmentList();
            listViewDepartment.Items.Clear();
            foreach (Department department in departmentData) { listViewDepartment.Items.Add(department.GetListViewItem()); }

            User[] userData = db.GetUserList();
            comboBoxOwner.Items.Clear();
            foreach (User user in userData) { comboBoxOwner.Items.Add(user); }
        }

        private void listViewDepartment_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            Department department = (Department)e.Item.Tag;
            textBoxName.Text = department.name;
            textBoxDescription.Text = department.description;
            comboBoxOwner.SelectedItem = null;
            foreach (User user in comboBoxOwner.Items) { if (user.id == department.userId) { comboBoxOwner.SelectedItem = user; break; } }
            ValidateChildren(ValidationConstraints.Enabled);
        }

        private void textBoxName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(textBoxName, "Name can not be empty");
            }
            else if (textBoxName.Text.Length > 50)
            {
                e.Cancel = true;
                errorProvider.SetError(textBoxName, "Name can not be grater than 50 chars");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(textBoxName, null);
            }
        }

        private void textBoxDescription_Validating(object sender, CancelEventArgs e)
        {
            if (textBoxDescription.Text.Length > 200)
            {
                e.Cancel = true;
                errorProvider.SetError(textBoxDescription, "Description can not be grater than 200 chars");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(textBoxDescription, null);
            }
        }
    }
}