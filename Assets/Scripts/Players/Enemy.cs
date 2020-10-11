using System;
using System.Threading;
using UnityEngine;

public class Enemy : BattlePlayer
{
  
  private Action<Card> onCompleteCallback;
  private Card chosenCard;

  public override void ChooseAction(Action<CardAction> onCompleteCallback)
  {
    throw new NotImplementedException();
  }

  public override void ChooseCard(Action<Card> onCompleteCallback)
  { 
    // TODO: to wszystko prawdopodbnie jest do poprawy
    this.onCompleteCallback = onCompleteCallback;
    Thread thread = new Thread(RunChoosingCard);
    thread.Start();
  }

  private void RunChoosingCard(){
    Card card = hand.cards[0];
    chosenCard = card;
    Debug.unityLogger.Log("Przeciwnik położył kartę");
  }
  
  void Update(){
    if(chosenCard != null){
      onCompleteCallback(chosenCard);
      chosenCard = null;
    }
  }

  public override void FinishAction()
  {
    throw new NotImplementedException();
  }

}