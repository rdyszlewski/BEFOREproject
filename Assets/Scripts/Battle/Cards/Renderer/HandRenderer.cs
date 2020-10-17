using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandRenderer : MonoBehaviour
{

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
    selectionController = new SelectionController(selection, new ChooseCardCommand());
    itemCreator = GetComponent<CardItemCreator>();
  }

  public void Draw(Hand hand){
    this.hand = hand;
    // TODO: rysowanie 
    for(int i=0; i<hand.GetSize(); i++){
      Card card = hand.GetCard(i);
      CardItem item = itemCreator.CreateItem(card, transform, cardSize);
      items.Add(item);
    }
  }

  void Update(){
    selectionController.Update();
  }
}
