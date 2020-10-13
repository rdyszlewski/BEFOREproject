using UnityEngine;

public class GenerationPhase : BattlePhase
{

  [SerializeField]
  private int maxTurns = 3;

  [SerializeField]
  private int minTurns = 1;

  [SerializeField]
  private int minCards = 3;

  [SerializeField]
  private int maxCards = 5;

  [SerializeField]
  private int minSteps = 1;

  [SerializeField]
  private int maxSteps = 1;

  [SerializeField]
  private bool allowHidden = true;

  public override void DoAction()
  {

  }

  protected override void OnFinishPhase()
  {
    // TODO: tutaj chyba nic się nie dzieje
  }

  protected override void OnStart()
  {
    Debug.unityLogger.Log("Rozpoczęto fazę generowania rundy");
    // TODO: to będzie trzeba dość mocno zmienić, ponieważ w tym momencie nie ma możliwości sterowania generatorem, przez co rozgrywka może być niemożliwa. Pomyśleć, jak to zrobić poprawnie
    data.roundPattern.LoadPattern();
    Debug.unityLogger.Log("Kończenie fazy generowania rundy");
    FinishPhase();
    // TODO: dlaczego to nie chce działać?
  }
}