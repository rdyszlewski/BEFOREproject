using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardCreator : MonoBehaviour
{

  [System.Serializable]
  private class CardInfo: IElement<CardType>{
    [SerializeField]
    private CardType type;
    public CardType Type{get{return type;}}
    public bool up;
    public bool down;
    public bool left;
    public bool right;
    public bool none;
  }

  [SerializeField]
  private List<CardInfo> cards;
  private ElementsMap<CardType, CardInfo> cardsMap;

  void Awake(){
   cardsMap = new ElementsMap<CardType, CardInfo>();
    cardsMap.Initialize(cards);
    Debug.Assert(cardsMap.GetSize()==Enum.GetValues(typeof(CardType)).Length);

    ActionCommandFactory.Initialize(); // TODO: to powinno być w innym miejscu
  }
  
  public Card CreateCard(CardType type){
    CardInfo info = cardsMap.GetElement(type);
    List<Direction> directions = GetDirections(info);
    List<CardAction> actions = CreateActions(type, directions);
    Card card = new Card(type, actions);
    return card;
  }

  private List<Direction> GetDirections(CardInfo info){
    List<Direction> directions = new List<Direction>();
    if(info.up){
      directions.Add(Direction.UP);
    }
    if(info.down){
      directions.Add(Direction.DOWN);
    }
    if(info.left){
      directions.Add(Direction.LEFT);
    }
    if(info.right){
      directions.Add(Direction.RIGHT);
    }
    if(info.none){
      directions.Add(Direction.NONE);
    }
    return directions;
  }

  private List<CardAction> CreateActions(CardType type, List<Direction> directions){
    List<CardAction> actions = new List<CardAction>();
    foreach(Direction direction in directions){
      CardAction action = new CardAction(type, direction);
      action.Command = ActionCommandFactory.GetCommand(type);
      actions.Add(action);
    }
    return actions;
  }
}
