public class Card{

  private CardType _type;
  public CardType type{
    get{return _type;}
    set{_type = value;}
  }

  private bool _reveal = true;
  public bool reveal{
    get{return _reveal;}
    set{_reveal = value;}
  }
}