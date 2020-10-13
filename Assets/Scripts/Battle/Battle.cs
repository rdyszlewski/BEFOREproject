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
  private ActionRenderer actionRenderer;

  private CardFactory cardFactory;

  private PhaseInitData data;

  private bool initialized = false;

  void Start () {
    Init ();
    initialized = true;
    Debug.unityLogger.Log ("Start finished");
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
    InitActionRenderer();

    // TODO: to można zrobić inaczej
    data = new PhaseInitData ();
    data.hand = hand;
    data.board = board;
    data.selectedCards = chosenCards;
    data.roundPattern = roundPattern;
    data.cardsFactory = cardFactory;
    data.cardsRenderer = handRenderer;
    data.actionRenderer = actionRenderer;
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

  private void InitActionRenderer () {
    GameObject gameObject = GameObject.FindGameObjectWithTag ("Actions");
    actionRenderer = gameObject.GetComponent<ActionRenderer> ();
    actionRenderer.Init();
  }

  private void InitBattleBoard () {
    board.LoadBoard ();
  }

  private void InitPlayers () {
    BattlePlayer player = CreatePlayerTemp ();
    BattlePlayer enemy = CreateEnemyTemp ();

    players = new List<BattlePlayer> ();
    players.Add (player);
    players.Add (enemy);

    // TODO: później przenieść to w inny miejsce
    handRenderer.SetHand (player.hand); // TODO: pomyśleć, jak to powinno być
    data.players = players;
  }

  private BattlePlayer CreatePlayerTemp () {
    GameObject playerObject = Instantiate (tempPlayer.gameObject, transform.position, Quaternion.identity, transform) as GameObject;
    // BattlePlayer player = tempPlayer.GetComponent<Player>();
    BattlePlayer player = playerObject.GetComponent<Player> ();
    player.Initialization ();
    // TODO: sprawdzić, czy to jest odpowiednie miejsce, żeby to przekazywać. Czy nie można tego zrobić jakoś w klasie Player
    CardSelectionController cardSelectionController = new CardSelectionController (handRenderer);
    (player as Player).cardSelectionController = cardSelectionController;
    ActionSelectionController actionSelectionController = new ActionSelectionController (actionRenderer);
    (player as Player).actionSelectionController = actionSelectionController;
    return player;
  }

  private BattlePlayer CreateEnemyTemp () {
    GameObject enemyObject = Instantiate (tempEnemy, transform.position, Quaternion.identity, transform);
    // BattlePlayer enemy = tempEnemy.GetComponent<Enemy> ();
    BattlePlayer enemy = enemyObject.GetComponent<Enemy> ();
    enemy.Initialization ();
    return enemy;
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

    foreach (BattlePlayer player in players) {
      // TODO: to raczej powinno być w innym miejscu
      List<Card> cards = DeckCreator.CreateRandomCards (15, cardFactory);
      foreach (Card card in cards) {
        card.owner = player;
      }
      player.deck.SetCards (cards);
    }

    currentPhase = NextPhase ();
    currentPhase.Run ();
  }

  private BattlePhase NextPhase () {
    currentPhaseIndex++;
    if (currentPhaseIndex >= phases.Count) {
      // currentPhaseIndex = 0;
      Debug.unityLogger.Log ("Gratulacje, skończono gre");
      return null;
    }
    return phases[currentPhaseIndex];
  }

  // Update is called once per frame
  void Update () {
    if (initialized && currentPhase != null) {
      if (!currentPhase.IsActive ()) {
        Debug.unityLogger.Log ("Nie jestem aktywny. Ratunku");
      }
      if (currentPhase && currentPhase.IsActive ()) {
        currentPhase.DoAction (); // TODO: czy to będzie potrzebne w Update ?
      } else {
        Debug.unityLogger.Log ("Zmiana fazy");
        currentPhase = NextPhase ();
        if (currentPhase == null) {
          Debug.unityLogger.Log ("KONIEC");
        }
        currentPhase.Run (); // TODO: tymczasowo może tutaj wyskoczyć błąd, dodać później jakieś warunki wyjścia z gry
      }
    }
  }
}