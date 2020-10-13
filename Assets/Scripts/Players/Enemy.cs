using System;
using System.Threading;
using UnityEngine;

public class Enemy : BattlePlayer
{
  
  private Action<Card> onCompleteCardCallback;
  private Action<CardAction> onCompleteActionCallback;
  private Card chosenCard;
  private CardAction chosenAction;

  public override void ChooseAction(Card card,Action<CardAction> onCompleteCallback)
  {
    playerState = PlayerState.ACTION_SELECTING;
    this.onCompleteActionCallback = onCompleteCallback;
    Thread thread = new Thread(()=>RunChoosingAction(card));
    thread.Start();
  }

  private void RunChoosingAction(Card card){
    CardAction action = card.actions[0];
    chosenAction = action;
  }

  public override void ChooseCard(Action<Card> onCompleteCallback)
  { 
    playerState = PlayerState.CARD_SELECTING;
    // TODO: to wszystko prawdopodbnie jest do poprawy
    this.onCompleteCardCallback = onCompleteCallback;
    Thread thread = new Thread(RunChoosingCard);
    thread.Start();
  }

  private void RunChoosingCard(){
    Card card = hand.cards[0];
    chosenCard = card;
    Debug.unityLogger.Log("Przeciwnik położył kartę");
  }
  
  void Update(){
    switch(playerState){
      case PlayerState.CARD_SELECTING:
        HandleCardSelecting();
        break;
      case PlayerState.ACTION_SELECTING:
        HandleActionSelecting();
        break;
    }
  }

  private void HandleCardSelecting(){
    if(chosenCard != null){
      onCompleteCardCallback(chosenCard);
      chosenCard = null;
      playerState = PlayerState.WAITING;
    }
  }

  private void HandleActionSelecting(){
    if(chosenAction != null){
      Debug.unityLogger.Log("Wróg skończył wybieranie karty");
      onCompleteActionCallback(chosenAction);
      chosenAction = null;
      playerState = PlayerState.WAITING;
    }
  }

  public override void FinishAction()
  {
    // TODO: tutaj nie mam pojęcia, co tutaj ma być
  }

}