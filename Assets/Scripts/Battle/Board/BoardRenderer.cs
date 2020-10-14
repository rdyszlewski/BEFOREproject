using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoardRenderer : MonoBehaviour
{
    [SerializeField]
    private GameObject cellPrefab;

    [SerializeField]
    private GameObject floorContainer;

    [SerializeField]
    private GameObject pawnsContainer;

    [SerializeField]
    private GameObject objectsContainer;

    [SerializeField]
    private GameObject effectsContainer;

    private Vector2 cellSize;

    public void Initialize()
    {
        // TODO: wykonać tutaj jakieś działania
    }

    public void CreateBoard(Board board)
    {
        Debug.Assert(cellPrefab != null);
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

        for(int row = 0; row < boardSize.y; row++)
        {
            for( int column = 0; column < boardSize.x; column++)
            {
                GameObject gameObject = Instantiate(cellPrefab, floorContainer.transform);
                gameObject.AddComponent(typeof(LayoutElement));
                BoardCell boardCell = gameObject.GetComponent<BoardCell>();
                boardCell.Initialize();
                boardCell.Resize(cellSize);
                boardCell.SetLayer(1);
                // TODO: tutaj powinna być jeszcze zmiana wyglądu
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
        //rectTransform.rect.Set(size.x/2, size.y/2, size.x, size.y);
        rectTransform.sizeDelta = size;
        //rectTransform.position = new Vector3(size.x / 2, size.y / 2, 0); // TODO: tutaj prawdopodobnie umieścić wartość wartsty
        //rectTransform.anchoredPosition = new Vector3(0, 0, 0);
    }

    // TODO: utworzenie tablicy
    // TODO: przemieszczanie pionka
    
}
