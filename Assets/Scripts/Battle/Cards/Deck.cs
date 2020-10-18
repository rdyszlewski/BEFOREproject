
using System;
using System.Collections.Generic;
using System.Linq;

public class Deck{
  
  private List<Card> cards;

  private HashSet<Card> usedCards;

  private CardsRenderer renderer;

  public Deck(CardsRenderer renderer){
    this.renderer = renderer;
  }

  public List<Card> RandomCards(int amount){
    List<Card> notUsedCards = GetNotUsedCards();
    int cardsNumber = notUsedCards.Count >= amount ? amount: notUsedCards.Count;
    List<Card> shuffledCards = notUsedCards.OrderBy(x=>Guid.NewGuid()).ToList();
    List<Card> resultsCards = notUsedCards.GetRange(0, cardsNumber);
    foreach(Card card in resultsCards){
      usedCards.Add(card);
    }
    return cards.GetRange(0, cardsNumber);
  }

  private List<Card> GetNotUsedCards(){
    return cards.FindAll(x=>!usedCards.Contains(x)).ToList();
  }

  public void Reset(){
    usedCards.Clear();
  }

  public void AddCard(Card card){
    cards.Add(card);
  }

  public void RemoveCard(Card card){
    cards.Remove(card);
    usedCards.Remove(card);
  }

  public void Initialize(List<Card> cards){
    this.cards = cards;
    usedCards = new HashSet<Card>();
  }

  public int GetSize(){
    if(cards == null){
      return 0;
    }
    // TODO: zobaczyć, czy to tak powinno być
    return cards.Count - usedCards.Count;
  }
}