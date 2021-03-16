using System;
using System.Windows.Forms;

namespace Manager
{
    public partial class Manager : Form
    {

        DBConnection db = new DBConnection();
        User[] userList;


        public Manager()
        {
            InitializeComponent();
        }

        private void Manager_Load(object sender, EventArgs e)
        {
            db.connect();
            refreshList();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateChildren(ValidationConstraints.Enabled)) { return; }   // validate form entries

                User user = new User(null, textName.Text, Convert.ToInt32(numericAge.Value), textEmail.Text, textDescription.Text);
                user.validate();  // validate information
                DBResult result = db.AddUser(user); //  Sql query
                if (!(bool) result.result)
                {
                    MessageBox.Show(result.reason, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                refreshList();
            } catch (ValidationException exception)
            {
                MessageBox.Show(exception.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listViewUser.SelectedItems)
            {
                User user = (User) item.Tag;
                try
                {
                    DBResult result = db.DeleteUserById(user.id ?? throw new Exception());
                    if (!(bool)result.result)
                    {
                        MessageBox.Show(result.reason, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                } catch { return; }
                    
            }
            refreshList();
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateChildren(ValidationConstraints.Enabled)) { return; }

                foreach (ListViewItem item in listViewUser.SelectedItems)
                {
                    User user = (User)item.Tag;
                    user.name = textName.Text;
                    user.age = Convert.ToInt32(numericAge.Value);
                    user.email = textEmail.Text;
                    user.description = textDescription.Text;
                    user.validate();
                    DBResult result = db.UpdateUser(user);
                    if (!(bool) result.result)
                    {
                        MessageBox.Show(result.reason, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                refreshList();
            } catch (ValidationException exception)
            {
                MessageBox.Show(exception.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            refreshList();
        }

        private void refreshList()
        {
            refreshUserList();
            refreshAddressList();
            refreshDepartmentList();
        }

        private void refreshUserList()
        {
            userList = db.GetUserList();

            listViewUser.Items.Clear();
            foreach (User user in userList) { listViewUser.Items.Add(user.GetListViewItem()); };
        }

        private void refreshAddressList()
        {
            if (listViewUser.SelectedItems.Count > 0)
            {
                User user = (User) listViewUser.SelectedItems[0].Tag;
                Address[] addressData = db.GetAddressByUserId(user.id ?? throw new Exception());
                listViewAddress.Items.Clear();
                foreach (Address address in addressData) { listViewAddress.Items.Add(address.GetListViewItem()); }
            }
        }

        private void refreshDepartmentList()
        {
            if (listViewUser.SelectedItems.Count > 0)
            {
                User user = (User)listViewUser.SelectedItems[0].Tag;
                Department[] departmentData = db.GetDepartmentListByUserId(user.id ?? throw new Exception());
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
            if (!ValidateChildren(ValidationConstraints.Enabled)) {}
        }

        private void buttonEditAddress_Click(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection itemList = listViewUser.SelectedItems;
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
            refreshDepartmentList();
        }

        private void textName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textName.Text))
            {
                e.Cancel = true;
                errorProviderManager.SetError(textName, "Name can not be empty");
            }
            else if (textName.Text.Length > 50)
            {
                e.Cancel = true;
                errorProviderManager.SetError(textName, "Name can not be grater than 50 chars");
            }
            else
            {
                e.Cancel = false;
                errorProviderManager.SetError(textName, null);
            }
        }

        private void numericAge_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (numericAge.Value <= 0)
            {
                e.Cancel = true;
                errorProviderManager.SetError(numericAge, "Age can not be 0");
            }
            else if (numericAge.Value > 100)
            {
                e.Cancel = true;
                errorProviderManager.SetError(numericAge, "Age can not be greater than 100");
            }
            else
            {
                e.Cancel = false;
                errorProviderManager.SetError(numericAge, null);
            }
        }

        private void textEmail_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textEmail.Text))
            {
                e.Cancel = true;
                errorProviderManager.SetError(textEmail, "Email can not be empty");
            }
            else if (textEmail.Text.Length > 50)
            {
                e.Cancel = true;
                errorProviderManager.SetError(textEmail, "Email can not be grater than 50 chars");
            }
            else
            {
                e.Cancel = false;
                errorProviderManager.SetError(textEmail, null);
            }
        }

        private void textDescription_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (textDescription.Text.Length > 200)
            {
                e.Cancel = true;
                errorProviderManager.SetError(textDescription, "Description can not be grater than 200 chars");
            }
            else
            {
                e.Cancel = false;
                errorProviderManager.SetError(textDescription, null);
            }
        }
    }
}
