
using System.Collections.Generic;
using UnityEngine;

public class Hand{

  private int capacity;
  private int Capacity{get {return capacity;}}
  private List<Card> cards;
  private HandRenderer handRenderer;

  public Hand(int capacity, HandRenderer handRenderer){
    this.capacity = capacity;
    this.handRenderer = handRenderer;
  }

  public void AddCard(Card card){
    cards.Add(card);
    handRenderer.AddCard(card);
  }

  public void TakeCards(List<Card> cards){
    Debug.Assert(cards.Count <= capacity);
    this.cards = cards;
  }

  public void DiscardCards(){
    this.cards.Clear();
    handRenderer.RemoveAll();
  }

  public void RemoveCard(Card card){
    this.cards.Remove(card);
    handRenderer.Remove(card);
  }

  public void ChooseCard(Card card){
    // TODO: zastanowić się, czy ta metoda powinna tak wyglądać. Czy wystraczy, że usunięmy ją
    // TODO: na razie nie wiem, jak to powinno działać
  }

  public int GetSize(){
    return cards.Count;
  }

  public Card GetCard(int index){
    Debug.Assert(index >= 0 && index < cards.Count); // TODO: sprawdzić później ten warunek
    return cards[index];
  }
}