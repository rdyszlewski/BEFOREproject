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
    _currentPlayer.ChooseAction(card, ChooseAction);
    // odsłonięcie karty
  }

  private void ChooseAction(CardAction action){
   Debug.unityLogger.Log("Wybrano akcje");
    action.PerformAction();
    // TODO: wybranie następnego gracza
    Card card = NextCard();
    // TODO: powstawiać jakieś fajne warunki
    if(card == null){
      Debug.unityLogger.Log("Zakończono Ostatnią Turę");
      FinishPhase();
    }
    _currentPlayer = card.owner;
    _currentPlayer.ChooseAction(card, ChooseAction);
  }

  private Card NextCard(){
    // TODO: później zrobić odpowiednio pobieranie ze stosu, jeżeli odwrócenie
    // od końca
    return _selectedCards.RevealCard(true); // TODO: sprawdzić, czy o to będzie chodziło

  }
}