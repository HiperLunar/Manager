﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

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
            int? id;
            if (comboBoxOwner.SelectedItem == null) { id = null; }
            else { id = ((User)comboBoxOwner.SelectedItem).id; }
            if (!db.AddDepartment(new Department(0, textBoxName.Text, textBoxDescription.Text, id)))
            {
                MessageBox.Show("Error while inserting to database :(", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            refreshList();
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listViewDepartment.SelectedItems)
            {
                Department department = (Department) item.Tag;
                if (!db.DeleteDepartmentById(department.id))
                {
                    MessageBox.Show("Error while deleting to database :(", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            refreshList();
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listViewDepartment.SelectedItems) {
                Department department = (Department) item.Tag;
                department.name = textBoxName.Text;
                department.description = textBoxDescription.Text;
                department.userId = ((User)comboBoxOwner.SelectedItem).id;
                if (!db.UpdateDepartment(department))
                {
                    MessageBox.Show("Error while updating to database :(", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            foreach (User user in comboBoxOwner.Items) { if (user.id == department.userId) { comboBoxOwner.SelectedItem = user; break; } }
        }
    }
}