using Assets.Scripts.Battle.Board;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class FloorCellCreator : CellCreatorBase
{
    [SerializeField]
    private GameObject floorObject;

    [SerializeField]
    private List<CellElement<FloorType>> elements;
    // TODO: tutaj jest problem. Tego nie widzi. Zwraca to jako pustą listę

    private CellElementsMap<FloorType> elementsMap;

    protected override void InitializeCreator()
    {
        elementsMap = new CellElementsMap<FloorType>();
        elementsMap.Initialize(elements);
    }


    public BoardCell CreateCell(FloorType type, Vector2 cellSize, Transform parent)
    {
        return CreateCell(type, cellSize, parent, new Vector3(0, 0, 0));
    }

    public BoardCell CreateCell(FloorType type, Vector2 cellSize, Transform parent, Vector3 position)
    {
        //Debug.unityLogger.Log(floorElements.Count);
        CellElement<FloorType> element = elementsMap.GetCellElement(type);
        if (element != null)
        {
            GameObject createdObject = Instantiate(floorObject, parent);
            // TODO: jeżeli będzie potrzebne umieszczanie pozycji, wtedy będzie trzeba skorzystać z innego wariantu metody, oraz poprawić pozycję oraz rotację
            createdObject.AddComponent(typeof(LayoutElement)); // TODO: to można przenieść do jakieś wspólnej metody
            
            BoardCell cell = createdObject.GetComponent<BoardCell>();
            cell.Initialize();
            cell.SetLayer(RenderOrder); // TODO: pobranie wartości ze specjalnej 
            cell.SetTexture(element.texture);
            cell.Resize(cellSize);
            return cell;
        }
        return null;
    }
}
