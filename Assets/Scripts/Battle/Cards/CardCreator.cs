using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardCreator : MonoBehaviour
{

  public Card CreateCard(CardType type){
    // TODO: wstawić tutaj odpowiednią implementację
    Card card = new Card(type);
    return card;
  }

}
