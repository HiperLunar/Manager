using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Manager
{
    using Id = Int32;

    public class User
    {
        public Id id;
        public string name;
        public int age;
        public string email;
        public string description;

        public User(Id id, string name, int age, string email, string description)
        {
            validateName(name);
            validateAge(age);
            validateEmail(email);
            validateDescription(description);

            this.id = id;
            this.name = name;
            this.age = age;
            this.email = email;
            this.description = description;
        }

        public User(DataRow row)
        {
            this.id = Convert.ToInt32(row.ItemArray[0]);
            this.name = row.ItemArray[1].ToString();
            this.age = Convert.ToInt32(row.ItemArray[2]);
            this.email = row.ItemArray[3].ToString();
            this.description = row.ItemArray[4].ToString();
        }

        public ListViewItem GetListViewItem()
        {
            ListViewItem item = new ListViewItem(id.ToString());
            item.SubItems.Add(name);
            item.SubItems.Add(age.ToString());
            item.SubItems.Add(email);
            item.SubItems.Add(description);
            item.Tag = this;
            return item;
        }

        public override string ToString()
        {
            return name;
        }

        private void validateName(string name) { if (!(name.Length > 0 && name.Length < 50)) { throw new ValidationException("Name field is not valid!"); } }
        private void validateAge(int age) { if (!(age > 0 && name.Length < 100)) { throw new ValidationException("Age  field is not valid!"); } }
        private void validateEmail(string email)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            if (!(email.Length > 0 && name.Length < 50 && regex.Match(email).Success)) { throw new ValidationException("Eamil  field is not valid!"); } 
        }
        private void validateDescription(string description) { if (!(description.Length > 0 && description.Length < 200)) { throw new ValidationException("Description field is not valid!"); } }
    }

    public class Address
    {
        public Id id;
        public string info;
        public bool isCommercial;

        public Address(Id id, string info, bool isCommercial)
        {
            this.id = id;
            this.info = info;
            this.isCommercial = isCommercial;
        }

        public Address(DataRow row)
        {
            this.id = Convert.ToInt32(row.ItemArray[0]);
            this.info = row.ItemArray[1].ToString();
            this.isCommercial = row.ItemArray[2].ToString() == "True";
        }

        public ListViewItem GetListViewItem()
        {
            ListViewItem item = new ListViewItem(id.ToString());
            item.SubItems.Add(info);
            item.SubItems.Add(isCommercial.ToString());
            item.Tag = this;
            return item;
        }
    }

    public class Department
    {
        public Id id;
        public string name;
        public string description;
        public Id? userId;
        public User user;

        public Department(Id id, string name, string description, Id? userId)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.userId = userId;
        }

        public Department(DataRow row)
        {
            this.id = Convert.ToInt32(row.ItemArray[0]);
            this.name = row.ItemArray[1].ToString();
            this.description = row.ItemArray[2].ToString();
            if (row.ItemArray[3].Equals(DBNull.Value)) { this.userId = null;  }
            else { this.userId = Convert.ToInt32(row.ItemArray[3]); }
        }

        public ListViewItem GetListViewItem()
        {
            ListViewItem item = new ListViewItem(id.ToString());
            item.SubItems.Add(name);
            item.SubItems.Add(description);
            item.SubItems.Add(userId.ToString());
            item.Tag = this;
            return item;
        }
    }

    public class ValidationException : Exception
    { 
        private string err_message;
        public ValidationException(string message)
        {
            err_message = message;
        }

        public override string Message { get { return err_message; } }
    }
}
