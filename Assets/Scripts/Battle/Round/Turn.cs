
using System.Collections.Generic;
using UnityEngine;

public class Turn{

  private List<Step> steps;

  public Turn(List<Step> steps){
    Debug.Assert(steps != null && steps.Count != 0);
    this.steps = steps;
  }

  public int CountSteps(){
    return steps.Count;
  }

  public Step GetStep(int stepNumber){
    if(IsCorrectStep(stepNumber)){
      return steps[stepNumber];
    }
    return null;
  }

  private bool IsCorrectStep(int index){
    return index >= 0 && index < steps.Count;
  }
}