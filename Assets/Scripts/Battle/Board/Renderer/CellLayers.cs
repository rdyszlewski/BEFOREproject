using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellLayers : MonoBehaviour
{

   [System.Serializable]
   private class LayerElement {
        public BoardCellCreator.CellType type;
        public int renderOrder;
   }

    [SerializeField]
    private List<LayerElement> orders;

    public int GetRenderOrder(BoardCellCreator.CellType type)
    {
        LayerElement element = orders.Find(x => x.type == type);
        if (element != null)
        {
            return element.renderOrder;
        }
        return 0;
    }
}
