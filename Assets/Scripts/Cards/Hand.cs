using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void UpdateHand (bool newHand);

public class Hand : MonoBehaviour {
  [SerializeField]
  private int maxCapacity = 5;

  private List<Card> _cards;

  public List<Card> cards{
    get{return _cards;}
  }
  private UpdateHand updateEvent;
  private CardFactory cardFactory;

  private SelectedCards chosenCards; // TODO: to później będzie trzeba usunąć
  
  void Start () {
    _cards = new List<Card>();
    InitCardsFactory();
    InitChosenCards();
    // Card card1 = cardFactory.GetCard(CardType.MOVE_HORIZONTAL);
    // Card card2 = cardFactory.GetCard(CardType.MOVE_VERTICAL);
    // _cards.Add(card1);
    // _cards.Add(card2);
    // RunUpdateHandEvent(true);
  }

  private void InitCardsFactory(){
    GameObject gameObject = GameObject.FindGameObjectWithTag("CardsFactory");
    cardFactory = gameObject.GetComponent<CardFactory>();
  }

  private void InitChosenCards(){
    GameObject gameObject = GameObject.FindGameObjectWithTag("ChosenCards");
    chosenCards = gameObject.GetComponent<SelectedCards>();
  }

  // Update is called once per frame
  void Update () {

  }


  public void SetCards(List<Card> cards) {
    _cards = cards;
    RunUpdateHandEvent(true);
  }

  private void RunUpdateHandEvent (bool createHand) {
    if (updateEvent != null){
      updateEvent(createHand);
    }
  }

  public void SetUpdateEvent(UpdateHand updateEvent){
    this.updateEvent = updateEvent;
  }

  public void RemoveCard(Card card){
    _cards.Remove(card);
    RunUpdateHandEvent(true);
    // TODO: najpierw można tutaj zrobić animacje
  }

  public void ChooseCard(Card card){
    // TODO: wybieranie karty. Dodanie do kart wybranych, usunięcie kart
    Debug.unityLogger.Log("ChooseCard");
    chosenCards.PutCard(card);

    cards.Remove(card);
  }

}