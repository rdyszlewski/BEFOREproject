using UnityEngine;

public class CardPhase : BattlePhase
{
  public override void DoAction()
  {
    // TODO: jakaś akcja
  }

  protected override void OnStart()
  {
    Debug.unityLogger.Log("Rozpoczynam fazę CardPhase");
    
  }
}