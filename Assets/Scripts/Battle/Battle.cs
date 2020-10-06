using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Battle : MonoBehaviour {

  // TODO: komponenty, czy prefabrykaty. O to jest pytanie. 

  private List<BattlePlayer> players;
  private List<BattlePhase> phases;
  private BattlePhase currentPhase;
  private int currentPhaseIndex = -1;

  private Hand hand;
  private Board board;
  private SelectedCards chosenCards;
  private Pattern roundPattern;
  
  [SerializeField]
  private GameObject tempPlayer;

  [SerializeField]
  private GameObject tempEnemy;

  private CardsRenderer handRenderer;

  private CardFactory cardFactory;

  void Start () {
    Init();
  }

  private void Init(){
    InitComponents();
    InitPlayers();
    InitPhases();
    InitBattleBoard();
    // TODO: wziąć HandRenderer i ustawić tam gracza
  }

  private void InitComponents(){
    InitHand();
    InitBoard();
    InitSelectedCards();
    InitRoundPattern();
    InitCardFactory();
  }

  private void InitHand(){
     GameObject gameObject = GameObject.FindGameObjectWithTag("Hand");
     hand = gameObject.GetComponent<Hand>();
     handRenderer = gameObject.GetComponent<CardsRenderer>();
     handRenderer.Init();
  }

  private void InitBoard(){
    GameObject gameObject = GameObject.FindGameObjectWithTag("Board");
    board = gameObject.GetComponent<Board>();
  }

  private void InitSelectedCards(){
    GameObject gameObject = GameObject.FindGameObjectWithTag("ChosenCards");
    chosenCards = gameObject.GetComponent<SelectedCards>();
  }

  private void InitRoundPattern(){
    GameObject gameObject = GameObject.FindGameObjectWithTag("Round");
    roundPattern = gameObject.GetComponent<Pattern>();
  }

  private void InitCardFactory(){
    GameObject gameObject = GameObject.FindGameObjectWithTag("CardsFactory");
    cardFactory = gameObject.GetComponent<CardFactory>();
  }

  private void InitBattleBoard(){
    board.LoadBoard();
  }

     private void InitPlayers(){
      BattlePlayer player = tempPlayer.GetComponent<Player>();
      player.Init();
      player.deck.SetCards(DeckCreator.CreateRandomCards(15, cardFactory));
      BattlePlayer enemy = tempEnemy.GetComponent<Enemy>();
      enemy.Init();
      enemy.deck.SetCards(DeckCreator.CreateRandomCards(15, cardFactory));
      players = new List<BattlePlayer>();
      players.Add(player);
      players.Add(enemy);

      // TODO: później przenieść to w inny miejsce
      handRenderer.SetHand(player.hand);
      
    }

  private void InitPhases(){
    BattlePhase preparationPhase = GetComponent<PreparationPhase>();
    BattlePhase cardPhase = GetComponent<CardPhase>();
    BattlePhase actionPhase = GetComponent<ActionPhase>();
    phases = new List<BattlePhase>(){
      preparationPhase, cardPhase, actionPhase
    };
    currentPhase = NextPhase();
    currentPhase.SetPlayers(players);
    currentPhase.Run();
  }

  private BattlePhase NextPhase(){
    currentPhaseIndex++;
    if(currentPhaseIndex >= phases.Count){
      currentPhaseIndex = 0;
    }
    return phases[currentPhaseIndex];
  }

  // Update is called once per frame
  void Update () {
    if(currentPhase && currentPhase.IsActive()){
      currentPhase.DoAction();
    } else {
      currentPhase = NextPhase();
      currentPhase.SetPlayers(players);
      currentPhase.Run();
    }
  }
}