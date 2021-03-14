using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Manager
{
    public partial class Manager : Form
    {

        DBConnection db = new DBConnection();

        public Manager()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            db.connect();
            refreshList();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!db.AddUser(new User(0, textName.Text, Convert.ToInt32(numericAge.Value), textEmail.Text, textDescription.Text)))
                {
                    MessageBox.Show("Error while inserting to database :(", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                refreshList();
            } catch (ValidationException exception)
            {
                MessageBox.Show(exception.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in userList.SelectedItems)
            {
                User user = (User) item.Tag;
                if (!db.DeleteUserById(user.id))
                {
                    MessageBox.Show("Error while deleting to database :(", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            refreshList();
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (ListViewItem item in userList.SelectedItems)
                {
                    User user = (User)item.Tag;
                    user.name = textName.Text;
                    user.age = Convert.ToInt32(numericAge.Value);
                    user.email = textEmail.Text;
                    user.description = textDescription.Text;
                    if (!db.UpdateUser(user))
                    {
                        MessageBox.Show("Error while updating to database :(", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                refreshList();
            } catch (ValidationException exception)
            {
                MessageBox.Show(exception.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            refreshList();
        }

        private void refreshList()
        {
            User[] data = db.GetUserList();

            userList.Items.Clear();
            foreach (User user in data) { userList.Items.Add(user.GetListViewItem()); };
            refreshAddressList();
            refreshDepartmentList();
        }

        private void refreshAddressList()
        {
            if (userList.SelectedItems.Count > 0)
            {
                User user = (User) userList.SelectedItems[0].Tag;
                Address[] addressData = db.GetAddressByUserId(user.id);
                listViewAddress.Items.Clear();
                foreach (Address address in addressData) { listViewAddress.Items.Add(address.GetListViewItem()); }
            }
        }

        private void refreshDepartmentList()
        {
            if (userList.SelectedItems.Count > 0)
            {
                User user = (User)userList.SelectedItems[0].Tag;
                Department[] departmentData = db.GetDepartmentListByUserId(user.id);
                listViewDepartment.Items.Clear();
                foreach (Department department in departmentData) { listViewDepartment.Items.Add(department.GetListViewItem()); }
            }
        }

        private void userList_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            User user = (User) e.Item.Tag;
            textName.Text = user.name;
            numericAge.Value = Convert.ToDecimal(user.age);
            textEmail.Text = user.email;
            textDescription.Text = user.description;

            refreshAddressList();
            refreshDepartmentList();
        }

        private void buttonEditAddress_Click(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection itemList = userList.SelectedItems;
            User user;
            if (itemList.Count > 0) { user = (User)itemList[0].Tag; }
            else { user = null; }
            Form selectAddressForm = new SelectAddress(user);
            selectAddressForm.ShowDialog();
            refreshAddressList();
        }

        private void buttonEditDepartment_Click(object sender, EventArgs e)
        {
            SelectDepartment selectDepartment = new SelectDepartment();
            selectDepartment.ShowDialog();
        }
    }
}
