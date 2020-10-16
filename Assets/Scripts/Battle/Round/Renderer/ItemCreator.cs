using System.Collections.Generic;
using UnityEngine;

public class ItemCreator : MonoBehaviour {
  [SerializeField]
  private GameObject turnObject;

  private StepItemCreator stepItemCreator;

  void Awake () {
    stepItemCreator = GetComponent<StepItemCreator> ();
  }

  public TurnItem CreateTurnItem (Turn turn, Transform parent) {
    GameObject turnObject = CreateTurn (parent);
    GameObject stepsContainer = turnObject.transform.Find ("Steps").gameObject;
    List<StepItem> steps = CreateStepsItems (turn, stepsContainer);
    TurnItem turnItem = InitializeTurnItem(turnObject, steps);
    return turnItem;
  }

  private GameObject CreateTurn (Transform parent) {
    GameObject createdTurn = Instantiate (turnObject, parent);
    return createdTurn;
  }

  private List<StepItem> CreateStepsItems (Turn turn,  GameObject stepsContainer) {
    List<StepItem> steps = new List<StepItem> ();
    for (int i = 0; i < turn.CountSteps (); i++) {
      Step step = turn.GetStep (i);
      StepItem item = stepItemCreator.CreateStepItem (step.Type,  stepsContainer.transform);
      steps.Add (item);
    }
    return steps;
  }

  private TurnItem InitializeTurnItem(GameObject turnObject, List<StepItem> steps){
     TurnItem turnItem = turnObject.GetComponent<TurnItem>();
    turnItem.Initialize();
    turnItem.Steps = steps;
    return turnItem;
  }

  private void AppendStepItemToTurnItem (List<StepItem> steps, GameObject stepsContainer) {
    foreach (StepItem step in steps) {
      step.transform.SetParent(stepsContainer.transform);
    }
  }
}