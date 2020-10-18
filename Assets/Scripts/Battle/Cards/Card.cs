
using System.Collections.Generic;

public class Card{
  
  private CardType type;
  public CardType Type{get{return type;}}
  private List<CardAction> actions;
  public List<CardAction> Actions{get{return actions;}}

  private EntityPlayer owner;
  public EntityPlayer Owner{get{return owner;} set{owner = value;}}
  private CardState state;
  public CardState State{get{return state;} set{state=value;}}

  public Card(CardType type, List<CardAction> actions){
    this.type = type;
    this.actions = actions;
  }
  // TODO: dodać jakieś funkcje
}