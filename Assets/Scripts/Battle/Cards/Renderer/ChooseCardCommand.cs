
using UnityEngine;

public class ChooseCardCommand{

  // TODO: na pewno będzie trzeba tutaj dodać jakieś parametry
  public void Execute(Card card){

    Debug.Log("Wybrano kartę");
    Debug.Log(card.Type);

  }
}