using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SelectedCards;

public delegate void RevealCardCallback (Card card, DeckAction action);

public class SelectedCards : MonoBehaviour {

  public enum DeckAction {
    PUT,
    REVEAL,
    REMOVE
  }

  private CardsStack<Card> cards;
  private Card currentCard;
  private RevealCardCallback revealCardEvent;
  void Start () {
    cards = new CardsStack<Card> ();
  }

  void Update () {

  }

  public void SetChosenCardsCallback (RevealCardCallback callback) {
    revealCardEvent = callback;
  }

  public void PutCard (Card card) {
    cards.Push (card);
    revealCardEvent (card, DeckAction.PUT);
  }

  public Card RevealCard (bool reverse) {
    Card card = reverse ? cards.PopLast () : cards.PopFirst ();
    if(card != null){
      revealCardEvent (card, DeckAction.REVEAL);
      currentCard = card;
    }
    // TODO: czy na pewno tutaj będzie usuwana karta?
    return card;
  }
}