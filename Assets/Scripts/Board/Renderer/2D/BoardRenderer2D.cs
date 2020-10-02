using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BoardRenderer2D : MonoBehaviour, IBoardRenderer
{

    private readonly Color DEFAULT_COLOR = Color.white;
    private readonly Color HOVER_COLOR = Color.blue;
    private readonly Color SELECT_COLOR = Color.green;

    [SerializeField]
    private GameObject cell;


    [SerializeField]
    private Texture2D tempFloorTexture;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    public Cell CreateCell(GameObject parent)
    {
      Cell cell = InstantiateCell(parent);
      cell.SetupTexture(tempFloorTexture);
      return cell;
    }

    public Cell InstantiateCell(GameObject parent)
    {
      GameObject gameObject = InstantiateObject(cell, parent);
      return gameObject.GetComponent<Cell>();
    }

    private GameObject InstantiateObject(GameObject gameObject, GameObject parent)
    {
      return Instantiate(gameObject, Vector3.zero, Quaternion.identity, parent.transform);
    }

    public void HoverCell(Cell cell)
    {
      cell.ChangeColor(HOVER_COLOR);
    }

    public void SelectCell(Cell cell)
    {
      cell.ChangeColor(SELECT_COLOR);
    }

    public void ResetCellSelection(Cell cell)
    {
      cell.ChangeColor(DEFAULT_COLOR);
    }
}
