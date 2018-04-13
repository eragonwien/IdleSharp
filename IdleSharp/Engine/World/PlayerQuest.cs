using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Engine
{
    public class PlayerQuest
    {
        public PlayerQuest(Quest details, bool isCompleted = false)
        {
            Details = details;
            IsCompleted = isCompleted;
        }

        public Quest Details { get; set; }
        public bool IsCompleted { get; set; }

        internal XmlNode XmlNode(XmlDocument data)
        {
            XmlNode xmlQuest = data.CreateElement("Quest");

            XmlAttribute idAttribute = data.CreateAttribute("ID");
            idAttribute.Value = Details.ID.ToString();

            XmlAttribute isCompletedAttribute = data.CreateAttribute("IsCompleted");
            isCompletedAttribute.Value = IsCompleted.ToString();

            xmlQuest.Attributes.Append(idAttribute);
            xmlQuest.Attributes.Append(isCompletedAttribute);

            return xmlQuest;
        }
    }
}
