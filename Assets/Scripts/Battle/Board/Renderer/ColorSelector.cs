using Assets.Scripts.Battle.Board.Renderer;
using UnityEngine;

public class ColorSelector : MonoBehaviour, ISelection
{

    [SerializeField]
    private Color moveColor;

    [SerializeField]
    private Color attackColor;

    [SerializeField]
    private Color useColor;

    [SerializeField]
    private Color enemyColor;

    private readonly Color defaultColor = Color.white;
    public void Select(BoardCell cell, SelectionType type)
    {
        Debug.Assert(cell != null);
        Color color = GetColor(type);
        cell.ChangeColor(color);
    }

    private Color GetColor(SelectionType type)
    {
        Debug.Assert(moveColor != null);
        Debug.Assert(attackColor != null);
        Debug.Assert(useColor != null);
        Debug.Assert(enemyColor != null);
        switch (type)
        {
            case SelectionType.MOVE:
                return moveColor;
            case SelectionType.ATTACK:
                return attackColor;
            case SelectionType.USE:
                return useColor;
            case SelectionType.ENEMY:
                return enemyColor;
            default:
                return defaultColor;
        }
    }

    public void Deselect(BoardCell cell, SelectionType type)
    {
        Debug.Assert(cell != null);
        cell.ChangeColor(defaultColor);
    }
}
