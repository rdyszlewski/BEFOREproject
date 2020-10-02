
using System.Collections.Generic;
using System.Diagnostics;

public class Turn{
    
  private List<Step> _steps = new List<Step>();

  public int GetNumberSteps(){
    return _steps.Count;
  }

  public Step GetStep(int index){
    Debug.Assert(index >=0);
    Debug.Assert(index < _steps.Count);

    return _steps[index];
  }

  public void AddStep(Step step){
    _steps.Add(step);
  }
}