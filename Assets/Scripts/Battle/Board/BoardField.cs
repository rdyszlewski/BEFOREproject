using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Battle.Board
{ 

    public class BoardField
    {
        private int row;
        private int column;
        private Floor floor;

        public int Row { get => row; set => row = value; }
        public int Column { get => column; set => column = value; }
        public Floor Floor { get => floor; set => floor = value; }

        // TODO: dodać pozostałe elementy, które mogą się zawierać na polu
    }
}
