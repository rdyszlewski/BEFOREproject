using System.Collections.Generic;
using UnityEngine;

public class CardActionFactory: MonoBehaviour{
  // TODO: prawdopodobnie wypadałoby to zrobić w ten sposób, że jest metoda abstrakcyjna, która potrafi tworzyć określoną kartę, oraz klasa, która tworzy wygląd karty
  [System.Serializable]
  public class ActionElement{
    public ActionType type;
    public CardAction action;
    public Texture texture; 
  }

  [SerializeField]
  private List<ActionElement> actions;

  [SerializeField]
  private GameObject actionItemObject;
  // TODO: utworzyć jakiś obiekt

  private Dictionary<ActionType, ActionElement> actionsMap;

  void Awake(){
    actionsMap = new Dictionary<ActionType, ActionElement>();
    foreach(ActionElement element in actions){
      element.action = new CardAction();
      element.action.type = element.type;
      actionsMap.Add(element.type, element);
    }
  }

  public CardAction GetAction(ActionType type){
    // TODO: to jest tylko tymczasowe. 
    return new CardAction();
  }

  public Texture GetActionItemTexture(ActionType type){
    if(actionsMap.ContainsKey(type)){
      return actionsMap[type].texture;
    }
    return null;
  }

  public CardActionItem CreateActionItem(ActionType type, Vector3 position, Transform parent, Vector3 size){
    GameObject gameObject = Instantiate(actionItemObject, position, Quaternion.identity, parent);
    CardActionItem item = gameObject.GetComponent<CardActionItem>();
    CardAction action = GetAction(type);
    item.action = action;
    item.size = size;
    Texture texture = GetActionItemTexture(type);
    item.SetupTexture(texture);
    return item;
  }
}