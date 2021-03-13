using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Windows.Forms;

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
            this.id = id;
            this.name = name;
            this.age = age;
            this.email = email;
            this.description = description;
        }

        public User(ListViewItem item)
        {
            this.id = Convert.ToInt32(item.SubItems[0].Text);
            this.name = item.SubItems[1].Text;
            this.age = Convert.ToInt32(item.SubItems[2].Text);
            this.email = item.SubItems[3].Text;
            this.description = item.SubItems[4].Text;
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
            return item;
        }
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

        public Address(ListViewItem item)
        {
            this.id= Convert.ToInt32(item.SubItems[0].Text);
            this.info = item.SubItems[1].Text;
            this.isCommercial = item.SubItems[2].Text == "True";
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
            return item;
        }
    }

    public class Department
    {
        public Id id;
        public string name;
        public string description;
        public Id userId;

        public Department(Id id, string name, string description, Id userId)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.userId = userId;
        }

        public Department(ListViewItem item)
        {
            this.id = Convert.ToInt32(item.SubItems[0]);
            this.name = item.SubItems[1].ToString();
            this.description = item.SubItems[2].ToString();
            this.userId = Convert.ToInt32(item.SubItems[3]);
        }

        public Department(DataRow row)
        {
            this.id = Convert.ToInt32(row.ItemArray[0]);
            this.name = row.ItemArray[1].ToString();
            this.description = row.ItemArray[2].ToString();
            this.userId = Convert.ToInt32(row.ItemArray[3]);
        }

        public ListViewItem GetListViewItem()
        {
            ListViewItem item = new ListViewItem(id.ToString());
            item.SubItems.Add(name);
            item.SubItems.Add(description);
            item.SubItems.Add(userId.ToString());
            return item;
        }
    }
}
