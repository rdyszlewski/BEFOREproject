using System.Collections.Generic;
using UnityEngine;

public class HandRenderer : MonoBehaviour
{
  // TODO; prawdopdobnie to wszystko będzie wyglądało nieco inaczej. Być może będzie jeden renderer zarządzający wszystkimi kartami (Deck, Hand, ChosenCards). Wtedy będzie można robić fajne przejśćia karty pomiędzy odpowiednimi kupkami

  // TODO: może zrobić jakiś globalny rozmiar karty, tak, żeby w każdym miejscu wyglądały tak samo
  [SerializeField]
  private Vector3 cardSize;

  private Hand hand;
  private List<CardItem> items;
  private SelectionController selectionController;
  private CardItemCreator itemCreator;
  
  public void Initialize(){
    items = new List<CardItem>();
    ICardSelection selection = GetComponent<ColorCardSelection>();
    selectionController = new SelectionController(selection);
    itemCreator = GetComponent<CardItemCreator>();
  }

  public void Draw(Hand hand){
    this.hand = hand;
    // TODO: to chyba można rozwiązać jakoś inaczej
    selectionController.CardCommand = new ChooseCardCommand(hand);
    for(int i=0; i<hand.GetSize(); i++){
      AddCard(hand.GetCard(i));
    }
  }

  public void RemoveAll(){
    foreach(CardItem item in items){
      Destroy(item.gameObject);
    }
    items.Clear();
  }

  public void Remove(Card card){
    CardItem item = items.Find(x=>x.Card == card);
    Destroy(item.gameObject);
    items.Remove(item);
  }

  void Update(){
    selectionController.Update();
  }

  public void AddCard(Card card){
    CardItem item = itemCreator.CreateItem(card, transform, cardSize);
    items.Add(item);
  }
}
