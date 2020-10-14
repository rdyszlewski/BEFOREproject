using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Battle.Board.Renderer
{
    public enum SelectionType
    {
        MOVE,
        ATTACK,
        USE,
        ENEMY
    }

    public interface ISelection
    {
        // TODO: czy to na pewno jest odpowiednio zrobione?
        void Select(BoardCell cell, SelectionType type);
        void Deselect(BoardCell cell, SelectionType type);
    }
}
