using System.Collections.Generic;
using UnityEngine;

public class TurnItem : MonoBehaviour {
  private Transform stepsContainer;
  private Transform effectsContainer;

  private List<StepItem> steps;
  public List<StepItem> Steps { set { steps = value; } }


  public void Initialize () {
    stepsContainer = transform.Find ("Steps");
    effectsContainer = transform.Find ("Effects");

  }

}