using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBDman.Classes
{
    class Inventory
    {
        public int quantity { get; set; }
        public string objectId { get; set; }
        public int lastUpdateAt { get; set; }
    }
}