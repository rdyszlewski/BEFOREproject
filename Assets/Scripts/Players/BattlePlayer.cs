using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BattlePlayer : MonoBehaviour
{

  protected enum PlayerState{
    CARD_SELECTING,
    ACTION_SELECTING,
    PREPARING,
    WAITING
  }
  // TODO: każdy gracz powinien mieć karty w ręce i stos kart

    // TODO: przemyśleć dokładnie, jak to powinno wyglądać
    [SerializeField]
    private Deck _deck;
    public Deck deck{
      set{
        Debug.unityLogger.Log("Podmianka decku");
        Debug.unityLogger.Log(value);
        _deck = value;
      }
      get{return _deck;}
    }
    private Hand _hand;
    
    private PlayerState _playerState = PlayerState.WAITING;

    public Hand hand{
      get{return _hand;}
    }
    // public Deck deck{
    //   get{return _deck;}
    // }

    protected PlayerState playerState{
      get{return _playerState;}
      set{_playerState = value;}
    }

    void Start()
    {
        
    }

    public void Initialization(){
      Debug.unityLogger.Log("Initialization player");
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

    // INTERFACE 
    public abstract void ChooseCard(Action<Card> onCompleteCallback);
    public abstract void ChooseAction(Action<CardAction> onCompleteCallback);
    public abstract void FinishAction();

    // TODO: dorzucić akcje wymiany kart, albo czegoś tam jeszcze 
}
