using System.Collections.Generic;
using UnityEngine;

public class DeckCreator : MonoBehaviour {
  private CardCreator cardCreator;

  void Awake () {
    cardCreator = GetComponent<CardCreator> ();
  }
  // TODO: później dodać wstawianie schematu, dla konkretnego wroga, lub schemat gracza
  public Deck CreateDeck (int size) {
    Deck deck = new Deck ();
    List<Card> cards = CreateCards (size);
    deck.Initialize (cards);
    return deck;
  }

  private List<Card> CreateCards (int size) {
    List<Card> cards = new List<Card> ();
    // TODO: zrobić jakieś fajne rzeczy
    for (int i = 0; i < size; i++) {
      Card card = cardCreator.CreateCard (CardType.MOVE_HORIZONTAL);
      cards.Add (card);
    }
    return cards;
  }

// TODO: to prawdopodobnie zostanie usunięte
  void Start(){
    Deck deck = CreateDeck(15);
    HandRenderer renderer = GetComponent<HandRenderer>();
    renderer.Initialize();
    Hand hand = new Hand(5, renderer);
    List<Card> cards = deck.RandomCards(5);
    hand.TakeCards(cards);
    renderer.Draw(hand);
  }
}