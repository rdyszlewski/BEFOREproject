using System.Collections.Generic;
using UnityEngine;

public class ActionPhase : BattlePhase
{

  private CardsRenderer handRenderer;
  private List<BattlePlayer> _players;
  private BattlePlayer _currentPlayer;
  private SelectedCards _selectedCards;

  private Pattern _pattern;

  void Start(){
    handRenderer = GameObject.FindGameObjectWithTag("Hand").GetComponent<CardsRenderer>();
  }

  public override void DoAction()
  {
    // TODO:
  }

  protected override void OnStart()
  {
    Debug.unityLogger.Log("Rozpoczynam fazę ActionPhase");
    _players = data.players;
    _selectedCards = data.selectedCards;
    
    Card card = NextCard();
    _currentPlayer = card.owner;
    Debug.unityLogger.Log(_currentPlayer.GetType());
    if(_currentPlayer.GetType() == typeof(Player)){
      Debug.unityLogger.Log("Kolej gracza");
      data.actionRenderer.SetActions(card.actions);
    }
    _currentPlayer.ChooseAction(card, ChooseAction);
    // TODO: odsłonięcie akcji na stosie
  }

  private void ChooseAction(CardAction action){
   Debug.unityLogger.Log("Wybrano akcje");
    action.PerformAction(); // TODO: to powinno być wykonywane z jakąś animacją czy coś
    // TODO
    data.actionRenderer.DestroyAllCards();
    Card card = NextCard();
    // TODO: powstawiać jakieś fajne warunki
    if(card == null){
      Debug.unityLogger.Log("Zakończono Ostatnią Turę");
      FinishPhase();
      return;
    }
    _currentPlayer = card.owner;
    if(_currentPlayer.GetType() == typeof(Player)){
      Debug.unityLogger.Log("odsunąć się, teraz kolej gracza");
      data.actionRenderer.SetActions(card.actions);
    }
    _currentPlayer.ChooseAction(card, ChooseAction);
  }

  private Card NextCard(){
    // TODO: później zrobić odpowiednio pobieranie ze stosu, jeżeli odwrócenie
    // TODO: w tym miejscu należy usunąć wszystkie karty
    return _selectedCards.RevealCard(true); // TODO: sprawdzić, czy o to będzie chodziło
  }

  protected override void OnFinishPhase()
  {
    data.actionRenderer.DestroyAllCards();
    // TODO: usunąć wszystko
  }
}