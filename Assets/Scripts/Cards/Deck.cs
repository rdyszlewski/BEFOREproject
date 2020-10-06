using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Deck : MonoBehaviour
{   

  private List<Card> allCards;
  private List<Card> availableCards;
  private HashSet<Card> usedCards;
    // Start is called before the first frame update
    void Start()
    {
        allCards = new List<Card>();
        usedCards = new HashSet<Card>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public List<Card> RandomCards(int numberCards){
      List<Card> shuffledCards = allCards.OrderBy(x => Guid.NewGuid()).ToList();
      List<Card> result = allCards.GetRange(0, numberCards);
      availableCards = allCards.GetRange(numberCards, allCards.Count - numberCards);
      return result;
    }

    public void SetCards(List<Card> cards){
      allCards = cards;
    }

    public void AddCard(Card card){
      allCards.Add(card);
    }

    // TODO: zastanowić się, co tutaj jeszcze jest potrzebne
}
