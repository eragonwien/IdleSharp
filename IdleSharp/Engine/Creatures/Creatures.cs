using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public abstract class Creatures
    {
        public Creatures(string name, int maximumHitPoint, int currentHitPoint)
        {
            Name = name;
            MaximumHitPoint = maximumHitPoint;
            CurrentHitPoint = currentHitPoint;
        }

        public string Name { get; set; }
        public int MaximumHitPoint { get; set; }
        public int CurrentHitPoint { get; set; }
    }
}
