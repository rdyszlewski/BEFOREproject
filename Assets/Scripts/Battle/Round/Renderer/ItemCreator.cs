using System.Collections.Generic;
using UnityEngine;

public class ItemCreator : MonoBehaviour {
  [SerializeField]
  private GameObject turnObject;

  [SerializeField]
  private GameObject stepObject;

  private StepItemCreator stepItemCreator;

  void Awake () {
    stepItemCreator = GetComponent<StepItemCreator> ();
  }

  public TurnItem CreateTurnItem (Turn turn, Vector2 itemSize, Transform parent) {
    GameObject turnObject = CreateTurn (parent);
    GameObject stepsContainer = turnObject.transform.Find ("Steps").gameObject;
    List<StepItem> steps = CreateStepsItems (turn, itemSize, stepsContainer);
    TurnItem turnItem = turnObject.GetComponent<TurnItem>();
    turnItem.Initialize();
    turnItem.Steps = steps;
    turnItem.Resize();

    return turnItem;
  }

  private GameObject CreateTurn (Transform parent) {
    GameObject createdTurn = Instantiate (turnObject, parent);
    return createdTurn;
  }

  private List<StepItem> CreateStepsItems (Turn turn, Vector2 itemSize, GameObject stepsContainer) {
    List<StepItem> steps = new List<StepItem> ();
    for (int i = 0; i < turn.CountSteps (); i++) {
      Step step = turn.GetStep (i);
      StepItem item = stepItemCreator.CreateStepItem (step.Type, itemSize, stepsContainer.transform);
      steps.Add (item);
    }
    return steps;
  }

  private void AppendStepItemToTurnItem (List<StepItem> steps, GameObject stepsContainer) {
    foreach (StepItem step in steps) {
      step.transform.SetParent(stepsContainer.transform);
    }
  }
}