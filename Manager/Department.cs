using System;

using System.Data;
using System.Windows.Forms;
using Id = System.Guid;

namespace Manager
{
    public class Department
        /*
         * Department information
         */
    {
        public Id id;
        public string name;
        public string description;
        public Id? userId;
        public User user;
        public string userName;

        public Department(Id? id, string name, string description, Id? userId)
        {
            this.id = id ?? Id.NewGuid();
            this.name = name;
            this.description = description;
            this.userId = userId;
        }

        public Department(DataRow row)
        {
            this.id = row.Field<Id>("Id");
            this.name = row.Field<string>("Name");
            this.description = row.Field<string>("Description");
            this.userId = row.Field<Id?>("UserId");
            this.userName = row.Field<string>("UserName");
        }

        public ListViewItem GetListViewItem()
        {
            ListViewItem item = new ListViewItem(id.ToString());
            item.SubItems.Add(name);
            item.SubItems.Add(description);
            item.SubItems.Add(userName?.ToString());
            item.Tag = this;
            return item;
        }
    }
}
