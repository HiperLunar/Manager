using System;

using System.Data;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Id = System.Guid;

namespace Manager
{
    public class User
        /*
         * User information class
         */
    {
        public Id? id;
        public string name;
        public int age;
        public string email;
        public string description;

        public User() { }

        public User(Id? id, string name, int age, string email, string description)
        {
            this.id = id;
            this.name = name;
            this.age = age;
            this.email = email;
            this.description = description;
        }

        public User(DataRow row)
        {
            this.id = row.Field<Id?>("Id");
            this.name = row.Field<string>("Name");
            this.age = row.Field<int>("Age");
            this.email = row.Field<string>("Email");
            this.description = row.Field<string>("Description");
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

        public void validate()
        {
            validateName(name);
            validateAge(age);
            validateEmail(email);
            validateDescription(description);
        }

        private void validateName(string name) { if (!(name.Length > 0 && name.Length < 50)) { throw new ValidationException("Name field is not valid!"); } }
        private void validateAge(int age) { if (!(age > 0 && name.Length < 100)) { throw new ValidationException("Age  field is not valid!"); } }
        private void validateEmail(string email)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            if (!(email.Length > 0 && name.Length < 50 && regex.Match(email).Success)) { throw new ValidationException("Email  field is not valid!"); } 
        }
        private void validateDescription(string description) { if (!(description.Length > 0 && description.Length < 200)) { throw new ValidationException("Description field is not valid!"); } }
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
