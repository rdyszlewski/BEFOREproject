using System.Collections.Generic;
using UnityEngine;

public class PreparationPhase : BattlePhase
{
  
  [SerializeField]
  private int numberCardsOnHand = 5;

  private CardsRenderer handRenderer;

  void Start(){
    handRenderer = GameObject.FindGameObjectWithTag("Hand").GetComponent<CardsRenderer>();  
  }
  

  public override void DoAction()
  {
    // TODO:
  }

  protected override void OnStart()
  {
    // TODO:
    foreach(BattlePlayer player in players){
      player.RandomCards(numberCardsOnHand);
    }
    handRenderer.UpdateHand();
    Debug.unityLogger.Log("Rozpoczynamy fazę PreparationPhase");
    FinishPhase();
    // TODO: można zrobić, aby użytkownik musiał potwierdzić wybór kart. Wymiana niepasujących kart
  }

}