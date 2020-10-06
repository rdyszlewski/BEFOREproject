using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SelectedCards;

public delegate void RevealCardCallback(Card card, DeckAction action);


public class SelectedCards : MonoBehaviour
{

  public enum DeckAction{
    PUT,
    REVEAL,
    REMOVE
  }

  private List<Card> cards;
  private Card currentCard;
  private RevealCardCallback revealCardEvent;
    // Start is called before the first frame update
    void Start()
    {
      cards = new List<Card>();    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

  public void SetChosenCardsCallback(RevealCardCallback callback){
    revealCardEvent = callback;
  }

  public void PutCard(Card card){
    cards.Add(card);
    revealCardEvent(card, DeckAction.PUT);
  }

  public Card RevealCard(bool reverse){
    Card card = reverse ? cards[0]: cards[cards.Count-1];
    // TODO: zaktualizować widok. 
    // TODO: pokazać akcje
    // TODO: uruchomić turę odpowiedniego gracza
    revealCardEvent(card, DeckAction.REVEAL);
    currentCard = card;
    return card;
  }

  public void RemoveCard(){ 
    cards.Remove(currentCard);
    revealCardEvent(currentCard, DeckAction.REMOVE);
    currentCard = null;
  }
}
