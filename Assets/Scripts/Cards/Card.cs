public class Card{

  private CardType _type;
  private StepType _stepType;
  public CardType type{
    get{return _type;}
    set{_type = value;}
  }

  public StepType stepType{
    get{return _stepType;}
    set{_stepType = value;}
  }

  private bool _reveal = true;
  public bool reveal{
    get{return _reveal;}
    set{_reveal = value;}
  }
}