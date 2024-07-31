using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashTracker
{
    [Serializable]
    public class ListViewItemData
    {
        public string Text { get; set; }
        public List<string> SubItems { get; set; } = new List<string>();
    }
}
