using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandRenderer : MonoBehaviour {

  private List<CardItem> items;
  private SelectionController selectionController;
  private CardItemCreator itemCreator;

  private Vector3 cardSize;
  private Hand hand;

  public void Initialize (Vector3 cardSize, CardItemCreator itemCreator) {
    items = new List<CardItem> ();
    ICardSelection selection = GetComponent<ColorCardSelection> ();
    selectionController = new SelectionController (selection);
    this.itemCreator = itemCreator;
    this.cardSize = cardSize;
    items = new List<CardItem>();
  }

  public void Draw (Hand hand) {
    this.hand = hand;
    // TODO: to chyba można rozwiązać jakoś inaczej
    selectionController.CardCommand = new ChooseCardCommand (hand);
    for (int i = 0; i < hand.GetSize (); i++) {
      AddCard (hand.GetCard (i));
    }
  }

  public void RemoveAll () {
    foreach (CardItem item in items) {
      Destroy (item.gameObject);
    }
    items.Clear ();
  }

  // TODO: zmienić nazwę
  public CardItem UseCard(Card card){
    CardItem item = FindItem(card);
    items.Remove(item);
    return item;
  }

  public CardItem Remove (Card card) {
    CardItem item = FindItem (card);
    Destroy (item.gameObject);
    items.Remove (item);
    return item;
  }

  public void AddCard (Card card) {
    CardItem item = itemCreator.CreateItem (card, transform, cardSize);
    items.Add (item);
  }

  void Update () {
    if(selectionController != null){
      selectionController.Update ();

    }
  }

  private CardItem FindItem (Card card) {
    return items.Find (x => x.Card == card);
  }
}