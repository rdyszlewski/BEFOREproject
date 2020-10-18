
using UnityEngine;

public class ChooseCardCommand{

  // TODO: na pewno będzie trzeba tutaj dodać jakieś parametry
  private Hand hand;

  public ChooseCardCommand(Hand hand){
    this.hand = hand;
  }

  public void Execute(Card card){

    // TODO: zaimplementować odpowiednie działanie
    hand.RemoveCard(card);

  }
}