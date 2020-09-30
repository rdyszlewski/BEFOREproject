using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static BoardRenderer;

public class CellFactory : MonoBehaviour
{

    [SerializeField]
    private GameObject cell2D;

    [SerializeField]
    private GameObject cell3D;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public Cell CreateCell(GameObject parent, GraphicsMode graphicsMode)
    {
        GameObject gameObject = null; ;
        switch (graphicsMode)
        {
            case GraphicsMode.MODE2D:
                gameObject = InstantiateObject(cell2D, parent);
                break;
            case GraphicsMode.MODE3D:
                gameObject = InstantiateObject(cell2D, parent);
                break;

        }
        return gameObject.GetComponent<Cell>();
    }

    private GameObject InstantiateObject(GameObject gameObject, GameObject parent)
    {
        return Instantiate(gameObject, Vector3.zero, Quaternion.identity, parent.transform);
    }

}
