using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckRenderer : MonoBehaviour
{
    private List<CardItem> items;
    private Deck deck;
    private Vector3 cardSize;
    private CardItemCreator itemCreator;

    public void Initialize(Vector3 cardSize, CardItemCreator itemCreator){
      this.cardSize = cardSize;
      this.itemCreator = itemCreator;
      items = new List<CardItem>();
    }

    // TODO: teraz pytanie. Czy tworzymy tutaj wiele kart, czy tylko jedną, żeby było widać, że coś się tutaj znajduje

    public void Draw(Deck deck){
      if(items.Count > 0){
        RemoveAll();
      }
      if(deck.GetSize() > 0){
        Card card = new Card(CardType.TAKE, null);
        card.State = CardState.HOLE;
        CardItem item = itemCreator.CreateItem(card, transform, cardSize);
        items.Add(item);
        // TODO: być może ustawić pozycję
        item.FlipCard();
      }
    }

    public void RemoveAll(){
      foreach(CardItem item in items){
        Destroy(item.gameObject);
      }
      items.Clear();
    }

    public CardItem Remove(Card card){
      if(deck.GetSize() == 0){ // TODO: sprawdzić, jak to wszystko będzie wyglądało
        CardItem item = items[0];
        Destroy(item.gameObject);
        items.Remove(item);
        return item;
      }
      return null;
    }
}
