using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Battle.Board
{
    public class Floor
    {
        private FloorType type;
        public FloorType Type { get { return type; } }

        public Floor(FloorType type)
        {
            this.type = type;
        }
    }
}
