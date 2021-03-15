using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Manager
{
    public partial class SelectAddress : Form
    {
        User user;
        DBConnection db;
        public SelectAddress(User user)
        {
            InitializeComponent();
            db = new DBConnection();
            this.user = user;
        }

        private void SelectAddress_Load(object sender, EventArgs e)
        {
            db.connect();
            labelTitle.Text = String.Format("Select address for user {0}", (user?.name) ?? "");
            refreshList();
            refreshComboBoxItems();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            ValidateChildren(ValidationConstraints.Enabled);
            Address address = new Address(0, textBoxInformation.Text, checkBoxIsCommercial.Checked);
            if (!db.AddAddress(address))
            {
                MessageBox.Show("Error while inserting to database :(", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            refreshList();
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listViewAddress.SelectedItems)
            {
                Address address = (Address) item.Tag;
                if (!db.DeleteAddressById(address.id))
                {
                    MessageBox.Show("Error while deleting to database :(", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            refreshList();
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            ValidateChildren(ValidationConstraints.Enabled);
            foreach (ListViewItem item in listViewAddress.SelectedItems)
            {
                Address address = (Address)item.Tag;
                address.info = textBoxInformation.Text;
                address.isCommercial = checkBoxIsCommercial.Checked;
                if (!db.UpdateAddress(address))
                {
                    MessageBox.Show("Error while deleting to database :(", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            refreshList();
        }

        private void refreshButton_Click(object sender, EventArgs e) { refreshList(); }

        private void refreshList()
        {
            Address[] data = db.GetAddressList();

            listViewAddress.Items.Clear();

            foreach (Address address in data) { listViewAddress.Items.Add(address.GetListViewItem()); }

            listViewUserAddress.Items.Clear();
            if (user != null)
            {
                Address[] list = db.GetAddressByUserId(user.id);

                listViewUserAddress.Items.Clear();

                foreach (Address address in list) { listViewUserAddress.Items.Add(address.GetListViewItem()); }
            }
        }

        private void refreshComboBoxItems()
        {
            User[] userData = db.GetUserList();
            comboBoxUser.Items.Clear();
            foreach (User user in userData) { comboBoxUser.Items.Add(user); }
            foreach (User Cuser in comboBoxUser.Items) { if (user?.id == Cuser.id) { comboBoxUser.SelectedItem = Cuser; break; } }
        }

        private void buttonMove_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listViewAddress.SelectedItems)
            {
                if (!db.AddUserAddress(user.id, ((Address) item.Tag).id))
                {
                    MessageBox.Show("Error while inserting to database :(", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            refreshList();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listViewUserAddress.SelectedItems)
            {
                if (!db.DeleteUserAddress(user.id, ((Address)item.Tag).id))
                {
                    MessageBox.Show("Error while inserting to database :(", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            refreshList();
        }

        private void listViewAddress_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            Address address= (Address) e.Item.Tag;
            textBoxInformation.Text = address.info;
            checkBoxIsCommercial.Checked = address.isCommercial;
        }

        private void listViewUserAddress_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            Address address = (Address) e.Item.Tag;
            textBoxInformation.Text = address.info;
            checkBoxIsCommercial.Checked = address.isCommercial;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBoxUser_SelectionChangeCommitted(object sender, EventArgs e) { user = (User) comboBoxUser.SelectedItem; refreshList(); }

        private void comboBoxUser_Validating(object sender, CancelEventArgs e)
        {
            if (comboBoxUser.SelectedItem == null)
            {
                e.Cancel = true;
                errorProvider.SetError(comboBoxUser, "Must select a user");
            }
        }

        private void textBoxInformation_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxInformation.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(textBoxInformation, "Address information can not be empty");
            }
            else if (textBoxInformation.Text.Length > 200)
            {
                e.Cancel = true;
                errorProvider.SetError(textBoxInformation, "Address information can not be grater than 200 chars");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(textBoxInformation, null);
            }
        }
    }
}
