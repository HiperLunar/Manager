using System.Data;
using System.Windows.Forms;

using Id = System.Guid;

namespace Manager
{
    public class Address
    {
        public Id id;
        public string info;
        public bool isCommercial;

        public Address(Id? id, string info, bool isCommercial)
        {
            this.id = id ?? Id.NewGuid();
            this.info = info;
            this.isCommercial = isCommercial;
        }

        public Address(DataRow row)
        {
            this.id = row.Field<Id>("Id");
            this.info = row.Field<string>("AddressInfo");
            this.isCommercial = row.Field<bool>("IsCommercial");
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
}
