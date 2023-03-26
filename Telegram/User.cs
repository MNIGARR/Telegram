using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telegram
{
    public class User
    {
        public string name { get; set; }

        public DateTime date { get; set; }

        public ObservableCollection<Chat> ChatList { get; set; } = new();
    }
}
