using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Engine
{
    public class InventoryItem
    {
        public InventoryItem(Item details, int quantity)
        {
            Details = details;
            Quantity = quantity;
        }

        public Item Details { get; set; }
        public int Quantity { get; set; }

        public XmlNode XmlNode(XmlDocument data)
        {
            XmlNode xmlItem = data.CreateElement("Item");

            XmlAttribute idAttribute = data.CreateAttribute("ID");
            idAttribute.Value = Details.ID.ToString();
            xmlItem.Attributes.Append(idAttribute);


            XmlAttribute quantityAttribute = data.CreateAttribute("Quantity");
            quantityAttribute.Value = Quantity.ToString();

            xmlItem.Attributes.Append(quantityAttribute);

            return xmlItem;
        }
    }
}
