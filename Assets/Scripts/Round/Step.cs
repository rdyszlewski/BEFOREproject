public class Step{

  private StepType _type;

  public StepType type{
      get{return _type;}
  }

  public Step(StepType type){
      _type = type;
  }
}
