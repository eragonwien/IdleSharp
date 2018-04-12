using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Item
    {
        public Item(int iD, string name, string description)
        {
            ID = iD;
            Name = name;
            Description = description;
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
