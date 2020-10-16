using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundController : MonoBehaviour {
  private Round round;
  private RoundRenderer roundRenderer;

  private int currentTurn = 0;
  private int currentStep = 0;
  void Start () {
    roundRenderer = GetComponent<RoundRenderer> ();
    roundRenderer.Initialization ();
    round = MockRound ();
    roundRenderer.DrawPattern (round);

    roundRenderer.Select(currentTurn, currentStep);
  }

  private Round MockRound () {
    Step step1 = new Step (StepType.HOLE);
    Step step2 = new Step (StepType.OPEN);
    Step step3 = new Step (StepType.OPEN);
    Step step4 = new Step (StepType.HOLE);

    Turn turn1 = new Turn (new List<Step> { step1, step2 });
    Turn turn2 = new Turn (new List<Step> { step3 });
    Turn turn3 = new Turn (new List<Step> { step4 });

    Round round = new Round (new List<Turn> { turn1, turn2, turn3 });
    return round;
  }

  // Update is called once per frame
  void Update () {
    if(Input.GetMouseButtonDown(0)){
      NextStep();
    }
  }

  public void NextStep(){
    DeselectCurrentStep();
    // TODO: zmienić pozycję
    if(IsNextStep()){
      currentStep++;
    } else {
      NextTurn();
    }
    SelectCurrentStep();
  }

  private void SelectCurrentStep(){
    roundRenderer.Select(currentTurn, currentStep);
  }

  private void DeselectCurrentStep(){
    roundRenderer.Deselect(currentTurn, currentStep);
  }

  public void FirstStep(){
    currentStep = 0;
    SelectCurrentStep();
  }

  public void NextTurn(){
    DeselectCurrentStep();
    if(IsNextTurn()){
      currentTurn++;
      FirstStep();
    } else {
      currentTurn = 0;
      FirstStep();
    }
  }

  public bool IsNextStep(){
    // TODO: sprawdzić, czy działa poprawnie
    return currentStep < round.GetTurn(currentTurn).CountSteps()-1;
  }

  public bool IsNextTurn(){
    return currentTurn < round.CountTurns() -1;
  }
}