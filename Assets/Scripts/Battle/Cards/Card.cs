
using System.Collections.Generic;

public class Card{
  
  private CardType type;
  public CardType Type{get{return type;}}
  private List<CardAction> actions;
  public List<CardAction> Actions{get{return actions;}}

  private CardState state;

  public Card(CardType type, List<CardAction> actions){
    this.type = type;
    this.actions = actions;
  }
  // TODO: dodać jakieś funkcje
}