using Assets.Scripts.Battle.Board;
using Assets.Scripts.Battle.Board.Renderer;
using UnityEngine;

public class BoardRenderer : MonoBehaviour
{

    [SerializeField]
    private GameObject floorContainer;

    [SerializeField]
    private GameObject pawnsContainer;

    [SerializeField]
    private GameObject objectsContainer;

    [SerializeField]
    private GameObject effectsContainer;

    private BoardCellCreator cellCreator;

    private Vector2 cellSize;

    private BoardSelectionManager selectionManager;
    public void Initialize()
    {
        cellCreator = GetComponent<BoardCellCreator>();
        cellCreator.Initialize();
        InitializeSelectionManager();
    }

    private void InitializeSelectionManager()
    {
        selectionManager = new BoardSelectionManager();
        ColorSelector selector = GetComponent<ColorSelector>();
        selectionManager.SetSelector(selector);
    }

    public void CreateBoard(Board board)
    {
        Debug.Assert(floorContainer != null);
        Debug.Assert(pawnsContainer != null);
        Debug.Assert(objectsContainer != null);
        Debug.Assert(effectsContainer != null);
        Vector2 boardRectSize = GetBoardSize();
        Vector2Int boardSize = board.Size;
        cellSize = new Vector2(boardRectSize.x / boardSize.x, boardRectSize.y / boardSize.y);

        SetContainerSize(floorContainer, boardRectSize);
        SetContainerSize(pawnsContainer, boardRectSize);
        SetContainerSize(objectsContainer, boardRectSize);
        SetContainerSize(effectsContainer, boardRectSize);

        Debug.unityLogger.Log(boardSize);
        for(int row = 0; row < boardSize.y; row++)
        {
            for( int column = 0; column < boardSize.x; column++)
            {
                BoardField field = board.GetField(column, row);
                BoardCell cell = cellCreator.CreateFloorCell(FloorType.DEFAULT, cellSize, floorContainer.transform);
                // TODO: zrobić coś z tą komórką
            }
        }
    }

    private Vector2 GetBoardSize()
    {
        RectTransform parentRectTransform = transform.GetComponent<RectTransform>();
        float width = parentRectTransform.rect.width;
        float height = parentRectTransform.rect.height;
        return new Vector2(width, height);
    }

    private void SetContainerSize(GameObject container, Vector2 size)
    {
        RectTransform rectTransform = container.GetComponent<RectTransform>();
        rectTransform.sizeDelta = size;
    }

    void Update()
    {
        selectionManager.Update();
    }

    // TODO: utworzenie tablicy
    // TODO: przemieszczanie pionka

}
