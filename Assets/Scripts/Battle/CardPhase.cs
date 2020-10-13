using System.Collections.Generic;
using UnityEngine;

// Faza wyboru karty
// Faza trwa runde
// Każdą turę po kolei wykonuje każdy z graczy
// Gracz musi oddać karty

public class CardPhase : BattlePhase
{

  private CardsRenderer handRenderer;

  private List<BattlePlayer> _players;
  private BattlePlayer _currentPlayer;
  private int currentPlayerIndex;
  private Pattern _pattern;

  void Start(){
    handRenderer = GameObject.FindGameObjectWithTag("Hand").GetComponent<CardsRenderer>();
  }

  public override void DoAction()
  {
    // TODO: jakaś akcji
    
  }

  protected override void OnStart()
  {
    Debug.unityLogger.Log("Rozpoczynam fazę CardPhase");
    _players = data.players;
    _pattern = data.roundPattern;
    currentPlayerIndex = -1;

    _currentPlayer = NextPlayer();
    _currentPlayer.ChooseCard(ChooseCard);
    // TODO: prawdopodobnie będzie trzeba wybrać pierwszego gracza
    
  }

  private void ChooseCard(Card card){
    Debug.unityLogger.Log(_pattern.GetCurrentStep().type);
    card.stepType = _pattern.GetCurrentStep().type;
    // Debug.unityLogger.Log(card.stepType);
    data.selectedCards.PutCard(card);
    // TODO: tutaj jest jakiś problem. Trzeba się dokładniej przyjrzeć. 

    _currentPlayer.hand.RemoveCard(card); // TODO: sprawdzić, czy się będzie to wyświetlać
    bool endOfTurn = _pattern.NextStep();
    if(endOfTurn){
      // TODO: w tym miejscu jest zmiana gracza
      Debug.unityLogger.Log("Zmieniam gracza");
      _currentPlayer = NextPlayer();
      if(_currentPlayer == null){
      
        Debug.unityLogger.Log("Zmieniam ture");
        bool endOfRound = _pattern.NextTurn();
        if(endOfRound){
          Debug.unityLogger.Log("Zakończono faze");
          _currentPlayer = null;
          // TODO: odpowiednio zamknąć faze
          FinishPhase();
        } else {
          currentPlayerIndex = -1;
          // TODo: przenieść to do jakieś metody
          _currentPlayer = NextPlayer();
          _currentPlayer.ChooseCard(ChooseCard);
        }
      } else {
        _pattern.ResetStep();
        _currentPlayer.ChooseCard(ChooseCard);
      }
    } else {
      _currentPlayer.ChooseCard(ChooseCard);
    }
  }

  private void ChangePlayer(){
    _currentPlayer = NextPlayer();
    if(_currentPlayer == null){ // koniec 
      Debug.unityLogger.Log("Kolejna tura");
      // TODO: zmiana kolejności powinna być chyba w tym miejscu
    }
    _currentPlayer.ChooseCard(ChooseCard);
  }

  private BattlePlayer NextPlayer(){
    currentPlayerIndex++;
    if(currentPlayerIndex>=_players.Count){
      // currentPlayerIndex = 0;
      return null;
    }
    return _players[currentPlayerIndex];
  }

  protected override void OnFinishPhase()
  {
    data.cardsRenderer.DestroyAllCards();
    // TODO: może istnieje jakiś inny sposób, żeby to zrobić
  }
}