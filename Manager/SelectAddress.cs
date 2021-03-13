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
            labelTitle.Text = String.Format("Select address for user {0}", user.name);
            refreshList();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (!db.AddAddress(new Address(0, textBoxInformation.Text, checkBoxIsCommercial.Checked)))
            {
                MessageBox.Show("Error while inserting to database :(", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            refreshList();
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listViewAddress.SelectedItems)
            {
                Address address = new Address(item);
                if (!db.DeleteAddressById(address.id))
                {
                    MessageBox.Show("Error while deleting to database :(", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            refreshList();
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listViewAddress.SelectedItems)
            {
                Address address = new Address(item);
                address.info = textBoxInformation.Text;
                address.isCommercial = checkBoxIsCommercial.Checked;
                if (!db.UpdateAddress(address))
                {
                    MessageBox.Show("Error while deleting to database :(", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            refreshList();
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            refreshList();
        }

        public void refreshList()
        {
            Address[] data = db.GetAddressList();

            listViewAddress.Items.Clear();

            foreach (Address address in data) { listViewAddress.Items.Add(address.GetListViewItem()); }

            Address[] list = db.GetAddressByUserId(user.id);

            listViewUserAddress.Items.Clear();

            foreach (Address address in list) { listViewUserAddress.Items.Add(address.GetListViewItem()); }
        }

        private void buttonMove_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listViewAddress.SelectedItems)
            {
                if (!db.AddUserAddress(user.id, new Address(item).id))
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
                if (!db.DeleteUserAddress(user.id, new Address(item).id))
                {
                    MessageBox.Show("Error while inserting to database :(", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            refreshList();
        }

        private void listViewAddress_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            Address address= new Address(e.Item);
            textBoxInformation.Text = address.info;
            checkBoxIsCommercial.Checked = address.isCommercial;
        }

        private void listViewUserAddress_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            Address address = new Address(e.Item);
            textBoxInformation.Text = address.info;
            checkBoxIsCommercial.Checked = address.isCommercial;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
