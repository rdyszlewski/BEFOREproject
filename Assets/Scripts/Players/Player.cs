using System;
using UnityEngine;

public class Player : BattlePlayer
{

  private Action<Card> selectionCardCallback;

  private CardSelectionController _cardSelectionController;
  // TODO: card 
  public CardSelectionController cardSelectionController{
    set{_cardSelectionController = value;}
  }
  public override void ChooseAction(Card card, Action<CardAction> onCompleteCallback)
  {
    throw new NotImplementedException();
  }

  public override void ChooseCard(Action<Card> onCompleteCallback)
  {
    selectionCardCallback = onCompleteCallback;
    playerState = PlayerState.CARD_SELECTING;
    Debug.unityLogger.Log("ChooseCard Player");
  }

  public override void FinishAction()
  {
    playerState = PlayerState.WAITING;
  }

  void Update(){
    // TODO: wybieranie karty
    // TODO: zastanowić się 
    // TODO: to można przerobić na interfejs

    // if(_cardSelectionController != null){
    //   _cardSelectionController.Update();
    // }
    switch(playerState){
      case PlayerState.CARD_SELECTING:
        HandleCardSelection();
        break;
      case PlayerState.ACTION_SELECTING:
        HandleCardSelection();
        break;
      // TODO: obsłużyć reszte stanów
    }
  }

  private void HandleCardSelection(){
    _cardSelectionController.Update();
    if(Input.GetMouseButtonDown(0) && _cardSelectionController.selectedCard != null){
      Debug.Assert(selectionCardCallback != null,"Callback cannot be null in this state (CARD_SELECTING)");
      this.playerState = PlayerState.WAITING;
      selectionCardCallback(_cardSelectionController.selectedCard.card);
    }
  }
}