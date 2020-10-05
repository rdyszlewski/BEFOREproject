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
  // Start is called before the first frame update
  void Start () {
    _cards = new List<Card>();
    cardFactory = GetComponent<CardFactory>();
    Card card1 = cardFactory.GetCard(CardType.MOVE_HORIZONTAL);
    Card card2 = cardFactory.GetCard(CardType.MOVE_VERTICAL);
    _cards.Add(card1);
    _cards.Add(card2);
    RunUpdateHandEvent(true);
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
    // TODO: najpierw można tutaj zrobić animacje
  }

  public void ChooseCard(Card card){
    // TODO: wybieranie karty. Dodanie do kart wybranych, usunięcie kart
  }

}