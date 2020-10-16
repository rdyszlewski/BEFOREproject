
using System.Collections.Generic;

public class Card{
  
  private CardType type;
  public CardType Type{get{return type;}}
  private List<CardAction> actions;

  private CardState state;

  public Card(CardType type){
    this.type = type;
  }

  // TODO: dodać jakieś funkcje
}