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
            if (!db.addUser(new User(0, textName.Text, Convert.ToInt32(numericAge.Value), textEmail.Text, textDescription.Text)))
            {
                MessageBox.Show("Error while inserting to database :(", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            refreshList();
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in userList.SelectedItems)
            {
                User user = new User(item);
                if (!db.deleteUserById(user.id))
                {
                    MessageBox.Show("Error while deleting to database :(", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            refreshList();
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in userList.SelectedItems)
            {
                User user = new User(item);
                user.name = textName.Text;
                user.age = Convert.ToInt32(numericAge.Value);
                user.email = textEmail.Text;
                user.description = textDescription.Text;
                if (!db.updateUser(user))
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

        private void refreshList()
        {
            DataTable data = db.getUserTable();

            userList.Items.Clear();

            foreach (DataRow row in data.Rows)
            {
                User user = new User(
                    Convert.ToInt32(row.ItemArray[0]),
                    row.ItemArray[1].ToString(),
                    Convert.ToInt32(row.ItemArray[2]),
                    row.ItemArray[3].ToString(),
                    row.ItemArray[4].ToString()
                );
                userList.Items.Add(user.GetListViewItem());
            }
        }

        private void userList_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            User user = new User(e.Item);
            textName.Text = user.name;
            numericAge.Value = Convert.ToDecimal(user.age);
            textEmail.Text = user.email;
            textDescription.Text = user.description;
        }

        private void userList_DoubleClick(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection itemList = userList.SelectedItems;
            User user = new User(itemList[0]);
            Form selectAddressForm = new SelectAddress(user);
            selectAddressForm.ShowDialog();
        }
    }
}
