using System.Collections.Generic;
using UnityEngine;

public class PreparationPhase : BattlePhase {

  [SerializeField]
  private int numberCardsOnHand = 5;

  private CardsRenderer handRenderer;

  void Start () {
    handRenderer = GameObject.FindGameObjectWithTag ("Hand").GetComponent<CardsRenderer> ();
  }

  public override void DoAction () {
    // TODO: zastanowić się, co tutaj jeszcze jest potrzebne
  }

  protected override void OnStart () {
    // TODO:
    Debug.unityLogger.Log ("Rozpoczynamy fazę PreparationPhase");
    foreach (BattlePlayer player in data.players) {
      player.RandomCards (numberCardsOnHand);
    }
    handRenderer.UpdateHand();
    Debug.unityLogger.Log("Kończenie fazy PreparationPhase");
    FinishPhase ();
    Debug.unityLogger.Log("To nie wiem, czy się wykona");
    // TODO: można zrobić, aby użytkownik musiał potwierdzić wybór kart. Wymiana niepasujących kart
  }

}