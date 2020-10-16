
using System.Collections.Generic;

public class Deck{
  
  private List<Card> cards;

  private HashSet<Card> usedCard;

  public List<Card> RandomCards(int cardsNumber){
    // List<Card> randomCards = new List<Card>();
    // // TODO: tutaj jakaś magia
    // return randomCards;
    return cards.GetRange(0, cardsNumber);
  }

  public void Reset(){
    // TODO: zastanowić się, czy robić used, czy nie 
  }

  public void AddCard(Card card){
    cards.Add(card);
  }

  public void RemoveCard(Card card){
    cards.Remove(card);
  }

  public void Initialize(List<Card> cards){
    this.cards = cards;
  }

  public int GetSize(){
    if(cards == null){
      return 0;
    }
    return cards.Count;
  }
}