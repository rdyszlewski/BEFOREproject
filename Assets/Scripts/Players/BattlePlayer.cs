using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattlePlayer : MonoBehaviour
{
  // TODO: każdy gracz powinien mieć karty w ręce i stos kart

    // TODO: przemyśleć dokładnie, jak to powinno wyglądać
    private Deck _deck;
    private Hand _hand;

    public Hand hand{
      get{return _hand;}
    }

    public Deck deck{
      get{return _deck;}
    }

    void Start()
    {
        
    }

    public void Init(){
      _hand = GetComponent<Hand>();
      _deck = GetComponent<Deck>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RandomCards(int numberCards){
        List<Card> cards = _deck.RandomCards(numberCards);
        _hand.SetCards(cards);
    }
}
