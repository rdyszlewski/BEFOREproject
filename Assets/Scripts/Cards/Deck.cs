using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Deck : MonoBehaviour
{   

  [SerializeField]
  private List<Card> allCards = new List<Card>();

  private List<Card> availableCards = new List<Card>();
  private HashSet<Card> usedCards = new HashSet<Card>();
    // Start is called before the first frame update
    void Start()
    {
      // Debug.unityLogger.Log("Inicjalizacja talii");
      //   allCards = new List<Card>();
      //   usedCards = new HashSet<Card>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public List<Card> RandomCards(int numberCards){
      Debug.Assert(allCards.Count >= numberCards);
      List<Card> shuffledCards = allCards.OrderBy(x => Guid.NewGuid()).ToList();
      List<Card> result = allCards.GetRange(0, numberCards);
      availableCards = allCards.GetRange(numberCards, allCards.Count - numberCards);
      return result;
    }

    public void SetCards(List<Card> cards){
      Debug.unityLogger.Log("SetCards");
      Debug.unityLogger.Log(cards.Count);
      allCards = cards;
    }

    public void AddCard(Card card){
      allCards.Add(card);
    }

    // TODO: zastanowić się, co tutaj jeszcze jest potrzebne
}
