using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionItemCreator : MonoBehaviour
{
  [System.Serializable]
  private class DirectionElement : IElement<Direction>
  {
    [SerializeField]
    private Direction type;
    public Direction Type{get{return type;}}

    public Texture2D texture;
  }

  [SerializeField]
  private ActionItem actionObject;

  [SerializeField]
  private List<DirectionElement> directionElements;
  private ElementsMap<Direction, DirectionElement> directionElementsMap;

  void Awake(){
    directionElementsMap = new ElementsMap<Direction, DirectionElement>();
    directionElementsMap.Initialize(directionElements);
  }

  public ActionItem CreateAction(CardAction action, Vector2Int actionPosition, Transform parent, Vector3 size){
    GameObject gameObject = Instantiate(actionObject.gameObject, transform);
    ActionItem item = gameObject.GetComponent<ActionItem>();
    item.Initialize(action, actionPosition);
    DirectionElement directionElement = directionElementsMap.GetElement(action.Direction);
    item.SetTexture(directionElement.texture);
    item.Resize(size);

    return item;
  }
}
