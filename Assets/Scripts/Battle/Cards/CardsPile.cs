using System.Collections.Generic;

public class CardsPile{

  // TODO: dodać jakiś renderer, który będzie wykonywał te akcje
  private Queue<Card> cards;

  public void AddCard(Card card, CardState state){
    card.State = state;
    cards.Enqueue(card);
  }

  public Card RevealCard(){
    return cards.Dequeue();
  }
}