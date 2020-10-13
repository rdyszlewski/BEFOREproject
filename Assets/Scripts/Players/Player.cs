using System;
using UnityEngine;

public class Player : BattlePlayer
{

  private Action<Card> selectionCardCallback;
  private Action<CardAction> selectionActionCallback;

  private CardSelectionController _cardSelectionController;
  // TODO: card 
  public CardSelectionController cardSelectionController{
    set{_cardSelectionController = value;}
  }

  private ActionSelectionController _actionSelectionController;
  public ActionSelectionController actionSelectionController{
    set{_actionSelectionController = value;}
  }

  public override void ChooseAction(Card card, Action<CardAction> onCompleteCallback)
  {
    Debug.unityLogger.Log("ChooseAction");
    selectionActionCallback = onCompleteCallback;
    playerState = PlayerState.ACTION_SELECTING;

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
        HandleActionSelection();
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

  private void HandleActionSelection(){
    _actionSelectionController.Update();
    if(Input.GetMouseButton(0) && _actionSelectionController.selectedCard != null){
      this.playerState = PlayerState.WAITING;
      selectionActionCallback(_actionSelectionController.selectedCard.action);
    }
  }
}