using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace CashTracker
{
    public static class Serializer
    {
        public static ListViewItemData ConvertToListViewItemData(ListViewItem item)
        {
            var data = new ListViewItemData
            {
                Text = item.Text
            };

            foreach (ListViewItem.ListViewSubItem subItem in item.SubItems)
            {
                data.SubItems.Add(subItem.Text);
            }

            return data;
        }

        public static void SaveListViewItemsToXml(string filePath, ListView listView)
        {
            var dataList = listView.Items.Cast<ListViewItem>().Select(ConvertToListViewItemData).ToList();

            var serializer = new XmlSerializer(typeof(List<ListViewItemData>));

            using (var writer = new StreamWriter(filePath))
            {
                serializer.Serialize(writer, dataList);
            }
        }

        public static void LoadListViewItemsFromXml(string filePath, ListView listView)
        {
            if (File.Exists(filePath))
            {
                var serializer = new XmlSerializer(typeof(List<ListViewItemData>));

                List<ListViewItemData> dataList;

                using (var reader = new StreamReader(filePath))
                {
                    dataList = (List<ListViewItemData>)serializer.Deserialize(reader);
                }

                listView.Items.Clear();

                foreach (var data in dataList)
                {
                    var item = new ListViewItem(data.Text);

                    foreach (var subItemText in data.SubItems)
                    {
                        item.SubItems.Add(subItemText);
                    }

                    listView.Items.Add(item);
                }
            }
            else
            {
                Console.Write("No file loaded, starting app with blank slate.");
            }
        }
    }
}
