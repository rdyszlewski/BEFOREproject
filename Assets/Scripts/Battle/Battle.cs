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

  private PhaseInitData data;

  private bool initialized = false;

  void Start () {
    Init ();
    initialized = true;
    Debug.unityLogger.Log("Start finished");
  }

  private void Init () {
    InitComponents ();
    InitPlayers ();
    InitPhases ();
    InitBattleBoard ();
    
    // TODO: wziąć HandRenderer i ustawić tam gracza
  }

  private void InitComponents () {
    InitHand ();
    InitBoard ();
    InitSelectedCards ();
    InitRoundPattern ();
    InitCardFactory ();

    data = new PhaseInitData ();
    data.hand = hand;
    data.board = board;
    data.selectedCards = chosenCards;
    data.roundPattern = roundPattern;
    data.cardsFactory = cardFactory;
    data.cardsRenderer = handRenderer;
  }

  private void InitHand () {
    GameObject gameObject = GameObject.FindGameObjectWithTag ("Hand");
    hand = gameObject.GetComponent<Hand> ();
    handRenderer = gameObject.GetComponent<CardsRenderer> ();
    handRenderer.Init ();
  }

  private void InitBoard () {
    GameObject gameObject = GameObject.FindGameObjectWithTag ("Board");
    board = gameObject.GetComponent<Board> ();
  }

  private void InitSelectedCards () {
    GameObject gameObject = GameObject.FindGameObjectWithTag ("ChosenCards");
    chosenCards = gameObject.GetComponent<SelectedCards> ();
  }

  private void InitRoundPattern () {
    GameObject gameObject = GameObject.FindGameObjectWithTag ("Round");
    roundPattern = gameObject.GetComponent<Pattern> ();
  }

  private void InitCardFactory () {
    GameObject gameObject = GameObject.FindGameObjectWithTag ("CardsFactory");
    cardFactory = gameObject.GetComponent<CardFactory> ();
  }

  private void InitBattleBoard () {
    board.LoadBoard ();
  }

  private void InitPlayers () {
    GameObject playerObject = Instantiate (tempPlayer.gameObject, transform.position, Quaternion.identity, transform) as GameObject;
    // BattlePlayer player = tempPlayer.GetComponent<Player>();
    BattlePlayer player = playerObject.GetComponent<Player> ();
    player.Initialization();
    CardSelectionController cardSelectionController = new CardSelectionController (handRenderer);
    (player as Player).cardSelectionController = cardSelectionController;

    GameObject enemyObject = Instantiate(tempEnemy, transform.position, Quaternion.identity, transform);
    // BattlePlayer enemy = tempEnemy.GetComponent<Enemy> ();
    BattlePlayer enemy = enemyObject.GetComponent<Enemy>();
    enemy.Initialization();
    players = new List<BattlePlayer> ();
    players.Add (player);
    players.Add (enemy);

    // TODO: później przenieść to w inny miejsce
    handRenderer.SetHand (player.hand);
    data.players = players;
  }

  private void InitPhases () {
    BattlePhase generationPhase = GetComponent<GenerationPhase> ();
    generationPhase.InitPhase (data);
    BattlePhase preparationPhase = GetComponent<PreparationPhase> ();
    preparationPhase.InitPhase (data);
    BattlePhase cardPhase = GetComponent<CardPhase> ();
    cardPhase.InitPhase (data);
    BattlePhase actionPhase = GetComponent<ActionPhase> ();
    actionPhase.InitPhase (data);

    phases = new List<BattlePhase> () {
      generationPhase,
      preparationPhase,
      cardPhase,
      actionPhase
    };

    foreach(BattlePlayer player in players){
      player.deck.SetCards (DeckCreator.CreateRandomCards (15, cardFactory));
    }

    currentPhase = NextPhase ();
    currentPhase.Run ();
  }

  private BattlePhase NextPhase () {
    currentPhaseIndex++;
    if (currentPhaseIndex >= phases.Count) {
      currentPhaseIndex = 0;
    }
    return phases[currentPhaseIndex];
  }

  // Update is called once per frame
  void Update () {
    if(initialized){
      if (!currentPhase.IsActive ()) {
        Debug.unityLogger.Log ("Nie jestem aktywny. Ratunku");
      }
      if (currentPhase && currentPhase.IsActive ()) {
        currentPhase.DoAction(); // TODO: czy to będzie potrzebne w Update ?
      } else {
        Debug.unityLogger.Log ("Zmiana fazy");
        currentPhase = NextPhase ();
        currentPhase.Run ();
      }
    }
  }
}