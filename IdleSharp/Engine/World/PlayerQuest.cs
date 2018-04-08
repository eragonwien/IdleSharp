using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class PlayerQuest
    {
        public PlayerQuest(Quest details, bool isCompleted = false)
        {
            Details = details;
            this.IsCompleted = isCompleted;
        }

        public Quest Details { get; set; }
        public bool IsCompleted { get; set; }
    }
}
