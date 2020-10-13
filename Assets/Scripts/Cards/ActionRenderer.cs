using System.Collections.Generic;
using UnityEngine;

public class ActionRenderer: MonoBehaviour{

  [SerializeField]
  private Vector3 size;

  [SerializeField]
  private Vector2 positionCenter;

  [SerializeField]
  private Vector3 itemSize;
  
  [SerializeField]
  private float breakSize;

  [SerializeField]
  private GameObject cardItemObject;

  private List<CardAction> actions; // TODO: pomyśleć dokładnie, jak do tego podejść

  private CardActionFactory actionFactory;

  private List<CardActionItem> items;
  private CardActionItem selectedItem;

  public void Init(){
    items = new List<CardActionItem>();
    actions = new List<CardAction>(); // TODO: pomyśleć, w jakis sposób można to zrobić
    InitActionFactory();
    // TODO: tutaj nie powinno być żadnych zmian dotryczących usuwania albo dodawania elementów. Dla każdej karty będzie generowany kolejne elemenrty
  }

  private void InitActionFactory(){
    GameObject gameObject = GameObject.FindGameObjectWithTag ("CardsFactory");
    actionFactory = gameObject.GetComponent<CardActionFactory>();
  }

  public void SetActions(List<CardAction> actions){
    this.actions = actions;
    CreateCardsItems(actions);
    // TODO: narysowanie elementów


  }

  private void CreateCardsItems(List<CardAction> actions){
    if(actions == null){
      return;
    }

    Vector3 currentPosition = new Vector3 (positionCenter.x - actions.Count / 2 * itemSize.x + itemSize.x / 2, positionCenter.y, 1);
    foreach (CardAction action in actions) {
      // TODO: 
      CardActionItem item = actionFactory.CreateActionItem(action.type, currentPosition, transform, itemSize);
      items.Add(item);
      currentPosition.x = currentPosition.x + itemSize.x + breakSize;
    }
  }

  public void DestroyAllCards () {
    for (int i = 0; i < this.transform.childCount; i++) {
      Destroy (transform.GetChild (i).gameObject);
    }
  }

  void OnDrawGizmos(){
    Gizmos.color = Color.green;
    Gizmos.DrawWireCube(positionCenter, size);

    Gizmos.color = Color.blue;
    Gizmos.DrawWireCube(positionCenter, itemSize);

    Gizmos.color = Color.black;
    Vector3 lineBegin = new Vector3 (positionCenter.x + itemSize.x / 2, positionCenter.y, 1);
    Vector3 lineEnd = new Vector3 (lineBegin.x + breakSize, lineBegin.y, lineBegin.z);
    Gizmos.DrawLine (lineBegin, lineEnd);
  }
}