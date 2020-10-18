using System;
using System.Collections.Generic;
using UnityEngine;


public class DeckCreator : MonoBehaviour {
  private CardCreator cardCreator;
  private System.Random random = new System.Random();

  void Awake () {
    cardCreator = GetComponent<CardCreator> ();
  }
  // TODO: później dodać wstawianie schematu, dla konkretnego wroga, lub schemat gracza
  public Deck CreateDeck (int size) {
    CardsRenderer renderer = GetComponent<CardsRenderer>();
    Deck deck = new Deck (renderer);
    List<Card> cards = CreateCards (size);
    deck.Initialize (cards);
    return deck;
  }

  private List<Card> CreateCards (int size) {
    List<Card> cards = new List<Card> ();
    for (int i = 0; i < size; i++) {
      CardType type = RandomType();
      Card card = cardCreator.CreateCard (type);
      cards.Add (card);
    }
    return cards;
  }

  private CardType RandomType(){
    Array values = Enum.GetValues(typeof(CardType));
    int index = random.Next(values.Length);
    return (CardType)values.GetValue(index);
  } 

// TODO: to prawdopodobnie zostanie usunięte
  void Start(){
    Deck deck = CreateDeck(15);
    CardsRenderer renderer = GetComponent<CardsRenderer>();
    renderer.Initialize();
    Hand hand = new Hand(5, renderer);
    List<Card> cards = deck.RandomCards(5);
    hand.TakeCards(cards);
    renderer.DrawDeck(deck);
    renderer.DrawHand(hand);
  }
}