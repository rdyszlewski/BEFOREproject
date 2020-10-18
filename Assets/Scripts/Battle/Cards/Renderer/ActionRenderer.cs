using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionRenderer : MonoBehaviour {
  [SerializeField]
  private Vector3 actionSize;

  private ActionItemCreator itemCreator;

  private List<ActionItem> items;

  public void Initialize () {
    itemCreator = GetComponent<ActionItemCreator> ();
    items = new List<ActionItem> ();
  }

  public void Draw (Card card, Board board) {
    foreach (CardAction action in card.Actions) {
      List<Vector2Int> positions = action.Command.GetPositions (card.Owner, board, action.Direction);
      foreach (Vector2Int position in positions) {
        ActionItem item = itemCreator.CreateAction (action, position, transform, actionSize);
        items.Add (item);
      }
    }
  }

  void Start(){
    Initialize();
    CardCreator creator = transform.parent.GetComponentInChildren<CardCreator>();
    Card card = creator.CreateCard(CardType.MOVE_HORIZONTAL);
    Board board = null;
    Draw(card, board);
  }
}