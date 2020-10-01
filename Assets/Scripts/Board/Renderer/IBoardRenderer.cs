using UnityEngine;

public interface IBoardRenderer{
    Cell CreateCell(GameObject parent);
    void HoverCell(Cell cell);
    void SelectCell(Cell cell);

    void ResetCellSelection(Cell cell);
    // TODO: dodać jeszcze to co będzie potrzebne
}